using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace POE_Project
{
    /// <summary>
    /// This is recipe class
    /// </summary>
    public class Recipe
    {
        //These are the global variables
        private int ingrCount;
        private string recipe;
        private int quaIng;
        private String unit;
        private string nameIng;
        private int measu;
        private int calori;
        private string foodGroup;
        private string descrptio;

        /// <summary>
        /// This is List that I store Capture
        /// </summary>
        List<List<IngredientCapture>> RecipeIngredients = new List<List<IngredientCapture>>();

        List<RecipeDescription> RecipeDescription = new List<RecipeDescription>();

        //-----------------------------------------------------------------------------------------Menu()-----------------------------------------------------------------------------------------------------------//
        public void Menu()
        {
            // Display the menu options
            Console.WriteLine("Menu:\n\n1. New Recipe\n2. Display\n3. Scale Ingredients\n4. Reset Quantities\n5. Clear Data\n6. Exit");
            WriteLine();
            Console.Write("Enter your choice: ");
            int choice;

            // Validate the user input to ensure it is a valid choice
            while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 1 || choice > 7)
            {
                WriteLine("Please provide a valid input (1-6)");
                WriteLine();
                Console.Write("Enter your choice: ");
            }

            switch (choice)
            {
                case 1:
                    if (RecipeIngredients.Count == 0)
                    {
                        Console.WriteLine("You chose New Recipe");
                        WriteLine();

                        // Start creating a new recipe
                        Main();
                    }

                    if (RecipeIngredients.Count > 0)
                    {
                        Console.WriteLine("You chose to add more recipes");
                        WriteLine();
                        // Ask for another recipe
                        AskAgain();
                    }
                    break;

                case 2:
                    Console.WriteLine("You chose Display");
                    WriteLine();

                    if (RecipeIngredients.Count == 0)
                    {
                        WriteLine("No recipes available. Please create a new recipe first.");
                        WriteLine();
                        Menu();
                    }
                    else
                    {
                        if (RecipeIngredients.Count > 1)
                        {
                            WriteLine("Your recipes contain more than one");
                            WriteLine("Do you want to view them all together? Press '1' or view a specific recipe? Press '2'");
                            int chose;

                            // Validate the user input to ensure it is either 1 or 2
                            while (int.TryParse(Console.ReadLine(), out chose) == false || chose < 1 || chose > 2)
                            {
                                WriteLine("Please provide a value between 1 and 2 only");
                                WriteLine();
                                WriteLine("Do you want to view them all together? Press '1' or view a specific recipe? Press '2'");
                                WriteLine();
                            }

                            if (chose == 1)
                            {
                                // Display all the recipes together
                                ToPrint(RecipeIngredients);
                            }
                            else
                            {
                                // View a specific recipe
                                ViewSpecificReicpe(chose);
                            }
                        }
                    }

                    // Display the recipe details
                    ToPrint(RecipeIngredients);
                    break;

                case 3:
                    Console.WriteLine("You chose Scale Ingredients");
                    WriteLine();

                    if (RecipeIngredients.Count == 0)
                    {
                        WriteLine("No recipes available. Please create a new recipe first.");
                        WriteLine();
                        Menu();
                    }

                    // Convert the units of the Ingredients to a common unit
                    Measurement(RecipeIngredients);
                    break;

                case 4:
                    Console.WriteLine("You chose Reset Quantities");
                    WriteLine();

                    if (RecipeIngredients.Count == 0)
                    {
                        WriteLine("No recipes available. Please create a new recipe first.");
                        WriteLine();
                        Menu();
                    }

                    // Convert the quantities of the Ingredients to the smallest possible quantities
                    ClearQuantity(RecipeIngredients, this.measu);
                    break;

                case 5:
                    Console.WriteLine("You chose Clear Data");
                    WriteLine();

                    if (RecipeIngredients.Count == 0)
                    {
                        WriteLine("No recipes available. Please create a new recipe first.");
                        WriteLine();
                        Menu();
                    }

                    // Reset the recipe data
                    ResetRecipe();
                    break;

                case 6:
                    WriteLine("Thank You");
                    Environment.Exit(0);
                    break;

                default:
                    WriteLine("Invalid choice");
                    break;
            }
        }

        //-----------------------------------------------------------------------------------------End of Menu-----------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------ViewSpecificRecipe()--------------------------------------------------------------------------------------------//

        private void ViewSpecificReicpe(int chose)
        {
            if (chose == 2)
            {
                WriteLine("Please provide the name of the recipe");
                string name = ReadLine();

                bool recipeFound = false;

                // Loop through the recipes to find the matching recipe by name
                for (int v = 0; v < RecipeIngredients.Count; v++)
                {
                    if (RecipeIngredients[v][0].Recipe1.Equals(name))
                    {
                        recipeFound = true;

                        // Print the heading
                        Console.WriteLine("*".PadLeft(120, '*'));
                        Console.WriteLine("\t\t\t\t\tDISPLAY");
                        Console.WriteLine("-".PadLeft(120, '-'));

                        // Print the recipe name
                        Console.WriteLine($"Recipe:\t\t\t {RecipeIngredients[v][0].Recipe1}");
                        Console.WriteLine(new string('-', 120));

                        // Print the table header for ingredients
                        Console.WriteLine("| {0,-5} | {1,-25} | {2,-10} | {3,-15} | {4,-10} | {5,-15} |", "No.", "Ingredient Name", "Quantity", "Measurement", "Calories", "Food Group");
                        Console.WriteLine(new string('-', 120));

                        // Loop through the ingredients of the current recipe
                        for (int j = 0; j < RecipeIngredients[v].Count; j++)
                        {
                            IngredientCapture t = RecipeIngredients[v][j];

                            // Print the ingredient details
                            Console.WriteLine("| {0,-5} | {1,-25} | {2,-10} | {3,-15} | {4,-10} | {5,-15} |", j + 1, t.Name1, t.Quantity1, t.Unit, t.Calories1, t.FoodGroup);
                            Console.WriteLine(new string('-', 120));

                            // Call the cupMeasurement method to print the equivalent measurement in cups, if applicable
                            CupMeasurement(t);

                            Console.WriteLine();
                        }

                        // Check the total calories of the recipe
                        CheckCalories();

                        // Print the steps description for the current recipe
                        Console.WriteLine("\nSteps Description:");
                        PrintRecipeDescription();

                        // Print the ending asterisks
                        Console.WriteLine("*".PadLeft(120, '*'));
                        Console.WriteLine();

                        // Call the Menu method to display the menu options
                        Menu();
                        break;
                    }
                }

                if (recipeFound == true)
                {
                    WriteLine($"Recipe '{name}' has been found.");
                    ToPrint(RecipeIngredients);
                }
                else
                {
                    if (recipeFound == false)
                    {
                        WriteLine($"Recipe '{name}' not found.");
                        WriteLine();
                        Menu();
                    }
                }
            }
        }
        //------------------------------------------------------------------------------------------------End of ViewSpecificRecipe()--------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------InputRecipeDescription()--------------------------------------------------------------------------------------------//
        public void InputRecipeDescription()
        {
            // Loop through each recipe description.
            for (int i = 0; i < RecipeDescription.Count; i++)
            {
                // Get the recipe name from user input.
                this.recipe = Main();

                // Get the step description from user input.
                this.descrptio = Steps();

                // Create a RecipeDescription object with the recipe name and step description.
                RecipeDescription recipeDesc = new RecipeDescription(recipe, descrptio);

                // Add the RecipeDescription object to the list of all recipes' descriptions.
                RecipeDescription.Add(recipeDesc);
            }

            // Call any other desired logic after all recipes have been processed and added to list of descriptions. 
            Menu();
        }

        //------------------------------------------------------------------------------------------------End of InputRecipeDescription--------------------------------------------------------------------------------------------//

        //-----------------------------------------------------------------------------------------------------------Main()-------------------------------------------------------//
        public String Main()
        {

            // Ask the user to provide the name of their recipe
            WriteLine("Please Provide the name of your Recipe ");
            recipe = ReadLine();

            // If the user entered an empty string or a string containing only whitespace characters, keep asking until they provide a non-empty value
            while (String.IsNullOrEmpty(recipe) || String.IsNullOrWhiteSpace(recipe))
            {
                WriteLine("Please don't Leave any Empty Space");
                WriteLine();
                WriteLine("Please Provide the name of your Recipe ");
                recipe = ReadLine();
            }

            WriteLine();

            InputDetails();
            return recipe;

            // Call the InputDetails method to get the input from the user about the recipe ingredients and steps
        }
        //-----------------------------------------------------------------------------End of Main()----------------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------Ingridetnts()-------------------------------------------------------------------------------------------------------------------------//

        private int Ingridents()
        {
            // Prompt the user to enter a number or number word for ingredients
            WriteLine("Please enter the number of  ingredients as a number or word (e.g. '1', 'one', '2', 'two', etc.):");


            // Read the user input and convert it to lower case
            string input = ReadLine().ToLower();

            // Initialize variables for number parsing and sum calculation
            int num = 0;
            int sum = 0;

            // Check if the input can be parsed as an integer
            if (int.TryParse(input, out ingrCount))
            {
                // Process the input as an integer
                sum = ingrCount;

            }
            else
            {
                // Process the input as a string
                StringToNumber(ref input, ref num, ref sum);
            }

            // Check if the sum is zero, indicating invalid input
            if (sum == 0)
            {
                WriteLine("Invalid input, please try again.");
                WriteLine();

                // Call the input details method recursively to prompt the user again
                InputDetails();
            }

            // Return the sum of ingredients
            return sum;
        }
        //---------------------------------------------------------------------------End of Ingridents()----------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------Quantity()----------------------------------------------------------------------------------------------------------//
        private int Quantity(int i)
        {
            // Prompt the user to enter the quantity of an ingredient
            WriteLine($"Quantity of an ingredient: {i + 1}");

            // Read the user's input as a string
            String qua = Console.ReadLine().ToLower();

            // Initialize variables to store the parsed values
            int sum = 0;
            int num = 0;

            // Check if the input can be parsed as an integer
            if (int.TryParse(qua, out quaIng))
            {
                // Process the input as an integer
                sum = quaIng;

            }
            else
            {
                // Process the input as a string
                StringToNumber(ref qua, ref num, ref sum);
            }

            // Check if the sum is 0, indicating an invalid input
            if (sum == 0)
            {
                // Prompt the user to try again and call the method recursively
                WriteLine("Invalid Input, Please Try again");
                WriteLine();
                Quantity(i);
            }

            // Return the sum of the ingredient quantity
            return sum;
        }
        //-----------------------------------------------------------------------------End of Quantity()------------------------------------------------------------------------------------------------------------//

        private int Calories(int i)
        {
            WriteLine($"Calories of an ingredient: {i + 1}");

            String cal = Console.ReadLine().ToLower();

            int sum = 0;
            int num = 0;

            // Check if the input can be parsed as an integer
            if (int.TryParse(cal, out calori))
            {
                // Process the input as an integer
                sum = calori;

            }
            else
            {
                // Process the input as a string
                StringToNumber(ref cal, ref num, ref sum);
            }

            // Check if the sum is 0, indicating an invalid input
            if (sum == 0)
            {
                // Prompt the user to try again and call the method recursively
                WriteLine("Invalid Input, Please Try again");
                WriteLine();
                Calories(i);
            }

            // Return the sum of the ingredient quantity
            return sum;


        }

        //------------------------------------------------------------------------------------InputDetails()---------------------------------------------------------------------------------------------------------//
        public void InputDetails()
        {
            // Call the Ingridents() method to get the number of ingredients required for the recipe
            this.ingrCount = Ingridents();

            // Initialize the ingredients array with the number of ingredients entered by the user
            List<IngredientCapture> ingredients = new List<IngredientCapture>();
            int i = 0;
            int store;

            // Loop through the ingredients array to get the name, quantity and unit of each ingredient
            do
            {
                // Get the name of the ith ingredient from the user
                WriteLine($"\nName of the ingredients : {i + 1} ");
                nameIng = ReadLine();

                // Keep prompting the user to enter the name of the ingredient until a non-empty input is provided
                while (String.IsNullOrEmpty(nameIng) || String.IsNullOrWhiteSpace(nameIng))
                {
                    WriteLine("Please don't Leave any Empty Space");
                    WriteLine($"\nName of the ingredients : {i + 1} ");
                    nameIng = ReadLine();
                }

                WriteLine();

                // Get the quantity of the ith ingredient from the user
                quaIng = Quantity(i);

                WriteLine();
                // Explanation for calories
                Console.WriteLine("-- This line adds the calories to each ingredient");
                Console.WriteLine();
                calori = Calories(i);


                WriteLine();
                // Explanation for food group selection
                Console.WriteLine("-- This line assigns the selected food group to the ingredient");
                Console.WriteLine();

                // Assign the selected food group to the ingredient
                this.foodGroup = FoodGroup(i);

                WriteLine();

                // Get the unit of the ith ingredient from the user
                WriteLine($"Enter the unit of ingredient : {i + 1}");
                unit = ReadLine().ToLower();

                // Keep prompting the user to enter the unit of the ingredient until a non-empty input is provided
                while (String.IsNullOrEmpty(unit) || String.IsNullOrWhiteSpace(unit))
                {
                    WriteLine("Please don't Leave any Empty Space");
                    Console.Write("Enter the unit of ingredient {0}: ", i + 1);
                    WriteLine();
                    unit = ReadLine().ToLower();
                }


                IngredientCapture t1 = new IngredientCapture(nameIng, quaIng, unit, recipe, calori, foodGroup);
                ingredients.Add(t1);

                WriteLine();
                WriteLine("Do you want add more ingredients? Press 1 for 'Yes' or 2 for 'No'");

                while (int.TryParse(Console.ReadLine(), out store) == false || store < 1 || store > 2)
                {
                    WriteLine("Please Enter the valid input (1-2)");
                    WriteLine();
                    WriteLine("Do you want add more ingredients? Press 1 for 'Yes' or 2 for 'No'");
                }

            } while (store != 2);

            RecipeIngredients.Add(ingredients);

            this.descrptio = Steps();

            // Create a RecipeDescription object with the recipe name and step description.
            RecipeDescription recipeDesc = new RecipeDescription(recipe, descrptio);

            // Add the RecipeDescription object to the RecipeDescription.
            RecipeDescription.Add(recipeDesc);


            WriteLine();
            WriteLine("\t\t'SUCESSFULLY CAPTURE THE INGRIDENTS VALUES'");
            WriteLine();
            Console.WriteLine("*".PadLeft(120, '*'));
            Menu();


            WriteLine();
        }

        //------------------------------------------------------------------------------------End of InputDetails()-------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------CheckTotalCalories()------------------------------------------------------------------------------------------//
        // This method checks if the total calories exceed 300.
        public int CheckTotalCalories(int totalCalories)
        {
            if (totalCalories > 300)
            {
                WriteLine("The total calories of this recipe exceed 300.");
                return totalCalories; // Return the value of totalCalories.
            }
            else
            {
                return 0; // Return zero if calories are not exceeded.
            }
        }

        private void CheckCalories()
        {
            // Iterate through each ingredient and sum up the calorie values.
            for (int i = 0; i < RecipeIngredients.Count; i++)
            {
                List<IngredientCapture> recipe = RecipeIngredients[i];

                for (int j = 0; j < recipe.Count; j++)
                {
                    IngredientCapture cal = recipe[j];
                    calori += cal.Calories1;
                }
            }

            // Create an instance of a delegate that takes in an integer argument and returns an integer result, 
            // and assign it to our CheckTotalCalorie method reference. 
            CaloriesCheckerDelegate caloriesChecker = CheckTotalCalories;

            // Invoke the delegate with our calorie count as its input argument,
            // which will call our assigned method to check whether or not we've exceeded the allowed limit on calories. 
            caloriesChecker(calori);
        }


        //----------------------------------------------------------------------------------------FoodGroup()-----------------------------------------------------------------------------------------//
        // This method prompts the user to choose a food group from a list of options.
        private string FoodGroup(int i)
        {
            Console.WriteLine($"Please Choose The Food Group : {i + 1}\n");
            Console.WriteLine("1. Starchy foods\n2. Vegetables and fruits\n3. Dry beans, peas, lentils and soya\n4. Chicken, fish, meat and eggs\n5. Milk and dairy products\n6. Fats and oil\n7. Water");

            int choice;

            // Keep prompting for input until valid number in range [1-7] is provided by user.
            while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 1 || choice > 7)
            {
                Console.WriteLine("Please Provide the valid input (1-7)");
                Console.WriteLine("Please select a food group:");
            }

            // Once valid input has been received from user via switch statement,
            // return corresponding string value associated with that option/choice.
            switch (choice)
            {
                case 1:
                    return "Starchy foods";
                case 2:
                    return "Vegetables and fruits";
                case 3:
                    return "Dry beans, peas, lentils and soya";
                case 4:
                    return "Chicken, fish, meat and eggs";
                case 5:
                    return "Milk and dairy products";
                case 6:
                    return "Fats and oil";
                case 7:
                    return "Water";
                default:   // If invalid input was entered by user
                    Console.WriteLine("Invalid choice.");
                    return null;   // Return null as no match found
            }
        }

        //--------------------------------------------------------------------------------------End of FoodGroup()-----------------------------------------------------------------------------------------//

        //-----------------------------------------------------------------------------Steps()------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method takes input from the user and returns an array of strings representing the steps involved in a recipe.
        /// </summary>
        /// <returns></returns>
        private string Steps()
        {
            // Ask the user to provide the number of steps involved in the recipe.
            WriteLine($"\nPlease provide the number of steps:");
            string St = Console.ReadLine().ToLower();
            WriteLine();

            // Declare and initialize variables to store the number of steps, sum of steps, and a placeholder for numeric value.
            int sum = 0;
            int num = 0;

            // Check if the user input is a valid integer.
            if (int.TryParse(St, out int ingSteps))
            {
                // If the input is a valid integer, assign it to the sum variable.
                sum = ingSteps;
            }
            else
            {
                // If the input is not a valid integer, convert the input to numeric value using StringToNumber method.
                StringToNumber(ref St, ref num, ref sum);
            }

            // If the sum of steps is equal to zero, it means the user input was invalid. So, ask the user to try again.
            if (sum == 0)
            {
                WriteLine("Invalid Input, Please Try again");
                WriteLine();
                return Steps(); // Return the result of the recursive call
            }

            // Declare a variable to store the step descriptions
            this.descrptio = StepsIngridents(sum);


            // Return the step descriptions
            return descrptio;
        }

        //-------------------------------------------------------------------------End of Steps()-----------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------------------------StringToNumber()-------------------------------------------------------------------------------------------------------------------//
        private void StringToNumber(ref string input, ref int num, ref int sum)
        {
            //A dictionary is created to store the corresponding integer value of each string number word.
            Dictionary<String, int> numberValue = new Dictionary<String, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
                { "ten", 10 },
                {"eleven",11 },
                {"tweleve",12 },
                {"thirteen",13 },
                {"fourteen",14 },
                {"fifteen",15 },
                {"sixteen",16 },
                {"seventeen",17 },
                {"eighteen",18 },
                {"nineteen",19 },
                { "twenty", 20 },
                { "thirty", 30 },
                { "fourty", 40 },
                { "fifty", 50 },
                { "sixty", 60 },
                { "eighty", 80 },
                { "ninety", 90 },
                { "hundred", 100 }
            };

            //The "and" word is replaced with a space and then the input is split into an array of string values.
            input = input.Replace("and", " ");
            string[] values = input.Split(' ');

            //A loop is used to iterate through each string value in the array.
            for (int v = 0; v < values.Length; v++)
            {
                //If the current string value is "hundred", then the current sum is multiplied by 100 to account for the hundreds place
                if (values[v] == "hundred")
                {
                    sum *= 100;
                }
                //If the current string value is "and", then it is skipped since it has no numerical value
                else if (values[v] == "and")
                {
                    continue; // skip the "and" word
                }
                //If the current string value is found in the dictionary, then its corresponding integer value is retrieved and added to the sum.
                else if (numberValue.TryGetValue(values[v], out num))
                {
                    sum += num;
                }
            }
            //The final sum value is printed to the console.


        }
        //---------------------------------------------------------------------------End of StringToNumber()-----------------------------------------------------------------------------------------------------//

        //----------------------------------------------------------------------------------Measurement()-------------------------------------------------------------------------------------------------------------//
        private void Measurement(List<List<IngredientCapture>> RecipeIngredients)
        {
            // Prompt the user to choose the measurement for the ingredients
            WriteLine($"\nPlease choose the measurement here for your ingredient  \n 1: Half (1/2) \n 2: double (2) \n 3: Triple(3)");

            // Keep asking for input until a valid number between 1 and 3 is entered
            while (int.TryParse(Console.ReadLine(), out this.measu) == false || this.measu < 1 || this.measu > 3)
            {
                WriteLine("Please Provide the valid input (1-3)");
                WriteLine($"\nPlease choose the measurement here for your ingredient  \n 1: Half (1/2) \n 2: double (2) \n 3: Triple(3)");
            }

            // Iterate over the ingredients and apply the chosen measurement to each
            foreach (List<IngredientCapture> recipe in RecipeIngredients)
            {
                foreach (IngredientCapture ing in recipe)
                {
                    switch (measu)
                    {
                        // Halve the quantity of the ingredient
                        case 1:
                            ing.Quantity1 = (int)(ing.Quantity1 * 0.5);
                            WriteLine();
                            break;

                        // Double the quantity of the ingredient
                        case 2:
                            ing.Quantity1 = (ing.Quantity1 * 2);
                            WriteLine();
                            break;

                        // Triple the quantity of the ingredient
                        case 3:
                            ing.Quantity1 = (ing.Quantity1 * 3);
                            WriteLine();
                            break;

                        // This should never happen, but if the measurement chosen is not 1, 2, or 3, print an error message
                        default:
                            WriteLine("Error");
                            break;

                    }
                }
            }


            WriteLine("Sucessfully Updated the Measurements");
            WriteLine();
            Menu();



        }
        //------------------------------------------------------------------------------End of Measurement()---------------------------------------------------------------------------------------------------------------//

        //----------------------------------------------------------------------------CupMeasurement()---------------------------------------------------------------------------------------------------------------------//
        private static void CupMeasurement(IngredientCapture ing)
        {
            // This method checks if the quantity of the ingredient is greater than or equal to 16 and its unit of measurement is "table of spoon", "spoon", or "table".
            if (ing.Quantity1 >= 16 && (ing.Unit.Equals("table of spoon") || ing.Unit.Contains("spoon") || ing.Unit.Contains("table")))
            {
                // If the conditions are met, it displays a message that the unit of measurement is one cup.
                WriteLine($"The unit of measurement is one cup ");
            }
        }
        //-------------------------------------------------------------------------------End of cupMeasurement()---------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------------------------------StepsIngridents()-----------------------------------------------------------------------------------------------------------------------//
        // This method prompts user to enter a description for each step in the recipe.
        private String StepsIngridents(int sum)
        {
            // Initialize an empty string for storing all descriptions.
            string descriptions = "";

            // Iterate through each step and prompt user to input a description for that step.
            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine($"Please provide the description of step {i + 1}:");
                string description = Console.ReadLine();

                // Concatenate each description along with a newline character.
                descriptions += description + "\n";

                Console.WriteLine();
            }

            // Return all descriptions as a single formatted string, trimmed of any excess whitespace characters at beginning or end. 
            return descriptions.Trim();
        }
        //--------------------------------------------------------------------------------End of StepIngridents()----------------------------------------------------------------------------------------------------------//

        //----------------------------------------------------------------------------------PrintRecipeDescription()--------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method prints out the recipe name and description for each step in that recipe.
        /// </summary>
        private void PrintRecipeDescription()
        {
            // Loop through each RecipeDescription object stored in the List.
            for (int v = 0; v < RecipeDescription.Count; v++)
            {
                // Get current RecipeDescription object from list.
                RecipeDescription recDes = RecipeDescription[v];

                // Print out the recipe name corresponding to this iteration of loop.
                WriteLine($"\nRecipe Name {v + 1}: {recDes.RecipeName}\n");

                // Split up StepDescriptions by newline characters and print them out with their associated step numbers
                string[] steps = recDes.StepDescription.Split('\n');

                for (int i = 0; i < steps.Length; i++)
                {
                    // Remove any leading/trailing whitespace from each step description before printing it along with its corresponding number. 
                    string trimmedStepDescrption = steps[i].Trim();
                    WriteLine($"- Step {i + 1}: {trimmedStepDescrption}");
                }
            }
        }


        //----------------------------------------------------------------------------------End of Print Description ()-----------------------------------------------------------------------------------------------------//

        //----------------------------------------------------------------------ClearQuantity()-----------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// This method clears the value of Quantity1 for all IngredientCapture objects in RecipeIngredients list, dividing by measu.
        /// </summary>
        /// <param name="RecipeIngredients">The List of Lists of IngredientCapture objects representing recipe ingredients.</param>
        /// <param name="measu">The integer to divide each Quantity1 value by (to reset it).</param>
        private void ClearQuantity(List<List<IngredientCapture>> RecipeIngredients, int measu)
        {
            // Prompt user to confirm whether they want to clear/reset all quantity values.
            WriteLine("\nAre you sure you want to reset the Quantity  say 1 = Yes or 2 = No ");

            // Loop until user provides valid input (either 1 or 2).
            int use;
            while (int.TryParse(ReadLine(), out use) == false || (use != 1 && use != 2))
            {
                WriteLine("Please provide a valid input (1 or 2 only).");
                WriteLine();
                WriteLine("\nAre you sure you want to reset the Quantity? Say '1' for Yes and '2' for No.");
            }

            WriteLine();

            if (use.Equals(1)) // If user confirms they want to clear/reset quantities...
            {
                // Iterate through each recipe in RecipeIngredients list and divide each ingredient's quantity by measu.
                for (int i = 0; i < RecipeIngredients.Count; i++)
                {
                    List<IngredientCapture> recipe = RecipeIngredients[i];

                    for (int j = 0; j < recipe.Count; j++)
                    {
                        IngredientCapture ing = recipe[j];
                        ing.Quantity1 /= measu;
                    }
                }


                // Inform user that operation was successful, print updated ingredient list with cleared quantities,
                // and return to main menu. 
                WriteLine("Successfully returns the original value");
                WriteLine();
                ToPrint(RecipeIngredients);
                WriteLine();

                Menu();
            }
            else
            {
                if (use.Equals(2)) // If user chooses not to clear/reset quantities, return to main menu.
                {
                    Menu();
                }
            }
        }
        //-------------------------------------------------------------------------End of ClearQuantity()------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------ResetRecipe()-----------------------------------------------------------------------------------------------------------------------//
        private void ResetRecipe()
        {
            //This line prompts the user to enter whether or not they want to reset the quantity of ingredients.
            WriteLine("\nIf you want to clear all the data please enter 1 = yes or 2 = no");
            int un;

            //This while loop checks that the user enters a valid input, which is either 1 or 2.
            while (int.TryParse(ReadLine(), out un) == false || un < 1 || un > 2)
            {
                WriteLine("Please provide a valid input (1 or 2 only).");
                WriteLine();
                WriteLine("\nIf you want to clear all the data  please enter 1 for yes or 2 or no");

            }

            WriteLine();

            if (un == 1)
            {
                RecipeIngredients.Clear();
                RecipeDescription.Clear();

                // Display message to indicate successful clearing
                WriteLine("Data has been successfully cleared.");

                WriteLine();

                Menu();
            }
            else
            {
                // If user chooses not to clear the data, simply return to the menu
                if (un == 2)
                {
                    Menu();
                }
            }


        }
        //------------------------------------------------------------------------------End of Reset Recipe()----------------------------------------------------------------------------------------------------------//

        //---------------------------------------------------------------------------------AskAgain()----------------------------------------------------------------------------------------------------------------------//
        private void AskAgain()
        {
            // Ask user if they want to add new recipes
            WriteLine("you want to add new recipes say 1 = 'Yes' and 2 = 'No' ");

            // Initialize variable to store user input
            int ask;


            // Use a loop to validate user input
            while (int.TryParse(ReadLine(), out ask) == false || ask < 1 || ask > 2)
            {
                // Display error message if input is invalid
                WriteLine("Please provide a valid input (1 or 2 only).");
                WriteLine();
                // Ask user again for input
                WriteLine("If you want to add new recipes say 1 = 'Yes' and 2 = 'No' ");
            }

            // If user input is 1, call the 'Main' method to restart the program
            if (ask == 1)
            {
                WriteLine();
                Main();
            }
            // If user input is 2, display a thank you message
            else
            {
                if (ask == 2)
                {
                    Menu();
                }
            }

        }


        //----------------------------------------------------------------------------End of AskAgain()--------------------------------------------------------------------------------------------------------------//

        //-----------------------------------------------------------------------ToPrint()---------------------------------------------------------------------------------------------------------------------------------//
        private void ToPrint(List<List<IngredientCapture>> RecipeIngredients)
        {
            // Print the heading
            Console.WriteLine("*".PadLeft(120, '*'));
            Console.WriteLine("\t\t\t\t\tDISPLAY");
            Console.WriteLine("-".PadLeft(120, '-'));

            // Sort the RecipeIngredients list by recipe name
            RecipeIngredients.Sort((r1, r2) => r1[0].Recipe1.CompareTo(r2[0].Recipe1));

            // Loop through the recipe list
            string currentRecipe;

            for (int i = 0; i < RecipeIngredients.Count; i++)
            {
                List<IngredientCapture> recipe = RecipeIngredients[i];

                // Reset the current recipe name for each new recipe
                currentRecipe = "";

                for (int j = 0; j < recipe.Count; j++)
                {
                    IngredientCapture t = recipe[j];

                    // If the recipe name is different from the previous one, print it
                    if (t.Recipe1 != currentRecipe)
                    {
                        Console.WriteLine($"Recipe:\t\t\t {t.Recipe1}");
                        Console.WriteLine(new string('-', 120));
                        currentRecipe = t.Recipe1;
                    }

                    // Print the table header for ingredients if it is the first ingredient in the recipe
                    if (j == 0)
                    {
                        Console.WriteLine("| {0,-5} | {1,-25} | {2,-10} | {3,-15} | {4,-10} | {5,-15} |", "No.", "Ingredient Name", "Quantity", "Measurement", "Calories", "Food Group");
                        Console.WriteLine(new string('-', 120));
                    }

                    // Print the ingredient details for the current ingredient
                    Console.WriteLine("| {0,-5} | {1,-25} | {2,-10} | {3,-15} | {4,-10} | {5,-15} |", j + 1, t.Name1, t.Quantity1, t.Unit, t.Calories1, t.FoodGroup);
                    Console.WriteLine(new string('-', 120));

                    // Print an empty line
                    Console.WriteLine();

                    // Call the cupMeasurement method to print the equivalent measurement in cups, if applicable
                    CupMeasurement(t);

                    WriteLine();
                }
            }
            // Check the total calories of the recipe
            CheckCalories();

            // Print the steps description for the current recipe
            Console.WriteLine("\nSteps Description:");
            PrintRecipeDescription();


            // Print the ending asterisks
            Console.WriteLine("*".PadLeft(120, '*'));
            Console.WriteLine();

            // Call the Menu method to display the menu options
            Menu();
        }


        //------------------------------------------------------------------------End of ToPrint()-----------------------------------------------------------------------------------------------------------------------//

    }//End of class

    // <param name="totalCalories">The integer representing the total number of calories in some recipe.</param>
    public delegate int CaloriesCheckerDelegate(int totalCalories);


}//End of nameSpace
