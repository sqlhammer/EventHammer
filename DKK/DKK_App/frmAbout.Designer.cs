namespace DKK_App
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbSQLHammer = new System.Windows.Forms.PictureBox();
            this.lblMajorVersion = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.lnklblSourceCode = new System.Windows.Forms.LinkLabel();
            this.lnklblContact = new System.Windows.Forms.LinkLabel();
            this.lblBuildDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSQLHammer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSQLHammer
            // 
            this.pbSQLHammer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbSQLHammer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSQLHammer.Image = global::DKK_App.Properties.Resources.powered_by_sqlhammer;
            this.pbSQLHammer.Location = new System.Drawing.Point(26, 24);
            this.pbSQLHammer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbSQLHammer.Name = "pbSQLHammer";
            this.pbSQLHammer.Size = new System.Drawing.Size(329, 84);
            this.pbSQLHammer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSQLHammer.TabIndex = 0;
            this.pbSQLHammer.TabStop = false;
            this.pbSQLHammer.Click += new System.EventHandler(this.pbSQLHammer_Click);
            // 
            // lblMajorVersion
            // 
            this.lblMajorVersion.AutoSize = true;
            this.lblMajorVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMajorVersion.Location = new System.Drawing.Point(26, 136);
            this.lblMajorVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMajorVersion.Name = "lblMajorVersion";
            this.lblMajorVersion.Size = new System.Drawing.Size(123, 20);
            this.lblMajorVersion.TabIndex = 1;
            this.lblMajorVersion.Text = "Major Version: 1";
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuild.Location = new System.Drawing.Point(26, 169);
            this.lblBuild.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(87, 20);
            this.lblBuild.TabIndex = 2;
            this.lblBuild.Text = "Build: 0.0.1";
            // 
            // lnklblSourceCode
            // 
            this.lnklblSourceCode.ActiveLinkColor = System.Drawing.Color.OliveDrab;
            this.lnklblSourceCode.AutoSize = true;
            this.lnklblSourceCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblSourceCode.Location = new System.Drawing.Point(26, 232);
            this.lnklblSourceCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblSourceCode.Name = "lnklblSourceCode";
            this.lnklblSourceCode.Size = new System.Drawing.Size(137, 20);
            this.lnklblSourceCode.TabIndex = 3;
            this.lnklblSourceCode.TabStop = true;
            this.lnklblSourceCode.Text = "Github Repository";
            this.lnklblSourceCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblSourceCode_LinkClicked);
            // 
            // lnklblContact
            // 
            this.lnklblContact.ActiveLinkColor = System.Drawing.Color.OliveDrab;
            this.lnklblContact.AutoSize = true;
            this.lnklblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblContact.Location = new System.Drawing.Point(26, 265);
            this.lnklblContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblContact.Name = "lnklblContact";
            this.lnklblContact.Size = new System.Drawing.Size(165, 20);
            this.lnklblContact.TabIndex = 4;
            this.lnklblContact.TabStop = true;
            this.lnklblContact.Text = "Contact the developer";
            this.lnklblContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblContact_LinkClicked);
            // 
            // lblBuildDate
            // 
            this.lblBuildDate.AutoSize = true;
            this.lblBuildDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuildDate.Location = new System.Drawing.Point(26, 201);
            this.lblBuildDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuildDate.Name = "lblBuildDate";
            this.lblBuildDate.Size = new System.Drawing.Size(87, 20);
            this.lblBuildDate.TabIndex = 5;
            this.lblBuildDate.Text = "Build Date:";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 306);
            this.Controls.Add(this.lblBuildDate);
            this.Controls.Add(this.lnklblContact);
            this.Controls.Add(this.lnklblSourceCode);
            this.Controls.Add(this.lblBuild);
            this.Controls.Add(this.lblMajorVersion);
            this.Controls.Add(this.pbSQLHammer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Event Hammer";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSQLHammer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSQLHammer;
        private System.Windows.Forms.Label lblMajorVersion;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.LinkLabel lnklblSourceCode;
        private System.Windows.Forms.LinkLabel lnklblContact;
        private System.Windows.Forms.Label lblBuildDate;
    }
}