using _03_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void AddBadgeToDictionary_ShouldGetNotNull()
        {
            //Arrange
            Badge badge = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository(); 
            List<string> starterDoors = new List<string>() { "A1", "A5" }; 

            //Act
            Badge starterBadge = new Badge(12345, starterDoors);
            badgeRepo.AddBadgeToDictionary(starterBadge);
            Badge badgeFromDictionary = badgeRepo.GetBadgeByID(12345);
            //Assert
            Assert.IsNotNull(badgeFromDictionary);

        }
    }
}
