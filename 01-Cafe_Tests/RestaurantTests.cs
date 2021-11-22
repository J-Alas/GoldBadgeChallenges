using _01_Restaurant_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_R_Tests
{
    [TestClass]
    public class RestaurantTests
    {

        [TestMethod]
        public void GetItems()
        {
            //Arrange
            Menu tuna = new Menu();
            MenuRepository menuRepo = new MenuRepository();
            tuna.MealNumber = 1;
            tuna.MealName = "Tuna Sandwich";
            tuna.Description = "After School Classic";
            List<string> tunaIngredients = new List<string>() {"tuna", "white bread", "mayo" };
            tuna.Ingredients = tunaIngredients;
            tuna.Price = 5.99;
            //Act
            menuRepo.AddItem(tuna);
            menuRepo.GetItems();
           

        }

        [TestMethod]
        public void Menu() {in };


        //remove this
        [TestMethod]
        public void DeleteItem_ShouldReturnFalse()
        {
            //Arrange
            Menu tuna = new Menu();
            MenuRepository menuRepo = new MenuRepository();
            tuna.MealNumber = 1;
            tuna.MealName = "Tuna Sandwich";
            tuna.Description = "After School Classic";
            List<string> potatoIngredients = new List<string>() {"tuna", "white bread", "mayo" };
            tuna.Ingredients = potatoIngredients;
            tuna.Price = 5.99;
            //Act
            menuRepo.AddItem(tuna);
            menuRepo.RemoveItem(tuna.MealName);
            //Assert
            Assert.IsFalse(menuRepo.RemoveItem(tuna.MealName));
        }

    }
}
