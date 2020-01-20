using DKK_App.Exceptions;

namespace DKK_App.Entities
{
    public class Score
    {
        private bool _isSettable;

        public Score()
        {
            MatchType = new MatchType
            {
                IsSpecialConsideration = false,
                MatchTypeId = 0,
                MatchTypeName = ""
            };

            ScoreId = -1;
            MatchId = -1;
        }

        public int ScoreId { get; set; }
        public int EventId { get; set; }
        public int MatchId { get; set; }
        public int DivisionId { get; set; }
        public int SubDivisionId { get; set; }
        public string DivSubDiv
        {
            get
            {
                return Global.GetMatchDisplayName(DivisionId, SubDivisionId);
            }
        }
        public MatchType MatchType { get; set; }
        public string MatchTypeName
        {
            get
            {
                return (MatchType == null) ? "" : MatchType.MatchTypeName;
            }
        }
        public int CompetitorId { get; set; }
        public string DisplayName { get; set; }
        public decimal ScoreJudge1 { get; set; }
        public decimal ScoreJudge2 { get; set; }
        public decimal ScoreJudge3 { get; set; }
        public decimal ScoreJudge4 { get; set; }
        public decimal ScoreJudge5 { get; set; }
        public int Ranked { get; set; }
        public bool IsDisqualified { get; set; }
        public decimal Database_Total { get; set; }
        public string DisplayTotal
        {
            get
            {
                return GetValueWithRankOnlyCheck(Database_Total);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    Database_Total = result;
            }
        }
        public string DisplayScoreJudge1
        {
            get
            {
                return GetValueWithRankOnlyCheck(ScoreJudge1);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    ScoreJudge1 = result;
            }
        }
        public string DisplayScoreJudge2
        {
            get
            {
                return GetValueWithRankOnlyCheck(ScoreJudge2);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    ScoreJudge2 = result;
            }
        }
        public string DisplayScoreJudge3
        {
            get
            {
                return GetValueWithRankOnlyCheck(ScoreJudge3);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    ScoreJudge3 = result;
            }
        }
        public string DisplayScoreJudge4
        {
            get
            {
                return GetValueWithRankOnlyCheck(ScoreJudge4);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    ScoreJudge4 = result;
            }
        }
        public string DisplayScoreJudge5
        {
            get
            {
                return GetValueWithRankOnlyCheck(ScoreJudge5);
            }
            set
            {
                decimal result = SetValueWithRankOnlyCheck(value);
                if (_isSettable)
                    ScoreJudge5 = result;
            }
        }

        private string GetValueWithRankOnlyCheck(decimal v)
        {
            if (MatchType.IsRankOnlyMatch)
                return "N/A";

            return v.ToString();
        }

        private decimal SetValueWithRankOnlyCheck(string v)
        {
            //Don't change the underlying value if they cannot see what they
            //changed due to "N/A" being displayed.
            _isSettable = true;
            if (MatchType.IsRankOnlyMatch)
                _isSettable = false;

            decimal.TryParse(v, out decimal result);
            return result;
        }

        private bool IsDefaultOrInvalid(int value)
        {
            if (value <= 0)
                return true;

            return false;
        }

        private bool IsInvalid(int value)
        {
            if (value < 0)
                return true;

            return false;
        }

        private bool IsInvalidJudgeScore(decimal value)
        {
            if (value < 0 || value > 10) return true;

            return false;
        }

        public ScoreErrorType HasAllRequiredAttributes()
        {
            if (IsDefaultOrInvalid(MatchId)) return ScoreErrorType.MatchForeignKeyViolation;
            if (IsDefaultOrInvalid(EventId)) return ScoreErrorType.EventForeignKeyViolation;
            if (IsDefaultOrInvalid(DivisionId)) return ScoreErrorType.Unknown;
            if (IsDefaultOrInvalid(SubDivisionId)) return ScoreErrorType.Unknown;
            if (IsDefaultOrInvalid(CompetitorId)) return ScoreErrorType.CompetitorForeignKeyViolation;
            if (IsInvalid(Ranked)) return ScoreErrorType.RankOutOfBounds;

            if (MatchType == null || MatchType == default(MatchType)) return ScoreErrorType.MatchTypeForeignKeyViolation;
            if (IsDefaultOrInvalid(MatchType.MatchTypeId)) return ScoreErrorType.MatchTypeForeignKeyViolation;

            if (!MatchType.IsRankOnlyMatch)
            {
                if (IsInvalidJudgeScore(ScoreJudge1)) return ScoreErrorType.ScoreOutOfBounds;
                if (IsInvalidJudgeScore(ScoreJudge2)) return ScoreErrorType.ScoreOutOfBounds;
                if (IsInvalidJudgeScore(ScoreJudge3)) return ScoreErrorType.ScoreOutOfBounds;
                if (IsInvalidJudgeScore(ScoreJudge4)) return ScoreErrorType.ScoreOutOfBounds;
                if (IsInvalidJudgeScore(ScoreJudge5)) return ScoreErrorType.ScoreOutOfBounds;
            }

            return ScoreErrorType.None;
        }
    }
}
