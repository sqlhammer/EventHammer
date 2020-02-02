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
using DKK_App.Objects;
using System.ComponentModel;
using DKK_App.Exceptions;

namespace DKK_App
{
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();
        public List<Event> FilteredEvents = new List<Event>();
        public List<MatchModel> MatchModels = new List<MatchModel>();
        public List<CompetitorModel> CompetitorModels = new List<CompetitorModel>();
        public MatchContext MatchContext = new MatchContext();
        public List<MatchType> MatchTypes = new List<MatchType>();
        public SortableBindingList<Score> Scores = new SortableBindingList<Score>();
        public SortableBindingList<Score> SavedScores = new SortableBindingList<Score>();
        public List<Division> Divisions = new List<Division>();
        private List<Rank> Ranks = new List<Rank>();
        private List<Dojo> Dojos = new List<Dojo>();
        private List<Title> Titles = new List<Title>();
        public List<EventModel> EventModels = new List<EventModel>();
        private Color Green_SQLHammer = Color.FromArgb(40, 190, 155);
        private CompetitorDetailsGridMap map = new CompetitorDetailsGridMap();
        private bool IsSandboxMode = false;

        private bool MatchModelLoadComplete = false;
        private bool CompetitorModelLoadComplete = false;
        private bool ScoresLoadComplete = false;
        private bool ScoresHaveBeenEdited = false;
        private bool _resizing = false;

        #region Form / Multi-tab

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(1155, 620);

            //Setup TreeListViews
            tlvMatches.CanExpandGetter = delegate (object x) { return true; };
            tlvMatches.ChildrenGetter = delegate (object x) { return ((Models.MatchModel)x).Children; };
            tlvMatches.ContextMenuStrip = this.cmsMatches;
            tlvComp.ContextMenuStrip = this.cmsCompetitor;
            tlvCompetitors.ContextMenuStrip = this.cmsMatchComp;

            //Set default connection state
            //Sandbox mode will be OFF
            ToggleSandboxMode(false);

            //First point of database access
            InitializeFormWithDataAccess();

            //Populate controls
            SetFilterDropdowns();
            SetEventDateTimePicker();
            DisableNonEventTabs();

            //AutoResizeForm();
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeFormWithDataAccess()
        {
            try
            {
                //Global.CheckForUpdates(); //Disabled in favor of ClickOnce auto-upgrades
                SetEventSearchDateRange();
                RefreshEventSelect();
                RefreshEvents();
                SetEventTypeDropdown();
                RefreshEvents();
                RefreshDivisions();
                RefreshRanks();
                RefreshDojos();
                RefreshTitles();
                RefreshMatchTypes();
                BuildCompetitorDetailsGridView();

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

        private void cmiSandboxMode_Click(object sender, EventArgs e)
        {
            ToggleSandboxMode(!IsSandboxMode);
        }

        private void ToggleSandboxMode (bool targetSandboxMode)
        {
            string connectionState = "DKK";

            if (!targetSandboxMode)
            {
                connectionState = "DKK";
                cmiSandboxMode.Text = "Sandbox Mode - OFF";
                this.BackColor = Color.White;
            }
            else
            {
                connectionState = "DKK_Dev";
                cmiSandboxMode.Text = "Sandbox Mode - ON";
                this.BackColor = Color.LightCoral;
            }

            UpdateLastConnectionState(connectionState);
            IsSandboxMode = targetSandboxMode;

            ResetEnvironment();
        }

        private void UpdateLastConnectionState(string connectionState)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["LastConnectionState"].Value = connectionState;
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        /*
        private void UpdateConnectionString (string connectionString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["DKK"].ConnectionString = connectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        */

        private void ResetEnvironment()
        {
            //To force the user back to selecting an event which is relevant to this environment
            DisableNonEventTabs();
            tab1.SelectedIndex = 0; //tabHome

            //To provoke an auto-refresh of all models for the new environment
            MatchModelLoadComplete = false;
            CompetitorModelLoadComplete = false;
            ScoresLoadComplete = false;

            //To refresh all standard object lists such as events, dojos, titles, etc.
            RetryConnection();
        }

        private void RefreshMatchTypes()
        {
            Task.Run(() => { RefreshMatchTypesAsync(); });
        }

        private async void RefreshMatchTypesAsync()
        {
            MatchTypes = await DataAccessAsync.GetMatchTypes();
        }

        private void btnClearMatchFilter_Click(object sender, EventArgs e)
        {
            ClearMatchFilter();
        }

        private void ClearMatchFilter()
        {
            RefreshMatches(MatchModels);
            txtMatchFilter.Text = "";
        }

        private void cmiDownloadLatestVersion_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.eventhammeronline.com/go/ehupgradetutorial");
            LaunchWebsite("https://www.eventhammeronline.com/go/ehsetup");
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

        public void RefreshMatchCompetitorScoreViews()
        {
            MatchModels = new List<MatchModel>();
            CompetitorModels = new List<CompetitorModel>();

            this.lblLoading.Visible = true;
            this.lblCompLoading.Visible = true;
            this.lblScoresLoading.Visible = true;
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.tmrMatchCompetitorRefresh.Enabled = true;
            this.tmrNewMatch.Enabled = true;

            RefreshMatchTypes();
            Task.Run(() => { RefreshMatchesAndCompetitorsAndScores(); });

            ClearCompetitorSelection();
        }

        private void HideTabPageButtons()
        {
            this.btnRetryConnection.Visible = false;
            this.btnClearCompetitorFilter.Visible = false;
            this.btnRefreshLists.Visible = false;
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
                        this.tabCompetitor.Enabled &&
                        this.tabScore.Enabled
                    )
                    &&
                    (
                        this.tab1.SelectedTab == this.tabMatch ||
                        this.tab1.SelectedTab == this.tabCompetitor ||
                        this.tab1.SelectedTab == this.tabScore
                    )
                    &&
                    (
                        MatchModelLoadComplete == false
                        && CompetitorModelLoadComplete == false
                        && ScoresLoadComplete == false
                    )
               )
            {
                RefreshMatchCompetitorScoreViews();
            }

            //Toggle Competitor button visibility
            if (this.tabCompetitor.Enabled &&
                this.tab1.SelectedTab == this.tabCompetitor &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshLists.Visible = true;
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
                this.btnRefreshLists.Visible = true;
                this.btnClearMatchFilter.Visible = true;
                this.btnClearCompetitorFilter.Visible = true;
                this.msMatches.Enabled = true;
            }
            else
            {
                this.msMatches.Enabled = false;
            }

            //Toggle Score button visibility
            if (this.tabScore.Enabled &&
                this.tab1.SelectedTab == this.tabScore &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshLists.Visible = true;
                this.btnClearMatchFilter.Visible = false;
                this.btnClearCompetitorFilter.Visible = false;
                //this.msMatches.Enabled = false;
                this.btnSubmitScores.Visible = true;
                this.btnScoresUndoChanges.Visible = true;
            }
            else
            {
                //this.msMatches.Enabled = false;
            }

            //Toggle Event button visibility and Event menu options
            if (this.tab1.SelectedTab == this.tabEvents &&
                this.btnRetryConnection.Visible == false)
            {
                this.btnRefreshLists.Visible = false;
                this.btnClearMatchFilter.Visible = false;
                this.btnClearCompetitorFilter.Visible = false;

                this.eventToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.eventToolStripMenuItem.Enabled = false;
            }

            AutoResizeForm();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.eventhammeronline.com/go/ehhelp");
        }

        private void autoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.InstallUpdateSyncWithInfo();
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

        private void FilterApplicableMatches()
        {
            if (tlvCompetitors.SelectedObject != null)
            {
                CompetitorModel competitor = (CompetitorModel)tlvCompetitors.SelectedObject;
                RefreshMatches(Global.FilterMatchModel_ApplicableMatches(MatchModels, competitor, Divisions));
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
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_AllEvents", report_url));
        }

        private void btnCheckInRoster_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_CheckInRoster", report_url));
        }

