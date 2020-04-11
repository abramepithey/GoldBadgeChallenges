using System;
using System.Collections.Generic;
using GoldBadgeChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeChallengeTests
{
    [TestClass]
    public class _01_Cafe_Repo_Tests
    {
        MenuItemRepo _repo = new MenuItemRepo();

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void AddMenuItem_ItemWasAdded(int testnum)
        {
            MenuItem newItem = new MenuItem();
            newItem.MealName = "chicken";

            MenuItem newItemOne = new MenuItem();
            newItemOne.MealName = "chicken";
            MenuItem newItemTwo = new MenuItem();
            newItemTwo.MealName = "chicken";
            MenuItem newItemThree = new MenuItem();
            newItemThree.MealName = "chicken";

            _repo.AddMenuItem(newItem);
            _repo.AddMenuItem(newItemOne);
            _repo.AddMenuItem(newItemTwo);
            _repo.AddMenuItem(newItemThree);

            List<MenuItem> templist = _repo.ListAllMenuItems();

            int expected = testnum;
            int actual = templist.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void DeleteMenuItemByName_ItemWasDeleted(int testnum)
        {
            MenuItem newItem = new MenuItem();
            newItem.MealName = "chicken";

            MenuItem newItemOne = new MenuItem();
            newItemOne.MealName = "chicken";
            MenuItem newItemTwo = new MenuItem();
            newItemTwo.MealName = "chicken";
            MenuItem newItemThree = new MenuItem();
            newItemThree.MealName = "chickens";

            _repo.AddMenuItem(newItem);
            _repo.AddMenuItem(newItemOne);
            _repo.AddMenuItem(newItemTwo);
            _repo.AddMenuItem(newItemThree);

            _repo.DeleteMenuItemByName("chicken");

            List<MenuItem> templist = _repo.ListAllMenuItems();

            int expected = testnum;
            int actual = templist.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
