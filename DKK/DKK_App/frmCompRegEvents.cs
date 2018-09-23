using DKK_App.Models;
using System;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmCompRegEvents : Form
    {
        public CompetitorModel CompetitorModel = new CompetitorModel();

        public frmCompRegEvents()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            ResetMatchTypeSelection();
        }

        private void frmCompRegEvents_Load(object sender, System.EventArgs e)
        {
            LoadMatchTypes();
            ResetMatchTypeSelection();
        }

        private void Save()
        {
            for (int i = 0; i < lstEvents.Items.Count; i++)
            {
                switch (lstEvents.Items[i].ToString())
                {
                    case "Kata":
                        CompetitorModel.Competitor.IsKata = (lstEvents.SelectedIndices.Contains(i));
                        break;
                    case "Weapon Kata":
                        CompetitorModel.Competitor.IsWeaponKata = (lstEvents.SelectedIndices.Contains(i));
                        break;
                    case "Semi-Knockdown":
                        CompetitorModel.Competitor.IsSemiKnockdown = (lstEvents.SelectedIndices.Contains(i));
                        break;
                    case "Knockdown":
                        CompetitorModel.Competitor.IsKnockdown = (lstEvents.SelectedIndices.Contains(i));
                        break;
                }
            }

            DataAccess.UpdateCompetitor(CompetitorModel.Competitor);
        }

        private void SelectMatchTypeByName(string name)
        {
            for (int i = 0; i < lstEvents.Items.Count; i++)
            {
                if (lstEvents.Items[i].ToString() == name)
                {
                    lstEvents.SelectedIndices.Add(i);
                    break;
                }
            }
        }

        private void ResetMatchTypeSelection()
        {
            lstEvents.ClearSelected();

            if (CompetitorModel.Competitor.IsKata)
                SelectMatchTypeByName("Kata");

            if (CompetitorModel.Competitor.IsWeaponKata)
                SelectMatchTypeByName("Weapon Kata");

            if (CompetitorModel.Competitor.IsSemiKnockdown)
                SelectMatchTypeByName("Semi-Knockdown");

            if (CompetitorModel.Competitor.IsKnockdown)
                SelectMatchTypeByName("Knockdown");
        }

        private void LoadMatchTypes()
        {
            lstEvents.Items.Add("Kata");
            lstEvents.Items.Add("Weapon Kata");
            lstEvents.Items.Add("Semi-Knockdown");
            lstEvents.Items.Add("Knockdown");
        }

        /*
        private void LoadMatchTypes()
        {
            List<MatchType> matchTypes = DataAccess.GetMatchTypes();

            //Where filter used to get a distinct list of type names
            foreach (MatchType mt in matchTypes.Where(m => m.IsSpecialConsideration == false))
            {
                lstEvents.Items.Add(mt.MatchTypeName);
            }
        }
        */
    }
}
