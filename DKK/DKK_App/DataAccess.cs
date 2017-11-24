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

            return QueryEventInformation(query).First();
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
