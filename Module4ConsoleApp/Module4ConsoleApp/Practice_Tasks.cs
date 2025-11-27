/*
 * МОДУЛЬ 4: ПРАКТИЧНІ ЗАВДАННЯ
 * Простори імен. Структури та перелічування. Nullable типи
 * 
 * Цей файл містить вирішення 6 практичних завдань
 */

using System;
using System.Collections.Generic;
using System.Linq;

// ============================================
// ЗАВДАННЯ 1: ГЕНЕРАТОРИ ЧИСЕЛ
// ============================================

namespace NumberGenerators
{
    // Генератор парних чисел
    public class EvenNumberGenerator
    {
        public static List<int> Generate(int count, int startFrom = 0)
        {
            List<int> numbers = new List<int>();
            int current = startFrom % 2 == 0 ? startFrom : startFrom + 1;
            
            for (int i = 0; i < count; i++)
            {
                numbers.Add(current);
                current += 2;
            }
            
            return numbers;
        }
    }

    // Генератор непарних чисел
    public class OddNumberGenerator
    {
        public static List<int> Generate(int count, int startFrom = 1)
        {
            List<int> numbers = new List<int>();
            int current = startFrom % 2 == 1 ? startFrom : startFrom + 1;
            
            for (int i = 0; i < count; i++)
            {
                numbers.Add(current);
                current += 2;
            }
            
            return numbers;
        }
    }

    // Генератор простих чисел
    public class PrimeNumberGenerator
    {
        // Перевірка, чи число просте
        private static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            
            return true;
        }

        public static List<int> Generate(int count)
        {
            List<int> primes = new List<int>();
            int number = 2;
            
            while (primes.Count < count)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
                number++;
            }
            
            return primes;
        }
    }

    // Генератор чисел Фібоначчі
    public class FibonacciGenerator
    {
        public static List<long> Generate(int count)
        {
            List<long> fibonacci = new List<long>();
            
            if (count <= 0) return fibonacci;
            
            if (count >= 1) fibonacci.Add(0);
            if (count >= 2) fibonacci.Add(1);
            
            for (int i = 2; i < count; i++)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
            }
            
            return fibonacci;
        }
    }
}

// ============================================
// ЗАВДАННЯ 2: ГЕОМЕТРИЧНІ ФІГУРИ
// ============================================

namespace Geometry.Shapes
{
    // Трикутник
    public class Triangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        // Периметр трикутника
        public double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        // Площа трикутника (формула Герона)
        public double GetArea()
        {
            double p = GetPerimeter() / 2; // Півпериметр
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public void Display()
        {
            Console.WriteLine($"Трикутник: сторони {SideA}, {SideB}, {SideC}");
            Console.WriteLine($"  Периметр: {GetPerimeter():F2}");
            Console.WriteLine($"  Площа: {GetArea():F2}");
        }
    }

    // Прямокутник
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Периметр прямокутника
        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        // Площа прямокутника
        public double GetArea()
        {
            return Width * Height;
        }

        public void Display()
        {
            Console.WriteLine($"Прямокутник: {Width} x {Height}");
            Console.WriteLine($"  Периметр: {GetPerimeter():F2}");
            Console.WriteLine($"  Площа: {GetArea():F2}");
        }
    }

    // Квадрат
    public class Square
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        // Периметр квадрата
        public double GetPerimeter()
        {
            return 4 * Side;
        }

        // Площа квадрата
        public double GetArea()
        {
            return Side * Side;
        }

        public void Display()
        {
            Console.WriteLine($"Квадрат: сторона {Side}");
            Console.WriteLine($"  Периметр: {GetPerimeter():F2}");
            Console.WriteLine($"  Площа: {GetArea():F2}");
        }
    }
}

// ============================================
// ЗАВДАННЯ 3: ГРА "ВГАДАЙ ЧИСЛО"
// ============================================

namespace Games
{
    public class GuessNumberGame
    {
        private int minValue;
        private int maxValue;
        private int secretNumber;
        private int attempts;

        public GuessNumberGame(int min, int max)
        {
            minValue = min;
            maxValue = max;
            attempts = 0;
        }

        // Користувач загадує число
        public void SetSecretNumber(int number)
        {
            if (number < minValue || number > maxValue)
            {
                throw new ArgumentException($"Число має бути в діапазоні [{minValue}, {maxValue}]");
            }
            secretNumber = number;
        }

