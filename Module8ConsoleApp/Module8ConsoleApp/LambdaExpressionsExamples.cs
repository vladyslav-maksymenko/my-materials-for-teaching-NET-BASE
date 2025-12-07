using System;
using System.Collections.Generic;
using System.Linq;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: ЛЯМБДА-ВИРАЗИ
    // ============================================

    // Кейс 1: LINQ з лямбда-виразами
    public class LinqExamples
    {
        public static void DemonstrateLinq()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var people = new List<Person>
            {
                new Person("Іван", "Петренко", 25),
                new Person("Марія", "Іваненко", 30),
                new Person("Петро", "Сидоренко", 22),
                new Person("Олена", "Коваленко", 28),
                new Person("Андрій", "Мельник", 35)
            };

            // Where - фільтрація
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            var adults = people.Where(p => p.Age >= 18);

            // Select - проекція
            var squares = numbers.Select(n => n * n);
            var fullNames = people.Select(p => $"{p.FirstName} {p.LastName}");

            // OrderBy - сортування
            var sortedByAge = people.OrderBy(p => p.Age);
            var sortedByName = people.OrderByDescending(p => p.LastName);

            // First/Last - перший/останній елемент
            var firstEven = numbers.First(n => n % 2 == 0);
            var lastPerson = people.Last();

            // Any/All - перевірка умов
            var hasEvens = numbers.Any(n => n % 2 == 0);
            var allAdults = people.All(p => p.Age >= 18);

            // Count - підрахунок
            var evenCount = numbers.Count(n => n > 5);
            var youngCount = people.Count(p => p.Age < 30);

            // Sum/Average/Max/Min - агрегація
            var sum = numbers.Sum();
            var avgAge = people.Average(p => p.Age);
            var maxAge = people.Max(p => p.Age);
            var minAge = people.Min(p => p.Age);

            // GroupBy - групування
            var byAgeGroup = people.GroupBy(p => p.Age / 10 * 10);

            // SelectMany - розгортання колекцій
            var allNumbers = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };
            var flattened = allNumbers.SelectMany(list => list);
        }
    }

    // Кейс 2: Обробка колекцій з лямбда-виразами
    public class CollectionProcessor
    {
        public static void ProcessCollections()
        {
            var products = new List<Product>
            {
                new Product { Name = "Ноутбук", Price = 25000, Stock = 5 },
                new Product { Name = "Мишка", Price = 500, Stock = 20 },
                new Product { Name = "Клавіатура", Price = 1200, Stock = 15 },
                new Product { Name = "Монітор", Price = 8000, Stock = 8 }
            };

            // Find - знайти елемент
            var expensive = products.Find(p => p.Price > 10000);

            // FindAll - знайти всі елементи
            var inStock = products.FindAll(p => p.Stock > 10);

            // ForEach - виконати дію для кожного
            products.ForEach(p => Console.WriteLine($"{p.Name}: {p.Price:C}"));

            // RemoveAll - видалити за умовою
            products.RemoveAll(p => p.Stock == 0);

            // Sort - сортування
            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
        }
    }

    // Кейс 3: Асинхронні операції з лямбда-виразами
    public class AsyncExamples
    {
        public static void DemonstrateAsync()
        {
            // Task.Run з лямбда-виразом
            var task = System.Threading.Tasks.Task.Run(() =>
            {
                Console.WriteLine("Виконується асинхронна операція...");
                System.Threading.Thread.Sleep(1000);
                return "Результат";
            });

            // ContinueWith з лямбда-виразом
            task.ContinueWith(t =>
            {
                Console.WriteLine($"Отримано результат: {t.Result}");
            });
        }
    }

    // Кейс 4: Події з лямбда-виразами
    public class EventExamples
    {
        public class Button
        {
            public event EventHandler Clicked;

            public void Click()
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public static void DemonstrateEvents()
        {
            var button = new Button();

            // Підписка з лямбда-виразом
            button.Clicked += (sender, e) =>
            {
                Console.WriteLine("Кнопка натиснута!");
            };

            button.Click();
        }
    }

    // Кейс 5: Функціональне програмування
    public class FunctionalExamples
    {
        // Композиція функцій
        public static Func<T, R> Compose<T, M, R>(Func<T, M> f, Func<M, R> g)
        {
            return x => g(f(x));
        }

        // Часткове застосування
        public static Func<int, int> MultiplyBy(int factor)
        {
            return x => x * factor;
        }

        // Каррінг
        public static Func<int, Func<int, int>> CurriedAdd()
        {
            return x => y => x + y;
        }

        public static void DemonstrateFunctional()
        {
            // Композиція
            Func<int, int> square = x => x * x;
            Func<int, int> addOne = x => x + 1;
            var squareThenAdd = Compose(square, addOne);
            Console.WriteLine(squareThenAdd(5)); // (5*5)+1 = 26

            // Часткове застосування
            var multiplyBy10 = MultiplyBy(10);
            Console.WriteLine(multiplyBy10(5)); // 50

            // Каррінг
            var add = CurriedAdd();
            var add5 = add(5);
            Console.WriteLine(add5(3)); // 8
        }
    }

    // Кейс 6: Захоплення змінних (Closure)
    public class ClosureExamples
    {
        public static void DemonstrateClosures()
        {
            // Захоплення змінної
            int multiplier = 10;
            Func<int, int> multiply = x => x * multiplier;

            Console.WriteLine(multiply(5)); // 50

            // Зміна захопленої змінної
            multiplier = 20;
            Console.WriteLine(multiply(5)); // 100 (змінилося!)

            // Проблема з циклом
            var actions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                // Неправильно - всі захоплюють одну змінну i
                actions.Add(() => Console.WriteLine(i)); // Виведе 3, 3, 3
            }

            // Правильно - створюємо локальну копію
            var correctActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int localI = i; // Локальна копія
                correctActions.Add(() => Console.WriteLine(localI)); // Виведе 0, 1, 2
            }
        }
    }

    // Кейс 7: Практичні приклади з реальних сценаріїв
    public class RealWorldExamples
    {
        // Фільтрація та сортування користувачів
        public static void FilterAndSortUsers()
        {
            var users = new List<User>
            {
                new User { Name = "Іван", Email = "ivan@example.com", IsActive = true, LastLogin = DateTime.Now.AddDays(-5) },
                new User { Name = "Марія", Email = "maria@example.com", IsActive = true, LastLogin = DateTime.Now.AddDays(-1) },
                new User { Name = "Петро", Email = "petro@example.com", IsActive = false, LastLogin = DateTime.Now.AddDays(-30) },
                new User { Name = "Олена", Email = "olena@example.com", IsActive = true, LastLogin = DateTime.Now.AddDays(-10) }
            };

            // Активні користувачі, які заходили за останні 7 днів
            var activeRecentUsers = users
                .Where(u => u.IsActive && (DateTime.Now - u.LastLogin).Days <= 7)
                .OrderByDescending(u => u.LastLogin)
                .Select(u => u.Email)
                .ToList();

            // Групування за активністю
            var groupedByActivity = users
                .GroupBy(u => u.IsActive ? "Активні" : "Неактивні")
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();
        }

        // Обчислення статистики
        public static void CalculateStatistics()
        {
            var sales = new List<Sale>
            {
                new Sale { Product = "Ноутбук", Amount = 25000, Date = DateTime.Now.AddDays(-5) },
                new Sale { Product = "Мишка", Amount = 500, Date = DateTime.Now.AddDays(-3) },
                new Sale { Product = "Клавіатура", Amount = 1200, Date = DateTime.Now.AddDays(-1) },
                new Sale { Product = "Ноутбук", Amount = 25000, Date = DateTime.Now.AddDays(-2) }
            };

            // Загальна сума продажів
            var total = sales.Sum(s => s.Amount);

            // Середня сума продажу
            var average = sales.Average(s => s.Amount);

            // Продажі за останні 7 днів
            var recentSales = sales
                .Where(s => (DateTime.Now - s.Date).Days <= 7)
                .Sum(s => s.Amount);

            // Топ-3 товари за сумою
            var topProducts = sales
                .GroupBy(s => s.Product)
                .Select(g => new { Product = g.Key, Total = g.Sum(s => s.Amount) })
                .OrderByDescending(x => x.Total)
                .Take(3)
                .ToList();
        }

        // Валідація та трансформація даних
        public static void ValidateAndTransform()
        {
            var rawData = new List<string> { "123", "456", "abc", "789", "def" };

            // Валідація (тільки числа) та трансформація
            var numbers = rawData
                .Where(s => int.TryParse(s, out _))
                .Select(s => int.Parse(s))
                .Where(n => n > 100)
                .OrderBy(n => n)
                .ToList();

            // Або з TryParse в Select
            var validNumbers = rawData
                .Select(s => new { Value = s, Number = int.TryParse(s, out int n) ? (int?)n : null })
                .Where(x => x.Number.HasValue)
                .Select(x => x.Number.Value)
                .ToList();
        }
    }

    // ============================================
    // ДОПОМІЖНІ КЛАСИ
    // ============================================
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }

    public class Sale
    {
        public string Product { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class LambdaExpressionsExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: ЛЯМБДА-ВИРАЗИ");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: LINQ
            Console.WriteLine("КЕЙС 1: LINQ з лямбда-виразами");
            Console.WriteLine("-".PadRight(60, '-'));
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var people = new List<Person>
            {
                new Person("Іван", "Петренко", 25),
                new Person("Марія", "Іваненко", 30),
                new Person("Петро", "Сидоренко", 22),
                new Person("Олена", "Коваленко", 28)
            };

            Console.WriteLine($"Числа: {string.Join(", ", numbers)}");
            Console.WriteLine($"Парні числа: {string.Join(", ", numbers.Where(n => n % 2 == 0))}");
            Console.WriteLine($"Квадрати: {string.Join(", ", numbers.Select(n => n * n))}");
            Console.WriteLine($"Сума: {numbers.Sum()}");
            Console.WriteLine($"Середнє: {numbers.Average():F2}");

            Console.WriteLine("\nЛюди:");
            people.ForEach(p => Console.WriteLine($"  {p.FirstName} {p.LastName}, {p.Age} років"));

            var adults = people.Where(p => p.Age >= 25).OrderBy(p => p.Age);
            Console.WriteLine("\nДорослі (≥25 років), відсортовані за віком:");
            adults.ToList().ForEach(p => Console.WriteLine($"  {p.FirstName} {p.LastName}, {p.Age} років"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Обробка колекцій
            Console.WriteLine("КЕЙС 2: Обробка колекцій з лямбда-виразами");
            Console.WriteLine("-".PadRight(60, '-'));
            var products = new List<Product>
            {
                new Product { Name = "Ноутбук", Price = 25000, Stock = 5 },
                new Product { Name = "Мишка", Price = 500, Stock = 20 },
                new Product { Name = "Клавіатура", Price = 1200, Stock = 15 },
                new Product { Name = "Монітор", Price = 8000, Stock = 8 }
            };

            Console.WriteLine("Всі товари:");
            products.ForEach(p => Console.WriteLine($"  {p.Name}: {p.Price:C}, Склад: {p.Stock}"));

            var expensive = products.Find(p => p.Price > 10000);
            Console.WriteLine($"\nДорогий товар (>10000): {expensive?.Name}");

            var inStock = products.FindAll(p => p.Stock > 10);
            Console.WriteLine($"\nТовари на складі (>10):");
            inStock.ForEach(p => Console.WriteLine($"  {p.Name}: {p.Stock}"));

            products.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            Console.WriteLine("\nВідсортовано за ціною:");
            products.ForEach(p => Console.WriteLine($"  {p.Name}: {p.Price:C}"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: Захоплення змінних
            Console.WriteLine("КЕЙС 3: Захоплення змінних (Closure)");
            Console.WriteLine("-".PadRight(60, '-'));
            int multiplier = 10;
            Func<int, int> multiply = x => x * multiplier;

            Console.WriteLine($"multiplier = {multiplier}");
            Console.WriteLine($"multiply(5) = {multiply(5)}");

            multiplier = 20;
            Console.WriteLine($"\nmultiplier = {multiplier} (змінено)");
            Console.WriteLine($"multiply(5) = {multiply(5)} (змінилося!)");

            Console.WriteLine("\nПроблема з циклом:");
            var wrongActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                wrongActions.Add(() => Console.WriteLine($"  Неправильно: {i}")); // Всі виведуть 3
            }
            wrongActions.ForEach(a => a());

            Console.WriteLine("\nПравильне рішення:");
            var correctActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int localI = i; // Локальна копія
                correctActions.Add(() => Console.WriteLine($"  Правильно: {localI}"));
            }
            correctActions.ForEach(a => a());

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: Функціональне програмування
            Console.WriteLine("КЕЙС 4: Функціональне програмування");
            Console.WriteLine("-".PadRight(60, '-'));
            
            // Композиція
            Func<int, int> square = x => x * x;
            Func<int, int> addOne = x => x + 1;
            Func<int, int> squareThenAdd = x => addOne(square(x));
            Console.WriteLine($"squareThenAdd(5) = {squareThenAdd(5)}"); // (5*5)+1 = 26

            // Часткове застосування
            Func<int, Func<int, int>> multiplyBy = factor => x => x * factor;
            var multiplyBy10 = multiplyBy(10);
            Console.WriteLine($"multiplyBy10(5) = {multiplyBy10(5)}"); // 50

            // Каррінг
            Func<int, Func<int, int>> curriedAdd = x => y => x + y;
            var add5 = curriedAdd(5);
            Console.WriteLine($"add5(3) = {add5(3)}"); // 8

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Реальні сценарії
            Console.WriteLine("КЕЙС 5: Реальні сценарії використання");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var sales = new List<Sale>
            {
                new Sale { Product = "Ноутбук", Amount = 25000, Date = DateTime.Now.AddDays(-5) },
                new Sale { Product = "Мишка", Amount = 500, Date = DateTime.Now.AddDays(-3) },
                new Sale { Product = "Клавіатура", Amount = 1200, Date = DateTime.Now.AddDays(-1) },
                new Sale { Product = "Ноутбук", Amount = 25000, Date = DateTime.Now.AddDays(-2) }
            };

            var total = sales.Sum(s => s.Amount);
            Console.WriteLine($"Загальна сума продажів: {total:C}");

            var avg = sales.Average(s => s.Amount);
            Console.WriteLine($"Середня сума продажу: {avg:C}");

            var topProducts = sales
                .GroupBy(s => s.Product)
                .Select(g => new { Product = g.Key, Total = g.Sum(s => s.Amount) })
                .OrderByDescending(x => x.Total)
                .Take(3);

            Console.WriteLine("\nТоп-3 товари:");
            topProducts.ToList().ForEach(p => Console.WriteLine($"  {p.Product}: {p.Total:C}"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }
}

