using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using DKK_App.Entities;
using System.Linq;
using System.Threading.Tasks;
using DKK_App.Models;
using System.ComponentModel;
using DKK_App.Objects;

namespace DKK_App
{
    public static class DataAccessAsync
    {        
        #region EventType Gets
        public static async Task<List<EventType>> GetEventTypeByName(string name)
        {
            string query = @"SELECT et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM [Event].[EventType] et
                            WHERE et.Name = '" + name + "'";

            return await QueryEventTypeInformation(query);
        }

        public static async Task<List<EventType>> GetEventTypes()
        {
            string query = @"SELECT et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM [Event].[EventType] et";
            
            return await QueryEventTypeInformation(query);
        }
        
        private static async Task<List<EventType>> QueryEventTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<EventType> types = new List<EventType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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
        public static async Task<Competitor> GetCompetitor(int id)
        {
            string query = @"SELECT CompetitorId,
                               DateOfBirth,
                               Age,
                               Weight,
                               Height,
                               DojoId,
                               OtherDojoName,
                               ParentId,
                               IsMinor,
                               IsSpecialConsideration,
                               ConsiderationDescription,
                               IsKata,
                               IsWeaponKata,
                               IsSemiKnockdown,
                               IsKnockdown,
                               PersonId,
                               FirstName,
                               LastName,
                               DisplayName,
                               TitleId,
                               TitleName,
                               IsInstructor,
                               Gender,
                               PhoneNumber,
                               EmailAddress,
                               StreetAddress1,
                               StreetAddress2,
                               AppartmentCode,
                               City,
                               StateProvince,
                               PostalCode,
                               Country,
                               ParentPersonId,
                               ParentFirstName,
                               ParentLastName,
                               ParentDisplayName,
                               ParentEmailAddress,
                               RankId,
                               Belt,
                               Level,
                               Kyu,
                               EventId,
                               EventName,
                               EventTypeId,
                               EventDate,
                               DojoName,
                               OwnerId,
                               FacilityId,
                               FacilityName,
                               FacilityPhoneNumber,
                               FacilityEmail,
                               FacilityStreetAddress1,
                               FacilityStreetAddress2,
                               FacilityAppartmentCode,
                               FacilityCity,
                               FacilityStateProvidence,
                               FacilityPostalCode,
                               FacilityCountry,
                               FacilityTypeId,
                               FacilityTypeName,
                               OwnerFirstName,
                               OwnerLastName,
                               OwnerDisplayName,
	                           MartialArtTypeId,
	                           MartialArtTypeName,
                               OtherInstructorName
                        FROM [Person].[vwCompetitorDetail]
                        WHERE CompetitorId = " + id.ToString();

            List<Competitor> cs = await QueryCompetitorInformation(query);
            Competitor c = cs.FirstOrDefault();

            return c;
        }

        public static async Task<List<Competitor>> GetCompetitors(Event Event)
        {
            string query = @"SELECT CompetitorId,
                               DateOfBirth,
                               Age,
                               Weight,
                               Height,
                               DojoId,
                               OtherDojoName,
                               ParentId,
                               IsMinor,
                               IsSpecialConsideration,
                               ConsiderationDescription,
                               IsKata,
                               IsWeaponKata,
                               IsSemiKnockdown,
                               IsKnockdown,
                               PersonId,
                               FirstName,
                               LastName,
                               DisplayName,
                               TitleId,
                               TitleName,
                               IsInstructor,
                               Gender,
                               PhoneNumber,
                               EmailAddress,
                               StreetAddress1,
                               StreetAddress2,
                               AppartmentCode,
                               City,
                               StateProvince,
                               PostalCode,
                               Country,
                               ParentPersonId,
                               ParentFirstName,
                               ParentLastName,
                               ParentDisplayName,
                               ParentEmailAddress,
                               RankId,
                               Belt,
                               Level,
                               Kyu,
                               EventId,
                               EventName,
                               EventTypeId,
                               EventDate,
                               DojoName,
                               OwnerId,
                               FacilityId,
                               FacilityName,
                               FacilityPhoneNumber,
                               FacilityEmail,
                               FacilityStreetAddress1,
                               FacilityStreetAddress2,
                               FacilityAppartmentCode,
                               FacilityCity,
                               FacilityStateProvidence,
                               FacilityPostalCode,
                               FacilityCountry,
                               FacilityTypeId,
                               FacilityTypeName,
                               OwnerFirstName,
                               OwnerLastName,
                               OwnerDisplayName,
	                           MartialArtTypeId,
	                           MartialArtTypeName,
                               OtherInstructorName
                        FROM [Person].[vwCompetitorDetail]
                        WHERE EventId = " + Event.EventId.ToString();

            List<Competitor> cs = await QueryCompetitorInformation(query);
            
            return cs;
        }

