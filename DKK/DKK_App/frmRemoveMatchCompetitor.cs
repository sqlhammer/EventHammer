
using System.Linq;
using DKK_App.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmRemoveMatchCompetitor : Form
    {
        public MatchModel Match;
        public frmMain frmMain;

        public frmRemoveMatchCompetitor()
        {
            InitializeComponent();
        }

        private void frmRemoveMatchCompetitor_Load(object sender, System.EventArgs e)
        {
            SetMatchInformation();
            PopulateCompetitorList();
        }

        private void PopulateCompetitorList()
        {
            foreach (MatchModel mm in Match.Children)
            {
               this.lbCompetitors.Items.Add(mm.DisplayName);
            }
        }

        private void SetMatchInformation()
        {
            this.lblMatchInfo.Text = string.Format("Match: {0}    Type: {1}",Match.MatchDisplayName,Match.MatchTypeName);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            List<MatchModel> mm = new List<MatchModel>();
            MatchModel match = new MatchModel();


            foreach (int i in lbCompetitors.SelectedIndices)
            {
                match = Match.Children.FirstOrDefault(m => m.DisplayName == lbCompetitors.Items[i].ToString());
                match.MatchId = Match.MatchId;
                mm.Add(match);
            }

            RemoveMatchCompetitors(mm);
            frmMain.RemoveCompetitorFromMatchView(match.MatchId, match.CompetitorId);
            CloseForm();
        }

        private void RemoveMatchCompetitors(List<MatchModel> mm)
        {
            foreach(MatchModel m in mm)
            {
                DataAccess.DeleteCompetitorFromMatch(m);
            }
        }
    }
}
