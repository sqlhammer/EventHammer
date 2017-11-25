using DKK_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DKK_App
{
    public static class Global
    {
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
