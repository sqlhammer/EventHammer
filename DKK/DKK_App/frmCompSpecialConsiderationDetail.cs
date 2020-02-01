using DKK_App.Models;
using System;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmCompSpecialConsiderationDetail : Form
    {
        public Models.CompetitorModel CompetitorModel = new CompetitorModel();
        public frmMain mainForm;

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
            CompetitorModel.Competitor = Global.GetCompetitorFromCompetitorModel(CompetitorModel);
            CompetitorModel.Competitor.Description = txtDesc.Text;
            CompetitorModel.Competitor.IsSpecialConsideration = !String.IsNullOrWhiteSpace(txtDesc.Text);
            DataAccess.UpdateCompetitor(CompetitorModel.Competitor);

            mainForm.SetSpecialConsiderationsCellValue();

            this.Close();
        }
    }
}
