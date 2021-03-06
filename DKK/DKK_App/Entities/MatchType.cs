﻿namespace DKK_App.Entities
{
    public class MatchType
    {
        public int MatchTypeId { get; set; }
        public string MatchTypeName { get; set; }
        public bool IsSpecialConsideration { get; set; }
        public string MatchTypeDisplayName
        {
            get
            {
                return Global.GetMatchTypeDisplayName(this,Enums.LengthType.Short);
            }
        }
        public bool IsRankOnlyMatch
        {
            get
            {
                if (MatchTypeName.ToLower().Contains("knock"))
                    return true;

                return false;
            }
        }
    }
}
