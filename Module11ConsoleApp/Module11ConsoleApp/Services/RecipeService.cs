using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Module11ConsoleApp.Models;

namespace Module11ConsoleApp.Services
{
    public class RecipeService
    {
        private List<Recipe> _recipes = new List<Recipe>();

        public void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
            Console.WriteLine($"Рецепт '{recipe.Name}' додано успішно.");
        }

        public bool RemoveRecipe(string name)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                _recipes.Remove(recipe);
                Console.WriteLine($"Рецепт '{name}' видалено успішно.");
                return true;
            }
            Console.WriteLine($"Рецепт '{name}' не знайдено.");
            return false;
        }

        public bool UpdateRecipe(string name, Recipe updatedRecipe)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                int index = _recipes.IndexOf(recipe);
                _recipes[index] = updatedRecipe;
                Console.WriteLine($"Рецепт '{name}' оновлено успішно.");
                return true;
            }
            Console.WriteLine($"Рецепт '{name}' не знайдено.");
            return false;
        }

        public List<Recipe> SearchByCuisine(string cuisine)
        {
            return _recipes.Where(r => r.Cuisine.Equals(cuisine, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Recipe> SearchByCookingTime(int maxMinutes)
        {
            return _recipes.Where(r => r.CookingTimeMinutes <= maxMinutes).ToList();
        }

        public List<Recipe> SearchByIngredient(string ingredient)
        {
            return _recipes.Where(r => r.Ingredients.Any(i => i.Equals(ingredient, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public List<Recipe> SearchByName(string name)
        {
            return _recipes.Where(r => r.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Recipe> SearchByCalories(int maxCalories)
        {
            return _recipes.Where(r => r.TotalCalories <= maxCalories).ToList();
        }

        public List<Recipe> SearchByDishType(DishType dishType)
        {
            return _recipes.Where(r => r.DishType == dishType).ToList();
        }

        public List<Recipe> SearchByDishTypes(List<DishType> dishTypes)
        {
            return _recipes.Where(r => dishTypes.Contains(r.DishType)).ToList();
        }

        public void SaveToFile(string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                string json = JsonSerializer.Serialize(_recipes, options);
                File.WriteAllText(filePath, json, Encoding.UTF8);
                Console.WriteLine($"Рецепти успішно збережено у файл '{filePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні: {ex.Message}");
            }
        }

        public void LoadFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл '{filePath}' не існує.");
                    return;
                }

                string json = File.ReadAllText(filePath, Encoding.UTF8);
                _recipes = JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
                Console.WriteLine($"Рецепти успішно завантажено з файлу '{filePath}' ({_recipes.Count} рецептів)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні: {ex.Message}");
            }
        }

        public void GenerateReportByCuisine(string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine("=== Звіт за типом кухні ===\n");

            var grouped = _recipes.GroupBy(r => r.Cuisine);
            foreach (var group in grouped)
            {
                report.AppendLine($"Кухня: {group.Key}");
                foreach (var recipe in group)
                {
                    report.AppendLine($"  - {recipe.Name} ({recipe.DishType}, {recipe.CookingTimeMinutes} хв, {recipe.TotalCalories} ккал)");
                }
                report.AppendLine();
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByCookingTime(string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine("=== Звіт за часом готування ===\n");

            var sorted = _recipes.OrderBy(r => r.CookingTimeMinutes);
            foreach (var recipe in sorted)
            {
                report.AppendLine($"{recipe.Name}: {recipe.CookingTimeMinutes} хвилин ({recipe.Cuisine} кухня)");
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByIngredient(string ingredient, string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine($"=== Звіт за інгредієнтом: {ingredient} ===\n");

            var recipes = SearchByIngredient(ingredient);
            foreach (var recipe in recipes)
            {
                report.AppendLine($"{recipe.Name} ({recipe.Cuisine} кухня)");
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByName(string name, string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine($"=== Звіт за назвою: {name} ===\n");

            var recipes = SearchByName(name);
            foreach (var recipe in recipes)
            {
                report.AppendLine($"Назва: {recipe.Name}");
                report.AppendLine($"Кухня: {recipe.Cuisine}");
                report.AppendLine($"Тип страви: {recipe.DishType}");
                report.AppendLine($"Час готування: {recipe.CookingTimeMinutes} хв");
                report.AppendLine($"Калорії: {recipe.TotalCalories}");
                report.AppendLine($"Інгредієнти: {string.Join(", ", recipe.Ingredients)}");
                report.AppendLine();
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByCalories(string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine("=== Звіт за сумою калорій ===\n");

            var sorted = _recipes.OrderByDescending(r => r.TotalCalories);
            foreach (var recipe in sorted)
            {
                report.AppendLine($"{recipe.Name}: {recipe.TotalCalories} ккал ({recipe.Cuisine} кухня)");
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByDishType(DishType dishType, string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine($"=== Звіт за типом страви: {dishType} ===\n");

            var recipes = SearchByDishType(dishType);
            foreach (var recipe in recipes)
            {
                report.AppendLine($"{recipe.Name} ({recipe.Cuisine} кухня, {recipe.CookingTimeMinutes} хв, {recipe.TotalCalories} ккал)");
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        public void GenerateReportByDishTypes(List<DishType> dishTypes, string outputPath = null)
        {
            var report = new StringBuilder();
            report.AppendLine($"=== Звіт за комбінацією типів страв: {string.Join(", ", dishTypes)} ===\n");

            var recipes = SearchByDishTypes(dishTypes);
            foreach (var recipe in recipes)
            {
                report.AppendLine($"{recipe.Name} ({recipe.DishType}, {recipe.Cuisine} кухня, {recipe.CookingTimeMinutes} хв, {recipe.TotalCalories} ккал)");
            }

            DisplayOrSaveReport(report.ToString(), outputPath);
        }

        private void DisplayOrSaveReport(string report, string? outputPath)
        {
            if (string.IsNullOrEmpty(outputPath))
            {
                Console.WriteLine(report);
            }
            else
            {
                try
                {
                    File.WriteAllText(outputPath, report, Encoding.UTF8);
                    Console.WriteLine($"Звіт збережено у файл '{outputPath}'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при збереженні звіту: {ex.Message}");
                    Console.WriteLine("\nВміст звіту:");
                    Console.WriteLine(report);
                }
            }
        }

        public List<Recipe> GetAllRecipes()
        {
            return _recipes;
        }
    }
}

