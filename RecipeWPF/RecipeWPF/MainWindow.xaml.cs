using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<List<IngredientCapture>> RecipeIngredients;
        private List<RecipeDescription> recipeDescription;

        public MainWindow()
        {
            InitializeComponent();
            RecipeIngredients = new List<List<IngredientCapture>>(); // Initialize the RecipeIngredients list of lists
            recipeDescription = new List<RecipeDescription>();
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Menu();
        }

        private void Menu()
        {
            if (int.TryParse(txtChoice.Text, out int choice) == false || choice < 1 || choice > 7)
            {
                MessageBox.Show("Please provide a valid input (1-7)", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Valid input, perform the corresponding action
                switch (choice)
                {
                    case 1:
                        if (RecipeIngredients.Count == 0)
                        {
                            // If no recipe ingredients are present, open the Recipe window
                            Recipe recipeWindow = new Recipe();
                            recipeWindow.Show();
                        }
                        else
                        {
                            if (RecipeIngredients.Count > 0)
                            {
                                // Prompt the user for confirmation to add more recipes
                                MessageBoxResult resu = MessageBox.Show("Do you want to add more recipes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                                if (resu == MessageBoxResult.Yes)
                                {
                                    // If the user chooses to add more recipes, open the Recipe window
                                    Recipe recipeWindow = new Recipe();
                                    recipeWindow.Show();
                                }
                                else
                                {
                                    // Pass the RecipeIngredients list to the new MainWindow instance
                                    // to display the existing recipes and focus on the MainWindow
                                    MainWindow menu = new MainWindow();
                                    menu.SetRecipeIngredients(RecipeIngredients);
                                    menu.Focus();
                                }
                            }
                        }
                        break;
                    case 2:
                        if (RecipeIngredients.Count == 0)
                        {
                            // If no recipe ingredients are present, display a warning message
                            MessageBox.Show("No Recipes are available", "Empty Recipes", MessageBoxButton.OK, MessageBoxImage.Error);

                            // Create a new MainWindow instance and focus on it
                            MainWindow menu = new MainWindow();
                            menu.Focus();
                        }
                        else
                        {
                            // If recipe ingredients are present, open the display window
                            OpenDisplayWindow();
                        }
                        break;
                    case 3:
                        if (RecipeIngredients.Count == 0)
                        {
                            // If no recipe ingredients are present, display an error message
                            MessageBox.Show("No Recipes are available", "Empty Recipes", MessageBoxButton.OK, MessageBoxImage.Error);

                            // Create a new MainWindow instance and focus on it
                            MainWindow menu = new MainWindow();
                            menu.Focus();
                        }
                        else
                        {
                            // If recipe ingredients are present, perform scaling of ingredients
                            ScalingIngredients();
                        }
                        break;

                    case 4:
                        if (RecipeIngredients.Count == 0)
                        {
                            // If no recipe ingredients are present, display an error message
                            MessageBox.Show("No Recipes are available", "Empty Recipes", MessageBoxButton.OK, MessageBoxImage.Error);

                            // Create a new MainWindow instance and focus on it
                            MainWindow menu = new MainWindow();
                            menu.Focus();
                        }
                        else
                        {
                            // If recipe ingredients are present, reset the quantity
                            ResetQuantity();
                        }
                        break;

                    case 5:
                        ClearData();
                        break;

                    case 6:
                        // Prompt the user for confirmation to exit the program
                        MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the program?", "Exit Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            // If the user confirms the exit, shut down the application
                            Application.Current.Shutdown();
                        }
                        else
                        {
                            // If the user cancels the exit, return or continue with the program
                            return;
                        }
                        break;



                }
            }
        }

        private void ClearData()
        {
            if (RecipeIngredients.Count == 0)
            {
                // If no recipe ingredients are present, display an error message
                MessageBox.Show("No Recipes are available", "Empty Recipes", MessageBoxButton.OK, MessageBoxImage.Error);

                // Create a new MainWindow instance and focus on it
                MainWindow menu = new MainWindow();
                menu.Focus();
            }
            else
            {
                // If recipe ingredients are present, ask for confirmation to clear the data
                MessageBoxResult resut = MessageBox.Show("Are you sure you want to clear the data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (resut == MessageBoxResult.Yes)
                {
                    // Clear the RecipeIngredients list and the recipe description
                    RecipeIngredients.Clear();
                    recipeDescription.Clear();

                    // Display a success message
                    MessageBox.Show("Data cleared successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Display a message indicating that the data was not cleared
                    MessageBox.Show("Data not cleared.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Method to receive the RecipeIngredients list
        public void SetRecipeData(List<RecipeDescription> descriptions)
        {

            recipeDescription = descriptions;
        }

        public void SetRecipeIngredients(List<List<IngredientCapture>> ingredients)
        {
            RecipeIngredients = ingredients;
        }

        // Method to open the Display window
        private void OpenDisplayWindow()
        {
            Display displayWindow = new Display();
            displayWindow.SetRecipeIngredients(RecipeIngredients, recipeDescription);
            displayWindow.Show();
        }

        private void ScalingIngredients()
        {
            Scaling scaling = new Scaling();
            scaling.SetIngredientScaling(RecipeIngredients);
            scaling.Show();
        }

        private void ResetQuantity()
        {
            Scaling scaling = new Scaling();
            bool resetSuccessful = scaling.ResetIngredientQuantities(RecipeIngredients);
            MessageBoxResult resetResult = MessageBox.Show("Do you want to reset the quantities of the ingredients?", "Reset Quantities", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resetResult == MessageBoxResult.Yes)
            {
                if (resetSuccessful)
                {
                    MessageBox.Show("Quantities reset successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Quantities not reset.", "No Changes", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



    }

}
