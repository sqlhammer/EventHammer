namespace DKK_App.Entities
{
    public class Facility
    {
        public int FacilityId { get; set; }
        public string AppartmentCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public FacilityType FacilityType { get; set; }
        public string FacilityName { get; set; }
        public Person Owner { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string StateProvidence { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
    }
}
