using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RecipeWPF
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        private List<List<IngredientCapture>> RecipeIngredients;
        private List<RecipeDescription> recipeDescription;

        public Display()
        {
            InitializeComponent();
        }

        private string ingredientToSearch;
        private string comboList;
        private int maxiCalories;

        private void SubmitDisplay_Click(object sender, RoutedEventArgs e)
        {
            ingredientToSearch = displayIngredientName.Text.Trim();
            comboList = comboListValues.Text.Trim();
            // Check if the user provided a value for maxiCalories
            bool hasMaxiCalories = !string.IsNullOrEmpty(MaxiCal.Text.Trim());
            if (hasMaxiCalories && !int.TryParse(MaxiCal.Text.Trim(), out maxiCalories))
            {
                // The input is not a valid integer
                MessageBox.Show("Invalid input for maximum calories. Please enter a valid integer value.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            bool isMatchFound = SetRecipeIngredients(RecipeIngredients, recipeDescription);

            if (!string.IsNullOrEmpty(ingredientToSearch))
            {
                bool isIngredientFound = RecipeIngredients.Any(ingredientList => ingredientList.Any(ingredient => ingredient.Name1 == ingredientToSearch));

                if (isIngredientFound)
                {
                    // Show a success message for the ingredientToSearch
                    MessageBox.Show("Ingredient found: " + ingredientToSearch);
                }
                else
                {
                    // Show an error message for the ingredientToSearch not found
                    MessageBox.Show("Ingredient not found: " + ingredientToSearch, "Ingredient Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(comboList))
            {
                bool isComboListFound = RecipeIngredients.Any(ingredientList => ingredientList.Any(ingredient => ingredient.FoodGroup == comboList));
                if (isComboListFound)
                {
                    // Show a success message for the comboList
                    MessageBox.Show("ComboList found: " + comboList);
                }
                else
                {
                    // Show an error message for the comboList not found
                    MessageBox.Show("ComboList not found: " + comboList, "ComboList Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else if (maxiCalories != 0)
            {
                bool isMaxiCaloriesFound = RecipeIngredients.Any(ingredientList => ingredientList.Any(ingredient => ingredient.Calories1 == maxiCalories));
                if (isMaxiCaloriesFound)
                {
                    // Show a success message for the maxiCalories
                    MessageBox.Show("MaxiCalories found: " + maxiCalories);
                }
                else
                {
                    // Show an error message for the maxiCalories not found
                    MessageBox.Show("MaxiCalories not found: " + maxiCalories, "MaxiCalories Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                // Show a failure message
                MessageBox.Show("Nothing has been found.");
            }

            // Show the ingredient details in the TextBlock
            string show = GetDetails(ingredientToSearch, comboList, maxiCalories);
            ShowIngredientDetails(show);

            MainWindow mainWindow = new MainWindow();
            mainWindow.SetRecipeIngredients(RecipeIngredients);

        }


        public bool SetRecipeIngredients(List<List<IngredientCapture>> ingredients, List<RecipeDescription> description)
        {
            RecipeIngredients = ingredients;
            recipeDescription = description;

            bool isMatchFound = false;

            // Loop through RecipeIngredients
            foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
            {
                foreach (IngredientCapture ingredient in ingredientList)
                {
                    if (ingredient.Name1.Equals(ingredientToSearch) || ingredient.FoodGroup.Equals(comboList) || ingredient.Calories1 == maxiCalories)
                    {
                        isMatchFound = true;
                        break;
                    }
                }

                if (isMatchFound)
                {
                    break;
                }
            }

            return isMatchFound;

        }


        private string GetDetails(string ingredientName, string comboList, int maxi)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.AppendLine("************************************************************************************************************************");
            messageBuilder.AppendLine("\t\t\t\t\tDISPLAY");
            messageBuilder.AppendLine("------------------------------------------------------------------------------------------------------------------------");
            messageBuilder.AppendLine("Recipe Name:");

            foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
            {
                foreach (IngredientCapture ingredient in ingredientList)
                {
                    if (ingredient.Name1.Equals(ingredientName) || ingredient.FoodGroup.Equals(comboList) || ingredient.Calories1 == maxi)
                    {
                        messageBuilder.AppendLine(ingredient.Recipe1); // Appending the recipe name to the messageBuilder
                        break; // Exit the loop after finding the recipe name
                    }
                }
            }

            messageBuilder.AppendLine("------------------------------------------------------------------------------------------------------------------------");
            messageBuilder.AppendLine("| No.\t| Ingredient Name\t| Quantity\t| Measurement\t| Calories\t| Food Group\t\t|");
            messageBuilder.AppendLine("------------------------------------------------------------------------------------------------------------------------");

            int count = 1;


            foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
            {
                foreach (IngredientCapture ingredient in ingredientList)
                {
                    if (ingredient.Name1.Equals(ingredientName) || ingredient.FoodGroup.Equals(comboList) || ingredient.Calories1 == maxi)
                    {
                        messageBuilder.AppendLine($"| {count}\t| {ingredient.Name1}\t\t| {ingredient.Quantity1}\t\t| {ingredient.Unit}\t\t| {ingredient.Calories1}\t\t| {ingredient.FoodGroup}\t|");
                        count++;
                    }
                }
            }


            messageBuilder.AppendLine("------------------------------------------------------------------------------------------------------------------------");
            messageBuilder.AppendLine();
            messageBuilder.AppendLine("Steps Description:");

            PrintRecipeDescription(messageBuilder);

            messageBuilder.AppendLine("************************************************************************************************************************");

            return messageBuilder.ToString();
        }


        private void PrintRecipeDescription(StringBuilder messageBuilder)
        {
            string previousRecipeName = string.Empty;
            int stepNumber = 1;
            for (int v = 0; v < recipeDescription.Count; v++)
            {
                RecipeDescription recDes = recipeDescription[v];

                if (recDes.RecipeName != previousRecipeName)
                {
                    messageBuilder.AppendLine($"\nRecipe Name: {recDes.RecipeName}");
                    previousRecipeName = recDes.RecipeName;
                    stepNumber = 1;
                }

                string[] steps = recDes.StepDescription.Split('\n');


                for (int i = 0; i < steps.Length; i++)
                {
                    string trimmedStepDescription = steps[i].Trim();
                    messageBuilder.AppendLine($"- Step {stepNumber}: {trimmedStepDescription}");

                    // Increment step number
                    stepNumber++;
                }
            }

            // Display or use the message as needed
            messageBuilder.AppendLine();
        }

        private void ShowIngredientDetails(string details)
        {
            displayTextBox.Text = details;
        }

     

    }

}
