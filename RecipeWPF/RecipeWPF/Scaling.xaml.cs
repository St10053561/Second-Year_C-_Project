using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeWPF
{
    /// <summary>
    /// Interaction logic for Scaling.xaml
    /// </summary>
    public partial class Scaling : Window
    {
        private List<List<IngredientCapture>> RecipeIngredients;
        public Scaling()
        {
            InitializeComponent();
        }


        // ...

        private void SubmitCheckButton(object sender, RoutedEventArgs e)
        {
            bool scalingApplied = SetIngredientScaling(RecipeIngredients);

            if (scalingApplied)
            {
                MessageBox.Show("Ingredient scaling applied successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No scaling applied.", "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Close the current window and return to the MainWindow
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Focus();
        }

        // Define a variable to store the applied scaling factor

        public bool SetIngredientScaling(List<List<IngredientCapture>> ingredients)
        {
            RecipeIngredients = ingredients;

            if (HalfRadioButton.IsChecked == true)
            {
                // Radio button is selected, apply half scaling to ingredients
                foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
                {
                    foreach (IngredientCapture ingredient in ingredientList)
                    {
                        ingredient.OrigQuanity1 = ingredient.Quantity1;
                        ingredient.Quantity1 = (int)(ingredient.Quantity1 * 0.5);
                    }
                }
            }
            else if (DoubleRadioButton.IsChecked == true)
            {
                foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
                {
                    foreach (IngredientCapture ingredient in ingredientList)
                    {
                        ingredient.OrigQuanity1 = ingredient.Quantity1;
                        ingredient.Quantity1 *= 2;
                    }
                }
            }
            else if (TripleRadioButton.IsChecked == true)
            {
                foreach (List<IngredientCapture> ingredientList in RecipeIngredients)
                {
                    foreach (IngredientCapture ingredient in ingredientList)
                    {
                        ingredient.OrigQuanity1 = ingredient.Quantity1;
                        ingredient.Quantity1 *= 3;
                    }
                }
            }

            // Scaling applied successfully
            return true;
        }



        public bool ResetIngredientQuantities(List<List<IngredientCapture>> ingredients)
        {
            foreach (List<IngredientCapture> ingredientList in ingredients)
            {
                foreach (IngredientCapture ingredient in ingredientList)
                {
                    ingredient.Quantity1 = ingredient.OrigQuanity1; // Reset the quantity to its original value
                }
            }

            return true;
        }



    }
}
