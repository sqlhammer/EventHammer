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
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbScorecards = new System.Windows.Forms.GroupBox();
            this.btnKnockdown = new System.Windows.Forms.Button();
            this.btnSemiKnockdown = new System.Windows.Forms.Button();
            this.btnWeaponKata = new System.Windows.Forms.Button();
            this.btnKata = new System.Windows.Forms.Button();
            this.gbEvent = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEventTo = new System.Windows.Forms.DateTimePicker();
            this.dtpEventFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventInfo = new System.Windows.Forms.TextBox();
            this.lblEventSelect = new System.Windows.Forms.Label();
            this.cbEventSelect = new System.Windows.Forms.ComboBox();
            this.tabMatch = new System.Windows.Forms.TabPage();
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
            this.imgList = new System.Windows.Forms.ImageList(this.components);
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
            this.cbCompetitorFilterBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompetitorFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miEventManager = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshEventSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCompany = new System.Windows.Forms.PictureBox();
            this.pbPoweredBy = new System.Windows.Forms.PictureBox();
            this.btnRetryConnection = new System.Windows.Forms.Button();
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.btnRefreshMatchTab = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshMatchAndCompetitorListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retryConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLoading = new System.Windows.Forms.Label();
            this.tmrMatchCompetitorRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrDivisions = new System.Windows.Forms.Timer(this.components);
            this.tab1.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.gbReports.SuspendLayout();
            this.gbScorecards.SuspendLayout();
            this.gbEvent.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).BeginInit();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).BeginInit();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabHome);
            this.tab1.Controls.Add(this.tabMatch);
            this.tab1.Location = new System.Drawing.Point(12, 49);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(2257, 988);
            this.tab1.TabIndex = 1;
            this.tab1.SelectedIndexChanged += new System.EventHandler(this.tab1_SelectedIndexChanged);
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.gbReports);
            this.tabHome.Controls.Add(this.gbEvent);
            this.tabHome.Location = new System.Drawing.Point(8, 39);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(2241, 941);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // gbReports
            // 
            this.gbReports.Controls.Add(this.label3);
            this.gbReports.Controls.Add(this.gbScorecards);
            this.gbReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReports.Location = new System.Drawing.Point(611, 6);
            this.gbReports.Name = "gbReports";
            this.gbReports.Size = new System.Drawing.Size(1107, 356);
            this.gbReports.TabIndex = 1;
            this.gbReports.TabStop = false;
            this.gbReports.Text = "Reports";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username: reports - Password: reports";
            // 
            // gbScorecards
            // 
            this.gbScorecards.Controls.Add(this.btnKnockdown);
            this.gbScorecards.Controls.Add(this.btnSemiKnockdown);
            this.gbScorecards.Controls.Add(this.btnWeaponKata);
            this.gbScorecards.Controls.Add(this.btnKata);
            this.gbScorecards.Location = new System.Drawing.Point(15, 53);
            this.gbScorecards.Name = "gbScorecards";
            this.gbScorecards.Size = new System.Drawing.Size(1074, 213);
            this.gbScorecards.TabIndex = 0;
            this.gbScorecards.TabStop = false;
            this.gbScorecards.Text = "Scorecards";
            // 
            // btnKnockdown
            // 
            this.btnKnockdown.Location = new System.Drawing.Point(851, 54);
            this.btnKnockdown.Name = "btnKnockdown";
            this.btnKnockdown.Size = new System.Drawing.Size(200, 100);
            this.btnKnockdown.TabIndex = 3;
            this.btnKnockdown.Text = "Knockdown";
            this.btnKnockdown.UseVisualStyleBackColor = true;
            this.btnKnockdown.Click += new System.EventHandler(this.btnKnockdown_Click);
            // 
            // btnSemiKnockdown
            // 
            this.btnSemiKnockdown.Location = new System.Drawing.Point(569, 54);
            this.btnSemiKnockdown.Name = "btnSemiKnockdown";
            this.btnSemiKnockdown.Size = new System.Drawing.Size(200, 100);
            this.btnSemiKnockdown.TabIndex = 2;
            this.btnSemiKnockdown.Text = "Semi Knockdown";
            this.btnSemiKnockdown.UseVisualStyleBackColor = true;
            this.btnSemiKnockdown.Click += new System.EventHandler(this.btnSemiKnockdown_Click);
            // 
            // btnWeaponKata
            // 
            this.btnWeaponKata.Location = new System.Drawing.Point(292, 54);
            this.btnWeaponKata.Name = "btnWeaponKata";
            this.btnWeaponKata.Size = new System.Drawing.Size(200, 100);
            this.btnWeaponKata.TabIndex = 1;
            this.btnWeaponKata.Text = "Weapon Kata";
            this.btnWeaponKata.UseVisualStyleBackColor = true;
            this.btnWeaponKata.Click += new System.EventHandler(this.btnWeaponKata_Click);
            // 
            // btnKata
            // 
            this.btnKata.Location = new System.Drawing.Point(21, 54);
            this.btnKata.Name = "btnKata";
            this.btnKata.Size = new System.Drawing.Size(200, 100);
            this.btnKata.TabIndex = 0;
            this.btnKata.Text = "Kata";
            this.btnKata.UseVisualStyleBackColor = true;
            this.btnKata.Click += new System.EventHandler(this.btnKata_Click);
            // 
            // gbEvent
            // 
            this.gbEvent.Controls.Add(this.label2);
            this.gbEvent.Controls.Add(this.dtpEventTo);
            this.gbEvent.Controls.Add(this.dtpEventFrom);
            this.gbEvent.Controls.Add(this.label1);
            this.gbEvent.Controls.Add(this.txtEventInfo);
            this.gbEvent.Controls.Add(this.lblEventSelect);
            this.gbEvent.Controls.Add(this.cbEventSelect);
            this.gbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEvent.Location = new System.Drawing.Point(6, 6);
            this.gbEvent.Name = "gbEvent";
            this.gbEvent.Size = new System.Drawing.Size(573, 356);
            this.gbEvent.TabIndex = 0;
            this.gbEvent.TabStop = false;
            this.gbEvent.Text = "Select Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 45);
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
            this.dtpEventTo.Name = "dtpEventTo";
            this.dtpEventTo.Size = new System.Drawing.Size(200, 35);
            this.dtpEventTo.TabIndex = 5;
            this.dtpEventTo.ValueChanged += new System.EventHandler(this.dtpEventTo_ValueChanged);
            // 
            // dtpEventFrom
            // 
            this.dtpEventFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventFrom.Location = new System.Drawing.Point(91, 42);
            this.dtpEventFrom.Name = "dtpEventFrom";
            this.dtpEventFrom.Size = new System.Drawing.Size(200, 35);
            this.dtpEventFrom.TabIndex = 4;
            this.dtpEventFrom.ValueChanged += new System.EventHandler(this.dtpEventFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // txtEventInfo
            // 
            this.txtEventInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventInfo.Location = new System.Drawing.Point(11, 147);
            this.txtEventInfo.Multiline = true;
            this.txtEventInfo.Name = "txtEventInfo";
            this.txtEventInfo.Size = new System.Drawing.Size(547, 195);
            this.txtEventInfo.TabIndex = 2;
            // 
            // lblEventSelect
            // 
            this.lblEventSelect.AutoSize = true;
            this.lblEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventSelect.Location = new System.Drawing.Point(6, 96);
            this.lblEventSelect.Name = "lblEventSelect";
            this.lblEventSelect.Size = new System.Drawing.Size(153, 29);
            this.lblEventSelect.TabIndex = 1;
            this.lblEventSelect.Text = "Select Event:";
            // 
            // cbEventSelect
            // 
            this.cbEventSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventSelect.FormattingEnabled = true;
            this.cbEventSelect.Location = new System.Drawing.Point(165, 93);
            this.cbEventSelect.Name = "cbEventSelect";
            this.cbEventSelect.Size = new System.Drawing.Size(393, 37);
            this.cbEventSelect.TabIndex = 0;
            this.cbEventSelect.SelectedIndexChanged += new System.EventHandler(this.cbEventSelect_SelectedIndexChanged);
            // 
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.lblLoading);
            this.tabMatch.Controls.Add(this.groupBox2);
            this.tabMatch.Controls.Add(this.groupBox1);
            this.tabMatch.Controls.Add(this.label4);
            this.tabMatch.Location = new System.Drawing.Point(8, 39);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(2241, 941);
            this.tabMatch.TabIndex = 1;
            this.tabMatch.Text = "Matches";
            this.tabMatch.UseVisualStyleBackColor = true;
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
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1127, 917);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Matches";
            // 
            // btnMatchApply
            // 
            this.btnMatchApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatchApply.Location = new System.Drawing.Point(951, 97);
            this.btnMatchApply.Name = "btnMatchApply";
            this.btnMatchApply.Size = new System.Drawing.Size(133, 50);
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
            this.tlvMatches.CellEditUseWholeCell = false;
            this.tlvMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColDivDisplay,
            this.olvColMatchType,
            this.olvColDisplayName,
            this.olvColRankName,
            this.olvColAge,
            this.olvColWeight,
            this.olvColDojo});
            this.tlvMatches.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvMatches.Location = new System.Drawing.Point(7, 160);
            this.tlvMatches.Name = "tlvMatches";
            this.tlvMatches.ShowGroups = false;
            this.tlvMatches.Size = new System.Drawing.Size(1114, 751);
            this.tlvMatches.SmallImageList = this.imgList;
            this.tlvMatches.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvMatches.TabIndex = 10;
            this.tlvMatches.UseCompatibleStateImageBehavior = false;
            this.tlvMatches.View = System.Windows.Forms.View.Details;
            this.tlvMatches.VirtualMode = true;
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
            this.olvColDojo.Text = "School";
            this.olvColDojo.Width = 120;
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cbMatchFilterBy
            // 
            this.cbMatchFilterBy.FormattingEnabled = true;
            this.cbMatchFilterBy.Location = new System.Drawing.Point(554, 101);
            this.cbMatchFilterBy.Name = "cbMatchFilterBy";
            this.cbMatchFilterBy.Size = new System.Drawing.Size(349, 41);
            this.cbMatchFilterBy.TabIndex = 8;
            // 
            // rbApplicableMatches
            // 
            this.rbApplicableMatches.AutoSize = true;
            this.rbApplicableMatches.Enabled = false;
            this.rbApplicableMatches.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApplicableMatches.Location = new System.Drawing.Point(20, 91);
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
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "Filter by:";
            // 
            // txtMatchFilter
            // 
            this.txtMatchFilter.Location = new System.Drawing.Point(219, 101);
            this.txtMatchFilter.Name = "txtMatchFilter";
            this.txtMatchFilter.Size = new System.Drawing.Size(286, 40);
            this.txtMatchFilter.TabIndex = 6;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Enabled = false;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAll.Location = new System.Drawing.Point(21, 56);
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
            this.label8.Location = new System.Drawing.Point(213, 56);
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
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 917);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Competitors";
            // 
            // btnCompetitorApply
            // 
            this.btnCompetitorApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompetitorApply.Location = new System.Drawing.Point(784, 97);
            this.btnCompetitorApply.Name = "btnCompetitorApply";
            this.btnCompetitorApply.Size = new System.Drawing.Size(133, 50);
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
            this.tlvCompetitors.AllowDrop = true;
            this.tlvCompetitors.CellEditUseWholeCell = false;
            this.tlvCompetitors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColCompDisplayName,
            this.olvColCompRankName,
            this.olvColCompAge,
            this.olvColCompWeight});
            this.tlvCompetitors.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvCompetitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvCompetitors.Location = new System.Drawing.Point(0, 160);
            this.tlvCompetitors.Name = "tlvCompetitors";
            this.tlvCompetitors.ShowGroups = false;
            this.tlvCompetitors.Size = new System.Drawing.Size(928, 751);
            this.tlvCompetitors.SmallImageList = this.imgList;
            this.tlvCompetitors.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tlvCompetitors.TabIndex = 11;
            this.tlvCompetitors.UseCompatibleStateImageBehavior = false;
            this.tlvCompetitors.View = System.Windows.Forms.View.Details;
            this.tlvCompetitors.VirtualMode = true;
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
            // cbCompetitorFilterBy
            // 
            this.cbCompetitorFilterBy.FormattingEnabled = true;
            this.cbCompetitorFilterBy.Location = new System.Drawing.Point(413, 101);
            this.cbCompetitorFilterBy.Name = "cbCompetitorFilterBy";
            this.cbCompetitorFilterBy.Size = new System.Drawing.Size(350, 41);
            this.cbCompetitorFilterBy.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 33);
            this.label6.TabIndex = 3;
            this.label6.Text = "Filter by:";
            // 
            // txtCompetitorFilter
            // 
            this.txtCompetitorFilter.Location = new System.Drawing.Point(24, 101);
            this.txtCompetitorFilter.Name = "txtCompetitorFilter";
            this.txtCompetitorFilter.Size = new System.Drawing.Size(362, 40);
            this.txtCompetitorFilter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 33);
            this.label5.TabIndex = 1;
            this.label5.Text = "Filter:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(985, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 378);
            this.label4.TabIndex = 2;
            this.label4.Text = ">\r\n\r\nDrag\r\n\r\nand\r\n\r\nDrop\r\n\r\n>";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // msMenu
            // 
            this.msMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.matchToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(2281, 40);
            this.msMenu.TabIndex = 4;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEventManager,
            this.refreshEventSelectionToolStripMenuItem,
            this.retryConnectionToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(64, 36);
            this.miFile.Text = "File";
            // 
            // miEventManager
            // 
            this.miEventManager.Name = "miEventManager";
            this.miEventManager.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.miEventManager.Size = new System.Drawing.Size(404, 38);
            this.miEventManager.Text = "Event Manager";
            this.miEventManager.Click += new System.EventHandler(this.newEventToolStripMenuItem_Click);
            // 
            // refreshEventSelectionToolStripMenuItem
            // 
            this.refreshEventSelectionToolStripMenuItem.Name = "refreshEventSelectionToolStripMenuItem";
            this.refreshEventSelectionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshEventSelectionToolStripMenuItem.Size = new System.Drawing.Size(404, 38);
            this.refreshEventSelectionToolStripMenuItem.Text = "Refresh Event Selection";
            this.refreshEventSelectionToolStripMenuItem.Click += new System.EventHandler(this.refreshEventSelectionToolStripMenuItem_Click);
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
            // btnRetryConnection
            // 
            this.btnRetryConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetryConnection.Location = new System.Drawing.Point(909, 1044);
            this.btnRetryConnection.Name = "btnRetryConnection";
            this.btnRetryConnection.Size = new System.Drawing.Size(535, 73);
            this.btnRetryConnection.TabIndex = 5;
            this.btnRetryConnection.Text = "Retry Connection";
            this.btnRetryConnection.UseVisualStyleBackColor = true;
            this.btnRetryConnection.Visible = false;
            this.btnRetryConnection.Click += new System.EventHandler(this.btnRetryConnection_Click);
            // 
            // btnRefreshMatchTab
            // 
            this.btnRefreshMatchTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshMatchTab.Location = new System.Drawing.Point(781, 1044);
            this.btnRefreshMatchTab.Name = "btnRefreshMatchTab";
            this.btnRefreshMatchTab.Size = new System.Drawing.Size(535, 73);
            this.btnRefreshMatchTab.TabIndex = 6;
            this.btnRefreshMatchTab.Text = "Refresh Lists";
            this.btnRefreshMatchTab.UseVisualStyleBackColor = true;
            this.btnRefreshMatchTab.Visible = false;
            this.btnRefreshMatchTab.Click += new System.EventHandler(this.btnRefreshMatchTab_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(1338, 1044);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(535, 73);
            this.btnClearFilters.TabIndex = 7;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Visible = false;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // matchToolStripMenuItem
            // 
            this.matchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFiltersToolStripMenuItem,
            this.refreshMatchAndCompetitorListsToolStripMenuItem});
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Size = new System.Drawing.Size(94, 36);
            this.matchToolStripMenuItem.Text = "Match";
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
            // retryConnectionToolStripMenuItem
            // 
            this.retryConnectionToolStripMenuItem.Name = "retryConnectionToolStripMenuItem";
            this.retryConnectionToolStripMenuItem.Size = new System.Drawing.Size(404, 38);
            this.retryConnectionToolStripMenuItem.Text = "Retry Connection";
            this.retryConnectionToolStripMenuItem.Click += new System.EventHandler(this.retryConnectionToolStripMenuItem_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(736, 410);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(626, 147);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2281, 1140);
            this.Controls.Add(this.btnClearFilters);
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
            this.MinimumSize = new System.Drawing.Size(1750, 1150);
            this.Name = "frmMain";
            this.Text = "Event Hammer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tab1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.gbReports.ResumeLayout(false);
            this.gbReports.PerformLayout();
            this.gbScorecards.ResumeLayout(false);
            this.gbEvent.ResumeLayout(false);
            this.gbEvent.PerformLayout();
            this.tabMatch.ResumeLayout(false);
            this.tabMatch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvMatches)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlvCompetitors)).EndInit();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).EndInit();
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
        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miEventManager;
        private System.Windows.Forms.GroupBox gbScorecards;
        private System.Windows.Forms.Button btnKnockdown;
        private System.Windows.Forms.Button btnSemiKnockdown;
        private System.Windows.Forms.Button btnWeaponKata;
        private System.Windows.Forms.Button btnKata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRetryConnection;
        private System.Windows.Forms.ToolStripMenuItem refreshEventSelectionToolStripMenuItem;
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
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshMatchAndCompetitorListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retryConnectionToolStripMenuItem;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Timer tmrMatchCompetitorRefresh;
        private System.Windows.Forms.Timer tmrDivisions;
    }
}