namespace DKK_CloudStorage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.pbCompany = new System.Windows.Forms.PictureBox();
            this.pbDKK = new System.Windows.Forms.PictureBox();
            this.pbPwredBy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDKK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwredBy)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select the registration file";
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Verdana", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(193, 79);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(803, 175);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Select registration file to upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Verdana", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(193, 308);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(793, 338);
            this.txtStatus.TabIndex = 1;
            this.txtStatus.Text = "<status>";
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbCompany
            // 
            this.pbCompany.Location = new System.Drawing.Point(-1946, 740);
            this.pbCompany.Margin = new System.Windows.Forms.Padding(4);
            this.pbCompany.Name = "pbCompany";
            this.pbCompany.Size = new System.Drawing.Size(282, 72);
            this.pbCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCompany.TabIndex = 4;
            this.pbCompany.TabStop = false;
            // 
            // pbDKK
            // 
            this.pbDKK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDKK.BackgroundImage")));
            this.pbDKK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDKK.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbDKK.InitialImage")));
            this.pbDKK.Location = new System.Drawing.Point(13, 709);
            this.pbDKK.Margin = new System.Windows.Forms.Padding(4);
            this.pbDKK.Name = "pbDKK";
            this.pbDKK.Size = new System.Drawing.Size(282, 114);
            this.pbDKK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDKK.TabIndex = 5;
            this.pbDKK.TabStop = false;
            this.pbDKK.Click += new System.EventHandler(this.pbDKK_Click);
            // 
            // pbPwredBy
            // 
            this.pbPwredBy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPwredBy.BackgroundImage")));
            this.pbPwredBy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPwredBy.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbPwredBy.InitialImage")));
            this.pbPwredBy.Location = new System.Drawing.Point(789, 709);
            this.pbPwredBy.Name = "pbPwredBy";
            this.pbPwredBy.Size = new System.Drawing.Size(393, 115);
            this.pbPwredBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPwredBy.TabIndex = 6;
            this.pbPwredBy.TabStop = false;
            this.pbPwredBy.Click += new System.EventHandler(this.pbPwredBy_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 836);
            this.Controls.Add(this.pbPwredBy);
            this.Controls.Add(this.pbDKK);
            this.Controls.Add(this.pbCompany);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "EventHammer File Uploader";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDKK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPwredBy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.PictureBox pbCompany;
        private System.Windows.Forms.PictureBox pbDKK;
        private System.Windows.Forms.PictureBox pbPwredBy;
    }
}

