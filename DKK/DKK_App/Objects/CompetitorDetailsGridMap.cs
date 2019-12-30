
namespace DKK_App.Objects
{
    public class CompetitorDetailsGridMap
    {
        public CompetitorDetailsGridMap()
        {
            FirstName = new CompetitorDetailsGridPair(1, 0, 2, 0);
            LastName = new CompetitorDetailsGridPair(3, 0, 4, 0);

            Gender = new CompetitorDetailsGridPair(1, 1, 2, 1);
            Age = new CompetitorDetailsGridPair(3, 1, 4, 1);

            Weight = new CompetitorDetailsGridPair(1, 2, 2, 2);
            Height = new CompetitorDetailsGridPair(3, 2, 4, 2);

            Belt = new CompetitorDetailsGridPair(1, 3, 2, 3);
            Title = new CompetitorDetailsGridPair(3, 3, 4, 3);

            School = new CompetitorDetailsGridPair(1, 4, 2, 4);
            OtherSchool = new CompetitorDetailsGridPair(3, 4, 4, 4);

            Instructor = new CompetitorDetailsGridPair(1, 5, 2, 5);
            Special = new CompetitorDetailsGridPair(3, 5, 3, 5);
            RegisteredEvents = new CompetitorDetailsGridPair(4, 5, 4, 5);

            ParentFirstName = new CompetitorDetailsGridPair(1, 6, 2, 6);
            ParentLastName = new CompetitorDetailsGridPair(3, 6, 4, 6);

            ParentEmail = new CompetitorDetailsGridPair(1, 7, 2, 7);
            Street1 = new CompetitorDetailsGridPair(3, 7, 4, 7);

            Street2 = new CompetitorDetailsGridPair(1, 8, 2, 8);
            AppartmentNumber = new CompetitorDetailsGridPair(3, 8, 4, 8);

            City = new CompetitorDetailsGridPair(1, 9, 2, 9);
            State = new CompetitorDetailsGridPair(3, 9, 4, 9);

            Country = new CompetitorDetailsGridPair(1, 10, 2, 10);
            PostalCode = new CompetitorDetailsGridPair(3, 10, 4, 10);

            PhoneNumber = new CompetitorDetailsGridPair(1, 11, 2, 11);
            Email = new CompetitorDetailsGridPair(3, 11, 4, 11);
        }

        public const int _columnCount = 5;
        public const int _rowCount = 12;
        public const int _minColumnWidth = 100;

        public int ColumnCount { get { return _columnCount; } }
        public int RowCount { get { return _rowCount; } }
        public int MinimumColumnWidth { get { return _minColumnWidth; } }
        public CompetitorDetailsGridPair FirstName { get; }
        public CompetitorDetailsGridPair LastName { get; }
        public CompetitorDetailsGridPair ParentFirstName { get; }
        public CompetitorDetailsGridPair ParentLastName { get; }
        public CompetitorDetailsGridPair ParentEmail { get; }
        public CompetitorDetailsGridPair Belt { get; }
        public CompetitorDetailsGridPair School { get; }
        public CompetitorDetailsGridPair Instructor { get; }
        public CompetitorDetailsGridPair Gender { get; }
        public CompetitorDetailsGridPair Weight { get; }
        public CompetitorDetailsGridPair Height { get; }
        public CompetitorDetailsGridPair PhoneNumber { get; }
        public CompetitorDetailsGridPair Email { get; }
        public CompetitorDetailsGridPair Country { get; }
        public CompetitorDetailsGridPair Age { get; }
        public CompetitorDetailsGridPair Special { get; }
        public CompetitorDetailsGridPair RegisteredEvents { get; }
        public CompetitorDetailsGridPair Title { get; }
        public CompetitorDetailsGridPair OtherSchool { get; }
        public CompetitorDetailsGridPair Street1 { get; }
        public CompetitorDetailsGridPair Street2 { get; }
        public CompetitorDetailsGridPair City { get; }
        public CompetitorDetailsGridPair State { get; }
        public CompetitorDetailsGridPair AppartmentNumber { get; }
        public CompetitorDetailsGridPair PostalCode { get; }
    }
}
