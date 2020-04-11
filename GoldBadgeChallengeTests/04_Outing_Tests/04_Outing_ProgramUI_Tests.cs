using System;
using _04_Outing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeChallengeTests
{
    [TestClass]
    public class _04_Outing_ProgramUI_Tests
    {
        EventRepo _repo;

        DateTime dateOne;
        DateTime dateTwo;
        DateTime dateThree;
        DateTime dateFour;
        DateTime dateFive;
        DateTime dateSix;

        Event eventOne;
        Event eventTwo;
        Event eventThree;
        Event eventFour;
        Event eventFive;
        Event eventSix;

        [TestCleanup]
        public void TestCleanup()
        {
            _repo = null;

            dateOne = DateTime.MinValue;
            dateTwo = DateTime.MinValue;
            dateThree = DateTime.MinValue;
            dateFour = DateTime.MinValue;
            dateFive = DateTime.MinValue;
            dateSix = DateTime.MinValue;

            eventOne = null;
            eventTwo = null;
            eventThree = null;
            eventFour = null;
            eventFive = null;
            eventSix = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            _repo = new EventRepo();

            dateOne = new DateTime(2001, 5, 12);
            dateTwo = new DateTime(3005, 11, 30);
            dateThree = new DateTime(1992, 2, 21);
            dateFour = new DateTime(2020, 4, 11);
            dateFive = new DateTime(1999, 12, 31);
            dateSix = new DateTime(2011, 1, 5);

            eventOne = new Event(EventTypes.AmusementPark, 21, dateOne, 3478.29478);
            eventTwo = new Event(EventTypes.AmusementPark, 70, dateTwo, 37562.12345);
            eventThree = new Event(EventTypes.Bowling, 4, dateThree, 90.73625);
            eventFour = new Event(EventTypes.Concert, 18, dateFour, 222.421273);
            eventFive = new Event(EventTypes.Golf, 3, dateFive, 99999.999999);
            eventSix = new Event(EventTypes.Bowling, 99, dateSix, 10);

            _repo.CreateNewEvent(eventOne);
            _repo.CreateNewEvent(eventTwo);
            _repo.CreateNewEvent(eventThree);
            _repo.CreateNewEvent(eventFour);
            _repo.CreateNewEvent(eventFive);
            _repo.CreateNewEvent(eventSix);
        }

        [TestMethod]
        public void GetCostOfAllEvents_ShowsCombinedCost()
        {
            double actual = _repo.GetCostOfAllEvents();
            double expected = 3478.29478 + 37562.12345 + 90.73625 + 222.421273 + 99999.999999 + 10;
            Assert.AreEqual(expected, actual);
        }
    }
}
