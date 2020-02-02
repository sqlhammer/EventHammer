using DKK_App.Entities;
using DKK_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DKK_App.Enums;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using DKK_App.Objects;
using System.Deployment.Application;
using DKK_App.Exceptions;
using System.Configuration;

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
                case FilterType.Height:
                    return await FilterCompetitorModelAsync_Height(model, pattern);
                case FilterType.Weight:
                    return await FilterCompetitorModelAsync_Weight(model, pattern);
                case FilterType.Age:
                    return await FilterCompetitorModelAsync_Age(model, pattern);
            }

            return model;
        }

        public static async Task<List<CompetitorModel>> FilterCompetitorModelAsync(List<CompetitorModel> model, FilterType filter)
        {
            switch (filter)
            {
                case FilterType.Minor:
                    return await FilterCompetitorModelAsync_Minor(model);
                case FilterType.IsSpecialConsideration:
                    return await FilterCompetitorModelAsync_IsSpecialConsideration(model);
            }

            return model;
        }

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_IsSpecialConsideration(List<CompetitorModel> model)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => m.IsSpecialConsideration).ToList();
            });

            return result;
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

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_Minor(List<CompetitorModel> model)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => m.Age < 18).ToList();
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

        private static async Task<List<CompetitorModel>> FilterCompetitorModelAsync_Height(List<CompetitorModel> model, string pattern)
        {
            var result = await Task.Run(() =>
            {
                return model.Where(m => m.Height >= Convert.ToDecimal(pattern) - 5 && m.Height <= Convert.ToDecimal(pattern) + 5).ToList();
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
        public static async Task<List<MatchModel>> FilterMatchModelAsync (List<MatchModel> model, FilterType filter, string pattern, List<CompetitorModel> competitors, List<MatchType> matchTypes)
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
                case FilterType.Height:
                    return await FilterMatchModelAsync_Height(model, pattern);
                case FilterType.Age:
                    return await FilterMatchModelAsync_Age(model, pattern);
                case FilterType.DojoName:
                    return await FilterMatchModelAsync_Dojo(model, pattern);
                case FilterType.MatchDisplayName:
                    return await FilterMatchModelAsync_MatchDisplayName(model, pattern);
                case FilterType.MatchType:
                    return await FilterMatchModelAsync_MatchType(model, pattern);
                case FilterType.MatchesWithTooFewCompetitors:
                    return await FilterMatchModelAsync_MatchesWithTooFewCompetitors(model);
                case FilterType.Minor:
                    return await FilterMatchModelAsync_Minor(model);
                case FilterType.DuplicateMatchType:
                    return await FilterMatchModelAsync_DuplicateMatchType(model, competitors, matchTypes);
            }

            return model;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_DuplicateMatchType(List<MatchModel> model, List<CompetitorModel> competitors, List<MatchType> matchTypes)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (CompetitorModel c in competitors)
                {
                    foreach (MatchType mt in matchTypes)
                    {
                        List<MatchModel> models = model.Where(y => y.Children.Any(z => z.CompetitorId == c.CompetitorId) && y.MatchTypeId == mt.MatchTypeId).ToList();

                        if (models.Count > 1)
                            filteredModel.AddRange(models);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        public static List<MatchModel> FilterMatchModel_ApplicableMatches (List<MatchModel> model, CompetitorModel competitor, List<Division> divisions)
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

        private static async Task<List<MatchModel>> FilterMatchModelAsync_MatchesWithTooFewCompetitors(List<MatchModel> model)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Count <= 1)
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Minor(List<MatchModel> model)
        {
            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (m.Children.Any(i => i.Age < 18))
                    {
                        filteredModel.Add(m);
                    }
                }

                return filteredModel;
            });

            return result;
        }

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Age(List<MatchModel> model, string pattern)
        {
            decimal number;
            bool isNumber = false;
            if (Decimal.TryParse(pattern, out number))
                isNumber = true;

            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (!isNumber)
                    {
                        filteredModel.Add(m);
                        continue;
                    }

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

        private static async Task<List<MatchModel>> FilterMatchModelAsync_Height(List<MatchModel> model, string pattern)
        {
            decimal number;
            bool isNumber = false;
            if (Decimal.TryParse(pattern, out number))
                isNumber = true;

            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (!isNumber)
                    {
                        filteredModel.Add(m);
                        continue;
                    }

                    if (m.Children.Any(i => i.Height >= Convert.ToDecimal(pattern) - 5 &&
                        i.Height <= Convert.ToDecimal(pattern) + 5))
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
            decimal number;
            bool isNumber = false;
            if (Decimal.TryParse(pattern, out number))
                isNumber = true;

            var result = await Task.Run(() =>
            {
                List<MatchModel> filteredModel = new List<MatchModel>();

                foreach (var m in model)
                {
                    if (!isNumber)
                    {
                        filteredModel.Add(m);
                        continue;
                    }

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

                mm.EventId = obj.Match.Event.EventId;
                mm.DivisionId = obj.Match.Division.DivisionId;
                mm.MatchTypeId = obj.Match.MatchType.MatchTypeId;
                mm.MatchId = obj.Match.MatchId;
                mm.SubDivisionId = obj.Match.SubDivisionId;
                mm.MatchTypeName = GetMatchTypeDisplayName(obj.Match.MatchType,LengthType.Long);
                mm.MatchTypeDisplayName = obj.Match.MatchType.MatchTypeDisplayName;
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
                mm.DisplayName = (obj.Competitor.Person != null) ? obj.Competitor.Person.DisplayName : null;
                mm.DojoName = (obj.Competitor.Dojo != null) ? obj.Competitor.Dojo.Facility.FacilityName : null; 
                mm.Gender = (obj.Competitor.Person != null) ? obj.Competitor.Person.Gender : null;
                mm.RankName = (obj.Competitor.Rank != null) ? obj.Competitor.Rank.RankName : null;
                mm.Weight = obj.Competitor.Weight;
                mm.Height = obj.Competitor.Height;
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
                    Height = comp.Height,
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

        public static List<EventModel> GetEventModel(List<Event> events)
        {
            List<Models.EventModel> model = new List<Models.EventModel>();

            foreach (Event obj in events)
            {
                if (model.Any(m => m.EventId == obj.EventId))
                    continue;

                EventModel em = new EventModel
                {
                    EventId = obj.EventId,
                    Date = obj.Date,
                    EventName = obj.EventName,
                    EventTypeName = obj.EventType.EventTypeName
                };

                model.Add(em);
            }

            return model;
        }

        public static List<DivisionModel> GetDivisionModel(List<Division> divisions)
        {
            List<DivisionModel> model = new List<Models.DivisionModel>();

            foreach (Division obj in divisions)
            {
                if (model.Any(m => m.DivisionId == obj.DivisionId))
                    continue;

                DivisionModel dm = new DivisionModel
                {
                    DivisionId = obj.DivisionId,
                    Gender = obj.Gender,
                    IsKata = obj.IsKata,
                    IsWeaponKata = obj.IsWeaponKata,
                    IsSemiKnockdown = obj.IsSemiKnockdown,
                    IsKnockdown = obj.IsKnockdown,
                    MaxAge = obj.MaxAge,
                    MaxBelt = obj.MaxRank.RankName,
                    MaxWeight_lb = obj.MaxWeight_lb,
                    MinAge = obj.MinAge,
                    MinBelt = obj.MinRank.RankName,
                    MinWeight_lb = obj.MinWeight_lb,
                    WeightClass = obj.WeightClass
                };

                model.Add(dm);
            }

            return model;
        }

        public static CompetitorModel GetCompetitorModel(Competitor obj)
        {
            CompetitorModel mm = new CompetitorModel(obj);

            return mm;
        }

        public static List<CompetitorModel> GetCompetitorModel(List<Competitor> mcs)
        {
            List<Models.CompetitorModel> model = new List<Models.CompetitorModel>();
            
            foreach (Competitor obj in mcs)
            {
                if (model.Any(m => m.CompetitorId == obj.CompetitorId))
                    continue;

                CompetitorModel mm = new CompetitorModel(obj);

                model.Add(mm);
            }

            return model;
        }
        #endregion

        #region Match Modification
        public static List<MatchModel> AddCompetitorToMatch (CompetitorModel comp, MatchModel match, List<MatchModel> matches)
        {
            DataAccess.AddCompetitorToEvent(comp, match);

            MatchModel newComp = new MatchModel();

            newComp.CompetitorId = comp.CompetitorId;
            newComp.MatchId = match.MatchId;
            newComp.Age = comp.Age;
            newComp.DisplayName = comp.DisplayName;
            newComp.DojoName = comp.DojoName;
            newComp.Gender = comp.Gender;
            newComp.RankName = comp.RankName;
            newComp.Weight = comp.Weight;
            newComp.Height = comp.Height;
            newComp.Children = new List<MatchModel>();

            foreach (MatchModel m in matches)
            {
                if(m.MatchId == match.MatchId)
                {
                    m.Children.Add(newComp);
                    break;
                }
            }
            
            return matches;
        }
        #endregion

        #region Validators and Conversions
        public static ScoreErrorType ValidateScores(SortableBindingList<Score> scoreList, Event currentEvent)
        {
            List<Score> scores = new List<Score>();

            //Eliminate disqualified rows from the validation
            foreach (Score score in scoreList.Where(x => x.IsDisqualified == false))
            {
                scores.Add(score);
            }

            //Incomplete row check
            foreach (Score s in scores)
            {
                ScoreErrorType err = s.HasAllRequiredAttributes();
                if (err != ScoreErrorType.None)
                {
                    return err;
                }
            }

            //Duplicate competitor check
            List<int> matchIds = new List<int>();
            foreach(Score s in scores)
            {
                matchIds.Add(s.MatchId);
            }
            matchIds = matchIds.Distinct().ToList();

            foreach(int matchId in matchIds)
            {
                foreach (Score s in scores.Where(y => y.MatchId == matchId))
                {
                    if (scores.Count(x => x.MatchId == matchId && x.CompetitorId == s.CompetitorId) > 1)
                        return ScoreErrorType.DuplicateCompetitorInMatch;
                }
            }

            //Duplicate rank check
            //Only look at first, second, third.
            //I expected if we do not rank below third place, default values of 0s will be left and therefore are not duplicates.
            foreach (int matchId in matchIds)
            {
                foreach (Score s in scores.Where(y => y.MatchId == matchId))
                {
                    if (scores.Count(x => x.MatchId == matchId && x.Ranked == s.Ranked) > 1)
                        return ScoreErrorType.DuplicateRankInMatch;
                }
            }

            return ScoreErrorType.None;
        }

        public static string GetEscapedSQLText(string query)
        {
            return query.Replace("'", "''");
        }

        public static Competitor GetCompetitorFromCompetitorModel(CompetitorModel cm)
        {
            return DataAccess.GetCompetitor(cm.CompetitorId);
        }

        public static bool IsUniqueEventName(Event e)
        {
            bool IsUniqueEventName = false;

            if (DataAccess.GetEventsByName(e.EventName).Count == 0)
            {
                IsUniqueEventName = true;
            }

            return IsUniqueEventName;
        }

        public static bool IsDuplicatePerson(Person person)
        {
            bool IsDuplicate = true;

            if (DataAccess.GetPerson(person) == null)
            {
                IsDuplicate = false;
            }

            return IsDuplicate;
        }

        public static bool IsValidInteger(string num)
        {
            Regex regex = new Regex(@"^\d*$");
            System.Text.RegularExpressions.Match match = regex.Match(num);

            return match.Success;
        }

        public static bool IsDuplicateMatchDisplayId(List<MatchModel> models, int divisionId, int subDivisionId)
        {
            bool IsDuplicate = true;

            MatchModel model = models.Where(m => m.DivisionId == divisionId && m.SubDivisionId == subDivisionId).FirstOrDefault();

            if (model == null)
            {
                IsDuplicate = false;
            }

            return IsDuplicate;
        }

        public static string GetMatchDisplayName(int division, int subdivision)
        {
            return division.ToString() + "-" + subdivision.ToString();
        }

        public static string GetMatchDisplayName(string division, string subdivision)
        {
            return division + "-" + subdivision;
        }

        public static string GetMatchDisplayName(decimal division, decimal subdivision)
        {
            return division.ToString() + "-" + subdivision.ToString();
        }

        public static string GetMatchTypeDisplayName(MatchType mt, LengthType len = LengthType.Long)
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

        public static string IsValidEvent(Event Event, bool IsNewEvent)
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

            //Check uniqueness
            if(IsNewEvent && !IsUniqueEventName(Event))
            {
                result = "Error: EventName is not unique.";
                return result;
            }

            return result;
        }
        #endregion

        #region Helper 

        public static string GetConnectionState()
        {
            return ConfigurationManager.AppSettings["LastConnectionState"];
        }

        public static void InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                    return;
                }
                catch (InvalidDeploymentException ide)
                {
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                    return;
                }
                catch (InvalidOperationException ioe)
                {
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                    return;
                }

                if (info.UpdateAvailable)
                {
                    Boolean doUpdate = true;

                    if (!info.IsUpdateRequired)
                    {
                        DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                        if (!(DialogResult.OK == dr))
                        {
                            doUpdate = false;
                        }
                    }
                    else
                    {
                        // Display a message that the app MUST reboot. Display the minimum required version.
                        MessageBox.Show("This application has detected a mandatory update from your current " +
                            "version to version " + info.MinimumRequiredVersion.ToString() +
                            ". The application will now install the update and restart.",
                            "Update Available", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    if (doUpdate)
                    {
                        try
                        {
                            ad.Update();
                            MessageBox.Show("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You are on the latest version of the software.",
                            "No Update Necessary", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
            }
        }

        public static Font AutoResizeFont(Control control)
        {
            // min font size / min control width
            // treelistview example: 7.875 / 458
            double font_multiplier = 1;
            double size_multiplier = 1;

            //string debug = control.GetType().ToString();

            switch (control.GetType().ToString())
            {
                case "BrightIdeasSoftware.TreeListView":
                    font_multiplier = 0.017;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.DataGridView":
                    font_multiplier = 0.01;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.TextBox":
                    font_multiplier = 0.033;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.RichTextBox":
                    font_multiplier = 0.033;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.ComboBox":
                    font_multiplier = 0.033;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.DateTimePicker":
                    font_multiplier = 0.033;
                    size_multiplier = control.Width;
                    break;
                case "System.Windows.Forms.Button":
                    font_multiplier = 0.080;
                    size_multiplier = control.Width;
                    break;
                    //default:
                    //    debug = debug;
                    //    break;
            }

            float size = (float)(size_multiplier * font_multiplier);

            if (size < 8) size = 8;

            return new Font
                (
                    "Microsoft Sans Serif",
                    size,
                    FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point
                );
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        #endregion

        public static void CheckForUpdates()
        {
            var AvailableVersion = WebAccess.GetLatestEventHammerVersion();
            var CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            if (AvailableVersion > CurrentVersion)
            {
                string msg = "There is a newer version of Event Hammer available. Download and install it now by going to \"Help > Download latest version\".";
                MessageBox.Show(msg, "Update is available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
