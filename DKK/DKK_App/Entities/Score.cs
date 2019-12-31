namespace DKK_App.Entities
{
    public class Score
    {
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
        public int MatchTypeId { get; set; }
        public string MatchTypeName { get;}
        public int CompetitorId { get; set; }
        public string DisplayName { get; set; }
        public decimal ScoreJudge1 { get; set; }
        public decimal ScoreJudge2 { get; set; }
        public decimal ScoreJudge3 { get; set; }
        public decimal ScoreJudge4 { get; set; }
        public decimal ScoreJudge5 { get; set; }
        public decimal Database_Total { get; set; }
        public int Ranked { get; set; }
        public bool IsDisqualified { get; set; }
    }
}
