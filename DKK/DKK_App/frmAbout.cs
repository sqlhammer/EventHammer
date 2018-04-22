using System;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void LaunchWebsite(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void lnklblSourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com/go/ehsource/");
        }

        private void lnklblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com/go/contact/");
        }

        private void pbSQLHammer_Click(object sender, System.EventArgs e)
        {
            LaunchWebsite("https://www.sqlhammer.com/");
        }

        private void frmAbout_Load(object sender, System.EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1)
                                    .AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion = $"{version}";
            string displayBuildDate = buildDate.ToString("MM/dd/yyyy");

            this.lblBuild.Text = $"Build: {displayableVersion}";
            this.lblBuildDate.Text = $"Build Date: {displayBuildDate}";
        }
    }
}
