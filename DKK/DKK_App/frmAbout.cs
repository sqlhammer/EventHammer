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
    }
}
