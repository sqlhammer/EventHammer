﻿using System;
using System.Collections.Generic;

namespace DKK_App.Models
{
    public class MatchModel
    {
        private string _MatchDisplayName;
        private int? _MatchDisplayId;
        
        public int? SubDivisionId { get; set; }
        public int? MatchId { get; set; }
        public int? DivisionId { get; set; }
        public int? MatchDisplayId
        {
            get
            {
                return _MatchDisplayId;
            }
            set
            {
                _MatchDisplayId = value;
                _MatchDisplayName = null;
            }
        } 
        public string MatchDisplayName
        {
            get
            {
                if (String.IsNullOrEmpty(_MatchDisplayName))
                {
                    if (MatchDisplayId != null)
                    {
                        _MatchDisplayName = MatchDisplayId.ToString() + "-" + SubDivisionId.ToString();
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
        public string DojoName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        public List<MatchModel> Children { get; set; }
    }
}