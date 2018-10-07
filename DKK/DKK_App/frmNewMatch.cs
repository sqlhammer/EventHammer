using DKK_App.Entities;
using DKK_App.Enums;
using DKK_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKK_App
{
    public partial class frmNewMatch : Form
    {
        public Event CurrentEvent = new Event();
        public List<Division> Divisions = new List<Division>();
        private List<MatchType> MatchTypes = new List<MatchType>();
        public List<MatchModel> MatchModels = new List<MatchModel>();
        public frmMain ParentFormMain { get; set; }

        public frmNewMatch()
        {
            InitializeComponent();
        }

        private void frmNewMatch_Load(object sender, System.EventArgs e)
        {
            LoadMatchTypesCombobox();
            LoadDivisionList();
        }        

        private NewMatchErrorType IsValidNewMatch()
        {
            /*
             * Conditions:
             * 1. A match type must be selected
             * 2. A display division number must be selected (enforced by the control)
             * 3. A sub division number must be selected (enforced by the control)
             * 4. A division must be selected
             * 5. A match with the same display div and subdiv cannot already exist
             * 6. Must be appropriate IsKata type
             * 7. A display division number cannot already exist
             */

            int divisionId = ((DivisionModel)this.tlvDivisions.SelectedObject).DivisionId;

            if (Global.IsDuplicateMatchDisplayId(MatchModels, divisionId, (int)this.nudSubDivision.Value))
                return NewMatchErrorType.DuplicateMatchDisplayId;
            
            if (this.tlvDivisions.SelectedObject == null)
                return NewMatchErrorType.DivisionNotSelected;

            if (this.tlvDivisions.SelectedObject == null)
                return NewMatchErrorType.DivisionNotSelected;

            string MatchDisplayName = Global.GetMatchDisplayName(divisionId, this.nudSubDivision.Value);
            if (MatchModels.Any(m => m.MatchDisplayName.CompareTo(MatchDisplayName) == 0))
                return NewMatchErrorType.MatchDisplayNameExists;

            return NewMatchErrorType.None;
        }

        private NewMatchErrorType IsAppropriateKataType()
        {
            switch(this.cbMatchType.SelectedItem.ToString())
            {
                case "Kata":
                    if (!((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.NonKataDivisionWithKataSelection;
                    break;
                case "Weapon Kata":
                    if (!((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.NonKataDivisionWithKataSelection;
                    break;
                case "Semi-Knockdown":
                    if (((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.KataDivisionWithNonKataSelection;
                    break;
                case "Knockdown":
                    if (((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.KataDivisionWithNonKataSelection;
                    break;
                case "Kata (Special Consideration)":
                    if (!((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.NonKataDivisionWithKataSelection;
                    break;
                case "Weapon Kata (Special Consideration)":
                    if (!((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.NonKataDivisionWithKataSelection;
                    break;
                case "Semi-Knockdown (Special Consideration)":
                    if (((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.KataDivisionWithNonKataSelection;
                    break;
                case "Knockdown (Special Consideration)":
                    if (((DivisionModel)this.tlvDivisions.SelectedObject).IsKata)
                        return NewMatchErrorType.KataDivisionWithNonKataSelection;
                    break;
            }

            return NewMatchErrorType.None;
        }

        private void LoadDivisionList()
        {
            this.tlvDivisions.Roots = Global.GetDivisionModel(Divisions);
            this.tlvDivisions.CollapseAll();
        }

        private void LoadMatchTypesCombobox()
        {
            RefreshMatchTypes();

            this.cbMatchType.Items.Clear();
            foreach(var mt in MatchTypes)
            {
                string type = Global.GetMatchTypeDisplayName(mt, LengthType.Long);
                this.cbMatchType.Items.Add(type);
            }
        }

        private void RefreshMatchTypes()
        {
            MatchTypes = DataAccess.GetMatchTypes();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void CreateNewMatch()
        {
            //write to the database
            MatchModel match = new MatchModel();

            bool isSpecial = this.cbIsSpecialConsideration.Checked;
            string matchTypeName = ((DivisionModel)this.tlvDivisions.SelectedObject).MatchTypeName;

            switch (matchTypeName)
            {
                case "Kata":
                    match.MatchTypeId = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Kata") == 0 && 
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeId;
                    match.MatchTypeName = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Kata") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeName;
                    break;
                case "Weapon Kata":
                    match.MatchTypeId = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Weapon Kata") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeId;
                    match.MatchTypeName = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Weapon Kata") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeName;
                    break;
                case "Semi-Knockdown":
                    match.MatchTypeId = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Semi-Knockdown") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeId;
                    match.MatchTypeName = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Semi-Knockdown") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeName;
                    break;
                case "Knockdown":
                    match.MatchTypeId = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Knockdown") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeId;
                    match.MatchTypeName = (MatchTypes.Where(mtw => mtw.MatchTypeName.CompareTo("Knockdown") == 0 &&
                        mtw.IsSpecialConsideration == isSpecial).First()).MatchTypeName;
                    break;
            }

            match.EventId = CurrentEvent.EventId;
            match.DivisionId = ((DivisionModel)this.tlvDivisions.SelectedObject).DivisionId;
            match.SubDivisionId = (int)this.nudSubDivision.Value;
            match.Children = new List<MatchModel>();

            match.MatchId = DataAccess.InsertMatch(match);

            //update the matchmodels
            MatchModels.Add(match);
            ParentFormMain.MatchModels = ParentFormMain.SortMatchModels(MatchModels);

            //refresh the main form to avoid a full refresh
            ParentFormMain.RefreshMatches(MatchModels);

            this.Close();
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            string MatchDisplayName = Global.GetMatchDisplayName(this.nudDivision.Value, this.nudSubDivision.Value);

            switch (IsValidNewMatch())
            {
                case NewMatchErrorType.None:
                    CreateNewMatch();
                    break;
                case NewMatchErrorType.DivisionNotSelected:
                    MessageBox.Show("You must select a division before saving.", "Missing division", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.MatchTypeNotSelected:
                    MessageBox.Show("You must select a match type before saving.", "Missing match type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.MatchDisplayNameExists:
                    MessageBox.Show(string.Format("The Division-SubDivision ({0}) already exists.", MatchDisplayName), string.Format("{0} exists", MatchDisplayName), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.Unknown:
                    MessageBox.Show("Unknown error", "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.KataDivisionWithNonKataSelection:
                    MessageBox.Show("To select a non-Kata match type, you must select a non-Kata division, as well.", "Match type / division type mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.NonKataDivisionWithKataSelection:
                    MessageBox.Show("To select a Kata match type, you must select a Kata division, as well.", "Match type / division type mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case NewMatchErrorType.DuplicateMatchDisplayId:
                    MessageBox.Show("That combination of Division and Sub-division numbers is already taken. Please select another.", "Duplicate Division / Sub-division combination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
