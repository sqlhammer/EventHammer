namespace DKK_App
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.lblReportCreds = new System.Windows.Forms.Label();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnCheckInRoster = new System.Windows.Forms.Button();
            this.btnCompetitorsBySchoolReport = new System.Windows.Forms.Button();
            this.btnRegForm = new System.Windows.Forms.Button();
            this.btnSchoolsOwners = new System.Windows.Forms.Button();
            this.btnAllEvents = new System.Windows.Forms.Button();
            this.btnDivisionRingNumbers = new System.Windows.Forms.Button();
            this.btnWeighInList = new System.Windows.Forms.Button();
            this.gbEvent = new System.Windows.Forms.GroupBox();
            this.rtbEventInfo = new System.Windows.Forms.RichTextBox();
            this.btnEventLoadReg = new System.Windows.Forms.Button();
            this.lblEventTo = new System.Windows.Forms.Label();
            this.dtpEventTo = new System.Windows.Forms.DateTimePicker();
            this.dtpEventFrom = new System.Windows.Forms.DateTimePicker();
            this.lblEventFrom = new System.Windows.Forms.Label();
            this.lblEventSelect = new System.Windows.Forms.Label();
            this.cbEventSelect = new System.Windows.Forms.ComboBox();
            this.gbScorecards = new System.Windows.Forms.GroupBox();
            this.btnKnockdownSpecial = new System.Windows.Forms.Button();
            this.btnSemiKnockdownSpecial = new System.Windows.Forms.Button();
            this.btnWeaponKataSpecial = new System.Windows.Forms.Button();
            this.btnKataSpecial = new System.Windows.Forms.Button();
            this.btnKnockdown = new System.Windows.Forms.Button();
            this.btnSemiKnockdown = new System.Windows.Forms.Button();
            this.btnWeaponKata = new System.Windows.Forms.Button();
            this.btnKata = new System.Windows.Forms.Button();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.gbEventDetails = new System.Windows.Forms.GroupBox();
            this.dtpEventDate = new System.Windows.Forms.DateTimePicker();
            this.cbEventType = new System.Windows.Forms.ComboBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.lblEventType = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnClearEventSelection = new System.Windows.Forms.Button();
            this.btnNewEvent = new System.Windows.Forms.Button();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.gbEvents = new System.Windows.Forms.GroupBox();
            this.tlvEvents = new BrightIdeasSoftware.TreeListView();
            this.olvColEventId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEventName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEventDateText = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEventType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColEventDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.lblLoading = new System.Windows.Forms.Label();
            this.gbMatches = new System.Windows.Forms.GroupBox();
            this.btnMatchApply = new System.Windows.Forms.Button();
            this.tlvMatches = new BrightIdeasSoftware.TreeListView();
            this.olvColDivDisplay = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMatchType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDisplayName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColRankName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDojo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbMatchFilterBy = new System.Windows.Forms.ComboBox();
            this.rbApplicableMatches = new System.Windows.Forms.RadioButton();
            this.lblMatchFilterBy = new System.Windows.Forms.Label();
            this.txtMatchFilter = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.lblMatchFilter = new System.Windows.Forms.Label();
            this.gbMatchCompetitors = new System.Windows.Forms.GroupBox();
            this.btnCompetitorApply = new System.Windows.Forms.Button();
            this.tlvCompetitors = new BrightIdeasSoftware.TreeListView();
            this.olvColCompDisplayName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompRankName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvMatchCompHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbCompetitorFilterBy = new System.Windows.Forms.ComboBox();
            this.lblCompetitorFilterBy = new System.Windows.Forms.Label();
            this.txtCompetitorFilter = new System.Windows.Forms.TextBox();
            this.lblCompetitorFilter = new System.Windows.Forms.Label();
            this.lblDragAndDrop = new System.Windows.Forms.Label();
            this.tabCompetitor = new System.Windows.Forms.TabPage();
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblCompLoading = new System.Windows.Forms.Label();
            this.gbCompetitorDetails = new System.Windows.Forms.GroupBox();
            this.dgvCompetitorDetails = new System.Windows.Forms.DataGridView();
            this.btnCompDelete = new System.Windows.Forms.Button();
            this.btnCompClear = new System.Windows.Forms.Button();
            this.btnNewComp = new System.Windows.Forms.Button();
            this.btnSaveComp = new System.Windows.Forms.Button();
            this.gbComp = new System.Windows.Forms.GroupBox();
            this.btnCompFilterApply = new System.Windows.Forms.Button();
            this.tlvComp = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbCompFilterBy = new System.Windows.Forms.ComboBox();
            this.lblCompFilterBy = new System.Windows.Forms.Label();
            this.txtCompFilter = new System.Windows.Forms.TextBox();
            this.lblCompFilter = new System.Windows.Forms.Label();
            this.tabScore = new System.Windows.Forms.TabPage();
            this.lblScoresLoading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.dgcScoresScoreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreMatchTypeNameHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreDivSubDivHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoresMatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreJudge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreJudge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreJudge3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreJudge4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoreJudge5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoresTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoresRanked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScoresIsDisqualified = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.scoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.retryConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submsRefreshEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.submsNewEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.submsSaveEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.submsClearEventSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.submsDeleteEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.msMatches = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiViewSelectedMatchDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiChangeSelectedDivisionNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshMatchAndCompetitorListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchSelectionAssistantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msCompetitor = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newCompetitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedCompetitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedCompetitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSandboxMode = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDownloadLatestVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRetryConnection = new System.Windows.Forms.Button();
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.btnRefreshLists = new System.Windows.Forms.Button();
            this.btnClearMatchFilter = new System.Windows.Forms.Button();
            this.tmrMatchCompetitorRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrDivisions = new System.Windows.Forms.Timer(this.components);
            this.cmsMatches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiMatchesExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMatchesCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMatchNewMatch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiChangeDivisionNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeleteMatch = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiRemoveCompetitors = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiViewMatchDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearCompetitorFilter = new System.Windows.Forms.Button();
            this.pbCompany = new System.Windows.Forms.PictureBox();
            this.pbPoweredBy = new System.Windows.Forms.PictureBox();
            this.tmrNewMatch = new System.Windows.Forms.Timer(this.components);
            this.cmsCompetitor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCompTab = new System.Windows.Forms.Timer(this.components);
            this.tmrRegistrations = new System.Windows.Forms.Timer(this.components);
            this.btnScoresUndoChanges = new System.Windows.Forms.Button();
            this.btnSubmitScores = new System.Windows.Forms.Button();
            this.cmsScores = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiScoreAddRow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiScoreDeleteRows = new System.Windows.Forms.ToolStripMenuItem();
            this.tab1.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.gbEvent.SuspendLayout();
            this.gbScorecards.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.gbEventDetails.SuspendLayout();
            this.gbEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvEvents)).BeginInit();
            this.tabMatch.SuspendLayout();
            this.gbMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).BeginInit();
            this.gbMatchCompetitors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).BeginInit();
            this.tabCompetitor.SuspendLayout();
            this.gbCompetitorDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitorDetails)).BeginInit();
            this.gbComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvComp)).BeginInit();
            this.tabScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).BeginInit();
            this.msMenu.SuspendLayout();
            this.cmsMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).BeginInit();
            this.cmsCompetitor.SuspendLayout();
            this.cmsScores.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabHome);
            this.tab1.Controls.Add(this.tabEvents);
            this.tab1.Controls.Add(this.tabMatch);
            this.tab1.Controls.Add(this.tabCompetitor);
            this.tab1.Controls.Add(this.tabScore);
            this.tab1.Location = new System.Drawing.Point(6, 24);
            this.tab1.Margin = new System.Windows.Forms.Padding(2);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(1128, 494);
            this.tab1.TabIndex = 1;
            this.tab1.SelectedIndexChanged += new System.EventHandler(this.tab1_SelectedIndexChanged);
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.lblReportCreds);
            this.tabHome.Controls.Add(this.gbAdmin);
            this.tabHome.Controls.Add(this.gbEvent);
            this.tabHome.Controls.Add(this.gbScorecards);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Margin = new System.Windows.Forms.Padding(2);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(2);
            this.tabHome.Size = new System.Drawing.Size(1120, 468);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // lblReportCreds
            // 
            this.lblReportCreds.AutoSize = true;
            this.lblReportCreds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportCreds.Location = new System.Drawing.Point(726, 3);
            this.lblReportCreds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReportCreds.Name = "lblReportCreds";
            this.lblReportCreds.Size = new System.Drawing.Size(229, 15);
            this.lblReportCreds.TabIndex = 4;
            this.lblReportCreds.Text = "Username: reports - Password: Reports1";
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnCheckInRoster);
            this.gbAdmin.Controls.Add(this.btnCompetitorsBySchoolReport);
            this.gbAdmin.Controls.Add(this.btnRegForm);
            this.gbAdmin.Controls.Add(this.btnSchoolsOwners);
            this.gbAdmin.Controls.Add(this.btnAllEvents);
            this.gbAdmin.Controls.Add(this.btnDivisionRingNumbers);
            this.gbAdmin.Controls.Add(this.btnWeighInList);
            this.gbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.gbAdmin.Location = new System.Drawing.Point(4, 190);
            this.gbAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Padding = new System.Windows.Forms.Padding(2);
            this.gbAdmin.Size = new System.Drawing.Size(546, 277);
            this.gbAdmin.TabIndex = 5;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "Administrative Reports";
            // 
            // btnCheckInRoster
            // 
            this.btnCheckInRoster.Enabled = false;
            this.btnCheckInRoster.Location = new System.Drawing.Point(274, 26);
            this.btnCheckInRoster.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckInRoster.Name = "btnCheckInRoster";
            this.btnCheckInRoster.Size = new System.Drawing.Size(125, 105);
            this.btnCheckInRoster.TabIndex = 14;
            this.btnCheckInRoster.Text = "Check-In Roster";
            this.btnCheckInRoster.UseVisualStyleBackColor = true;
            this.btnCheckInRoster.Click += new System.EventHandler(this.btnCheckInRoster_Click);
            // 
            // btnCompetitorsBySchoolReport
            // 
            this.btnCompetitorsBySchoolReport.Enabled = false;
            this.btnCompetitorsBySchoolReport.Location = new System.Drawing.Point(367, 156);
            this.btnCompetitorsBySchoolReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompetitorsBySchoolReport.Name = "btnCompetitorsBySchoolReport";
            this.btnCompetitorsBySchoolReport.Size = new System.Drawing.Size(165, 105);
            this.btnCompetitorsBySchoolReport.TabIndex = 13;
            this.btnCompetitorsBySchoolReport.Text = "Competitors By School";
            this.btnCompetitorsBySchoolReport.UseVisualStyleBackColor = true;
            this.btnCompetitorsBySchoolReport.Click += new System.EventHandler(this.btnCompetitorsBySchoolReport_Click);
            // 
            // btnRegForm
            // 
            this.btnRegForm.Location = new System.Drawing.Point(141, 26);
            this.btnRegForm.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegForm.Name = "btnRegForm";
            this.btnRegForm.Size = new System.Drawing.Size(125, 105);
            this.btnRegForm.TabIndex = 12;
            this.btnRegForm.Text = "Competitor Registration Form";
            this.btnRegForm.UseVisualStyleBackColor = true;
            this.btnRegForm.Click += new System.EventHandler(this.btnRegForm_Click);
            // 
            // btnSchoolsOwners
            // 
            this.btnSchoolsOwners.Enabled = false;
            this.btnSchoolsOwners.Location = new System.Drawing.Point(407, 26);
            this.btnSchoolsOwners.Margin = new System.Windows.Forms.Padding(2);
            this.btnSchoolsOwners.Name = "btnSchoolsOwners";
            this.btnSchoolsOwners.Size = new System.Drawing.Size(125, 105);
            this.btnSchoolsOwners.TabIndex = 11;
            this.btnSchoolsOwners.Text = "Schools and Owners";
            this.btnSchoolsOwners.UseVisualStyleBackColor = true;
            this.btnSchoolsOwners.Click += new System.EventHandler(this.btnSchoolsOwners_Click);
            // 
            // btnAllEvents
            // 
            this.btnAllEvents.Enabled = false;
            this.btnAllEvents.Location = new System.Drawing.Point(9, 26);
            this.btnAllEvents.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllEvents.Name = "btnAllEvents";
            this.btnAllEvents.Size = new System.Drawing.Size(125, 105);
            this.btnAllEvents.TabIndex = 10;
            this.btnAllEvents.Text = "All Events";
            this.btnAllEvents.UseVisualStyleBackColor = true;
            this.btnAllEvents.Click += new System.EventHandler(this.btnAllEvents_Click);
            // 
            // btnDivisionRingNumbers
            // 
            this.btnDivisionRingNumbers.Enabled = false;
            this.btnDivisionRingNumbers.Location = new System.Drawing.Point(188, 156);
            this.btnDivisionRingNumbers.Margin = new System.Windows.Forms.Padding(2);
            this.btnDivisionRingNumbers.Name = "btnDivisionRingNumbers";
            this.btnDivisionRingNumbers.Size = new System.Drawing.Size(165, 105);
            this.btnDivisionRingNumbers.TabIndex = 9;
            this.btnDivisionRingNumbers.Text = "Division Ring Numbers";
            this.btnDivisionRingNumbers.UseVisualStyleBackColor = true;
            this.btnDivisionRingNumbers.Click += new System.EventHandler(this.btnDivisionRingNumbers_Click);
            // 
            // btnWeighInList
            // 
            this.btnWeighInList.Enabled = false;
            this.btnWeighInList.Location = new System.Drawing.Point(9, 156);
            this.btnWeighInList.Margin = new System.Windows.Forms.Padding(2);
            this.btnWeighInList.Name = "btnWeighInList";
            this.btnWeighInList.Size = new System.Drawing.Size(165, 105);
            this.btnWeighInList.TabIndex = 8;
            this.btnWeighInList.Text = "Weigh-In List";
            this.btnWeighInList.UseVisualStyleBackColor = true;
            this.btnWeighInList.Click += new System.EventHandler(this.btnWeighInList_Click);
            // 
            // gbEvent
            // 
            this.gbEvent.Controls.Add(this.rtbEventInfo);
            this.gbEvent.Controls.Add(this.btnEventLoadReg);
            this.gbEvent.Controls.Add(this.lblEventTo);
            this.gbEvent.Controls.Add(this.dtpEventTo);
            this.gbEvent.Controls.Add(this.dtpEventFrom);
            this.gbEvent.Controls.Add(this.lblEventFrom);
            this.gbEvent.Controls.Add(this.lblEventSelect);
            this.gbEvent.Controls.Add(this.cbEventSelect);
            this.gbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvent.Location = new System.Drawing.Point(3, 3);
            this.gbEvent.Margin = new System.Windows.Forms.Padding(2);
            this.gbEvent.Name = "gbEvent";
            this.gbEvent.Padding = new System.Windows.Forms.Padding(2);
            this.gbEvent.Size = new System.Drawing.Size(546, 178);
            this.gbEvent.TabIndex = 0;
            this.gbEvent.TabStop = false;
            this.gbEvent.Text = "Select Event";
            // 
            // rtbEventInfo
            // 
            this.rtbEventInfo.Location = new System.Drawing.Point(6, 74);
            this.rtbEventInfo.Name = "rtbEventInfo";
            this.rtbEventInfo.Size = new System.Drawing.Size(378, 96);
            this.rtbEventInfo.TabIndex = 8;
            this.rtbEventInfo.Text = "";
            // 
            // btnEventLoadReg
            // 
            this.btnEventLoadReg.Enabled = false;
            this.btnEventLoadReg.Location = new System.Drawing.Point(389, 46);
            this.btnEventLoadReg.Margin = new System.Windows.Forms.Padding(2);
            this.btnEventLoadReg.Name = "btnEventLoadReg";
            this.btnEventLoadReg.Size = new System.Drawing.Size(144, 126);
            this.btnEventLoadReg.TabIndex = 7;
            this.btnEventLoadReg.Text = "Load new registrations";
            this.btnEventLoadReg.UseVisualStyleBackColor = true;
            this.btnEventLoadReg.Click += new System.EventHandler(this.btnEventLoadReg_Click);
            // 
            // lblEventTo
            // 
            this.lblEventTo.AutoSize = true;
            this.lblEventTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventTo.Location = new System.Drawing.Point(152, 22);
            this.lblEventTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventTo.Name = "lblEventTo";
            this.lblEventTo.Size = new System.Drawing.Size(24, 15);
            this.lblEventTo.TabIndex = 6;
            this.lblEventTo.Text = "To:";
            // 
            // dtpEventTo
            // 
            this.dtpEventTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventTo.Location = new System.Drawing.Point(179, 21);
            this.dtpEventTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEventTo.Name = "dtpEventTo";
            this.dtpEventTo.Size = new System.Drawing.Size(102, 21);
            this.dtpEventTo.TabIndex = 5;
            this.dtpEventTo.ValueChanged += new System.EventHandler(this.dtpEventTo_ValueChanged);
            // 
            // dtpEventFrom
            // 
            this.dtpEventFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventFrom.Location = new System.Drawing.Point(46, 21);
            this.dtpEventFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEventFrom.Name = "dtpEventFrom";
            this.dtpEventFrom.Size = new System.Drawing.Size(102, 21);
            this.dtpEventFrom.TabIndex = 4;
            this.dtpEventFrom.ValueChanged += new System.EventHandler(this.dtpEventFrom_ValueChanged);
            // 
            // lblEventFrom
            // 
            this.lblEventFrom.AutoSize = true;
            this.lblEventFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventFrom.Location = new System.Drawing.Point(3, 24);
            this.lblEventFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventFrom.Name = "lblEventFrom";
            this.lblEventFrom.Size = new System.Drawing.Size(39, 15);
            this.lblEventFrom.TabIndex = 3;
            this.lblEventFrom.Text = "From:";
            // 
            // lblEventSelect
            // 
            this.lblEventSelect.AutoSize = true;
            this.lblEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSelect.Location = new System.Drawing.Point(3, 48);
            this.lblEventSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventSelect.Name = "lblEventSelect";
            this.lblEventSelect.Size = new System.Drawing.Size(77, 15);
            this.lblEventSelect.TabIndex = 1;
            this.lblEventSelect.Text = "Select Event:";
            // 
            // cbEventSelect
            // 
            this.cbEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventSelect.FormattingEnabled = true;
            this.cbEventSelect.Location = new System.Drawing.Point(82, 46);
            this.cbEventSelect.Margin = new System.Windows.Forms.Padding(2);
            this.cbEventSelect.Name = "cbEventSelect";
            this.cbEventSelect.Size = new System.Drawing.Size(296, 23);
            this.cbEventSelect.TabIndex = 0;
            this.cbEventSelect.SelectedIndexChanged += new System.EventHandler(this.cbEventSelect_SelectedIndexChanged);
            // 
            // gbScorecards
            // 
            this.gbScorecards.Controls.Add(this.btnKnockdownSpecial);
            this.gbScorecards.Controls.Add(this.btnSemiKnockdownSpecial);
            this.gbScorecards.Controls.Add(this.btnWeaponKataSpecial);
            this.gbScorecards.Controls.Add(this.btnKataSpecial);
            this.gbScorecards.Controls.Add(this.btnKnockdown);
            this.gbScorecards.Controls.Add(this.btnSemiKnockdown);
            this.gbScorecards.Controls.Add(this.btnWeaponKata);
            this.gbScorecards.Controls.Add(this.btnKata);
            this.gbScorecards.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.gbScorecards.Location = new System.Drawing.Point(564, 51);
            this.gbScorecards.Margin = new System.Windows.Forms.Padding(2);
            this.gbScorecards.Name = "gbScorecards";
            this.gbScorecards.Padding = new System.Windows.Forms.Padding(2);
            this.gbScorecards.Size = new System.Drawing.Size(550, 415);
            this.gbScorecards.TabIndex = 0;
            this.gbScorecards.TabStop = false;
            this.gbScorecards.Text = "Scorecards";
            // 
            // btnKnockdownSpecial
            // 
            this.btnKnockdownSpecial.Enabled = false;
            this.btnKnockdownSpecial.Location = new System.Drawing.Point(289, 329);
            this.btnKnockdownSpecial.Margin = new System.Windows.Forms.Padding(2);
            this.btnKnockdownSpecial.Name = "btnKnockdownSpecial";
            this.btnKnockdownSpecial.Size = new System.Drawing.Size(166, 125);
            this.btnKnockdownSpecial.TabIndex = 7;
            this.btnKnockdownSpecial.Text = "Knockdown - Special Consideration";
            this.btnKnockdownSpecial.UseVisualStyleBackColor = true;
            this.btnKnockdownSpecial.Click += new System.EventHandler(this.btnKnockdownSpecial_Click);
            // 
            // btnSemiKnockdownSpecial
            // 
            this.btnSemiKnockdownSpecial.Enabled = false;
            this.btnSemiKnockdownSpecial.Location = new System.Drawing.Point(88, 329);
            this.btnSemiKnockdownSpecial.Margin = new System.Windows.Forms.Padding(2);
            this.btnSemiKnockdownSpecial.Name = "btnSemiKnockdownSpecial";
            this.btnSemiKnockdownSpecial.Size = new System.Drawing.Size(166, 125);
            this.btnSemiKnockdownSpecial.TabIndex = 6;
            this.btnSemiKnockdownSpecial.Text = "Semi-Knockdown - Special Consideration";
            this.btnSemiKnockdownSpecial.UseVisualStyleBackColor = true;
            this.btnSemiKnockdownSpecial.Click += new System.EventHandler(this.btnSemiKnockdownSpecial_Click);
            // 
            // btnWeaponKataSpecial
            // 
            this.btnWeaponKataSpecial.Enabled = false;
            this.btnWeaponKataSpecial.Location = new System.Drawing.Point(374, 187);
            this.btnWeaponKataSpecial.Margin = new System.Windows.Forms.Padding(2);
            this.btnWeaponKataSpecial.Name = "btnWeaponKataSpecial";
            this.btnWeaponKataSpecial.Size = new System.Drawing.Size(166, 125);
            this.btnWeaponKataSpecial.TabIndex = 5;
            this.btnWeaponKataSpecial.Text = "Weapon Kata - Special Consideration";
            this.btnWeaponKataSpecial.UseVisualStyleBackColor = true;
            this.btnWeaponKataSpecial.Click += new System.EventHandler(this.btnWeaponKataSpecial_Click);
            // 
            // btnKataSpecial
            // 
            this.btnKataSpecial.Enabled = false;
            this.btnKataSpecial.Location = new System.Drawing.Point(374, 40);
            this.btnKataSpecial.Margin = new System.Windows.Forms.Padding(2);
            this.btnKataSpecial.Name = "btnKataSpecial";
            this.btnKataSpecial.Size = new System.Drawing.Size(166, 125);
            this.btnKataSpecial.TabIndex = 4;
            this.btnKataSpecial.Text = "Kata - Special Consideration";
            this.btnKataSpecial.UseVisualStyleBackColor = true;
            this.btnKataSpecial.Click += new System.EventHandler(this.btnKataSpecial_Click);
            // 
            // btnKnockdown
            // 
            this.btnKnockdown.Enabled = false;
            this.btnKnockdown.Location = new System.Drawing.Point(193, 187);
            this.btnKnockdown.Margin = new System.Windows.Forms.Padding(2);
            this.btnKnockdown.Name = "btnKnockdown";
            this.btnKnockdown.Size = new System.Drawing.Size(166, 125);
            this.btnKnockdown.TabIndex = 3;
            this.btnKnockdown.Text = "Knockdown";
            this.btnKnockdown.UseVisualStyleBackColor = true;
            this.btnKnockdown.Click += new System.EventHandler(this.btnKnockdown_Click);
            // 
            // btnSemiKnockdown
            // 
            this.btnSemiKnockdown.Enabled = false;
            this.btnSemiKnockdown.Location = new System.Drawing.Point(8, 187);
            this.btnSemiKnockdown.Margin = new System.Windows.Forms.Padding(2);
            this.btnSemiKnockdown.Name = "btnSemiKnockdown";
            this.btnSemiKnockdown.Size = new System.Drawing.Size(166, 125);
            this.btnSemiKnockdown.TabIndex = 2;
            this.btnSemiKnockdown.Text = "Semi-Knockdown";
            this.btnSemiKnockdown.UseVisualStyleBackColor = true;
            this.btnSemiKnockdown.Click += new System.EventHandler(this.btnSemiKnockdown_Click);
            // 
            // btnWeaponKata
            // 
            this.btnWeaponKata.Enabled = false;
            this.btnWeaponKata.Location = new System.Drawing.Point(193, 40);
            this.btnWeaponKata.Margin = new System.Windows.Forms.Padding(2);
            this.btnWeaponKata.Name = "btnWeaponKata";
            this.btnWeaponKata.Size = new System.Drawing.Size(166, 125);
            this.btnWeaponKata.TabIndex = 1;
            this.btnWeaponKata.Text = "Weapon Kata";
            this.btnWeaponKata.UseVisualStyleBackColor = true;
            this.btnWeaponKata.Click += new System.EventHandler(this.btnWeaponKata_Click);
            // 
            // btnKata
            // 
            this.btnKata.Enabled = false;
            this.btnKata.Location = new System.Drawing.Point(8, 40);
            this.btnKata.Margin = new System.Windows.Forms.Padding(2);
            this.btnKata.Name = "btnKata";
            this.btnKata.Size = new System.Drawing.Size(166, 125);
            this.btnKata.TabIndex = 0;
            this.btnKata.Text = "Kata";
            this.btnKata.UseVisualStyleBackColor = true;
            this.btnKata.Click += new System.EventHandler(this.btnKata_Click);
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.gbEventDetails);
            this.tabEvents.Controls.Add(this.gbEvents);
            this.tabEvents.Location = new System.Drawing.Point(4, 22);
            this.tabEvents.Margin = new System.Windows.Forms.Padding(2);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(2);
            this.tabEvents.Size = new System.Drawing.Size(1120, 468);
            this.tabEvents.TabIndex = 2;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // gbEventDetails
            // 
            this.gbEventDetails.Controls.Add(this.dtpEventDate);
            this.gbEventDetails.Controls.Add(this.cbEventType);
            this.gbEventDetails.Controls.Add(this.txtEventName);
            this.gbEventDetails.Controls.Add(this.lblEventDate);
            this.gbEventDetails.Controls.Add(this.lblEventType);
            this.gbEventDetails.Controls.Add(this.lblEventName);
            this.gbEventDetails.Controls.Add(this.btnDeleteEvent);
            this.gbEventDetails.Controls.Add(this.btnClearEventSelection);
            this.gbEventDetails.Controls.Add(this.btnNewEvent);
            this.gbEventDetails.Controls.Add(this.btnSaveEvent);
            this.gbEventDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEventDetails.Location = new System.Drawing.Point(498, 6);
            this.gbEventDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbEventDetails.Name = "gbEventDetails";
            this.gbEventDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbEventDetails.Size = new System.Drawing.Size(610, 456);
            this.gbEventDetails.TabIndex = 7;
            this.gbEventDetails.TabStop = false;
            this.gbEventDetails.Text = "Event Details";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(242, 236);
            this.dtpEventDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(240, 24);
            this.dtpEventDate.TabIndex = 11;
            // 
            // cbEventType
            // 
            this.cbEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventType.FormattingEnabled = true;
            this.cbEventType.Location = new System.Drawing.Point(242, 188);
            this.cbEventType.Margin = new System.Windows.Forms.Padding(2);
            this.cbEventType.Name = "cbEventType";
            this.cbEventType.Size = new System.Drawing.Size(240, 25);
            this.cbEventType.TabIndex = 10;
            // 
            // txtEventName
            // 
            this.txtEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventName.Location = new System.Drawing.Point(242, 138);
            this.txtEventName.Margin = new System.Windows.Forms.Padding(2);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(240, 24);
            this.txtEventName.TabIndex = 9;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDate.Location = new System.Drawing.Point(114, 239);
            this.lblEventDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(39, 18);
            this.lblEventDate.TabIndex = 8;
            this.lblEventDate.Text = "Date";
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventType.Location = new System.Drawing.Point(114, 189);
            this.lblEventType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(81, 18);
            this.lblEventType.TabIndex = 7;
            this.lblEventType.Text = "Event Type";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(114, 140);
            this.lblEventName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(89, 18);
            this.lblEventName.TabIndex = 6;
            this.lblEventName.Text = "Event Name";
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(318, 399);
            this.btnDeleteEvent.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(125, 35);
            this.btnDeleteEvent.TabIndex = 5;
            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnClearEventSelection
            // 
            this.btnClearEventSelection.Location = new System.Drawing.Point(444, 399);
            this.btnClearEventSelection.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearEventSelection.Name = "btnClearEventSelection";
            this.btnClearEventSelection.Size = new System.Drawing.Size(125, 35);
            this.btnClearEventSelection.TabIndex = 4;
            this.btnClearEventSelection.Text = "Clear Selection";
            this.btnClearEventSelection.UseVisualStyleBackColor = true;
            this.btnClearEventSelection.Click += new System.EventHandler(this.btnClearEventSelection_Click);
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.Location = new System.Drawing.Point(188, 399);
            this.btnNewEvent.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(125, 35);
            this.btnNewEvent.TabIndex = 3;
            this.btnNewEvent.Text = "Save as New";
            this.btnNewEvent.UseVisualStyleBackColor = true;
            this.btnNewEvent.Click += new System.EventHandler(this.btnNewEvent_Click);
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(60, 399);
            this.btnSaveEvent.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(125, 35);
            this.btnSaveEvent.TabIndex = 2;
            this.btnSaveEvent.Text = "Save Changes";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // gbEvents
            // 
            this.gbEvents.Controls.Add(this.tlvEvents);
            this.gbEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvents.Location = new System.Drawing.Point(12, 6);
            this.gbEvents.Margin = new System.Windows.Forms.Padding(2);
            this.gbEvents.Name = "gbEvents";
            this.gbEvents.Padding = new System.Windows.Forms.Padding(2);
            this.gbEvents.Size = new System.Drawing.Size(467, 458);
            this.gbEvents.TabIndex = 6;
            this.gbEvents.TabStop = false;
            this.gbEvents.Text = "Events";
            // 
            // tlvEvents
            // 
            this.tlvEvents.AllColumns.Add(this.olvColEventId);
            this.tlvEvents.AllColumns.Add(this.olvColEventName);
            this.tlvEvents.AllColumns.Add(this.olvColEventDateText);
            this.tlvEvents.AllColumns.Add(this.olvColEventType);
            this.tlvEvents.AllColumns.Add(this.olvColEventDate);
            this.tlvEvents.CellEditUseWholeCell = false;
            this.tlvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColEventId,
            this.olvColEventName,
            this.olvColEventDateText,
            this.olvColEventType});
            this.tlvEvents.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvEvents.HideSelection = false;
            this.tlvEvents.IsSimpleDragSource = true;
            this.tlvEvents.Location = new System.Drawing.Point(3, 28);
            this.tlvEvents.Margin = new System.Windows.Forms.Padding(2);
            this.tlvEvents.Name = "tlvEvents";
            this.tlvEvents.ShowGroups = false;
            this.tlvEvents.Size = new System.Drawing.Size(458, 426);
            this.tlvEvents.SmallImageList = this.imgList;
            this.tlvEvents.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvEvents.TabIndex = 11;
            this.tlvEvents.UseCompatibleStateImageBehavior = false;
            this.tlvEvents.View = System.Windows.Forms.View.Details;
            this.tlvEvents.VirtualMode = true;
            this.tlvEvents.SelectedIndexChanged += new System.EventHandler(this.tlvEvents_SelectedIndexChanged);
            // 
            // olvColEventId
            // 
            this.olvColEventId.AspectName = "EventId";
            this.olvColEventId.Text = "Id";
            this.olvColEventId.Width = 45;
            // 
            // olvColEventName
            // 
            this.olvColEventName.AspectName = "EventName";
            this.olvColEventName.Text = "Name";
            this.olvColEventName.Width = 130;
            // 
            // olvColEventDateText
            // 
            this.olvColEventDateText.AspectName = "DateText";
            this.olvColEventDateText.Text = "Date";
            this.olvColEventDateText.Width = 100;
            // 
            // olvColEventType
            // 
            this.olvColEventType.AspectName = "EventTypeName";
            this.olvColEventType.Text = "Type";
            this.olvColEventType.Width = 90;
            // 
            // olvColEventDate
            // 
            this.olvColEventDate.AspectName = "Date";
            this.olvColEventDate.IsVisible = false;
            this.olvColEventDate.Text = "Date";
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.lblLoading);
            this.tabMatch.Controls.Add(this.gbMatches);
            this.tabMatch.Controls.Add(this.gbMatchCompetitors);
            this.tabMatch.Controls.Add(this.lblDragAndDrop);
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Margin = new System.Windows.Forms.Padding(2);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(2);
            this.tabMatch.Size = new System.Drawing.Size(1120, 468);
            this.tabMatch.TabIndex = 1;
            this.tabMatch.Text = "Matches";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(368, 205);
            this.lblLoading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(316, 73);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // gbMatches
            // 
            this.gbMatches.Controls.Add(this.btnMatchApply);
            this.gbMatches.Controls.Add(this.tlvMatches);
            this.gbMatches.Controls.Add(this.cbMatchFilterBy);
            this.gbMatches.Controls.Add(this.rbApplicableMatches);
            this.gbMatches.Controls.Add(this.lblMatchFilterBy);
            this.gbMatches.Controls.Add(this.txtMatchFilter);
            this.gbMatches.Controls.Add(this.rbAll);
            this.gbMatches.Controls.Add(this.lblMatchFilter);
            this.gbMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMatches.Location = new System.Drawing.Point(554, 2);
            this.gbMatches.Margin = new System.Windows.Forms.Padding(2);
            this.gbMatches.Name = "gbMatches";
            this.gbMatches.Padding = new System.Windows.Forms.Padding(2);
            this.gbMatches.Size = new System.Drawing.Size(564, 458);
            this.gbMatches.TabIndex = 4;
            this.gbMatches.TabStop = false;
            this.gbMatches.Text = "Matches";
            // 
            // btnMatchApply
            // 
            this.btnMatchApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchApply.Location = new System.Drawing.Point(476, 48);
            this.btnMatchApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnMatchApply.Name = "btnMatchApply";
            this.btnMatchApply.Size = new System.Drawing.Size(66, 25);
            this.btnMatchApply.TabIndex = 13;
            this.btnMatchApply.Text = "Apply";
            this.btnMatchApply.UseVisualStyleBackColor = true;
            this.btnMatchApply.Click += new System.EventHandler(this.btnMatchApply_Click);
            // 
            // tlvMatches
            // 
            this.tlvMatches.AllColumns.Add(this.olvColDivDisplay);
            this.tlvMatches.AllColumns.Add(this.olvColMatchType);
            this.tlvMatches.AllColumns.Add(this.olvColDisplayName);
            this.tlvMatches.AllColumns.Add(this.olvColRankName);
            this.tlvMatches.AllColumns.Add(this.olvColAge);
            this.tlvMatches.AllColumns.Add(this.olvColWeight);
            this.tlvMatches.AllColumns.Add(this.olvColDojo);
            this.tlvMatches.AllColumns.Add(this.olvColHeight);
            this.tlvMatches.CellEditUseWholeCell = false;
            this.tlvMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDivDisplay,
            this.olvColMatchType,
            this.olvColDisplayName,
            this.olvColRankName,
            this.olvColAge,
            this.olvColWeight,
            this.olvColDojo,
            this.olvColHeight});
            this.tlvMatches.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvMatches.HideSelection = false;
            this.tlvMatches.IsSimpleDropSink = true;
            this.tlvMatches.Location = new System.Drawing.Point(4, 80);
            this.tlvMatches.Margin = new System.Windows.Forms.Padding(2);
            this.tlvMatches.Name = "tlvMatches";
            this.tlvMatches.ShowGroups = false;
            this.tlvMatches.Size = new System.Drawing.Size(559, 378);
            this.tlvMatches.SmallImageList = this.imgList;
            this.tlvMatches.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvMatches.TabIndex = 10;
            this.tlvMatches.UseCompatibleStateImageBehavior = false;
            this.tlvMatches.View = System.Windows.Forms.View.Details;
            this.tlvMatches.VirtualMode = true;
            this.tlvMatches.ModelCanDrop += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.tlvMatches_ModelCanDrop);
            this.tlvMatches.ModelDropped += new System.EventHandler<BrightIdeasSoftware.ModelDropEventArgs>(this.tlvMatches_ModelDropped);
            // 
            // olvColDivDisplay
            // 
            this.olvColDivDisplay.AspectName = "MatchDisplayName";
            this.olvColDivDisplay.Text = "Div-SubDiv";
            this.olvColDivDisplay.Width = 80;
            // 
            // olvColMatchType
            // 
            this.olvColMatchType.AspectName = "MatchTypeName";
            this.olvColMatchType.Text = "Type";
            this.olvColMatchType.Width = 100;
            // 
            // olvColDisplayName
            // 
            this.olvColDisplayName.AspectName = "DisplayName";
            this.olvColDisplayName.Text = "Name";
            this.olvColDisplayName.Width = 110;
            // 
            // olvColRankName
            // 
            this.olvColRankName.AspectName = "RankName";
            this.olvColRankName.Text = "Belt";
            this.olvColRankName.Width = 80;
            // 
            // olvColAge
            // 
            this.olvColAge.AspectName = "Age";
            this.olvColAge.Text = "Age";
            this.olvColAge.Width = 45;
            // 
            // olvColWeight
            // 
            this.olvColWeight.AspectName = "Weight";
            this.olvColWeight.Text = "Weight (lb)";
            this.olvColWeight.Width = 75;
            // 
            // olvColDojo
            // 
            this.olvColDojo.AspectName = "DojoName";
            this.olvColDojo.DisplayIndex = 7;
            this.olvColDojo.Text = "School";
            this.olvColDojo.Width = 120;
            // 
            // olvColHeight
            // 
            this.olvColHeight.AspectName = "Height";
            this.olvColHeight.DisplayIndex = 6;
            this.olvColHeight.Text = "Height (in)";
            // 
            // cbMatchFilterBy
            // 
            this.cbMatchFilterBy.FormattingEnabled = true;
            this.cbMatchFilterBy.Location = new System.Drawing.Point(277, 50);
            this.cbMatchFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbMatchFilterBy.Name = "cbMatchFilterBy";
            this.cbMatchFilterBy.Size = new System.Drawing.Size(176, 25);
            this.cbMatchFilterBy.TabIndex = 8;
            // 
            // rbApplicableMatches
            // 
            this.rbApplicableMatches.AutoSize = true;
            this.rbApplicableMatches.Enabled = false;
            this.rbApplicableMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApplicableMatches.Location = new System.Drawing.Point(10, 46);
            this.rbApplicableMatches.Margin = new System.Windows.Forms.Padding(2);
            this.rbApplicableMatches.Name = "rbApplicableMatches";
            this.rbApplicableMatches.Size = new System.Drawing.Size(82, 34);
            this.rbApplicableMatches.TabIndex = 9;
            this.rbApplicableMatches.Text = "Applicable\r\nMatches";
            this.rbApplicableMatches.UseVisualStyleBackColor = true;
            this.rbApplicableMatches.CheckedChanged += new System.EventHandler(this.rbApplicableMatches_CheckedChanged);
            // 
            // lblMatchFilterBy
            // 
            this.lblMatchFilterBy.AutoSize = true;
            this.lblMatchFilterBy.Location = new System.Drawing.Point(277, 28);
            this.lblMatchFilterBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatchFilterBy.Name = "lblMatchFilterBy";
            this.lblMatchFilterBy.Size = new System.Drawing.Size(63, 18);
            this.lblMatchFilterBy.TabIndex = 7;
            this.lblMatchFilterBy.Text = "Filter by:";
            // 
            // txtMatchFilter
            // 
            this.txtMatchFilter.Location = new System.Drawing.Point(110, 50);
            this.txtMatchFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatchFilter.Name = "txtMatchFilter";
            this.txtMatchFilter.Size = new System.Drawing.Size(145, 24);
            this.txtMatchFilter.TabIndex = 6;
            this.txtMatchFilter.TextChanged += new System.EventHandler(this.txtMatchFilter_TextChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Enabled = false;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.Location = new System.Drawing.Point(10, 28);
            this.rbAll.Margin = new System.Windows.Forms.Padding(2);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(88, 19);
            this.rbAll.TabIndex = 8;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Matches";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // lblMatchFilter
            // 
            this.lblMatchFilter.AutoSize = true;
            this.lblMatchFilter.Location = new System.Drawing.Point(106, 28);
            this.lblMatchFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatchFilter.Name = "lblMatchFilter";
            this.lblMatchFilter.Size = new System.Drawing.Size(44, 18);
            this.lblMatchFilter.TabIndex = 5;
            this.lblMatchFilter.Text = "Filter:";
            // 
            // gbMatchCompetitors
            // 
            this.gbMatchCompetitors.Controls.Add(this.btnCompetitorApply);
            this.gbMatchCompetitors.Controls.Add(this.tlvCompetitors);
            this.gbMatchCompetitors.Controls.Add(this.cbCompetitorFilterBy);
            this.gbMatchCompetitors.Controls.Add(this.lblCompetitorFilterBy);
            this.gbMatchCompetitors.Controls.Add(this.txtCompetitorFilter);
            this.gbMatchCompetitors.Controls.Add(this.lblCompetitorFilter);
            this.gbMatchCompetitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMatchCompetitors.Location = new System.Drawing.Point(12, 3);
            this.gbMatchCompetitors.Margin = new System.Windows.Forms.Padding(2);
            this.gbMatchCompetitors.Name = "gbMatchCompetitors";
            this.gbMatchCompetitors.Padding = new System.Windows.Forms.Padding(2);
            this.gbMatchCompetitors.Size = new System.Drawing.Size(467, 458);
            this.gbMatchCompetitors.TabIndex = 3;
            this.gbMatchCompetitors.TabStop = false;
            this.gbMatchCompetitors.Text = "Competitors";
            // 
            // btnCompetitorApply
            // 
            this.btnCompetitorApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompetitorApply.Location = new System.Drawing.Point(392, 48);
            this.btnCompetitorApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompetitorApply.Name = "btnCompetitorApply";
            this.btnCompetitorApply.Size = new System.Drawing.Size(66, 25);
            this.btnCompetitorApply.TabIndex = 12;
            this.btnCompetitorApply.Text = "Apply";
            this.btnCompetitorApply.UseVisualStyleBackColor = true;
            this.btnCompetitorApply.Click += new System.EventHandler(this.btnCompetitorApply_Click);
            // 
            // tlvCompetitors
            // 
            this.tlvCompetitors.AllColumns.Add(this.olvColCompDisplayName);
            this.tlvCompetitors.AllColumns.Add(this.olvColCompRankName);
            this.tlvCompetitors.AllColumns.Add(this.olvColCompAge);
            this.tlvCompetitors.AllColumns.Add(this.olvColCompWeight);
            this.tlvCompetitors.AllColumns.Add(this.olvMatchCompHeight);
            this.tlvCompetitors.CellEditUseWholeCell = false;
            this.tlvCompetitors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColCompDisplayName,
            this.olvColCompRankName,
            this.olvColCompAge,
            this.olvColCompWeight,
            this.olvMatchCompHeight});
            this.tlvCompetitors.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvCompetitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvCompetitors.HideSelection = false;
            this.tlvCompetitors.IsSimpleDragSource = true;
            this.tlvCompetitors.Location = new System.Drawing.Point(3, 80);
            this.tlvCompetitors.Margin = new System.Windows.Forms.Padding(2);
            this.tlvCompetitors.Name = "tlvCompetitors";
            this.tlvCompetitors.ShowGroups = false;
            this.tlvCompetitors.Size = new System.Drawing.Size(458, 376);
            this.tlvCompetitors.SmallImageList = this.imgList;
            this.tlvCompetitors.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvCompetitors.TabIndex = 11;
            this.tlvCompetitors.UseCompatibleStateImageBehavior = false;
            this.tlvCompetitors.View = System.Windows.Forms.View.Details;
            this.tlvCompetitors.VirtualMode = true;
            this.tlvCompetitors.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tlvCompetitors_ItemDrag);
            this.tlvCompetitors.SelectedIndexChanged += new System.EventHandler(this.tlvCompetitors_SelectedIndexChanged);
            // 
            // olvColCompDisplayName
            // 
            this.olvColCompDisplayName.AspectName = "DisplayName";
            this.olvColCompDisplayName.Text = "Name";
            this.olvColCompDisplayName.Width = 140;
            // 
            // olvColCompRankName
            // 
            this.olvColCompRankName.AspectName = "RankName";
            this.olvColCompRankName.Text = "Belt";
            this.olvColCompRankName.Width = 85;
            // 
            // olvColCompAge
            // 
            this.olvColCompAge.AspectName = "Age";
            this.olvColCompAge.Text = "Age";
            this.olvColCompAge.Width = 76;
            // 
            // olvColCompWeight
            // 
            this.olvColCompWeight.AspectName = "Weight";
            this.olvColCompWeight.Text = "Weight (lb)";
            this.olvColCompWeight.Width = 111;
            // 
            // olvMatchCompHeight
            // 
            this.olvMatchCompHeight.AspectName = "Height";
            this.olvMatchCompHeight.Text = "Height (in)";
            // 
            // cbCompetitorFilterBy
            // 
            this.cbCompetitorFilterBy.FormattingEnabled = true;
            this.cbCompetitorFilterBy.Location = new System.Drawing.Point(206, 50);
            this.cbCompetitorFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbCompetitorFilterBy.Name = "cbCompetitorFilterBy";
            this.cbCompetitorFilterBy.Size = new System.Drawing.Size(177, 25);
            this.cbCompetitorFilterBy.TabIndex = 4;
            // 
            // lblCompetitorFilterBy
            // 
            this.lblCompetitorFilterBy.AutoSize = true;
            this.lblCompetitorFilterBy.Location = new System.Drawing.Point(204, 28);
            this.lblCompetitorFilterBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompetitorFilterBy.Name = "lblCompetitorFilterBy";
            this.lblCompetitorFilterBy.Size = new System.Drawing.Size(63, 18);
            this.lblCompetitorFilterBy.TabIndex = 3;
            this.lblCompetitorFilterBy.Text = "Filter by:";
            // 
            // txtCompetitorFilter
            // 
            this.txtCompetitorFilter.Location = new System.Drawing.Point(12, 50);
            this.txtCompetitorFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompetitorFilter.Name = "txtCompetitorFilter";
            this.txtCompetitorFilter.Size = new System.Drawing.Size(183, 24);
            this.txtCompetitorFilter.TabIndex = 2;
            this.txtCompetitorFilter.TextChanged += new System.EventHandler(this.txtCompetitorFilter_TextChanged);
            // 
            // lblCompetitorFilter
            // 
            this.lblCompetitorFilter.AutoSize = true;
            this.lblCompetitorFilter.Location = new System.Drawing.Point(9, 28);
            this.lblCompetitorFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompetitorFilter.Name = "lblCompetitorFilter";
            this.lblCompetitorFilter.Size = new System.Drawing.Size(44, 18);
            this.lblCompetitorFilter.TabIndex = 1;
            this.lblCompetitorFilter.Text = "Filter:";
            // 
            // lblDragAndDrop
            // 
            this.lblDragAndDrop.AutoSize = true;
            this.lblDragAndDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDragAndDrop.Location = new System.Drawing.Point(492, 163);
            this.lblDragAndDrop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDragAndDrop.Name = "lblDragAndDrop";
            this.lblDragAndDrop.Size = new System.Drawing.Size(51, 216);
            this.lblDragAndDrop.TabIndex = 2;
            this.lblDragAndDrop.Text = ">\r\n\r\nDrag\r\n\r\nand\r\n\r\nDrop\r\n\r\n>";
            this.lblDragAndDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabCompetitor
            // 
            this.tabCompetitor.Controls.Add(this.lblConnection);
            this.tabCompetitor.Controls.Add(this.lblCompLoading);
            this.tabCompetitor.Controls.Add(this.gbCompetitorDetails);
            this.tabCompetitor.Controls.Add(this.gbComp);
            this.tabCompetitor.Location = new System.Drawing.Point(4, 22);
            this.tabCompetitor.Margin = new System.Windows.Forms.Padding(2);
            this.tabCompetitor.Name = "tabCompetitor";
            this.tabCompetitor.Padding = new System.Windows.Forms.Padding(2);
            this.tabCompetitor.Size = new System.Drawing.Size(1120, 468);
            this.tabCompetitor.TabIndex = 3;
            this.tabCompetitor.Text = "Competitors";
            this.tabCompetitor.UseVisualStyleBackColor = true;
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(144, 216);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(872, 55);
            this.lblConnection.TabIndex = 9;
            this.lblConnection.Text = "Attempting to connect to the database...";
            // 
            // lblCompLoading
            // 
            this.lblCompLoading.AutoSize = true;
            this.lblCompLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompLoading.Location = new System.Drawing.Point(404, 196);
            this.lblCompLoading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompLoading.Name = "lblCompLoading";
            this.lblCompLoading.Size = new System.Drawing.Size(316, 73);
            this.lblCompLoading.TabIndex = 6;
            this.lblCompLoading.Text = "Loading...";
            this.lblCompLoading.Visible = false;
            // 
            // gbCompetitorDetails
            // 
            this.gbCompetitorDetails.Controls.Add(this.dgvCompetitorDetails);
            this.gbCompetitorDetails.Controls.Add(this.btnCompDelete);
            this.gbCompetitorDetails.Controls.Add(this.btnCompClear);
            this.gbCompetitorDetails.Controls.Add(this.btnNewComp);
            this.gbCompetitorDetails.Controls.Add(this.btnSaveComp);
            this.gbCompetitorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCompetitorDetails.Location = new System.Drawing.Point(496, 4);
            this.gbCompetitorDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbCompetitorDetails.Name = "gbCompetitorDetails";
            this.gbCompetitorDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbCompetitorDetails.Size = new System.Drawing.Size(610, 456);
            this.gbCompetitorDetails.TabIndex = 5;
            this.gbCompetitorDetails.TabStop = false;
            this.gbCompetitorDetails.Text = "Competitor Details";
            // 
            // dgvCompetitorDetails
            // 
            this.dgvCompetitorDetails.AllowUserToAddRows = false;
            this.dgvCompetitorDetails.AllowUserToDeleteRows = false;
            this.dgvCompetitorDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetitorDetails.Location = new System.Drawing.Point(14, 28);
            this.dgvCompetitorDetails.Name = "dgvCompetitorDetails";
            this.dgvCompetitorDetails.Size = new System.Drawing.Size(584, 353);
            this.dgvCompetitorDetails.TabIndex = 6;
            this.dgvCompetitorDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompetitorDetails_CellContentClick);
            // 
            // btnCompDelete
            // 
            this.btnCompDelete.Location = new System.Drawing.Point(277, 399);
            this.btnCompDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompDelete.Name = "btnCompDelete";
            this.btnCompDelete.Size = new System.Drawing.Size(146, 35);
            this.btnCompDelete.TabIndex = 5;
            this.btnCompDelete.Text = "Delete Competitor";
            this.btnCompDelete.UseVisualStyleBackColor = true;
            this.btnCompDelete.Click += new System.EventHandler(this.btnCompDelete_Click);
            // 
            // btnCompClear
            // 
            this.btnCompClear.Location = new System.Drawing.Point(444, 399);
            this.btnCompClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompClear.Name = "btnCompClear";
            this.btnCompClear.Size = new System.Drawing.Size(154, 35);
            this.btnCompClear.TabIndex = 4;
            this.btnCompClear.Text = "Clear Selection";
            this.btnCompClear.UseVisualStyleBackColor = true;
            this.btnCompClear.Click += new System.EventHandler(this.btnCompClear_Click);
            // 
            // btnNewComp
            // 
            this.btnNewComp.Location = new System.Drawing.Point(148, 399);
            this.btnNewComp.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewComp.Name = "btnNewComp";
            this.btnNewComp.Size = new System.Drawing.Size(114, 35);
            this.btnNewComp.TabIndex = 3;
            this.btnNewComp.Text = "Save as New";
            this.btnNewComp.UseVisualStyleBackColor = true;
            this.btnNewComp.Click += new System.EventHandler(this.btnNewComp_Click);
            // 
            // btnSaveComp
            // 
            this.btnSaveComp.Location = new System.Drawing.Point(14, 399);
            this.btnSaveComp.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveComp.Name = "btnSaveComp";
            this.btnSaveComp.Size = new System.Drawing.Size(118, 35);
            this.btnSaveComp.TabIndex = 2;
            this.btnSaveComp.Text = "Save Changes";
            this.btnSaveComp.UseVisualStyleBackColor = true;
            this.btnSaveComp.Click += new System.EventHandler(this.btnSaveComp_Click);
            // 
            // gbComp
            // 
            this.gbComp.Controls.Add(this.btnCompFilterApply);
            this.gbComp.Controls.Add(this.tlvComp);
            this.gbComp.Controls.Add(this.cbCompFilterBy);
            this.gbComp.Controls.Add(this.lblCompFilterBy);
            this.gbComp.Controls.Add(this.txtCompFilter);
            this.gbComp.Controls.Add(this.lblCompFilter);
            this.gbComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComp.Location = new System.Drawing.Point(10, 4);
            this.gbComp.Margin = new System.Windows.Forms.Padding(2);
            this.gbComp.Name = "gbComp";
            this.gbComp.Padding = new System.Windows.Forms.Padding(2);
            this.gbComp.Size = new System.Drawing.Size(467, 458);
            this.gbComp.TabIndex = 4;
            this.gbComp.TabStop = false;
            this.gbComp.Text = "Competitors";
            // 
            // btnCompFilterApply
            // 
            this.btnCompFilterApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompFilterApply.Location = new System.Drawing.Point(392, 48);
            this.btnCompFilterApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompFilterApply.Name = "btnCompFilterApply";
            this.btnCompFilterApply.Size = new System.Drawing.Size(66, 25);
            this.btnCompFilterApply.TabIndex = 12;
            this.btnCompFilterApply.Text = "Apply";
            this.btnCompFilterApply.UseVisualStyleBackColor = true;
            this.btnCompFilterApply.Click += new System.EventHandler(this.btnCompFilterApply_Click);
            // 
            // tlvComp
            // 
            this.tlvComp.AllColumns.Add(this.olvColumn1);
            this.tlvComp.AllColumns.Add(this.olvColumn2);
            this.tlvComp.AllColumns.Add(this.olvColumn3);
            this.tlvComp.AllColumns.Add(this.olvColumn4);
            this.tlvComp.AllColumns.Add(this.olvColCompHeight);
            this.tlvComp.CellEditUseWholeCell = false;
            this.tlvComp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColCompHeight});
            this.tlvComp.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvComp.HideSelection = false;
            this.tlvComp.IsSimpleDragSource = true;
            this.tlvComp.Location = new System.Drawing.Point(3, 76);
            this.tlvComp.Margin = new System.Windows.Forms.Padding(2);
            this.tlvComp.Name = "tlvComp";
            this.tlvComp.ShowGroups = false;
            this.tlvComp.Size = new System.Drawing.Size(458, 378);
            this.tlvComp.SmallImageList = this.imgList;
            this.tlvComp.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvComp.TabIndex = 11;
            this.tlvComp.UseCompatibleStateImageBehavior = false;
            this.tlvComp.View = System.Windows.Forms.View.Details;
            this.tlvComp.VirtualMode = true;
            this.tlvComp.SelectedIndexChanged += new System.EventHandler(this.tlvComp_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "DisplayName";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 140;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "RankName";
            this.olvColumn2.Text = "Belt";
            this.olvColumn2.Width = 85;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Age";
            this.olvColumn3.Text = "Age";
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Weight";
            this.olvColumn4.Text = "Weight (lb)";
            this.olvColumn4.Width = 90;
            // 
            // olvColCompHeight
            // 
            this.olvColCompHeight.AspectName = "Height";
            this.olvColCompHeight.Text = "Height (in)";
            this.olvColCompHeight.Width = 80;
            // 
            // cbCompFilterBy
            // 
            this.cbCompFilterBy.FormattingEnabled = true;
            this.cbCompFilterBy.Location = new System.Drawing.Point(206, 50);
            this.cbCompFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbCompFilterBy.Name = "cbCompFilterBy";
            this.cbCompFilterBy.Size = new System.Drawing.Size(177, 25);
            this.cbCompFilterBy.TabIndex = 4;
            // 
            // lblCompFilterBy
            // 
            this.lblCompFilterBy.AutoSize = true;
            this.lblCompFilterBy.Location = new System.Drawing.Point(204, 28);
            this.lblCompFilterBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompFilterBy.Name = "lblCompFilterBy";
            this.lblCompFilterBy.Size = new System.Drawing.Size(63, 18);
            this.lblCompFilterBy.TabIndex = 3;
            this.lblCompFilterBy.Text = "Filter by:";
            // 
            // txtCompFilter
            // 
            this.txtCompFilter.Location = new System.Drawing.Point(12, 50);
            this.txtCompFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompFilter.Name = "txtCompFilter";
            this.txtCompFilter.Size = new System.Drawing.Size(183, 24);
            this.txtCompFilter.TabIndex = 2;
            this.txtCompFilter.TextChanged += new System.EventHandler(this.txtCompFilter_TextChanged);
            // 
            // lblCompFilter
            // 
            this.lblCompFilter.AutoSize = true;
            this.lblCompFilter.Location = new System.Drawing.Point(9, 28);
            this.lblCompFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompFilter.Name = "lblCompFilter";
            this.lblCompFilter.Size = new System.Drawing.Size(44, 18);
            this.lblCompFilter.TabIndex = 1;
            this.lblCompFilter.Text = "Filter:";
            // 
            // tabScore
            // 
            this.tabScore.Controls.Add(this.lblScoresLoading);
            this.tabScore.Controls.Add(this.label1);
            this.tabScore.Controls.Add(this.dgvScore);
            this.tabScore.Location = new System.Drawing.Point(4, 22);
            this.tabScore.Name = "tabScore";
            this.tabScore.Padding = new System.Windows.Forms.Padding(3);
            this.tabScore.Size = new System.Drawing.Size(1120, 468);
            this.tabScore.TabIndex = 4;
            this.tabScore.Text = "Scores";
            this.tabScore.UseVisualStyleBackColor = true;
            // 
            // lblScoresLoading
            // 
            this.lblScoresLoading.AutoSize = true;
            this.lblScoresLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoresLoading.Location = new System.Drawing.Point(381, 200);
            this.lblScoresLoading.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScoresLoading.Name = "lblScoresLoading";
            this.lblScoresLoading.Size = new System.Drawing.Size(316, 73);
            this.lblScoresLoading.TabIndex = 7;
            this.lblScoresLoading.Text = "Loading...";
            this.lblScoresLoading.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unsaved changes ***";
            // 
            // dgvScore
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScore.AutoGenerateColumns = false;
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcScoresScoreId,
            this.dgvScoreMatchTypeNameHidden,
            this.dgvScoreDivSubDivHidden,
            this.dgvScoresMatchId,
            this.dgvScoreJudge1,
            this.dgvScoreJudge2,
            this.dgvScoreJudge3,
            this.dgvScoreJudge4,
            this.dgvScoreJudge5,
            this.dgvScoresTotal,
            this.dgvScoresRanked,
            this.dgvScoresIsDisqualified});
            this.dgvScore.DataSource = this.scoreBindingSource;
            this.dgvScore.Location = new System.Drawing.Point(32, 31);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.Size = new System.Drawing.Size(1046, 403);
            this.dgvScore.TabIndex = 0;
            this.dgvScore.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgvScore_CellContextMenuStripNeeded);
            this.dgvScore.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScore_CellEndEdit);
            this.dgvScore.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScore_CellEnter);
            this.dgvScore.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvScore_CellMouseDown);
            this.dgvScore.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScore_CellValidated);
            this.dgvScore.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvScore_ColumnHeaderMouseClick);
            this.dgvScore.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvScore_DataBindingComplete);
            this.dgvScore.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvScore_RowsAdded);
            this.dgvScore.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScore_RowValidated);
            this.dgvScore.Sorted += new System.EventHandler(this.dgvScore_Sorted);
            this.dgvScore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvScore_KeyDown);
            // 
            // dgcScoresScoreId
            // 
            this.dgcScoresScoreId.DataPropertyName = "ScoreId";
            this.dgcScoresScoreId.HeaderText = "ScoreId";
            this.dgcScoresScoreId.Name = "dgcScoresScoreId";
            this.dgcScoresScoreId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgcScoresScoreId.Visible = false;
            // 
            // dgvScoreMatchTypeNameHidden
            // 
            this.dgvScoreMatchTypeNameHidden.DataPropertyName = "MatchTypeName";
            this.dgvScoreMatchTypeNameHidden.HeaderText = "MatchTypeName";
            this.dgvScoreMatchTypeNameHidden.Name = "dgvScoreMatchTypeNameHidden";
            this.dgvScoreMatchTypeNameHidden.ReadOnly = true;
            this.dgvScoreMatchTypeNameHidden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvScoreMatchTypeNameHidden.Visible = false;
            // 
            // dgvScoreDivSubDivHidden
            // 
            this.dgvScoreDivSubDivHidden.DataPropertyName = "DivSubDiv";
            this.dgvScoreDivSubDivHidden.HeaderText = "DivSubDiv";
            this.dgvScoreDivSubDivHidden.Name = "dgvScoreDivSubDivHidden";
            this.dgvScoreDivSubDivHidden.ReadOnly = true;
            this.dgvScoreDivSubDivHidden.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvScoreDivSubDivHidden.Visible = false;
            // 
            // dgvScoresMatchId
            // 
            this.dgvScoresMatchId.DataPropertyName = "MatchId";
            this.dgvScoresMatchId.HeaderText = "MatchId";
            this.dgvScoresMatchId.Name = "dgvScoresMatchId";
            this.dgvScoresMatchId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvScoresMatchId.Visible = false;
            // 
            // dgvScoreJudge1
            // 
            this.dgvScoreJudge1.DataPropertyName = "DisplayScoreJudge1";
            this.dgvScoreJudge1.HeaderText = "Score 1";
            this.dgvScoreJudge1.Name = "dgvScoreJudge1";
            this.dgvScoreJudge1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoreJudge2
            // 
            this.dgvScoreJudge2.DataPropertyName = "DisplayScoreJudge2";
            this.dgvScoreJudge2.HeaderText = "Score 2";
            this.dgvScoreJudge2.Name = "dgvScoreJudge2";
            this.dgvScoreJudge2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoreJudge3
            // 
            this.dgvScoreJudge3.DataPropertyName = "DisplayScoreJudge3";
            this.dgvScoreJudge3.HeaderText = "Score 3";
            this.dgvScoreJudge3.Name = "dgvScoreJudge3";
            this.dgvScoreJudge3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoreJudge4
            // 
            this.dgvScoreJudge4.DataPropertyName = "DisplayScoreJudge4";
            this.dgvScoreJudge4.HeaderText = "Score 4";
            this.dgvScoreJudge4.Name = "dgvScoreJudge4";
            this.dgvScoreJudge4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoreJudge5
            // 
            this.dgvScoreJudge5.DataPropertyName = "DisplayScoreJudge5";
            this.dgvScoreJudge5.HeaderText = "Score 5";
            this.dgvScoreJudge5.Name = "dgvScoreJudge5";
            this.dgvScoreJudge5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoresTotal
            // 
            this.dgvScoresTotal.DataPropertyName = "DisplayTotal";
            this.dgvScoresTotal.HeaderText = "Total";
            this.dgvScoresTotal.Name = "dgvScoresTotal";
            this.dgvScoresTotal.ReadOnly = true;
            this.dgvScoresTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoresRanked
            // 
            this.dgvScoresRanked.DataPropertyName = "Ranked";
            this.dgvScoresRanked.HeaderText = "Ranked";
            this.dgvScoresRanked.Name = "dgvScoresRanked";
            this.dgvScoresRanked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dgvScoresIsDisqualified
            // 
            this.dgvScoresIsDisqualified.DataPropertyName = "IsDisqualified";
            this.dgvScoresIsDisqualified.FalseValue = "false";
            this.dgvScoresIsDisqualified.HeaderText = "Disqualified";
            this.dgvScoresIsDisqualified.IndeterminateValue = "false";
            this.dgvScoresIsDisqualified.Name = "dgvScoresIsDisqualified";
            this.dgvScoresIsDisqualified.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvScoresIsDisqualified.TrueValue = "true";
            // 
            // scoreBindingSource
            // 
            this.scoreBindingSource.DataSource = typeof(DKK_App.Entities.Score);
            // 
            // msMenu
            // 
            this.msMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.eventToolStripMenuItem,
            this.msMatches,
            this.msCompetitor,
            this.miHelp});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.msMenu.Size = new System.Drawing.Size(1158, 24);
            this.msMenu.TabIndex = 4;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryConnectionToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 22);
            this.miFile.Text = "File";
            // 
            // retryConnectionToolStripMenuItem
            // 
            this.retryConnectionToolStripMenuItem.Name = "retryConnectionToolStripMenuItem";
            this.retryConnectionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.retryConnectionToolStripMenuItem.Text = "Retry Connection";
            this.retryConnectionToolStripMenuItem.Click += new System.EventHandler(this.retryConnectionToolStripMenuItem_Click);
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submsRefreshEvent,
            this.submsNewEvent,
            this.submsSaveEvent,
            this.submsClearEventSelection,
            this.submsDeleteEvent});
            this.eventToolStripMenuItem.Enabled = false;
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
            this.eventToolStripMenuItem.Text = "Event";
            // 
            // submsRefreshEvent
            // 
            this.submsRefreshEvent.Name = "submsRefreshEvent";
            this.submsRefreshEvent.Size = new System.Drawing.Size(177, 22);
            this.submsRefreshEvent.Text = "Refresh Events";
            this.submsRefreshEvent.Click += new System.EventHandler(this.submsRefreshEvent_Click);
            // 
            // submsNewEvent
            // 
            this.submsNewEvent.Name = "submsNewEvent";
            this.submsNewEvent.Size = new System.Drawing.Size(177, 22);
            this.submsNewEvent.Text = "Save as New Event";
            this.submsNewEvent.Click += new System.EventHandler(this.submsNewEvent_Click);
            // 
            // submsSaveEvent
            // 
            this.submsSaveEvent.Name = "submsSaveEvent";
            this.submsSaveEvent.Size = new System.Drawing.Size(177, 22);
            this.submsSaveEvent.Text = "Save Selected Event";
            this.submsSaveEvent.Click += new System.EventHandler(this.submsSaveEvent_Click);
            // 
            // submsClearEventSelection
            // 
            this.submsClearEventSelection.Name = "submsClearEventSelection";
            this.submsClearEventSelection.Size = new System.Drawing.Size(177, 22);
            this.submsClearEventSelection.Text = "Clear Selection";
            this.submsClearEventSelection.Click += new System.EventHandler(this.submsClearEventSelection_Click);
            // 
            // submsDeleteEvent
            // 
            this.submsDeleteEvent.Name = "submsDeleteEvent";
            this.submsDeleteEvent.Size = new System.Drawing.Size(177, 22);
            this.submsDeleteEvent.Text = "Delete Event";
            this.submsDeleteEvent.Click += new System.EventHandler(this.submsDeleteEvent_Click);
            // 
            // msMatches
            // 
            this.msMatches.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewMatchToolStripMenuItem,
            this.deleteMatchToolStripMenuItem,
            this.cmiViewSelectedMatchDetails,
            this.cmiChangeSelectedDivisionNumber,
            this.clearFiltersToolStripMenuItem,
            this.refreshMatchAndCompetitorListsToolStripMenuItem,
            this.matchSelectionAssistantToolStripMenuItem});
            this.msMatches.Enabled = false;
            this.msMatches.Name = "msMatches";
            this.msMatches.Size = new System.Drawing.Size(53, 22);
            this.msMatches.Text = "Match";
            // 
            // createNewMatchToolStripMenuItem
            // 
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.createNewMatchToolStripMenuItem.Name = "createNewMatchToolStripMenuItem";
            this.createNewMatchToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.createNewMatchToolStripMenuItem.Text = "New Match";
            this.createNewMatchToolStripMenuItem.Click += new System.EventHandler(this.createNewMatchToolStripMenuItem_Click);
            // 
            // deleteMatchToolStripMenuItem
            // 
            this.deleteMatchToolStripMenuItem.Name = "deleteMatchToolStripMenuItem";
            this.deleteMatchToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.deleteMatchToolStripMenuItem.Text = "Delete Selected Match";
            // 
            // cmiViewSelectedMatchDetails
            // 
            this.cmiViewSelectedMatchDetails.Name = "cmiViewSelectedMatchDetails";
            this.cmiViewSelectedMatchDetails.Size = new System.Drawing.Size(279, 22);
            this.cmiViewSelectedMatchDetails.Text = "View Selected Match Details";
            this.cmiViewSelectedMatchDetails.Click += new System.EventHandler(this.cmiViewSelectedMatchDetails_Click);
            // 
            // cmiChangeSelectedDivisionNumber
            // 
            this.cmiChangeSelectedDivisionNumber.Name = "cmiChangeSelectedDivisionNumber";
            this.cmiChangeSelectedDivisionNumber.Size = new System.Drawing.Size(279, 22);
            this.cmiChangeSelectedDivisionNumber.Text = "Change Selected Sub-Division Number";
            this.cmiChangeSelectedDivisionNumber.Click += new System.EventHandler(this.cmiChangeSelectedDivisionNumber_Click);
            // 
            // clearFiltersToolStripMenuItem
            // 
            this.clearFiltersToolStripMenuItem.Name = "clearFiltersToolStripMenuItem";
            this.clearFiltersToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.clearFiltersToolStripMenuItem.Text = "Clear Filters";
            this.clearFiltersToolStripMenuItem.Click += new System.EventHandler(this.clearFiltersToolStripMenuItem_Click);
            // 
            // refreshMatchAndCompetitorListsToolStripMenuItem
            // 
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Name = "refreshMatchAndCompetitorListsToolStripMenuItem";
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Text = "Refresh Match and Competitor Lists";
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Click += new System.EventHandler(this.refreshMatchAndCompetitorListsToolStripMenuItem_Click);
            // 
            // matchSelectionAssistantToolStripMenuItem
            // 
            this.matchSelectionAssistantToolStripMenuItem.Name = "matchSelectionAssistantToolStripMenuItem";
            this.matchSelectionAssistantToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.matchSelectionAssistantToolStripMenuItem.Text = "Match Selection Assistant";
            this.matchSelectionAssistantToolStripMenuItem.Click += new System.EventHandler(this.matchSelectionAssistantToolStripMenuItem_Click);
            // 
            // msCompetitor
            // 
            this.msCompetitor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSelectionToolStripMenuItem1,
            this.newCompetitorToolStripMenuItem,
            this.editSelectedCompetitorToolStripMenuItem,
            this.deleteSelectedCompetitorToolStripMenuItem});
            this.msCompetitor.Enabled = false;
            this.msCompetitor.Name = "msCompetitor";
            this.msCompetitor.Size = new System.Drawing.Size(80, 22);
            this.msCompetitor.Text = "Competitor";
            // 
            // clearSelectionToolStripMenuItem1
            // 
            this.clearSelectionToolStripMenuItem1.Name = "clearSelectionToolStripMenuItem1";
            this.clearSelectionToolStripMenuItem1.Size = new System.Drawing.Size(218, 22);
            this.clearSelectionToolStripMenuItem1.Text = "Clear Selection";
            this.clearSelectionToolStripMenuItem1.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem1_Click);
            // 
            // newCompetitorToolStripMenuItem
            // 
            this.newCompetitorToolStripMenuItem.Name = "newCompetitorToolStripMenuItem";
            this.newCompetitorToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.newCompetitorToolStripMenuItem.Text = "Save as New Competitor";
            this.newCompetitorToolStripMenuItem.Click += new System.EventHandler(this.newCompetitorToolStripMenuItem_Click);
            // 
            // editSelectedCompetitorToolStripMenuItem
            // 
            this.editSelectedCompetitorToolStripMenuItem.Name = "editSelectedCompetitorToolStripMenuItem";
            this.editSelectedCompetitorToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.editSelectedCompetitorToolStripMenuItem.Text = "Save Selected Competitor";
            this.editSelectedCompetitorToolStripMenuItem.Click += new System.EventHandler(this.editSelectedCompetitorToolStripMenuItem_Click);
            // 
            // deleteSelectedCompetitorToolStripMenuItem
            // 
            this.deleteSelectedCompetitorToolStripMenuItem.Name = "deleteSelectedCompetitorToolStripMenuItem";
            this.deleteSelectedCompetitorToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.deleteSelectedCompetitorToolStripMenuItem.Text = "Delete Selected Competitor";
            this.deleteSelectedCompetitorToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedCompetitorToolStripMenuItem_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.cmiSandboxMode,
            this.autoUpdateToolStripMenuItem,
            this.cmiDownloadLatestVersion,
            this.aboutToolStripMenuItem});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(44, 22);
            this.miHelp.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.helpToolStripMenuItem1.Text = "Knowledge Base";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // cmiSandboxMode
            // 
            this.cmiSandboxMode.Name = "cmiSandboxMode";
            this.cmiSandboxMode.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.cmiSandboxMode.Size = new System.Drawing.Size(205, 22);
            this.cmiSandboxMode.Text = "Sandbox Mode - OFF";
            this.cmiSandboxMode.Click += new System.EventHandler(this.cmiSandboxMode_Click);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.autoUpdateToolStripMenuItem.Text = "Check For Updates";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // cmiDownloadLatestVersion
            // 
            this.cmiDownloadLatestVersion.Name = "cmiDownloadLatestVersion";
            this.cmiDownloadLatestVersion.Size = new System.Drawing.Size(205, 22);
            this.cmiDownloadLatestVersion.Text = "Download installer (web)";
            this.cmiDownloadLatestVersion.Click += new System.EventHandler(this.cmiDownloadLatestVersion_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnRetryConnection
            // 
            this.btnRetryConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetryConnection.Location = new System.Drawing.Point(454, 522);
            this.btnRetryConnection.Margin = new System.Windows.Forms.Padding(2);
            this.btnRetryConnection.Name = "btnRetryConnection";
            this.btnRetryConnection.Size = new System.Drawing.Size(268, 42);
            this.btnRetryConnection.TabIndex = 5;
            this.btnRetryConnection.Text = "Retry Connection";
            this.btnRetryConnection.UseVisualStyleBackColor = true;
            this.btnRetryConnection.Visible = false;
            this.btnRetryConnection.Click += new System.EventHandler(this.btnRetryConnection_Click);
            // 
            // btnRefreshLists
            // 
            this.btnRefreshLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshLists.Location = new System.Drawing.Point(478, 522);
            this.btnRefreshLists.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshLists.Name = "btnRefreshLists";
            this.btnRefreshLists.Size = new System.Drawing.Size(200, 42);
            this.btnRefreshLists.TabIndex = 6;
            this.btnRefreshLists.Text = "Refresh List Data";
            this.btnRefreshLists.UseVisualStyleBackColor = true;
            this.btnRefreshLists.Visible = false;
            this.btnRefreshLists.Click += new System.EventHandler(this.btnRefreshLists_Click);
            // 
            // btnClearMatchFilter
            // 
            this.btnClearMatchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMatchFilter.Location = new System.Drawing.Point(712, 522);
            this.btnClearMatchFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearMatchFilter.Name = "btnClearMatchFilter";
            this.btnClearMatchFilter.Size = new System.Drawing.Size(200, 42);
            this.btnClearMatchFilter.TabIndex = 7;
            this.btnClearMatchFilter.Text = "Clear Match Filter";
            this.btnClearMatchFilter.UseVisualStyleBackColor = true;
            this.btnClearMatchFilter.Visible = false;
            this.btnClearMatchFilter.Click += new System.EventHandler(this.btnClearMatchFilter_Click);
            // 
            // tmrMatchCompetitorRefresh
            // 
            this.tmrMatchCompetitorRefresh.Interval = 250;
            this.tmrMatchCompetitorRefresh.Tick += new System.EventHandler(this.tmrMatchCompetitorScoreRefresh_Tick);
            // 
            // tmrDivisions
            // 
            this.tmrDivisions.Interval = 250;
            this.tmrDivisions.Tick += new System.EventHandler(this.tmrDivisions_Tick);
            // 
            // cmsMatches
            // 
            this.cmsMatches.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsMatches.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiMatchesExpandAll,
            this.cmiMatchesCollapseAll,
            this.cmiMatchNewMatch,
            this.cmiChangeDivisionNumber,
            this.cmiDeleteMatch,
            this.cmiRemoveCompetitors,
            this.cmiViewMatchDetails});
            this.cmsMatches.Name = "cmsMatches";
            this.cmsMatches.Size = new System.Drawing.Size(233, 158);
            // 
            // cmiMatchesExpandAll
            // 
            this.cmiMatchesExpandAll.Name = "cmiMatchesExpandAll";
            this.cmiMatchesExpandAll.Size = new System.Drawing.Size(232, 22);
            this.cmiMatchesExpandAll.Text = "&Expand All";
            this.cmiMatchesExpandAll.Click += new System.EventHandler(this.cmiMatchesExpandAll_Click);
            // 
            // cmiMatchesCollapseAll
            // 
            this.cmiMatchesCollapseAll.Name = "cmiMatchesCollapseAll";
            this.cmiMatchesCollapseAll.Size = new System.Drawing.Size(232, 22);
            this.cmiMatchesCollapseAll.Text = "&Collapse All";
            this.cmiMatchesCollapseAll.Click += new System.EventHandler(this.cmiMatchesCollapseAll_Click);
            // 
            // cmiMatchNewMatch
            // 
            this.cmiMatchNewMatch.Enabled = false;
            this.cmiMatchNewMatch.Name = "cmiMatchNewMatch";
            this.cmiMatchNewMatch.Size = new System.Drawing.Size(232, 22);
            this.cmiMatchNewMatch.Text = "&New Match";
            this.cmiMatchNewMatch.Click += new System.EventHandler(this.newMatchToolStripMenuItem_Click);
            // 
            // cmiChangeDivisionNumber
            // 
            this.cmiChangeDivisionNumber.Name = "cmiChangeDivisionNumber";
            this.cmiChangeDivisionNumber.Size = new System.Drawing.Size(232, 22);
            this.cmiChangeDivisionNumber.Text = "Change Sub-Division Number";
            this.cmiChangeDivisionNumber.Click += new System.EventHandler(this.cmiChangeDivisionNumber_Click);
            // 
            // cmiDeleteMatch
            // 
            this.cmiDeleteMatch.Name = "cmiDeleteMatch";
            this.cmiDeleteMatch.Size = new System.Drawing.Size(232, 22);
            this.cmiDeleteMatch.Text = "&Delete Match";
            this.cmiDeleteMatch.Click += new System.EventHandler(this.cmiDeleteMatch_Click);
            // 
            // cmiRemoveCompetitors
            // 
            this.cmiRemoveCompetitors.Name = "cmiRemoveCompetitors";
            this.cmiRemoveCompetitors.Size = new System.Drawing.Size(232, 22);
            this.cmiRemoveCompetitors.Text = "&Remove Competitor(s)";
            this.cmiRemoveCompetitors.Click += new System.EventHandler(this.removeCompetitorsToolStripMenuItem_Click);
            // 
            // cmiViewMatchDetails
            // 
            this.cmiViewMatchDetails.Name = "cmiViewMatchDetails";
            this.cmiViewMatchDetails.Size = new System.Drawing.Size(232, 22);
            this.cmiViewMatchDetails.Text = "View Match Details";
            this.cmiViewMatchDetails.Click += new System.EventHandler(this.cmiViewMatchDetails_Click);
            // 
            // btnClearCompetitorFilter
            // 
            this.btnClearCompetitorFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCompetitorFilter.Location = new System.Drawing.Point(168, 522);
            this.btnClearCompetitorFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearCompetitorFilter.Name = "btnClearCompetitorFilter";
            this.btnClearCompetitorFilter.Size = new System.Drawing.Size(200, 42);
            this.btnClearCompetitorFilter.TabIndex = 8;
            this.btnClearCompetitorFilter.Text = "Clear Competitor Filter";
            this.btnClearCompetitorFilter.UseVisualStyleBackColor = true;
            this.btnClearCompetitorFilter.Visible = false;
            this.btnClearCompetitorFilter.Click += new System.EventHandler(this.btnClearCompetitorFilter_Click);
            // 
            // pbCompany
            // 
            this.pbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbCompany.Image = global::DKK_App.Properties.Resources.dkk_logo_medium_horizontal;
            this.pbCompany.Location = new System.Drawing.Point(14, 528);
            this.pbCompany.Margin = new System.Windows.Forms.Padding(2);
            this.pbCompany.Name = "pbCompany";
            this.pbCompany.Size = new System.Drawing.Size(141, 36);
            this.pbCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCompany.TabIndex = 2;
            this.pbCompany.TabStop = false;
            this.pbCompany.Click += new System.EventHandler(this.pbCompany_Click);
            this.pbCompany.MouseEnter += new System.EventHandler(this.pbCompany_MouseEnter);
            this.pbCompany.MouseLeave += new System.EventHandler(this.pbCompany_MouseLeave);
            this.pbCompany.MouseHover += new System.EventHandler(this.pbCompany_MouseHover);
            // 
            // pbPoweredBy
            // 
            this.pbPoweredBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPoweredBy.Image = global::DKK_App.Properties.Resources.powered_by_sqlhammer;
            this.pbPoweredBy.Location = new System.Drawing.Point(983, 528);
            this.pbPoweredBy.Margin = new System.Windows.Forms.Padding(2);
            this.pbPoweredBy.Name = "pbPoweredBy";
            this.pbPoweredBy.Size = new System.Drawing.Size(141, 36);
            this.pbPoweredBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoweredBy.TabIndex = 0;
            this.pbPoweredBy.TabStop = false;
            this.pbPoweredBy.Click += new System.EventHandler(this.pbPoweredBy_Click);
            this.pbPoweredBy.MouseEnter += new System.EventHandler(this.pbPoweredBy_MouseEnter);
            this.pbPoweredBy.MouseLeave += new System.EventHandler(this.pbPoweredBy_MouseLeave);
            this.pbPoweredBy.MouseHover += new System.EventHandler(this.pbPoweredBy_MouseHover);
            // 
            // tmrNewMatch
            // 
            this.tmrNewMatch.Interval = 250;
            this.tmrNewMatch.Tick += new System.EventHandler(this.tmrNewMatch_Tick);
            // 
            // cmsCompetitor
            // 
            this.cmsCompetitor.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsCompetitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearSelectionToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsCompetitor.Name = "cmsCompetitor";
            this.cmsCompetitor.Size = new System.Drawing.Size(153, 48);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearSelectionToolStripMenuItem.Text = "&Clear Selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tmrCompTab
            // 
            this.tmrCompTab.Interval = 250;
            this.tmrCompTab.Tick += new System.EventHandler(this.tmrCompTab_Tick);
            // 
            // tmrRegistrations
            // 
            this.tmrRegistrations.Interval = 1000;
            // 
            // btnScoresUndoChanges
            // 
            this.btnScoresUndoChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScoresUndoChanges.Location = new System.Drawing.Point(752, 544);
            this.btnScoresUndoChanges.Margin = new System.Windows.Forms.Padding(2);
            this.btnScoresUndoChanges.Name = "btnScoresUndoChanges";
            this.btnScoresUndoChanges.Size = new System.Drawing.Size(200, 42);
            this.btnScoresUndoChanges.TabIndex = 10;
            this.btnScoresUndoChanges.Text = "Undo Changes";
            this.btnScoresUndoChanges.UseVisualStyleBackColor = true;
            this.btnScoresUndoChanges.Visible = false;
            this.btnScoresUndoChanges.Click += new System.EventHandler(this.btnScoresUndoChanges_Click);
            // 
            // btnSubmitScores
            // 
            this.btnSubmitScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitScores.Location = new System.Drawing.Point(325, 544);
            this.btnSubmitScores.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmitScores.Name = "btnSubmitScores";
            this.btnSubmitScores.Size = new System.Drawing.Size(200, 42);
            this.btnSubmitScores.TabIndex = 11;
            this.btnSubmitScores.Text = "Submit Scores";
            this.btnSubmitScores.UseVisualStyleBackColor = true;
            this.btnSubmitScores.Visible = false;
            this.btnSubmitScores.Click += new System.EventHandler(this.btnSubmitScores_Click);
            // 
            // cmsScores
            // 
            this.cmsScores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiScoreAddRow,
            this.cmiScoreDeleteRows});
            this.cmsScores.Name = "cmsScores";
            this.cmsScores.Size = new System.Drawing.Size(150, 48);
            // 
            // cmiScoreAddRow
            // 
            this.cmiScoreAddRow.Name = "cmiScoreAddRow";
            this.cmiScoreAddRow.Size = new System.Drawing.Size(149, 22);
            this.cmiScoreAddRow.Text = "Add New Row";
            this.cmiScoreAddRow.Click += new System.EventHandler(this.cmiScoreAddRow_Click);
            // 
            // cmiScoreDeleteRows
            // 
            this.cmiScoreDeleteRows.Name = "cmiScoreDeleteRows";
            this.cmiScoreDeleteRows.Size = new System.Drawing.Size(149, 22);
            this.cmiScoreDeleteRows.Text = "Delete Row(s)";
            this.cmiScoreDeleteRows.Click += new System.EventHandler(this.cmiScoreDeleteRows_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1158, 597);
            this.Controls.Add(this.btnSubmitScores);
            this.Controls.Add(this.btnScoresUndoChanges);
            this.Controls.Add(this.btnClearCompetitorFilter);
            this.Controls.Add(this.btnClearMatchFilter);
            this.Controls.Add(this.btnRefreshLists);
            this.Controls.Add(this.btnRetryConnection);
            this.Controls.Add(this.pbCompany);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.pbPoweredBy);
            this.Controls.Add(this.msMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Event Hammer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.tab1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.gbAdmin.ResumeLayout(false);
            this.gbEvent.ResumeLayout(false);
            this.gbEvent.PerformLayout();
            this.gbScorecards.ResumeLayout(false);
            this.tabEvents.ResumeLayout(false);
            this.gbEventDetails.ResumeLayout(false);
            this.gbEventDetails.PerformLayout();
            this.gbEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvEvents)).EndInit();
            this.tabMatch.ResumeLayout(false);
            this.tabMatch.PerformLayout();
            this.gbMatches.ResumeLayout(false);
            this.gbMatches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).EndInit();
            this.gbMatchCompetitors.ResumeLayout(false);
            this.gbMatchCompetitors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).EndInit();
            this.tabCompetitor.ResumeLayout(false);
            this.tabCompetitor.PerformLayout();
            this.gbCompetitorDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitorDetails)).EndInit();
            this.gbComp.ResumeLayout(false);
            this.gbComp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvComp)).EndInit();
            this.tabScore.ResumeLayout(false);
            this.tabScore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBindingSource)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.cmsMatches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).EndInit();
            this.cmsCompetitor.ResumeLayout(false);
            this.cmsScores.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPoweredBy;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabMatch;
        private System.Windows.Forms.PictureBox pbCompany;
        private System.Windows.Forms.GroupBox gbEvent;
        private System.Windows.Forms.Label lblEventSelect;
        private System.Windows.Forms.ComboBox cbEventSelect;
        private System.Windows.Forms.Label lblEventTo;
        private System.Windows.Forms.DateTimePicker dtpEventTo;
        private System.Windows.Forms.DateTimePicker dtpEventFrom;
        private System.Windows.Forms.Label lblEventFrom;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.GroupBox gbScorecards;
        private System.Windows.Forms.Button btnKnockdown;
        private System.Windows.Forms.Button btnSemiKnockdown;
        private System.Windows.Forms.Button btnWeaponKata;
        private System.Windows.Forms.Button btnKata;
        private System.Windows.Forms.Label lblReportCreds;
        private System.Windows.Forms.Button btnRetryConnection;
        private System.Windows.Forms.Label lblDragAndDrop;
        private System.Windows.Forms.GroupBox gbMatches;
        private System.Windows.Forms.GroupBox gbMatchCompetitors;
        private System.Windows.Forms.RadioButton rbApplicableMatches;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.TextBox txtCompetitorFilter;
        private System.Windows.Forms.Label lblCompetitorFilter;
        private System.Windows.Forms.ComboBox cbMatchFilterBy;
        private System.Windows.Forms.Label lblMatchFilterBy;
        private System.Windows.Forms.TextBox txtMatchFilter;
        private System.Windows.Forms.Label lblMatchFilter;
        private System.Windows.Forms.ComboBox cbCompetitorFilterBy;
        private System.Windows.Forms.Label lblCompetitorFilterBy;
        private BrightIdeasSoftware.BarRenderer barRenderer1;
        private BrightIdeasSoftware.TreeListView tlvMatches;
        private System.Windows.Forms.ImageList imgList;
        private BrightIdeasSoftware.OLVColumn olvColMatchType;
        private BrightIdeasSoftware.OLVColumn olvColDivDisplay;
        private BrightIdeasSoftware.OLVColumn olvColDisplayName;
        private BrightIdeasSoftware.OLVColumn olvColRankName;
        private BrightIdeasSoftware.OLVColumn olvColAge;
        private BrightIdeasSoftware.OLVColumn olvColWeight;
        private BrightIdeasSoftware.TreeListView tlvCompetitors;
        private BrightIdeasSoftware.OLVColumn olvColCompDisplayName;
        private BrightIdeasSoftware.OLVColumn olvColCompRankName;
        private BrightIdeasSoftware.OLVColumn olvColCompAge;
        private BrightIdeasSoftware.OLVColumn olvColCompWeight;
        private BrightIdeasSoftware.OLVColumn olvColDojo;
        private System.Windows.Forms.Button btnRefreshLists;
        private System.Windows.Forms.Button btnMatchApply;
        private System.Windows.Forms.Button btnCompetitorApply;
        private System.Windows.Forms.Button btnClearMatchFilter;
        private System.Windows.Forms.ToolStripMenuItem msMatches;
        private System.Windows.Forms.ToolStripMenuItem clearFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMatchAndCompetitorListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retryConnectionToolStripMenuItem;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer tmrMatchCompetitorRefresh;
        private System.Windows.Forms.Timer tmrDivisions;
        private System.Windows.Forms.ContextMenuStrip cmsMatches;
        private System.Windows.Forms.ToolStripMenuItem cmiMatchesExpandAll;
        private System.Windows.Forms.ToolStripMenuItem cmiMatchesCollapseAll;
        private System.Windows.Forms.ToolStripMenuItem cmiDeleteMatch;
        private System.Windows.Forms.Button btnClearCompetitorFilter;
        private System.Windows.Forms.ToolStripMenuItem createNewMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmiMatchNewMatch;
        private System.Windows.Forms.Timer tmrNewMatch;
        private System.Windows.Forms.ToolStripMenuItem msCompetitor;
        private System.Windows.Forms.ToolStripMenuItem newCompetitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedCompetitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedCompetitorToolStripMenuItem;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabCompetitor;
        private System.Windows.Forms.GroupBox gbComp;
        private System.Windows.Forms.Button btnCompFilterApply;
        private BrightIdeasSoftware.TreeListView tlvComp;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.ComboBox cbCompFilterBy;
        private System.Windows.Forms.Label lblCompFilterBy;
        private System.Windows.Forms.TextBox txtCompFilter;
        private System.Windows.Forms.Label lblCompFilter;
        private System.Windows.Forms.GroupBox gbCompetitorDetails;
        private System.Windows.Forms.Button btnCompClear;
        private System.Windows.Forms.Button btnNewComp;
        private System.Windows.Forms.Button btnSaveComp;
        private System.Windows.Forms.Button btnCompDelete;
        private System.Windows.Forms.Label lblCompLoading;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsCompetitor;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer tmrCompTab;
        private BrightIdeasSoftware.OLVColumn olvColHeight;
        private BrightIdeasSoftware.OLVColumn olvMatchCompHeight;
        private BrightIdeasSoftware.OLVColumn olvColCompHeight;
        private System.Windows.Forms.GroupBox gbEventDetails;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnClearEventSelection;
        private System.Windows.Forms.Button btnNewEvent;
        private System.Windows.Forms.Button btnSaveEvent;
        private System.Windows.Forms.GroupBox gbEvents;
        private BrightIdeasSoftware.TreeListView tlvEvents;
        private BrightIdeasSoftware.OLVColumn olvColEventId;
        private BrightIdeasSoftware.OLVColumn olvColEventName;
        private BrightIdeasSoftware.OLVColumn olvColEventDateText;
        private BrightIdeasSoftware.OLVColumn olvColEventType;
        private System.Windows.Forms.DateTimePicker dtpEventDate;
        private System.Windows.Forms.ComboBox cbEventType;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.Label lblEventName;
        private BrightIdeasSoftware.OLVColumn olvColEventDate;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem submsClearEventSelection;
        private System.Windows.Forms.ToolStripMenuItem submsNewEvent;
        private System.Windows.Forms.ToolStripMenuItem submsSaveEvent;
        private System.Windows.Forms.ToolStripMenuItem submsDeleteEvent;
        private System.Windows.Forms.ToolStripMenuItem submsRefreshEvent;
        private System.Windows.Forms.Button btnKnockdownSpecial;
        private System.Windows.Forms.Button btnSemiKnockdownSpecial;
        private System.Windows.Forms.Button btnWeaponKataSpecial;
        private System.Windows.Forms.Button btnKataSpecial;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Button btnWeighInList;
        private System.Windows.Forms.Button btnDivisionRingNumbers;
        private System.Windows.Forms.Button btnSchoolsOwners;
        private System.Windows.Forms.Button btnAllEvents;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchSelectionAssistantToolStripMenuItem;
        private System.Windows.Forms.Button btnEventLoadReg;
        private System.Windows.Forms.Timer tmrRegistrations;
        private System.Windows.Forms.ToolStripMenuItem cmiRemoveCompetitors;
        private System.Windows.Forms.ToolStripMenuItem cmiViewMatchDetails;
        private System.Windows.Forms.Button btnRegForm;
        private System.Windows.Forms.ToolStripMenuItem cmiViewSelectedMatchDetails;
        private System.Windows.Forms.ToolStripMenuItem cmiChangeDivisionNumber;
        private System.Windows.Forms.ToolStripMenuItem cmiChangeSelectedDivisionNumber;
        private System.Windows.Forms.ToolStripMenuItem cmiDownloadLatestVersion;
        private System.Windows.Forms.Button btnCompetitorsBySchoolReport;
        private System.Windows.Forms.Button btnCheckInRoster;
        private System.Windows.Forms.RichTextBox rtbEventInfo;
        private System.Windows.Forms.DataGridView dgvCompetitorDetails;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.TabPage tabScore;
        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.BindingSource scoreBindingSource;
        private System.Windows.Forms.Button btnScoresUndoChanges;
        private System.Windows.Forms.Button btnSubmitScores;
        private System.Windows.Forms.ContextMenuStrip cmsScores;
        private System.Windows.Forms.ToolStripMenuItem cmiScoreAddRow;
        private System.Windows.Forms.ToolStripMenuItem cmiScoreDeleteRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cmiSandboxMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcScoresScoreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreMatchTypeNameHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreDivSubDivHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoresMatchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreJudge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreJudge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreJudge3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreJudge4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoreJudge5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoresTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScoresRanked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvScoresIsDisqualified;
        private System.Windows.Forms.Label lblScoresLoading;
    }
}