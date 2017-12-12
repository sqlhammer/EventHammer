using System;

namespace DKK_App.Entities
{
    public class Competitor
    {
        public int CompetitorId { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Dojo Dojo { get; set; }
        public Event Event { get; set; }
        public bool IsKata { get; set; }
        public bool IsKnockdown { get; set; }
        public bool IsMinor { get; set; }
        public bool IsSemiKnockdown { get; set; }
        public bool IsSpecialConsideration { get; set; }
        public bool IsWeaponKata { get; set; }
        public Person Parent { get; set; }
        public Person Person { get; set; }
        public Rank Rank { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
    }
}
