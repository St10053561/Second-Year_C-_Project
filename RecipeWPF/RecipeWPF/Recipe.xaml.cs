using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeWPF
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Window
    {
        private int ingrCount;
        private string ingrName;
        private string foodGroup;
        private string unit;
        private int quaIng;
        private int calori;
        private string recipe;
        public List<List<IngredientCapture>> RecipeIngredients = new List<List<IngredientCapture>>();

        public Recipe()
        {
            InitializeComponent();


            DataContext = this;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            submitButton.IsEnabled = false;
            recipe = RecipeTextBox.Text.Trim();

            if (string.IsNullOrEmpty(recipe))
            {
                MessageBox.Show("Please don't leave empty space in the recipe text box.", "Incomplete Recipe Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                submitButton.IsEnabled = true;
                return;
            }
            bool allIngredientsCaptured = true;
            int ingrCount = 1; // Start with 1 ingredient by default

            while (true)
            {
                bool success = IngridentMethod();
                if (!success)
                {
                    allIngredientsCaptured = false;
                    break;
                }

                //MessageBox.Show($"Ingredient {ingrCount} captured successfully.", "Capture Ingredient", MessageBoxButton.OK, MessageBoxImage.Information);

                ingrCount++; // Increment the ingrCount variable

                // Prompt user to continue capturing the next ingredient
                MessageBoxResult result = MessageBox.Show("Do you want to capture the next ingredient?", "Capture Ingredient", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    if (mainWindow != null)
                    {
                        // Pass the RecipeIngredients list to the MainWindow
                        mainWindow.SetRecipeIngredients(RecipeIngredients);

                        mainWindow.Show();
                        mainWindow.Focus(); // Bring the existing MainWindow to the front
                    }
                    Close(); // Close the Recipe window

                    Steps step = new Steps(RecipeIngredients);
                    step.PopulateStepsTextBox(); // Call the method to populate the ComboBox
                    step.Show();

                    // User chose not to capture the next ingredient, navigate to Steps.xaml
                    break;
                }

            }

            if (allIngredientsCaptured)
            {
                MessageBox.Show("All ingredients captured successfully.", "Capture Ingredients", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            submitButton.IsEnabled = true;

        }

        private bool IngridentMethod()
        {
            try
            {
                // Validate ingrName
                ingrName = IngridentTextBox.Text.Trim();
                if (string.IsNullOrEmpty(ingrName))
                {
                    MessageBox.Show("Please provide the name for the ingredient.", "Ingredient Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                // Parse quaIng
                if (!int.TryParse(QuantityTextBox.Text.Trim(), out quaIng))
                {
                    MessageBox.Show("Please provide a valid number for quantity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                // Parse calories
                if (!int.TryParse(CaloriTextBox.Text.Trim(), out calori))
                {
                    MessageBox.Show("Please provide valid calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                if (calori > 300)
                {
                    MessageBox.Show("Calories cannot exceed 300.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }


                // Validate foodGroup
                foodGroup = comboFoodGroup.Text.Trim();
                if (string.IsNullOrEmpty(foodGroup) || string.IsNullOrWhiteSpace(foodGroup))
                {
                    MessageBox.Show("Please select a food group.", "Food Group", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                // Validate unit
                unit = unitTextBox.Text.Trim();
                if (string.IsNullOrEmpty(unit) || string.IsNullOrWhiteSpace(unit))
                {
                    MessageBox.Show("Please provide the unit for the ingredient.", "Unit", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                // Create a new list of IngredientCapture
                List<IngredientCapture> ingredientList = new List<IngredientCapture>();

                // Create an instance of IngredientCapture with the captured values
                IngredientCapture ingredient = new IngredientCapture(ingrName, quaIng, unit, recipe, calori, foodGroup);

                // Add the ingredient to the ingredientList
                ingredientList.Add(ingredient);

                // Add the ingredientList to the RecipeIngredients list
                RecipeIngredients.Add(ingredientList);


                // Clear input fields
                IngridentTextBox.Text = "";
                comboFoodGroup.Text = "";
                unitTextBox.Text = "";
                QuantityTextBox.Text = "";
                CaloriTextBox.Text = "";

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


    }
}