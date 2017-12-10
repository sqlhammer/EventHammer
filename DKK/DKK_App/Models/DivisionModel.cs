namespace DKK_App.Models
{
    public class DivisionModel
    {
        public int DivisionId { get; set; }
        public decimal MinWeight_lb { get; set; }
        public decimal MaxWeight_lb { get; set; }
        public string WeightClass { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool IsKata { get; set; }
        public string MinBelt { get; set; }
        public string MaxBelt { get; set; }
    }
}
