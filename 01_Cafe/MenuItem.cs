using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    public class MenuItem
    {
        private int _MealNumber;

        public int MealNumber
        {
            get { return _MealNumber; }
            set { _MealNumber = value; }
        }

        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; }
        public double MealPrice { get; set; }

        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
    }
}
