using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsTestMethod
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddItemtoQueue()
        {
            ClaimQueue claimClass = new ClaimQueue();
            ClaimsRepo claimsRepo = new ClaimsRepo();

            bool added = claimsRepo.AddItemsToQueue(claimClass);

            Assert.IsTrue(added);

            Console.WriteLine(added);
        }
        [TestMethod]
        public void ReadFullQueueTest()
        {
            ClaimQueue claimClass = new ClaimQueue();
            ClaimsRepo claimsRepo = new ClaimsRepo();

            claimsRepo.AddItemsToQueue(claimClass);

            Queue<ClaimQueue> claimobjects = claimsRepo.ReadFullQueue();

            bool queuehasobjects = claimobjects.Contains(claimClass);

            Assert.IsTrue(queuehasobjects);

            Console.WriteLine(queuehasobjects);
        }
        [TestMethod]
        public void ReadByClaimID()
        {
            ClaimQueue claim;
            ClaimQueue claimClass = new ClaimQueue();
            ClaimsRepo claimsRepo = new ClaimsRepo();

            ClaimQueue claimone = new ClaimQueue(ClaimType.Car, "burned to the ground", 20.20, new DateTime(2020, 3, 22), new DateTime(2020, 3, 30));
            ClaimQueue claimtwo = new ClaimQueue(ClaimType.Theft, "crashed into pole", 20.30, new DateTime(2020, 3, 22), new DateTime(2020, 5, 31));

            claimsRepo.AddItemsToQueue(claimone);
            claimsRepo.AddItemsToQueue(claimtwo);

            claim = claimsRepo.ReadClaimByID(claimone.ClaimID);
            Console.WriteLine(claim.ClaimID);
            Assert.AreEqual(claim.ClaimDescription, "burned to the ground");
        }
        [TestMethod]
        public void MyTestMethod()
        {
            ClaimQueue claim = new ClaimQueue();
            Console.WriteLine(claim.ClaimID);
            Console.WriteLine(claim.ClaimID);
            Console.WriteLine(claim.ClaimID);
        }


        private ClaimQueue claim;
        private ClaimsRepo claimsRepo;
        private ClaimQueue claimone;

        [TestInitialize]

        public void Arrange()
        {
            claimsRepo = new ClaimsRepo();
             claimone = new ClaimQueue(ClaimType.Car, "burned to the ground", 20.20, new DateTime(2020, 3, 22), new DateTime(2020, 3, 30));
            claimsRepo.AddItemsToQueue(claimone);
        }

        [TestMethod]
        public void MyTestMethodone()
        {
             claim = claimsRepo.ReadClaimByID(claimone.ClaimID);
            Console.WriteLine( claim.ClaimID);

        }
        [TestMethod]
        public void PeakTest()
        {
            claim = claimsRepo.PeakNextClaimInQueue();
            Assert.AreEqual(claim.ClaimDescription, "burned to the ground");
            Console.WriteLine(claim.ClaimDescription);
        }
        [TestMethod]
        public void DeQueueTest()
        {
            int guesscount = 0;
            
            claimsRepo.DeleteNextClaimInQueue();
            Queue<ClaimQueue> claims = claimsRepo.ReadFullQueue();
            Assert.AreEqual(guesscount, claims.Count);
        }
    }
}
