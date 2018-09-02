namespace DKK_App
{
    partial class frmNewMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewMatch));
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMatchType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tlvDivisions = new BrightIdeasSoftware.TreeListView();
            this.colId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colGender = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colIsKata = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMinBelt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMaxBelt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMinAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMaxAge = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMinWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colMaxWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nudDivision = new System.Windows.Forms.NumericUpDown();
            this.nudSubDivision = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tlvDivisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubDivision)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(290, 420);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(104, 43);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(418, 420);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 43);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Select division type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Display Div #";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Match Type";
            // 
            // cbMatchType
            // 
            this.cbMatchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMatchType.FormattingEnabled = true;
            this.cbMatchType.Location = new System.Drawing.Point(118, 30);
            this.cbMatchType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMatchType.Name = "cbMatchType";
            this.cbMatchType.Size = new System.Drawing.Size(240, 25);
            this.cbMatchType.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(632, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Sub-Div #";
            // 
            // tlvDivisions
            // 
            this.tlvDivisions.AllColumns.Add(this.colId);
            this.tlvDivisions.AllColumns.Add(this.colGender);
            this.tlvDivisions.AllColumns.Add(this.colIsKata);
            this.tlvDivisions.AllColumns.Add(this.colMinBelt);
            this.tlvDivisions.AllColumns.Add(this.colMaxBelt);
            this.tlvDivisions.AllColumns.Add(this.colMinAge);
            this.tlvDivisions.AllColumns.Add(this.colMaxAge);
            this.tlvDivisions.AllColumns.Add(this.colMinWeight);
            this.tlvDivisions.AllColumns.Add(this.colMaxWeight);
            this.tlvDivisions.CellEditUseWholeCell = false;
            this.tlvDivisions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colGender,
            this.colIsKata,
            this.colMinBelt,
            this.colMaxBelt,
            this.colMinAge,
            this.colMaxAge,
            this.colMinWeight,
            this.colMaxWeight});
            this.tlvDivisions.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlvDivisions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlvDivisions.Location = new System.Drawing.Point(30, 98);
            this.tlvDivisions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlvDivisions.Name = "tlvDivisions";
            this.tlvDivisions.ShowGroups = false;
            this.tlvDivisions.Size = new System.Drawing.Size(765, 301);
            this.tlvDivisions.TabIndex = 22;
            this.tlvDivisions.UseCompatibleStateImageBehavior = false;
            this.tlvDivisions.View = System.Windows.Forms.View.Details;
            this.tlvDivisions.VirtualMode = true;
            // 
            // colId
            // 
            this.colId.AspectName = "DivisionId";
            this.colId.Text = "Id";
            this.colId.Width = 62;
            // 
            // colGender
            // 
            this.colGender.AspectName = "Gender";
            this.colGender.Text = "Gender";
            this.colGender.Width = 67;
            // 
            // colIsKata
            // 
            this.colIsKata.AspectName = "IsKata";
            this.colIsKata.Text = "Kata";
            // 
            // colMinBelt
            // 
            this.colMinBelt.AspectName = "MinBelt";
            this.colMinBelt.Text = "Min Belt";
            this.colMinBelt.Width = 130;
            // 
            // colMaxBelt
            // 
            this.colMaxBelt.AspectName = "MaxBelt";
            this.colMaxBelt.Text = "Max Belt";
            this.colMaxBelt.Width = 130;
            // 
            // colMinAge
            // 
            this.colMinAge.AspectName = "MinAge";
            this.colMinAge.Text = "Min Age";
            this.colMinAge.Width = 67;
            // 
            // colMaxAge
            // 
            this.colMaxAge.AspectName = "MaxAge";
            this.colMaxAge.Text = "Max Age";
            this.colMaxAge.Width = 67;
            // 
            // colMinWeight
            // 
            this.colMinWeight.AspectName = "MinWeight_lb";
            this.colMinWeight.Text = "Min Weight";
            this.colMinWeight.Width = 95;
            // 
            // colMaxWeight
            // 
            this.colMaxWeight.AspectName = "MaxWeight_lb";
            this.colMaxWeight.Text = "Max Weight";
            this.colMaxWeight.Width = 95;
            // 
            // nudDivision
            // 
            this.nudDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDivision.Location = new System.Drawing.Point(536, 30);
            this.nudDivision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudDivision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDivision.Name = "nudDivision";
            this.nudDivision.Size = new System.Drawing.Size(68, 24);
            this.nudDivision.TabIndex = 23;
            this.nudDivision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudSubDivision
            // 
            this.nudSubDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSubDivision.Location = new System.Drawing.Point(716, 30);
            this.nudSubDivision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSubDivision.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSubDivision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSubDivision.Name = "nudSubDivision";
            this.nudSubDivision.Size = new System.Drawing.Size(68, 24);
            this.nudSubDivision.TabIndex = 24;
            this.nudSubDivision.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmNewMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(832, 504);
            this.Controls.Add(this.nudSubDivision);
            this.Controls.Add(this.nudDivision);
            this.Controls.Add(this.tlvDivisions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMatchType);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(848, 539);
            this.Name = "frmNewMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Match";
            this.Load += new System.EventHandler(this.frmNewMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlvDivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubDivision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMatchType;
        private System.Windows.Forms.Label label4;
        private BrightIdeasSoftware.TreeListView tlvDivisions;
        private BrightIdeasSoftware.OLVColumn colId;
        private BrightIdeasSoftware.OLVColumn colGender;
        private BrightIdeasSoftware.OLVColumn colIsKata;
        private BrightIdeasSoftware.OLVColumn colMinBelt;
        private BrightIdeasSoftware.OLVColumn colMaxBelt;
        private BrightIdeasSoftware.OLVColumn colMinAge;
        private BrightIdeasSoftware.OLVColumn colMaxAge;
        private BrightIdeasSoftware.OLVColumn colMinWeight;
        private BrightIdeasSoftware.OLVColumn colMaxWeight;
        private System.Windows.Forms.NumericUpDown nudDivision;
        private System.Windows.Forms.NumericUpDown nudSubDivision;
    }
}