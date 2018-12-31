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

namespace DKK_App
{
    public partial class frmMain : Form
    {
        public Event CurrentEvent = new Event();
        public List<Event> AllEvents = new List<Event>();
        public List<Event> FilteredEvents = new List<Event>();
        public List<MatchModel> MatchModels = new List<MatchModel>();
        public MatchContext MatchContext = new MatchContext();
        public List<CompetitorModel> CompetitorModels = new List<CompetitorModel>();
        public List<Division> Divisions = new List<Division>();
        private List<Rank> Ranks = new List<Rank>();
        private List<Dojo> Dojos = new List<Dojo>();
        private List<Title> Titles = new List<Title>();
        public List<EventModel> EventModels = new List<EventModel>();
        private Color Green_SQLHammer = Color.FromArgb(40, 190, 155);

        private bool MatchModelLoadComplete = false;
        private bool CompetitorModelLoadComplete = false;
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

            InitializeFormWithDataAccess();

            //Populate controls
            SetFilterDropdowns();
            SetEventDateTimePicker();
            DisableNonEventTabs();

            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeFormWithDataAccess()
        {
            try
            {
                Global.CheckForUpdates();
                SetEventSearchDateRange();
                RefreshEventSelect();
                RefreshEvents();
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

        private void cmiDownloadLatestVersion_Click(object sender, EventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com/go/ehupgradetutorial");
            LaunchWebsite("https://www.sqlhammer.com/go/ehsetup");
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

            AutoResizeForm();
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
            foreach(var m in MatchContext.CollapsedModels)
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
            tlvCompetitors.Roots = model;
            tlvCompetitors.CollapseAll();

            tlvComp.Roots = model;
            tlvComp.CollapseAll();
            CompetitorModelLoadComplete = true;
        }

        private async void RefreshMatchesAndCompetitors()
        {
            //For some reason, when I remove these two lines
            //I get an error from this.tlvMatches.ExpandAll() in RefreshMatches().
            MatchModelLoadComplete = false;
            CompetitorModelLoadComplete = false;

            Task.Run(() => RefreshCompetitors());
            Task.Run(() => RefreshMatches());
        }

        private async void RefreshMatches()
        {
            MatchModelLoadComplete = false;
            List<MatchCompetitor> mcs = await DataAccessAsync.GetMatchCompetitors(CurrentEvent);
            MatchModels = SortMatchModels(Global.GetMatchModel(mcs));
            MatchModelLoadComplete = true;
            //this.tlvMatches.ExpandAll();
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
                this.rbAll.Enabled = true;
                this.rbApplicableMatches.Enabled = true;

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

        private void tlvMatches_CanDrop(object sender, BrightIdeasSoftware.OlvDropEventArgs e)
        {
            //string s = "used as break point to test event";
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

            this.cbCompBelt.SelectedIndex = this.cbCompBelt.FindStringExact(rank.RankName);
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

                this.cbCompSchool.SelectedIndex = this.cbCompSchool.FindStringExact(comp.Dojo.Facility.FacilityName);

                if (comp.Dojo.Facility.Owner == null)
                {
                    this.txtCompInstructor.Text = "";
                    return;
                }

                this.txtCompInstructor.Text = comp.Dojo.Facility.Owner.DisplayName;
            }
            else
            {
                SetCompetitorSchoolControls(false);
                this.txtCompSchoolOther.Text = comp.OtherDojoName;
                this.txtCompInstructor.Text = comp.OtherInstructorName;
            }
        }

        private void SetCompetitorSchoolControls(bool HasDojoId)
        {
            if (HasDojoId)
            {
                this.txtCompSchoolOther.Enabled = false;
                this.txtCompSchoolOther.Text = "";

                this.cbCompSchool.Enabled = true;
            }
            else
            {
                this.txtCompSchoolOther.Enabled = true;
                if (this.cbCompSchool.Items.Count > 0)
                    this.cbCompSchool.SelectedIndex = 0; //"Other"
            }
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
            Competitor comp = compModel.Competitor;
            
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
            
            this.nudCompWeight.Value = comp.Weight;
            this.nudCompHeight.Value = comp.Height;

            this.nudCompAge.Value = comp.Age;

            LoadCompetitorBelt(comp.Rank);
            LoadCompetitorSchool(comp);
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
            this.cbCompSchool.Items.Add("Other");

            foreach (var dojo in Dojos)
            {
                this.cbCompSchool.Items.Add(dojo.Facility.FacilityName);
            }
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
                this.txtCompSchoolOther.Text = "";
                this.txtCompSchoolOther.Enabled = true;

                this.txtCompInstructor.Text = "";
                this.txtCompInstructor.Enabled = true;
            }
            else
            {
                this.txtCompSchoolOther.Text = "";
                this.txtCompSchoolOther.Enabled = false;

                this.txtCompInstructor.Text = "";
                this.txtCompInstructor.Enabled = false;

                string selectedSchool = "";
                if (this.cbCompSchool.SelectedItem != null)
                    selectedSchool = this.cbCompSchool.SelectedItem.ToString();
                Dojo dojo = (Dojos.Where(d => d.Facility.FacilityName.CompareTo(selectedSchool) == 0)).FirstOrDefault();
                this.txtCompInstructor.Text = dojo.Facility.Owner.DisplayName;
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

        private void btnSpecialConsiderationDetails_Click(object sender, EventArgs e)
        {
            //TODO: update the database call for competitormodel to include desc
            frmCompSpecialConsiderationDetail frm = new frmCompSpecialConsiderationDetail();
            CompetitorModel comp = this.tlvComp.SelectedObject as CompetitorModel;

            if (comp != null)
            {
                frm.CompetitorModel = (comp);
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
            comp.Age = (int)this.nudCompAge.Value;
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
            comp.OtherDojoName = this.txtCompSchoolOther.Text;

            string selectedSchool = "";
            if (this.cbCompSchool.SelectedItem != null)
                selectedSchool = this.cbCompSchool.SelectedItem.ToString();
            comp.Dojo = (Dojos.Where(d => d.Facility.FacilityName.CompareTo(selectedSchool) == 0)).FirstOrDefault();

            comp.OtherInstructorName = "";
            if (comp.Dojo == null)
                comp.OtherInstructorName = this.txtCompInstructor.Text;

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
        #endregion

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

            _resizing = false;
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

            //Buttons
            //  Static relation to each other, centered
            btnRetryConnection.Left = (this.Width / 2) - (btnRetryConnection.Width / 2);
            btnRefreshMatchTab.Left = (this.Width / 2) - (btnRefreshMatchTab.Width / 2);

            btnClearCompetitorFilter.Left = btnRefreshMatchTab.Left - btnClearCompetitorFilter.Width - 40;
            btnClearMatchFilter.Left = btnRefreshMatchTab.Left + btnRefreshMatchTab.Width + 40;

            btnRetryConnection.Top = tab1_bottom_edge_buffer;
            btnRefreshMatchTab.Top = tab1_bottom_edge_buffer;
            btnClearCompetitorFilter.Top = tab1_bottom_edge_buffer;
            btnClearMatchFilter.Top = tab1_bottom_edge_buffer;

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

                column_counter++;
                if (column_counter == column_count)
                    column_counter = 0;

                last_control = control;
            }

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

        private void AutoResizeCompetitorControls()
        {

        }

        private void AutoResizeMatchControls()
        {

        }
        #endregion        
    }
}
