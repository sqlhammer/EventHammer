using System;

namespace DKK_App.Models
{
    public class EventModel
    {
        public string DateText
        {
            get
            {
                return Date.ToString("MM/dd/yyyy");
            }
        }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public string EventTypeName { get; set; }
    }
}
