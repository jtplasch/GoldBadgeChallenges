using Challenge1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    public class Challenge1Items 
    {
        public int MealNumber { get; set; }

        public string MealName { get; set; }

        public string Description { get; set; }

        public string IngredientList { get; set; }

        public decimal MealPrice { get; set; }

        public Challenge1Items() { }
        public Challenge1Items(int mealNumber, string mealName, string description, string ingredientList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            IngredientList = ingredientList;
            MealPrice = mealPrice;
        }
    }
}
