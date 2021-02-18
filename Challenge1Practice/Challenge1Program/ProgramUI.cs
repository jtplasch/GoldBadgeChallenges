using Challenge1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    public class ProgramUI
    {
        private Challenge1Repo _repo = new Challenge1Repo();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                    Console.Clear();
                    Console.WriteLine("Enter the number of the option you'd like to select:\n" + 
                        "1. Create Menu Item\n" + 
                        "2. Show all menu items\n" + 
                        "3. Delete Menu Items\n" + 
                        "4. Exit");

                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1": //create menu item
                            AddMeal();
                            break;
                        case "2": //show all items
                            GetItems();
                            break;
                        case "3": //delete menu item
                            DeleteMeal();
                            break;
                        case "4": //exit
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number between 1 and 4.");
                            Console.ReadKey();
                            break;
                    }
            }
        }

        

        private void AddMeal()
        {
            Console.Clear();
            Challenge1Items meal = new Challenge1Items();

            Console.WriteLine("Please enter a meal Number");
            meal.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the name of the Meal.");
            meal.MealName = Console.ReadLine();

            Console.WriteLine("Enter Meal Description");
            meal.Description = Console.ReadLine();

            Console.WriteLine("Enter Ingredient Lists");
            meal.IngredientList = Console.ReadLine();

            Console.WriteLine("Enter Meal Price");
            meal.MealPrice = Decimal.Parse(Console.ReadLine());
        }

        private void GetItems()
        {
            Console.Clear();
            List<Challenge1Items> mealList = _repo.GetItems();

            foreach(Challenge1Items meal in mealList)
            {
                ShowMeals(meal);
            }
            Console.ReadKey();
        }

        private void ShowMeals(Challenge1Items meal)
        {
            Console.WriteLine($"Meal Number: {meal.MealNumber}\n" +
                $"Meal Name: {meal.MealName}\n" +
                $"Description: {meal.Description}\n" +
                $"Ingredient List: {meal.IngredientList}\n" +
                $"Price: {meal.MealPrice}\n");
        }

        private void DeleteMeal()
        {
            Console.Clear();
            Console.WriteLine("Please enter the meal number of the meal you'd like deleted.");

            List<Challenge1Items> mealList = _repo.GetItems();

            int count = 0;
            foreach(Challenge1Items meal in mealList)
            {
                count++;
                Console.WriteLine($"{count}. {meal.MealNumber}");
            }

            int targetMealID = int.Parse(Console.ReadLine());
            int targetIndex = targetMealID - 1;

            if(targetIndex >= 0 && targetIndex < mealList.Count)
            {
                Challenge1Items desiredMeal = mealList[targetIndex];
                if (_repo.DeleteMeal(desiredMeal.MealNumber))
                {
                    
                    Console.WriteLine($"{desiredMeal.MealNumber} successfully removed.");
                    
                }
                else
                {
                    Console.WriteLine("Sorry, this is unavailable");
                }
            }
            else
            {
                Console.WriteLine("No Content has that ID");
            }
            
        }
    }
    
}
