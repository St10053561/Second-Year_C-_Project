using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPF
{
    public class MainRecipe
    {
        private string name;
        private List<RecipeDescription> steps;
        private List<List<IngredientCapture>> recipeIngredient;

        public MainRecipe(string name, List<RecipeDescription> steps, List<List<IngredientCapture>> recipeIngredient)
        {
            this.name = name;
            this.steps = steps;
            this.recipeIngredient = recipeIngredient;
        }

        public string Name { get => name; set => name = value; }
        public List<RecipeDescription> Steps { get => steps; set => steps = value; }
        public List<List<IngredientCapture>> RecipeIngredient { get => recipeIngredient; set => recipeIngredient = value; }
    }
}
