using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    public enum EventTypes
    {
        Golf,
        Bowling,
        AmusementPark,
        Concert
    }

    public class Event
    {
        public EventTypes EventType { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double CostPerPerson
        {
            get
            {
                return (TotalCost / (double)PersonCount);
            }
        }

        public Event() { }
        public Event(EventTypes eventType, int personCount, DateTime date, double totalCost)
        {
            EventType = eventType;
            PersonCount = personCount;
            Date = date;
            TotalCost = totalCost;
        }
    }
}
