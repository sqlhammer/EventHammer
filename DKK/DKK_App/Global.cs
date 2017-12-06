using DKK_App.Entities;
using DKK_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DKK_App.Enums;
using System.Threading.Tasks;

namespace DKK_App
{
    public static class Global
    {
        #region Competitor Filters
        public static async Task<List<CompetitorModel>> FilterCompetitorModelAsync(List<CompetitorModel> model, FilterType filter, string pattern)
        {
            pattern = pattern.ToLower();

            switch (filter)
            {
                case FilterType.Belt:
                    return await FilterCompetitorModelAsync_Belt(model, pattern);
                case FilterType.DisplayName:
                    return await FilterCompetitorModelAsync_DisplayName(model, pattern);
                case FilterType.Weight:
                    return await FilterCompetitorModelAsync_Weight(model, pattern);
                case FilterType.Age:
                    return await FilterCompetitorModelAsync_Age(model, pattern);
            }

            return model;
        }

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_Belt(List<CompetitorModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => !String.IsNullOrEmpty(m.RankName.ToLower()) && m.RankName.ToLower().Contains(pattern)).ToList();
            });

            return result;
        }

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_DisplayName(List<CompetitorModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => !String.IsNullOrEmpty(m.DisplayName.ToLower()) && m.DisplayName.ToLower().Contains(pattern)).ToList();
            });

            return result;
        }

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_Age(List<CompetitorModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => m.Age >= Convert.ToInt32(pattern) - 2 && m.Age <= Convert.ToInt32(pattern) + 2).ToList();
            });

            return result;
        }

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_Weight(List<CompetitorModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => m.Weight >= Convert.ToDecimal(pattern) - 5 && m.Weight <= Convert.ToDecimal(pattern) + 5).ToList();
            });

            return result;
        }
        #endregion

        #region Match Filters
        public static async Task<List<MatchModel>> FilterMatchModelAsync (List<MatchModel> model, FilterType filter, string pattern)
        {
            pattern = pattern.ToLower();

            switch (filter)
            {
                case FilterType.Belt:
                    return await FilterMatchModelAsync_Belt(model, pattern);
                case FilterType.DisplayName:
                    return await FilterMatchModelAsync_DisplayName(model, pattern);
                case FilterType.Weight:
                    return await FilterMatchModelAsync_Weight(model, pattern);
                case FilterType.Age:
                    return await FilterMatchModelAsync_Age(model, pattern);
                case FilterType.DojoName:
                    return await FilterMatchModelAsync_Dojo(model, pattern);
                case FilterType.MatchDisplayName:
                    return await FilterMatchModelAsync_MatchDisplayName(model, pattern);
                case FilterType.MatchType:
                    return await FilterMatchModelAsync_MatchType(model, pattern);
            }

            return model;
        }

        public static List<MatchModel> FilterMatchModelAsync_ApplicableMatches (List<MatchModel> model, CompetitorModel competitor, List<Division> divisions)
        {
            if (divisions.Count == 0)
                return model;

            List<Division> filteredDivs = new List<Division>();

            foreach (var div in divisions)
            {
                if (div.MinAge <= competitor.Age &&
                    div.MaxAge >= competitor.Age &&
                    div.Gender == competitor.Gender &&
                    div.MinRank.Level <= competitor.Level &&
                    div.MaxRank.Level >= competitor.Level &&
                    div.MinWeight_lb <= competitor.Weight &&
                    div.MaxWeight_lb >= competitor.Weight)
                {
                    filteredDivs.Add(div);
                }
            }

            List<MatchModel> filteredModel = new List<MatchModel>();

            foreach (var m in model)
            {
                if(filteredDivs.Any(d => d.DivisionId == m.DivisionId))
                {
                    filteredModel.Add(m);
                }
            }

            return filteredModel;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Age(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.Age >= Convert.ToInt32(pattern) - 2 &&
                        i.Age <= Convert.ToInt32(pattern) + 2))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });
                        
            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Weight(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.Weight >= Convert.ToDecimal(pattern) - 5 &&
                        i.Weight <= Convert.ToDecimal(pattern) + 5))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_MatchDisplayName(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => !String.IsNullOrEmpty(m.MatchDisplayName.ToLower()) && m.MatchDisplayName.ToLower().Contains(pattern)).ToList();
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Dojo(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.DojoName.ToLower().Contains(pattern)))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_MatchType(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => !String.IsNullOrEmpty(m.MatchTypeName.ToLower()) && m.MatchTypeName.ToLower().Contains(pattern)).ToList();
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Belt(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.RankName.ToLower().Contains(pattern)))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_DisplayName(List<MatchModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.DisplayName.ToLower().Contains(pattern)))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }
        #endregion

        #region Model Builders
        public static List<MatchModel> GetMatchModel(List<MatchCompetitor> mcs)
        {
            List<Models.MatchModel> model = new List<Models.MatchModel>();
            List<Models.MatchModel> competitors = new List<MatchModel>();
            List<Models.MatchModel> divisions = new List<MatchModel>();

            //Build models

            //Grouping
            foreach (MatchCompetitor obj in mcs)
            {
                MatchModel mm = new MatchModel();

                if (divisions.Any(m => m.MatchTypeId == obj.Match.MatchType.MatchTypeId &&
                    m.MatchId == obj.Match.MatchId))
                {
                    continue;
                }

                mm.DivisionId = obj.Match.Division.DivisionId;
                mm.MatchTypeId = obj.Match.MatchType.MatchTypeId;
                mm.MatchId = obj.Match.MatchId;
                mm.MatchDisplayId = obj.Match.MatchDisplayId;
                mm.SubDivisionId = obj.Match.SubDivisionId;
                mm.MatchTypeName = GetMatchTypeDisplayName(obj.Match.MatchType,LengthType.Long);
                mm.Children = new List<MatchModel>();

                divisions.Add(mm);
            }

            //Details
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
                mm.DojoName = obj.Competitor.Dojo.Facility.FacilityName;
                mm.Gender = obj.Competitor.Person.Gender;
                mm.RankName = obj.Competitor.Rank.RankName;
                mm.Weight = obj.Competitor.Weight;
                mm.Children = new List<MatchModel>();

                competitors.Add(mm);
            }

            //Nest the models
                                    
            foreach (MatchModel comp in competitors)
            {
                MatchCompetitor mc = mcs.First(m => m.Competitor.CompetitorId == (int)comp.CompetitorId && 
                    m.Match.MatchId == comp.MatchId);
                MatchModel div = divisions.First(m => m.MatchId == mc.Match.MatchId);

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

                div.Children.Add(mm);
            }
            
            // Divs > model

            foreach (MatchModel div in divisions)
            {
                model.Add(div);
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
                mm.DojoName = obj.Competitor.Dojo.Facility.FacilityName;
                mm.Gender = obj.Competitor.Person.Gender;
                mm.RankName = obj.Competitor.Rank.RankName;
                mm.Level = obj.Competitor.Rank.Level;
                mm.Weight = obj.Competitor.Weight;

                model.Add(mm);
            }

            return model;
        }
        #endregion



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
                    specialSuffix = " (Special Consideration)";
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
