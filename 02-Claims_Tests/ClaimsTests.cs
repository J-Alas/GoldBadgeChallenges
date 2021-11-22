using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddNewClaim_ShouldGetNotNull()
        {
            //Arrange
            ClaimsRepository claimsRepository = new ClaimsRepository();
            Claim claim1 = new Claim(1, Claim.Type.Vehicle, "Car got folded", 100000.01, new DateTime(2020, 10, 01), new DateTime(2020, 10, 03));
            //Act
            claimsRepository.AddNewClaim(claim1);
            Claim claimFromQueue = claimsRepository.GetClaimByID(1);
            //Assert
            Assert.IsNotNull(claimFromQueue);
        }
        [TestMethod]
        //take out of the queue
        public void HandleAClaim_ShouldReturnTrue()
        {
            ClaimsRepository claimsRepository = new ClaimsRepository();
            Claim claim1 = new Claim(1, Claim.Type.Vehicle, "Car got folded", 100000.01, new DateTime(2020, 10, 01), new DateTime(2020, 10, 03));
            
            claimsRepository.AddNewClaim(claim1);
            bool handled = claimsRepository.HandleAClaim(claim1.ClaimID);

            Assert.IsTrue(handled);
        }
    }
}
