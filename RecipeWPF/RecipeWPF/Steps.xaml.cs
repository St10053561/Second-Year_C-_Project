using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RecipeWPF
{
    /// <summary>
    /// Interaction logic for Steps.xaml
    /// </summary>
    public partial class Steps : Window
    {
        private List<RecipeDescription> recipeDescription = new List<RecipeDescription>();
        private List<List<IngredientCapture>> recipeIngredients;

        public Steps(List<List<IngredientCapture>> ingredients)
        {
            recipeIngredients = ingredients;
            InitializeComponent();
        }


        public void PopulateStepsTextBox()
        {
            ComboRecipe.ItemsSource = recipeIngredients;
            ComboRecipe.DisplayMemberPath = "Recipe1";
        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string stepDescription = StepsRecipeTextBox.Text.Trim();

            SubmitButton.IsEnabled = false;

            if (string.IsNullOrEmpty(stepDescription))
            {
                MessageBox.Show("Please don't leave empty space in the steps text box.", "Incomplete Steps Field", MessageBoxButton.OK, MessageBoxImage.Warning);
                SubmitButton.IsEnabled = true;
                return;
            }
            // Retrieve the selected ingredient list from the combo box
            List<IngredientCapture> selectedIngredientList = ComboRecipe.SelectedItem as List<IngredientCapture>;

            if (selectedIngredientList == null)
            {
                MessageBox.Show("Please select a recipe from the Combo box.", "Incomplete Recipe Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                SubmitButton.IsEnabled = true;
                return;
            }



            string selectedRecipe = selectedIngredientList.FirstOrDefault()?.Recipe1;

            if (string.IsNullOrEmpty(selectedRecipe))
            {
                MessageBox.Show("No recipe selected.", "Incomplete Recipe Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                SubmitButton.IsEnabled = true;
                return;
            }


            // Create an instance of RecipeDescription with the captured values
            RecipeDescription recipeStep = new RecipeDescription(selectedRecipe, stepDescription);

            // Add the recipe step to the recipeDescription list
            recipeDescription.Add(recipeStep);


        // Prompt user to continue capturing the next step
        MessageBoxResult result = MessageBox.Show("Do you want to capture the next step?", "Capture Step", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Clear the input fields for the next step
                StepsRecipeTextBox.Text = "";
            }
            else
            {
                // User chose not to capture the next step, show success message
                MessageBox.Show("Step capture completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Close(); 

                // Navigate back to the MainWindow
                MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mainWindow != null)
                {
                    // Pass the RecipeIngredients and RecipeDescription lists to the MainWindow
                    mainWindow.SetRecipeData(recipeDescription);

                    mainWindow.Show();
                    mainWindow.Focus(); // Bring the existing MainWindow to the front
                }
            }




            SubmitButton.IsEnabled = true;
        }

  


    }
}
