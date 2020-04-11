using System;
using System.Collections.Generic;
using _02_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeChallengeTests
{
    [TestClass]
    public class _02_Claim_Repo_Tests
    {
        ClaimRepo _repo;

        Claim claimOne;
        Claim claimTwo;
        Claim claimThree;

        [TestCleanup]
        public void TestCleanup()
        {
            _repo = null;
            claimOne = null;
            claimTwo = null;
            claimThree = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            _repo = new ClaimRepo();
            claimOne = new Claim(1, ClaimType.Car, "Hit a horse and exploded", 25000.11234, new DateTime(2011, 11, 21), new DateTime(2020, 3, 19));
            claimTwo = new Claim(2, ClaimType.Home, "Horse exploded and blew out my windows", 350.285678, new DateTime(2011, 11, 21), new DateTime(2011, 11, 30));
            claimThree = new Claim(3, ClaimType.Theft, "Someone stole my horse and car for nefarious reasons", 20000.37466, new DateTime(2011, 10, 30), new DateTime(2011, 11, 21));
            _repo.CreateNewClaim(claimOne);
            _repo.CreateNewClaim(claimTwo);
            _repo.CreateNewClaim(claimThree);
        }

        [TestMethod]
        public void GetClaimCount_GetsCorrectNumberOfClaims()
        {
            int actual = _repo.GetClaimCount();
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllClaims_GetsCorrectNumberOfClaims()
        {
            List<Claim> tempList = _repo.GetAllClaims();
            int actual = tempList.Count;
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void IsValid_ReturnsCorrectBool(int index)
        {
            List<Claim> tempList = _repo.GetAllClaims();
            bool actual = tempList[index].IsValid;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void GetNextClaim_ShouldBeFirstClaim_ShouldBeTrue()
        {
            string expected = "Hit a horse and exploded";
            Claim firstClaim = _repo.GetNextClaim();
            string actual = firstClaim.Description;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNewClaim_AddsAClaim()
        {
            int expected = 4;
            Claim newClaim = new Claim();
            _repo.CreateNewClaim(newClaim);
            int actual = _repo.GetClaimCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteNextClaim_DeletesFirstClaimInRepo()
        {
            _repo.DeleteNextClaim();
            Claim firstClaim = _repo.GetNextClaim();
            string actual = firstClaim.Description;
            string expected = "Horse exploded and blew out my windows";
            Assert.AreEqual(expected, actual);
        }
    }
}
