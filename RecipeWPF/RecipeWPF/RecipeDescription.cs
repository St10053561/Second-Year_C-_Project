using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPF
{
    /// <summary>
    /// This class represents a recipe, and contains information about the name of the recipe and its step-by-step instructions.
    /// </summary>
    public class RecipeDescription
    {
        // Properties for storing the name of the recipe and its step-by-step instructions (as strings).
        public string RecipeName { get; set; }
        public string StepDescription { get; set; }

        ///</summary>
        ///<param name="recipeName">The string representing the name of this new recipe.</param>  
        ///<param name="stepDescription">The string containing step-by-step instructions for making this recipe.</param>      
        public RecipeDescription(string recipeName, string stepDescription)
        {
            RecipeName = recipeName;
            StepDescription = stepDescription;
        }
    }
}
