namespace DKK_App.Objects
{
    public class DivisionSubDivision
    {
        public DivisionSubDivision(string div_subdiv)
        {
            DivSubDiv = div_subdiv;
            ParseDivSubDiv(div_subdiv);
        }

        public string DivSubDiv { get; set; }
        public int DivisionId { get; set; }
        public int SubDivisionId { get; set; }

        private void ParseDivSubDiv(string div_subdiv)
        {
            string[] arr = div_subdiv.Split('-');
            DivisionId = int.Parse(arr[0]);
            SubDivisionId = int.Parse(arr[1]);
        }
    }
}
