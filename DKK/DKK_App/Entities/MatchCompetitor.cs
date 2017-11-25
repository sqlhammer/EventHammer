namespace DKK_App.Entities
{
    public class MatchCompetitor
    {
        public int MatchCompetitorId { get; set; }
        public Competitor Competitor { get; set; }
        public Match Match { get; set; }
        public int MatchPlacement { get; set; }
    }
}
