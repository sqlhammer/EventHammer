using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DKK_App.Entities;
using DKK_App.Models;
using DKK_App.Enums;
using System.Threading.Tasks;
using System.Drawing;

namespace DKK_App
{
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();
        public List<Models.MatchModel> MatchModels = new List<MatchModel>();
        public List<Models.CompetitorModel> CompetitorModels = new List<CompetitorModel>();
        public List<Division> Divisions = new List<Division>();

        public frmMain()
        {
            InitializeComponent();
        }
        
        private void btnRefreshMatchTab_Click(object sender, EventArgs e)
        {
            MatchModels = new List<MatchModel>();
            CompetitorModels = new List<CompetitorModel>();
            RefreshMatchCompetitorViews();
        }

        private async void RefreshDivisionsAsync()
        {
            Divisions = await DataAccessAsync.GetDivisions();
        }
        
        private void RefreshMatchCompetitorViews()
        {
            this.lblLoading.Visible = true;
            this.tmrMatchCompetitorRefresh.Enabled = true;

            Task.Run(() => { RefreshMatchesAndCompetitors(); });           
        }

        private void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load only on the first click.
            //Manual refreshes after that.
            if (this.tabMatch.Enabled &&
                this.tab1.SelectedTab == this.tabMatch &&
                MatchModels.Count == 0)
            {
                RefreshMatchCompetitorViews();
            }

