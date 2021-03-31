using BadgeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        [TestInitialize]
        public void SeedTestBadge()
        {
            BadgeClass badgeOne = new BadgeClass(123456, new List<string>() { "A1", "A2" });
            BadgeClass badgeTwo = new BadgeClass(234567, new List<string>() { "B1", "B2" });

            _badgeRepo.AddNewBadgeToDict(badgeOne);
            _badgeRepo.AddNewBadgeToDict(badgeTwo);
        }
        [TestMethod]
        public void AddNewBadge_ReturnValueTrue()
        {
            //BadgeClass badgeThing = new BadgeClass();
            BadgeClass badgeThree = new BadgeClass(345678, new List<string>() { "C1", "C2" });
            int startingListSize = _badgeRepo.ReturnFullList().Count;

            _badgeRepo.AddNewBadgeToDict(badgeThree);
            int endingListSize = _badgeRepo.ReturnFullList().Count;

            Assert.IsTrue(startingListSize < endingListSize);
        }
        [TestMethod]
        public void UpdateAccessList_ReturnValueTrue()
        {
            bool isTrue = _badgeRepo.UpdateAccessList(123456, "A1");

            Assert.IsTrue(isTrue);
        }
        [TestMethod]
        public void DeleteAccessFromList_ReturnValueTrue()
        {
            bool isTrueTwo = _badgeRepo.DeleteAccessFromList(234567, "B2");
            Assert.IsTrue(isTrueTwo);
        }
    }
}
