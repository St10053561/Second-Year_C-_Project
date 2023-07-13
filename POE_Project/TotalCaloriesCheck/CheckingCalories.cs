using Microsoft.VisualStudio.TestTools.UnitTesting;
using POE_Project;
using System;

namespace TotalCaloriesCheck
{
    [TestClass]
    public class CheckingCalories
    {
        [TestMethod]
        public void CaloriValue()
        {
            // Arrange
            int totalCalories = 350; // Set a totalCalories value greater than 300
            Recipe recipe = new Recipe();

            // Act
            int result = recipe.CheckTotalCalories(totalCalories);

            // Assert
            Assert.IsTrue(result > 300);

        }
    }
}
