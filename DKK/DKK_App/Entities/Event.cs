using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKK_App.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; }
    }
}