        // Комп'ютер вгадує число (бінарний пошук)
        public int ComputerGuess()
        {
            int guess = (minValue + maxValue) / 2;
            attempts++;
            return guess;
        }

        // Перевірка, чи вгадав комп'ютер
        public string CheckGuess(int guess)
        {
            if (guess == secretNumber)
            {
                return "Вгадав!";
            }
            else if (guess < secretNumber)
            {
                minValue = guess + 1;
                return "Замало";
            }
            else
            {
                maxValue = guess - 1;
                return "Забагато";
            }
        }

        public int GetAttempts()
        {
            return attempts;
        }

        // Повна гра
        public void Play()
        {
            Console.WriteLine($"Загадайте число від {minValue} до {maxValue}");
            Console.Write("Введіть загадане число: ");
            int secret = int.Parse(Console.ReadLine() ?? "0");
            SetSecretNumber(secret);

            Console.WriteLine("\nКомп'ютер починає вгадувати...\n");

            while (true)
            {
                int guess = ComputerGuess();
                Console.WriteLine($"Спроба {attempts}: Комп'ютер вгадує {guess}");

                string result = CheckGuess(guess);
                Console.WriteLine($"Результат: {result}\n");

                if (result == "Вгадав!")
                {
                    Console.WriteLine($"Комп'ютер вгадав за {attempts} спроб!");
                    break;
                }
            }
        }
    }
}

// ============================================
// ЗАВДАННЯ 4: ГЕНЕРАТОР ПСЕВДОТЕКСТУ
// ============================================

namespace TextGeneration
{
    public class PseudotextGenerator
    {
        private string vowels = "аеиіоуяюєї";
        private string consonants = "бвгґджзклмнпрстфхцчшщ";

        public string Generate(int vowelCount, int consonantCount, int maxWordLength)
        {
            Random random = new Random();
            string text = "";
            int totalWords = (vowelCount + consonantCount) / 2; // Приблизна кількість слів

            for (int i = 0; i < totalWords; i++)
            {
                string word = GenerateWord(random, vowelCount, consonantCount, maxWordLength);
                text += word + " ";
            }

            return text.Trim();
        }

        private string GenerateWord(Random random, int vowelCount, int consonantCount, int maxLength)
        {
            string word = "";
            int length = random.Next(3, Math.Min(maxLength + 1, vowelCount + consonantCount + 1));
            int vowelsUsed = 0;
            int consonantsUsed = 0;

            for (int i = 0; i < length; i++)
            {
                bool useVowel = false;

                // Визначаємо, чи використовувати голосну
                if (vowelsUsed < vowelCount && consonantsUsed < consonantCount)
                {
                    useVowel = random.Next(2) == 0;
                }
                else if (vowelsUsed < vowelCount)
                {
                    useVowel = true;
                }

                if (useVowel && vowelsUsed < vowelCount)
                {
                    word += vowels[random.Next(vowels.Length)];
                    vowelsUsed++;
                }
                else if (consonantsUsed < consonantCount)
                {
                    word += consonants[random.Next(consonants.Length)];
                    consonantsUsed++;
                }
            }

            return word;
        }
    }
}

// ============================================
// ЗАВДАННЯ 5: МОДЕЛЮВАННЯ СКЛАДУ
// ============================================

namespace Warehouse
{
    // Перелічування категорій товарів
    public enum ItemCategory
    {
        Electronics,  // Електроніка
        Furniture,    // Меблі
        Food,         // Їжа
        Clothing,     // Одяг
        Books,        // Книги
        Tools         // Інструменти
    }

    // Структура предмета на складі
    public struct Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ItemCategory Category { get; set; }

