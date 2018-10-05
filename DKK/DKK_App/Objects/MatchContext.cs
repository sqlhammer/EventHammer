using DKK_App.Models;
using System.Collections.Generic;

namespace DKK_App.Objects
{
    public class MatchContext
    {
        public MatchContext ()
        {
            SelectedModel = new MatchModel();
            CollapsedModels = new List<MatchModel>();
            ExpandedModels = new List<MatchModel>();
        }

        public MatchContext (MatchModel selected, List<MatchModel> collapsed, List<MatchModel> expanded)
        {
            SelectedModel = selected;
            CollapsedModels = collapsed;
            ExpandedModels = expanded;
        }

        public MatchModel SelectedModel { get; set; }
        public List<MatchModel> CollapsedModels { get; set; }
        public List<MatchModel> ExpandedModels { get; set; }
    }
}
