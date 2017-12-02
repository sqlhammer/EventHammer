using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using DKK_App.Entities;
using System.Linq;

namespace DKK_App
{
    public static class DataAccess
    {        
        #region EventType Gets
        public static List<EventType> GetEventTypeByName(string name)
        {
            string query = @"SELECT et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM [Event].[EventType] et
                            WHERE et.Name = '" + name + "'";

            return QueryEventTypeInformation(query);
        }

        public static List<EventType> GetEventTypes()
        {
            string query = @"SELECT et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM [Event].[EventType] et";

            return QueryEventTypeInformation(query);
        }

        private static List<EventType> QueryEventTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<EventType> types = new List<EventType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                types.Add(new EventType
                                {
                                    EventTypeId = Convert.ToInt32(reader["EventTypeId"].ToString()),
                                    EventTypeName = reader["EventTypeName"].ToString()
                                });
                            }
                        }
                    }
                }

                return types;
            }
        }
        #endregion

        #region Competitor Gets
        public static Competitor GetCompetitor(int id)
        {
            string query = @"SELECT CompetitorId
	                          ,PersonId
	                          ,DateOfBirth
	                          ,Age
	                          ,Weight
	                          ,RankId
	                          ,DojoId
	                          ,ParentId
	                          ,IsMinor
	                          ,IsSpecialConsideration
	                          ,EventId
	                          ,IsKata
	                          ,IsWeaponKata
	                          ,IsSemiKnockdown
	                          ,IsKnockdown
                        FROM Person.Competitor
                        WHERE CompetitorId = " + id.ToString();

            Competitor c = QueryCompetitorInformation(query).FirstOrDefault();

            c.Person = GetPerson(c.Person.PersonId);
            c.Parent = GetPerson(c.Parent.PersonId);
            c.Rank = GetRank(c.Rank.RankId);
            c.Event = GetEventInformationById(c.Event.EventId);

            return c;
        }
        
        private static List<Competitor> QueryCompetitorInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Competitor> objs = new List<Competitor>();
                Rank rank = new Rank();
                Event Event = new Event();
                Person person = new Person();
                Person parent = new Person();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                rank.RankId = Convert.ToInt32(reader["RankId"].ToString());
                                person.PersonId = Convert.ToInt32(reader["PersonId"].ToString());
                                parent.PersonId = Convert.ToInt32(reader["ParentId"].ToString());

                                objs.Add(new Competitor
                                {
                                    Age = Convert.ToInt32(reader["Age"].ToString()),
                                    CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString()),
                                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString()),
                                    DojoId = Convert.ToInt32(reader["DojoId"].ToString()),
                                    IsKata = Convert.ToBoolean(reader["IsKata"].ToString()),
                                    IsKnockdown = Convert.ToBoolean(reader["IsKnockdown"].ToString()),
                                    IsMinor = Convert.ToBoolean(reader["IsMinor"].ToString()),
                                    IsSemiKnockdown = Convert.ToBoolean(reader["IsSemiKnockdown"].ToString()),
                                    IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString()),
                                    IsWeaponKata = Convert.ToBoolean(reader["IsWeaponKata"].ToString()),
                                    Event = Event,
                                    Weight = Convert.ToDecimal(reader["Weight"].ToString()),
                                    Rank = rank,
                                    Parent = parent,
                                    Person = person
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion
        
        #region Rank Gets
        public static Rank GetRank(int id)
        {
            string query = @"SELECT r.RankId
	                              ,r.Name
	                              ,r.Level
	                              ,r.Kyn
                            FROM Event.Rank r
                            WHERE r.RankId = " + id.ToString();

            return QueryRankInformation(query).FirstOrDefault();
        }

        private static List<Rank> QueryRankInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Rank> objs = new List<Rank>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                objs.Add(new Rank
                                {
                                    RankId = Convert.ToInt32(reader["RankId"].ToString()),
                                    Kyn = reader["Kyn"].ToString(),
                                    Level = Convert.ToInt32(reader["Level"].ToString()),
                                    RankName = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Title Gets
        public static Title GetTitle(int id)
        {
            string query = @"SELECT t.TitleId
	                              ,t.Name
                            FROM Person.Title t
                            WHERE t.TitleId = " + id.ToString();
            
            return QueryTitleInformation(query).FirstOrDefault();
        }

        private static List<Title> QueryTitleInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Title> objs = new List<Title>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                objs.Add(new Title
                                {
                                    TitleId = Convert.ToInt32(reader["TitleId"].ToString()),
                                    TitleName = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Person Gets
        public static Person GetPerson(int id)
        {
            string query = @"SELECT p.PersonId
	                          ,p.FirstName
	                          ,p.LastName
	                          ,p.DisplayName
	                          ,p.TitleId
	                          ,p.IsInstructor
	                          ,p.Gender
	                          ,p.PhoneNumber
	                          ,p.EmailAddress
	                          ,p.StreetAddress1
	                          ,p.StreetAddress2
	                          ,p.AppartmentCode
	                          ,p.City
	                          ,p.StateProvince
	                          ,p.PostalCode
	                          ,p.Country
                        FROM Person.Person p
                        WHERE p.PersonId = " + id.ToString();

            Person person = QueryPersonInformation(query).FirstOrDefault();
            person.Title = GetTitle(person.Title.TitleId);

            return person;
        }

        private static List<Person> QueryPersonInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Person> objs = new List<Person>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Title t = new Title();
                                string title = reader["TitleId"].ToString();
                                if (!String.IsNullOrEmpty(title))
                                {
                                    t.TitleId = Convert.ToInt32(title);
                                }

                                objs.Add(new Person
                                {
                                    PersonId = Convert.ToInt32(reader["PersonId"].ToString()),
                                    AppartmentCode = reader["AppartmentCode"].ToString(),
                                    City = reader["City"].ToString(),
                                    Country = reader["Country"].ToString(),
                                    DisplayName = reader["DisplayName"].ToString(),
                                    EmailAddress = reader["EmailAddress"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    IsInstructor = Convert.ToBoolean(reader["IsInstructor"].ToString()),
                                    LastName = reader["LastName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    PostalCode = reader["PostalCode"].ToString(),
                                    StateProvince = reader["StateProvince"].ToString(),
                                    StreetAddress1 = reader["StreetAddress1"].ToString(),
                                    StreetAddress2 = reader["StreetAddress2"].ToString(),
                                    Title = t
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region MatchType Gets
        public static MatchType GetMatchType(int id)
        {
            string query = @"SELECT MatchTypeId
	                              ,Name
	                              ,IsSpecialConsideration 
                            FROM Event.MatchType
                            WHERE MatchTypeId = " + id.ToString();

            return QueryMatchTypeInformation(query).FirstOrDefault();
        }

        private static List<MatchType> QueryMatchTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MatchType> objs = new List<MatchType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                objs.Add(new MatchType
                                {
                                    MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString()),
                                    IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString()),
                                    MatchTypeName = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Match Gets
        public static List<Match> GetMatches(Event Event)
        {
            string query = @"SELECT MatchId
	                              ,EventId
	                              ,MatchTypeId
	                              ,DivisionId
	                              ,SubDivisionId
                            FROM [Event].[Match] m
                            WHERE m.EventId = " + Event.EventId.ToString();

            return QueryMatchInformation(query);
        }

        public static Match GetMatch(int id)
        {
            string query = @"SELECT MatchId
	                              ,EventId
	                              ,MatchTypeId
	                              ,DivisionId
	                              ,SubDivisionId
                            FROM [Event].[Match] m
                            WHERE m.MatchId = " + id.ToString();

            Match m = QueryMatchInformation(query).FirstOrDefault();

            m.MatchType = GetMatchType(m.MatchType.MatchTypeId);

            return m;
        }

        private static List<Match> QueryMatchInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Match> objs = new List<Match>();
                Division div = new Division();
                MatchType mt = new MatchType();
                Event Event = new Event();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                div.DivisionId = Convert.ToInt32(reader["DivisionId"].ToString());
                                mt.MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString());
                                Event.EventId = Convert.ToInt32(reader["EventId"].ToString());

                                objs.Add(new Match
                                {
                                    MatchId = Convert.ToInt32(reader["MatchId"].ToString()),
                                    SubDivisionId = Convert.ToInt32(reader["SubDivisionId"].ToString()),
                                    Division = div,
                                    MatchType = mt,
                                    Event = Event
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region MatchCompetitor Gets
        public static List<MatchCompetitor> GetMatchCompetitors(Event Event)
        {
            string query = @"SELECT mcd.MatchCompetitorId
	                              ,mcd.MatchId
	                              ,mcd.CompetitorId
	                              ,mcd.MatchPlacement
	                              ,mcd.EventId
	                              ,mcd.MatchTypeId
	                              ,mcd.DivisionId
	                              ,mcd.SubDivisionId
	                              ,mcd.MatchTypeName
	                              ,mcd.MatchIsSpecialConsideration
	                              ,mcd.EventName
	                              ,mcd.EventTypeId
	                              ,mcd.EventDate
	                              ,mcd.EventTypeName
	                              ,mcd.PersonId
	                              ,mcd.DateOfBirth
	                              ,mcd.Age
	                              ,mcd.Weight
	                              ,mcd.DojoId
	                              ,mcd.IsMinor
	                              ,mcd.IsSpecialConsideration
	                              ,mcd.IsKata
	                              ,mcd.IsWeaponKata
	                              ,mcd.IsSemiKnockdown
	                              ,mcd.IsKnockdown
	                              ,mcd.FirstName
	                              ,mcd.LastName
	                              ,mcd.DisplayName
	                              ,mcd.IsInstructor
	                              ,mcd.Gender
	                              ,mcd.PhoneNumber
	                              ,mcd.EmailAddress
	                              ,mcd.StreetAddress1
	                              ,mcd.StreetAddress2
	                              ,mcd.AppartmentCode
	                              ,mcd.City
	                              ,mcd.StateProvince
	                              ,mcd.PostalCode
	                              ,mcd.Country
	                              ,mcd.ParentId
	                              ,mcd.ParentFirstName
	                              ,mcd.ParentLastName
	                              ,mcd.ParentDisplayName
	                              ,mcd.ParentEmailAddress
	                              ,mcd.RankId
	                              ,mcd.Belt
	                              ,mcd.Level
	                              ,mcd.Kyn
	                              ,mcd.DojoName
	                              ,mcd.OwnerId
	                              ,mcd.FacilityTypeId
	                              ,mcd.FacilityTypeName
	                              ,mcd.OwnerFirstName
	                              ,mcd.OwnerLastName
	                              ,mcd.OwnerDisplayName
	                              ,mcd.TitleId
	                              ,mcd.TitleName
	                              ,mcd.OwnerTitleId
	                              ,mcd.OwnerTitleName
	                              ,mcd.MinimumWeight_lb
	                              ,mcd.MaximumWeight_lb
	                              ,mcd.WeightClass
	                              ,mcd.DivisionGender
	                              ,mcd.MinimumLevelId
	                              ,mcd.MaximumLevelId
	                              ,mcd.MinimumAge
	                              ,mcd.MaximumAge
	                              ,mcd.DivisionIsKata
	                              ,mcd.DivisionMaxBelt
	                              ,mcd.DivisionMaxLevel
	                              ,mcd.DivisionMaxKyn
	                              ,mcd.DivisionMinBelt
	                              ,mcd.DivisionMinLevel
	                              ,mcd.DivisionMinKyn
                            FROM Event.vwMatchCompetitorDetail mcd
                            WHERE mcd.EventId = " + Event.EventId.ToString();

            List<MatchCompetitor> mcs = QueryMatchCompetitorDetails(query);

            return mcs;
        }

        public static List<MatchCompetitor> GetMatchCompetitors(Competitor competitor)
        {
            //Retrieve base data
            string query = @"SELECT mc.MatchCompetitorId
	                                ,mc.MatchId
	                                ,mc.CompetitorId
	                                ,ISNULL(mc.MatchPlacement,0) MatchPlacement
                            FROM [Event].MatchCompetitor mc
                            WHERE mc.CompetitorId = " + competitor.CompetitorId.ToString();

            List<MatchCompetitor> mcs = QueryMatchCompetitorInformation(query);

            //Populate matches and competitors
            foreach (MatchCompetitor mc in mcs)
            {
                mc.Match = GetMatch(mc.Match.MatchId);
                mc.Competitor = GetCompetitor(mc.Competitor.CompetitorId);
            }

            return mcs;
        }

        private static List<MatchCompetitor> QueryMatchCompetitorDetails(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MatchCompetitor> objs = new List<MatchCompetitor>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                //MinRank
                                Rank min_r = new Rank
                                {
                                    Kyn = reader["DivisionMinKyn"].ToString(),
                                    Level = Convert.ToInt32(reader["DivisionMinLevel"].ToString()),
                                    RankId = Convert.ToInt32(reader["MinimumLevelId"].ToString()),
                                    RankName = reader["DivisionMinBelt"].ToString()
                                };

                                //MaxRank
                                Rank max_r = new Rank
                                {
                                    Kyn = reader["DivisionMaxKyn"].ToString(),
                                    Level = Convert.ToInt32(reader["DivisionMaxLevel"].ToString()),
                                    RankId = Convert.ToInt32(reader["MaximumLevelId"].ToString()),
                                    RankName = reader["DivisionMaxBelt"].ToString()
                                };

                                //Division
                                Division d = new Division
                                {
                                    DivisionId = Convert.ToInt32(reader["DivisionId"].ToString()),
                                    Gender = reader["DivisionGender"].ToString(),
                                    IsKata = Convert.ToBoolean(reader["DivisionIsKata"].ToString()),
                                    MaxAge = Convert.ToInt32(reader["MaximumAge"].ToString()),
                                    MinAge = Convert.ToInt32(reader["MinimumAge"].ToString()),
                                    MaxWeight_lb = Convert.ToDecimal(reader["MaximumWeight_lb"].ToString()),
                                    MinWeight_lb = Convert.ToDecimal(reader["MinimumWeight_lb"].ToString()),
                                    WeightClass = reader["WeightClass"].ToString(),
                                    MaxRank = max_r,
                                    MinRank = min_r
                                };

                                //Competitor title
                                Title ct = new Title();
                                if (!String.IsNullOrEmpty(reader["TitleId"].ToString()))
                                {
                                    ct.TitleId = Convert.ToInt32(reader["TitleId"].ToString());
                                    ct.TitleName = reader["TitleName"].ToString();
                                }

                                //EventType
                                EventType et = new EventType
                                {
                                    EventTypeId = Convert.ToInt32(reader["EventTypeId"].ToString()),
                                    EventTypeName = reader["EventTypeName"].ToString()
                                };

                                //Event
                                Event e = new Event
                                {
                                    Date = Convert.ToDateTime(reader["EventDate"].ToString()),
                                    EventId = Convert.ToInt32(reader["EventId"].ToString()),
                                    EventName = reader["EventName"].ToString(),
                                    EventType = et
                                };

                                //Rank
                                Rank r = new Rank
                                {
                                    Kyn = reader["Kyn"].ToString(),
                                    Level = Convert.ToInt32(reader["Level"].ToString()),
                                    RankId = Convert.ToInt32(reader["RankId"].ToString()),
                                    RankName = reader["Belt"].ToString()
                                };

                                //Parent
                                Person parent = new Person();
                                if (!String.IsNullOrEmpty(reader["ParentId"].ToString()))
                                {                                    
                                    parent.DisplayName = reader["ParentDisplayName"].ToString();
                                    parent.EmailAddress = reader["ParentEmailAddress"].ToString();
                                    parent.FirstName = reader["ParentFirstName"].ToString();
                                    parent.LastName = reader["ParentLastName"].ToString();
                                    parent.PersonId = Convert.ToInt32(reader["ParentId"].ToString());                                    
                                }

                                //Person
                                Person person = new Person();
                                if (!String.IsNullOrEmpty(reader["PersonId"].ToString()))
                                {
                                    person.AppartmentCode = reader["AppartmentCode"].ToString();
                                    person.City = reader["City"].ToString();
                                    person.Country = reader["Country"].ToString();
                                    person.DisplayName = reader["DisplayName"].ToString();
                                    person.EmailAddress = reader["EmailAddress"].ToString();
                                    person.FirstName = reader["FirstName"].ToString();
                                    person.Gender = reader["Gender"].ToString();
                                    person.IsInstructor = Convert.ToBoolean(reader["IsInstructor"].ToString());
                                    person.LastName = reader["LastName"].ToString();
                                    person.PersonId = Convert.ToInt32(reader["PersonId"].ToString());
                                    person.PhoneNumber = reader["PhoneNumber"].ToString();
                                    person.PostalCode = reader["PostalCode"].ToString();
                                    person.StateProvince = reader["StateProvince"].ToString();
                                    person.StreetAddress1 = reader["StreetAddress1"].ToString();
                                    person.StreetAddress2 = reader["StreetAddress2"].ToString();
                                    person.Title = ct;
                                }

                                //Competitor
                                Competitor c = new Competitor
                                {
                                    Age = Convert.ToInt32(reader["Age"].ToString()),
                                    CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString()),
                                    IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString()),
                                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString()),
                                    DojoId = Convert.ToInt32(reader["DojoId"].ToString()),
                                    Event = e,
                                    IsKata = Convert.ToBoolean(reader["IsKata"].ToString()),
                                    IsKnockdown = Convert.ToBoolean(reader["IsKnockdown"].ToString()),
                                    IsMinor = Convert.ToBoolean(reader["IsMinor"].ToString()),
                                    IsSemiKnockdown = Convert.ToBoolean(reader["IsSemiKnockdown"].ToString()),
                                    IsWeaponKata = Convert.ToBoolean(reader["IsWeaponKata"].ToString()),
                                    Parent = parent,
                                    Person = person,
                                    Rank = r,
                                    Weight = Convert.ToDecimal(reader["Weight"].ToString())
                                };

                                //MatchType
                                MatchType mt = new MatchType
                                {
                                    MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString()),
                                    MatchTypeName = reader["MatchTypeName"].ToString(),
                                    IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString())
                                };

                                //Match
                                Match m = new Match
                                {
                                    MatchId = Convert.ToInt32(reader["MatchId"].ToString()),
                                    SubDivisionId = Convert.ToInt32(reader["SubDivisionId"].ToString()),
                                    Division = d,
                                    Event = e,
                                    MatchType = mt
                                };

                                //MatchCompetitor
                                MatchCompetitor mc = new MatchCompetitor
                                {
                                    MatchCompetitorId = Convert.ToInt32(reader["MatchCompetitorId"].ToString()),
                                    Competitor = c,
                                    Match = m
                                };
                                if(!String.IsNullOrEmpty(reader["MatchPlacement"].ToString()))
                                {
                                    mc.MatchPlacement = Convert.ToInt32(reader["MatchPlacement"].ToString());
                                }

                                objs.Add(mc);
                            }
                        }
                    }
                }

                return objs;
            }
        }

        private static List<MatchCompetitor> QueryMatchCompetitorInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MatchCompetitor> objs = new List<MatchCompetitor>();
                Match match = new Match();
                Competitor competitor = new Competitor();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                match.MatchId = Convert.ToInt32(reader["MatchId"].ToString());
                                competitor.CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString());

                                objs.Add(new MatchCompetitor
                                {
                                    MatchCompetitorId = Convert.ToInt32(reader["MatchCompetitorId"].ToString()),
                                    Match = match,
                                    Competitor = competitor,
                                    MatchPlacement = Convert.ToInt32(reader["MatchPlacement"].ToString())
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Event Gets
        public static List<Event> GetEventInformationByDateRange(DateTime minDate, DateTime maxDate)
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e
                            WHERE e.Date BETWEEN CAST('" + minDate.ToString("yyyyMMdd") + @"' AS DATE) 
                                AND CAST('" + maxDate.ToString("yyyyMMdd") + @"' AS DATE)";

            return QueryEventInformation(query);
        }

        public static Event GetEventInformationById(int id)
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e
                            WHERE e.EventId = " + id.ToString();

            return QueryEventInformation(query).FirstOrDefault();
        }

        public static List<Event> GetEventInformation()
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e";

            return QueryEventInformation(query);
        }

        private static List<Event> QueryEventInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Event> events = new List<Event>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                EventType type = new EventType
                                {
                                    EventTypeId = Convert.ToInt32(reader["EventTypeId"].ToString()),
                                    EventTypeName = reader["EventTypeName"].ToString()
                                };

                                events.Add(new Event
                                {
                                    EventId = Convert.ToInt32(reader["EventId"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                                    EventName = reader["EventName"].ToString(),
                                    EventType = type
                                });
                            }
                        }
                    }
                }

                return events;
            }
        }
        #endregion

        #region Deletes
        public static void DeleteEvent(int id)
        {
            string query = @"EXEC [Event].[spDeleteEvent] @EventId = " + id.ToString();

            ExecuteDDL(query);
        }

        public static void DeleteEvent (Event Event)
        {
            string query = @"EXEC [Event].[spDeleteEvent] @EventId = " + Event.EventId.ToString();

            ExecuteDDL(query);
        }
        #endregion

        #region Updates
        public static void UpdateEvent(Event Event)
        {
            string query = @"EXEC [Event].[spUpdateEvent] @EventId = 
                " + Event.EventId.ToString() + @", @EventName = '" +
                Event.EventName + @"', @EventTypeId = " +
                Event.EventType.EventTypeId.ToString() + @", @Date = '" +
                Event.Date.ToString("yyyyMMdd") + @"';";

            ExecuteDDL(query);
        }
        #endregion

        #region Inserts
        public static void InsertEvent(Event Event)
        {
            string query = @"EXEC [Event].[spInsertEvent] @EventName = '" +
                Event.EventName + @"', @EventTypeId = " +
                Event.EventType.EventTypeId.ToString() + @", @Date = '" +
                Event.Date.ToString("yyyyMMdd") + @"';";

            ExecuteDDL(query);
        }
        #endregion

        public static void ExecuteDDL(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
