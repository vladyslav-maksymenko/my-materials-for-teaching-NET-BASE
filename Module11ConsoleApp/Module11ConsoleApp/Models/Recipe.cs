using System;
using System.Collections.Generic;

namespace Module11ConsoleApp.Models
{
    public class Recipe
    {
        public string Name { get; set; } = string.Empty;
        public string Cuisine { get; set; } = string.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public int CookingTimeMinutes { get; set; }
        public List<string> CookingSteps { get; set; } = new List<string>();
        public Dictionary<string, int> IngredientCalories { get; set; } = new Dictionary<string, int>();
        public DishType DishType { get; set; }

        public int TotalCalories
        {
            get
            {
                int total = 0;
                foreach (var ingredient in Ingredients)
                {
                    if (IngredientCalories.ContainsKey(ingredient))
                    {
                        total += IngredientCalories[ingredient];
                    }
                }
                return total;
            }
        }

        public override string ToString()
        {
            return $"Рецепт: {Name} ({Cuisine} кухня, {DishType}, {CookingTimeMinutes} хв, {TotalCalories} ккал)";
        }
    }

    public enum DishType
    {
        Салат,
        Перше,
        Друге,
        Закуска,
        Десерт
    }
}