            //Toggle button visibility
            if (this.tabMatch.Enabled &&
                this.tab1.SelectedTab == this.tabMatch &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshMatchTab.Visible = true;
                this.btnClearFilters.Visible = true;
            }
            else
            {
                this.btnRefreshMatchTab.Visible = false;
                this.btnClearFilters.Visible = false;
            }
        }

        private FilterType TranslateToFilterType(string strtype)
        {
            FilterType type = FilterType.Unknown;

            switch (strtype)
            {
                case "Name":
                    type = FilterType.DisplayName;
                    break;
                case "Belt":
                    type = FilterType.Belt;
                    break;
                case "Age (+/- 2 yrs)":
                    type = FilterType.Age;
                    break;
                case "Weight (+/- 5 lbs)":
                    type = FilterType.Weight;
                    break;
                case "Div-SubDiv":
                    type = FilterType.MatchDisplayName;
                    break;
                case "Type":
                    type = FilterType.MatchType;
                    break;
                case "School":
                    type = FilterType.DojoName;
                    break;
            }

            return type;
        }

        private async void btnCompetitorApply_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.cbCompetitorFilterBy.SelectedItem.ToString()))
            {
                FilterType type = TranslateToFilterType(this.cbCompetitorFilterBy.SelectedItem.ToString());

                var model = await Global.FilterCompetitorModelAsync(CompetitorModels, type, this.txtCompetitorFilter.Text);

                RefreshCompetitors(model);
            }
        }

        private async void btnMatchApply_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.cbMatchFilterBy.SelectedItem.ToString()))
            {
                FilterType type = TranslateToFilterType(this.cbMatchFilterBy.SelectedItem.ToString());
                
                var model = await Global.FilterMatchModelAsync(MatchModels, type, this.txtMatchFilter.Text);
                
                RefreshMatches(model);
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            RefreshMatchesAndCompetitors();
        }

        private void RefreshDivisions()
        {
            Divisions = new List<Division>();
            this.tmrDivisions.Enabled = true;

            Task.Run(() => RefreshDivisionsAsync());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Set TreeListView delegates
            tlvMatches.CanExpandGetter = delegate (object x) { return true; };
            tlvMatches.ChildrenGetter = delegate (object x) { return ((Models.MatchModel)x).Children; };

            SetFilterDropdowns();
            DisableAllTabs();
            RefreshDivisions();

            try
            {
                SetEventSearchDateRange();
                //Unnecessary because the SetEventSearchDateRange() triggers this via the date time picker change events.
                //RefreshEventSelect();
            }
            catch
            {
                MessageBox.Show("Failed to connect to remote EventHammer database.", "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnRetryConnection.Visible = true;
            }
        }

        private void rbApplicableMatches_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbApplicableMatches.Checked)
            {
                FilterApplicableMatches();
            }
        }

        private void FilterApplicableMatches()
        {
            if (tlvCompetitors.SelectedObject != null)
            {
                CompetitorModel competitor = (CompetitorModel)tlvCompetitors.SelectedObject;
                RefreshMatches(Global.FilterMatchModelAsync_ApplicableMatches(MatchModels, competitor, Divisions));
            }
        }

        private void refreshEventSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshEventSelect();
        }

        private void btnRetryConnection_Click(object sender, EventArgs e)
        {
            RetryConnection();
        }

        private void RetryConnection()
        {
            try
            {
                RefreshEventSelect();
                this.btnRetryConnection.Visible = false;
            }
            catch
            {
                MessageBox.Show("Failed to connect to remote EventHammer database.", "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKata_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId" };
            string[] Params = { CurrentEvent.EventId.ToString() };

            LaunchWebsite("http://dkktest1.eastus.cloudapp.azure.com/ReportServer?%2fDKK_Reports%2fKataScoreCard_Master", ParamNames, Params);
        }

        private void btnWeaponKata_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId" };
            string[] Params = { CurrentEvent.EventId.ToString() };

            LaunchWebsite("http://dkktest1.eastus.cloudapp.azure.com/ReportServer?%2fDKK_Reports%2fWeaponKataScoreCard_Master", ParamNames, Params);
        }

        private void btnSemiKnockdown_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId" };
            string[] Params = { CurrentEvent.EventId.ToString() };

            LaunchWebsite("http://dkktest1.eastus.cloudapp.azure.com/ReportServer?%2fDKK_Reports%2fSemiKnockdownScoreCard_Master", ParamNames, Params);
        }

        private void btnKnockdown_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId" };
            string[] Params = { CurrentEvent.EventId.ToString() };

            LaunchWebsite("http://dkktest1.eastus.cloudapp.azure.com/ReportServer?%2fDKK_Reports%2fKnockdownScoreCard_Master", ParamNames, Params);
        }

        private void newEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEventManager frm = new frmEventManager();
            frm.Show();
        }

        private void pbCompany_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.danburykarate.com");
        }

        private void pbCompany_MouseEnter(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbCompany_MouseHover(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbCompany_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void pbPoweredBy_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com");
        }
        
        private void pbPoweredBy_MouseEnter(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pbPoweredBy_MouseHover(object sender, System.EventArgs e)
        {           
            this.Cursor = Cursors.Hand;
        }

        private void pbPoweredBy_MouseLeave(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void cbEventSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentEvent = AllEvents[this.cbEventSelect.SelectedIndex];
            EnableAllTabs();
            RefreshFormTitle();
            DisplayEventInformation();
        }

        private void dtpEventFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllEvents();
            RefreshEventSelect();
        }

        private void dtpEventTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshAllEvents();
            RefreshEventSelect();
        }

        private string BuildParameterString(string[] ParamNames, string[] Params)
        {
            string str = "";

            for(int i = 0; i <= ParamNames.GetUpperBound(0); i++)
            {
                str = str + "&" + ParamNames[i] + "=" + Params[i];
            }

            return str;
        }

        private void LaunchWebsite (string URL, string[] ParamNames, string[] Params)
        {
            URL = URL + BuildParameterString(ParamNames, Params);
            System.Diagnostics.Process.Start(URL);
        }

        private void LaunchWebsite(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void RefreshAllEvents()
        {
            AllEvents = DataAccess.GetEventInformationByDateRange(dtpEventFrom.Value,dtpEventTo.Value);
        }

        private Event SetCurrentEvent(List<Event> events)
        {
            return events.FirstOrDefault();
        }

        private void RefreshFormTitle()
        {
            this.Text = "Event Hammer - " + CurrentEvent.EventName + " - " + CurrentEvent.Date.ToString("MM/dd/yyyy");
        }

        private void RefreshEventSelect()
        {
            RefreshAllEvents();

            this.cbEventSelect.Items.Clear();
            foreach(Event Event in AllEvents)
            {
                this.cbEventSelect.Items.Add(Event.EventName + " - " + Event.Date.ToString("MM/dd/yyyy"));
            }
        }

        private void SetEventSearchDateRange()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime maxDate = new DateTime(DateTime.Now.Year + 1, 12, 31);

            this.dtpEventFrom.Value = minDate;
            this.dtpEventTo.Value = maxDate;
        }

        private void DisplayEventInformation()
        {
            this.txtEventInfo.Text = "Event Id:\t\t" + CurrentEvent.EventId.ToString();
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Name:\t" + CurrentEvent.EventName;
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Type:\t" + CurrentEvent.EventType.EventTypeName;
            this.txtEventInfo.Text = this.txtEventInfo.Text + System.Environment.NewLine + "Event Date:\t" + CurrentEvent.Date.ToString("MM/dd/yyyy");
        }

        private void EnableAllTabs()
        {
            foreach (TabPage pg in this.tab1.TabPages)
            {
                if (pg.Enabled == false)
                {
                    pg.Enabled = true;
                }
            }
        }

        private void DisableAllTabs()
        {
            foreach(TabPage pg in this.tab1.TabPages)
            {
                pg.Enabled = (pg.Name.CompareTo("tabHome") == 0);
            }
        }

        private void ToggleTabStatuses()
        {
            if(this.cbEventSelect.SelectedIndex != -1)
            {
                EnableAllTabs();
                return;
            }

            DisableAllTabs();
        }

        private void RefreshMatches(List<MatchModel> model)
        {
            tlvMatches.Roots = model;
            tlvMatches.CollapseAll();
        }

        private void RefreshCompetitors(List<CompetitorModel> model)
        {
            tlvCompetitors.Roots = model;
            tlvCompetitors.CollapseAll();
        }

        private async void RefreshMatchesAndCompetitors()
        {
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = Global.GetMatchModel(mcs);
            CompetitorModels = Global.GetCompetitorModel(mcs);
        }

        private async void RefreshMatches()
        {
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = Global.GetMatchModel(mcs);
        }

        private async void RefreshCompetitors()
        {
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            CompetitorModels = Global.GetCompetitorModel(mcs);
        }

        private void SetFilterDropdowns()
        {
            SetCompetitorFilterDropdowns();
            SetMatchFilterDropdowns();
        }

        private void SetCompetitorFilterDropdowns()
        {
            this.cbCompetitorFilterBy.Items.Clear();

            for (int i = 0; i < tlvCompetitors.Columns.Count; i++)
            {
                string label = tlvCompetitors.Columns[i].Text;
                switch(tlvCompetitors.Columns[i].Text)
                {
                    case "Weight (lb)":
                        label = "Weight (+/- 5 lbs)";
                        break;
                    case "Age":
                        label = "Age (+/- 2 yrs)";
                        break;
                }
                this.cbCompetitorFilterBy.Items.Add(label);
            }
        }

        private void SetMatchFilterDropdowns()
        {
            this.cbMatchFilterBy.Items.Clear();

            for (int i = 0; i < tlvMatches.Columns.Count; i++)
            {
                string label = tlvMatches.Columns[i].Text;
                switch (tlvMatches.Columns[i].Text)
                {
                    case "Weight (lb)":
                        label = "Weight (+/- 5 lbs)";
                        break;
                    case "Age":
                        label = "Age (+/- 2 yrs)";
                        break;
                }
                this.cbMatchFilterBy.Items.Add(label);
            }
        }

        private void retryConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetryConnection();
        }

        private void clearFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshMatchesAndCompetitors();
        }

        private void refreshMatchAndCompetitorListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshMatchCompetitorViews();
        }

        private void tmrMatchCompetitorRefresh_Tick(object sender, EventArgs e)
        {
            //this method was implemented because I was unable to refresh the treelistviews after
            //the async calls to refresh the match and competitor models was complete

            //TODO: Figure out what happens when there is a new event with no matches and no competitors.
            if (MatchModels.Count > 0 && CompetitorModels.Count > 0)
            {
                this.lblLoading.Visible = false;
                this.tmrMatchCompetitorRefresh.Enabled = false;

                RefreshMatchesAndCompetitors();
            }
        }

        private void tlvCompetitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbApplicableMatches.Checked)
            {
                FilterApplicableMatches();
            }
        }

        private void tmrDivisions_Tick(object sender, EventArgs e)
        {
            if (Divisions.Count > 0)
            {
                this.rbAll.Enabled = true;
                this.rbApplicableMatches.Enabled = true;
                this.tmrDivisions.Enabled = false;
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAll.Checked)
            {
                RefreshMatches(MatchModels);
            }
        }

        private void tlvCompetitors_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Copy the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void tlvMatches_ModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            if (e.TargetModel == null)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                if (e.SourceModels.Count == 1)
                {
                    CompetitorModel comp = new CompetitorModel();
                    foreach (CompetitorModel c in e.SourceModels)
                    {
                        comp = c;
                        break;
                    }

                    MatchModel match = e.TargetModel as MatchModel;
                    
                    if (match.Children.Any(m => m.CompetitorId == comp.CompetitorId))
                    {
                        e.Effect = DragDropEffects.None;
                        e.InfoMessage = "Cannot add this competitor because he/she is already in the match.";
                    }
                    else
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void tlvMatches_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            if (e.TargetModel == null)
                return;

            CompetitorModel comp = new CompetitorModel();
            foreach (CompetitorModel c in e.SourceModels)
            {
                comp = c;
                break;
            }

            MatchModels = Global.AddCompetitorToMatch(comp, (MatchModel)e.TargetModel, MatchModels);
            RefreshMatches(MatchModels);

            e.RefreshObjects();
        }

        private void tlvMatches_CanDrop(object sender, BrightIdeasSoftware.OlvDropEventArgs e)
        {
            //string s = "used as break point to test event";
        }
    }
}
