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
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.gbEvent = new System.Windows.Forms.GroupBox();
            this.lblEventSelect = new System.Windows.Forms.Label();
            this.cbEventSelect = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pbCompany = new System.Windows.Forms.PictureBox();
            this.pbPoweredBy = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtEventInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEventFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpEventTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tab1.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.gbEvent.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).BeginInit();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabHome);
            this.tab1.Controls.Add(this.tabPage2);
            this.tab1.Location = new System.Drawing.Point(12, 12);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(1749, 1025);
            this.tab1.TabIndex = 1;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.gbEvent);
            this.tabHome.Location = new System.Drawing.Point(8, 39);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1733, 978);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
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
            this.gbEvent.Location = new System.Drawing.Point(6, 6);
            this.gbEvent.Name = "gbEvent";
            this.gbEvent.Size = new System.Drawing.Size(573, 344);
            this.gbEvent.TabIndex = 0;
            this.gbEvent.TabStop = false;
            this.gbEvent.Text = "Event";
            // 
            // lblEventSelect
            // 
            this.lblEventSelect.AutoSize = true;
            this.lblEventSelect.Location = new System.Drawing.Point(6, 87);
            this.lblEventSelect.Name = "lblEventSelect";
            this.lblEventSelect.Size = new System.Drawing.Size(139, 25);
            this.lblEventSelect.TabIndex = 1;
            this.lblEventSelect.Text = "Select Event:";
            // 
            // cbEventSelect
            // 
            this.cbEventSelect.FormattingEnabled = true;
            this.cbEventSelect.Location = new System.Drawing.Point(147, 84);
            this.cbEventSelect.Name = "cbEventSelect";
            this.cbEventSelect.Size = new System.Drawing.Size(411, 33);
            this.cbEventSelect.TabIndex = 0;
            this.cbEventSelect.SelectedIndexChanged += new System.EventHandler(this.cbEventSelect_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1733, 978);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.pbPoweredBy.Location = new System.Drawing.Point(1479, 1044);
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
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(646, 1044);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(480, 73);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // txtEventInfo
            // 
            this.txtEventInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventInfo.Location = new System.Drawing.Point(11, 138);
            this.txtEventInfo.Multiline = true;
            this.txtEventInfo.Name = "txtEventInfo";
            this.txtEventInfo.Size = new System.Drawing.Size(547, 195);
            this.txtEventInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "From:";
            // 
            // dtpEventFrom
            // 
            this.dtpEventFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventFrom.Location = new System.Drawing.Point(91, 33);
            this.dtpEventFrom.Name = "dtpEventFrom";
            this.dtpEventFrom.Size = new System.Drawing.Size(200, 31);
            this.dtpEventFrom.TabIndex = 4;
            this.dtpEventFrom.ValueChanged += new System.EventHandler(this.dtpEventFrom_ValueChanged);
            // 
            // dtpEventTo
            // 
            this.dtpEventTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEventTo.Location = new System.Drawing.Point(358, 33);
            this.dtpEventTo.Name = "dtpEventTo";
            this.dtpEventTo.Size = new System.Drawing.Size(200, 31);
            this.dtpEventTo.TabIndex = 5;
            this.dtpEventTo.ValueChanged += new System.EventHandler(this.dtpEventTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "To:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(262, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(509, 31);
            this.textBox1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1774, 1129);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pbCompany);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.pbPoweredBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1750, 1150);
            this.Name = "frmMain";
            this.Text = "Event Hammer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tab1.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.gbEvent.ResumeLayout(false);
            this.gbEvent.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoweredBy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPoweredBy;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pbCompany;
        private System.Windows.Forms.GroupBox gbEvent;
        private System.Windows.Forms.Label lblEventSelect;
        private System.Windows.Forms.ComboBox cbEventSelect;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEventTo;
        private System.Windows.Forms.DateTimePicker dtpEventFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventInfo;
        private System.Windows.Forms.TextBox textBox1;
    }
}