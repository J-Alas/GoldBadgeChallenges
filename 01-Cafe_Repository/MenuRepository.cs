using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Restaurant_Repository
{
    public class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        //Create
        public void AddItem(Menu menu)
        {
            _listOfMenuItems.Add(menu);
        }

        //Read
        public List<Menu> AllItems()
        {
            return _listOfMenuItems;
        }

        //Delete
        public bool RemoveItem(string mealName)
        {
            Menu menu = GetItemByName(mealName);

            if (menu == null)
            {
                return false;
            }

            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menu);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        public Menu GetItemByName(string mealName)
        {
            foreach (Menu menu in _listOfMenuItems)
            {
                if (menu.MealName == mealName)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
