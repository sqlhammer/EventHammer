
namespace DKK_App.Exceptions
{
    public enum ScoreMergeErrorType
    {
        Unknown,
        None,
        UniqueKeyViolation,
        EventForeignKeyViolation,
        MatchForeignKeyViolation,
        MatchTypeForeignKeyViolation,
        CompetitorForeignKeyViolation,
        DuplicateScoreId,
        RankOutOfBounds,
        ScoreOutOfBounds
    }
}
