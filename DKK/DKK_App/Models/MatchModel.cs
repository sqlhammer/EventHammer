using System;
using System.Collections.Generic;

namespace DKK_App.Models
{
    public class MatchModel
    {
        private string _MatchDisplayName;
        private int? _SubDivisionId;

        public int? EventId { get; set; }
        public int? SubDivisionId
        {
            get { return _SubDivisionId; }
            set { _SubDivisionId = value; _MatchDisplayName = null; }
        }
        public int? MatchId { get; set; }
        public int? DivisionId { get; set; }
        public string MatchDisplayName
        {
            get
            {
                if (String.IsNullOrEmpty(_MatchDisplayName))
                {
                    if (DivisionId != null)
                    {
                        _MatchDisplayName = Global.GetMatchDisplayName((int)DivisionId, (int)SubDivisionId);
                    }
                }

                return _MatchDisplayName;
            }
        }
        public int? MatchTypeId { get; set; }
        public string MatchTypeName { get; set; }
        public int? CompetitorId { get; set; }
        public string DisplayName { get; set; }
        public string RankName { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public string DojoName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        public List<MatchModel> Children { get; set; }
    }
}
