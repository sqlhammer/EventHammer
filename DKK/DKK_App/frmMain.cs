using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DKK_App.Entities;
using DKK_App.Models;
using DKK_App.Enums;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;

namespace DKK_App
{
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();
        public List<Event> FilteredEvents = new List<Event>();
        public List<Models.MatchModel> MatchModels = new List<MatchModel>();
        public List<Models.CompetitorModel> CompetitorModels = new List<CompetitorModel>();
        public List<Division> Divisions = new List<Division>();
        private List<Rank> Ranks = new List<Rank>();
        private List<Dojo> Dojos = new List<Dojo>();
        private List<Title> Titles = new List<Title>();
        public List<Models.EventModel> EventModels = new List<EventModel>();
        private Color Green_SQLHammer = Color.FromArgb(40, 190, 155);

        private bool MatchModelLoadComplete = false;
        private bool CompetitorModelLoadComplete = false;

        #region Form / Multi-tab

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Setup TreeListViews
            tlvMatches.CanExpandGetter = delegate (object x) { return true; };
            tlvMatches.ChildrenGetter = delegate (object x) { return ((Models.MatchModel)x).Children; };
            tlvMatches.ContextMenuStrip = this.cmsMatches;
            tlvComp.ContextMenuStrip = this.cmsCompetitor;

            InitializeFormWithDataAccess();

