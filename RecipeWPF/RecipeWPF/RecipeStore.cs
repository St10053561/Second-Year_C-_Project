using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPF
{
    public class RecipeStore
    {
        private string recipeName;
        private List<IngredientCapture> recipeIngredients;
        private List<RecipeDescription> recipeDescriptions;

        public RecipeStore(string recipeName, List<IngredientCapture> recipeIngredients, List<RecipeDescription> recipeDescriptions)
        {
            this.recipeName = recipeName;
            this.recipeIngredients = recipeIngredients;
            this.recipeDescriptions = recipeDescriptions;
        }

        public string RecipeName { get => recipeName; set => recipeName = value; }
        public List<IngredientCapture> RecipeIngredients { get => recipeIngredients; set => recipeIngredients = value; }
        public List<RecipeDescription> RecipeDescriptions { get => recipeDescriptions; set => recipeDescriptions = value; }
    }


}
