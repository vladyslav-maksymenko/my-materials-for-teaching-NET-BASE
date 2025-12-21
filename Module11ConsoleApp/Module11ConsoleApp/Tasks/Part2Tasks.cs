using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Module11ConsoleApp.Models;
using Module11ConsoleApp.Services;

namespace Module11ConsoleApp.Tasks
{
    public static class Part2Tasks
    {
        private static RecipeService _recipeService = new RecipeService();

        public static void Task1_RecipeManagement()
        {
            Console.WriteLine("\n=== Завдання 1: Управління рецептами ===");
            
            while (true)
            {
                Console.WriteLine("\n--- Меню рецептів ---");
                Console.WriteLine("1. Додати рецепт");
                Console.WriteLine("2. Видалити рецепт");
                Console.WriteLine("3. Змінити рецепт");
                Console.WriteLine("4. Пошук рецептів");
                Console.WriteLine("5. Зберегти рецепти у файл");
                Console.WriteLine("6. Завантажити рецепти з файлу");
                Console.WriteLine("7. Генерувати звіти");
                Console.WriteLine("8. Показати всі рецепти");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        RemoveRecipe();
                        break;
                    case "3":
                        UpdateRecipe();
                        break;
                    case "4":
                        SearchRecipes();
                        break;
                    case "5":
                        SaveRecipes();
                        break;
                    case "6":
                        LoadRecipes();
                        break;
                    case "7":
                        GenerateReports();
                        break;
                    case "8":
                        ShowAllRecipes();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некоректний вибір.");
                        break;
                }
            }
        }

        private static void AddRecipe()
        {
            Recipe recipe = new Recipe();
            
            Console.Write("Назва рецепта: ");
            recipe.Name = Console.ReadLine() ?? "";
            
            Console.Write("Назва кухні: ");
            recipe.Cuisine = Console.ReadLine() ?? "";
            
            Console.WriteLine("Введіть інгредієнти (для завершення введіть порожній рядок):");
            string? ingredient;
            while (!string.IsNullOrWhiteSpace(ingredient = Console.ReadLine()))
            {
                recipe.Ingredients.Add(ingredient);
            }
            
            Console.Write("Час готування (хвилини): ");
            if (int.TryParse(Console.ReadLine(), out int time))
            {
                recipe.CookingTimeMinutes = time;
            }
            
            Console.WriteLine("Введіть кроки готування (для завершення введіть порожній рядок):");
            string? step;
            while (!string.IsNullOrWhiteSpace(step = Console.ReadLine()))
            {
                recipe.CookingSteps.Add(step);
            }
            
            Console.WriteLine("Введіть калорії для кожного інгредієнта:");
            foreach (var ing in recipe.Ingredients)
            {
                Console.Write($"  {ing}: ");
                if (int.TryParse(Console.ReadLine(), out int calories))
                {
                    recipe.IngredientCalories[ing] = calories;
                }
            }
            
            Console.WriteLine("Тип страви (1-Салат, 2-Перше, 3-Друге, 4-Закуска, 5-Десерт): ");
            if (int.TryParse(Console.ReadLine(), out int dishType) && dishType >= 1 && dishType <= 5)
            {
                recipe.DishType = (DishType)(dishType - 1);
            }
            
            _recipeService.AddRecipe(recipe);
        }

