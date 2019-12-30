
namespace DKK_App.Objects
{
    public class GridPair
    {
        public GridPair(int columnIndex, int rowIndex)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
        }

        public int ColumnIndex { get; }
        public int RowIndex { get; }
    }
}