            //Populate controls
            SetFilterDropdowns();
            SetEventDateTimePicker();
            DisableNonEventTabs();
        }

        private void InitializeFormWithDataAccess()
        {
            try
            {
                SetEventSearchDateRange();
                RefreshEventSelect();
                SetEventTypeDropdown();
                RefreshEvents();
                RefreshDivisions();
                RefreshRanks();
                RefreshDojos();
                RefreshTitles();

                this.lblConnection.Visible = false;
                this.btnRetryConnection.Visible = false;
            }
            catch
            {
                this.lblConnection.Visible = false;
                MessageBox.Show("Failed to connect to remote EventHammer database.", "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnRetryConnection.Visible = true;
            }
        }

        private void btnClearMatchFilter_Click(object sender, EventArgs e)
        {
            RefreshMatches(MatchModels);
        }

        private async Task ApplyCompetitorFilter(ComboBox cb, TextBox txtbox)
        {
            if (cb.SelectedIndex == -1)
                return;

            FilterType type = TranslateToFilterType(cb.SelectedItem.ToString());
            
            if (type == FilterType.Minor || type == FilterType.IsSpecialConsideration)
            {
                await ApplyCompetitorFilter(type);
            }
            else if (!String.IsNullOrEmpty(txtbox.Text))
            {
                await ApplyCompetitorFilter(type, txtbox.Text);
            }
        }

        private async Task ApplyCompetitorFilter(FilterType type, string pattern)
        {
            if (String.IsNullOrEmpty(pattern))
                return;
            
            var model = await Global.FilterCompetitorModelAsync(CompetitorModels, type, pattern);

            RefreshCompetitors(model);
        }

        private async Task ApplyCompetitorFilter(FilterType type)
        {
            var model = await Global.FilterCompetitorModelAsync(CompetitorModels, type);

            RefreshCompetitors(model);
        }

        public void RefreshMatchCompetitorViews()
        {
            MatchModels = new List<MatchModel>();
            CompetitorModels = new List<CompetitorModel>();

            this.lblLoading.Visible = true;
            this.lblCompLoading.Visible = true;
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.tmrMatchCompetitorRefresh.Enabled = true;
            this.tmrNewMatch.Enabled = true;

            Task.Run(() => { RefreshMatchesAndCompetitors(); });
        }

        private void HideTabPageButtons()
        {
            this.btnRetryConnection.Visible = false;
            this.btnClearCompetitorFilter.Visible = false;
            this.btnRefreshMatchTab.Visible = false;
            this.btnClearMatchFilter.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideTabPageButtons();

            //Load only on the first click.
            //Manual refreshes after that.
            if (
                    (
                        this.tabMatch.Enabled &&
                        this.tabCompetitor.Enabled
                    )
                    &&
                    (
                        this.tab1.SelectedTab == this.tabMatch ||
                        this.tab1.SelectedTab == this.tabCompetitor
                    )
                    &&
                    (
                        MatchModelLoadComplete == false
                        && CompetitorModelLoadComplete == false
                    )
               )
            {
                RefreshMatchCompetitorViews();
            }

            //Toggle Competitor button visibility
            if (this.tabCompetitor.Enabled &&
                this.tab1.SelectedTab == this.tabCompetitor &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshMatchTab.Visible = true;
                this.btnClearCompetitorFilter.Visible = true;
                this.msCompetitor.Enabled = true;
            }
            else
            {
                this.msCompetitor.Enabled = false;
            }

            //Toggle Match button visibility
            if (this.tabMatch.Enabled &&
                this.tab1.SelectedTab == this.tabMatch &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshMatchTab.Visible = true;
                this.btnClearMatchFilter.Visible = true;
                this.btnClearCompetitorFilter.Visible = true;
                this.msMatches.Enabled = true;
            }
            else
            {
                this.msMatches.Enabled = false;
            }

            //Toggle Event button visibility and Event menu options
            if (this.tab1.SelectedTab == this.tabEvents &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshMatchTab.Visible = false;
                this.btnClearMatchFilter.Visible = false;
                this.btnClearCompetitorFilter.Visible = false;

                this.eventToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.eventToolStripMenuItem.Enabled = false;
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com/go/ehhelp");
        }

        #endregion

        #region Home Tab

        private void btnEventLoadReg_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.TriggerRegistrationLoad();

                MessageBox.Show(@"This operation could take up to 5 minutes. 

Please refresh the list data from the Competitors tab to verify completion.", "Registration load has been triggered", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        private void btnRetryConnection_Click(object sender, EventArgs e)
        {
            RetryConnection();
        }

        private void RetryConnection()
        {
            this.lblConnection.Visible = true;
            this.Refresh();
            InitializeFormWithDataAccess();
            this.lblConnection.Visible = false;
            this.Refresh();
        }

        private void btnAllEvents_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_WeighIns", report_url));
        }

        private void btnRegForm_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_CompetitorRegistrationForm", report_url));
        }

        private void btnSchoolsOwners_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_WeighIns", report_url));
        }

        private void btnWeighInList_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_WeighIns", report_url));
        }

        private void btnDivisionRingNumbers_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_DivisionNumbers", report_url));
        }

        private void btnKata_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Kata", "false" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KataScoreCard", report_url), ParamNames, Params);
        }

        private void btnWeaponKata_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Weapon Kata", "false" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KataScoreCard", report_url), ParamNames, Params);
        }

        private void btnSemiKnockdown_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Semi-Knockdown", "false" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KnockdownScoreCard", report_url), ParamNames, Params);
        }

        private void btnKnockdown_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Knockdown", "false" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KnockdownScoreCard", report_url), ParamNames, Params);
        }

        private void btnKataSpecial_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Kata", "true" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KataScoreCard", report_url), ParamNames, Params);
        }

        private void btnWeaponKataSpecial_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Weapon Kata", "true" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KataScoreCard", report_url), ParamNames, Params);
        }

        private void btnSemiKnockdownSpecial_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Semi-Knockdown", "true" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KnockdownScoreCard", report_url), ParamNames, Params);
        }

        private void btnKnockdownSpecial_Click(object sender, EventArgs e)
        {
            string[] ParamNames = { "EventId", "MatchTypeName", "IsSpecialConsideration" };
            string[] Params = { CurrentEvent.EventId.ToString(), "Knockdown", "true" };

            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_KnockdownScoreCard", report_url), ParamNames, Params);
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
            EnableEventButtons();
            EnableAllTabs();
            RefreshFormTitle();
            DisplayEventInformation();
        }

        private void dtpEventFrom_ValueChanged(object sender, EventArgs e)
        {
            RefreshEventSelect();
        }

        private void dtpEventTo_ValueChanged(object sender, EventArgs e)
        {
            RefreshEventSelect();
        }

        private string BuildParameterString(string[] ParamNames, string[] Params)
        {
            string str = "";

            for (int i = 0; i <= ParamNames.GetUpperBound(0); i++)
            {
                str = str + "&" + ParamNames[i] + "=" + Params[i];
            }

            return str;
        }

        private void LaunchWebsite(string URL, string[] ParamNames, string[] Params)
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
            AllEvents = DataAccess.GetEventInformation();
        }

        private void RefreshFilteredEvents(DateTime from, DateTime to)
        {
            FilteredEvents = DataAccess.GetEventInformationByDateRange(from, to);            
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
            RefreshFilteredEvents(this.dtpEventFrom.Value,this.dtpEventTo.Value);

            this.cbEventSelect.Items.Clear();
            foreach (Event Event in FilteredEvents)
            {
                this.cbEventSelect.Items.Add(Event.EventName + " - " + Event.Date.ToString("MM/dd/yyyy"));
            }

            EventModels = Global.GetEventModel(AllEvents);
            this.tlvEvents.Roots = EventModels;
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

        private void EnableAllMenus()
        {
            this.msMatches.Enabled = true;
            this.msCompetitor.Enabled = true;
            this.eventToolStripMenuItem.Enabled = true;
        }

        private void EnableEventButtons()
        {
            EnableAllReports();
            this.btnEventLoadReg.Enabled = true;
        }

        private void EnableAllReports()
        {
            this.btnKata.Enabled = true;
            this.btnKataSpecial.Enabled = true;
            this.btnWeaponKata.Enabled = true;
            this.btnWeaponKataSpecial.Enabled = true;
            this.btnSemiKnockdown.Enabled = true;
            this.btnSemiKnockdownSpecial.Enabled = true;
            this.btnKnockdown.Enabled = true;
            this.btnKnockdownSpecial.Enabled = true;
            this.btnWeighInList.Enabled = true;
            this.btnDivisionRingNumbers.Enabled = true;
            this.btnAllEvents.Enabled = true;
            this.btnSchoolsOwners.Enabled = true;

            //I wanted to use SQL Hammer colors but did not get around to it.
            /*
            this.btnKata.BackColor = Green_SQLHammer;
            this.btnKataSpecial.BackColor = Green_SQLHammer;
            this.btnWeaponKata.BackColor = Green_SQLHammer;
            this.btnWeaponKataSpecial.BackColor = Green_SQLHammer;
            this.btnSemiKnockdown.BackColor = Green_SQLHammer;
            this.btnSemiKnockdownSpecial.BackColor = Green_SQLHammer;
            this.btnKnockdown.BackColor = Green_SQLHammer;
            this.btnKnockdownSpecial.BackColor = Green_SQLHammer;
            this.btnWeighInList.BackColor = Green_SQLHammer;
            this.btnDivisionRingNumbers.BackColor = Green_SQLHammer;
            this.btnAllEvents.BackColor = Green_SQLHammer;
            this.btnSchoolsOwners.BackColor = Green_SQLHammer;
            */
        }

        private void DisableAllReports()
        {
            this.btnKata.Enabled = false;
            this.btnKataSpecial.Enabled = false;
            this.btnWeaponKata.Enabled = false;
            this.btnWeaponKataSpecial.Enabled = false;
            this.btnSemiKnockdown.Enabled = false;
            this.btnSemiKnockdownSpecial.Enabled = false;
            this.btnKnockdown.Enabled = false;
            this.btnKnockdownSpecial.Enabled = false;
            this.btnWeighInList.Enabled = false;
            this.btnDivisionRingNumbers.Enabled = false;
            this.btnAllEvents.Enabled = false;
            this.btnSchoolsOwners.Enabled = false;

            //I wanted to use SQL Hammer colors but did not get around to it.
            /*
            this.btnKata.BackColor = Color.Transparent;
            this.btnKataSpecial.BackColor = Color.Transparent;
            this.btnWeaponKata.BackColor = Color.Transparent;
            this.btnWeaponKataSpecial.BackColor = Color.Transparent;
            this.btnSemiKnockdown.BackColor = Color.Transparent;
            this.btnSemiKnockdownSpecial.BackColor = Color.Transparent;
            this.btnKnockdown.BackColor = Color.Transparent;
            this.btnKnockdownSpecial.BackColor = Color.Transparent;
            this.btnWeighInList.BackColor = Color.Transparent;
            this.btnDivisionRingNumbers.BackColor = Color.Transparent;
            this.btnAllEvents.BackColor = Color.Transparent;
            this.btnSchoolsOwners.BackColor = Color.Transparent;
            */
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

        private void DisableNonEventTabs()
        {
            foreach (TabPage pg in this.tab1.TabPages)
            {
                if (pg.Name.CompareTo("tabHome") != 0 &&
                    pg.Name.CompareTo("tabEvents") != 0)
                {
                    pg.Enabled = false;
                }
            }
        }

        private void ToggleTabStatuses()
        {
            if (this.cbEventSelect.SelectedIndex != -1)
            {
                EnableAllTabs();
                return;
            }

            DisableNonEventTabs();
        }

        #endregion

        #region Match Tab
        private void cmiViewMatchDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (tlvMatches.SelectedObject == null)
                    return;
                
                MatchModel mt = (MatchModel)tlvMatches.SelectedObject;

                if (mt.MatchId == null)
                    return;

                Match m = DataAccess.GetMatch((int)mt.MatchId);

                string msgTitle = "Match Details";
                string msg = String.Format(@"Division: {0}
Sub-Division: {1}
Match Type: {2}
Gender: {3}
Minimum Weight: {4}
Maximum Weight: {5}
Minimum Age: {6}
Maximum Age: {7}
Minimum Kyu: {8}
Maximum Kyu: {9}
Minimum Belt: {10}
Maximum Belt: {11}
",
m.MatchDisplayId.ToString(),
m.SubDivisionId.ToString(),
m.MatchType.MatchTypeName,
m.Division.Gender,
m.Division.MinWeight_lb.ToString(),
m.Division.MaxWeight_lb.ToString(),
m.Division.MinAge.ToString(),
m.Division.MaxAge.ToString(),
m.Division.MinRank.Kyu,
m.Division.MaxRank.Kyu,
m.Division.MinRank.RankName,
m.Division.MaxRank.RankName);

                MessageBox.Show(msg, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<MatchModel> SortMatchModels(List<MatchModel> models)
        {
            //We need to resort for display purposes
            models.Sort(delegate (MatchModel x, MatchModel y)
            {
                //Handle NULLs even though I do not expect them
                if (x.MatchDisplayId == null && y.MatchDisplayId == null) return 0;
                if (x.MatchDisplayId == null) return -1;
                if (y.MatchDisplayId == null) return 1;

                //Sort by division
                if (x.MatchDisplayId < y.MatchDisplayId) return -1;
                if (x.MatchDisplayId > y.MatchDisplayId) return 1;

                //Sort by sub-division if divisions match
                if (x.MatchDisplayId == y.MatchDisplayId)
                {
                    if (x.SubDivisionId == y.SubDivisionId) return 0;
                    if (x.SubDivisionId < y.SubDivisionId) return -1;
                    if (x.SubDivisionId > y.SubDivisionId) return 1;
                }

                //It should never get here but I needed to guarantee all code paths return a value.
                return 0;
            });

            return models;
        }

        public void RemoveCompetitorFromMatchView(int? MatchId, int? CompetitorId)
        {
            if (MatchId == null || CompetitorId == null)
                return;

            List<MatchModel> models = MatchModels;
            MatchModel match = models.Where(m => m.MatchId == MatchId).FirstOrDefault();
            MatchModel newMatch = match;

            if (match == null)
                return;

            MatchModel competitor = match.Children.Where(m => m.CompetitorId == CompetitorId).FirstOrDefault();

            if (competitor == null)
                return;

            newMatch.Children.Remove(competitor);

            models.Remove(match);
            models.Add(newMatch);

            MatchModels = SortMatchModels(models);
            RefreshMatches(MatchModels);
        }

        private void removeCompetitorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRemoveMatchCompetitorForm();
        }
        
        private void LoadRemoveMatchCompetitorForm()
        {
            if (tlvMatches.SelectedObject == null)
                return;

            frmRemoveMatchCompetitor frm = new frmRemoveMatchCompetitor();
            MatchModel m = (MatchModel)tlvMatches.SelectedObject;
            frm.Match = m;
            frm.frmMain = this;

            frm.Show();
        }

        private void matchSelectionAssistantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = @"Would you like the application to automatically place all competitors into matches which might suit them?

If you do not like the placements, you will have to move the competitors to different matches or remove them from unsatisfactory matches, manually.";
            DialogResult r = MessageBox.Show(msg,"Match Selection Assistant",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(r == DialogResult.Yes)
            {
                try
                {
                    DataAccess.AutoSetMatches(CurrentEvent);
                    RefreshMatchCompetitorViews();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshMatchTab_Click(object sender, EventArgs e)
        {
            RefreshMatchCompetitorViews();
        }

        private async void RefreshDivisionsAsync()
        {
            Divisions = await DataAccessAsync.GetDivisions();
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
                case "Height (+/- 5 ins)":
                    type = FilterType.Height;
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
                case "Matches w/ <= 1 competitor":
                    type = FilterType.MatchesWithTooFewCompetitors;
                    break;
                case "Minor (Age < 18)":
                    type = FilterType.Minor;
                    break;
                case "Is Special Consideration":
                    type = FilterType.IsSpecialConsideration;
                    break;
            }

            return type;
        }

        private void btnCompetitorApply_Click(object sender, EventArgs e)
        {
            ApplyCompetitorFilter();
        }

        private async void ApplyCompetitorFilter()
        {
            await ApplyCompetitorFilter(this.cbCompetitorFilterBy, this.txtCompetitorFilter);
        }

        private void btnMatchApply_Click(object sender, EventArgs e)
        {
            ApplyMatchFilter();
        }

        private async void ApplyMatchFilter()
        {
            if (this.cbMatchFilterBy.SelectedItem == null)
                return;

            FilterType type = TranslateToFilterType(this.cbMatchFilterBy.SelectedItem.ToString());
            
            if ((this.cbMatchFilterBy.SelectedIndex != -1 && 
                !String.IsNullOrEmpty(this.txtMatchFilter.Text)) ||
                type == FilterType.MatchesWithTooFewCompetitors)
            {
                var model = await Global.FilterMatchModelAsync(MatchModels, type, this.txtMatchFilter.Text);

                RefreshMatches(model);
            }
        }

        private void RefreshDivisions()
        {
            Divisions = new List<Division>();
            this.tmrDivisions.Enabled = true;
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.tmrNewMatch.Enabled = true;

            Task.Run(() => RefreshDivisionsAsync());
        }

        public void RefreshMatches(List<MatchModel> model)
        {
            MatchModelLoadComplete = false;
            tlvMatches.Roots = model;
            tlvMatches.CollapseAll();
            MatchModelLoadComplete = true;
        }

        private void RefreshCompetitors(List<CompetitorModel> model)
        {
            CompetitorModelLoadComplete = false;
            tlvCompetitors.Roots = model;
            tlvCompetitors.CollapseAll();

            tlvComp.Roots = model;
            tlvComp.CollapseAll();
            CompetitorModelLoadComplete = true;
        }

        private async void RefreshMatchesAndCompetitors()
        {
            MatchModelLoadComplete = false;
            CompetitorModelLoadComplete = false;
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = Global.GetMatchModel(mcs);

            List<Competitor> cs = await DataAccessAsync.GetCompetitors(CurrentEvent);
            CompetitorModels = Global.GetCompetitorModel(cs);
            MatchModelLoadComplete = true;
            CompetitorModelLoadComplete = true;
        }

        private async void RefreshMatches()
        {
            MatchModelLoadComplete = false;
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = Global.GetMatchModel(mcs);
            MatchModelLoadComplete = true;
        }

        private async void RefreshCompetitors()
        {
            CompetitorModelLoadComplete = false;
            List<Competitor> cs = await DataAccessAsync.GetCompetitors(CurrentEvent);
            CompetitorModels = Global.GetCompetitorModel(cs);
            CompetitorModelLoadComplete = true;
        }

        private void SetFilterDropdowns()
        {
            SetCompetitorFilterDropdowns();
            SetMatchFilterDropdowns();
        }

        private void SetCompetitorFilterDropdowns()
        {
            //Handles both Matches and Competitors tabs

            this.cbCompetitorFilterBy.Items.Clear();
            this.cbCompFilterBy.Items.Clear();

            for (int i = 0; i < tlvCompetitors.Columns.Count; i++)
            {
                string label = tlvCompetitors.Columns[i].Text;
                switch (tlvCompetitors.Columns[i].Text)
                {
                    case "Weight (lb)":
                        label = "Weight (+/- 5 lbs)";
                        break;
                    case "Height (in)":
                        label = "Height (+/- 5 ins)";
                        break;
                    case "Age":
                        label = "Age (+/- 2 yrs)";
                        this.cbCompetitorFilterBy.Items.Add("Minor (Age < 18)");
                        this.cbCompFilterBy.Items.Add("Minor (Age < 18)");
                        break;
                }
                this.cbCompetitorFilterBy.Items.Add(label);
                this.cbCompFilterBy.Items.Add(label);
            }

            this.cbCompetitorFilterBy.Items.Add("Is Special Consideration");
            this.cbCompFilterBy.Items.Add("Is Special Consideration");
        }

        private void SetMatchFilterDropdowns()
        {
            this.cbMatchFilterBy.Items.Clear();

            //Add options by column
            for (int i = 0; i < tlvMatches.Columns.Count; i++)
            {
                string label = tlvMatches.Columns[i].Text;
                switch (tlvMatches.Columns[i].Text)
                {
                    case "Weight (lb)":
                        label = "Weight (+/- 5 lbs)";
                        break;
                    case "Height (in)":
                        label = "Height (+/- 5 ins)";
                        break;
                    case "Age":
                        label = "Age (+/- 2 yrs)";
                        this.cbMatchFilterBy.Items.Add("Minor (Age < 18)");
                        break;
                }
                this.cbMatchFilterBy.Items.Add(label);
            }

            //Add non-columnar filters
            this.cbMatchFilterBy.Items.Add("Matches w/ <= 1 competitor");
        }

        private void retryConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RetryConnection();
        }

        private void clearFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshMatches(MatchModels);
            RefreshCompetitors(CompetitorModels);
        }

        private void refreshMatchAndCompetitorListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshMatchCompetitorViews();
        }

        private void tmrMatchCompetitorRefresh_Tick(object sender, EventArgs e)
        {
            //this method was implemented because I was unable to refresh the treelistviews after
            //the async calls to refresh the match and competitor models was complete
            
            if (MatchModelLoadComplete && CompetitorModelLoadComplete)
            {
                this.lblLoading.Visible = false;
                this.lblCompLoading.Visible = false;
                this.tmrMatchCompetitorRefresh.Enabled = false;

                RefreshMatches(MatchModels);
                RefreshCompetitors(CompetitorModels);
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

        private void cmiMatchesExpandAll_Click(object sender, EventArgs e)
        {
            this.tlvMatches.ExpandAll();
        }

        private void cmiMatchesCollapseAll_Click(object sender, EventArgs e)
        {
            this.tlvMatches.CollapseAll();
        }

        private void btnClearCompetitorFilter_Click(object sender, EventArgs e)
        {
            RefreshCompetitors(CompetitorModels);
        }

        private void txtCompetitorFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyCompetitorFilter();
        }

        private void txtMatchFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyMatchFilter();
        }

        private void cmiDeleteMatch_Click(object sender, EventArgs e)
        {
            MatchModel m = this.tlvMatches.SelectedObject as MatchModel;

            if (m == null)
                return;

            string msg = String.Format("Confirm: irrevocably delete match {0}.", m.MatchDisplayName);
            string title = "Confirm delete";
            DialogResult r = MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Cancel)
                return;

            DataAccessAsync.DeleteMatchAsync(m);
            MatchModels.Remove(m);
            RefreshMatches(MatchModels);
        }

        #endregion

        #region New Match

        private void newMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewMatchForm();
        }

        private void createNewMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadNewMatchForm();
        }

        private void LoadNewMatchForm()
        {
            frmNewMatch frm = new frmNewMatch();
            frm.Divisions = Divisions;
            frm.MatchModels = MatchModels;
            frm.ParentFormMain = this;
            frm.Show();
        }

        private void tmrNewMatch_Tick(object sender, EventArgs e)
        {
            if (Divisions.Count > 0 &&
                MatchModels.Count > 0)
            {
                this.createNewMatchToolStripMenuItem.Enabled = true;
                this.tmrDivisions.Enabled = false;
            }
        }

        #endregion

        #region Competitor Tab
        
        private void RefreshRanks()
        {
            this.tmrCompTab.Enabled = true;
            Task.Run(() => { RefreshRanksAsync(); });
        }

        private void RefreshDojos()
        {
            Task.Run(() => { RefreshDojosAsync(); });
        }

        private void RefreshTitles()
        {
            Task.Run(() => { RefreshTitlesAsync(); });
        }

        private async void RefreshRanksAsync()
        {
            Ranks = await DataAccessAsync.GetRanks();
        }

        private async void RefreshTitlesAsync()
        {
            Titles = await DataAccessAsync.GetTitles();
        }

        private async void RefreshDojosAsync()
        {
            Dojos = await DataAccessAsync.GetDojos();
        }

        private void LoadCompetitorBelt(Rank rank)
        {
            if (rank == null)
                return;

            this.cbCompBelt.SelectedIndex = this.cbCompBelt.FindStringExact(rank.RankName);
        }

        private void LoadCompetitorSchool(Dojo dojo)
        {
            if (dojo == null)
                return;

            this.cbCompSchool.SelectedIndex = this.cbCompSchool.FindStringExact(dojo.Facility.FacilityName);

            if (dojo.Facility.Owner == null)
            {
                this.txtCompInstructor.Text = "";
                return;
            }

            this.txtCompInstructor.Text = dojo.Facility.Owner.DisplayName;
        }

        private void LoadCompetitorTitle(Title title)
        {
            if (title == null)
                return;

            this.cbCompTitle.SelectedIndex = this.cbCompTitle.FindStringExact(title.TitleName);
        }

        private void LoadCompetitorGender(string gender)
        {
            if (String.IsNullOrEmpty(gender))
            {
                this.rbCompFemale.Checked = false;
                this.rbCompMale.Checked = false;
                return;
            }

            if (gender.ToLower().CompareTo("f") == 0)
            {
                this.rbCompFemale.Checked = true;
                this.rbCompMale.Checked = false;
            }
            else
            {
                this.rbCompFemale.Checked = false;
                this.rbCompMale.Checked = true;
            }
        }

        private void LoadCompetitorDetails(CompetitorModel compModel)
        {
            Competitor comp = new Competitor
            {
                Dojo = new Dojo
                {
                    Facility = new Facility()
                },
                Event = new Event(),
                Parent = new Person(),
                Person = new Person(),
                Rank = new Rank()
            };

            if (compModel.CompetitorId != 0)
            {
                comp = DataAccess.GetCompetitor(compModel.CompetitorId);
            }

            this.txtCompFirstName.Text = comp.Person.FirstName;
            this.txtCompLastName.Text = comp.Person.LastName;
            this.txtCompApptCode.Text = comp.Person.AppartmentCode;
            this.txtCompCity.Text = comp.Person.City;
            this.txtCompCountry.Text = comp.Person.Country;
            this.txtCompEmail.Text = comp.Person.EmailAddress;
            if (comp.Parent != null)
            {
                this.txtCompParentEmail.Text = comp.Parent.EmailAddress;
                this.txtCompParentFirstName.Text = comp.Parent.FirstName;
                this.txtCompParentLastName.Text = comp.Parent.LastName;
            }
            this.txtCompPhone.Text = comp.Person.PhoneNumber;
            this.txtCompState.Text = comp.Person.StateProvince;
            this.txtCompStreet1.Text = comp.Person.StreetAddress1;
            this.txtCompStreet2.Text = comp.Person.StreetAddress2;
            this.txtCompZipCode.Text = comp.Person.PostalCode;

            this.chbCompIsInstructor.Checked = comp.Person.IsInstructor;
            this.chbCompSpecialConsideration.Checked = comp.IsSpecialConsideration;

            this.nudCompWeight.Value = comp.Weight;
            this.nudCompHeight.Value = comp.Height;

            this.nudCompAge.Value = comp.Age;

            LoadCompetitorBelt(comp.Rank);
            LoadCompetitorSchool(comp.Dojo);
            LoadCompetitorTitle(comp.Person.Title);
            LoadCompetitorGender(comp.Person.Gender);
        }

        private void tlvComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp != null)
            {
                LoadCompetitorDetails(comp);
            }
            else
            {
                LoadCompetitorDetails(new CompetitorModel());
            }
        }

        private void chbCompIsInstructor_CheckedChanged(object sender, EventArgs e)
        {
            this.cbCompTitle.Enabled = this.chbCompIsInstructor.Checked;
        }

        private void SetCompetitorBeltDropdown()
        {
            if (Ranks.Count == 0)
                return;

            this.cbCompBelt.Items.Clear();
            foreach (var rank in Ranks)
            {
                this.cbCompBelt.Items.Add(rank.RankName);
            }
        }

        private void SetCompetitorDojoDropdown()
        {
            if (Dojos.Count == 0)
                return;

            this.cbCompSchool.Items.Clear();
            foreach (var dojo in Dojos)
            {
                this.cbCompSchool.Items.Add(dojo.Facility.FacilityName);
            }

            this.cbCompSchool.Items.Add("Other");
        }

        private void SetCompetitorTitleDropdown()
        {
            if (Titles.Count == 0)
                return;

            this.cbCompTitle.Items.Clear();
            foreach (var title in Titles)
            {
                this.cbCompTitle.Items.Add(title.TitleName);
            }
        }

        private void tmrCompTab_Tick(object sender, EventArgs e)
        {
            bool TurnMeOff = true;

            if (Ranks.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (this.cbCompBelt.Items.Count == 0)
            {
                SetCompetitorBeltDropdown();
            }

            if (Dojos.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (this.cbCompSchool.Items.Count == 0)
            {
                SetCompetitorDojoDropdown();
            }

            if (Titles.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (this.cbCompTitle.Items.Count == 0)
            {
                SetCompetitorTitleDropdown();
            }

            if (TurnMeOff)
                this.tmrCompTab.Enabled = false;
        }

        private void cbCompSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCompSchool.SelectedItem != null &&
                this.cbCompSchool.SelectedItem.ToString().CompareTo("Other") == 0)
            {
                this.txtCompSchoolOther.Enabled = true;
            }
            else
            {
                this.txtCompSchoolOther.Text = "";
                this.txtCompSchoolOther.Enabled = false;
            }
        }

        private void btnCompClear_Click(object sender, EventArgs e)
        {
            ClearCompetitorSelection();
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCompetitorSelection();
        }

        private void clearSelectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearCompetitorSelection();
        }

        private void ClearCompetitorSelection()
        {
            this.tlvComp.SelectedObject = null;
            LoadCompetitorDetails(new CompetitorModel());
        }

        private void deleteSelectedCompetitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCompetitor(this.tlvComp.SelectedObject as CompetitorModel);
        }

        private void btnCompDelete_Click(object sender, EventArgs e)
        {
            DeleteCompetitor(this.tlvComp.SelectedObject as CompetitorModel);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCompetitor(this.tlvComp.SelectedObject as CompetitorModel);
        }

        private void DeleteCompetitor(CompetitorModel comp)
        {
            if (comp == null || comp.CompetitorId == 0)
                return;

            string msg = String.Format("Confirm: irrevocably delete competitor: {0}.", comp.DisplayName);
            string title = "Confirm delete";
            DialogResult r = MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Cancel)
                return;

            DataAccess.DeleteCompetitor(comp);

            CompetitorModels.Remove(comp);
            RefreshCompetitors(CompetitorModels);
        }

        private void btnSaveComp_Click(object sender, EventArgs e)
        {
            SaveCompetitor(false);
        }

        private void chbCompSpecialConsideration_CheckedChanged(object sender, EventArgs e)
        {
            btnSpecialConsiderationDetails.Enabled = this.chbCompSpecialConsideration.Checked;
        }

        private void btnSpecialConsiderationDetails_Click(object sender, EventArgs e)
        {
            //TODO: update the database call for competitormodel to include desc
            frmCompSpecialConsiderationDetail frm = new frmCompSpecialConsiderationDetail();
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp != null)
            {
                frm.CompetitorModel = ((CompetitorModel)this.tlvComp.SelectedObject);
            }
            else
            {
                frm.CompetitorModel = (new CompetitorModel());
            }
            
            frm.Show();
        }

        private void SaveCompetitor(bool IsNew)
        {
            CompetitorModel cm = this.tlvComp.SelectedObject as CompetitorModel;
            Competitor comp = new Competitor
            {
                Dojo = new Dojo
                {
                    Facility = new Facility
                    {
                        FacilityType = new FacilityType()
                    }
                },
                Event = CurrentEvent,
                Rank = new Rank(),
                Person = new Person
                {
                    Title = new Title()
                },
                Parent = new Person
                {
                    Title = new Title()
                }
            };
            
            if (cm != null && IsNew == false)
            {
                comp = DataAccess.GetCompetitor(cm.CompetitorId);
            }
            else if (cm == null && IsNew == false)
            {
                //No competitor is selected to save.
                return;
            }
            
            comp.Person.FirstName = this.txtCompFirstName.Text;
            comp.Person.EmailAddress = this.txtCompEmail.Text;
            comp.Person.LastName = this.txtCompLastName.Text;
            
            if (IsNew && Global.IsDuplicatePerson(comp.Person))
            {
                MessageBox.Show("The same combination of FirstName, LastName, and EmailAddress already exists.", "Duplicate person", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            comp.Weight = this.nudCompWeight.Value;
            comp.Person.DisplayName = this.txtCompLastName.Text + ", " + this.txtCompFirstName.Text;
            comp.Height = this.nudCompHeight.Value;
            comp.Person.Gender = (this.rbCompFemale.Checked) ? "F" : "M";
            //comp.DateOfBirth = new DateTime(Convert.ToInt32(this.cbCompYear.SelectedItem.ToString()), Convert.ToInt32(this.cbCompMonth.SelectedItem.ToString()),1);
            comp.Age = (int)this.nudCompAge.Value;
            comp.Person.IsInstructor = this.chbCompIsInstructor.Checked;
            comp.IsSpecialConsideration = this.chbCompSpecialConsideration.Checked;
            comp.Parent.FirstName = this.txtCompParentFirstName.Text;
            comp.Parent.LastName = this.txtCompParentLastName.Text;
            comp.Parent.EmailAddress = this.txtCompParentEmail.Text;
            comp.Person.PhoneNumber = this.txtCompPhone.Text;
            comp.Person.Country = this.txtCompCountry.Text;
            comp.Person.StreetAddress1 = this.txtCompStreet1.Text;
            comp.Person.StreetAddress2 = this.txtCompStreet2.Text;
            comp.Person.AppartmentCode = this.txtCompApptCode.Text;
            comp.Person.City = this.txtCompCity.Text;
            comp.Person.StateProvince = this.txtCompState.Text;
            comp.Person.PostalCode = this.txtCompZipCode.Text;

            comp.Rank = (Ranks.Where(r => r.RankName.CompareTo(this.cbCompBelt.SelectedItem.ToString()) == 0)).First();
            comp.Person.Title = (this.cbCompTitle.SelectedItem == null) ? new Title() : (Titles.Where(t => t.TitleName.CompareTo(this.cbCompTitle.SelectedItem.ToString()) == 0)).First();
            comp.Dojo = (Dojos.Where(d => d.Facility.FacilityName.CompareTo(this.cbCompSchool.SelectedItem.ToString()) == 0)).First();

            SaveCompetitor(comp, IsNew);

            RefreshMatchCompetitorViews();
        }

        private void SaveCompetitor(Competitor comp, bool IsNew)
        {
            if (IsNew)
            {
                DataAccess.InsertCompetitor(comp);
            }
            else
            {
                DataAccess.UpdateCompetitor(comp);
            }

            ClearCompetitorSelection();
        }

        private void editSelectedCompetitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCompetitor(false);
        }

        private void btnNewComp_Click(object sender, EventArgs e)
        {
            SaveCompetitor(true);
        }

        private void newCompetitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCompetitor(true);
        }

        private void btnCompFilterApply_Click(object sender, EventArgs e)
        {
            ApplyCompFilter();
        }

        private void txtCompFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyCompFilter();
        }

        private async void ApplyCompFilter()
        {
            await ApplyCompetitorFilter(this.cbCompFilterBy, this.txtCompFilter);
        }
        #endregion

        #region Event Tab
        private void RefreshEvents()
        {
            AllEvents = DataAccess.GetEventInformation();
            EventModels = Global.GetEventModel(AllEvents);

            ClearEventSelection();
            RefreshEvents(EventModels);
        }

        private void RefreshEvents(List<EventModel> em)
        {
            this.tlvEvents.Roots = em;
            this.tlvEvents.Refresh();
        }

        private void SetEventTypeDropdown()
        {
            List<EventType> ets = DataAccess.GetEventTypes();
            this.cbEventType.Items.Clear();

            foreach (EventType et in ets)
            {
                this.cbEventType.Items.Add(et.EventTypeName);
            }
        }

        private void LoadEventDetails (EventModel e)
        {
            this.txtEventName.Text = e.EventName;
            this.dtpEventDate.Value = (e.Date == DateTime.MinValue) ? DateTime.Today : e.Date;
            this.cbEventType.SelectedIndex = this.cbEventType.FindStringExact(e.EventTypeName);
        }

        private void tlvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventModel Event = this.tlvEvents.SelectedObject as EventModel;

            if (Event != null)
            {
                LoadEventDetails ((EventModel)this.tlvEvents.SelectedObject);
            }
            else
            {
                LoadEventDetails (new EventModel());
            }
        }
        
        private void ClearEventSelection()
        {
            this.tlvEvents.SelectedObject = null;
            LoadEventDetails(new EventModel());
        }

        private void submsClearEventSelection_Click(object sender, EventArgs e)
        {
            ClearEventSelection();
        }

        private void SaveNewEvent()
        {
            EventType type = DataAccess.GetEventTypeByName(this.cbEventType.SelectedItem.ToString()).First();

            Event Event = new Event
            {
                Date = this.dtpEventDate.Value,
                EventName = this.txtEventName.Text,
                EventType = type
            };

            string result = Global.IsValidEvent(Event,true);
            if (result.CompareTo("") != 0)
            {
                MessageBox.Show(result,"Invalid Event",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            DataAccess.InsertEvent(Event);
            
            RefreshEvents();
        }

        private void SaveEvent()
        {
            EventModel e = this.tlvEvents.SelectedObject as EventModel;

            if (e == null)
                return;

            EventType type = DataAccess.GetEventTypeByName(this.cbEventType.SelectedItem.ToString()).First();

            Event Event = new Event
            {
                EventId = e.EventId,
                Date = this.dtpEventDate.Value,
                EventName = this.txtEventName.Text,
                EventType = type
            };

            string result = Global.IsValidEvent(Event,false);
            if (result.CompareTo("") != 0)
            {
                MessageBox.Show(result, "Invalid Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataAccess.UpdateEvent(Event);
        }

        private void btnClearEventSelection_Click(object sender, EventArgs e)
        {
            ClearEventSelection();
        }

        private void SetEventDateTimePicker()
        {
            this.dtpEventDate.Value = DateTime.Today;
        }

        private void submsRefreshEvent_Click(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        private void refreshEventSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshEvents();
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {
            SaveNewEvent();
        }

        private void submsNewEvent_Click(object sender, EventArgs e)
        {
            SaveNewEvent();
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            SaveEvent();
        }

        private void submsSaveEvent_Click(object sender, EventArgs e)
        {
            SaveEvent();
        }

        private void DeleteEvent()
        {
            EventModel e = this.tlvEvents.SelectedObject as EventModel;

            if (e == null)
                return;

            string msg = String.Format("Confirm: irrevocably delete event {0}.", e.EventName);
            string title = "Confirm delete";
            DialogResult r = MessageBox.Show(msg, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Cancel)
                return;

            DataAccess.DeleteEvent(e.EventId);
            EventModels.Remove(e);
            RefreshEvents();
            ClearEventSelection();
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }

        private void submsDeleteEvent_Click(object sender, EventArgs e)
        {
            DeleteEvent();
        }
        #endregion
        
    }
}
