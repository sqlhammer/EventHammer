namespace DKK_App
{
    partial class frmEventManager
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
            this.lstvEvents = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lstvEvents
            // 
            this.lstvEvents.Location = new System.Drawing.Point(12, 12);
            this.lstvEvents.Name = "lstvEvents";
            this.lstvEvents.Size = new System.Drawing.Size(925, 810);
            this.lstvEvents.TabIndex = 0;
            this.lstvEvents.UseCompatibleStateImageBehavior = false;
            this.lstvEvents.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(966, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "View";
            // 
            // cbView
            // 
            this.cbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbView.FormattingEnabled = true;
            this.cbView.Items.AddRange(new object[] {
            "Detail",
            "Tile",
            "Large Icon"});
            this.cbView.Location = new System.Drawing.Point(1067, 23);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(171, 41);
            this.cbView.TabIndex = 2;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // frmEventManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 834);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstvEvents);
            this.Name = "frmEventManager";
            this.Text = "Event Manager";
            this.Load += new System.EventHandler(this.frmEventManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstvEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbView;
    }
}