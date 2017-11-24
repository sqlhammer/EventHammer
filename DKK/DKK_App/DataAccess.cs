using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using DKK_App.Entities;

namespace DKK_App
{
    public static class DataAccess
    {
        public static List<Event> GetEventInformationByDateRange(DateTime minDate, DateTime maxDate)
        {
            string query = @"SELECT e.EventId
                                    ,e.Name EventName
	                                ,e.Date
	                                ,et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM[Event].[Event] e
                            INNER JOIN[Event].[EventType]
                                    et ON et.EventTypeId = e.EventTypeId
                            WHERE e.Date BETWEEN CAST('" + minDate.ToString("yyyyMMdd") + @"' AS DATE) 
                                AND CAST('" + maxDate.ToString("yyyyMMdd") + @"' AS DATE)";

            return QueryEventInformation(query);
        }

        public static List<Event> GetEventInformation()
        {
            string query = @"SELECT e.EventId
                                    ,e.Name EventName
	                                ,e.Date
	                                ,et.EventTypeId
	                                ,et.Name EventTypeName
                            FROM[Event].[Event] e
                            INNER JOIN[Event].[EventType]
                                    et ON et.EventTypeId = e.EventTypeId";

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
                                events.Add(new Event
                                {
                                    EventId = Convert.ToInt32(reader["EventId"].ToString()),
                                    Date = Convert.ToDateTime(reader["Date"].ToString()),
                                    EventName = reader["EventName"].ToString(),
                                    EventTypeId = Convert.ToInt32(reader["EventTypeId"].ToString()),
                                    EventTypeName = reader["EventTypeName"].ToString()
                                });
                            }
                        }
                    }
                }

                return events;
            }
        }
    }
}
