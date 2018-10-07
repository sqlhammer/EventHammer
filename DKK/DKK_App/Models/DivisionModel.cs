using System;

namespace DKK_App.Models
{
    public class DivisionModel
    {
        private string _MatchTypeName;

        public int DivisionId { get; set; }
        public decimal MinWeight_lb { get; set; }
        public decimal MaxWeight_lb { get; set; }
        public string WeightClass { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool IsKata { get; set; }
        public bool IsWeaponKata { get; set; }
        public bool IsSemiKnockdown { get; set; }
        public bool IsKnockdown { get; set; }
        public string MatchTypeName
        {
            get
            {
                if (String.IsNullOrEmpty(_MatchTypeName))
                {
                    if (IsKata) { _MatchTypeName = "Kata"; return _MatchTypeName; }
                    if (IsWeaponKata) { _MatchTypeName = "Weapon Kata"; return _MatchTypeName; }
                    if (IsSemiKnockdown) { _MatchTypeName = "Semi-Knockdown"; return _MatchTypeName; }
                    if (IsKnockdown) { _MatchTypeName = "Knockdown"; return _MatchTypeName; }
                }

                return _MatchTypeName;
            }
        }
        public string MinBelt { get; set; }
        public string MaxBelt { get; set; }
    }
}