        private static async Task<List<Competitor>> QueryCompetitorInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Competitor> objs = new List<Competitor>();
                Event Event = new Event();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                Rank rank = new Rank();
                                Person person = new Person();
                                Person parent = new Person();
                                Dojo dojo = new Dojo
                                {
                                    MartialArtType = new MartialArtType(),
                                    Facility = new Facility()
                                };
                                
                                //Competitor title
                                Title ct = new Title();
                                if (!String.IsNullOrEmpty(reader["TitleId"].ToString()))
                                {
                                    ct.TitleId = Convert.ToInt32(reader["TitleId"].ToString());
                                    ct.TitleName = reader["TitleName"].ToString();
                                }

                                //Rank
                                if (!String.IsNullOrEmpty(reader["RankId"].ToString()))
                                {
                                    rank.Kyu = reader["Kyu"].ToString();
                                    rank.Level = Convert.ToInt32(reader["Level"].ToString());
                                    rank.RankId = Convert.ToInt32(reader["RankId"].ToString());
                                    rank.RankName = reader["Belt"].ToString();
                                }

                                //Parent
                                if (!String.IsNullOrEmpty(reader["ParentId"].ToString()))
                                {
                                    parent.DisplayName = reader["ParentDisplayName"].ToString();
                                    parent.EmailAddress = reader["ParentEmailAddress"].ToString();
                                    parent.FirstName = reader["ParentFirstName"].ToString();
                                    parent.LastName = (reader["ParentLastName"] != null) ? reader["ParentLastName"].ToString() : null;
                                    parent.PersonId = Convert.ToInt32(reader["ParentId"].ToString());
                                }

                                //Person
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
                                    person.StreetAddress1 = (reader["StreetAddress1"] != null) ? reader["StreetAddress1"].ToString() : null;
                                    person.StreetAddress2 = (reader["StreetAddress2"] != null) ? reader["StreetAddress2"].ToString() : null;
                                    person.Title = ct;
                                }

                                //Dojo
                                int dojoid = (!String.IsNullOrEmpty(reader["DojoId"].ToString())) ? Convert.ToInt32(reader["DojoId"].ToString()) : 0;
                                int ownerid = (!String.IsNullOrEmpty(reader["OwnerId"].ToString())) ? Convert.ToInt32(reader["OwnerId"].ToString()) : 0;
                                
                                if (dojoid > 0)
                                {
                                    Person owner = new Person();
                                    if (ownerid > 0)
                                    {
                                        owner = new Person
                                        {
                                            PersonId = ownerid,
                                            FirstName = reader["OwnerFirstName"].ToString(),
                                            LastName = reader["OwnerLastName"].ToString(),
                                            DisplayName = reader["OwnerDisplayName"].ToString(),
                                        };
                                    }

                                    dojo = new Dojo
                                    {
                                        DojoId = dojoid,
                                        Facility = new Facility
                                        {
                                            FacilityId = Convert.ToInt32(reader["FacilityId"].ToString()),
                                            FacilityName = reader["FacilityName"].ToString(),
                                            StreetAddress1 = (reader["FacilityStreetAddress1"] != null) ? reader["FacilityStreetAddress1"].ToString() : null,
                                            StreetAddress2 = (reader["FacilityStreetAddress2"] != null) ? reader["FacilityStreetAddress2"].ToString() : null,
                                            AppartmentCode = (reader["FacilityAppartmentCode"] != null) ? reader["FacilityAppartmentCode"].ToString() : null,
                                            City = (reader["FacilityCity"] != null) ? reader["FacilityCity"].ToString() : null,
                                            Country = (reader["FacilityCountry"] != null) ? reader["FacilityCountry"].ToString() : null,
                                            Email = (reader["FacilityEmail"] != null) ? reader["FacilityEmail"].ToString() : null,
                                            PhoneNumber = (reader["FacilityPhoneNumber"] != null) ? reader["FacilityPhoneNumber"].ToString() : null,
                                            PostalCode = (reader["FacilityPostalCode"] != null) ? reader["FacilityPostalCode"].ToString() : null,
                                            StateProvidence = (reader["FacilityStateProvidence"] != null) ? reader["FacilityStateProvidence"].ToString() : null,
                                            FacilityType = new FacilityType
                                            {
                                                FacilityTypeId = Convert.ToInt32(reader["FacilityTypeId"].ToString()),
                                                FacilityTypeName = (reader["FacilityTypeName"] != null) ? reader["FacilityTypeName"].ToString() : null,
                                            },
                                            Owner = owner
                                        },
                                        MartialArtType = new MartialArtType
                                        {
                                            MartialArtTypeId = Convert.ToInt32(reader["MartialArtTypeId"].ToString()),
                                            MartialArtTypeName = reader["MartialArtTypeName"].ToString()
                                        }
                                    };
                                }