        private void btnCompetitorsBySchoolReport_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_CompetitorsByDojo", report_url));
        }

        private void btnRegForm_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_CompetitorRegistrationForm", report_url));
        }

        private void btnSchoolsOwners_Click(object sender, EventArgs e)
        {
            string report_url = ConfigurationManager.AppSettings["ReportURL"].ToString();
            LaunchWebsite(String.Format("{0}ReportServer?%2fDKK_Reports%2fMaster_SchoolList", report_url));
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
            CurrentEvent = FilteredEvents[this.cbEventSelect.SelectedIndex];
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
            RefreshFilteredEvents(this.dtpEventFrom.Value, this.dtpEventTo.Value);

            this.cbEventSelect.Items.Clear();
            foreach (Event Event in FilteredEvents)
            {
                this.cbEventSelect.Items.Add(Event.EventName + " - " + Event.Date.ToString("MM/dd/yyyy"));
            }

            this.cbEventSelect.Text = "";
            this.rtbEventInfo.Text = "";
        }

        private void SetEventSearchDateRange()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year - 5, 1, 1);
            DateTime maxDate = new DateTime(DateTime.Now.Year + 2, 12, 31);

            this.dtpEventFrom.Value = minDate;
            this.dtpEventTo.Value = maxDate;
        }

        private void DisplayEventInformation()
        {
            this.rtbEventInfo.Text = "Event Id:\t\t" + CurrentEvent.EventId.ToString();
            this.rtbEventInfo.Text = this.rtbEventInfo.Text + System.Environment.NewLine + "Event Name:\t" + CurrentEvent.EventName;
            this.rtbEventInfo.Text = this.rtbEventInfo.Text + System.Environment.NewLine + "Event Type:\t" + CurrentEvent.EventType.EventTypeName;
            this.rtbEventInfo.Text = this.rtbEventInfo.Text + System.Environment.NewLine + "Event Date:\t" + CurrentEvent.Date.ToString("MM/dd/yyyy");
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
            this.btnCompetitorsBySchoolReport.Enabled = true;
            this.btnCheckInRoster.Enabled = true;

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
            this.btnCompetitorsBySchoolReport.Enabled = false;
            this.btnCheckInRoster.Enabled = false;

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
        private void cmiMatchCompFilterByName_Click(object sender, EventArgs e)
        {
            CompetitorModel c = new CompetitorModel();

            if (tlvCompetitors.SelectedObject != null)
            {
                c = (CompetitorModel)tlvCompetitors.SelectedObject;
                FilterMatchListByName(c.DisplayName);
            }
        }

        private void FilterMatchListByName(string name)
        {
            cbMatchFilterBy.SelectedIndex = cbMatchFilterBy.Items.IndexOf("Name");
            txtMatchFilter.Text = name;
            ApplyMatchFilter();
        }

        private void cmiChangeDivisionNumber_Click(object sender, EventArgs e)
        {
            ChangeSubDivisionNumber();
        }

        private void cmiChangeSelectedDivisionNumber_Click(object sender, EventArgs e)
        {
            ChangeSubDivisionNumber();
        }

        private void SetMatchContext()
        {
            MatchModel selected = new MatchModel();
            List<MatchModel> expanded = new List<MatchModel>();
            List<MatchModel> collapsed = new List<MatchModel>();

            // Set currently selected match
            if (tlvMatches.SelectedObject != null)
            {
                selected = (MatchModel)tlvMatches.SelectedObject;
            }

            //Build list of expanded and collapsed matches
            List<MatchModel> e = new List<MatchModel>();
            foreach (var obj in tlvMatches.ExpandedObjects)
            {
                e.Add((MatchModel)obj);
            }
            e = e.Where(match => match.MatchId != null).ToList();

            foreach (var model in MatchModels)
            {
                if (e.Exists(m => m.MatchId == model.MatchId))
                {
                    expanded.Add(model);
                }
                else
                {
                    collapsed.Add(model);
                }
            }

            // Set context
            MatchContext = new MatchContext(selected, collapsed, expanded);
        }

        private void ReestablishMatchContext()
        {
            // Expand/Collapse matches
            tlvMatches.ExpandAll();
            foreach (var m in MatchContext.CollapsedModels)
            {
                tlvMatches.Collapse(m);
            }

            // Set selected
            tlvMatches.SelectedObject = MatchContext.SelectedModel;
        }

        private void ChangeSubDivisionNumber()
        {
            /*
             * pop up to ask for new division and sub-division numbers
             * send async db update
             * update match model
             * */

            // Begin user input and validation

            if (tlvMatches.SelectedObject == null)
                return;

            MatchModel mt = (MatchModel)tlvMatches.SelectedObject;

            if (mt.MatchId == null)
                return;

            string newDisplayId = "";
            var result = Global.InputBox("Select new sub-division number"
                , "Type in a new sub-division number."
                , ref newDisplayId);

            if (result == DialogResult.Cancel)
                return;

            if (!Global.IsValidInteger(newDisplayId))
            {
                MessageBox.Show("You must input a single number only.",
                    "Invalid text pattern",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int divisionId = (int)(mt.DivisionId);
            int subDivisionId = Convert.ToInt32(newDisplayId);

            if (Global.IsDuplicateMatchDisplayId(MatchModels, divisionId, subDivisionId))
            {
                MessageBox.Show(String.Format("Division Id: {0} combined with Sub-Division Id: {1} already exists. Please chose a different number.", divisionId, subDivisionId),
                    "Duplicate Division / Sub-division combination.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // End user input and validation 

            // Begin database update

            mt.DivisionId = divisionId;
            mt.SubDivisionId = subDivisionId;

            DataAccessAsync.UpdateMatchDisplayId(mt);

            // End database update

            // Begin model update

            UpdateMatchModel(mt);

            // End model update
        }

        private void cmiViewMatchDetails_Click(object sender, EventArgs e)
        {
            ViewMatchDetails();
        }

        private void cmiViewSelectedMatchDetails_Click(object sender, EventArgs e)
        {
            ViewMatchDetails();
        }

        private void ViewMatchDetails()
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

        private List<CompetitorModel> SortCompetitorModels(List<CompetitorModel> models)
        {
            //We need to resort for display purposes
            models.Sort(delegate (CompetitorModel x, CompetitorModel y)
            {
                //Handle NULLs even though I do not expect them
                if (x.DisplayName == null && y.DisplayName == null) return 0;
                if (x.DisplayName == null) return -1;
                if (y.DisplayName == null) return 1;

                //Sort by name
                return x.DisplayName.CompareTo(y.DisplayName);
            });

            return models;
        }

        private List<Dojo> SortDojos(List<Dojo> models)
        {
            //We need to resort for display purposes
            models.Sort(delegate (Dojo x, Dojo y)
            {
                //Handle NULLs even though I do not expect them
                if (x.Facility.FacilityName == null && y.Facility.FacilityName == null) return 0;
                if (x.Facility.FacilityName == null) return -1;
                if (y.Facility.FacilityName == null) return 1;

                //Sort by name
                return x.Facility.FacilityName.CompareTo(y.Facility.FacilityName);
            });

            return models;
        }

        private List<EventModel> SortEventModels(List<EventModel> models)
        {
            //We need to resort for display purposes
            models.Sort(delegate (EventModel x, EventModel y)
            {
                //Handle NULLs even though I do not expect them
                if (x.Date == null && y.Date == null) return 0;
                if (x.Date == null) return -1;
                if (y.Date == null) return 1;

                //Sort by Event Date
                if (x.Date < y.Date) return -1;
                if (x.Date > y.Date) return 1;

                //It should never get here but I needed to guarantee all code paths return a value.
                return 0;
            });

            return models;
        }

        public List<MatchModel> SortMatchModels(List<MatchModel> models)
        {
            //We need to resort for display purposes
            models.Sort(delegate (MatchModel x, MatchModel y)
            {
                //Handle NULLs even though I do not expect them
                if (x.DivisionId == null && y.DivisionId == null) return 0;
                if (x.DivisionId == null) return -1;
                if (y.DivisionId == null) return 1;

                //Sort by division
                if (x.DivisionId < y.DivisionId) return -1;
                if (x.DivisionId > y.DivisionId) return 1;

                //Sort by sub-division if divisions match
                if (x.DivisionId == y.DivisionId)
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
            DialogResult r = MessageBox.Show(msg, "Match Selection Assistant", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                try
                {
                    DataAccess.AutoSetMatches(CurrentEvent);
                    RefreshMatchCompetitorScoreViews();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefreshLists_Click(object sender, EventArgs e)
        {
            if (!IsSafeToRefesh())
                return;

            RefreshMatchCompetitorScoreViews();
        }

        private bool IsSafeToRefesh()
        {
            if(ScoresHaveBeenEdited)
            {
                string msg = @"You may have made changes to the event's scores tab which have not been saved.

Would you like to save prior to refreshing all lists?

Save changes (Yes), discard changes (No), or abort the refresh (Cancel)?
";

                DialogResult result = MessageBox.Show(msg, "Unsaved changes",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);

                switch (result)
                {
                    case DialogResult.Cancel: return false;
                    case DialogResult.Yes: SubmitScores(); break;
                }
            }

            return true;
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
                case "Duplicate match type":
                    type = FilterType.DuplicateMatchType;
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
                type == FilterType.MatchesWithTooFewCompetitors ||
                type == FilterType.DuplicateMatchType)
            {
                var model = await Global.FilterMatchModelAsync(MatchModels, type, this.txtMatchFilter.Text, CompetitorModels, MatchTypes);

                RefreshMatches(model);
            }
        }

        private void RefreshDivisions()
        {
            Divisions = new List<Division>();
            this.tmrDivisions.Enabled = true;
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.cmiMatchNewMatch.Enabled = false;
            this.tmrNewMatch.Enabled = true;

            Task.Run(() => RefreshDivisionsAsync());
        }

        public void RefreshMatches(List<MatchModel> model)
        {
            SetMatchContext();
            MatchModelLoadComplete = false;
            tlvMatches.Roots = model;
            MatchModelLoadComplete = true;
            ReestablishMatchContext();
        }

        private void RefreshCompetitors(List<CompetitorModel> model)
        {
            CompetitorModelLoadComplete = false;
            CountCompetitors();

            tlvCompetitors.Roots = model;
            tlvCompetitors.CollapseAll();

            tlvComp.Roots = model;
            tlvComp.CollapseAll();
            CompetitorModelLoadComplete = true;
        }

        private void CountCompetitors()
        {
            string title = "Competitors ( Count: " + CompetitorModels.Count + " )";
            gbComp.Text = title;
        }

        private async void RefreshMatchesAndCompetitorsAndScores()
        {
            //For some reason, when I remove these 3 lines
            //I get an error from this.tlvMatches.ExpandAll() in RefreshMatches().
            //In theory, these shouldn't be needed because they are in the child methods but that is on a different thread.
            MatchModelLoadComplete = false;
            CompetitorModelLoadComplete = false;
            ScoresLoadComplete = false;

            Task.Run(() => RefreshCompetitors());
            Task.Run(() => RefreshMatches());
            Task.Run(() => RefreshScoresAsync());
        }

        private async void RefreshMatches()
        {
            MatchModelLoadComplete = false;
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = SortMatchModels(Global.GetMatchModel(mcs));
            MatchModelLoadComplete = true;
        }

        private async void RefreshCompetitors()
        {
            CompetitorModelLoadComplete = false;
            List<Competitor> cs = await DataAccessAsync.GetCompetitors(CurrentEvent);
            CompetitorModels = SortCompetitorModels(Global.GetCompetitorModel(cs));
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

            //Set name as default selection
            this.cbCompetitorFilterBy.SelectedIndex = this.cbCompetitorFilterBy.FindStringExact("Name");
            this.cbCompFilterBy.SelectedIndex = this.cbCompetitorFilterBy.FindStringExact("Name");
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
            this.cbMatchFilterBy.Items.Add("Duplicate match type");

            //Set name as default selection
            this.cbMatchFilterBy.SelectedIndex = this.cbMatchFilterBy.FindStringExact("Name");
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
            RefreshMatchCompetitorScoreViews();
        }

        private void tmrMatchCompetitorScoreRefresh_Tick(object sender, EventArgs e)
        {
            //this method was implemented because I was unable to refresh the treelistviews after
            //the async calls to refresh the match and competitor models was complete

            if (MatchModelLoadComplete && CompetitorModelLoadComplete && ScoresLoadComplete)
            {
                this.lblLoading.Visible = false;
                this.lblCompLoading.Visible = false;
                this.lblScoresLoading.Visible = false;
                this.tmrMatchCompetitorRefresh.Enabled = false;
                this.rbAll.Enabled = true;
                this.rbApplicableMatches.Enabled = true;

                RefreshMatches(MatchModels);
                RefreshCompetitors(CompetitorModels);
                RefreshScoresGrid();
                ScoresHaveBeenEdited = false;
                AutoResizeForm();
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
                this.tmrDivisions.Enabled = false;
            }
        }

        private void rbApplicableMatches_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbApplicableMatches.Checked)
            {
                FilterApplicableMatches();
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
        
        private void cmiMatchesExpandAll_Click(object sender, EventArgs e)
        {
            this.tlvMatches.ExpandAll();
            SetMatchContext();
        }

        private void cmiMatchesCollapseAll_Click(object sender, EventArgs e)
        {
            this.tlvMatches.CollapseAll();
            SetMatchContext();
        }

        private void btnClearCompetitorFilter_Click(object sender, EventArgs e)
        {
            ClearCompetitorFilters();
        }

        private void ClearCompetitorFilters()
        {
            RefreshCompetitors(CompetitorModels);
            txtCompetitorFilter.Text = "";
            txtCompFilter.Text = "";
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
            frm.CurrentEvent = CurrentEvent;
            frm.ParentFormMain = this;
            frm.Show();
        }

        private void tmrNewMatch_Tick(object sender, EventArgs e)
        {
            if (Divisions.Count > 0 && MatchModelLoadComplete)
            {
                this.cmiMatchNewMatch.Enabled = true;
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
            Dojos = SortDojos(await DataAccessAsync.GetDojos());
        }

        private void LoadCompetitorBelt(Rank rank)
        {
            if (rank == null)
                return;

            CompetitorDetailsGridMap map = new CompetitorDetailsGridMap();
            dgvCompetitorDetails[map.Belt.Value.ColumnIndex, map.Belt.Value.RowIndex].Value = rank.RankName;
        }

        private void btnCompRegEvents_Click(object sender, EventArgs e)
        {
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp == null)
                return;

            frmCompRegEvents frm = new frmCompRegEvents();
            frm.CompetitorModel = ((CompetitorModel)this.tlvComp.SelectedObject);
            frm.Show();
        }

        private void LoadCompetitorSchool(Competitor comp)
        {
            if (comp.Dojo != null && comp.Dojo.DojoId != 0)
            {
                SetCompetitorSchoolControls(true);

                dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value = comp.Dojo.Facility.FacilityName;

                if (comp.Dojo.Facility.Owner == null)
                {
                    dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value = "";
                    return;
                }

                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex,
                    map.Instructor.Value.RowIndex].Value = comp.Dojo.Facility.Owner.DisplayName;
            }
            else
            {
                SetCompetitorSchoolControls(false);
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].Value = comp.OtherDojoName;
                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value = comp.OtherInstructorName;
            }
        }

        private void SetCompetitorSchoolControls(bool HasDojoId)
        {
            if (HasDojoId)
            {
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].ReadOnly = true;
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].Value = "";

                dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].ReadOnly = false;
            }
            else
            {
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].ReadOnly = false;
                dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value = "Other";
            }
        }

        private void LoadCompetitorTitle(Title title)
        {
            if (title == null)
                return;

            dgvCompetitorDetails[map.Title.Value.ColumnIndex, map.Title.Value.RowIndex].Value = title.TitleName;
        }

        private void LoadCompetitorGender(string gender)
        {
            if (String.IsNullOrEmpty(gender))
                gender = "";
            else if (gender.ToLower().CompareTo("f") == 0)
                gender = "Female";
            else if (gender.ToLower().CompareTo("m") == 0)
                gender = "Male";

            dgvCompetitorDetails[map.Gender.Value.ColumnIndex, map.Gender.Value.RowIndex].Value = gender;
        }

        private void LoadCompetitorDetails(CompetitorModel compModel)
        {
            Competitor comp = compModel.Competitor;

            dgvCompetitorDetails[map.FirstName.Value.ColumnIndex, map.FirstName.Value.RowIndex].Value = comp.Person.FirstName;
            dgvCompetitorDetails[map.LastName.Value.ColumnIndex, map.LastName.Value.RowIndex].Value = comp.Person.LastName;
            dgvCompetitorDetails[map.AppartmentNumber.Value.ColumnIndex, map.AppartmentNumber.Value.RowIndex].Value = comp.Person.AppartmentCode;
            dgvCompetitorDetails[map.City.Value.ColumnIndex, map.City.Value.RowIndex].Value = comp.Person.City;
            dgvCompetitorDetails[map.Country.Value.ColumnIndex, map.Country.Value.RowIndex].Value = comp.Person.Country;
            dgvCompetitorDetails[map.Email.Value.ColumnIndex, map.Email.Value.RowIndex].Value = comp.Person.EmailAddress;
            if (comp.Parent != null)
            {
                dgvCompetitorDetails[map.ParentEmail.Value.ColumnIndex, map.ParentEmail.Value.RowIndex].Value = comp.Parent.EmailAddress;
                dgvCompetitorDetails[map.ParentFirstName.Value.ColumnIndex, map.ParentFirstName.Value.RowIndex].Value = comp.Parent.FirstName;
                dgvCompetitorDetails[map.ParentLastName.Value.ColumnIndex, map.ParentLastName.Value.RowIndex].Value = comp.Parent.LastName;
            }
            dgvCompetitorDetails[map.PhoneNumber.Value.ColumnIndex, map.PhoneNumber.Value.RowIndex].Value = comp.Person.PhoneNumber;
            dgvCompetitorDetails[map.State.Value.ColumnIndex, map.State.Value.RowIndex].Value = comp.Person.StateProvince;
            dgvCompetitorDetails[map.Street1.Value.ColumnIndex, map.Street1.Value.RowIndex].Value = comp.Person.StreetAddress1;
            dgvCompetitorDetails[map.Street2.Value.ColumnIndex, map.Street2.Value.RowIndex].Value = comp.Person.StreetAddress2;
            dgvCompetitorDetails[map.PostalCode.Value.ColumnIndex, map.PostalCode.Value.RowIndex].Value = comp.Person.PostalCode;

            dgvCompetitorDetails[map.Weight.Value.ColumnIndex, map.Weight.Value.RowIndex].Value = comp.Weight;
            dgvCompetitorDetails[map.Height.Value.ColumnIndex, map.Height.Value.RowIndex].Value = comp.Height;

            dgvCompetitorDetails[map.Age.Value.ColumnIndex, map.Age.Value.RowIndex].Value = comp.Age;

            LoadCompetitorBelt(comp.Rank);
            LoadCompetitorSchool(comp);
            LoadCompetitorTitle(comp.Person.Title);
            LoadCompetitorGender(comp.Person.Gender);
            SetSpecialConsiderationsCellValue(comp);
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

        private void tmrCompTab_Tick(object sender, EventArgs e)
        {
            bool TurnMeOff = true;
            if (Ranks.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (((DataGridViewComboBoxCell)dgvCompetitorDetails[map.Belt.Value.ColumnIndex,
                map.Belt.Value.RowIndex]).Items.Count == 0)
            {
                SetCompetitorBeltDropdown();
            }

            if (Dojos.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (((DataGridViewComboBoxCell)dgvCompetitorDetails[map.School.Value.ColumnIndex,
                map.School.Value.RowIndex]).Items.Count == 1)
            {
                SetCompetitorDojoDropdown();
            }

            if (Titles.Count == 0)
            {
                TurnMeOff = false;
            }
            else if (((DataGridViewComboBoxCell)dgvCompetitorDetails[map.Title.Value.ColumnIndex,
                map.Title.Value.RowIndex]).Items.Count == 0)
            {
                SetCompetitorTitleDropdown();
            }

            if (TurnMeOff)
                this.tmrCompTab.Enabled = false;
        }

        private void cbCompSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvCompetitorDetails[map.School.Value.ColumnIndex,
                    map.School.Value.RowIndex].ToString().CompareTo("Other") == 0)
            {
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].Value = "";
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].ReadOnly = false;

                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value = "";
                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].ReadOnly = false;
            }
            else
            {
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].Value = "";
                dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].ReadOnly = true;

                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value = "";
                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].ReadOnly = true;

                string selectedSchool = "";
                if (dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value != null)
                    selectedSchool = dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value.ToString();
                Dojo dojo = (Dojos.Where(d => d.Facility.FacilityName.CompareTo(selectedSchool) == 0)).FirstOrDefault();
                dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value = dojo.Facility.Owner.DisplayName;
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
            ClearCompetitorSelection();
        }

        private void btnSaveComp_Click(object sender, EventArgs e)
        {
            SaveCompetitor(false);
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

            comp.Person.FirstName = dgvCompetitorDetails[map.FirstName.Value.ColumnIndex, map.FirstName.Value.RowIndex].Value.ToString();
            comp.Person.EmailAddress = dgvCompetitorDetails[map.Email.Value.ColumnIndex, map.Email.Value.RowIndex].Value.ToString();
            comp.Person.LastName = dgvCompetitorDetails[map.LastName.Value.ColumnIndex, map.LastName.Value.RowIndex].Value.ToString();

            if (IsNew && Global.IsDuplicatePerson(comp.Person))
            {
                MessageBox.Show("The same combination of FirstName, LastName, and EmailAddress already exists.", "Duplicate person", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            comp.Weight = Convert.ToDecimal(dgvCompetitorDetails[map.Weight.Value.ColumnIndex, map.Weight.Value.RowIndex].Value.ToString());
            comp.Person.DisplayName = dgvCompetitorDetails[map.LastName.Value.ColumnIndex, map.LastName.Value.RowIndex].Value.ToString() +
                ", " +
                dgvCompetitorDetails[map.FirstName.Value.ColumnIndex, map.FirstName.Value.RowIndex].Value.ToString();
            comp.Height = Convert.ToDecimal(dgvCompetitorDetails[map.Height.Value.ColumnIndex, map.Height.Value.RowIndex].Value.ToString());
            comp.Person.Gender = (dgvCompetitorDetails[map.Gender.Value.ColumnIndex,
                                    map.Gender.Value.RowIndex].Value.ToString().CompareTo("Female") == 0) ? "F" : "M";
            comp.Age = Convert.ToInt32(dgvCompetitorDetails[map.Age.Value.ColumnIndex, map.Age.Value.RowIndex].Value.ToString());

            if (dgvCompetitorDetails[map.ParentFirstName.Value.ColumnIndex, map.ParentFirstName.Value.RowIndex].Value != null
                && dgvCompetitorDetails[map.ParentLastName.Value.ColumnIndex, map.ParentLastName.Value.RowIndex].Value != null
                && dgvCompetitorDetails[map.ParentEmail.Value.ColumnIndex, map.ParentEmail.Value.RowIndex].Value != null)
            {
                comp.Parent.FirstName = dgvCompetitorDetails[map.ParentFirstName.Value.ColumnIndex, map.ParentFirstName.Value.RowIndex].Value.ToString();
                comp.Parent.LastName = dgvCompetitorDetails[map.ParentLastName.Value.ColumnIndex, map.ParentLastName.Value.RowIndex].Value.ToString();
                comp.Parent.EmailAddress = dgvCompetitorDetails[map.ParentEmail.Value.ColumnIndex, map.ParentEmail.Value.RowIndex].Value.ToString();
            }
            comp.Person.PhoneNumber = dgvCompetitorDetails[map.PhoneNumber.Value.ColumnIndex, map.PhoneNumber.Value.RowIndex].Value.ToString();
            comp.Person.Country = dgvCompetitorDetails[map.Country.Value.ColumnIndex, map.Country.Value.RowIndex].Value.ToString();
            comp.Person.StreetAddress1 = dgvCompetitorDetails[map.Street1.Value.ColumnIndex, map.Street1.Value.RowIndex].Value.ToString();
            comp.Person.StreetAddress2 = (dgvCompetitorDetails[map.Street2.Value.ColumnIndex, map.Street2.Value.RowIndex].Value != null) ? dgvCompetitorDetails[map.Street2.Value.ColumnIndex, map.Street2.Value.RowIndex].Value.ToString() : "";
            comp.Person.AppartmentCode = (dgvCompetitorDetails[map.AppartmentNumber.Value.ColumnIndex, map.AppartmentNumber.Value.RowIndex].Value != null) ? dgvCompetitorDetails[map.AppartmentNumber.Value.ColumnIndex, map.AppartmentNumber.Value.RowIndex].Value.ToString() : "";
            comp.Person.City = dgvCompetitorDetails[map.City.Value.ColumnIndex, map.City.Value.RowIndex].Value.ToString();
            comp.Person.StateProvince = dgvCompetitorDetails[map.State.Value.ColumnIndex, map.State.Value.RowIndex].Value.ToString();
            comp.Person.PostalCode = dgvCompetitorDetails[map.PostalCode.Value.ColumnIndex, map.PostalCode.Value.RowIndex].Value.ToString();

            comp.Rank = (Ranks.Where(r => r.RankName.CompareTo(
                                                                dgvCompetitorDetails[map.Belt.Value.ColumnIndex,
                                                                    map.Belt.Value.RowIndex].Value.ToString()
                                                                ) == 0)).First();
            comp.Person.Title = (dgvCompetitorDetails[map.Title.Value.ColumnIndex,
                                    map.Title.Value.RowIndex].Value == null) ?
                                        new Title() :
                                        (Titles.Where(t => t.TitleName.CompareTo(dgvCompetitorDetails[map.Title.Value.ColumnIndex,
                                                                                    map.Title.Value.RowIndex].Value.ToString()) == 0)).First();

            string selectedSchool = "";
            if (dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value != null)
                selectedSchool = dgvCompetitorDetails[map.School.Value.ColumnIndex, map.School.Value.RowIndex].Value.ToString();
            comp.Dojo = (Dojos.Where(d => d.Facility.FacilityName.CompareTo(selectedSchool) == 0)).FirstOrDefault();

            comp.OtherDojoName = "";
            comp.OtherInstructorName = "";
            if (comp.Dojo == null)
            {
                var value = dgvCompetitorDetails[map.Instructor.Value.ColumnIndex, map.Instructor.Value.RowIndex].Value;
                comp.OtherInstructorName = (value != null) ? value.ToString() : "";
                value = dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex, map.OtherSchool.Value.RowIndex].Value;
                comp.OtherDojoName = (value != null) ? value.ToString() : "";
            }

            SaveCompetitor(comp, IsNew);
        }

        private void UpdateCompetitorModel(Competitor updatedCompetitor)
        {
            CompetitorModel cm = new CompetitorModel(updatedCompetitor);

            //It will throw an exception if this is a new competitor to be inserted.
            //In that case, we will just skip the removal step of this process.
            try
            {
                var existing_cm = CompetitorModels.Where(c => c.CompetitorId == cm.CompetitorId).First();
                CompetitorModels.Remove(existing_cm);
            }
            catch { }

            CompetitorModels.Add(cm);

            CompetitorModels = SortCompetitorModels(CompetitorModels);
            RefreshCompetitors(CompetitorModels);
        }

        private void UpdateMatchModel(MatchModel updatedMatch)
        {
            var existing_mm = MatchModels.Where(m => m.MatchId == updatedMatch.MatchId).First();

            MatchModels.Remove(existing_mm);
            MatchModels.Add(updatedMatch);

            MatchModels = SortMatchModels(MatchModels);
            RefreshMatches(MatchModels);
        }

        private void SaveCompetitor(Competitor comp, bool IsNew)
        {
            if (IsNew)
            {
                comp.CompetitorId = DataAccess.InsertCompetitor(comp);
            }
            else
            {
                DataAccess.UpdateCompetitor(comp);
            }

            UpdateCompetitorModel(comp);
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

        #region BuildCompetitorDetailsGridView
        private void BuildCompetitorDetailsGridView()
        {
            // Grid Settings
            dgvCompetitorDetails.ReadOnly = false;
            dgvCompetitorDetails.AllowUserToDeleteRows = false;
            dgvCompetitorDetails.ColumnCount = map.ColumnCount;
            dgvCompetitorDetails.AllowUserToAddRows = false;
            dgvCompetitorDetails.AllowUserToDeleteRows = false;
            dgvCompetitorDetails.AllowUserToOrderColumns = false;
            dgvCompetitorDetails.AllowUserToResizeColumns = true;
            dgvCompetitorDetails.AllowUserToResizeRows = true;

            dgvCompetitorDetails.Rows.Add(map.RowCount);

            for (int c = 0; c < dgvCompetitorDetails.Columns.Count; c++)
            {
                dgvCompetitorDetails.Columns[c].MinimumWidth = map.MinimumColumnWidth;
            }

            // Hidden id column
            dgvCompetitorDetails.Columns[0].Visible = false;
            dgvCompetitorDetails.Columns[0].ValueType = typeof(int);
            for (int i = 0; i < dgvCompetitorDetails.Rows.Count; i++)
            {
                dgvCompetitorDetails[0, i].Value = i;
            }

            // Build cells
            SetCompetitorDetailsGridLabelFields();
            SetCompetitorDetailsGridDataFields();

            //Refresh
            dgvCompetitorDetails.Refresh();
            dgvCompetitorDetails.AutoResizeColumns();
        }

        private void SetCompetitorDetailsGridDataFields()
        {
            CompetitorDetailsGridMap map = new CompetitorDetailsGridMap();

            #region Text Boxes
            // First Name text box
            dgvCompetitorDetails[map.FirstName.Value.ColumnIndex,
                map.FirstName.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.FirstName.Value.ColumnIndex,
                map.FirstName.Value.RowIndex].ReadOnly = false;
            // Last Name text box
            dgvCompetitorDetails[map.LastName.Value.ColumnIndex,
                map.LastName.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.LastName.Value.ColumnIndex,
                map.LastName.Value.RowIndex].ReadOnly = false;
            // Other school text box
            dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex,
                map.OtherSchool.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.OtherSchool.Value.ColumnIndex,
                map.OtherSchool.Value.RowIndex].ReadOnly = false;
            // Instructor text box
            dgvCompetitorDetails[map.Instructor.Value.ColumnIndex,
                map.Instructor.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Instructor.Value.ColumnIndex,
                map.Instructor.Value.RowIndex].ReadOnly = false;
            // Parent First Name text box
            dgvCompetitorDetails[map.ParentFirstName.Value.ColumnIndex,
                map.ParentFirstName.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentFirstName.Value.ColumnIndex,
                map.ParentFirstName.Value.RowIndex].ReadOnly = false;
            // Parent last Name text box
            dgvCompetitorDetails[map.ParentLastName.Value.ColumnIndex,
                map.ParentLastName.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentLastName.Value.ColumnIndex,
                map.ParentLastName.Value.RowIndex].ReadOnly = false;
            // Email text box
            dgvCompetitorDetails[map.Email.Value.ColumnIndex,
                map.Email.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Email.Value.ColumnIndex,
                map.Email.Value.RowIndex].ReadOnly = false;
            // Parent Email text box
            dgvCompetitorDetails[map.ParentEmail.Value.ColumnIndex,
                map.ParentEmail.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentEmail.Value.ColumnIndex,
                map.ParentEmail.Value.RowIndex].ReadOnly = false;
            // Phone number text box
            dgvCompetitorDetails[map.PhoneNumber.Value.ColumnIndex,
                map.PhoneNumber.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.PhoneNumber.Value.ColumnIndex,
                map.PhoneNumber.Value.RowIndex].ReadOnly = false;
            // Street 1 text box
            dgvCompetitorDetails[map.Street1.Value.ColumnIndex,
                map.Street1.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Street1.Value.ColumnIndex,
                map.Street1.Value.RowIndex].ReadOnly = false;
            // Street 2 text box
            dgvCompetitorDetails[map.Street2.Value.ColumnIndex,
                map.Street2.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Street2.Value.ColumnIndex,
                map.Street2.Value.RowIndex].ReadOnly = false;
            // City text box
            dgvCompetitorDetails[map.City.Value.ColumnIndex,
                map.City.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.City.Value.ColumnIndex,
                map.City.Value.RowIndex].ReadOnly = false;
            // State text box
            dgvCompetitorDetails[map.State.Value.ColumnIndex,
                map.State.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.State.Value.ColumnIndex,
                map.State.Value.RowIndex].ReadOnly = false;
            // Postal code text box
            dgvCompetitorDetails[map.PostalCode.Value.ColumnIndex,
                map.PostalCode.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.PostalCode.Value.ColumnIndex,
                map.PostalCode.Value.RowIndex].ReadOnly = false;
            // Country text box
            dgvCompetitorDetails[map.Country.Value.ColumnIndex,
                map.Country.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Country.Value.ColumnIndex,
                map.Country.Value.RowIndex].ReadOnly = false;
            // Appt. # text box
            dgvCompetitorDetails[map.AppartmentNumber.Value.ColumnIndex,
                map.AppartmentNumber.Value.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.AppartmentNumber.Value.ColumnIndex,
                map.AppartmentNumber.Value.RowIndex].ReadOnly = false;
            #endregion Text Boxes

            #region Numerics
            // weight
            dgvCompetitorDetails[map.Weight.Value.ColumnIndex,
                map.Weight.Value.RowIndex].ValueType = typeof(double);
            dgvCompetitorDetails[map.Weight.Value.ColumnIndex,
                map.Weight.Value.RowIndex].ReadOnly = false;
            // height
            dgvCompetitorDetails[map.Height.Value.ColumnIndex,
                map.Height.Value.RowIndex].ValueType = typeof(double);
            dgvCompetitorDetails[map.Height.Value.ColumnIndex,
                map.Height.Value.RowIndex].ReadOnly = false;
            #endregion Numerics

            #region Combo boxes

            // age
            int[] ages = new int[121];
            for (int i = 0; i < 121; i++)
            {
                ages[i] = i;
            }
            DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell
            {
                ValueType = typeof(int),
                ReadOnly = false,
                DataSource = ages
            };
            dgvCompetitorDetails[map.Age.Value.ColumnIndex,
                map.Age.Value.RowIndex] = cbCell;

            // gender
            string[] genders = new string[] { "Female", "Male" };
            cbCell = new DataGridViewComboBoxCell
            {
                ValueType = typeof(string),
                ReadOnly = false,
                DataSource = genders
            };
            dgvCompetitorDetails[map.Gender.Value.ColumnIndex,
                map.Gender.Value.RowIndex] = cbCell;

            SetCompetitorTitleDropdown();
            SetCompetitorDojoDropdown();
            SetCompetitorBeltDropdown();

            #endregion Combo boxes

            #region Buttons

            dgvCompetitorDetails[map.Special.Value.ColumnIndex,
                map.Special.Value.RowIndex] = new DataGridViewButtonCell
                {
                    Value = "Special Considerations"
                };

            dgvCompetitorDetails[map.RegisteredEvents.Value.ColumnIndex,
                map.RegisteredEvents.Value.RowIndex] = new DataGridViewButtonCell
                {
                    Value = "Registered Events"
                };

            #endregion Buttons
        }

        private void SetCompetitorDetailsGridLabelFields()
        {
            CompetitorDetailsGridMap map = new CompetitorDetailsGridMap();

            dgvCompetitorDetails[map.FirstName.Base.ColumnIndex,
                map.FirstName.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.FirstName.Base.ColumnIndex,
                map.FirstName.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.FirstName.Base.ColumnIndex,
                map.FirstName.Base.RowIndex].Value = "First Name";
            dgvCompetitorDetails[map.LastName.Base.ColumnIndex,
                map.LastName.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.LastName.Base.ColumnIndex,
                map.LastName.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.LastName.Base.ColumnIndex,
                map.LastName.Base.RowIndex].Value = "Last Name";
            dgvCompetitorDetails[map.Weight.Base.ColumnIndex,
                map.Weight.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Weight.Base.ColumnIndex,
                map.Weight.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Weight.Base.ColumnIndex,
                map.Weight.Base.RowIndex].Value = "Weight (lb)";
            dgvCompetitorDetails[map.Height.Base.ColumnIndex,
                map.Height.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Height.Base.ColumnIndex,
                map.Height.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Height.Base.ColumnIndex,
                map.Height.Base.RowIndex].Value = "Height (in)";
            dgvCompetitorDetails[map.Gender.Base.ColumnIndex,
                map.Gender.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Gender.Base.ColumnIndex,
                map.Gender.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Gender.Base.ColumnIndex,
                map.Gender.Base.RowIndex].Value = "Gender";
            dgvCompetitorDetails[map.Age.Base.ColumnIndex,
                map.Age.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Age.Base.ColumnIndex,
                map.Age.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Age.Base.ColumnIndex,
                map.Age.Base.RowIndex].Value = "Age";
            dgvCompetitorDetails[map.Belt.Base.ColumnIndex,
                map.Belt.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Belt.Base.ColumnIndex,
                map.Belt.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Belt.Base.ColumnIndex,
                map.Belt.Base.RowIndex].Value = "Belt";
            dgvCompetitorDetails[map.Title.Base.ColumnIndex,
                map.Title.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Title.Base.ColumnIndex,
                map.Title.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Title.Base.ColumnIndex,
                map.Title.Base.RowIndex].Value = "Title";
            dgvCompetitorDetails[map.School.Base.ColumnIndex,
                map.School.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.School.Base.ColumnIndex,
                map.School.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.School.Base.ColumnIndex,
                map.School.Base.RowIndex].Value = "School";
            dgvCompetitorDetails[map.OtherSchool.Base.ColumnIndex,
                map.OtherSchool.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.OtherSchool.Base.ColumnIndex,
                map.OtherSchool.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.OtherSchool.Base.ColumnIndex,
                map.OtherSchool.Base.RowIndex].Value = "Other School";
            dgvCompetitorDetails[map.Instructor.Base.ColumnIndex,
                map.Instructor.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Instructor.Base.ColumnIndex,
                map.Instructor.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Instructor.Base.ColumnIndex,
                map.Instructor.Base.RowIndex].Value = "Instructor";
            dgvCompetitorDetails[map.ParentFirstName.Base.ColumnIndex,
                map.ParentFirstName.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentFirstName.Base.ColumnIndex,
                map.ParentFirstName.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.ParentFirstName.Base.ColumnIndex,
                map.ParentFirstName.Base.RowIndex].Value = "Parent First Name";
            dgvCompetitorDetails[map.ParentLastName.Base.ColumnIndex,
                map.ParentLastName.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentLastName.Base.ColumnIndex,
                map.ParentLastName.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.ParentLastName.Base.ColumnIndex,
                map.ParentLastName.Base.RowIndex].Value = "Parent Last Name";
            dgvCompetitorDetails[map.ParentEmail.Base.ColumnIndex,
                map.ParentEmail.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.ParentEmail.Base.ColumnIndex,
                map.ParentEmail.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.ParentEmail.Base.ColumnIndex,
                map.ParentEmail.Base.RowIndex].Value = "Parent Email";
            dgvCompetitorDetails[map.PhoneNumber.Base.ColumnIndex,
                map.PhoneNumber.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.PhoneNumber.Base.ColumnIndex,
                map.PhoneNumber.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.PhoneNumber.Base.ColumnIndex,
                map.PhoneNumber.Base.RowIndex].Value = "Phone Number";
            dgvCompetitorDetails[map.Street1.Base.ColumnIndex,
                map.Street1.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Street1.Base.ColumnIndex,
                map.Street1.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Street1.Base.ColumnIndex,
                map.Street1.Base.RowIndex].Value = "Street 1";
            dgvCompetitorDetails[map.City.Base.ColumnIndex,
                map.City.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.City.Base.ColumnIndex,
                map.City.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.City.Base.ColumnIndex,
                map.City.Base.RowIndex].Value = "City";
            dgvCompetitorDetails[map.Email.Base.ColumnIndex,
                map.Email.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Email.Base.ColumnIndex,
                map.Email.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Email.Base.ColumnIndex,
                map.Email.Base.RowIndex].Value = "Email";
            dgvCompetitorDetails[map.Street2.Base.ColumnIndex,
                map.Street2.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Street2.Base.ColumnIndex,
                map.Street2.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Street2.Base.ColumnIndex,
                map.Street2.Base.RowIndex].Value = "Street 2";
            dgvCompetitorDetails[map.State.Base.ColumnIndex,
                map.State.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.State.Base.ColumnIndex,
                map.State.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.State.Base.ColumnIndex,
                map.State.Base.RowIndex].Value = "State";
            dgvCompetitorDetails[map.Country.Base.ColumnIndex,
                map.Country.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.Country.Base.ColumnIndex,
                map.Country.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.Country.Base.ColumnIndex,
                map.Country.Base.RowIndex].Value = "Country";
            dgvCompetitorDetails[map.AppartmentNumber.Base.ColumnIndex,
                map.AppartmentNumber.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.AppartmentNumber.Base.ColumnIndex,
                map.AppartmentNumber.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.AppartmentNumber.Base.ColumnIndex,
                map.AppartmentNumber.Base.RowIndex].Value = "Appt. #";
            dgvCompetitorDetails[map.PostalCode.Base.ColumnIndex,
                map.PostalCode.Base.RowIndex].ValueType = typeof(string);
            dgvCompetitorDetails[map.PostalCode.Base.ColumnIndex,
                map.PostalCode.Base.RowIndex].ReadOnly = true;
            dgvCompetitorDetails[map.PostalCode.Base.ColumnIndex,
                map.PostalCode.Base.RowIndex].Value = "Postal Code";
        }

        private void SetCompetitorTitleDropdown()
        {
            string[] titles = GetCompetitorTitleDropdown();
            DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell
            {
                ValueType = typeof(string),
                ReadOnly = false,
                DataSource = titles
            };
            dgvCompetitorDetails[map.Title.Value.ColumnIndex,
                map.Title.Value.RowIndex] = cbCell;

            dgvCompetitorDetails.Refresh();
        }

        private string[] GetCompetitorTitleDropdown()
        {
            string[] titles = new string[0];

            foreach (var title in Titles)
            {
                Array.Resize(ref titles, (titles.GetUpperBound(0) + 2));
                titles[titles.GetUpperBound(0)] = title.TitleName;
            }

            return titles;
        }

        private void SetCompetitorDojoDropdown()
        {
            string[] schools = GetCompetitorDojoDropdown();
            DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell
            {
                ValueType = typeof(string),
                ReadOnly = false,
                DataSource = schools
            };
            dgvCompetitorDetails[map.School.Value.ColumnIndex,
                map.School.Value.RowIndex] = cbCell;

            dgvCompetitorDetails.Refresh();
        }

        private string[] GetCompetitorDojoDropdown()
        {
            string[] schools = new string[1] { "Other" };

            foreach (var dojo in Dojos)
            {
                Array.Resize(ref schools, (schools.GetUpperBound(0) + 2));
                schools[schools.GetUpperBound(0)] = dojo.Facility.FacilityName;
            }

            return schools;
        }

        private void SetCompetitorBeltDropdown()
        {
            string[] belts = GetCompetitorBeltDropdown();
            DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell
            {
                ValueType = typeof(string),
                ReadOnly = false,
                DataSource = belts
            };
            dgvCompetitorDetails[map.Belt.Value.ColumnIndex,
                map.Belt.Value.RowIndex] = cbCell;

            dgvCompetitorDetails.Refresh();
        }

        private string[] GetCompetitorBeltDropdown()
        {
            string[] belts = new string[0];

            foreach (var rank in Ranks)
            {
                Array.Resize(ref belts, (belts.GetUpperBound(0) + 2));
                belts[belts.GetUpperBound(0)] = rank.RankName;
            }

            return belts;
        }

        private void LaunchCompetitorSpecialConsiderationsForm()
        {
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp != null)
            {
                frmCompSpecialConsiderationDetail frm = new frmCompSpecialConsiderationDetail();
                frm.CompetitorModel = comp;
                frm.mainForm = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("You must save this competitor or select an existing competitor to set the Special Considerations.", 
                    "Existing Competitor Required", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Hand);
                return;
            }
        }

        private void LaunchCompetitorEventRegistrationForm()
        {
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp != null)
            {
                frmCompRegEvents frm = new frmCompRegEvents();
                frm.CompetitorModel = (comp);
                frm.Show();
            }
            else
            {
                MessageBox.Show("You must save this competitor or select an existing competitor to set the Registered Events.",
                    "Existing Competitor Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }
        }

        public void SetSpecialConsiderationsCellValue()
        {
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            SetSpecialConsiderationsCellValue(comp);
        }

        private void SetSpecialConsiderationsCellValue(bool? isSpecial)
        {
            if (isSpecial != null)
            {
                if (isSpecial == true)
                {
                    dgvCompetitorDetails[map.Special.Base.ColumnIndex, map.Special.Base.RowIndex].Value = "Is Special";
                }
                else
                {
                    dgvCompetitorDetails[map.Special.Base.ColumnIndex, map.Special.Base.RowIndex].Value = "Not Special";
                }
            }
            else
            {
                dgvCompetitorDetails[map.Special.Base.ColumnIndex, map.Special.Base.RowIndex].Value = "Special Considerations";
            }
        }

        private void SetSpecialConsiderationsCellValue(CompetitorModel comp)
        {
            bool? isSpecial;
            isSpecial = (comp != null) ? (bool?)comp.IsSpecialConsideration : null;        
            SetSpecialConsiderationsCellValue(isSpecial);
        }

        private void SetSpecialConsiderationsCellValue(Competitor comp)
        {
            bool? isSpecial;
            isSpecial = (comp != null) ? (bool?)comp.IsSpecialConsideration : null;
            SetSpecialConsiderationsCellValue(isSpecial);
        }

        private void dgvCompetitorDetails_SpecialConsiderations_ButtonClick(DataGridViewButtonCell cell)
        {
            LaunchCompetitorSpecialConsiderationsForm();
        }

        private void dgvCompetitorDetails_RegisteredEvents_ButtonClick(DataGridViewButtonCell cell)
        {
            LaunchCompetitorEventRegistrationForm();
        }

        private void dgvCompetitorDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            CompetitorDetailsGridMap map = new CompetitorDetailsGridMap();

            if (senderGrid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell &&
                e.RowIndex >= 0)
            {
                // Is Special Considerations
                if (e.ColumnIndex == map.Special.Base.ColumnIndex && 
                    e.RowIndex == map.Special.Base.RowIndex)
                    dgvCompetitorDetails_SpecialConsiderations_ButtonClick((DataGridViewButtonCell)senderGrid[e.ColumnIndex, e.RowIndex]);

                // Registered Events
                if (e.ColumnIndex == map.RegisteredEvents.Base.ColumnIndex &&
                    e.RowIndex == map.RegisteredEvents.Base.RowIndex)
                    dgvCompetitorDetails_RegisteredEvents_ButtonClick((DataGridViewButtonCell)senderGrid[e.ColumnIndex, e.RowIndex]);
            }
        }
        #endregion BuildCompetitorDetailsGridView

        #endregion Competitor Tab

        #region Event Tab
        private void RefreshEvents()
        {
            AllEvents = DataAccess.GetEventInformation();
            EventModels = Global.GetEventModel(AllEvents);

            ClearEventSelection();
            RefreshEvents(EventModels);
            RefreshEventSelect();
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

            UpdateEventModel(Event);
            //This will reset the home tab dropdown and it will refresh the entire event models.
            RefreshEventSelect();
        }

        private void UpdateEventModel(Event Event)
        {
            EventModel em = new EventModel
            {
                EventId = Event.EventId,
                Date = Event.Date,
                EventName = Event.EventName,
                EventTypeName = Event.EventType.EventTypeName
            };

            var existing_em = EventModels.Where(e => e.EventId == em.EventId).First();

            EventModels.Remove(existing_em);
            EventModels.Add(em);

            EventModels = SortEventModels(EventModels);
            RefreshEvents(EventModels);
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

        #region Score Tab

        private void cmiScoreDeleteRows_Click(object sender, EventArgs e)
        {
            ScoresEndEditAndDiscardNewRow();

            if(!dgvScore.CurrentRow.IsNewRow)
                dgvScore.Rows.Remove(dgvScore.CurrentRow);

            ScoresHaveBeenEdited = true;
        }

        private void btnScoresUndoChanges_Click(object sender, EventArgs e)
        {
            UndoScoreChanges();
        }

        private void UndoScoreChanges()
        {
            RefreshScores();
        }

        private void btnSubmitScores_Click(object sender, EventArgs e)
        {
            SubmitScores();
        }

        private void ScoresEndEditAndDiscardNewRow()
        {
            dgvScore.EndEdit();
            FlushUnboundScoreGridBuffers();
        }

        private void SubmitScores()
        {
            ScoresEndEditAndDiscardNewRow();

            ScoreErrorType err = Global.ValidateScores(Scores, CurrentEvent);

            if (err == ScoreErrorType.None)
            {
                DataAccess.MergeScores(Scores, CurrentEvent);

                //Refresh whole list so that ScoreIds can be pulled into the bound object list
                RefreshScores();

                MessageBox.Show("Scores saved successfully.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (err)
                {
                    case ScoreErrorType.DuplicateCompetitorInMatch:
                        MessageBox.Show("There is a match with the same competitor having two sets of scores.", "Save Failed (Duplicate competitor in match)"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ScoreErrorType.RankOutOfBounds:
                        MessageBox.Show("Rank values must be greater than 0.", "Save Failed (Rank out of bounds)"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ScoreErrorType.ScoreOutOfBounds:
                        MessageBox.Show("Judge score values must be greater than or equal to 0 and less than or equal to 10.", "Save Failed (Judge Score out of bounds)"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case ScoreErrorType.DuplicateRankInMatch:
                        MessageBox.Show("There is a match with two competitors having the same rank value for 1st, 2nd, or 3rd place.", "Save Failed (Duplicate rank within match)"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Scores failed to save.", "Unhandled validation error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void RefreshScoresGrid()
        {
            BuildScoresGrid();
            dgvScore.DataSource = Scores;
            dgvScore.Refresh();
            dgvScore.AutoResizeColumns();
        }

        private void BuildScoresGrid()
        {
            if (dgvScore.Columns["dgvScoresDivSubDiv"] != null)
                return;

            dgvScore.Columns.Add(BindMatchTypesColumn());
            dgvScore.Columns.Add(BindDivisionsColumn());
            dgvScore.Columns.Add(BindCompetitorsColumn());

            SetScoreColumnDisplayOrder();
        }

        private void DisableDataGridViewComboBoxCell(DataGridViewComboBoxCell cell)
        {
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            cell.ReadOnly = true;
        }

        private void EnableDataGridViewComboBoxCell(DataGridViewComboBoxCell cell)
        {
            cell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cell.ReadOnly = false;
        }

        private void dgvScore_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ListSortDirection order = ListSortDirection.Ascending;
            if (dgvScore.SortOrder == SortOrder.Ascending)
                order = ListSortDirection.Descending;

            foreach (DataGridViewColumn c in dgvScore.Columns)
                c.HeaderCell.SortGlyphDirection = SortOrder.None;

            DataGridViewColumn col = dgvScore.Columns[e.ColumnIndex];
            switch (col.Name)
            {
                case "dgvScoreMatchTypeName":
                    col = dgvScore.Columns["dgvScoreMatchTypeNameHidden"];
                    break;
                case "dgvScoresDivSubDiv":
                    col = dgvScore.Columns["dgvScoreDivSubDivHidden"];
                    break;
            }

            dgvScore.Sort(col, order);
            dgvScore.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = (order == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending;
        }

        private DataGridViewComboBoxColumn BindDivisionsColumn()
        {
            BindingSource bindingSource = new BindingSource
            {
                DataSource = MatchModels
            };

            DataGridViewComboBoxColumn Column = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "MatchDisplayName",
                DataSource = bindingSource,
                ValueMember = "MatchDisplayName",
                DisplayMember = "MatchDisplayName",
                Name = "dgvScoresDivSubDiv",
                HeaderText = "Div-SubDiv",
                SortMode = DataGridViewColumnSortMode.Programmatic,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                ReadOnly = true
            };

            return Column;
        }

        private DataGridViewComboBoxColumn BindMatchTypesColumn()
        {
            BindingSource bindingSource = new BindingSource
            {
                DataSource = MatchModels
            };

            DataGridViewComboBoxColumn Column = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "MatchTypeDisplayName",
                DataSource = bindingSource,
                ValueMember = "MatchTypeDisplayName",
                DisplayMember = "MatchTypeDisplayName",
                Name = "dgvScoreMatchTypeName",
                HeaderText = "Match Type",
                SortMode = DataGridViewColumnSortMode.Programmatic,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                ReadOnly = true
            };
            
            return Column;
        }

        private DataGridViewComboBoxColumn BindCompetitorsColumn()
        {
            BindingSource bindingSource = new BindingSource
            {
                DataSource = CompetitorModels
            };

            DataGridViewComboBoxColumn Column = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "DisplayName",
                DataSource = bindingSource,
                ValueMember = "DisplayName",
                DisplayMember = "DisplayName",
                Name = "dgvScoresDisplayName",
                HeaderText = "Competitors",
                SortMode = DataGridViewColumnSortMode.Programmatic,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                ReadOnly = true
            };

            return Column;
        }

        private void BindFilteredCompetitorsColumn(int matchId, int rowIndex)
        {
            //Poor man's deep copy
            List<CompetitorModel> cm = new List<CompetitorModel>();
            foreach (var c in CompetitorModels)
                cm.Add(c);

            MatchModel m = MatchModels.Where(y => y.MatchId == matchId).FirstOrDefault();
            
            cm.RemoveAll(x => !m.Children.Any(z => x.CompetitorId == z.CompetitorId));

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = cm;

            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dgvScore.Rows[rowIndex].Cells[dgvScore.Columns["dgvScoresDisplayName"].Index];
            cell.DataSource = bindingSource;
        }

        private void SetScoreColumnDisplayOrder()
        {
            dgvScore.Columns["dgvScoresDivSubDiv"].DisplayIndex = 0;
            dgvScore.Columns["dgvScoreMatchTypeName"].DisplayIndex = 1;
            dgvScore.Columns["dgvScoresDisplayName"].DisplayIndex = 2;
            dgvScore.Columns["dgvScoreJudge1"].DisplayIndex = 3;
            dgvScore.Columns["dgvScoreJudge2"].DisplayIndex = 4;
            dgvScore.Columns["dgvScoreJudge3"].DisplayIndex = 5;
            dgvScore.Columns["dgvScoreJudge4"].DisplayIndex = 6;
            dgvScore.Columns["dgvScoreJudge5"].DisplayIndex = 7;
            dgvScore.Columns["dgvScoresTotal"].DisplayIndex = 8;
            dgvScore.Columns["dgvScoresRanked"].DisplayIndex = 9;
            dgvScore.Columns["dgvScoresIsDisqualified"].DisplayIndex = 10;
        }

        private SortableBindingList<Score> RefreshSavedScores()
        {
            SortableBindingList<Score> scores = DataAccess.GetScoresByEvent(CurrentEvent);
            SavedScores = scores;
            return SavedScores;
        }

        private SortableBindingList<Score> DeepCopyScoresList(SortableBindingList<Score> scores)
        {
            SortableBindingList<Score> copy = new SortableBindingList<Score>();

            foreach(Score s in scores)
            {
                copy.Add(new Score
                {
                    CompetitorId = s.CompetitorId,
                    DisplayName = s.DisplayName,
                    ScoreJudge1 = s.ScoreJudge1,
                    ScoreJudge2 = s.ScoreJudge2,
                    ScoreJudge3 = s.ScoreJudge3,
                    ScoreJudge4 = s.ScoreJudge4,
                    ScoreJudge5 = s.ScoreJudge5,
                    DivisionId = s.DivisionId,
                    EventId = s.EventId,
                    IsDisqualified = s.IsDisqualified,
                    MatchId = s.MatchId,
                    MatchType = new MatchType
                    {
                        IsSpecialConsideration = s.MatchType.IsSpecialConsideration,
                        MatchTypeId = s.MatchType.MatchTypeId,
                        MatchTypeName = s.MatchType.MatchTypeName
                    },
                    Ranked = s.Ranked,
                    ScoreId = s.ScoreId,
                    SubDivisionId = s.SubDivisionId
                });
            }

            return copy;
        }

        private void RefreshScores()
        {
            ScoresLoadComplete = false;
            SortableBindingList<Score> scores = DataAccess.GetScoresByEvent(CurrentEvent);
            Scores = scores;
            SavedScores = DeepCopyScoresList(scores);
            RefreshScoresGrid();
            ScoresHaveBeenEdited = false;
            ScoresLoadComplete = true;
        }

        private async void RefreshScoresAsync()
        {
            ScoresLoadComplete = false;
            SortableBindingList<Score> scores = await DataAccessAsync.GetScoresByEvent(CurrentEvent);
            Scores = scores;
            SavedScores = DeepCopyScoresList(scores);
            ScoresHaveBeenEdited = false;
            ScoresLoadComplete = true;
        }

        private void dgvScore_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            ComputeScoreTotal(e.RowIndex);
        }

        private void dgvScore_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvScore.Rows[e.RowIndex];
            FlushUnboundScoreGridBuffer(row);
            ComputeScoreTotal(row);
        }

        private void FlushUnboundScoreGridBuffers()
        {
            if (!DynamicColumnsHaveBeenAdded())
                return;

            for (int i = 0; i < dgvScore.Rows.Count; i++)
            {
                DataGridViewRow row = dgvScore.Rows[i];
                FlushUnboundScoreGridBuffer(row);
            }
        }

        private void FlushUnboundScoreGridBuffer(DataGridViewRow row)
        {
            Score s;
            try { s = (Score)row.DataBoundItem; }
            catch { return; }
            if (s == null) return;

            //Event
            s.EventId = CurrentEvent.EventId;

            //Division-SubDivision
            if (row.Cells["dgvScoresDivSubDiv"].Value == null)
                return;

            DivisionSubDivision div = new DivisionSubDivision(row.Cells["dgvScoresDivSubDiv"].Value.ToString());            
            s.DivisionId = div.DivisionId;
            s.SubDivisionId = div.SubDivisionId;

            //Match
            MatchModel match = MatchModels.Where(x => x.DivisionId == div.DivisionId && x.SubDivisionId == div.SubDivisionId).FirstOrDefault();
            s.MatchId = (match.MatchId != null) ? (int)match.MatchId : -1;

            //Match Type
            if (row.Cells["dgvScoreMatchTypeName"].Value == null)
                return;

            s.MatchType = MatchTypes.Where(x => x.MatchTypeDisplayName == row.Cells["dgvScoreMatchTypeName"].Value.ToString()).FirstOrDefault();

            //Competitor
            if (row.Cells["dgvScoresDisplayName"].Value == null)
                return;

            s.CompetitorId = CompetitorModels.Where(x => x.DisplayName == row.Cells["dgvScoresDisplayName"].Value.ToString()).FirstOrDefault().CompetitorId;
        }

        private void dgvScore_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetdgvScoreEditableCells();
        }

        private void dgvScore_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;

            e.ContextMenuStrip = cmsScores;
        }

        private void SetScoreContextMenuItemDeleteRowsText(int? ColIndex, int? RowIndex)
        {
            DataGridViewCell divCell, competitorCell;
            DataGridViewRow row;

            if (ColIndex == null || RowIndex == null)
            {
                if (dgvScore.CurrentRow == null)
                    return;

                row = dgvScore.CurrentRow;
            }
            else
            {
                row = dgvScore.Rows[(int)RowIndex];
            }

            divCell = row.Cells["dgvScoresDivSubDiv"];
            competitorCell = row.Cells["dgvScoresDisplayName"];

            string div = (divCell.Value == null) ? "?" : divCell.Value.ToString();
            string competitor = (competitorCell.Value == null) ? "?" : competitorCell.Value.ToString();

            cmiScoreDeleteRows.Text = string.Format("Delete row: Div: {0}, Name: {1}", div, competitor);
        }

        private void dgvScore_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                SetScoreContextMenuItemDeleteRowsText(e.ColumnIndex,e.RowIndex);

                DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                if (!c.Selected)
                {
                    c.DataGridView.ClearSelection();
                    c.DataGridView.CurrentCell = c;
                    c.Selected = true;
                }
            }
        }

        private void dgvScore_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F10 && e.Shift) || e.KeyCode == Keys.Apps)
            {
                SetScoreContextMenuItemDeleteRowsText(null,null);

                DataGridViewCell currentCell = (sender as DataGridView).CurrentCell;
                e.SuppressKeyPress = true;
                if (currentCell != null)
                {
                    ContextMenuStrip cms = currentCell.ContextMenuStrip;
                    if (cms != null)
                    {
                        Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
                        Point p = new Point(r.X + r.Width, r.Y + r.Height);
                        cms.Show(currentCell.DataGridView, p);
                    }
                }

                return;
            }
        }

        private void cmiScoreAddRow_Click(object sender, EventArgs e)
        {
            AddingNewScoresRow();
        }

        private void dgvScore_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!DynamicColumnsHaveBeenAdded())
                return;

            for (int i = 0; i < e.RowCount; i++)
            {
                DataGridViewRow row = dgvScore.Rows[e.RowIndex + i];
                SetdgvScoreColumns(row);
                ComputeScoreTotal(row);
            }
        }

        private bool DynamicColumnsHaveBeenAdded()
        {
            if (dgvScore.Columns["dgvScoresDivSubDiv"] == null
                || dgvScore.Columns["dgvScoreMatchTypeName"] == null
                || dgvScore.Columns["dgvScoresDisplayName"] == null)
                return false;

            return true;
        }

        private void SetdgvScoreEditableCells()
        {
            if (!DynamicColumnsHaveBeenAdded())
                return;

            for (int i = 0; i < dgvScore.Rows.Count; i++)
            {
                DataGridViewRow row = dgvScore.Rows[i];
                SetdgvScoreEditableCells(row);
            }
        }

        private void SetdgvScoreEditableCells(DataGridViewRow row)
        {
            if (row.Cells[dgcScoresScoreId.Index].Value == null
                || int.Parse(row.Cells[dgcScoresScoreId.Index].Value.ToString()) == -1
                || row.Cells[dgvScoresMatchId.Index].Value == null
                || int.Parse(row.Cells[dgvScoresMatchId.Index].Value.ToString()) == -1)
            {
                EnableDataGridViewComboBoxCell((DataGridViewComboBoxCell)row.Cells["dgvScoresDivSubDiv"]);
                EnableDataGridViewComboBoxCell((DataGridViewComboBoxCell)row.Cells["dgvScoresDisplayName"]);
                return;
            }

            int.TryParse(row.Cells[dgcScoresScoreId.Index].Value.ToString(), out int result);
            if (!SavedScores.Any(y => y.ScoreId == result))
            {
                EnableDataGridViewComboBoxCell((DataGridViewComboBoxCell)row.Cells["dgvScoresDivSubDiv"]);
                EnableDataGridViewComboBoxCell((DataGridViewComboBoxCell)row.Cells["dgvScoresDisplayName"]);
            }
        }

        private void SetdgvScoreColumns(DataGridViewRow row)
        {
            if (row.Cells["dgvScoresMatchId"].Value == null)
                return;

            int.TryParse(row.Cells["dgvScoresMatchId"].Value.ToString(), out int result);
            if (result == -1) //If Match object is default object
                return;

            row.Cells["dgvScoresDivSubDiv"].Value = MatchModels.Where(m => m.MatchId == result).FirstOrDefault().MatchDisplayName;
            row.Cells["dgvScoreMatchTypeName"].Value = MatchModels.Where(m => m.MatchId == result).FirstOrDefault().MatchTypeName;
        }

        private void dgvScore_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Do nothing if total was just being recalculated
            if (dgvScore.Columns["dgvScoresTotal"].Index == e.ColumnIndex)
                return;

            DataGridViewRow row = dgvScore.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = Color.Aquamarine;

            ScoresHaveBeenEdited = true;

            if (row.Cells[dgvScore.Columns["dgvScoresDivSubDiv"].Index].ColumnIndex == e.ColumnIndex)
                SetCellsOnScoresDivisionChange(row);
        }

        private void dgvScore_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvScore.Columns["dgvScoresDisplayName"].Index)
                FilterAvailableCompetitorsInScoreComboBox(e.RowIndex);
        }

        private void SetCellsOnScoresDivisionChange(DataGridViewRow row)
        {
            //Reset Match Type
            string div = row.Cells["dgvScoresDivSubDiv"].Value.ToString();
            row.Cells["dgvScoreMatchTypeName"].Value = MatchModels.Where(m => m.MatchDisplayName.CompareTo(div) == 0).FirstOrDefault().MatchTypeName;

            //Reset Competitor selection
            row.Cells[dgvScore.Columns["dgvScoresDisplayName"].Index].Value = null;
        }

        private void FilterAvailableCompetitorsInScoreComboBox(int RowIndex)
        {
            DataGridViewCell cell = dgvScore.Rows[RowIndex].Cells[dgvScore.Columns["dgvScoresDivSubDiv"].Index];
            if (cell.Value == null)
                return;

            string div = cell.Value.ToString();
            int? matchId = MatchModels.Where(x => x.MatchDisplayName.CompareTo(div) == 0).FirstOrDefault().MatchId;
            
            if(matchId != null)
                BindFilteredCompetitorsColumn((int)matchId, RowIndex);                
        }

        private void AddingNewScoresRow()
        {
            Scores.Add(new Score());
        }

        private void dgvScore_Sorted(object sender, EventArgs e)
        {
            ComputeScoreTotals();
        }

        private void ComputeScoreTotals()
        {
            foreach (DataGridViewRow row in dgvScore.Rows)
            {
                ComputeScoreTotal(row);
            }
        }

        private void ComputeScoreTotal(int rowIndex)
        {
            ComputeScoreTotal(dgvScore.Rows[rowIndex]);
        }

        private void ComputeScoreTotal(DataGridViewRow row)
        {
            if (row == null)
                return;

            string score1 = (row.Cells[dgvScoreJudge1.Index].Value == null) ? "0" : row.Cells[dgvScoreJudge1.Index].Value.ToString();
            string score2 = (row.Cells[dgvScoreJudge2.Index].Value == null) ? "0" : row.Cells[dgvScoreJudge2.Index].Value.ToString();
            string score3 = (row.Cells[dgvScoreJudge3.Index].Value == null) ? "0" : row.Cells[dgvScoreJudge3.Index].Value.ToString();
            string score4 = (row.Cells[dgvScoreJudge4.Index].Value == null) ? "0" : row.Cells[dgvScoreJudge4.Index].Value.ToString();
            string score5 = (row.Cells[dgvScoreJudge5.Index].Value == null) ? "0" : row.Cells[dgvScoreJudge5.Index].Value.ToString();
            decimal result;
            if (Decimal.TryParse(score1, out result)
                && Decimal.TryParse(score2, out result)
                && Decimal.TryParse(score3, out result)
                && Decimal.TryParse(score4, out result)
                && Decimal.TryParse(score5, out result))
            {
                row.Cells[dgvScoresTotal.Index].Value = Decimal.Parse(score1) + Decimal.Parse(score2) +
                    Decimal.Parse(score3) + Decimal.Parse(score4) + Decimal.Parse(score5);
            }
            else
            {
                row.Cells[dgvScoresTotal.Index].Value = "N/A";
            }
        }
        #endregion Score Tab

        #region Form Sizing
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            AutoResizeForm();
        }

        private void AutoResizeForm()
        {
            if (_resizing) return;
            _resizing = true;

            AutoResizeMainControls();
            AutoResizeHomeControls();
            AutoResizeEventControls();
            AutoResizeMatchControls();
            AutoResizeCompetitorControls();
            AutoResizeScoreControls();

            _resizing = false;
        }

        private void AutoResizeScoreControls()
        {
            const double scores_width_multiplier = 1;
            const double padding = 10;

            // DataGridView size
            dgvScore.Width = (int)((tab1.Width * scores_width_multiplier) - (padding * 3));
            dgvScore.Height = tab1.Height - (int)(padding * 4);
            dgvScore.Left = (int)padding;
            dgvScore.Top = (int)padding;

            // DataGridView font
            Font selection_font = Global.AutoResizeFont(dgvScore);
            dgvScore.Font = selection_font;

            // Column Width
            dgvScore.AutoResizeColumns();
            dgvScore.AutoResizeRows();
        }

        private void AutoResizeMainControls()
        {
            //Tab panel
            tab1.Width = this.Width - tab1.Left - 20;
            tab1.Height = this.Height - tab1.Top - 100;

            //Logos
            int tab1_bottom_edge_buffer = tab1.Top + tab1.Height + 10;
            pbCompany.Top = tab1_bottom_edge_buffer;
            pbPoweredBy.Top = tab1_bottom_edge_buffer;
            pbPoweredBy.Left = this.Width - pbPoweredBy.Width - 20;

            //Labels
            int labelTop = (tab1.Height / 2) - (lblLoading.Height / 2);
            int labelLeft = tab1.Left + (tab1.Width / 2) - (lblLoading.Width / 2);

            lblLoading.Top = labelTop;
            lblLoading.Left = labelLeft;

            lblScoresLoading.Top = labelTop;
            lblScoresLoading.Left = labelLeft;

            lblCompLoading.Top = labelTop;
            lblCompLoading.Left = labelLeft;

            //Buttons
            //  Static relation to each other, centered
            btnRetryConnection.Left = (this.Width / 2) - (btnRetryConnection.Width / 2);
            btnRefreshLists.Left = (this.Width / 2) - (btnRefreshLists.Width / 2);

            btnClearCompetitorFilter.Left = btnRefreshLists.Left - btnClearCompetitorFilter.Width - 40;
            btnClearMatchFilter.Left = btnRefreshLists.Left + btnRefreshLists.Width + 40;

            btnRetryConnection.Top = tab1_bottom_edge_buffer;
            btnRefreshLists.Top = tab1_bottom_edge_buffer;
            btnClearCompetitorFilter.Top = tab1_bottom_edge_buffer;
            btnClearMatchFilter.Top = tab1_bottom_edge_buffer;

            btnSubmitScores.Left = btnRefreshLists.Left - btnClearCompetitorFilter.Width - 40;
            btnScoresUndoChanges.Left = btnRefreshLists.Left + btnRefreshLists.Width + 40;
            btnSubmitScores.Top = tab1_bottom_edge_buffer;
            btnScoresUndoChanges.Top = tab1_bottom_edge_buffer;
        }

        private void AutoResizeHomeControls()
        {
            int width_padding = 20;
            int half_widths = (tab1.Width / 2) - width_padding;
            int height_padding = 40;
            int max_height = tab1.Height - height_padding;

            gbScorecards.Width = half_widths;
            gbEvent.Width = half_widths;
            gbAdmin.Width = half_widths;
            gbEvent.Height = (int)(max_height * 0.5);
            gbAdmin.Height = (int)(max_height * 0.5) - 15;

            AutoResizeHomeEventGroupControls();

            gbScorecards.Height = max_height - lblReportCreds.Height - 10;
            
            AutoResizeHomeAdminGroupControls();
            AutoResizeHomeScorecardGroupControls();

            int top_center = (tab1.Height / 2);
            int left_center = (tab1.Width / 2) - 5;

            gbEvent.Left = left_center - gbEvent.Width - 5;
            gbAdmin.Left = left_center - gbEvent.Width - 5;
            gbEvent.Top = top_center - (gbScorecards.Height / 2) - 15;
            gbAdmin.Top = gbEvent.Top + gbEvent.Height + 8;
            gbScorecards.Left = left_center + 5;

            lblReportCreds.Top = 10;
            lblReportCreds.Font = Global.AutoResizeFont(cbEventSelect);
            lblReportCreds.Left = gbScorecards.Left + (gbScorecards.Width / 2) - (lblReportCreds.Width / 2);

            gbScorecards.Top = gbEvent.Top + lblReportCreds.Height;
        }

        private void AutoResizeHomeEventGroupControls()
        {
            // Selection controls
            int left_control_total_width = (int)(gbEvent.Width * 0.66);
            int date_fitler_label_width = (int)(left_control_total_width / 8);
            int padding = 5;

            //      Date filter
            dtpEventFrom.Width = date_fitler_label_width * 3;
            dtpEventTo.Width = date_fitler_label_width * 3;

            Font selection_font = Global.AutoResizeFont(dtpEventFrom);
            dtpEventFrom.Font = selection_font;
            dtpEventTo.Font = selection_font;
            lblEventFrom.Font = selection_font;
            lblEventTo.Font = selection_font;

            lblEventFrom.Left = padding;
            dtpEventFrom.Left = lblEventFrom.Left + lblEventFrom.Width + padding;
            lblEventTo.Left = dtpEventFrom.Left + dtpEventFrom.Width + padding;
            dtpEventTo.Left = lblEventTo.Left + lblEventTo.Width + padding;

            //      Event select
            cbEventSelect.Width = (int)(left_control_total_width * 0.66);
            cbEventSelect.Font = Global.AutoResizeFont(cbEventSelect);
            lblEventSelect.Font = cbEventSelect.Font;
            cbEventSelect.Left = lblEventSelect.Left + lblEventSelect.Width + padding;

            // Registration button
            btnEventLoadReg.Width = gbEvent.Width - left_control_total_width - (padding * 2);
            btnEventLoadReg.Left = gbEvent.Width - btnEventLoadReg.Width - padding;
            btnEventLoadReg.Height = gbEvent.Height - (padding * 5);
            btnEventLoadReg.Top = (padding * 3);
            btnEventLoadReg.Font = Global.AutoResizeFont(btnEventLoadReg);

            // EventInfo
            rtbEventInfo.Width = left_control_total_width - padding;
            rtbEventInfo.Top = cbEventSelect.Top + cbEventSelect.Height + padding;
            rtbEventInfo.Height = gbEvent.Height - rtbEventInfo.Top - (padding * 2);
            rtbEventInfo.Font = Global.AutoResizeFont(rtbEventInfo);
        }

        private void AutoResizeHomeAdminGroupControls()
        {
            List<Control> controls = new List<Control>
            {
                btnAllEvents,
                btnRegForm,
                btnCheckInRoster,
                btnSchoolsOwners,
                btnWeighInList,
                btnDivisionRingNumbers,
                btnCompetitorsBySchoolReport
            };

            AutoResizeControlsInGrid(gbAdmin, controls, 4);
        }

        private void AutoResizeHomeScorecardGroupControls()
        {
            List<Control> controls = new List<Control>
            {
                btnKata,
                btnWeaponKata,
                btnKataSpecial,
                btnSemiKnockdown,
                btnKnockdown,
                btnWeaponKataSpecial,
                btnSemiKnockdownSpecial,
                btnKnockdownSpecial
            };

            AutoResizeControlsInGrid(gbScorecards, controls, 3);
        }

        private void AutoResizeControlsInGrid(Control groupBox, List<Control> controls, int column_count)
        {
            int padding = 5;
            int column_counter = 0;
            Control last_control = null;
            int current_top = padding * 5;
            int col1_left = padding * 3;
            int button_width = (int)((groupBox.Width - (padding * 10)) / column_count);
            int row_count = (int)Math.Ceiling((decimal)controls.Count / (decimal)column_count);
            int button_height = (int)((groupBox.Height - (padding * (row_count + 5))) / row_count);

            foreach (Control control in controls)
            {
                int current_left = col1_left + ((button_width + padding) * column_counter);
                
                //If we just moved to the next row
                if (column_counter == 0 && last_control != null)
                    current_top = last_control.Top + button_height + padding;

                control.Top = current_top;
                control.Height = button_height;
                control.Width = button_width;
                control.Left = current_left;
                control.Font = Global.AutoResizeFont(control);

                column_counter++;
                if (column_counter == column_count)
                    column_counter = 0;

                last_control = control;
            }

        }
        
        private void AutoResizeEventControls()
        {
            //Groups
            gbEvents.Width = (int)((tabEvents.Width * 0.40) - 10);
            gbEventDetails.Width = (int)((tabEvents.Width * 0.60) - 15);
            gbEventDetails.Left = (int)((tabEvents.Width * 0.40) + 10);
            gbEvents.Height = tabEvents.Height - 15;
            gbEventDetails.Height = tabEvents.Height - 15;

            //Events group
            tlvEvents.Height = gbEvents.Height - 35;
            tlvEvents.Width = gbEvents.Width - 10;

            //Details group
            int desired_label_width = (int)(gbEvents.Width * 0.28);
            int minimum_label_space_padding = 5;

            //  Size controls
            int size = (int)((gbEvents.Width - (desired_label_width + minimum_label_space_padding)) * 0.90);
            txtEventName.Width = size;
            cbEventType.Width = size;
            dtpEventDate.Width = size;

            size = (int)(gbEvents.Width / 3);
            btnNewEvent.Width = size;
            btnSaveEvent.Width = size;
            btnDeleteEvent.Width = size;
            btnClearEventSelection.Width = size;

            size = (int)(btnNewEvent.Width * 0.28);
            btnNewEvent.Height = size;
            btnSaveEvent.Height = size;
            btnDeleteEvent.Height = size;
            btnClearEventSelection.Height = size;

            //  Font scaling
            tlvEvents.Font = Global.AutoResizeFont(tlvEvents);
            tlvEvents.AutoResizeColumns();

            Font font = Global.AutoResizeFont(txtEventName);
            txtEventName.Font = font;
            cbEventType.Font = font;
            dtpEventDate.Font = font;
            lblEventName.Font = font;
            lblEventType.Font = font;
            lblEventDate.Font = font;

            font = Global.AutoResizeFont(btnNewEvent);
            btnNewEvent.Font = font;
            btnSaveEvent.Font = font;
            btnDeleteEvent.Font = font;
            btnClearEventSelection.Font = font;

            //  Center controls
            int line_control_width = desired_label_width + minimum_label_space_padding + txtEventName.Width;
            lblEventName.Left = (gbEventDetails.Width / 2) - (line_control_width / 2);
            txtEventName.Left = lblEventName.Left + desired_label_width + minimum_label_space_padding;
            lblEventType.Left = (gbEventDetails.Width / 2) - (line_control_width / 2);
            cbEventType.Left = lblEventName.Left + desired_label_width + minimum_label_space_padding;
            lblEventDate.Left = (gbEventDetails.Width / 2) - (line_control_width / 2);
            dtpEventDate.Left = lblEventName.Left + desired_label_width + minimum_label_space_padding;

            int control_height_buffer = 30;
            int top_center_adjusted_for_height = (gbEventDetails.Height / 2) - (lblEventType.Height / 2);
            lblEventType.Top = top_center_adjusted_for_height;
            cbEventType.Top = top_center_adjusted_for_height;
            lblEventDate.Top = top_center_adjusted_for_height + lblEventType.Height + control_height_buffer;
            dtpEventDate.Top = top_center_adjusted_for_height + lblEventType.Height + control_height_buffer;
            lblEventName.Top = top_center_adjusted_for_height - lblEventType.Height - control_height_buffer;
            txtEventName.Top = top_center_adjusted_for_height - lblEventType.Height - control_height_buffer;

            //  Bottom buttons
            int gbEventDetails_bottom_buffer = gbEventDetails.Top + gbEventDetails.Height - 15;
            btnSaveEvent.Top = gbEventDetails_bottom_buffer - btnSaveEvent.Height;
            btnNewEvent.Top = gbEventDetails_bottom_buffer - btnNewEvent.Height;
            btnDeleteEvent.Top = gbEventDetails_bottom_buffer - btnDeleteEvent.Height;
            btnClearEventSelection.Top = gbEventDetails_bottom_buffer - btnClearEventSelection.Height;

            btnNewEvent.Left = (gbEventDetails.Width / 2) - btnNewEvent.Width - 5;
            btnSaveEvent.Left = btnNewEvent.Left - btnSaveEvent.Width - 10;
            btnDeleteEvent.Left = btnNewEvent.Left + btnNewEvent.Width + 10;
            btnClearEventSelection.Left = btnDeleteEvent.Left + btnDeleteEvent.Width + 10;
        }

        private void AutoResizeMatchControls()
        {
            const double comp_width_multiplier = 0.4;
            const double dragdrop_width_multiplier = 0.05;
            const double matches_width_multiplier = 0.55;
            const double padding = 10;

            // group placement

            gbMatchCompetitors.Width = Convert.ToInt32((tab1.Width * comp_width_multiplier) - (padding * 2));
            gbMatches.Width = Convert.ToInt32((tab1.Width * matches_width_multiplier) - (padding * 2));
            gbMatchCompetitors.Height = tab1.Height - (int)(padding * 3);
            gbMatches.Height = tab1.Height - (int)(padding * 3);

            gbMatchCompetitors.Left = Convert.ToInt32(padding);
            gbMatches.Left = Convert.ToInt32(gbMatchCompetitors.Width + (padding * 2) + (tab1.Width * dragdrop_width_multiplier));

            // auto size groups

            AutoResizeMatchCompetitorGroupControls();
            AutoResizeMatchMatchGroupControls();

            // place drag and drop label

            lblDragAndDrop.Top = (tab1.Height / 2) - (lblDragAndDrop.Height / 2);
            lblDragAndDrop.Left = gbMatches.Left - 
                (lblDragAndDrop.Width / 2) - 
                (int)((tab1.Width * dragdrop_width_multiplier) / 2) -
                (int)(padding / 2);
        }

        private void AutoResizeMatchCompetitorGroupControls()
        {
            const double padding = 10;

            // control sizing (except TLV heights)

            tlvCompetitors.Width = Convert.ToInt32(gbMatchCompetitors.Width - padding);

            const double comp_filter_width_multiplier = 0.4;
            const double comp_filterby_width_multiplier = 0.45;
            const double comp_apply_width_multiplier = 0.15;

            txtCompetitorFilter.Width = Convert.ToInt32((gbMatchCompetitors.Width * comp_filter_width_multiplier) - padding);
            cbCompetitorFilterBy.Width = Convert.ToInt32((gbMatchCompetitors.Width * comp_filterby_width_multiplier) - padding);
            btnCompetitorApply.Width = Convert.ToInt32((gbMatchCompetitors.Width * comp_apply_width_multiplier) - padding);

            txtCompetitorFilter.Height = cbCompetitorFilterBy.Height;
            btnCompetitorApply.Height = (txtCompetitorFilter.Height * 2) + (int)(padding * 1.5);

            // fonts

            Font current_font = Global.AutoResizeFont(txtCompetitorFilter);
            txtCompetitorFilter.Font = current_font;
            cbCompetitorFilterBy.Font = current_font;
            lblCompetitorFilter.Font = current_font;
            lblCompetitorFilterBy.Font = current_font;
            tlvCompetitors.Font = Global.AutoResizeFont(tlvCompetitors);
            tlvCompetitors.AutoResizeColumns();

            // control placement

            tlvCompetitors.Top = Convert.ToInt32(padding + (cbCompetitorFilterBy.Top + cbCompetitorFilterBy.Height));

            txtCompetitorFilter.Left = tlvCompetitors.Left;
            cbCompetitorFilterBy.Left = txtCompetitorFilter.Left + Convert.ToInt32(padding) + txtCompetitorFilter.Width;
            btnCompetitorApply.Left = cbCompetitorFilterBy.Left + Convert.ToInt32(padding) + cbCompetitorFilterBy.Width;

            lblCompetitorFilter.Top = (int)(padding * 2.5);
            lblCompetitorFilterBy.Top = (int)(padding * 2.5);
            lblCompetitorFilter.Left = txtCompetitorFilter.Left;
            lblCompetitorFilterBy.Left = cbCompetitorFilterBy.Left;

            txtCompetitorFilter.Top = lblCompetitorFilter.Top + (int)(padding * 0.5) + lblCompetitorFilter.Height;
            cbCompetitorFilterBy.Top = lblCompetitorFilterBy.Top + (int)(padding * 0.5) + lblCompetitorFilterBy.Height;
            btnCompetitorApply.Top = lblCompetitorFilter.Top - (int)padding;

            // tree list view heights
            tlvCompetitors.Height = gbMatchCompetitors.Height - tlvCompetitors.Top - (int)padding;
        }

        private void AutoResizeMatchMatchGroupControls()
        {
            const int padding = 10;

            // control sizing (except TLV heights)

            tlvMatches.Width = gbMatches.Width - padding;

            const double match_filter_width_multiplier = 0.35;
            const double match_filterby_width_multiplier = 0.4;
            const double match_apply_width_multiplier = 0.10;

            txtMatchFilter.Width = (int)(gbMatches.Width * match_filter_width_multiplier) - padding;
            cbMatchFilterBy.Width = (int)(gbMatches.Width * match_filterby_width_multiplier) - padding;
            btnMatchApply.Width = (int)(gbMatches.Width * match_apply_width_multiplier) - padding;

            txtMatchFilter.Height = cbMatchFilterBy.Height;
            btnMatchApply.Height = (txtMatchFilter.Height * 2) + (int)(padding * 1.5);

            // fonts

            Font current_font = Global.AutoResizeFont(txtMatchFilter);
            txtMatchFilter.Font = current_font;
            rbAll.Font = current_font;
            rbApplicableMatches.Font = current_font;
            cbMatchFilterBy.Font = current_font;
            btnMatchApply.Font = current_font;
            tlvMatches.Font = tlvCompetitors.Font;
            tlvMatches.AutoResizeColumns();

            // control placement

            tlvMatches.Top = padding + (rbApplicableMatches.Top + rbApplicableMatches.Height);

            txtMatchFilter.Left = rbApplicableMatches.Left + rbApplicableMatches.Width + padding;
            cbMatchFilterBy.Left = txtMatchFilter.Left + (int)padding + txtMatchFilter.Width;
            btnMatchApply.Left = cbMatchFilterBy.Left + (int)padding + cbMatchFilterBy.Width;

            lblMatchFilter.Top = (int)(padding * 2.5);
            lblMatchFilterBy.Top = lblMatchFilter.Top;
            rbAll.Top = lblMatchFilter.Top;
            rbApplicableMatches.Top = rbAll.Top + rbAll.Height + (int)(padding / 2);
            lblMatchFilter.Left = txtMatchFilter.Left;
            lblMatchFilterBy.Left = cbMatchFilterBy.Left;

            txtMatchFilter.Top = lblMatchFilter.Top + (int)(padding * 0.5) + lblMatchFilter.Height;
            cbMatchFilterBy.Top = lblMatchFilterBy.Top + (int)(padding * 0.5) + lblMatchFilterBy.Height;
            btnMatchApply.Top = lblMatchFilter.Top - (int)padding;

            // tree list view heights
            tlvMatches.Height = (gbMatches.Height - tlvMatches.Top) - padding;
        }

        private void AutoResizeCompetitorListControls()
        {
            const double padding = 10;

            // control sizing (except TLV heights)

            tlvComp.Width = Convert.ToInt32(gbComp.Width - padding);

            const double comp_filter_width_multiplier = 0.4;
            const double comp_filterby_width_multiplier = 0.45;
            const double comp_apply_width_multiplier = 0.15;

            txtCompFilter.Width = Convert.ToInt32((gbComp.Width * comp_filter_width_multiplier) - padding);
            cbCompFilterBy.Width = Convert.ToInt32((gbComp.Width * comp_filterby_width_multiplier) - padding);
            btnCompFilterApply.Width = Convert.ToInt32((gbComp.Width * comp_apply_width_multiplier) - padding);

            txtCompFilter.Height = cbCompFilterBy.Height;
            btnCompFilterApply.Height = (txtCompFilter.Height * 2) + (int)(padding * 1.5);

            // fonts

            Font current_font = Global.AutoResizeFont(txtCompFilter);
            txtCompFilter.Font = current_font;
            cbCompFilterBy.Font = current_font;
            lblCompFilter.Font = current_font;
            lblCompFilterBy.Font = current_font;
            tlvComp.Font = Global.AutoResizeFont(tlvComp);
            tlvComp.AutoResizeColumns();

            // control placement

            tlvComp.Top = Convert.ToInt32(padding + (cbCompFilterBy.Top + cbCompFilterBy.Height));

            txtCompFilter.Left = tlvComp.Left;
            cbCompFilterBy.Left = txtCompFilter.Left + Convert.ToInt32(padding) + txtCompFilter.Width;
            btnCompFilterApply.Left = cbCompFilterBy.Left + Convert.ToInt32(padding) + cbCompFilterBy.Width;

            lblCompFilter.Top = (int)(padding * 2.5);
            lblCompFilterBy.Top = (int)(padding * 2.5);
            lblCompFilter.Left = txtCompFilter.Left;
            lblCompFilterBy.Left = cbCompFilterBy.Left;

            txtCompFilter.Top = lblCompFilter.Top + (int)(padding * 0.5) + lblCompFilter.Height;
            cbCompFilterBy.Top = lblCompFilterBy.Top + (int)(padding * 0.5) + lblCompFilterBy.Height;
            btnCompFilterApply.Top = lblCompFilter.Top - (int)padding;

            // tree list view heights
            tlvComp.Height = gbComp.Height - tlvComp.Top - (int)padding;
        }

        private void AutoResizeCompetitorDetailsControls()
        {
            int padding = 10;
            dgvCompetitorDetails.Width = gbCompetitorDetails.Width - (padding * 3);
            AutoResizeCompetitorDetailsColumnWidths();

            // Size
            int size = (gbCompetitorDetails.Width / 6);
            btnSaveComp.Width = size;
            btnNewComp.Width = size;
            btnCompDelete.Width = size;
            btnCompClear.Width = size;

            size = (int)(btnNewComp.Width * 0.35);
            btnSaveComp.Height = size;
            btnNewComp.Height = size;
            btnCompDelete.Height = size;
            btnCompClear.Height = size;

            // Font
            Font font = Global.AutoResizeFont(btnNewComp);
            btnSaveComp.Font = font;
            btnNewComp.Font = font;
            btnCompDelete.Font = font;
            btnCompClear.Font = font;
            dgvCompetitorDetails.DefaultCellStyle.Font = Global.AutoResizeFont(dgvCompetitorDetails);
            dgvCompetitorDetails.AutoResizeRows();

            // Place
            btnSaveComp.Top = gbCompetitorDetails.Height - btnSaveComp.Height - (padding * 2);
            btnNewComp.Top = btnSaveComp.Top;
            btnCompDelete.Top = btnSaveComp.Top;
            btnCompClear.Top = btnSaveComp.Top;

            btnNewComp.Left = (gbCompetitorDetails.Width / 2) - btnNewComp.Width - (padding / 2);
            btnSaveComp.Left = btnNewComp.Left - btnSaveComp.Width - padding;
            btnCompDelete.Left = (gbCompetitorDetails.Width / 2) + (padding / 2);
            btnCompClear.Left = btnCompDelete.Left + btnCompDelete.Width + padding;

            // Finalize grid view
            dgvCompetitorDetails.Height = gbCompetitorDetails.Height -
                                            (padding * 5) -
                                            (gbCompetitorDetails.Height - btnNewComp.Top);
            dgvCompetitorDetails.Refresh();
        }

        private void AutoResizeCompetitorDetailsColumnWidths()
        {
            int column_width = (dgvCompetitorDetails.Width / (dgvCompetitorDetails.Columns.Count - 1)) - 16;

            //Skip hidden id column (0)
            for (int i = 1; i < dgvCompetitorDetails.Columns.Count; i++)
            {
                dgvCompetitorDetails.Columns[i].Width = (column_width < dgvCompetitorDetails.Columns[i].MinimumWidth) ?
                                                            dgvCompetitorDetails.Columns[i].MinimumWidth :
                                                            column_width;
            }
        }

        private void AutoResizeCompetitorControls()
        {
            // Size groups
            int padding = 10;
            gbComp.Width = (int)(tab1.Width * 0.40) - (padding * 2);
            gbCompetitorDetails.Width = (int)(tab1.Width * 0.60) - (padding * 2);
            gbComp.Height = tab1.Height - (padding * 4);
            gbCompetitorDetails.Height = tab1.Height - (padding * 4);

            // Place groups
            gbComp.Left = padding;
            gbCompetitorDetails.Left = gbComp.Left + padding + gbComp.Width;
            gbComp.Top = padding;
            gbCompetitorDetails.Top = padding;

            // Controls
            AutoResizeCompetitorListControls();
            AutoResizeCompetitorDetailsControls();
        }
        #endregion
    }
}
