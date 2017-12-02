using DKK_App.Entities;
using DKK_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DKK_App
{
    public static class Global
    {
        private enum LengthType
        {
            Short = 0,
            Long = 1
        }

        private static string GetMatchTypeDisplayName(MatchType mt, LengthType len = LengthType.Long)
        {
            string dn = "";
            string specialSuffix = "";

            switch (len)
            {
                case LengthType.Short:
                    specialSuffix = "*";
                    break;
                case LengthType.Long: 
                    specialSuffix = " (IsSpecialConsideration)";
                    break;
            }

            switch (mt.IsSpecialConsideration)
            {
                case true:
                    dn = mt.MatchTypeName + specialSuffix;
                    break;
                case false:
                    dn = mt.MatchTypeName;
                    break;
            }

            return dn;
        }

        public static List<MatchModel> GetMatchModel(List<MatchCompetitor> mcs)
        {
            //TODO: Refactor this whole process when you get smarter.

            List<Models.MatchModel> model = new List<Models.MatchModel>();
            List<Models.MatchModel> competitors = new List<MatchModel>();
            List<Models.MatchModel> subdivisions = new List<MatchModel>();
            List<Models.MatchModel> divisions = new List<MatchModel>();
            List<Models.MatchModel> matchtypes = new List<MatchModel>();

            //Build models

            //MatchTypes
            foreach (MatchCompetitor obj in mcs)
            {
                MatchModel mm = new MatchModel();

                if (matchtypes.Any(m => m.MatchTypeId == obj.Match.MatchType.MatchTypeId))
                    continue;

                mm.MatchTypeId = obj.Match.MatchType.MatchTypeId;
                mm.MatchTypeName = GetMatchTypeDisplayName(obj.Match.MatchType, LengthType.Short);
                mm.Children = new List<MatchModel>();

                matchtypes.Add(mm);
            }

            //Divisions
            foreach (MatchCompetitor obj in mcs)
            {
                MatchModel mm = new MatchModel();

                if (divisions.Any(m => m.DivisionId == obj.Match.Division.DivisionId &&
                    m.MatchTypeId == obj.Match.MatchType.MatchTypeId))
                    continue;

                mm.DivisionId = obj.Match.Division.DivisionId;
                mm.MatchTypeId = obj.Match.MatchType.MatchTypeId;
                mm.Children = new List<MatchModel>();

                divisions.Add(mm);
            }

            //SubDivisions
            foreach (MatchCompetitor obj in mcs)
            {
                MatchModel mm = new MatchModel();

                if (subdivisions.Any(m => m.MatchId == obj.Match.MatchId))
                    continue;

                mm.MatchId = obj.Match.MatchId;
                mm.DivisionId = obj.Match.Division.DivisionId;
                mm.SubDivisionId = obj.Match.SubDivisionId;
                mm.Children = new List<MatchModel>();

                subdivisions.Add(mm);
            }

            //Competitor
            foreach (MatchCompetitor obj in mcs)
            {
                MatchModel mm = new MatchModel();

                if (competitors.Any(m => m.CompetitorId == obj.Competitor.CompetitorId &&
                    m.MatchId == obj.Match.MatchId))
                    continue;

                mm.CompetitorId = obj.Competitor.CompetitorId;
                mm.MatchId = obj.Match.MatchId;
                mm.Age = obj.Competitor.Age;
                mm.DisplayName = obj.Competitor.Person.DisplayName;
                //TODO: dojoname 
                //mm.DojoName = obj.Competitor.
                mm.Gender = obj.Competitor.Person.Gender;
                mm.RankName = obj.Competitor.Rank.RankName;
                mm.Weight = obj.Competitor.Weight;
                mm.Children = new List<MatchModel>();

                competitors.Add(mm);
            }

            //Nest the models

            // Comp > Sub Divs
                        
            foreach (MatchModel comp in competitors)
            {
                MatchCompetitor mc = mcs.First(m => m.Competitor.CompetitorId == (int)comp.CompetitorId && 
                    m.Match.MatchId == comp.MatchId);
                MatchModel subdiv = subdivisions.First(m => m.MatchId == mc.Match.MatchId);

                MatchModel mm = new MatchModel
                {
                    Age = comp.Age,
                    CompetitorId = comp.CompetitorId,
                    DisplayName = comp.DisplayName,
                    DojoName = comp.DojoName,
                    Gender = comp.Gender,
                    RankName = comp.RankName,
                    Weight = comp.Weight,
                    Children = comp.Children
                };

                subdiv.Children.Add(mm);
            }

            // Sub Divs > Divs
            
            foreach (MatchModel subdiv in subdivisions)
            {
                MatchCompetitor mc = mcs.First(m => m.Match.MatchId == subdiv.MatchId);
                MatchModel div = divisions.First(m => m.MatchTypeId == mc.Match.MatchType.MatchTypeId &&
                    m.DivisionId == mc.Match.Division.DivisionId);

                MatchModel mm = new MatchModel
                {
                    SubDivisionId = subdiv.SubDivisionId,
                    MatchId = subdiv.MatchId,
                    Children = subdiv.Children
                };

                div.Children.Add(mm);
            }

            // Divs > MatchTypes

            foreach (MatchModel div in divisions)
            {
                MatchCompetitor mc = mcs.First(m => m.Match.Division.DivisionId == div.DivisionId &&
                    m.Match.MatchType.MatchTypeId == div.MatchTypeId);
                MatchModel mt = matchtypes.First(m => m.MatchTypeId == mc.Match.MatchType.MatchTypeId);

                MatchModel mm = new MatchModel
                {
                    DivisionId = div.DivisionId,
                    Children = div.Children
                };

                mt.Children.Add(mm);
            }

            // MatchTypes > model

            foreach (MatchModel mt in matchtypes)
            {
                model.Add(mt);
            }

            return model;
        }

        public static List<CompetitorModel> GetCompetitorModel(List<MatchCompetitor> mcs)
        {
            List<Models.CompetitorModel> model = new List<Models.CompetitorModel>();
            
            foreach (MatchCompetitor obj in mcs)
            {
                if (model.Any(m => m.CompetitorId == obj.Competitor.CompetitorId))
                    continue;

                CompetitorModel mm = new CompetitorModel();
                
                mm.CompetitorId = obj.Competitor.CompetitorId;
                mm.Age = obj.Competitor.Age;
                mm.DisplayName = obj.Competitor.Person.DisplayName;
                //TODO: dojoname 
                //mm.DojoName = obj.Competitor.
                mm.Gender = obj.Competitor.Person.Gender;
                mm.RankName = obj.Competitor.Rank.RankName;
                mm.Weight = obj.Competitor.Weight;

                model.Add(mm);
            }

            return model;
        }

        public static string IsValidEvent(Event Event)
        {
            string result = "";

            //Null checks
            if (EqualityComparer<Event>.Default.Equals(Event, default(Event)))
            {
                result = "Error: NULL or missing Event.";
                return result;
            }
            if (EqualityComparer<EventType>.Default.Equals(Event.EventType, default(EventType)))
            {
                result = "Error: NULL or missing EventType.";
                return result;
            }

            //All fields complete
            if(String.IsNullOrEmpty(Event.EventName))
            {
                result = "Error: EventName is not populated.";
                return result;
            }
            if (String.IsNullOrEmpty(Event.EventType.EventTypeName))
            {
                result = "Error: EventTypeName is not populated.";
                return result;
            }
            if (Event.Date == null)
            {
                result = "Error: Date is not populated.";
                return result;
            }

            return result;
        }
    }
}