        public Item(string name, int quantity, decimal price, ItemCategory category)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - Кількість: {Quantity}, Ціна: {Price:C}";
        }
    }

    // Клас для управління складом
    public class WarehouseManager
    {
        private List<Item> items;

        public WarehouseManager()
        {
            items = new List<Item>();
        }

        // Додавання предмета
        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"Додано: {item.Name}");
        }

        // Видалення предмета за назвою
        public bool RemoveItem(string name)
        {
            Item? itemToRemove = items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove.HasValue)
            {
                items.Remove(itemToRemove.Value);
                Console.WriteLine($"Видалено: {name}");
                return true;
            }
            Console.WriteLine($"Предмет '{name}' не знайдено");
            return false;
        }

        // Оновлення предмета
        public bool UpdateItem(string name, int? newQuantity = null, decimal? newPrice = null)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Item updatedItem = items[i];
                    
                    if (newQuantity.HasValue)
                        updatedItem.Quantity = newQuantity.Value;
                    
                    if (newPrice.HasValue)
                        updatedItem.Price = newPrice.Value;
                    
                    items[i] = updatedItem;
                    Console.WriteLine($"Оновлено: {name}");
                    return true;
                }
            }
            Console.WriteLine($"Предмет '{name}' не знайдено");
            return false;
        }

        // Виведення всіх предметів
        public void DisplayAllItems()
        {
            Console.WriteLine("\n=== СКЛАД ===");
            if (items.Count == 0)
            {
                Console.WriteLine("Склад порожній");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        // Пошук предметів за категорією
        public void DisplayItemsByCategory(ItemCategory category)
        {
            Console.WriteLine($"\n=== ПРЕДМЕТИ КАТЕГОРІЇ: {category} ===");
            var categoryItems = items.Where(i => i.Category == category);
            
            if (!categoryItems.Any())
            {
                Console.WriteLine("Предметів не знайдено");
                return;
            }

            foreach (var item in categoryItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}

// ============================================
// ЗАВДАННЯ 6: СТРУКТУРА EMPLOYEE З NULLABLE
// ============================================

namespace Company
{
    // Структура співробітника з Nullable полями
    public struct Employee
    {
        public string Name { get; set; }
        public int? Age { get; set; }        // Nullable - може бути невідомим
        public decimal? Salary { get; set; } // Nullable - може бути невідомим

        public Employee(string name, int? age = null, decimal? salary = null)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        // Метод для виведення інформації з перевіркою на null
        public void DisplayInfo()
        {
            Console.WriteLine($"=== ІНФОРМАЦІЯ ПРО СПІВРОБІТНИКА ===");
            Console.WriteLine($"Ім'я: {Name}");
            
            // Перевірка віку
            if (Age.HasValue)
            {
                Console.WriteLine($"Вік: {Age.Value} років");
            }
            else
            {
                Console.WriteLine("Вік: не вказано");
            }

            // Перевірка зарплати
            if (Salary.HasValue)
            {
                Console.WriteLine($"Зарплата: {Salary.Value:C}");
            }
            else
            {
                Console.WriteLine("Зарплата: не вказано");
            }
            Console.WriteLine();
        }

        // Метод для отримання інформації у вигляді рядка
        public string GetInfoString()
        {
            string info = $"Ім'я: {Name}";
            
            if (Age.HasValue)
                info += $", Вік: {Age.Value}";
            else
                info += ", Вік: не вказано";
            
            if (Salary.HasValue)
                info += $", Зарплата: {Salary.Value:C}";
            else
                info += ", Зарплата: не вказано";
            
            return info;
        }
    }
}

// ============================================
// ДЕМОНСТРАЦІЯ ВСІХ ЗАВДАНЬ
// ============================================

namespace PracticeDemo
{
    public class PracticeTasksDemo
    {
        public static void RunAllTasks()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   МОДУЛЬ 4: ПРАКТИЧНІ ЗАВДАННЯ - ДЕМОНСТРАЦІЯ         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

            // Завдання 1: Генератори чисел
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 1: ГЕНЕРАТОРИ ЧИСЕЛ");
            Console.WriteLine("════════════════════════════════════════════════════════\n");

            Console.WriteLine("Парні числа (10 чисел, починаючи з 0):");
            var evenNumbers = NumberGenerators.EvenNumberGenerator.Generate(10);
            Console.WriteLine(string.Join(", ", evenNumbers));

            Console.WriteLine("\nНепарні числа (10 чисел, починаючи з 1):");
            var oddNumbers = NumberGenerators.OddNumberGenerator.Generate(10);
            Console.WriteLine(string.Join(", ", oddNumbers));

            Console.WriteLine("\nПрості числа (10 перших):");
            var primeNumbers = NumberGenerators.PrimeNumberGenerator.Generate(10);
            Console.WriteLine(string.Join(", ", primeNumbers));

            Console.WriteLine("\nЧисла Фібоначчі (10 перших):");
            var fibonacci = NumberGenerators.FibonacciGenerator.Generate(10);
            Console.WriteLine(string.Join(", ", fibonacci));

            Console.WriteLine("\n\n");

            // Завдання 2: Геометричні фігури
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 2: ГЕОМЕТРИЧНІ ФІГУРИ");
            Console.WriteLine("════════════════════════════════════════════════════════\n");

            var triangle = new Geometry.Shapes.Triangle(3, 4, 5);
            triangle.Display();

            Console.WriteLine();

            var rectangle = new Geometry.Shapes.Rectangle(5, 8);
            rectangle.Display();

            Console.WriteLine();

            var square = new Geometry.Shapes.Square(6);
            square.Display();

            Console.WriteLine("\n\n");

            // Завдання 3: Гра "Вгадай число"
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 3: ГРА 'ВГАДАЙ ЧИСЛО'");
            Console.WriteLine("════════════════════════════════════════════════════════\n");
            Console.WriteLine("(Для демонстрації використовується число 42)\n");

            var game = new Games.GuessNumberGame(1, 100);
            game.SetSecretNumber(42);

            while (true)
            {
                int guess = game.ComputerGuess();
                string result = game.CheckGuess(guess);
                Console.WriteLine($"Спроба {game.GetAttempts()}: Комп'ютер вгадує {guess} - {result}");

                if (result == "Вгадав!")
                {
                    Console.WriteLine($"\nКомп'ютер вгадав за {game.GetAttempts()} спроб!\n");
                    break;
                }
            }

            Console.WriteLine("\n\n");

            // Завдання 4: Генератор псевдотексту
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 4: ГЕНЕРАТОР ПСЕВДОТЕКСТУ");
            Console.WriteLine("════════════════════════════════════════════════════════\n");

            var textGenerator = new TextGeneration.PseudotextGenerator();
            string generatedText = textGenerator.Generate(10, 15, 6);
            Console.WriteLine($"Згенерований текст:");
            Console.WriteLine(generatedText);
            Console.WriteLine("\n\n");

            // Завдання 5: Склад
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 5: МОДЕЛЮВАННЯ СКЛАДУ");
            Console.WriteLine("════════════════════════════════════════════════════════\n");

            var warehouse = new Warehouse.WarehouseManager();

            // Додаємо предмети
            warehouse.AddItem(new Warehouse.Item("Ноутбук", 5, 25000, Warehouse.ItemCategory.Electronics));
            warehouse.AddItem(new Warehouse.Item("Стіл", 10, 3500, Warehouse.ItemCategory.Furniture));
            warehouse.AddItem(new Warehouse.Item("Хліб", 50, 25, Warehouse.ItemCategory.Food));
            warehouse.AddItem(new Warehouse.Item("Смартфон", 8, 15000, Warehouse.ItemCategory.Electronics));
            warehouse.AddItem(new Warehouse.Item("Крісло", 7, 2800, Warehouse.ItemCategory.Furniture));

            Console.WriteLine();
            warehouse.DisplayAllItems();

            // Оновлюємо предмет
            warehouse.UpdateItem("Хліб", newQuantity: 60, newPrice: 30);
            Console.WriteLine();

            // Виводимо предмети категорії
            warehouse.DisplayItemsByCategory(Warehouse.ItemCategory.Electronics);

            Console.WriteLine("\n\n");

            // Завдання 6: Employee з Nullable
            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 6: СТРУКТУРА EMPLOYEE З NULLABLE");
            Console.WriteLine("════════════════════════════════════════════════════════\n");

            // Співробітник з повною інформацією
            Company.Employee employee1 = new Company.Employee("Іван Петренко", 30, 25000);
            employee1.DisplayInfo();

            // Співробітник без віку
            Company.Employee employee2 = new Company.Employee("Марія Коваленко", null, 30000);
            employee2.DisplayInfo();

            // Співробітник без зарплати
            Company.Employee employee3 = new Company.Employee("Олександр Сидоренко", 25, null);
            employee3.DisplayInfo();

            // Співробітник без віку та зарплати
            Company.Employee employee4 = new Company.Employee("Олена Мельник");
            employee4.DisplayInfo();

            Console.WriteLine("════════════════════════════════════════════════════════");
            Console.WriteLine("ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА");
            Console.WriteLine("════════════════════════════════════════════════════════");
        }
    }
}

