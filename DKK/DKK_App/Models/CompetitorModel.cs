
using DKK_App.Entities;

namespace DKK_App.Models
{
    public class CompetitorModel
    {
        #region Constructors
        public Competitor Competitor { get; set; }
        
        public CompetitorModel(Competitor competitor)
        {
            Competitor = competitor;
        }

        public CompetitorModel()
        {
            Competitor = new Competitor
            {
                Dojo = new Dojo
                {
                    Facility = new Facility(),
                    MartialArtType = new MartialArtType()
                },
                Parent = new Person(),
                Person = new Person(),
                Rank = new Rank()
            };
        }
        #endregion

        #region Attributes
        public int CompetitorId
        {
            get
            {
                return Competitor.CompetitorId;
            }
        }
        public string DisplayName
        {
            get
            {
                return Competitor.Person.DisplayName;
            }
        }
        public string RankName
        {
            get
            {
                return Competitor.Rank.RankName;
            }
        }
        public int Level
        {
            get
            {
                return Competitor.Rank.Level;
            }
        }
        public decimal Weight
        {
            get
            {
                return Competitor.Weight;
            }
        }
        public decimal Height
        {
            get
            {
                return Competitor.Height;
            }
        }
        public string DojoName
        {
            get
            {
                return Competitor.Dojo.Facility.FacilityName;
            }
        }
        public string OtherDojoName
        {
            get
            {
                return Competitor.OtherDojoName;
            }
        }
        public int Age
        {
            get
            {
                return Competitor.Age;
            }
        }
        public string Gender
        {
            get
            {
                return Competitor.Person.Gender;
            }
        }
        public string Description
        {
            get
            {
                return Competitor.Description;
            }
        }
        public bool IsSpecialConsideration
        {
            get
            {
                return Competitor.IsSpecialConsideration;
            }
        }
        #endregion
    }
}
