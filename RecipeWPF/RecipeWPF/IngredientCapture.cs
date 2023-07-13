using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPF
{
    public class IngredientCapture
    {
        // These are private member variables of the class
        private string Name; // stores the name of the item
        private int Quantity; // stores the quantity of the item
        private string unit; // stores the unit of measurement for the item
        private string Recipe;// stores the recipe for the item
        private int Calories;// stores the calories for the item    
        private string foodGroup; // stores the food group for the item
        private int OrigQuanity;

        // This is the constructor for the class, which is called when a new instance of the class is created
        public IngredientCapture(string name, int quantity, string unit, string recipe, int calories, string foodGroup)
        {
            // The following lines assign the values passed to the constructor to the member variables of the class
            Name1 = name;
            Quantity1 = quantity;
            this.Unit = unit;
            Recipe1 = recipe;
            Calories1 = calories;
            this.FoodGroup = foodGroup;
        }

        // These are public properties of the class, which allow the private member variables to be accessed and modified from outside the class
        public string Name1 { get => Name; set => Name = value; } // allows getting and setting the name of the item
        public int Quantity1 { get => Quantity; set => Quantity = value; } // allows getting and setting the quantity of the item
        public string Unit { get => unit; set => unit = value; } // allows getting and setting the unit of measurement for the item
        public string Recipe1 { get => Recipe; set => Recipe = value; } // allows getting and setting the recipe name
        public int Calories1 { get => Calories; set => Calories = value; } // allows getting and setting the calories
        public string FoodGroup { get => foodGroup; set => foodGroup = value; } // allows getting and setting the food group
        public int OrigQuanity1 { get => OrigQuanity; set => OrigQuanity = value; }
    }
}
