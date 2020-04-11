using _04_Outing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    public class ProgramUI : IProgramUI
    {
        private readonly EventRepo _repo = new EventRepo();

        public void Run()
        {
            SeedEvents();
            MainMenu();
        }

        public void SeedEvents()
        {
            DateTime dateOne = new DateTime(2001, 5, 12);
            DateTime dateTwo = new DateTime(3005, 11, 30);
            DateTime dateThree = new DateTime(1992, 2, 21);
            DateTime dateFour = new DateTime(2020, 4, 11);
            DateTime dateFive = new DateTime(1999, 12, 31);
            DateTime dateSix = new DateTime(2011, 1, 5);

            Event eventOne = new Event(EventTypes.AmusementPark, 21, dateOne, 3478.29478);
            Event eventTwo = new Event(EventTypes.AmusementPark, 70, dateTwo, 37562.12345);
            Event eventThree = new Event(EventTypes.Bowling, 4, dateThree, 90.73625);
            Event eventFour = new Event(EventTypes.Concert, 18, dateFour, 222.421273);
            Event eventFive = new Event(EventTypes.Golf, 3, dateFive, 99999.999999);
            Event eventSix = new Event(EventTypes.Bowling, 99, dateSix, 10);

            _repo.CreateNewEvent(eventOne);
            _repo.CreateNewEvent(eventTwo);
            _repo.CreateNewEvent(eventThree);
            _repo.CreateNewEvent(eventFour);
            _repo.CreateNewEvent(eventFive);
            _repo.CreateNewEvent(eventSix);
        }

        public void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select an option below:\n" +
                    "1. Show all Events\n" +
                    "2. Add an Event\n" +
                    "3. Show total cost for all Events\n" +
                    "4. Show total cost for an Event type\n" +
                    "5. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        ShowAllEvents();
                        break;
                    case "2":
                        CreateEvent();
                        break;
                    case "3":
                        ShowTotalCost();
                        break;
                    case "4":
                        ShowTotalEventTypeCost();
                        break;
                    case "5":
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response");
                        break;
                }
            }
        }

        public void CreateEvent()
        {
            Event newEvent = new Event();
            Console.WriteLine("Enter the type of event from the options below:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string typeResponse = Console.ReadLine();
            switch (typeResponse)
            {
                case "1":
                    newEvent.EventType = EventTypes.Golf;
                    break;
                case "2":
                    newEvent.EventType = EventTypes.Bowling;
                    break;
                case "3":
                    newEvent.EventType = EventTypes.AmusementPark;
                    break;
                case "4":
                    newEvent.EventType = EventTypes.Concert;
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            Console.WriteLine("Enter the number of people that attended:");
            newEvent.PersonCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Year, the Month, and the Day, pressing enter between each:");
            int year = Convert.ToInt32(Console.ReadLine());
            int month = Convert.ToInt32(Console.ReadLine());
            int day = Convert.ToInt32(Console.ReadLine());
            newEvent.Date = new DateTime(year, month, day);

            Console.WriteLine("Enter the total cost for the event:");
            newEvent.TotalCost = Convert.ToDouble(Console.ReadLine());

            _repo.CreateNewEvent(newEvent);
        }

        public void ShowAllEvents()
        {
            List<Event> tempList = _repo.GetAllEvents();
            Console.WriteLine($"{"Date of Event", -30} {"Type of outing", -15} {"Total cost", -15} {"People", -15} {"Cost per person", -15}");
            foreach (Event outing in tempList)
            {
                Console.WriteLine($"{outing.Date, -30} {outing.EventType, -15} {_repo.DisplayNumber(outing.TotalCost), -15} {outing.PersonCount, -15} {_repo.DisplayNumber(outing.CostPerPerson), -15}");
            }
            Console.WriteLine("Press anything to continue...");
            Console.ReadKey();
        }

        public void ShowTotalCost()
        {
            double totalCost = _repo.DisplayNumber(_repo.GetCostOfAllEvents());
            Console.WriteLine($"Total cost of all events thus far is ${totalCost}.\n" +
                $"Press anything to continue...");
            Console.ReadKey();
        }

        public void ShowTotalEventTypeCost()
        {
            double costOfEvent;
            string eventChosen;
            Console.WriteLine("Enter the type of event from the options below:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    costOfEvent = _repo.DisplayNumber(_repo.GetCostOfEventType(EventTypes.Golf));
                    eventChosen = "Golf";
                    break;
                case "2":
                    costOfEvent = _repo.DisplayNumber(_repo.GetCostOfEventType(EventTypes.Bowling));
                    eventChosen = "Bowling";
                    break;
                case "3":
                    costOfEvent = _repo.DisplayNumber(_repo.GetCostOfEventType(EventTypes.AmusementPark));
                    eventChosen = "Amusement Park";
                    break;
                case "4":
                    costOfEvent = _repo.DisplayNumber(_repo.GetCostOfEventType(EventTypes.Concert));
                    eventChosen = "Concert";
                    break;
                default:
                    costOfEvent = 0;
                    eventChosen = "*error*";
                    break;
            }

            Console.WriteLine($"Total cost for all {eventChosen} outings is ${costOfEvent}.\n" +
                $"Press anything to continue...");
            Console.ReadKey();
        }
    }
}
