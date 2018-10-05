using DKK_App.Models;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmCompSpecialConsiderationDetail : Form
    {
        public Models.CompetitorModel CompetitorModel = new CompetitorModel();

        public frmCompSpecialConsiderationDetail()
        {
            InitializeComponent();
        }

        private void frmCompSpecialConsiderationDetail_Load(object sender, System.EventArgs e)
        {
            lblName.Text = "Name: " + CompetitorModel.DisplayName;
            txtDesc.Text = CompetitorModel.Description;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            CompetitorModel.Competitor.Description = txtDesc.Text;
            DataAccess.UpdateCompetitor(Global.GetCompetitorFromCompetitorModel(CompetitorModel));
            this.Close();
        }
    }
}
