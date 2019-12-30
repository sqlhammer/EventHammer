
namespace DKK_App.Objects
{
    public class CompetitorDetailsGridPair
    {
        public CompetitorDetailsGridPair(int BaseX, int BaseY, int ValueX, int ValueY)
        {
            this.Base = new GridPair(BaseX, BaseY);
            this.Value = new GridPair(ValueX, ValueY);
        }

        public GridPair Base { get; }
        public GridPair Value { get; }
    }
}
