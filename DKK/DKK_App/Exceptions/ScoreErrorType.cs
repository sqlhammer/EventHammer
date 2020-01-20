
namespace DKK_App.Exceptions
{
    public enum ScoreErrorType
    {
        Unknown,
        None,
        UniqueKeyViolation,
        EventForeignKeyViolation,
        MatchForeignKeyViolation,
        MatchTypeForeignKeyViolation,
        CompetitorForeignKeyViolation,
        DuplicateScoreId,
        DuplicateCompetitorInMatch,
        DuplicateRankInMatch,
        RankOutOfBounds,
        ScoreOutOfBounds
    }
}