        private static void RemoveRecipe()
        {
            Console.Write("Введіть назву рецепта для видалення: ");
            string? name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                _recipeService.RemoveRecipe(name);
            }
        }

        private static void UpdateRecipe()
        {
            Console.Write("Введіть назву рецепта для зміни: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            var existing = _recipeService.GetAllRecipes().FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existing == null)
            {
                Console.WriteLine("Рецепт не знайдено.");
                return;
            }

            Console.WriteLine("Введіть нові дані (натисніть Enter, щоб залишити поточне значення):");
            
            Recipe updated = new Recipe
            {
                Name = existing.Name,
                Cuisine = existing.Cuisine,
                Ingredients = new List<string>(existing.Ingredients),
                CookingTimeMinutes = existing.CookingTimeMinutes,
                CookingSteps = new List<string>(existing.CookingSteps),
                IngredientCalories = new Dictionary<string, int>(existing.IngredientCalories),
                DishType = existing.DishType
            };

            Console.Write($"Назва рецепта [{existing.Name}]: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) updated.Name = input;

            Console.Write($"Назва кухні [{existing.Cuisine}]: ");
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) updated.Cuisine = input;

            _recipeService.UpdateRecipe(name, updated);
        }

        private static void SearchRecipes()
        {
            Console.WriteLine("\nТипи пошуку:");
            Console.WriteLine("1. За типом кухні");
            Console.WriteLine("2. За часом готування");
            Console.WriteLine("3. За інгредієнтом");
            Console.WriteLine("4. За назвою");
            Console.WriteLine("5. За калоріями");
            Console.WriteLine("6. За типом страви");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();
            List<Recipe> results = new List<Recipe>();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву кухні: ");
                    string? cuisine = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(cuisine))
                        results = _recipeService.SearchByCuisine(cuisine);
                    break;
                case "2":
                    Console.Write("Введіть максимальний час готування (хвилини): ");
                    if (int.TryParse(Console.ReadLine(), out int time))
                        results = _recipeService.SearchByCookingTime(time);
                    break;
                case "3":
                    Console.Write("Введіть інгредієнт: ");
                    string? ingredient = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ingredient))
                        results = _recipeService.SearchByIngredient(ingredient);
                    break;
                case "4":
                    Console.Write("Введіть назву: ");
                    string? name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                        results = _recipeService.SearchByName(name);
                    break;
                case "5":
                    Console.Write("Введіть максимальну кількість калорій: ");
                    if (int.TryParse(Console.ReadLine(), out int calories))
                        results = _recipeService.SearchByCalories(calories);
                    break;
                case "6":
                    Console.WriteLine("Тип страви (1-Салат, 2-Перше, 3-Друге, 4-Закуска, 5-Десерт): ");
                    if (int.TryParse(Console.ReadLine(), out int type) && type >= 1 && type <= 5)
                        results = _recipeService.SearchByDishType((DishType)(type - 1));
                    break;
            }

            if (results.Count > 0)
            {
                Console.WriteLine($"\nЗнайдено {results.Count} рецептів:");
                foreach (var recipe in results)
                {
                    Console.WriteLine($"  - {recipe}");
                }
            }
            else
            {
                Console.WriteLine("Рецепти не знайдено.");
            }
        }

        private static void SaveRecipes()
        {
            Console.Write("Введіть шлях до файлу для збереження: ");
            string? path = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(path))
            {
                _recipeService.SaveToFile(path);
            }
        }

        private static void LoadRecipes()
        {
            Console.Write("Введіть шлях до файлу для завантаження: ");
            string? path = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(path))
            {
                _recipeService.LoadFromFile(path);
            }
        }

        private static void GenerateReports()
        {
            Console.WriteLine("\nТипи звітів:");
            Console.WriteLine("1. За типом кухні");
            Console.WriteLine("2. За часом готування");
            Console.WriteLine("3. За інгредієнтом");
            Console.WriteLine("4. За назвою");
            Console.WriteLine("5. За калоріями");
            Console.WriteLine("6. За типом страви");
            Console.WriteLine("7. За комбінацією типів страв");
            Console.Write("Ваш вибір: ");

            string? choice = Console.ReadLine();
            Console.Write("Зберегти у файл? (Enter - ні, або введіть шлях): ");
            string? outputPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(outputPath)) outputPath = null;

            switch (choice)
            {
                case "1":
                    _recipeService.GenerateReportByCuisine(outputPath);
                    break;
                case "2":
                    _recipeService.GenerateReportByCookingTime(outputPath);
                    break;
                case "3":
                    Console.Write("Введіть інгредієнт: ");
                    string? ingredient = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ingredient))
                        _recipeService.GenerateReportByIngredient(ingredient, outputPath);
                    break;
                case "4":
                    Console.Write("Введіть назву: ");
                    string? name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                        _recipeService.GenerateReportByName(name, outputPath);
                    break;
                case "5":
                    _recipeService.GenerateReportByCalories(outputPath);
                    break;
                case "6":
                    Console.WriteLine("Тип страви (1-Салат, 2-Перше, 3-Друге, 4-Закуска, 5-Десерт): ");
                    if (int.TryParse(Console.ReadLine(), out int type) && type >= 1 && type <= 5)
                        _recipeService.GenerateReportByDishType((DishType)(type - 1), outputPath);
                    break;
                case "7":
                    Console.WriteLine("Введіть типи страв через кому (1-Салат, 2-Перше, 3-Друге, 4-Закуска, 5-Десерт): ");
                    string? typesInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(typesInput))
                    {
                        var types = typesInput.Split(',').Select(s => s.Trim())
                            .Where(s => int.TryParse(s, out int t) && t >= 1 && t <= 5)
                            .Select(s => (DishType)(int.Parse(s) - 1))
                            .ToList();
                        if (types.Count > 0)
                            _recipeService.GenerateReportByDishTypes(types, outputPath);
                    }
                    break;
            }
        }

        private static void ShowAllRecipes()
        {
            var recipes = _recipeService.GetAllRecipes();
            if (recipes.Count == 0)
            {
                Console.WriteLine("Рецепти відсутні.");
                return;
            }

            Console.WriteLine($"\nВсього рецептів: {recipes.Count}");
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"  - {recipe}");
            }
        }

        public static void Task2_CopyFile()
        {
            Console.WriteLine("\n=== Завдання 2: Копіювання файлу ===");
            Console.Write("Введіть шлях до оригінального файлу: ");
            string? source = Console.ReadLine();
            Console.Write("Введіть шлях до місця копіювання: ");
            string? destination = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))
            {
                FileService.CopyFile(source, destination);
            }
        }

        public static void Task3_MoveFile()
        {
            Console.WriteLine("\n=== Завдання 3: Переміщення файлу ===");
            Console.Write("Введіть шлях до оригінального файлу: ");
            string? source = Console.ReadLine();
            Console.Write("Введіть шлях до місця переміщення: ");
            string? destination = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))
            {
                FileService.MoveFile(source, destination);
            }
        }

        public static void Task4_CopyDirectory()
        {
            Console.WriteLine("\n=== Завдання 4: Копіювання папки ===");
            Console.Write("Введіть шлях до оригінальної папки: ");
            string? source = Console.ReadLine();
            Console.Write("Введіть шлях до місця копіювання: ");
            string? destination = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))
            {
                FileService.CopyDirectory(source, destination);
            }
        }

        public static void Task5_MoveDirectory()
        {
            Console.WriteLine("\n=== Завдання 5: Переміщення папки ===");
            Console.Write("Введіть шлях до оригінальної папки: ");
            string? source = Console.ReadLine();
            Console.Write("Введіть шлях до місця переміщення: ");
            string? destination = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(source) && !string.IsNullOrWhiteSpace(destination))
            {
                FileService.MoveDirectory(source, destination);
            }
        }

        public static void Task6_ValidateEnglishName()
        {
            Console.WriteLine("\n=== Завдання 6: Валідація ПІБ (англійські літери) ===");
            Console.Write("Введіть ПІБ: ");
            string? name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                bool isValid = ValidationService.ValidateEnglishName(name);
                Console.WriteLine($"Результат валідації: {(isValid ? "Валідний" : "Невалідний")}");
                Console.WriteLine(@"Регулярний вираз: ^[a-zA-Z\s]+$");
            }
        }

        public static void Task7_ValidateAge()
        {
            Console.WriteLine("\n=== Завдання 7: Валідація віку (тільки цифри) ===");
            Console.Write("Введіть вік: ");
            string? age = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(age))
            {
                bool isValid = ValidationService.ValidateAge(age);
                Console.WriteLine($"Результат валідації: {(isValid ? "Валідний" : "Невалідний")}");
                Console.WriteLine(@"Регулярний вираз: ^\d+$");
            }
        }

        public static void Task8_ValidateAddress()
        {
            Console.WriteLine("\n=== Завдання 8: Валідація адреси (цифри та англійські літери) ===");
            Console.Write("Введіть адресу: ");
            string? address = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(address))
            {
                bool isValid = ValidationService.ValidateAddress(address);
                Console.WriteLine($"Результат валідації: {(isValid ? "Валідний" : "Невалідний")}");
                Console.WriteLine(@"Регулярний вираз: ^[a-zA-Z0-9\s]+$");
            }
        }

        public static void Task9_ValidateEmail()
        {
            Console.WriteLine("\n=== Завдання 9: Валідація email ===");
            Console.Write("Введіть email: ");
            string? email = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(email))
            {
                bool isValid = ValidationService.ValidateEmail(email);
                Console.WriteLine($"Результат валідації: {(isValid ? "Валідний" : "Невалідний")}");
                Console.WriteLine(@"Регулярний вираз: ^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            }
        }

        public static void Task10_RegistrationForm()
        {
            Console.WriteLine("\n=== Завдання 10: Реєстраційна анкета ===");
            
            RegistrationForm form = new RegistrationForm();
            
            Console.Write("Ім'я: ");
            form.FirstName = Console.ReadLine() ?? "";
            
            Console.Write("Прізвище: ");
            form.LastName = Console.ReadLine() ?? "";
            
            Console.Write("Вік: ");
            form.Age = Console.ReadLine() ?? "";
            
            Console.Write("Email: ");
            form.Email = Console.ReadLine() ?? "";
            
            Console.Write("Домашня адреса: ");
            form.Address = Console.ReadLine() ?? "";
            
            Console.Write("Індекс: ");
            form.PostalCode = Console.ReadLine() ?? "";
            
            Console.Write("Номер телефону: ");
            form.PhoneNumber = Console.ReadLine() ?? "";
            
            Console.Write("Професія: ");
            form.Profession = Console.ReadLine() ?? "";
            
            Console.Write("Пароль: ");
            form.Password = Console.ReadLine() ?? "";

            var (isValid, errors) = ValidationService.ValidateRegistrationForm(form);
            
            if (isValid)
            {
                Console.WriteLine("\n✓ Всі дані валідні! Форма заповнена успішно.");
                
                // Збереження у файл
                Console.Write("Введіть шлях до файлу для збереження: ");
                string? filePath = Console.ReadLine();
                
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    try
                    {
                        StringBuilder content = new StringBuilder();
                        content.AppendLine("=== Реєстраційна анкета ===");
                        content.AppendLine($"Ім'я: {form.FirstName}");
                        content.AppendLine($"Прізвище: {form.LastName}");
                        content.AppendLine($"Вік: {form.Age}");
                        content.AppendLine($"Email: {form.Email}");
                        content.AppendLine($"Адреса: {form.Address}");
                        content.AppendLine($"Індекс: {form.PostalCode}");
                        content.AppendLine($"Телефон: {form.PhoneNumber}");
                        content.AppendLine($"Професія: {form.Profession}");
                        content.AppendLine($"Пароль: {new string('*', form.Password.Length)}");
                        content.AppendLine($"Дата реєстрації: {DateTime.Now}");

                        File.WriteAllText(filePath, content.ToString(), Encoding.UTF8);
                        Console.WriteLine($"Дані успішно збережено у файл '{filePath}'");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка при збереженні: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n✗ Знайдено помилки введення:");
                foreach (var error in errors)
                {
                    Console.WriteLine($"  - {error}");
                }
            }
        }
    }
}

