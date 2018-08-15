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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.btnSchoolsOwners = new System.Windows.Forms.Button();
            this.btnAllEvents = new System.Windows.Forms.Button();
            this.btnDivisionRingNumbers = new System.Windows.Forms.Button();
            this.btnWeighInList = new System.Windows.Forms.Button();
            this.gbEvent = new System.Windows.Forms.GroupBox();
            this.btnEventLoadReg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEventTo = new System.Windows.Forms.DateTimePicker();
            this.dtpEventFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventInfo = new System.Windows.Forms.TextBox();
            this.lblEventSelect = new System.Windows.Forms.Label();
            this.cbEventSelect = new System.Windows.Forms.ComboBox();
            this.gbScorecards = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.label7 = new System.Windows.Forms.Label();
            this.txtMatchFilter = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCompetitorApply = new System.Windows.Forms.Button();
            this.tlvCompetitors = new BrightIdeasSoftware.TreeListView();
            this.olvColCompDisplayName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompRankName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvMatchCompHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbCompetitorFilterBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompetitorFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabCompetitor = new System.Windows.Forms.TabPage();
            this.lblCompLoading = new System.Windows.Forms.Label();
            this.gbCompetitorDetails = new System.Windows.Forms.GroupBox();
            this.btnCompDelete = new System.Windows.Forms.Button();
            this.btnCompClear = new System.Windows.Forms.Button();
            this.btnNewComp = new System.Windows.Forms.Button();
            this.btnSaveComp = new System.Windows.Forms.Button();
            this.gbCompAddress = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtCompZipCode = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtCompState = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtCompCity = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCompApptCode = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCompStreet2 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtCompStreet1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCompCountry = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtCompEmail = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCompPhone = new System.Windows.Forms.TextBox();
            this.gbCompDemographics = new System.Windows.Forms.GroupBox();
            this.btnSpecialConsiderationDetails = new System.Windows.Forms.Button();
            this.nudCompAge = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.nudCompHeight = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.cbCompBelt = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCompSchoolOther = new System.Windows.Forms.TextBox();
            this.cbCompSchool = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.gbCompParent = new System.Windows.Forms.GroupBox();
            this.txtCompParentEmail = new System.Windows.Forms.TextBox();
            this.txtCompParentLastName = new System.Windows.Forms.TextBox();
            this.txtCompParentFirstName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudCompWeight = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.rbCompMale = new System.Windows.Forms.RadioButton();
            this.rbCompFemale = new System.Windows.Forms.RadioButton();
            this.cbCompTitle = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chbCompIsInstructor = new System.Windows.Forms.CheckBox();
            this.chbCompSpecialConsideration = new System.Windows.Forms.CheckBox();
            this.txtCompLastName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCompFirstName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbComp = new System.Windows.Forms.GroupBox();
            this.btnCompFilterApply = new System.Windows.Forms.Button();
            this.tlvComp = new BrightIdeasSoftware.TreeListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCompHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cbCompFilterBy = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCompFilter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRetryConnection = new System.Windows.Forms.Button();
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.btnRefreshMatchTab = new System.Windows.Forms.Button();
            this.btnClearMatchFilter = new System.Windows.Forms.Button();
            this.tmrMatchCompetitorRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrDivisions = new System.Windows.Forms.Timer(this.components);
            this.cmsMatches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiMatchesExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMatchesCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMatchNewMatch = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.tmrRegistrations = new System.Windows.Forms.Timer(this.components);
            this.txtCompInstructor = new System.Windows.Forms.TextBox();
            this.lblCompInstructor = new System.Windows.Forms.Label();
            this.lblCompSchoolOther = new System.Windows.Forms.Label();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).BeginInit();
            this.tabCompetitor.SuspendLayout();
            this.gbCompetitorDetails.SuspendLayout();
            this.gbCompAddress.SuspendLayout();
            this.gbCompDemographics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompHeight)).BeginInit();
            this.gbCompParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompWeight)).BeginInit();
            this.gbComp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvComp)).BeginInit();
            this.msMenu.SuspendLayout();
            this.cmsMatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).BeginInit();
            this.cmsCompetitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabHome);
            this.tab1.Controls.Add(this.tabEvents);
            this.tab1.Controls.Add(this.tabMatch);
            this.tab1.Controls.Add(this.tabCompetitor);
            this.tab1.Location = new System.Drawing.Point(12, 48);
            this.tab1.Margin = new System.Windows.Forms.Padding(4);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(2256, 988);
            this.tab1.TabIndex = 1;
            this.tab1.SelectedIndexChanged += new System.EventHandler(this.tab1_SelectedIndexChanged);
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.gbAdmin);
            this.tabHome.Controls.Add(this.gbEvent);
            this.tabHome.Controls.Add(this.gbScorecards);
            this.tabHome.Location = new System.Drawing.Point(8, 39);
            this.tabHome.Margin = new System.Windows.Forms.Padding(4);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(4);
            this.tabHome.Size = new System.Drawing.Size(2240, 941);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.btnSchoolsOwners);
            this.gbAdmin.Controls.Add(this.btnAllEvents);
            this.gbAdmin.Controls.Add(this.btnDivisionRingNumbers);
            this.gbAdmin.Controls.Add(this.btnWeighInList);
            this.gbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.gbAdmin.Location = new System.Drawing.Point(7, 380);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(979, 554);
            this.gbAdmin.TabIndex = 5;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Text = "Administrative Reports";
            // 
            // btnSchoolsOwners
            // 
            this.btnSchoolsOwners.Enabled = false;
            this.btnSchoolsOwners.Location = new System.Drawing.Point(532, 51);
            this.btnSchoolsOwners.Margin = new System.Windows.Forms.Padding(4);
            this.btnSchoolsOwners.Name = "btnSchoolsOwners";
            this.btnSchoolsOwners.Size = new System.Drawing.Size(410, 210);
            this.btnSchoolsOwners.TabIndex = 11;
            this.btnSchoolsOwners.Text = "Schools and Owners";
            this.btnSchoolsOwners.UseVisualStyleBackColor = true;
            this.btnSchoolsOwners.Click += new System.EventHandler(this.btnSchoolsOwners_Click);
            // 
            // btnAllEvents
            // 
            this.btnAllEvents.Enabled = false;
            this.btnAllEvents.Location = new System.Drawing.Point(38, 51);
            this.btnAllEvents.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllEvents.Name = "btnAllEvents";
            this.btnAllEvents.Size = new System.Drawing.Size(410, 210);
            this.btnAllEvents.TabIndex = 10;
            this.btnAllEvents.Text = "All Events";
            this.btnAllEvents.UseVisualStyleBackColor = true;
            this.btnAllEvents.Click += new System.EventHandler(this.btnAllEvents_Click);
            // 
            // btnDivisionRingNumbers
            // 
            this.btnDivisionRingNumbers.Enabled = false;
            this.btnDivisionRingNumbers.Location = new System.Drawing.Point(532, 311);
            this.btnDivisionRingNumbers.Margin = new System.Windows.Forms.Padding(4);
            this.btnDivisionRingNumbers.Name = "btnDivisionRingNumbers";
            this.btnDivisionRingNumbers.Size = new System.Drawing.Size(410, 210);
            this.btnDivisionRingNumbers.TabIndex = 9;
            this.btnDivisionRingNumbers.Text = "Division Ring Numbers";
            this.btnDivisionRingNumbers.UseVisualStyleBackColor = true;
            this.btnDivisionRingNumbers.Click += new System.EventHandler(this.btnDivisionRingNumbers_Click);
            // 
            // btnWeighInList
            // 
            this.btnWeighInList.Enabled = false;
            this.btnWeighInList.Location = new System.Drawing.Point(38, 311);
            this.btnWeighInList.Margin = new System.Windows.Forms.Padding(4);
            this.btnWeighInList.Name = "btnWeighInList";
            this.btnWeighInList.Size = new System.Drawing.Size(410, 210);
            this.btnWeighInList.TabIndex = 8;
            this.btnWeighInList.Text = "Weigh-In List";
            this.btnWeighInList.UseVisualStyleBackColor = true;
            this.btnWeighInList.Click += new System.EventHandler(this.btnWeighInList_Click);
            // 
            // gbEvent
            // 
            this.gbEvent.Controls.Add(this.btnEventLoadReg);
            this.gbEvent.Controls.Add(this.label2);
            this.gbEvent.Controls.Add(this.dtpEventTo);
            this.gbEvent.Controls.Add(this.dtpEventFrom);
            this.gbEvent.Controls.Add(this.label1);
            this.gbEvent.Controls.Add(this.txtEventInfo);
            this.gbEvent.Controls.Add(this.lblEventSelect);
            this.gbEvent.Controls.Add(this.cbEventSelect);
            this.gbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvent.Location = new System.Drawing.Point(6, 6);
            this.gbEvent.Margin = new System.Windows.Forms.Padding(4);
            this.gbEvent.Name = "gbEvent";
            this.gbEvent.Padding = new System.Windows.Forms.Padding(4);
            this.gbEvent.Size = new System.Drawing.Size(980, 356);
            this.gbEvent.TabIndex = 0;
            this.gbEvent.TabStop = false;
            this.gbEvent.Text = "Select Event";
            // 
            // btnEventLoadReg
            // 
            this.btnEventLoadReg.Enabled = false;
            this.btnEventLoadReg.Location = new System.Drawing.Point(759, 92);
            this.btnEventLoadReg.Name = "btnEventLoadReg";
            this.btnEventLoadReg.Size = new System.Drawing.Size(214, 252);
            this.btnEventLoadReg.TabIndex = 7;
            this.btnEventLoadReg.Text = "Load new registrations";
            this.btnEventLoadReg.UseVisualStyleBackColor = true;
            this.btnEventLoadReg.Click += new System.EventHandler(this.btnEventLoadReg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "To:";
            // 
            // dtpEventTo
            // 
            this.dtpEventTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventTo.Location = new System.Drawing.Point(358, 42);
            this.dtpEventTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEventTo.Name = "dtpEventTo";
            this.dtpEventTo.Size = new System.Drawing.Size(200, 35);
            this.dtpEventTo.TabIndex = 5;
            this.dtpEventTo.ValueChanged += new System.EventHandler(this.dtpEventTo_ValueChanged);
            // 
            // dtpEventFrom
            // 
            this.dtpEventFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventFrom.Location = new System.Drawing.Point(92, 42);
            this.dtpEventFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEventFrom.Name = "dtpEventFrom";
            this.dtpEventFrom.Size = new System.Drawing.Size(200, 35);
            this.dtpEventFrom.TabIndex = 4;
            this.dtpEventFrom.ValueChanged += new System.EventHandler(this.dtpEventFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // txtEventInfo
            // 
            this.txtEventInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventInfo.Location = new System.Drawing.Point(12, 148);
            this.txtEventInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventInfo.Multiline = true;
            this.txtEventInfo.Name = "txtEventInfo";
            this.txtEventInfo.Size = new System.Drawing.Size(740, 196);
            this.txtEventInfo.TabIndex = 2;
            // 
            // lblEventSelect
            // 
            this.lblEventSelect.AutoSize = true;
            this.lblEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSelect.Location = new System.Drawing.Point(6, 96);
            this.lblEventSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventSelect.Name = "lblEventSelect";
            this.lblEventSelect.Size = new System.Drawing.Size(153, 29);
            this.lblEventSelect.TabIndex = 1;
            this.lblEventSelect.Text = "Select Event:";
            // 
            // cbEventSelect
            // 
            this.cbEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventSelect.FormattingEnabled = true;
            this.cbEventSelect.Location = new System.Drawing.Point(164, 92);
            this.cbEventSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cbEventSelect.Name = "cbEventSelect";
            this.cbEventSelect.Size = new System.Drawing.Size(588, 37);
            this.cbEventSelect.TabIndex = 0;
            this.cbEventSelect.SelectedIndexChanged += new System.EventHandler(this.cbEventSelect_SelectedIndexChanged);
            // 
            // gbScorecards
            // 
            this.gbScorecards.Controls.Add(this.label3);
            this.gbScorecards.Controls.Add(this.btnKnockdownSpecial);
            this.gbScorecards.Controls.Add(this.btnSemiKnockdownSpecial);
            this.gbScorecards.Controls.Add(this.btnWeaponKataSpecial);
            this.gbScorecards.Controls.Add(this.btnKataSpecial);
            this.gbScorecards.Controls.Add(this.btnKnockdown);
            this.gbScorecards.Controls.Add(this.btnSemiKnockdown);
            this.gbScorecards.Controls.Add(this.btnWeaponKata);
            this.gbScorecards.Controls.Add(this.btnKata);
            this.gbScorecards.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.gbScorecards.Location = new System.Drawing.Point(994, 8);
            this.gbScorecards.Margin = new System.Windows.Forms.Padding(4);
            this.gbScorecards.Name = "gbScorecards";
            this.gbScorecards.Padding = new System.Windows.Forms.Padding(4);
            this.gbScorecards.Size = new System.Drawing.Size(1190, 925);
            this.gbScorecards.TabIndex = 0;
            this.gbScorecards.TabStop = false;
            this.gbScorecards.Text = "Scorecards";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username: reports - Password: reports";
            // 
            // btnKnockdownSpecial
            // 
            this.btnKnockdownSpecial.Enabled = false;
            this.btnKnockdownSpecial.Location = new System.Drawing.Point(653, 663);
            this.btnKnockdownSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.btnKnockdownSpecial.Name = "btnKnockdownSpecial";
            this.btnKnockdownSpecial.Size = new System.Drawing.Size(333, 250);
            this.btnKnockdownSpecial.TabIndex = 7;
            this.btnKnockdownSpecial.Text = "Knockdown - Special Consideration";
            this.btnKnockdownSpecial.UseVisualStyleBackColor = true;
            this.btnKnockdownSpecial.Click += new System.EventHandler(this.btnKnockdownSpecial_Click);
            // 
            // btnSemiKnockdownSpecial
            // 
            this.btnSemiKnockdownSpecial.Enabled = false;
            this.btnSemiKnockdownSpecial.Location = new System.Drawing.Point(227, 663);
            this.btnSemiKnockdownSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.btnSemiKnockdownSpecial.Name = "btnSemiKnockdownSpecial";
            this.btnSemiKnockdownSpecial.Size = new System.Drawing.Size(333, 250);
            this.btnSemiKnockdownSpecial.TabIndex = 6;
            this.btnSemiKnockdownSpecial.Text = "Semi-Knockdown - Special Consideration";
            this.btnSemiKnockdownSpecial.UseVisualStyleBackColor = true;
            this.btnSemiKnockdownSpecial.Click += new System.EventHandler(this.btnSemiKnockdownSpecial_Click);
            // 
            // btnWeaponKataSpecial
            // 
            this.btnWeaponKataSpecial.Enabled = false;
            this.btnWeaponKataSpecial.Location = new System.Drawing.Point(822, 374);
            this.btnWeaponKataSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.btnWeaponKataSpecial.Name = "btnWeaponKataSpecial";
            this.btnWeaponKataSpecial.Size = new System.Drawing.Size(333, 250);
            this.btnWeaponKataSpecial.TabIndex = 5;
            this.btnWeaponKataSpecial.Text = "Weapon Kata - Special Consideration";
            this.btnWeaponKataSpecial.UseVisualStyleBackColor = true;
            this.btnWeaponKataSpecial.Click += new System.EventHandler(this.btnWeaponKataSpecial_Click);
            // 
            // btnKataSpecial
            // 
            this.btnKataSpecial.Enabled = false;
            this.btnKataSpecial.Location = new System.Drawing.Point(822, 80);
            this.btnKataSpecial.Margin = new System.Windows.Forms.Padding(4);
            this.btnKataSpecial.Name = "btnKataSpecial";
            this.btnKataSpecial.Size = new System.Drawing.Size(333, 250);
            this.btnKataSpecial.TabIndex = 4;
            this.btnKataSpecial.Text = "Kata - Special Consideration";
            this.btnKataSpecial.UseVisualStyleBackColor = true;
            this.btnKataSpecial.Click += new System.EventHandler(this.btnKataSpecial_Click);
            // 
            // btnKnockdown
            // 
            this.btnKnockdown.Enabled = false;
            this.btnKnockdown.Location = new System.Drawing.Point(444, 374);
            this.btnKnockdown.Margin = new System.Windows.Forms.Padding(4);
            this.btnKnockdown.Name = "btnKnockdown";
            this.btnKnockdown.Size = new System.Drawing.Size(333, 250);
            this.btnKnockdown.TabIndex = 3;
            this.btnKnockdown.Text = "Knockdown";
            this.btnKnockdown.UseVisualStyleBackColor = true;
            this.btnKnockdown.Click += new System.EventHandler(this.btnKnockdown_Click);
            // 
            // btnSemiKnockdown
            // 
            this.btnSemiKnockdown.Enabled = false;
            this.btnSemiKnockdown.Location = new System.Drawing.Point(60, 374);
            this.btnSemiKnockdown.Margin = new System.Windows.Forms.Padding(4);
            this.btnSemiKnockdown.Name = "btnSemiKnockdown";
            this.btnSemiKnockdown.Size = new System.Drawing.Size(333, 250);
            this.btnSemiKnockdown.TabIndex = 2;
            this.btnSemiKnockdown.Text = "Semi-Knockdown";
            this.btnSemiKnockdown.UseVisualStyleBackColor = true;
            this.btnSemiKnockdown.Click += new System.EventHandler(this.btnSemiKnockdown_Click);
            // 
            // btnWeaponKata
            // 
            this.btnWeaponKata.Enabled = false;
            this.btnWeaponKata.Location = new System.Drawing.Point(444, 80);
            this.btnWeaponKata.Margin = new System.Windows.Forms.Padding(4);
            this.btnWeaponKata.Name = "btnWeaponKata";
            this.btnWeaponKata.Size = new System.Drawing.Size(333, 250);
            this.btnWeaponKata.TabIndex = 1;
            this.btnWeaponKata.Text = "Weapon Kata";
            this.btnWeaponKata.UseVisualStyleBackColor = true;
            this.btnWeaponKata.Click += new System.EventHandler(this.btnWeaponKata_Click);
            // 
            // btnKata
            // 
            this.btnKata.Enabled = false;
            this.btnKata.Location = new System.Drawing.Point(60, 80);
            this.btnKata.Margin = new System.Windows.Forms.Padding(4);
            this.btnKata.Name = "btnKata";
            this.btnKata.Size = new System.Drawing.Size(333, 250);
            this.btnKata.TabIndex = 0;
            this.btnKata.Text = "Kata";
            this.btnKata.UseVisualStyleBackColor = true;
            this.btnKata.Click += new System.EventHandler(this.btnKata_Click);
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.gbEventDetails);
            this.tabEvents.Controls.Add(this.gbEvents);
            this.tabEvents.Location = new System.Drawing.Point(8, 39);
            this.tabEvents.Margin = new System.Windows.Forms.Padding(4);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(4);
            this.tabEvents.Size = new System.Drawing.Size(2240, 941);
            this.tabEvents.TabIndex = 2;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // gbEventDetails
            // 
            this.gbEventDetails.Controls.Add(this.dtpEventDate);
            this.gbEventDetails.Controls.Add(this.cbEventType);
            this.gbEventDetails.Controls.Add(this.txtEventName);
            this.gbEventDetails.Controls.Add(this.label32);
            this.gbEventDetails.Controls.Add(this.label33);
            this.gbEventDetails.Controls.Add(this.label34);
            this.gbEventDetails.Controls.Add(this.btnDeleteEvent);
            this.gbEventDetails.Controls.Add(this.btnClearEventSelection);
            this.gbEventDetails.Controls.Add(this.btnNewEvent);
            this.gbEventDetails.Controls.Add(this.btnSaveEvent);
            this.gbEventDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEventDetails.Location = new System.Drawing.Point(996, 12);
            this.gbEventDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbEventDetails.Name = "gbEventDetails";
            this.gbEventDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbEventDetails.Size = new System.Drawing.Size(1220, 912);
            this.gbEventDetails.TabIndex = 7;
            this.gbEventDetails.TabStop = false;
            this.gbEventDetails.Text = "Event Details";
            // 
            // dtpEventDate
            // 
            this.dtpEventDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventDate.Location = new System.Drawing.Point(484, 472);
            this.dtpEventDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEventDate.Name = "dtpEventDate";
            this.dtpEventDate.Size = new System.Drawing.Size(476, 40);
            this.dtpEventDate.TabIndex = 11;
            // 
            // cbEventType
            // 
            this.cbEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventType.FormattingEnabled = true;
            this.cbEventType.Location = new System.Drawing.Point(484, 376);
            this.cbEventType.Margin = new System.Windows.Forms.Padding(4);
            this.cbEventType.Name = "cbEventType";
            this.cbEventType.Size = new System.Drawing.Size(476, 41);
            this.cbEventType.TabIndex = 10;
            // 
            // txtEventName
            // 
            this.txtEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventName.Location = new System.Drawing.Point(484, 276);
            this.txtEventName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(476, 40);
            this.txtEventName.TabIndex = 9;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(228, 478);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(76, 33);
            this.label32.TabIndex = 8;
            this.label32.Text = "Date";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(228, 378);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(162, 33);
            this.label33.TabIndex = 7;
            this.label33.Text = "Event Type";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(228, 280);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(175, 33);
            this.label34.TabIndex = 6;
            this.label34.Text = "Event Name";
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Location = new System.Drawing.Point(554, 798);
            this.btnDeleteEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(292, 70);
            this.btnDeleteEvent.TabIndex = 5;
            this.btnDeleteEvent.Text = "Delete Event";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnClearEventSelection
            // 
            this.btnClearEventSelection.Location = new System.Drawing.Point(888, 798);
            this.btnClearEventSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearEventSelection.Name = "btnClearEventSelection";
            this.btnClearEventSelection.Size = new System.Drawing.Size(308, 70);
            this.btnClearEventSelection.TabIndex = 4;
            this.btnClearEventSelection.Text = "Clear Selection";
            this.btnClearEventSelection.UseVisualStyleBackColor = true;
            this.btnClearEventSelection.Click += new System.EventHandler(this.btnClearEventSelection_Click);
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.Location = new System.Drawing.Point(296, 798);
            this.btnNewEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(228, 70);
            this.btnNewEvent.TabIndex = 3;
            this.btnNewEvent.Text = "Save as New";
            this.btnNewEvent.UseVisualStyleBackColor = true;
            this.btnNewEvent.Click += new System.EventHandler(this.btnNewEvent_Click);
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(28, 798);
            this.btnSaveEvent.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(236, 70);
            this.btnSaveEvent.TabIndex = 2;
            this.btnSaveEvent.Text = "Save Changes";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // gbEvents
            // 
            this.gbEvents.Controls.Add(this.tlvEvents);
            this.gbEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvents.Location = new System.Drawing.Point(24, 12);
            this.gbEvents.Margin = new System.Windows.Forms.Padding(4);
            this.gbEvents.Name = "gbEvents";
            this.gbEvents.Padding = new System.Windows.Forms.Padding(4);
            this.gbEvents.Size = new System.Drawing.Size(934, 916);
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
            this.tlvEvents.IsSimpleDragSource = true;
            this.tlvEvents.Location = new System.Drawing.Point(6, 56);
            this.tlvEvents.Margin = new System.Windows.Forms.Padding(4);
            this.tlvEvents.Name = "tlvEvents";
            this.tlvEvents.ShowGroups = false;
            this.tlvEvents.Size = new System.Drawing.Size(912, 848);
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
            this.tabMatch.Controls.Add(this.groupBox2);
            this.tabMatch.Controls.Add(this.groupBox1);
            this.tabMatch.Controls.Add(this.label4);
            this.tabMatch.Location = new System.Drawing.Point(8, 39);
            this.tabMatch.Margin = new System.Windows.Forms.Padding(4);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(4);
            this.tabMatch.Size = new System.Drawing.Size(2240, 941);
            this.tabMatch.TabIndex = 1;
            this.tabMatch.Text = "Matches";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(736, 410);
            this.lblLoading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(626, 147);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMatchApply);
            this.groupBox2.Controls.Add(this.tlvMatches);
            this.groupBox2.Controls.Add(this.cbMatchFilterBy);
            this.groupBox2.Controls.Add(this.rbApplicableMatches);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMatchFilter);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1108, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1128, 916);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matches";
            // 
            // btnMatchApply
            // 
            this.btnMatchApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchApply.Location = new System.Drawing.Point(952, 96);
            this.btnMatchApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnMatchApply.Name = "btnMatchApply";
            this.btnMatchApply.Size = new System.Drawing.Size(132, 50);
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
            this.tlvMatches.IsSimpleDropSink = true;
            this.tlvMatches.Location = new System.Drawing.Point(8, 160);
            this.tlvMatches.Margin = new System.Windows.Forms.Padding(4);
            this.tlvMatches.Name = "tlvMatches";
            this.tlvMatches.ShowGroups = false;
            this.tlvMatches.Size = new System.Drawing.Size(1114, 752);
            this.tlvMatches.SmallImageList = this.imgList;
            this.tlvMatches.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvMatches.TabIndex = 10;
            this.tlvMatches.UseCompatibleStateImageBehavior = false;
            this.tlvMatches.View = System.Windows.Forms.View.Details;
            this.tlvMatches.VirtualMode = true;
            this.tlvMatches.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.tlvMatches_CanDrop);
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
            this.cbMatchFilterBy.Location = new System.Drawing.Point(554, 100);
            this.cbMatchFilterBy.Margin = new System.Windows.Forms.Padding(4);
            this.cbMatchFilterBy.Name = "cbMatchFilterBy";
            this.cbMatchFilterBy.Size = new System.Drawing.Size(348, 41);
            this.cbMatchFilterBy.TabIndex = 8;
            // 
            // rbApplicableMatches
            // 
            this.rbApplicableMatches.AutoSize = true;
            this.rbApplicableMatches.Enabled = false;
            this.rbApplicableMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApplicableMatches.Location = new System.Drawing.Point(20, 92);
            this.rbApplicableMatches.Margin = new System.Windows.Forms.Padding(4);
            this.rbApplicableMatches.Name = "rbApplicableMatches";
            this.rbApplicableMatches.Size = new System.Drawing.Size(158, 62);
            this.rbApplicableMatches.TabIndex = 9;
            this.rbApplicableMatches.Text = "Applicable\r\nMatches";
            this.rbApplicableMatches.UseVisualStyleBackColor = true;
            this.rbApplicableMatches.CheckedChanged += new System.EventHandler(this.rbApplicableMatches_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(554, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "Filter by:";
            // 
            // txtMatchFilter
            // 
            this.txtMatchFilter.Location = new System.Drawing.Point(220, 100);
            this.txtMatchFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatchFilter.Name = "txtMatchFilter";
            this.txtMatchFilter.Size = new System.Drawing.Size(286, 40);
            this.txtMatchFilter.TabIndex = 6;
            this.txtMatchFilter.TextChanged += new System.EventHandler(this.txtMatchFilter_TextChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Enabled = false;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.Location = new System.Drawing.Point(20, 56);
            this.rbAll.Margin = new System.Windows.Forms.Padding(4);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(167, 33);
            this.rbAll.TabIndex = 8;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All Matches";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 33);
            this.label8.TabIndex = 5;
            this.label8.Text = "Filter:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCompetitorApply);
            this.groupBox1.Controls.Add(this.tlvCompetitors);
            this.groupBox1.Controls.Add(this.cbCompetitorFilterBy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCompetitorFilter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(934, 916);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Competitors";
            // 
            // btnCompetitorApply
            // 
            this.btnCompetitorApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompetitorApply.Location = new System.Drawing.Point(784, 96);
            this.btnCompetitorApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompetitorApply.Name = "btnCompetitorApply";
            this.btnCompetitorApply.Size = new System.Drawing.Size(132, 50);
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
            this.tlvCompetitors.IsSimpleDragSource = true;
            this.tlvCompetitors.Location = new System.Drawing.Point(6, 160);
            this.tlvCompetitors.Margin = new System.Windows.Forms.Padding(4);
            this.tlvCompetitors.Name = "tlvCompetitors";
            this.tlvCompetitors.ShowGroups = false;
            this.tlvCompetitors.Size = new System.Drawing.Size(912, 748);
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
            this.cbCompetitorFilterBy.Location = new System.Drawing.Point(412, 100);
            this.cbCompetitorFilterBy.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompetitorFilterBy.Name = "cbCompetitorFilterBy";
            this.cbCompetitorFilterBy.Size = new System.Drawing.Size(350, 41);
            this.cbCompetitorFilterBy.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 33);
            this.label6.TabIndex = 3;
            this.label6.Text = "Filter by:";
            // 
            // txtCompetitorFilter
            // 
            this.txtCompetitorFilter.Location = new System.Drawing.Point(24, 100);
            this.txtCompetitorFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompetitorFilter.Name = "txtCompetitorFilter";
            this.txtCompetitorFilter.Size = new System.Drawing.Size(362, 40);
            this.txtCompetitorFilter.TabIndex = 2;
            this.txtCompetitorFilter.TextChanged += new System.EventHandler(this.txtCompetitorFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 33);
            this.label5.TabIndex = 1;
            this.label5.Text = "Filter:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(984, 326);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 378);
            this.label4.TabIndex = 2;
            this.label4.Text = ">\r\n\r\nDrag\r\n\r\nand\r\n\r\nDrop\r\n\r\n>";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabCompetitor
            // 
            this.tabCompetitor.Controls.Add(this.gbCompetitorDetails);
            this.tabCompetitor.Controls.Add(this.gbComp);
            this.tabCompetitor.Location = new System.Drawing.Point(8, 39);
            this.tabCompetitor.Margin = new System.Windows.Forms.Padding(4);
            this.tabCompetitor.Name = "tabCompetitor";
            this.tabCompetitor.Padding = new System.Windows.Forms.Padding(4);
            this.tabCompetitor.Size = new System.Drawing.Size(2240, 941);
            this.tabCompetitor.TabIndex = 3;
            this.tabCompetitor.Text = "Competitors";
            this.tabCompetitor.UseVisualStyleBackColor = true;
            // 
            // lblCompLoading
            // 
            this.lblCompLoading.AutoSize = true;
            this.lblCompLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompLoading.Location = new System.Drawing.Point(808, 392);
            this.lblCompLoading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompLoading.Name = "lblCompLoading";
            this.lblCompLoading.Size = new System.Drawing.Size(626, 147);
            this.lblCompLoading.TabIndex = 6;
            this.lblCompLoading.Text = "Loading...";
            this.lblCompLoading.Visible = false;
            // 
            // gbCompetitorDetails
            // 
            this.gbCompetitorDetails.Controls.Add(this.btnCompDelete);
            this.gbCompetitorDetails.Controls.Add(this.btnCompClear);
            this.gbCompetitorDetails.Controls.Add(this.btnNewComp);
            this.gbCompetitorDetails.Controls.Add(this.btnSaveComp);
            this.gbCompetitorDetails.Controls.Add(this.gbCompAddress);
            this.gbCompetitorDetails.Controls.Add(this.gbCompDemographics);
            this.gbCompetitorDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCompetitorDetails.Location = new System.Drawing.Point(992, 8);
            this.gbCompetitorDetails.Margin = new System.Windows.Forms.Padding(4);
            this.gbCompetitorDetails.Name = "gbCompetitorDetails";
            this.gbCompetitorDetails.Padding = new System.Windows.Forms.Padding(4);
            this.gbCompetitorDetails.Size = new System.Drawing.Size(1220, 912);
            this.gbCompetitorDetails.TabIndex = 5;
            this.gbCompetitorDetails.TabStop = false;
            this.gbCompetitorDetails.Text = "Competitor Details";
            // 
            // btnCompDelete
            // 
            this.btnCompDelete.Location = new System.Drawing.Point(554, 798);
            this.btnCompDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompDelete.Name = "btnCompDelete";
            this.btnCompDelete.Size = new System.Drawing.Size(292, 70);
            this.btnCompDelete.TabIndex = 5;
            this.btnCompDelete.Text = "Delete Competitor";
            this.btnCompDelete.UseVisualStyleBackColor = true;
            this.btnCompDelete.Click += new System.EventHandler(this.btnCompDelete_Click);
            // 
            // btnCompClear
            // 
            this.btnCompClear.Location = new System.Drawing.Point(888, 798);
            this.btnCompClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompClear.Name = "btnCompClear";
            this.btnCompClear.Size = new System.Drawing.Size(308, 70);
            this.btnCompClear.TabIndex = 4;
            this.btnCompClear.Text = "Clear Selection";
            this.btnCompClear.UseVisualStyleBackColor = true;
            this.btnCompClear.Click += new System.EventHandler(this.btnCompClear_Click);
            // 
            // btnNewComp
            // 
            this.btnNewComp.Location = new System.Drawing.Point(296, 798);
            this.btnNewComp.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewComp.Name = "btnNewComp";
            this.btnNewComp.Size = new System.Drawing.Size(228, 70);
            this.btnNewComp.TabIndex = 3;
            this.btnNewComp.Text = "Save as New";
            this.btnNewComp.UseVisualStyleBackColor = true;
            this.btnNewComp.Click += new System.EventHandler(this.btnNewComp_Click);
            // 
            // btnSaveComp
            // 
            this.btnSaveComp.Location = new System.Drawing.Point(28, 798);
            this.btnSaveComp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveComp.Name = "btnSaveComp";
            this.btnSaveComp.Size = new System.Drawing.Size(236, 70);
            this.btnSaveComp.TabIndex = 2;
            this.btnSaveComp.Text = "Save Changes";
            this.btnSaveComp.UseVisualStyleBackColor = true;
            this.btnSaveComp.Click += new System.EventHandler(this.btnSaveComp_Click);
            // 
            // gbCompAddress
            // 
            this.gbCompAddress.Controls.Add(this.label28);
            this.gbCompAddress.Controls.Add(this.txtCompZipCode);
            this.gbCompAddress.Controls.Add(this.label29);
            this.gbCompAddress.Controls.Add(this.txtCompState);
            this.gbCompAddress.Controls.Add(this.label30);
            this.gbCompAddress.Controls.Add(this.txtCompCity);
            this.gbCompAddress.Controls.Add(this.label25);
            this.gbCompAddress.Controls.Add(this.txtCompApptCode);
            this.gbCompAddress.Controls.Add(this.label26);
            this.gbCompAddress.Controls.Add(this.txtCompStreet2);
            this.gbCompAddress.Controls.Add(this.label27);
            this.gbCompAddress.Controls.Add(this.txtCompStreet1);
            this.gbCompAddress.Controls.Add(this.label24);
            this.gbCompAddress.Controls.Add(this.txtCompCountry);
            this.gbCompAddress.Controls.Add(this.label23);
            this.gbCompAddress.Controls.Add(this.txtCompEmail);
            this.gbCompAddress.Controls.Add(this.label22);
            this.gbCompAddress.Controls.Add(this.txtCompPhone);
            this.gbCompAddress.Location = new System.Drawing.Point(8, 532);
            this.gbCompAddress.Margin = new System.Windows.Forms.Padding(4);
            this.gbCompAddress.Name = "gbCompAddress";
            this.gbCompAddress.Padding = new System.Windows.Forms.Padding(4);
            this.gbCompAddress.Size = new System.Drawing.Size(1192, 222);
            this.gbCompAddress.TabIndex = 1;
            this.gbCompAddress.TabStop = false;
            this.gbCompAddress.Text = "Contact Information";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(880, 160);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 33);
            this.label28.TabIndex = 25;
            this.label28.Text = "Zip";
            // 
            // txtCompZipCode
            // 
            this.txtCompZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompZipCode.Location = new System.Drawing.Point(1000, 156);
            this.txtCompZipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompZipCode.Name = "txtCompZipCode";
            this.txtCompZipCode.Size = new System.Drawing.Size(188, 35);
            this.txtCompZipCode.TabIndex = 26;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(880, 104);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(82, 33);
            this.label29.TabIndex = 23;
            this.label29.Text = "State";
            // 
            // txtCompState
            // 
            this.txtCompState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompState.Location = new System.Drawing.Point(1000, 100);
            this.txtCompState.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompState.Name = "txtCompState";
            this.txtCompState.Size = new System.Drawing.Size(188, 35);
            this.txtCompState.TabIndex = 24;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(880, 48);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(66, 33);
            this.label30.TabIndex = 21;
            this.label30.Text = "City";
            // 
            // txtCompCity
            // 
            this.txtCompCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompCity.Location = new System.Drawing.Point(1000, 44);
            this.txtCompCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompCity.Name = "txtCompCity";
            this.txtCompCity.Size = new System.Drawing.Size(188, 35);
            this.txtCompCity.TabIndex = 22;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(476, 160);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 33);
            this.label25.TabIndex = 19;
            this.label25.Text = "Appt. #";
            // 
            // txtCompApptCode
            // 
            this.txtCompApptCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompApptCode.Location = new System.Drawing.Point(616, 156);
            this.txtCompApptCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompApptCode.Name = "txtCompApptCode";
            this.txtCompApptCode.Size = new System.Drawing.Size(228, 35);
            this.txtCompApptCode.TabIndex = 20;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(476, 104);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(116, 33);
            this.label26.TabIndex = 17;
            this.label26.Text = "Street 2";
            // 
            // txtCompStreet2
            // 
            this.txtCompStreet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompStreet2.Location = new System.Drawing.Point(616, 100);
            this.txtCompStreet2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompStreet2.Name = "txtCompStreet2";
            this.txtCompStreet2.Size = new System.Drawing.Size(228, 35);
            this.txtCompStreet2.TabIndex = 18;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(476, 48);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(116, 33);
            this.label27.TabIndex = 15;
            this.label27.Text = "Street 1";
            // 
            // txtCompStreet1
            // 
            this.txtCompStreet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompStreet1.Location = new System.Drawing.Point(616, 44);
            this.txtCompStreet1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompStreet1.Name = "txtCompStreet1";
            this.txtCompStreet1.Size = new System.Drawing.Size(228, 35);
            this.txtCompStreet1.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 160);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(117, 33);
            this.label24.TabIndex = 13;
            this.label24.Text = "Country";
            // 
            // txtCompCountry
            // 
            this.txtCompCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompCountry.Location = new System.Drawing.Point(222, 156);
            this.txtCompCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompCountry.Name = "txtCompCountry";
            this.txtCompCountry.Size = new System.Drawing.Size(228, 35);
            this.txtCompCountry.TabIndex = 14;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 104);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 33);
            this.label23.TabIndex = 11;
            this.label23.Text = "Email";
            // 
            // txtCompEmail
            // 
            this.txtCompEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompEmail.Location = new System.Drawing.Point(222, 100);
            this.txtCompEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompEmail.Name = "txtCompEmail";
            this.txtCompEmail.Size = new System.Drawing.Size(228, 35);
            this.txtCompEmail.TabIndex = 12;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 48);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(210, 33);
            this.label22.TabIndex = 9;
            this.label22.Text = "Phone Number";
            // 
            // txtCompPhone
            // 
            this.txtCompPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompPhone.Location = new System.Drawing.Point(222, 44);
            this.txtCompPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompPhone.Name = "txtCompPhone";
            this.txtCompPhone.Size = new System.Drawing.Size(228, 35);
            this.txtCompPhone.TabIndex = 10;
            // 
            // gbCompDemographics
            // 
            this.gbCompDemographics.Controls.Add(this.lblCompSchoolOther);
            this.gbCompDemographics.Controls.Add(this.lblCompInstructor);
            this.gbCompDemographics.Controls.Add(this.txtCompInstructor);
            this.gbCompDemographics.Controls.Add(this.btnSpecialConsiderationDetails);
            this.gbCompDemographics.Controls.Add(this.nudCompAge);
            this.gbCompDemographics.Controls.Add(this.lblAge);
            this.gbCompDemographics.Controls.Add(this.nudCompHeight);
            this.gbCompDemographics.Controls.Add(this.label31);
            this.gbCompDemographics.Controls.Add(this.cbCompBelt);
            this.gbCompDemographics.Controls.Add(this.chbCompIsInstructor);
            this.gbCompDemographics.Controls.Add(this.label21);
            this.gbCompDemographics.Controls.Add(this.txtCompSchoolOther);
            this.gbCompDemographics.Controls.Add(this.cbCompSchool);
            this.gbCompDemographics.Controls.Add(this.label20);
            this.gbCompDemographics.Controls.Add(this.gbCompParent);
            this.gbCompDemographics.Controls.Add(this.nudCompWeight);
            this.gbCompDemographics.Controls.Add(this.label19);
            this.gbCompDemographics.Controls.Add(this.rbCompMale);
            this.gbCompDemographics.Controls.Add(this.rbCompFemale);
            this.gbCompDemographics.Controls.Add(this.cbCompTitle);
            this.gbCompDemographics.Controls.Add(this.label16);
            this.gbCompDemographics.Controls.Add(this.chbCompSpecialConsideration);
            this.gbCompDemographics.Controls.Add(this.txtCompLastName);
            this.gbCompDemographics.Controls.Add(this.label15);
            this.gbCompDemographics.Controls.Add(this.txtCompFirstName);
            this.gbCompDemographics.Controls.Add(this.label14);
            this.gbCompDemographics.Location = new System.Drawing.Point(8, 56);
            this.gbCompDemographics.Margin = new System.Windows.Forms.Padding(4);
            this.gbCompDemographics.Name = "gbCompDemographics";
            this.gbCompDemographics.Padding = new System.Windows.Forms.Padding(4);
            this.gbCompDemographics.Size = new System.Drawing.Size(1192, 468);
            this.gbCompDemographics.TabIndex = 0;
            this.gbCompDemographics.TabStop = false;
            this.gbCompDemographics.Text = "Demographics";
            // 
            // btnSpecialConsiderationDetails
            // 
            this.btnSpecialConsiderationDetails.Enabled = false;
            this.btnSpecialConsiderationDetails.Location = new System.Drawing.Point(995, 289);
            this.btnSpecialConsiderationDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpecialConsiderationDetails.Name = "btnSpecialConsiderationDetails";
            this.btnSpecialConsiderationDetails.Size = new System.Drawing.Size(159, 50);
            this.btnSpecialConsiderationDetails.TabIndex = 6;
            this.btnSpecialConsiderationDetails.Text = "Details";
            this.btnSpecialConsiderationDetails.UseVisualStyleBackColor = true;
            this.btnSpecialConsiderationDetails.Click += new System.EventHandler(this.btnSpecialConsiderationDetails_Click);
            // 
            // nudCompAge
            // 
            this.nudCompAge.Location = new System.Drawing.Point(592, 134);
            this.nudCompAge.Margin = new System.Windows.Forms.Padding(4);
            this.nudCompAge.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudCompAge.Name = "nudCompAge";
            this.nudCompAge.Size = new System.Drawing.Size(122, 40);
            this.nudCompAge.TabIndex = 27;
            this.nudCompAge.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(427, 136);
            this.lblAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(66, 33);
            this.lblAge.TabIndex = 26;
            this.lblAge.Text = "Age";
            // 
            // nudCompHeight
            // 
            this.nudCompHeight.DecimalPlaces = 2;
            this.nudCompHeight.Location = new System.Drawing.Point(172, 284);
            this.nudCompHeight.Margin = new System.Windows.Forms.Padding(4);
            this.nudCompHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCompHeight.Name = "nudCompHeight";
            this.nudCompHeight.Size = new System.Drawing.Size(228, 40);
            this.nudCompHeight.TabIndex = 25;
            this.nudCompHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 284);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(150, 33);
            this.label31.TabIndex = 24;
            this.label31.Text = "Height (in)";
            // 
            // cbCompBelt
            // 
            this.cbCompBelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompBelt.FormattingEnabled = true;
            this.cbCompBelt.Location = new System.Drawing.Point(502, 208);
            this.cbCompBelt.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompBelt.Name = "cbCompBelt";
            this.cbCompBelt.Size = new System.Drawing.Size(212, 37);
            this.cbCompBelt.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(425, 208);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 33);
            this.label21.TabIndex = 22;
            this.label21.Text = "Belt";
            // 
            // txtCompSchoolOther
            // 
            this.txtCompSchoolOther.Enabled = false;
            this.txtCompSchoolOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompSchoolOther.Location = new System.Drawing.Point(881, 177);
            this.txtCompSchoolOther.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompSchoolOther.Name = "txtCompSchoolOther";
            this.txtCompSchoolOther.Size = new System.Drawing.Size(290, 35);
            this.txtCompSchoolOther.TabIndex = 21;
            // 
            // cbCompSchool
            // 
            this.cbCompSchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompSchool.FormattingEnabled = true;
            this.cbCompSchool.Location = new System.Drawing.Point(880, 127);
            this.cbCompSchool.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompSchool.Name = "cbCompSchool";
            this.cbCompSchool.Size = new System.Drawing.Size(290, 37);
            this.cbCompSchool.TabIndex = 20;
            this.cbCompSchool.SelectedIndexChanged += new System.EventHandler(this.cbCompSchool_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(767, 131);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 33);
            this.label20.TabIndex = 19;
            this.label20.Text = "School";
            // 
            // gbCompParent
            // 
            this.gbCompParent.Controls.Add(this.txtCompParentEmail);
            this.gbCompParent.Controls.Add(this.txtCompParentLastName);
            this.gbCompParent.Controls.Add(this.txtCompParentFirstName);
            this.gbCompParent.Controls.Add(this.label13);
            this.gbCompParent.Controls.Add(this.label12);
            this.gbCompParent.Controls.Add(this.label11);
            this.gbCompParent.Location = new System.Drawing.Point(12, 336);
            this.gbCompParent.Margin = new System.Windows.Forms.Padding(4);
            this.gbCompParent.Name = "gbCompParent";
            this.gbCompParent.Padding = new System.Windows.Forms.Padding(4);
            this.gbCompParent.Size = new System.Drawing.Size(1160, 122);
            this.gbCompParent.TabIndex = 1;
            this.gbCompParent.TabStop = false;
            this.gbCompParent.Text = "Parent (if minor)";
            // 
            // txtCompParentEmail
            // 
            this.txtCompParentEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompParentEmail.Location = new System.Drawing.Point(920, 56);
            this.txtCompParentEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompParentEmail.Name = "txtCompParentEmail";
            this.txtCompParentEmail.Size = new System.Drawing.Size(228, 35);
            this.txtCompParentEmail.TabIndex = 5;
            // 
            // txtCompParentLastName
            // 
            this.txtCompParentLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompParentLastName.Location = new System.Drawing.Point(576, 56);
            this.txtCompParentLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompParentLastName.Name = "txtCompParentLastName";
            this.txtCompParentLastName.Size = new System.Drawing.Size(228, 35);
            this.txtCompParentLastName.TabIndex = 4;
            // 
            // txtCompParentFirstName
            // 
            this.txtCompParentFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompParentFirstName.Location = new System.Drawing.Point(168, 56);
            this.txtCompParentFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompParentFirstName.Name = "txtCompParentFirstName";
            this.txtCompParentFirstName.Size = new System.Drawing.Size(228, 35);
            this.txtCompParentFirstName.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(824, 58);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 33);
            this.label13.TabIndex = 2;
            this.label13.Text = "Email";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(416, 58);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 33);
            this.label12.TabIndex = 1;
            this.label12.Text = "Last Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 33);
            this.label11.TabIndex = 0;
            this.label11.Text = "First Name";
            // 
            // nudCompWeight
            // 
            this.nudCompWeight.DecimalPlaces = 2;
            this.nudCompWeight.Location = new System.Drawing.Point(172, 208);
            this.nudCompWeight.Margin = new System.Windows.Forms.Padding(4);
            this.nudCompWeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCompWeight.Name = "nudCompWeight";
            this.nudCompWeight.Size = new System.Drawing.Size(228, 40);
            this.nudCompWeight.TabIndex = 18;
            this.nudCompWeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 208);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(156, 33);
            this.label19.TabIndex = 17;
            this.label19.Text = "Weight (lb)";
            // 
            // rbCompMale
            // 
            this.rbCompMale.AutoSize = true;
            this.rbCompMale.Location = new System.Drawing.Point(609, 54);
            this.rbCompMale.Margin = new System.Windows.Forms.Padding(4);
            this.rbCompMale.Name = "rbCompMale";
            this.rbCompMale.Size = new System.Drawing.Size(109, 37);
            this.rbCompMale.TabIndex = 15;
            this.rbCompMale.TabStop = true;
            this.rbCompMale.Text = "Male";
            this.rbCompMale.UseVisualStyleBackColor = true;
            // 
            // rbCompFemale
            // 
            this.rbCompFemale.AutoSize = true;
            this.rbCompFemale.Location = new System.Drawing.Point(431, 52);
            this.rbCompFemale.Margin = new System.Windows.Forms.Padding(4);
            this.rbCompFemale.Name = "rbCompFemale";
            this.rbCompFemale.Size = new System.Drawing.Size(144, 37);
            this.rbCompFemale.TabIndex = 14;
            this.rbCompFemale.TabStop = true;
            this.rbCompFemale.Text = "Female";
            this.rbCompFemale.UseVisualStyleBackColor = true;
            // 
            // cbCompTitle
            // 
            this.cbCompTitle.Enabled = false;
            this.cbCompTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompTitle.FormattingEnabled = true;
            this.cbCompTitle.Location = new System.Drawing.Point(882, 48);
            this.cbCompTitle.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompTitle.Name = "cbCompTitle";
            this.cbCompTitle.Size = new System.Drawing.Size(290, 37);
            this.cbCompTitle.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(776, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 33);
            this.label16.TabIndex = 12;
            this.label16.Text = "Title";
            // 
            // chbCompIsInstructor
            // 
            this.chbCompIsInstructor.AutoSize = true;
            this.chbCompIsInstructor.Location = new System.Drawing.Point(434, 292);
            this.chbCompIsInstructor.Margin = new System.Windows.Forms.Padding(4);
            this.chbCompIsInstructor.Name = "chbCompIsInstructor";
            this.chbCompIsInstructor.Size = new System.Drawing.Size(200, 37);
            this.chbCompIsInstructor.TabIndex = 11;
            this.chbCompIsInstructor.Text = "Is Instructor";
            this.chbCompIsInstructor.UseVisualStyleBackColor = true;
            this.chbCompIsInstructor.CheckedChanged += new System.EventHandler(this.chbCompIsInstructor_CheckedChanged);
            // 
            // chbCompSpecialConsideration
            // 
            this.chbCompSpecialConsideration.AutoSize = true;
            this.chbCompSpecialConsideration.Location = new System.Drawing.Point(645, 292);
            this.chbCompSpecialConsideration.Margin = new System.Windows.Forms.Padding(4);
            this.chbCompSpecialConsideration.Name = "chbCompSpecialConsideration";
            this.chbCompSpecialConsideration.Size = new System.Drawing.Size(331, 37);
            this.chbCompSpecialConsideration.TabIndex = 10;
            this.chbCompSpecialConsideration.Text = "Special Consideration";
            this.chbCompSpecialConsideration.UseVisualStyleBackColor = true;
            this.chbCompSpecialConsideration.CheckedChanged += new System.EventHandler(this.chbCompSpecialConsideration_CheckedChanged);
            // 
            // txtCompLastName
            // 
            this.txtCompLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompLastName.Location = new System.Drawing.Point(172, 132);
            this.txtCompLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompLastName.Name = "txtCompLastName";
            this.txtCompLastName.Size = new System.Drawing.Size(228, 35);
            this.txtCompLastName.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 58);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(159, 33);
            this.label15.TabIndex = 6;
            this.label15.Text = "First Name";
            // 
            // txtCompFirstName
            // 
            this.txtCompFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompFirstName.Location = new System.Drawing.Point(172, 56);
            this.txtCompFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompFirstName.Name = "txtCompFirstName";
            this.txtCompFirstName.Size = new System.Drawing.Size(228, 35);
            this.txtCompFirstName.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 136);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 33);
            this.label14.TabIndex = 7;
            this.label14.Text = "Last Name";
            // 
            // gbComp
            // 
            this.gbComp.Controls.Add(this.btnCompFilterApply);
            this.gbComp.Controls.Add(this.tlvComp);
            this.gbComp.Controls.Add(this.cbCompFilterBy);
            this.gbComp.Controls.Add(this.label9);
            this.gbComp.Controls.Add(this.txtCompFilter);
            this.gbComp.Controls.Add(this.label10);
            this.gbComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbComp.Location = new System.Drawing.Point(20, 8);
            this.gbComp.Margin = new System.Windows.Forms.Padding(4);
            this.gbComp.Name = "gbComp";
            this.gbComp.Padding = new System.Windows.Forms.Padding(4);
            this.gbComp.Size = new System.Drawing.Size(934, 916);
            this.gbComp.TabIndex = 4;
            this.gbComp.TabStop = false;
            this.gbComp.Text = "Competitors";
            // 
            // btnCompFilterApply
            // 
            this.btnCompFilterApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompFilterApply.Location = new System.Drawing.Point(784, 96);
            this.btnCompFilterApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompFilterApply.Name = "btnCompFilterApply";
            this.btnCompFilterApply.Size = new System.Drawing.Size(132, 50);
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
            this.tlvComp.IsSimpleDragSource = true;
            this.tlvComp.Location = new System.Drawing.Point(6, 152);
            this.tlvComp.Margin = new System.Windows.Forms.Padding(4);
            this.tlvComp.Name = "tlvComp";
            this.tlvComp.ShowGroups = false;
            this.tlvComp.Size = new System.Drawing.Size(912, 752);
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
            this.cbCompFilterBy.Location = new System.Drawing.Point(412, 100);
            this.cbCompFilterBy.Margin = new System.Windows.Forms.Padding(4);
            this.cbCompFilterBy.Name = "cbCompFilterBy";
            this.cbCompFilterBy.Size = new System.Drawing.Size(350, 41);
            this.cbCompFilterBy.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 33);
            this.label9.TabIndex = 3;
            this.label9.Text = "Filter by:";
            // 
            // txtCompFilter
            // 
            this.txtCompFilter.Location = new System.Drawing.Point(24, 100);
            this.txtCompFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompFilter.Name = "txtCompFilter";
            this.txtCompFilter.Size = new System.Drawing.Size(362, 40);
            this.txtCompFilter.TabIndex = 2;
            this.txtCompFilter.TextChanged += new System.EventHandler(this.txtCompFilter_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 56);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 33);
            this.label10.TabIndex = 1;
            this.label10.Text = "Filter:";
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
            this.msMenu.Size = new System.Drawing.Size(2280, 40);
            this.msMenu.TabIndex = 4;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryConnectionToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(64, 36);
            this.miFile.Text = "File";
            // 
            // retryConnectionToolStripMenuItem
            // 
            this.retryConnectionToolStripMenuItem.Name = "retryConnectionToolStripMenuItem";
            this.retryConnectionToolStripMenuItem.Size = new System.Drawing.Size(298, 38);
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
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(86, 36);
            this.eventToolStripMenuItem.Text = "Event";
            // 
            // submsRefreshEvent
            // 
            this.submsRefreshEvent.Name = "submsRefreshEvent";
            this.submsRefreshEvent.Size = new System.Drawing.Size(328, 38);
            this.submsRefreshEvent.Text = "Refresh Events";
            this.submsRefreshEvent.Click += new System.EventHandler(this.submsRefreshEvent_Click);
            // 
            // submsNewEvent
            // 
            this.submsNewEvent.Name = "submsNewEvent";
            this.submsNewEvent.Size = new System.Drawing.Size(328, 38);
            this.submsNewEvent.Text = "Save as New Event";
            this.submsNewEvent.Click += new System.EventHandler(this.submsNewEvent_Click);
            // 
            // submsSaveEvent
            // 
            this.submsSaveEvent.Name = "submsSaveEvent";
            this.submsSaveEvent.Size = new System.Drawing.Size(328, 38);
            this.submsSaveEvent.Text = "Save Selected Event";
            this.submsSaveEvent.Click += new System.EventHandler(this.submsSaveEvent_Click);
            // 
            // submsClearEventSelection
            // 
            this.submsClearEventSelection.Name = "submsClearEventSelection";
            this.submsClearEventSelection.Size = new System.Drawing.Size(328, 38);
            this.submsClearEventSelection.Text = "Clear Selection";
            this.submsClearEventSelection.Click += new System.EventHandler(this.submsClearEventSelection_Click);
            // 
            // submsDeleteEvent
            // 
            this.submsDeleteEvent.Name = "submsDeleteEvent";
            this.submsDeleteEvent.Size = new System.Drawing.Size(328, 38);
            this.submsDeleteEvent.Text = "Delete Event";
            this.submsDeleteEvent.Click += new System.EventHandler(this.submsDeleteEvent_Click);
            // 
            // msMatches
            // 
            this.msMatches.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewMatchToolStripMenuItem,
            this.deleteMatchToolStripMenuItem,
            this.clearFiltersToolStripMenuItem,
            this.refreshMatchAndCompetitorListsToolStripMenuItem,
            this.matchSelectionAssistantToolStripMenuItem});
            this.msMatches.Enabled = false;
            this.msMatches.Name = "msMatches";
            this.msMatches.Size = new System.Drawing.Size(94, 36);
            this.msMatches.Text = "Match";
            // 
            // createNewMatchToolStripMenuItem
            // 
            this.createNewMatchToolStripMenuItem.Enabled = false;
            this.createNewMatchToolStripMenuItem.Name = "createNewMatchToolStripMenuItem";
            this.createNewMatchToolStripMenuItem.Size = new System.Drawing.Size(494, 38);
            this.createNewMatchToolStripMenuItem.Text = "New Match";
            this.createNewMatchToolStripMenuItem.Click += new System.EventHandler(this.createNewMatchToolStripMenuItem_Click);
            // 
            // deleteMatchToolStripMenuItem
            // 
            this.deleteMatchToolStripMenuItem.Name = "deleteMatchToolStripMenuItem";
            this.deleteMatchToolStripMenuItem.Size = new System.Drawing.Size(494, 38);
            this.deleteMatchToolStripMenuItem.Text = "Delete Selected Match";
            // 
            // clearFiltersToolStripMenuItem
            // 
            this.clearFiltersToolStripMenuItem.Name = "clearFiltersToolStripMenuItem";
            this.clearFiltersToolStripMenuItem.Size = new System.Drawing.Size(494, 38);
            this.clearFiltersToolStripMenuItem.Text = "Clear Filters";
            this.clearFiltersToolStripMenuItem.Click += new System.EventHandler(this.clearFiltersToolStripMenuItem_Click);
            // 
            // refreshMatchAndCompetitorListsToolStripMenuItem
            // 
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Name = "refreshMatchAndCompetitorListsToolStripMenuItem";
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Size = new System.Drawing.Size(494, 38);
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Text = "Refresh Match and Competitor Lists";
            this.refreshMatchAndCompetitorListsToolStripMenuItem.Click += new System.EventHandler(this.refreshMatchAndCompetitorListsToolStripMenuItem_Click);
            // 
            // matchSelectionAssistantToolStripMenuItem
            // 
            this.matchSelectionAssistantToolStripMenuItem.Name = "matchSelectionAssistantToolStripMenuItem";
            this.matchSelectionAssistantToolStripMenuItem.Size = new System.Drawing.Size(494, 38);
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
            this.msCompetitor.Size = new System.Drawing.Size(148, 36);
            this.msCompetitor.Text = "Competitor";
            // 
            // clearSelectionToolStripMenuItem1
            // 
            this.clearSelectionToolStripMenuItem1.Name = "clearSelectionToolStripMenuItem1";
            this.clearSelectionToolStripMenuItem1.Size = new System.Drawing.Size(410, 38);
            this.clearSelectionToolStripMenuItem1.Text = "Clear Selection";
            this.clearSelectionToolStripMenuItem1.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem1_Click);
            // 
            // newCompetitorToolStripMenuItem
            // 
            this.newCompetitorToolStripMenuItem.Name = "newCompetitorToolStripMenuItem";
            this.newCompetitorToolStripMenuItem.Size = new System.Drawing.Size(410, 38);
            this.newCompetitorToolStripMenuItem.Text = "Save as New Competitor";
            this.newCompetitorToolStripMenuItem.Click += new System.EventHandler(this.newCompetitorToolStripMenuItem_Click);
            // 
            // editSelectedCompetitorToolStripMenuItem
            // 
            this.editSelectedCompetitorToolStripMenuItem.Name = "editSelectedCompetitorToolStripMenuItem";
            this.editSelectedCompetitorToolStripMenuItem.Size = new System.Drawing.Size(410, 38);
            this.editSelectedCompetitorToolStripMenuItem.Text = "Save Selected Competitor";
            this.editSelectedCompetitorToolStripMenuItem.Click += new System.EventHandler(this.editSelectedCompetitorToolStripMenuItem_Click);
            // 
            // deleteSelectedCompetitorToolStripMenuItem
            // 
            this.deleteSelectedCompetitorToolStripMenuItem.Name = "deleteSelectedCompetitorToolStripMenuItem";
            this.deleteSelectedCompetitorToolStripMenuItem.Size = new System.Drawing.Size(410, 38);
            this.deleteSelectedCompetitorToolStripMenuItem.Text = "Delete Selected Competitor";
            this.deleteSelectedCompetitorToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedCompetitorToolStripMenuItem_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(77, 36);
            this.miHelp.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(329, 38);
            this.helpToolStripMenuItem1.Text = "Knowledge Base";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(329, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnRetryConnection
            // 
            this.btnRetryConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetryConnection.Location = new System.Drawing.Point(908, 1044);
            this.btnRetryConnection.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetryConnection.Name = "btnRetryConnection";
            this.btnRetryConnection.Size = new System.Drawing.Size(536, 72);
            this.btnRetryConnection.TabIndex = 5;
            this.btnRetryConnection.Text = "Retry Connection";
            this.btnRetryConnection.UseVisualStyleBackColor = true;
            this.btnRetryConnection.Visible = false;
            this.btnRetryConnection.Click += new System.EventHandler(this.btnRetryConnection_Click);
            // 
            // btnRefreshMatchTab
            // 
            this.btnRefreshMatchTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshMatchTab.Location = new System.Drawing.Point(956, 1044);
            this.btnRefreshMatchTab.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshMatchTab.Name = "btnRefreshMatchTab";
            this.btnRefreshMatchTab.Size = new System.Drawing.Size(372, 72);
            this.btnRefreshMatchTab.TabIndex = 6;
            this.btnRefreshMatchTab.Text = "Refresh List Data";
            this.btnRefreshMatchTab.UseVisualStyleBackColor = true;
            this.btnRefreshMatchTab.Visible = false;
            this.btnRefreshMatchTab.Click += new System.EventHandler(this.btnRefreshMatchTab_Click);
            // 
            // btnClearMatchFilter
            // 
            this.btnClearMatchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMatchFilter.Location = new System.Drawing.Point(1424, 1044);
            this.btnClearMatchFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearMatchFilter.Name = "btnClearMatchFilter";
            this.btnClearMatchFilter.Size = new System.Drawing.Size(536, 72);
            this.btnClearMatchFilter.TabIndex = 7;
            this.btnClearMatchFilter.Text = "Clear Match Filter";
            this.btnClearMatchFilter.UseVisualStyleBackColor = true;
            this.btnClearMatchFilter.Visible = false;
            this.btnClearMatchFilter.Click += new System.EventHandler(this.btnClearMatchFilter_Click);
            // 
            // tmrMatchCompetitorRefresh
            // 
            this.tmrMatchCompetitorRefresh.Interval = 250;
            this.tmrMatchCompetitorRefresh.Tick += new System.EventHandler(this.tmrMatchCompetitorRefresh_Tick);
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
            this.cmiDeleteMatch,
            this.cmiRemoveCompetitors,
            this.cmiViewMatchDetails});
            this.cmsMatches.Name = "cmsMatches";
            this.cmsMatches.Size = new System.Drawing.Size(329, 220);
            // 
            // cmiMatchesExpandAll
            // 
            this.cmiMatchesExpandAll.Name = "cmiMatchesExpandAll";
            this.cmiMatchesExpandAll.Size = new System.Drawing.Size(328, 36);
            this.cmiMatchesExpandAll.Text = "&Expand All";
            this.cmiMatchesExpandAll.Click += new System.EventHandler(this.cmiMatchesExpandAll_Click);
            // 
            // cmiMatchesCollapseAll
            // 
            this.cmiMatchesCollapseAll.Name = "cmiMatchesCollapseAll";
            this.cmiMatchesCollapseAll.Size = new System.Drawing.Size(328, 36);
            this.cmiMatchesCollapseAll.Text = "&Collapse All";
            this.cmiMatchesCollapseAll.Click += new System.EventHandler(this.cmiMatchesCollapseAll_Click);
            // 
            // cmiMatchNewMatch
            // 
            this.cmiMatchNewMatch.Name = "cmiMatchNewMatch";
            this.cmiMatchNewMatch.Size = new System.Drawing.Size(328, 36);
            this.cmiMatchNewMatch.Text = "&New Match";
            this.cmiMatchNewMatch.Click += new System.EventHandler(this.newMatchToolStripMenuItem_Click);
            // 
            // cmiDeleteMatch
            // 
            this.cmiDeleteMatch.Name = "cmiDeleteMatch";
            this.cmiDeleteMatch.Size = new System.Drawing.Size(328, 36);
            this.cmiDeleteMatch.Text = "&Delete Match";
            this.cmiDeleteMatch.Click += new System.EventHandler(this.cmiDeleteMatch_Click);
            // 
            // cmiRemoveCompetitors
            // 
            this.cmiRemoveCompetitors.Name = "cmiRemoveCompetitors";
            this.cmiRemoveCompetitors.Size = new System.Drawing.Size(328, 36);
            this.cmiRemoveCompetitors.Text = "&Remove Competitor(s)";
            this.cmiRemoveCompetitors.Click += new System.EventHandler(this.removeCompetitorsToolStripMenuItem_Click);
            // 
            // cmiViewMatchDetails
            // 
            this.cmiViewMatchDetails.Name = "cmiViewMatchDetails";
            this.cmiViewMatchDetails.Size = new System.Drawing.Size(328, 36);
            this.cmiViewMatchDetails.Text = "View Match Details";
            this.cmiViewMatchDetails.Click += new System.EventHandler(this.cmiViewMatchDetails_Click);
            // 
            // btnClearCompetitorFilter
            // 
            this.btnClearCompetitorFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCompetitorFilter.Location = new System.Drawing.Point(336, 1044);
            this.btnClearCompetitorFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCompetitorFilter.Name = "btnClearCompetitorFilter";
            this.btnClearCompetitorFilter.Size = new System.Drawing.Size(536, 72);
            this.btnClearCompetitorFilter.TabIndex = 8;
            this.btnClearCompetitorFilter.Text = "Clear Competitor Filter";
            this.btnClearCompetitorFilter.UseVisualStyleBackColor = true;
            this.btnClearCompetitorFilter.Visible = false;
            this.btnClearCompetitorFilter.Click += new System.EventHandler(this.btnClearCompetitorFilter_Click);
            // 
            // pbCompany
            // 
            this.pbCompany.Image = global::DKK_App.Properties.Resources.dkk_logo_medium_horizontal;
            this.pbCompany.Location = new System.Drawing.Point(12, 1044);
            this.pbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.pbCompany.Name = "pbCompany";
            this.pbCompany.Size = new System.Drawing.Size(282, 72);
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
            this.pbPoweredBy.Image = global::DKK_App.Properties.Resources.powered_by_sqlhammer;
            this.pbPoweredBy.Location = new System.Drawing.Point(1986, 1042);
            this.pbPoweredBy.Margin = new System.Windows.Forms.Padding(4);
            this.pbPoweredBy.Name = "pbPoweredBy";
            this.pbPoweredBy.Size = new System.Drawing.Size(282, 72);
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
            this.cmsCompetitor.Size = new System.Drawing.Size(250, 76);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(249, 36);
            this.clearSelectionToolStripMenuItem.Text = "&Clear Selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(249, 36);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tmrCompTab
            // 
            this.tmrCompTab.Interval = 250;
            this.tmrCompTab.Tick += new System.EventHandler(this.tmrCompTab_Tick);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(289, 432);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(1735, 108);
            this.lblConnection.TabIndex = 9;
            this.lblConnection.Text = "Attempting to connect to the database...";
            // 
            // tmrRegistrations
            // 
            this.tmrRegistrations.Interval = 1000;
            // 
            // txtCompInstructor
            // 
            this.txtCompInstructor.Enabled = false;
            this.txtCompInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompInstructor.Location = new System.Drawing.Point(880, 238);
            this.txtCompInstructor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompInstructor.Name = "txtCompInstructor";
            this.txtCompInstructor.Size = new System.Drawing.Size(290, 35);
            this.txtCompInstructor.TabIndex = 28;
            // 
            // lblCompInstructor
            // 
            this.lblCompInstructor.AutoSize = true;
            this.lblCompInstructor.Location = new System.Drawing.Point(738, 237);
            this.lblCompInstructor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompInstructor.Name = "lblCompInstructor";
            this.lblCompInstructor.Size = new System.Drawing.Size(137, 33);
            this.lblCompInstructor.TabIndex = 29;
            this.lblCompInstructor.Text = "Instructor";
            // 
            // lblCompSchoolOther
            // 
            this.lblCompSchoolOther.AutoSize = true;
            this.lblCompSchoolOther.Location = new System.Drawing.Point(767, 176);
            this.lblCompSchoolOther.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompSchoolOther.Name = "lblCompSchoolOther";
            this.lblCompSchoolOther.Size = new System.Drawing.Size(108, 33);
            this.lblCompSchoolOther.TabIndex = 30;
            this.lblCompSchoolOther.Text = "(Other)";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2280, 1102);
            this.Controls.Add(this.lblCompLoading);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnClearCompetitorFilter);
            this.Controls.Add(this.btnClearMatchFilter);
            this.Controls.Add(this.btnRefreshMatchTab);
            this.Controls.Add(this.btnRetryConnection);
            this.Controls.Add(this.pbCompany);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.pbPoweredBy);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1740, 1007);
            this.Name = "frmMain";
            this.Text = "Event Hammer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tab1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.gbAdmin.ResumeLayout(false);
            this.gbEvent.ResumeLayout(false);
            this.gbEvent.PerformLayout();
            this.gbScorecards.ResumeLayout(false);
            this.gbScorecards.PerformLayout();
            this.tabEvents.ResumeLayout(false);
            this.gbEventDetails.ResumeLayout(false);
            this.gbEventDetails.PerformLayout();
            this.gbEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlvEvents)).EndInit();
            this.tabMatch.ResumeLayout(false);
            this.tabMatch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).EndInit();
            this.tabCompetitor.ResumeLayout(false);
            this.gbCompetitorDetails.ResumeLayout(false);
            this.gbCompAddress.ResumeLayout(false);
            this.gbCompAddress.PerformLayout();
            this.gbCompDemographics.ResumeLayout(false);
            this.gbCompDemographics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompHeight)).EndInit();
            this.gbCompParent.ResumeLayout(false);
            this.gbCompParent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompWeight)).EndInit();
            this.gbComp.ResumeLayout(false);
            this.gbComp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvComp)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.cmsMatches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).EndInit();
            this.cmsCompetitor.ResumeLayout(false);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEventTo;
        private System.Windows.Forms.DateTimePicker dtpEventFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventInfo;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.GroupBox gbScorecards;
        private System.Windows.Forms.Button btnKnockdown;
        private System.Windows.Forms.Button btnSemiKnockdown;
        private System.Windows.Forms.Button btnWeaponKata;
        private System.Windows.Forms.Button btnKata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRetryConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbApplicableMatches;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.TextBox txtCompetitorFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMatchFilterBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMatchFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCompetitorFilterBy;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.Button btnRefreshMatchTab;
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCompFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbCompetitorDetails;
        private System.Windows.Forms.GroupBox gbCompParent;
        private System.Windows.Forms.GroupBox gbCompAddress;
        private System.Windows.Forms.GroupBox gbCompDemographics;
        private System.Windows.Forms.TextBox txtCompParentEmail;
        private System.Windows.Forms.TextBox txtCompParentLastName;
        private System.Windows.Forms.TextBox txtCompParentFirstName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chbCompIsInstructor;
        private System.Windows.Forms.CheckBox chbCompSpecialConsideration;
        private System.Windows.Forms.TextBox txtCompLastName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCompFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbCompMale;
        private System.Windows.Forms.RadioButton rbCompFemale;
        private System.Windows.Forms.ComboBox cbCompTitle;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudCompWeight;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCompSchoolOther;
        private System.Windows.Forms.ComboBox cbCompSchool;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbCompBelt;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtCompCountry;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtCompEmail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCompPhone;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtCompZipCode;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtCompState;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtCompCity;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCompApptCode;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCompStreet2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCompStreet1;
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
        private System.Windows.Forms.NumericUpDown nudCompHeight;
        private System.Windows.Forms.Label label31;
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
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
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
        private System.Windows.Forms.NumericUpDown nudCompAge;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnSpecialConsiderationDetails;
        private System.Windows.Forms.ToolStripMenuItem matchSelectionAssistantToolStripMenuItem;
        private System.Windows.Forms.Button btnEventLoadReg;
        private System.Windows.Forms.Timer tmrRegistrations;
        private System.Windows.Forms.ToolStripMenuItem cmiRemoveCompetitors;
        private System.Windows.Forms.ToolStripMenuItem cmiViewMatchDetails;
        private System.Windows.Forms.Label lblCompInstructor;
        private System.Windows.Forms.TextBox txtCompInstructor;
        private System.Windows.Forms.Label lblCompSchoolOther;
    }
}