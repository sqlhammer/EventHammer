using System;

namespace DKK_App.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
    }
}
