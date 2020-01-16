
namespace DKK_App.Exceptions
{
    public enum NewMatchErrorType
    {
        Unknown,
        None,
        MatchDisplayNameExists,
        DivisionNotSelected,
        MatchTypeNotSelected,
        KataDivisionWithNonKataSelection,
        NonKataDivisionWithKataSelection,
        DuplicateMatchDisplayId
    }
}
