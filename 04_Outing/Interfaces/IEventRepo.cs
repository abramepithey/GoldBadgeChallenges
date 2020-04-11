using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing.Interfaces
{
    public interface IEventRepo
    {
        void CreateNewEvent(Event newEvent);
        List<Event> GetAllEvents();
        double GetCostOfAllEvents();
        double GetCostOfEventType(EventTypes type);
        List<Event> GetAllEventsOfType(EventTypes type);
        double DisplayNumber(double fullLengthNumber);
    }
}
