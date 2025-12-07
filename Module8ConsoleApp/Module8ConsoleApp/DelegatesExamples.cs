using System;
using System.Collections.Generic;
using System.Linq;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: ДЕЛЕГАТИ
    // ============================================

    // Кейс 1: Система обробки замовлень з різними стратегіями розрахунку знижки
    public class OrderProcessor
    {
        // Делегат для розрахунку знижки
        public delegate decimal DiscountCalculator(decimal amount);

        // Різні стратегії розрахунку знижки
        public static decimal NoDiscount(decimal amount) => amount;
        
        public static decimal FixedDiscount(decimal amount)
        {
            return amount > 1000 ? amount * 0.9m : amount; // 10% знижка для замовлень > 1000
        }
        
        public static decimal PercentageDiscount(decimal amount)
        {
            return amount * 0.85m; // 15% знижка для всіх
        }
        
        public static decimal TieredDiscount(decimal amount)
        {
            if (amount > 5000) return amount * 0.8m;  // 20% для великих замовлень
            if (amount > 2000) return amount * 0.85m;  // 15% для середніх
            if (amount > 1000) return amount * 0.9m;   // 10% для малих
            return amount;
        }

        public decimal ProcessOrder(decimal originalAmount, DiscountCalculator calculator)
        {
            decimal discountedAmount = calculator(originalAmount);
            Console.WriteLine($"Оригінальна сума: {originalAmount:C}");
            Console.WriteLine($"Сума зі знижкою: {discountedAmount:C}");
            Console.WriteLine($"Економія: {originalAmount - discountedAmount:C}");
            return discountedAmount;
        }
    }

    // Кейс 2: Система логування з різними обробниками
    public class Logger
    {
        public delegate void LogHandler(string message, LogLevel level);

        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        private List<LogHandler> _handlers = new List<LogHandler>();

        public void AddHandler(LogHandler handler)
        {
            _handlers.Add(handler);
        }

        public void Log(string message, LogLevel level)
        {
            foreach (var handler in _handlers)
            {
                handler(message, level);
            }
        }
    }

    // Різні обробники логів
    public static class LogHandlers
    {
        public static void ConsoleLogger(string message, Logger.LogLevel level)
        {
            ConsoleColor color = level switch
            {
                Logger.LogLevel.Info => ConsoleColor.Green,
                Logger.LogLevel.Warning => ConsoleColor.Yellow,
                Logger.LogLevel.Error => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
            
            Console.ForegroundColor = color;
            Console.WriteLine($"[{level}] {DateTime.Now:HH:mm:ss} - {message}");
            Console.ResetColor();
        }

        public static void FileLogger(string message, Logger.LogLevel level)
        {
            // Симуляція запису в файл
            Console.WriteLine($"[FILE] [{level}] {message}");
        }

        public static void DatabaseLogger(string message, Logger.LogLevel level)
        {
            // Симуляція запису в БД
            Console.WriteLine($"[DB] [{level}] {message}");
        }
    }

    // Кейс 3: Система валідації з множинними перевірками
    public class UserValidator
    {
        public delegate bool ValidationRule(string value);

        private List<ValidationRule> _rules = new List<ValidationRule>();

        public void AddRule(ValidationRule rule)
        {
            _rules.Add(rule);
        }

        public bool Validate(string value)
        {
            foreach (var rule in _rules)
            {
                if (!rule(value))
                {
                    return false;
                }
            }
            return true;
        }
    }

    // Правила валідації
    public static class ValidationRules
    {
        public static bool NotEmpty(string value) => !string.IsNullOrWhiteSpace(value);
        
        public static bool MinLength(string value) => value.Length >= 6;
        
        public static bool ContainsDigit(string value) => value.Any(char.IsDigit);
        
        public static bool ContainsLetter(string value) => value.Any(char.IsLetter);
        
        public static bool ContainsSpecialChar(string value) => value.Any(ch => "!@#$%^&*".Contains(ch));
    }

    // Кейс 4: Система обробки даних з різними фільтрами та трансформаціями
    public class DataProcessor
    {
        public delegate bool Filter<T>(T item);
        public delegate T Transform<T>(T item);

        public List<T> ProcessData<T>(List<T> data, Filter<T> filter, Transform<T> transform)
        {
            return data
                .Where(item => filter(item))
                .Select(item => transform(item))
                .ToList();
        }
    }

    // Кейс 5: Система сортування з кастомними компараторами
    public class ProductSorter
    {
        public delegate int CompareProducts(Product p1, Product p2);

        public void SortProducts(List<Product> products, CompareProducts comparer)
        {
            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = i + 1; j < products.Count; j++)
                {
                    if (comparer(products[i], products[j]) > 0)
                    {
                        var temp = products[i];
                        products[i] = products[j];
                        products[j] = temp;
                    }
                }
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString() => $"{Name} - {Price:C} (Склад: {Stock})";
    }

    // Кейс 6: Multicasting - система сповіщень
    public class NotificationService
    {
        public delegate void NotificationHandler(string message);

        private NotificationHandler _handlers;

        public void Subscribe(NotificationHandler handler)
        {
            _handlers += handler;
        }

        public void Unsubscribe(NotificationHandler handler)
        {
            _handlers -= handler;
        }

        public void SendNotification(string message)
        {
            Console.WriteLine("Відправка сповіщень...");
            _handlers?.Invoke(message);
        }
    }

    // Різні обробники сповіщень
    public static class NotificationHandlers
    {
        public static void EmailNotification(string message)
        {
            Console.WriteLine($"[EMAIL] Відправлено на email: {message}");
        }

        public static void SmsNotification(string message)
        {
            Console.WriteLine($"[SMS] Відправлено SMS: {message}");
        }

        public static void PushNotification(string message)
        {
            Console.WriteLine($"[PUSH] Push-сповіщення: {message}");
        }
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class DelegatesExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: ДЕЛЕГАТИ");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: Обробка замовлень
            Console.WriteLine("КЕЙС 1: Система обробки замовлень з різними стратегіями знижки");
            Console.WriteLine("-".PadRight(60, '-'));
            var processor = new OrderProcessor();
            
            decimal orderAmount = 2500m;
            Console.WriteLine($"\nЗамовлення на суму: {orderAmount:C}");
            
            Console.WriteLine("\n1. Без знижки:");
            processor.ProcessOrder(orderAmount, OrderProcessor.NoDiscount);
            
            Console.WriteLine("\n2. Фіксована знижка (>1000):");
            processor.ProcessOrder(orderAmount, OrderProcessor.FixedDiscount);
            
            Console.WriteLine("\n3. Відсоткова знижка (15%):");
            processor.ProcessOrder(orderAmount, OrderProcessor.PercentageDiscount);
            
            Console.WriteLine("\n4. Багаторівнева знижка:");
            processor.ProcessOrder(orderAmount, OrderProcessor.TieredDiscount);

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Система логування
            Console.WriteLine("КЕЙС 2: Система логування з множинними обробниками");
            Console.WriteLine("-".PadRight(60, '-'));
            var logger = new Logger();
            
            logger.AddHandler(LogHandlers.ConsoleLogger);
            logger.AddHandler(LogHandlers.FileLogger);
            logger.AddHandler(LogHandlers.DatabaseLogger);
            
            logger.Log("Система запущена", Logger.LogLevel.Info);
            logger.Log("Попередження: низький рівень пам'яті", Logger.LogLevel.Warning);
            logger.Log("Помилка: не вдалося підключитися до БД", Logger.LogLevel.Error);

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: Валідація
            Console.WriteLine("КЕЙС 3: Система валідації з множинними правилами");
            Console.WriteLine("-".PadRight(60, '-'));
            var validator = new UserValidator();
            
            validator.AddRule(ValidationRules.NotEmpty);
            validator.AddRule(ValidationRules.MinLength);
            validator.AddRule(ValidationRules.ContainsDigit);
            validator.AddRule(ValidationRules.ContainsLetter);
            validator.AddRule(ValidationRules.ContainsSpecialChar);
            
            string[] passwords = { "123", "password", "Pass123", "Pass123!" };
            
            foreach (var password in passwords)
            {
                bool isValid = validator.Validate(password);
                Console.WriteLine($"Пароль '{password}': {(isValid ? "✓ Валідний" : "✗ Невалідний")}");
            }

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: Обробка даних
            Console.WriteLine("КЕЙС 4: Система обробки даних з фільтрами та трансформаціями");
            Console.WriteLine("-".PadRight(60, '-'));
            var dataProcessor = new DataProcessor();
            
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Початкові дані: {string.Join(", ", numbers)}");
            
            // Фільтр: тільки парні числа
            DataProcessor.Filter<int> evenFilter = n => n % 2 == 0;
            // Трансформація: квадрат числа
            DataProcessor.Transform<int> squareTransform = n => n * n;
            
            var result = dataProcessor.ProcessData(numbers, evenFilter, squareTransform);
            Console.WriteLine($"Результат (парні числа в квадраті): {string.Join(", ", result)}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Сортування
            Console.WriteLine("КЕЙС 5: Система сортування з кастомними компараторами");
            Console.WriteLine("-".PadRight(60, '-'));
            var sorter = new ProductSorter();
            
            List<Product> products = new List<Product>
            {
                new Product { Name = "Ноутбук", Price = 25000, Stock = 5 },
                new Product { Name = "Мишка", Price = 500, Stock = 20 },
                new Product { Name = "Клавіатура", Price = 1200, Stock = 15 },
                new Product { Name = "Монітор", Price = 8000, Stock = 8 }
            };
            
            Console.WriteLine("\nПочатковий список:");
            products.ForEach(p => Console.WriteLine($"  {p}"));
            
            // Сортування за ціною
            Console.WriteLine("\nСортування за ціною (від дешевшого):");
            sorter.SortProducts(products, (p1, p2) => p1.Price.CompareTo(p2.Price));
            products.ForEach(p => Console.WriteLine($"  {p}"));
            
            // Сортування за кількістю на складі
            Console.WriteLine("\nСортування за кількістю на складі (від більшого):");
            sorter.SortProducts(products, (p1, p2) => p2.Stock.CompareTo(p1.Stock));
            products.ForEach(p => Console.WriteLine($"  {p}"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 6: Multicasting - сповіщення
            Console.WriteLine("КЕЙС 6: Multicasting - система сповіщень");
            Console.WriteLine("-".PadRight(60, '-'));
            var notificationService = new NotificationService();
            
            notificationService.Subscribe(NotificationHandlers.EmailNotification);
            notificationService.Subscribe(NotificationHandlers.SmsNotification);
            notificationService.Subscribe(NotificationHandlers.PushNotification);
            
            Console.WriteLine("\nВідправка сповіщення (всі канали):");
            notificationService.SendNotification("Ваше замовлення готове до отримання!");
            
            Console.WriteLine("\nВідписка від SMS:");
            notificationService.Unsubscribe(NotificationHandlers.SmsNotification);
            
            Console.WriteLine("\nВідправка сповіщення (без SMS):");
            notificationService.SendNotification("Нове повідомлення в системі");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }
}

