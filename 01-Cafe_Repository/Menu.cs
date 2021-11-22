using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Restaurant_Repository
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

        public Menu() { }
        public Menu(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = mealDescription;
            Ingredients = mealIngredients;
            Price = mealPrice;
        }

        

    }
}