                                objs.Add(new Competitor
                                {
                                    Age = Convert.ToInt32(reader["Age"].ToString()),
                                    CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString()),
                                    OtherInstructorName = (reader["OtherInstructorName"] != null) ? reader["OtherInstructorName"].ToString() : null,
                                    Dojo = dojo,
                                    IsKata = Convert.ToBoolean(reader["IsKata"].ToString()),
                                    IsKnockdown = Convert.ToBoolean(reader["IsKnockdown"].ToString()),
                                    IsMinor = Convert.ToBoolean(reader["IsMinor"].ToString()),
                                    IsSemiKnockdown = Convert.ToBoolean(reader["IsSemiKnockdown"].ToString()),
                                    IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString()),
                                    IsWeaponKata = Convert.ToBoolean(reader["IsWeaponKata"].ToString()),
                                    Event = Event,
                                    Weight = Convert.ToDecimal(reader["Weight"].ToString()),
                                    Height = Convert.ToDecimal(reader["Height"].ToString()),
                                    Description = reader["ConsiderationDescription"].ToString(),
                                    Rank = rank,
                                    Parent = parent,
                                    Person = person,
                                    OtherDojoName = reader["OtherDojoName"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion
        
        #region Division Gets
        public static async Task<List<Division>> GetDivisions()
        {
            string query = @"SELECT d.DivisionId
	                              ,d.MinimumWeight_lb
	                              ,d.MaximumWeight_lb
	                              ,d.WeightClass
	                              ,d.Gender
	                              ,d.MinimumLevelId
	                              ,d.MaximumLevelId
	                              ,d.MinimumAge
	                              ,d.MaximumAge
	                              ,d.IsKata 
	                              ,d.IsWeaponKata
	                              ,d.IsSemiKnockdown
	                              ,d.IsKnockdown
                            FROM Event.Division d";

            return await QueryDivisionInformation(query);
        }

        private static async Task<List<Division>> QueryDivisionInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Division> objs = new List<Division>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                objs.Add(new Division
                                {
                                    DivisionId = Convert.ToInt32(reader["DivisionId"].ToString()),
                                    Gender = reader["Gender"].ToString(),
                                    IsKata = Convert.ToBoolean(reader["IsKata"].ToString()),
                                    IsWeaponKata = Convert.ToBoolean(reader["IsWeaponKata"].ToString()),
                                    IsSemiKnockdown = Convert.ToBoolean(reader["IsSemiKnockdown"].ToString()),
                                    IsKnockdown = Convert.ToBoolean(reader["IsKnockdown"].ToString()),
                                    MaxAge = Convert.ToInt32(reader["MaximumAge"].ToString()),
                                    MaxRank = await GetRank(Convert.ToInt32(reader["MaximumLevelId"].ToString())),
                                    MaxWeight_lb = Convert.ToDecimal(reader["MaximumWeight_lb"].ToString()),
                                    MinAge = Convert.ToInt32(reader["MinimumAge"].ToString()),
                                    MinRank = await GetRank(Convert.ToInt32(reader["MinimumLevelId"].ToString())),
                                    MinWeight_lb = Convert.ToDecimal(reader["MinimumWeight_lb"].ToString()),
                                    WeightClass = reader["WeightClass"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Dojo Gets
        public static async Task<List<Dojo>> GetDojos ()
        {
            string query = @"SELECT d.DojoId
	                              ,d.FacilityId
	                              ,d.MartialArtTypeId
                            FROM Facility.Dojo d;";

            return await QueryDojoInformation(query);
        }

        public static async Task<Dojo> GetDojo(int id)
        {
            string query = @"SELECT d.DojoId
	                              ,d.FacilityId
	                              ,d.MartialArtTypeId
                            FROM Facility.Dojo d
                            WHERE d.DojoId = " + id.ToString();

            var results = await QueryDojoInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<Dojo>> QueryDojoInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Dojo> objs = new List<Dojo>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                objs.Add(new Dojo
                                {
                                    DojoId = Convert.ToInt32(reader["DojoId"].ToString()),
                                    Facility = await GetFacility(Convert.ToInt32(reader["FacilityId"].ToString())),
                                    MartialArtType = await GetMartialArtType(Convert.ToInt32(reader["MartialArtTypeId"].ToString()))
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region MartialArtType Gets
        public static async Task<MartialArtType> GetMartialArtType(int id)
        {
            string query = @"SELECT mat.MartialArtTypeId
	                              ,mat.Name
                            FROM Facility.MartialArtType mat
                            WHERE mat.MartialArtTypeId = " + id.ToString();

            var results = await QueryMartialArtTypeInformation(query);
            var result = results.FirstOrDefault();

            return result; 
        }

        private static async Task<List<MartialArtType>> QueryMartialArtTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MartialArtType> objs = new List<MartialArtType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                objs.Add(new MartialArtType
                                {
                                    MartialArtTypeId = Convert.ToInt32(reader["MartialArtTypeId"].ToString()),
                                    MartialArtTypeName = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region Facility Gets
        public static async Task<Facility> GetFacility(int id)
        {
            string query = @"SELECT f.FacilityId
	                              ,f.Name
	                              ,f.PhoneNumber
	                              ,f.Email
	                              ,f.OwnerId
	                              ,f.FacilityTypeId
	                              ,f.StreetAddress1
	                              ,f.StreetAddress2
	                              ,f.AppartmentCode
	                              ,f.City
	                              ,f.StateProvidence
	                              ,f.PostalCode
	                              ,f.Country 
                            FROM Facility.Facility f
                            WHERE f.FacilityId = " + id.ToString();

            var results = await QueryFacilityInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<Facility>> QueryFacilityInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Facility> objs = new List<Facility>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                Person owner = new Person();
                                if(!String.IsNullOrEmpty(reader["OwnerId"].ToString()))
                                {
                                    owner = await GetPerson(Convert.ToInt32(reader["OwnerId"].ToString()));
                                }

                                objs.Add(new Facility
                                {
                                    FacilityName = reader["Name"].ToString(),
                                    FacilityId = Convert.ToInt32(reader["FacilityId"].ToString()),
                                    FacilityType = await GetFacilityType(Convert.ToInt32(reader["FacilityTypeId"].ToString())),
                                    AppartmentCode = (reader["AppartmentCode"] != null) ? reader["AppartmentCode"].ToString() : null,
                                    City = (reader["City"] != null) ? reader["City"].ToString() : null,
                                    Country = (reader["Country"] != null) ? reader["Country"].ToString() : null,
                                    Email = (reader["Email"] != null) ? reader["Email"].ToString() : null,
                                    Owner = owner,
                                    PhoneNumber = (reader["PhoneNumber"] != null) ? reader["PhoneNumber"].ToString() : null,
                                    PostalCode = (reader["PostalCode"] != null) ? reader["PostalCode"].ToString() : null,
                                    StateProvidence = (reader["StateProvidence"] != null) ? reader["StateProvidence"].ToString() : null,
                                    StreetAddress1 = (reader["StreetAddress1"] != null) ? reader["StreetAddress1"].ToString() : null,
                                    StreetAddress2 = (reader["StreetAddress2"] != null) ? reader["StreetAddress2"].ToString() : null
                                });
                            }
                        }
                    }
                }

                return objs;
            }
        }
        #endregion

        #region FacilityType Gets
        public static async Task<FacilityType> GetFacilityType(int id)
        {
            string query = @"SELECT ft.FacilityTypeId
	                              ,ft.Name
                            FROM Facility.FacilityType ft
                            WHERE ft.FacilityTypeId =" + id.ToString();

            var results = await QueryFacilityTypeInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<FacilityType>> QueryFacilityTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<FacilityType> objs = new List<FacilityType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                objs.Add(new FacilityType
                                {
                                    FacilityTypeId = Convert.ToInt32(reader["FacilityTypeId"].ToString()),
                                    FacilityTypeName = reader["Name"].ToString()
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
        public static async Task<List<Rank>> GetRanks()
        {
            string query = @"SELECT r.RankId
	                              ,r.Name
	                              ,r.Level
	                              ,r.Kyu
                            FROM Event.Rank r;";

            return await QueryRankInformation(query);
        }

        public static async Task<Rank> GetRank(int id)
        {
            string query = @"SELECT r.RankId
	                              ,r.Name
	                              ,r.Level
	                              ,r.Kyu
                            FROM Event.Rank r
                            WHERE r.RankId = " + id.ToString();

            var results = await QueryRankInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<Rank>> QueryRankInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Rank> objs = new List<Rank>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                objs.Add(new Rank
                                {
                                    RankId = Convert.ToInt32(reader["RankId"].ToString()),
                                    Kyu = reader["Kyu"].ToString(),
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
        public static async Task<List<Title>> GetTitles ()
        {
            string query = @"SELECT t.TitleId
	                              ,t.Name
                            FROM Person.Title t;";
            
            return await QueryTitleInformation(query);
        }

        public static async Task<Title> GetTitle(int id)
        {
            string query = @"SELECT t.TitleId
	                              ,t.Name
                            FROM Person.Title t
                            WHERE t.TitleId = " + id.ToString();

            var results = await QueryTitleInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<Title>> QueryTitleInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Title> objs = new List<Title>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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
        public static async Task<Person> GetPerson(int id)
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

            var persons = await QueryPersonInformation(query);
            Person person = persons.FirstOrDefault();
            if (person != null && person.Title != null)
            {
                person.Title = await GetTitle(person.Title.TitleId);
            }

            return person;
        }

        private static async Task<List<Person>> QueryPersonInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Person> objs = new List<Person>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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
        public static async Task<MatchType> GetMatchType(int id)
        {
            string query = @"SELECT MatchTypeId
	                              ,Name
	                              ,IsSpecialConsideration 
                            FROM Event.MatchType
                            WHERE MatchTypeId = " + id.ToString();

            var results = await QueryMatchTypeInformation(query);
            var result = results.FirstOrDefault();

            return result;
        }

        private static async Task<List<MatchType>> QueryMatchTypeInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MatchType> objs = new List<MatchType>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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
        public static async Task<List<Match>> GetMatches(Event Event)
        {
            string query = @"SELECT MatchId
                                  ,MatchDisplayId
	                              ,EventId
	                              ,MatchTypeId
	                              ,DivisionId
	                              ,SubDivisionId
                            FROM [Event].[Match] m
                            WHERE m.EventId = " + Event.EventId.ToString();

            return await QueryMatchInformation(query);
        }

        public static async Task<Match> GetMatch(int id)
        {
            string query = @"SELECT MatchId
                                  ,MatchDisplayId
	                              ,EventId
	                              ,MatchTypeId
	                              ,DivisionId
	                              ,SubDivisionId
                            FROM [Event].[Match] m
                            WHERE m.MatchId = " + id.ToString();

            var results = await QueryMatchInformation(query);
            Match m = results.FirstOrDefault();

            m.MatchType = await GetMatchType(m.MatchType.MatchTypeId);

            return m;
        }

        private static async Task<List<Match>> QueryMatchInformation(string query)
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
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                div.DivisionId = Convert.ToInt32(reader["DivisionId"].ToString());
                                mt.MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString());
                                Event.EventId = Convert.ToInt32(reader["EventId"].ToString());

                                objs.Add(new Match
                                {
                                    MatchId = Convert.ToInt32(reader["MatchId"].ToString()),
                                    SubDivisionId = Convert.ToInt32(reader["SubDivisionId"].ToString()),
                                    MatchDisplayId = Convert.ToInt32(reader["MatchDisplayId"].ToString()),
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
        public static async Task<List<MatchCompetitor>> GetMatchCompetitors(Event Event)
        {
            string query = @"SELECT mcd.MatchCompetitorId
	                              ,mcd.MatchId
                                  ,mcd.MatchDisplayId
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
	                              --,mcd.DateOfBirth
	                              ,mcd.Age
	                              ,mcd.Weight
                                  ,mcd.Height
	                              ,mcd.DojoId
                                  ,mcd.OtherDojoName
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
	                              ,mcd.Kyu
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
	                              ,mcd.DivisionMaxKyu
	                              ,mcd.DivisionMinBelt
	                              ,mcd.DivisionMinLevel
	                              ,mcd.DivisionMinKyu
	                              ,mcd.OwnerId
	                              ,mcd.FacilityId
	                              ,mcd.FacilityName
	                              ,mcd.FacilityPhoneNumber
	                              ,mcd.FacilityEmail
	                              ,mcd.FacilityStreetAddress1
	                              ,mcd.FacilityStreetAddress2
	                              ,mcd.FacilityAppartmentCode
	                              ,mcd.FacilityCity
	                              ,mcd.FacilityStateProvidence
	                              ,mcd.FacilityPostalCode
	                              ,mcd.FacilityCountry
                                  ,mcd.MartialArtTypeId
                                  ,mcd.MartialArtTypeName
                            FROM Event.vwMatchCompetitorDetail mcd
                            WHERE mcd.EventId = " + Event.EventId.ToString();
            
            return await QueryMatchCompetitorDetails(query);
        }

        public static async Task<List<MatchCompetitor>> GetMatchCompetitors(Competitor competitor)
        {
            //Retrieve base data
            string query = @"SELECT mc.MatchCompetitorId
	                                ,mc.MatchId
	                                ,mc.CompetitorId
	                                ,ISNULL(mc.MatchPlacement,0) MatchPlacement
                            FROM [Event].MatchCompetitor mc
                            WHERE mc.CompetitorId = " + competitor.CompetitorId.ToString();

            List<MatchCompetitor> mcs = await QueryMatchCompetitorInformation(query);

            //Populate matches and competitors
            foreach (MatchCompetitor mc in mcs)
            {
                mc.Match = await GetMatch(mc.Match.MatchId);
                mc.Competitor = await GetCompetitor(mc.Competitor.CompetitorId);
            }

            return mcs;
        }

        private static async Task<List<MatchCompetitor>> QueryMatchCompetitorDetails(string query)
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
                            while (await reader.ReadAsync())
                            {
                                //MinRank
                                Rank min_r = new Rank
                                {
                                    Kyu = reader["DivisionMinKyu"].ToString(),
                                    Level = Convert.ToInt32(reader["DivisionMinLevel"].ToString()),
                                    RankId = Convert.ToInt32(reader["MinimumLevelId"].ToString()),
                                    RankName = reader["DivisionMinBelt"].ToString()
                                };

                                //MaxRank
                                Rank max_r = new Rank
                                {
                                    Kyu = reader["DivisionMaxKyu"].ToString(),
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
                                Rank r = new Rank();
                                if (!String.IsNullOrEmpty(reader["RankId"].ToString()))
                                {
                                    r.Kyu = reader["Kyu"].ToString();
                                    r.Level = Convert.ToInt32(reader["Level"].ToString());
                                    r.RankId = Convert.ToInt32(reader["RankId"].ToString());
                                    r.RankName = reader["Belt"].ToString();
                                }

                                //Parent
                                Person parent = new Person();
                                if (!String.IsNullOrEmpty(reader["ParentId"].ToString()))
                                {                                    
                                    parent.DisplayName = reader["ParentDisplayName"].ToString();
                                    parent.EmailAddress = reader["ParentEmailAddress"].ToString();
                                    parent.FirstName = reader["ParentFirstName"].ToString();
                                    parent.LastName = (reader["ParentLastName"] != null) ? reader["ParentLastName"].ToString() : null;
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
                                    person.StreetAddress1 = (reader["StreetAddress1"] != null) ? reader["StreetAddress1"].ToString() : null;
                                    person.StreetAddress2 = (reader["StreetAddress2"] != null) ? reader["StreetAddress2"].ToString() : null;
                                    person.Title = ct;
                                }

                                //Dojo
                                int dojoid = (!String.IsNullOrEmpty(reader["DojoId"].ToString())) ? Convert.ToInt32(reader["DojoId"].ToString()) : 0;
                                int ownerid = (!String.IsNullOrEmpty(reader["OwnerId"].ToString())) ? Convert.ToInt32(reader["OwnerId"].ToString()) : 0;

                                Dojo dojo = new Dojo
                                {
                                    MartialArtType = new MartialArtType(),
                                    Facility = new Facility()
                                };
                                if (dojoid > 0)
                                {
                                    Person owner = new Person();
                                    if (ownerid > 0)
                                    {
                                        owner = new Person
                                        {
                                            PersonId = ownerid,
                                            FirstName = reader["OwnerFirstName"].ToString(),
                                            LastName = reader["OwnerLastName"].ToString(),
                                            DisplayName = reader["OwnerDisplayName"].ToString(),
                                        };
                                    }

                                    dojo = new Dojo
                                    {
                                        DojoId = dojoid,
                                        Facility = new Facility
                                        {
                                            FacilityId = Convert.ToInt32(reader["FacilityId"].ToString()),
                                            FacilityName = reader["FacilityName"].ToString(),
                                            StreetAddress1 = (reader["FacilityStreetAddress1"] != null) ? reader["FacilityStreetAddress1"].ToString() : null,
                                            StreetAddress2 = (reader["FacilityStreetAddress2"] != null) ? reader["FacilityStreetAddress2"].ToString() : null,
                                            AppartmentCode = (reader["FacilityAppartmentCode"] != null) ? reader["FacilityAppartmentCode"].ToString() : null,
                                            City = (reader["FacilityCity"] != null) ? reader["FacilityCity"].ToString() : null,
                                            Country = (reader["FacilityCountry"] != null) ? reader["FacilityCountry"].ToString() : null,
                                            Email = (reader["FacilityEmail"] != null) ? reader["FacilityEmail"].ToString() : null,
                                            PhoneNumber = (reader["FacilityPhoneNumber"] != null) ? reader["FacilityPhoneNumber"].ToString() : null,
                                            PostalCode = (reader["FacilityPostalCode"] != null) ? reader["FacilityPostalCode"].ToString() : null,
                                            StateProvidence = (reader["FacilityStateProvidence"] != null) ? reader["FacilityStateProvidence"].ToString() : null,
                                            FacilityType = new FacilityType
                                            {
                                                FacilityTypeId = Convert.ToInt32(reader["FacilityTypeId"].ToString()),
                                                FacilityTypeName = (reader["FacilityTypeName"] != null) ? reader["FacilityTypeName"].ToString() : null,
                                            },
                                            Owner = owner
                                        },
                                        MartialArtType = new MartialArtType
                                        {
                                            MartialArtTypeId = Convert.ToInt32(reader["MartialArtTypeId"].ToString()),
                                            MartialArtTypeName = reader["MartialArtTypeName"].ToString()
                                        }
                                    };
                                }

                                //Competitor
                                Competitor c = new Competitor();
                                if (!String.IsNullOrEmpty(reader["CompetitorId"].ToString()))
                                {
                                    c = new Competitor
                                    {
                                        Age = Convert.ToInt32(reader["Age"].ToString()),
                                        CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString()),
                                        IsSpecialConsideration = Convert.ToBoolean(reader["IsSpecialConsideration"].ToString()),
                                        //DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString()),
                                        Dojo = dojo,
                                        Event = e,
                                        IsKata = Convert.ToBoolean(reader["IsKata"].ToString()),
                                        IsKnockdown = Convert.ToBoolean(reader["IsKnockdown"].ToString()),
                                        IsMinor = Convert.ToBoolean(reader["IsMinor"].ToString()),
                                        IsSemiKnockdown = Convert.ToBoolean(reader["IsSemiKnockdown"].ToString()),
                                        IsWeaponKata = Convert.ToBoolean(reader["IsWeaponKata"].ToString()),
                                        Parent = parent,
                                        Person = person,
                                        Rank = r,
                                        Weight = Convert.ToDecimal(reader["Weight"].ToString()),
                                        Height = Convert.ToDecimal(reader["Height"].ToString()),
                                        OtherDojoName = reader["OtherDojoName"].ToString()
                                    };
                                }

                                //MatchType
                                MatchType mt = new MatchType();
                                if (!String.IsNullOrEmpty(reader["MatchTypeId"].ToString()))
                                {
                                    mt = new MatchType
                                    {
                                        MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString()),
                                        MatchTypeName = reader["MatchTypeName"].ToString(),
                                        IsSpecialConsideration = Convert.ToBoolean(reader["MatchIsSpecialConsideration"].ToString())
                                    };
                                }

                                //Match
                                Match m = new Match();
                                if (!String.IsNullOrEmpty(reader["MatchId"].ToString()))
                                {
                                    m = new Match
                                    {
                                        MatchId = Convert.ToInt32(reader["MatchId"].ToString()),
                                        SubDivisionId = Convert.ToInt32(reader["SubDivisionId"].ToString()),
                                        MatchDisplayId = Convert.ToInt32(reader["MatchDisplayId"].ToString()),
                                        Division = d,
                                        Event = e,
                                        MatchType = mt
                                    };
                                }

                                //MatchCompetitor
                                MatchCompetitor mc = new MatchCompetitor();
                                if (!String.IsNullOrEmpty(reader["MatchCompetitorId"].ToString()))
                                {
                                    mc.MatchCompetitorId = Convert.ToInt32(reader["MatchCompetitorId"].ToString());
                                }
                                mc.Competitor = c;
                                mc.Match = m;

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

        private static async Task<List<MatchCompetitor>> QueryMatchCompetitorInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<MatchCompetitor> objs = new List<MatchCompetitor>();
                Match match = new Match();
                Competitor competitor = new Competitor();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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
        public static async Task<List<Event>> GetEventInformationByDateRange(DateTime minDate, DateTime maxDate)
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e
                            WHERE e.Date BETWEEN CAST('" + minDate.ToString("yyyyMMdd") + @"' AS DATE) 
                                AND CAST('" + maxDate.ToString("yyyyMMdd") + @"' AS DATE)";

            return await QueryEventInformation(query);
        }

        public static async Task<Event> GetEventInformationById(int id)
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e
                            WHERE e.EventId = " + id.ToString();

            var results = await QueryEventInformation(query);

            return results.FirstOrDefault();
        }

        public static async Task<List<Event>> GetEventInformation()
        {
            string query = @"SELECT e.EventId
	                              ,e.EventName
	                              ,e.Date
	                              ,e.EventTypeId
	                              ,e.EventTypeName
                            FROM [Event].vwEvent e";

            return await QueryEventInformation(query);
        }

        private static async Task<List<Event>> QueryEventInformation(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                List<Event> events = new List<Event>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
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

        #region Score Gets
        public static async Task<SortableBindingList<Score>> GetScoresByEvent(Event Event)
        {
            string query = @"SELECT
                                [ScoreId]
                                ,[EventId]
                                ,[MatchId]
                                ,[DivisionId]
                                ,[SubDivisionId]
                                ,[MatchTypeId]
                                ,[MatchTypeName]
                                ,[CompetitorId]
                                ,[DisplayName]
                                ,[ScoreJudge1]
                                ,[ScoreJudge2]
                                ,[ScoreJudge3]
                                ,[ScoreJudge4]
                                ,[ScoreJudge5]
                                ,[Database_Total]
                                ,[Ranked]
                                ,[IsDisqualified]
                            FROM [Event].[vwScore]
                            WHERE EventId = " + Event.EventId;

            return await QueryScores(query);
        }

        private static async Task<SortableBindingList<Score>> QueryScores(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                SortableBindingList<Score> scores = new SortableBindingList<Score>();

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                scores.Add(new Score
                                {
                                    CompetitorId = Convert.ToInt32(reader["CompetitorId"].ToString()),
                                    EventId = Convert.ToInt32(reader["EventId"].ToString()),
                                    DivisionId = Convert.ToInt32(reader["DivisionId"].ToString()),
                                    MatchId = Convert.ToInt32(reader["MatchId"].ToString()),
                                    MatchTypeId = Convert.ToInt32(reader["MatchTypeId"].ToString()),
                                    ScoreId = Convert.ToInt32(reader["ScoreId"].ToString()),
                                    IsDisqualified = Convert.ToBoolean(reader["IsDisqualified"].ToString()),
                                    SubDivisionId = Convert.ToInt32(reader["SubDivisionId"].ToString()),
                                    Database_Total = Convert.ToDecimal(reader["Database_Total"].ToString()),
                                    Ranked = Convert.ToInt32(reader["Ranked"].ToString()),
                                    DisplayName = reader["DisplayName"].ToString(),
                                    ScoreJudge1 = Convert.ToDecimal(reader["ScoreJudge1"].ToString()),
                                    ScoreJudge2 = Convert.ToDecimal(reader["ScoreJudge2"].ToString()),
                                    ScoreJudge3 = Convert.ToDecimal(reader["ScoreJudge3"].ToString()),
                                    ScoreJudge4 = Convert.ToDecimal(reader["ScoreJudge4"].ToString()),
                                    ScoreJudge5 = Convert.ToDecimal(reader["ScoreJudge5"].ToString()),
                                });
                            }
                        }
                    }
                }

                return scores;
            }
        }
        #endregion Score Gets

        #region Deletes
        public static void DeleteEventAsync(int id)
        {
            string query = @"EXEC [Event].[spDeleteEvent] @EventId = " + id.ToString();

            Task.Run(() => { ExecuteDDL(query); });
        }

        public static void DeleteEventAsync (Event Event)
        {
            string query = @"EXEC [Event].[spDeleteEvent] @EventId = " + Event.EventId.ToString();

            Task.Run(() => { ExecuteDDL(query); });
        }

        public static void DeleteMatchAsync(Match match)
        {
            string query = @"EXEC [Event].[spDeleteMatch] @MatchId = " + match.MatchId.ToString();

            Task.Run(() => { ExecuteDDL(query); });
        }

        public static void DeleteMatchAsync(MatchModel match)
        {
            string query = @"EXEC [Event].[spDeleteMatch] @MatchId = " + match.MatchId.ToString();

            Task.Run(() => { ExecuteDDL(query); });
        }
        #endregion

        #region Updates
        public static async void UpdateEvent(Event Event)
        {
            string query = @"EXEC [Event].[spUpdateEvent] @EventId = 
                " + Event.EventId.ToString() + @", @EventName = '" +
                Event.EventName + @"', @EventTypeId = " +
                Event.EventType.EventTypeId.ToString() + @", @Date = '" +
                Event.Date.ToString("yyyyMMdd") + @"';";

            ExecuteDDL(query);
        }

        public static async void UpdateMatchDisplayId(MatchModel match)
        {
            string query = @"EXEC [Event].[spUpdateMatchDisplayId] @MatchId = 
                " + match.MatchId.ToString() + @", @MatchDisplayId = " +
                match.DivisionId.ToString() + @", @SubDivisionId = " +
                match.SubDivisionId.ToString() + @";";

            ExecuteDDL(query);
        }
        #endregion

        #region Inserts
        public static async void InsertEvent(Event Event)
        {
            string query = @"EXEC [Event].[spInsertEvent] @EventName = '" +
                Event.EventName + @"', @EventTypeId = " +
                Event.EventType.EventTypeId.ToString() + @", @Date = '" +
                Event.Date.ToString("yyyyMMdd") + @"';";

            ExecuteDDL(query);
        }
        #endregion

        public static async void ExecuteDDL(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DKK"].ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["SqlCommandTimeout"]);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
