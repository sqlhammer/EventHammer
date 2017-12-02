using System.Collections.Generic;

namespace DKK_App.Models
{
    public class CompetitorModel
    {
        public int CompetitorId { get; set; }
        public string DisplayName { get; set; }
        public string RankName { get; set; }
        public decimal Weight { get; set; }
        public string DojoName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
