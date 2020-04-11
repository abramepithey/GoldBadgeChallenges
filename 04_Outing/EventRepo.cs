using _04_Outing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    public class EventRepo : IEventRepo
    {
        protected List<Event> _eventRepo = new List<Event>();

        public void CreateNewEvent(Event newEvent)
        {
            _eventRepo.Add(newEvent);
        }
        
        public List<Event> GetAllEvents()
        {
            return _eventRepo;
        }

        public int GetRepoCount()
        {
            int repoCount = _eventRepo.Count();
            return repoCount;
        }

        public List<Event> GetAllEventsOfType(EventTypes type)
        {
            List<Event> eventOfType = new List<Event>();
            foreach (Event specificEvent in _eventRepo)
            {
                if (specificEvent.EventType == type)
                {
                    eventOfType.Add(specificEvent);
                }
            }

            return eventOfType;
        }

        public double GetCostOfEventType(EventTypes type)
        {
            List<Event> eventOfType = GetAllEventsOfType(type);
            double totalTypeCost = 0;
            foreach (Event selectedType in eventOfType)
            {
                totalTypeCost += selectedType.TotalCost;
            }

            return totalTypeCost;
        }

        public double GetCostOfAllEvents()
        {
            double totalCost = 0;
            foreach (Event specificEvent in _eventRepo)
            {
                totalCost += specificEvent.TotalCost;
            }
            return totalCost;
        }

        public double DisplayNumber(double fullLengthNumber)
        {
            double roundedNumber = Math.Round(fullLengthNumber, 2, MidpointRounding.AwayFromZero);
            return roundedNumber;
        }
    }
}
