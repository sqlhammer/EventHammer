using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DKK_App.Entities;
using DKK_App.Models;

namespace DKK_App
{
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();

        public frmMain()
        {
            InitializeComponent();
        }

        #region EventTriggers
        private void refreshEventSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshEventSelect();
        }

        private void btnRetryConnection_Click(object sender, EventArgs e)
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
        #endregion EventTriggers

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

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Set TreeListView delegates
            tlvMatches.CanExpandGetter = delegate (object x) { return true; };
            tlvMatches.ChildrenGetter = delegate (object x) { return ((Models.MatchModel)x).Children; };

            DisableAllTabs();
            SetEventSearchDateRange();

            try
            {
                RefreshEventSelect();
            }
            catch
            {
                MessageBox.Show("Failed to connect to remote EventHammer database.", "Connection failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnRetryConnection.Visible = true;
            }
        }        

        private void RefreshMatches()
        {
            List<MatchCompetitor> mcs = DataAccess.GetMatchCompetitors(CurrentEvent);
            
            tlvMatches.Roots = Global.GetMatchModel(mcs);
        }

        private void RefreshCompetitors()
        {
            List<MatchCompetitor> mcs = DataAccess.GetMatchCompetitors(CurrentEvent);

            tlvCompetitors.Roots = Global.GetCompetitorModel(mcs);
        }

        private void rbApplicableMatches_CheckedChanged(object sender, EventArgs e)
        {
            if(this.rbApplicableMatches.Checked)
            {
                this.rbAll.Checked = false;
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAll.Checked)
            {
                this.rbApplicableMatches.Checked = false;
            }
        }

        private void tabMatch_Click(object sender, EventArgs e)
        {
            if (this.tabMatch.Enabled)
            {
                RefreshMatches();
                RefreshCompetitors();
            }
        }
    }
}
