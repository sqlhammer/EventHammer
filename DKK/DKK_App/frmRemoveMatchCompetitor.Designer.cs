namespace DKK_App
{
    partial class frmRemoveMatchCompetitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemoveMatchCompetitor));
            this.lbCompetitors = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMatchInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCompetitors
            // 
            this.lbCompetitors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.lbCompetitors.FormattingEnabled = true;
            this.lbCompetitors.ItemHeight = 33;
            this.lbCompetitors.Location = new System.Drawing.Point(32, 122);
            this.lbCompetitors.Name = "lbCompetitors";
            this.lbCompetitors.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbCompetitors.Size = new System.Drawing.Size(618, 400);
            this.lbCompetitors.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.btnRemove.Location = new System.Drawing.Point(32, 552);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(171, 75);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.btnCancel.Location = new System.Drawing.Point(479, 552);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 75);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMatchInfo
            // 
            this.lblMatchInfo.AutoSize = true;
            this.lblMatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F);
            this.lblMatchInfo.Location = new System.Drawing.Point(32, 41);
            this.lblMatchInfo.Name = "lblMatchInfo";
            this.lblMatchInfo.Size = new System.Drawing.Size(223, 33);
            this.lblMatchInfo.TabIndex = 3;
            this.lblMatchInfo.Text = "Match:      Type:";
            // 
            // frmRemoveMatchCompetitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 646);
            this.Controls.Add(this.lblMatchInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbCompetitors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRemoveMatchCompetitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove Match Competitor(s)";
            this.Load += new System.EventHandler(this.frmRemoveMatchCompetitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbCompetitors;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMatchInfo;
    }
}