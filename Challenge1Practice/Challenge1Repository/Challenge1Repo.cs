using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge1.ProgramUI;

namespace Challenge1
{
    public class Challenge1Repo
    {
        //Start CRUD
        private List<Challenge1Items> _menuItems = new List<Challenge1Items>();

        public int Total //Counts how many items there are in list to make sure items are added
        {
            get
            {
                return _menuItems.Count;
            }
        }

        //Create

        public bool AddMeal(Challenge1Items meal)
        {
            int startingCount = _menuItems.Count;

            _menuItems.Add(meal);

            bool wasAdded = _menuItems.Count > startingCount;
            return wasAdded;
        }

        public Challenge1Items GetMealByNumber(int mealNumber)
        {
            foreach(Challenge1Items meal in _menuItems)
                if(mealNumber == meal.MealNumber)
                {
                    return meal;
                }
                else Console.WriteLine("There is no such meal, please enter another number.");
            return null;
        }
        //Read
        public List<Challenge1Items> GetItems()
        {
            return _menuItems;
        }

        public bool DeleteMeal(int mealNumber)
        {
            Challenge1Items mealtoDelete = GetMealByNumber(mealNumber);
            return _menuItems.Remove(mealtoDelete);
        }
    }
}
