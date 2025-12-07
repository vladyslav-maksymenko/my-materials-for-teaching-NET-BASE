using System;
using System.Collections.Generic;
using System.Linq;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: АНОНІМНІ МЕТОДИ
    // ============================================

    // Кейс 1: Система обробки даних з анонімними методами
    public class DataProcessor
    {
        public delegate bool FilterDelegate<T>(T item);
        public delegate T TransformDelegate<T>(T item);

        public List<T> ProcessData<T>(List<T> data, FilterDelegate<T> filter, TransformDelegate<T> transform)
        {
            var result = new List<T>();
            foreach (var item in data)
            {
                if (filter(item))
                {
                    result.Add(transform(item));
                }
            }
            return result;
        }
    }

    // Кейс 2: Система таймерів з анонімними обробниками
    public class SimpleTimer
    {
        public delegate void TimerCallback();

        private TimerCallback _callback;
        private int _interval;
        private int _currentTick = 0;

        public SimpleTimer(int interval, TimerCallback callback)
        {
            _interval = interval;
            _callback = callback;
        }

        public void Tick()
        {
            _currentTick++;
            if (_currentTick >= _interval)
            {
                _callback?.Invoke();
                _currentTick = 0;
            }
        }
    }

    // Кейс 3: Система сортування з анонімними компараторами
    public class CustomSorter
    {
        public delegate int CompareDelegate<T>(T x, T y);

        public void Sort<T>(List<T> list, CompareDelegate<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (comparer(list[i], list[j]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }

    // Кейс 4: Система валідації з анонімними правилами
    public class Validator
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

    // Кейс 5: Система обробки подій з анонімними обробниками
    public class EventPublisher
    {
        public delegate void EventHandler(string message);

        public event EventHandler MessageReceived;

        public void PublishMessage(string message)
        {
            MessageReceived?.Invoke(message);
        }
    }

    // Кейс 6: Система обчислень з анонімними функціями
    public class Calculator
    {
        public delegate decimal CalculationDelegate(decimal a, decimal b);

        public decimal Calculate(decimal a, decimal b, CalculationDelegate operation)
        {
            return operation(a, b);
        }
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class AnonymousMethodsExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: АНОНІМНІ МЕТОДИ");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: Обробка даних
            Console.WriteLine("КЕЙС 1: Система обробки даних з анонімними методами");
            Console.WriteLine("-".PadRight(60, '-'));
            var processor = new DataProcessor();
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"Початкові дані: {string.Join(", ", numbers)}");

            // Анонімний метод для фільтрації (тільки парні числа)
            DataProcessor.FilterDelegate<int> evenFilter = delegate(int n)
            {
                return n % 2 == 0;
            };

            // Анонімний метод для трансформації (квадрат числа)
            DataProcessor.TransformDelegate<int> squareTransform = delegate(int n)
            {
                return n * n;
            };

            var result = processor.ProcessData(numbers, evenFilter, squareTransform);
            Console.WriteLine($"Результат (парні числа в квадраті): {string.Join(", ", result)}");

            // Використання зовнішньої змінної
            int multiplier = 3;
            DataProcessor.TransformDelegate<int> multiplyTransform = delegate(int n)
            {
                return n * multiplier; // Захоплення зовнішньої змінної
            };

            var multiplied = processor.ProcessData(numbers, evenFilter, multiplyTransform);
            Console.WriteLine($"Результат (парні числа × {multiplier}): {string.Join(", ", multiplied)}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Таймери
            Console.WriteLine("КЕЙС 2: Система таймерів з анонімними обробниками");
            Console.WriteLine("-".PadRight(60, '-'));
            int counter = 0;

            // Анонімний метод для обробки таймера
            SimpleTimer.TimerCallback timerCallback = delegate()
            {
                counter++;
                Console.WriteLine($"Таймер спрацював! Лічильник: {counter}");
            };

            var timer = new SimpleTimer(3, timerCallback);

            Console.WriteLine("Симуляція роботи таймера (10 тіків, інтервал 3):");
            for (int i = 0; i < 10; i++)
            {
                timer.Tick();
            }

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: Сортування
            Console.WriteLine("КЕЙС 3: Система сортування з анонімними компараторами");
            Console.WriteLine("-".PadRight(60, '-'));
            var sorter = new CustomSorter();
            var products = new List<Product>
            {
                new Product { Name = "Ноутбук", Price = 25000, Stock = 5 },
                new Product { Name = "Мишка", Price = 500, Stock = 20 },
                new Product { Name = "Клавіатура", Price = 1200, Stock = 15 },
                new Product { Name = "Монітор", Price = 8000, Stock = 8 }
            };

            Console.WriteLine("Початковий список:");
            products.ForEach(p => Console.WriteLine($"  {p}"));

            // Анонімний метод для сортування за ціною
            CustomSorter.CompareDelegate<Product> priceComparer = delegate(Product p1, Product p2)
            {
                return p1.Price.CompareTo(p2.Price);
            };

            var sortedByPrice = new List<Product>(products);
            sorter.Sort(sortedByPrice, priceComparer);
            Console.WriteLine("\nСортування за ціною:");
            sortedByPrice.ForEach(p => Console.WriteLine($"  {p}"));

            // Анонімний метод для сортування за назвою
            CustomSorter.CompareDelegate<Product> nameComparer = delegate(Product p1, Product p2)
            {
                return string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase);
            };

            var sortedByName = new List<Product>(products);
            sorter.Sort(sortedByName, nameComparer);
            Console.WriteLine("\nСортування за назвою:");
            sortedByName.ForEach(p => Console.WriteLine($"  {p}"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: Валідація
            Console.WriteLine("КЕЙС 4: Система валідації з анонімними правилами");
            Console.WriteLine("-".PadRight(60, '-'));
            var validator = new Validator();

            // Додаємо анонімні правила валідації
            validator.AddRule(delegate(string value)
            {
                return !string.IsNullOrWhiteSpace(value);
            });

            validator.AddRule(delegate(string value)
            {
                return value.Length >= 6;
            });

            validator.AddRule(delegate(string value)
            {
                return value.Any(char.IsDigit);
            });

            validator.AddRule(delegate(string value)
            {
                return value.Any(char.IsUpper);
            });

            string[] testValues = { "", "123", "password", "Password1", "PASS123" };

            foreach (var value in testValues)
            {
                bool isValid = validator.Validate(value);
                Console.WriteLine($"'{value}': {(isValid ? "✓ Валідний" : "✗ Невалідний")}");
            }

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Обробка подій
            Console.WriteLine("КЕЙС 5: Система обробки подій з анонімними обробниками");
            Console.WriteLine("-".PadRight(60, '-'));
            var publisher = new EventPublisher();
            int messageCount = 0;

            // Підписуємося на подію з анонімним методом
            publisher.MessageReceived += delegate(string message)
            {
                messageCount++;
                Console.WriteLine($"[Обробник #{messageCount}] Отримано повідомлення: {message}");
            };

            // Додаємо ще один анонімний обробник
            publisher.MessageReceived += delegate(string message)
            {
                Console.WriteLine($"[Другий обробник] Довжина повідомлення: {message.Length} символів");
            };

            publisher.PublishMessage("Привіт, світ!");
            publisher.PublishMessage("Це тестове повідомлення");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 6: Обчислення
            Console.WriteLine("КЕЙС 6: Система обчислень з анонімними функціями");
            Console.WriteLine("-".PadRight(60, '-'));
            var calculator = new Calculator();

            decimal a = 10;
            decimal b = 3;

            // Різні операції через анонімні методи
            Calculator.CalculationDelegate add = delegate(decimal x, decimal y)
            {
                return x + y;
            };

            Calculator.CalculationDelegate multiply = delegate(decimal x, decimal y)
            {
                return x * y;
            };

            Calculator.CalculationDelegate power = delegate(decimal x, decimal y)
            {
                return (decimal)Math.Pow((double)x, (double)y);
            };

            // Використання зовнішніх змінних
            decimal taxRate = 0.2m;
            Calculator.CalculationDelegate calculateWithTax = delegate(decimal price, decimal quantity)
            {
                decimal subtotal = price * quantity;
                return subtotal * (1 + taxRate);
            };

            Console.WriteLine($"{a} + {b} = {calculator.Calculate(a, b, add)}");
            Console.WriteLine($"{a} × {b} = {calculator.Calculate(a, b, multiply)}");
            Console.WriteLine($"{a} ^ {b} = {calculator.Calculate(a, b, power)}");
            Console.WriteLine($"Ціна {a:C} × Кількість {b} + ПДВ ({taxRate * 100}%) = " +
                            $"{calculator.Calculate(a, b, calculateWithTax):C}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString() => $"{Name} - {Price:C} (Склад: {Stock})";
    }
}

