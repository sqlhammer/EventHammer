namespace DKK_App.Entities
{
    public class Match
    {
        public int MacthId { get; set; }
        public Event Event { get; set; }
        public MatchType MatchType { get; set; }
        public Division Division { get; set; }
        public int SubDivisionId { get; set; }
    }
}
