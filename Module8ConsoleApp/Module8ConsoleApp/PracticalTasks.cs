using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module8ConsoleApp;

/// <summary>
/// Практичні завдання Модуль 8
/// </summary>
public static partial class PracticalTasks
{
    // ========== ЗАВДАННЯ 1 ==========
    // Делегат для відображення текстового повідомлення
    public delegate void MessageDisplayDelegate(string message);

    /// <summary>
    /// Завдання 1: Відображення текстового повідомлення через делегат
    /// </summary>
    public static void Task1_MessageDisplay()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 1: Відображення текстового повідомлення");
        Console.WriteLine(new string('═', 60));

        // Створення екземпляра делегата та прив'язка до різних методів
        MessageDisplayDelegate displayDelegate = DisplayToConsole;
        
        Console.WriteLine("\n1. Виклик через DisplayToConsole:");
        displayDelegate("Привіт, це повідомлення виведено через делегат!");

        // Зміна методу
        displayDelegate = DisplayToConsoleWithTimestamp;
        Console.WriteLine("\n2. Виклик через DisplayToConsoleWithTimestamp:");
        displayDelegate("Повідомлення з часовою міткою");

        // Додавання іншого методу (multicast)
        displayDelegate += DisplayToConsoleWithPrefix;
        Console.WriteLine("\n3. Виклик через multicast делегат:");
        displayDelegate("Повідомлення викликає обидва методи");

        // Використання анонімного методу
        MessageDisplayDelegate anonymousDelegate = delegate(string msg)
        {
            Console.WriteLine($"[АНОНІМНИЙ] {msg}");
        };
        Console.WriteLine("\n4. Виклик через анонімний метод:");
        anonymousDelegate("Це анонімний метод");

        // Використання лямбда-виразу
        MessageDisplayDelegate lambdaDelegate = (msg) => Console.WriteLine($"[ЛЯМБДА] {msg.ToUpper()}");
        Console.WriteLine("\n5. Виклик через лямбда-вираз:");
        lambdaDelegate("повідомлення через лямбда");
    }

    // Методи для завдання 1
    private static void DisplayToConsole(string message)
    {
        Console.WriteLine($"  → {message}");
    }

    private static void DisplayToConsoleWithTimestamp(string message)
    {
        Console.WriteLine($"  → [{DateTime.Now:HH:mm:ss}] {message}");
    }

    private static void DisplayToConsoleWithPrefix(string message)
    {
        Console.WriteLine($"  → [ПРЕФІКС] {message}");
    }

    // ========== ЗАВДАННЯ 2 ==========
    // Делегат для арифметичних операцій
    public delegate double ArithmeticOperation(double a, double b);

    /// <summary>
    /// Завдання 2: Арифметичні операції через делегати
    /// </summary>
    public static void Task2_ArithmeticOperations()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 2: Арифметичні операції");
        Console.WriteLine(new string('═', 60));

        double num1 = 15.5;
        double num2 = 4.2;

        // Створення делегатів для різних операцій
        ArithmeticOperation add = Addition;
        ArithmeticOperation subtract = Subtraction;
        ArithmeticOperation multiply = Multiplication;

        Console.WriteLine($"\nЧисла: {num1} та {num2}");
        Console.WriteLine($"Додавання: {num1} + {num2} = {add(num1, num2)}");
        Console.WriteLine($"Віднімання: {num1} - {num2} = {subtract(num1, num2)}");
        Console.WriteLine($"Множення: {num1} * {num2} = {multiply(num1, num2)}");

        // Використання делегата як параметра
        Console.WriteLine("\nВиклик через метод з параметром-делегатом:");
        PerformOperation(num1, num2, add, "Додавання");
        PerformOperation(num1, num2, subtract, "Віднімання");
        PerformOperation(num1, num2, multiply, "Множення");
    }

    // Методи для завдання 2
    private static double Addition(double a, double b) => a + b;
    private static double Subtraction(double a, double b) => a - b;
    private static double Multiplication(double a, double b) => a * b;

    private static void PerformOperation(double a, double b, ArithmeticOperation operation, string operationName)
    {
        double result = operation(a, b);
        Console.WriteLine($"  {operationName}: {a} і {b} = {result:F2}");
    }

    // ========== ЗАВДАННЯ 3 ==========
    /// <summary>
    /// Завдання 3: Перевірка чисел через Predicate
    /// </summary>
    public static void Task3_NumberPredicates()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 3: Перевірка чисел через Predicate");
        Console.WriteLine(new string('═', 60));

        int[] numbers = { 2, 3, 4, 5, 7, 8, 13, 15, 17, 21, 34, 55 };

        // Створення Predicate делегатів
        Predicate<int> isEven = IsEven;
        Predicate<int> isOdd = IsOdd;
        Predicate<int> isPrime = IsPrime;
        Predicate<int> isFibonacci = IsFibonacci;

        Console.WriteLine($"\nПеревірка чисел: {string.Join(", ", numbers)}\n");

        foreach (int num in numbers)
        {
            Console.WriteLine($"Число {num}:");
            Console.WriteLine($"  Парне: {isEven(num)}");
            Console.WriteLine($"  Непарне: {isOdd(num)}");
            Console.WriteLine($"  Просте: {isPrime(num)}");
            Console.WriteLine($"  Число Фібоначчі: {isFibonacci(num)}");
            Console.WriteLine();
        }
    }

    // Методи для завдання 3
    private static bool IsEven(int number) => number % 2 == 0;
    private static bool IsOdd(int number) => number % 2 != 0;

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

    private static bool IsFibonacci(int number)
    {
        // Перевірка чи є число числом Фібоначчі
        // Число n є числом Фібоначчі, якщо 5*n^2 + 4 або 5*n^2 - 4 є повним квадратом
        return IsPerfectSquare(5 * number * number + 4) || 
               IsPerfectSquare(5 * number * number - 4);
    }

    private static bool IsPerfectSquare(int n)
    {
        int sqrt = (int)Math.Sqrt(n);
        return sqrt * sqrt == n;
    }

    // ========== ЗАВДАННЯ 4 ==========
    /// <summary>
    /// Завдання 4: Арифметичні операції з використанням Invoke
    /// </summary>
    public static void Task4_ArithmeticWithInvoke()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 4: Арифметичні операції з Invoke");
        Console.WriteLine(new string('═', 60));

        double num1 = 20.0;
        double num2 = 5.0;

        ArithmeticOperation add = Addition;
        ArithmeticOperation subtract = Subtraction;
        ArithmeticOperation multiply = Multiplication;

        Console.WriteLine($"\nЧисла: {num1} та {num2}");
        Console.WriteLine("\nВиклик через Invoke:");

        // Виклик через Invoke
        double result1 = add.Invoke(num1, num2);
        Console.WriteLine($"  Додавання через Invoke: {num1} + {num2} = {result1}");

        double result2 = subtract.Invoke(num1, num2);
        Console.WriteLine($"  Віднімання через Invoke: {num1} - {num2} = {result2}");

        double result3 = multiply.Invoke(num1, num2);
        Console.WriteLine($"  Множення через Invoke: {num1} * {num2} = {result3}");

        // Використання Invoke в методі
        Console.WriteLine("\nВиклик через метод з Invoke:");
        PerformOperationWithInvoke(num1, num2, add, "Додавання");
        PerformOperationWithInvoke(num1, num2, subtract, "Віднімання");
        PerformOperationWithInvoke(num1, num2, multiply, "Множення");
    }

    private static void PerformOperationWithInvoke(double a, double b, ArithmeticOperation operation, string operationName)
    {
        double result = operation.Invoke(a, b);
        Console.WriteLine($"  {operationName} через Invoke: {a} і {b} = {result:F2}");
    }

    // ========== ЗАВДАННЯ 5 ==========
    // Делегат для фільтрації
    public delegate bool FilterDelegate(int number);

    /// <summary>
    /// Завдання 5: Фільтрація елементів List через делегати
    /// </summary>
    public static void Task5_FilterList()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 5: Фільтрація елементів List");
        Console.WriteLine(new string('═', 60));

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        Console.WriteLine($"\nВихідна колекція: {string.Join(", ", numbers)}");

        // Створення делегатів для фільтрації
        FilterDelegate filterEven = IsEven;
        FilterDelegate filterOdd = IsOdd;
        FilterDelegate filterPrime = IsPrime;

        // Фільтрація через делегати
        List<int> evenNumbers = FilterList(numbers, filterEven);
        List<int> oddNumbers = FilterList(numbers, filterOdd);
        List<int> primeNumbers = FilterList(numbers, filterPrime);

        Console.WriteLine($"\nПарні числа: {string.Join(", ", evenNumbers)}");
        Console.WriteLine($"Непарні числа: {string.Join(", ", oddNumbers)}");
        Console.WriteLine($"Прості числа: {string.Join(", ", primeNumbers)}");

        // Використання лямбда-виразів
        Console.WriteLine("\nФільтрація через лямбда-вирази:");
        List<int> divisibleBy3 = FilterList(numbers, n => n % 3 == 0);
        Console.WriteLine($"Числа, що діляться на 3: {string.Join(", ", divisibleBy3)}");
    }

    private static List<int> FilterList(List<int> numbers, FilterDelegate filter)
    {
        List<int> result = new List<int>();
        foreach (int number in numbers)
        {
            if (filter(number))
            {
                result.Add(number);
            }
        }
        return result;
    }

    // ========== ЗАВДАННЯ 6 ==========
    /// <summary>
    /// Завдання 6: Система логування на подіях для колекції
    /// </summary>
    public static void Task6_EventBasedLogging()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 6: Система логування на подіях");
        Console.WriteLine(new string('═', 60));

        // Створення колекції з логуванням
        LoggableCollection<string> collection = new LoggableCollection<string>();
        
        // Створення логгера та підписка на події
        CollectionLogger logger = new CollectionLogger("collection_log.txt");
        collection.ItemAdded += logger.OnItemAdded;
        collection.ItemRemoved += logger.OnItemRemoved;
        collection.ItemChanged += logger.OnItemChanged;

        Console.WriteLine("\nОперації з колекцією:");

        // Додавання елементів
        collection.Add("Елемент 1");
        collection.Add("Елемент 2");
        collection.Add("Елемент 3");

        // Зміна елемента
        collection[0] = "Змінений елемент 1";

        // Видалення елемента
        collection.Remove("Елемент 2");

        // Додавання ще одного елемента
        collection.Add("Елемент 4");

        Console.WriteLine($"\nКолекція містить {collection.Count} елементів:");
        foreach (var item in collection)
        {
            Console.WriteLine($"  - {item}");
        }

        // Закриття логгера
        logger.Close();

        Console.WriteLine("\nЛог збережено у файл: collection_log.txt");
    }
}

// ========== КЛАСИ ДЛЯ ЗАВДАННЯ 6 ==========

/// <summary>
/// Колекція з подіями для логування
/// </summary>
public class LoggableCollection<T> : List<T>
{
    // Події для логування
    public event EventHandler<CollectionEventArgs<T>>? ItemAdded;
    public event EventHandler<CollectionEventArgs<T>>? ItemRemoved;
    public event EventHandler<CollectionChangeEventArgs<T>>? ItemChanged;

    public new void Add(T item)
    {
        base.Add(item);
        OnItemAdded(new CollectionEventArgs<T>(item, "Додано"));
    }

    public new bool Remove(T item)
    {
        bool removed = base.Remove(item);
        if (removed)
        {
            OnItemRemoved(new CollectionEventArgs<T>(item, "Видалено"));
        }
        return removed;
    }

    public new T this[int index]
    {
        get => base[index];
        set
        {
            T oldValue = base[index];
            base[index] = value;
            OnItemChanged(new CollectionChangeEventArgs<T>(oldValue, value, index, "Змінено"));
        }
    }

    protected virtual void OnItemAdded(CollectionEventArgs<T> e)
    {
        ItemAdded?.Invoke(this, e);
    }

    protected virtual void OnItemRemoved(CollectionEventArgs<T> e)
    {
        ItemRemoved?.Invoke(this, e);
    }

    protected virtual void OnItemChanged(CollectionChangeEventArgs<T> e)
    {
        ItemChanged?.Invoke(this, e);
    }
}

/// <summary>
/// Аргументи події для колекції
/// </summary>
public class CollectionEventArgs<T> : EventArgs
{
    public T Item { get; }
    public string Action { get; }
    public DateTime Timestamp { get; }

    public CollectionEventArgs(T item, string action)
    {
        Item = item;
        Action = action;
        Timestamp = DateTime.Now;
    }
}

/// <summary>
/// Аргументи події для зміни елемента
/// </summary>
public class CollectionChangeEventArgs<T> : EventArgs
{
    public T OldValue { get; }
    public T NewValue { get; }
    public int Index { get; }
    public string Action { get; }
    public DateTime Timestamp { get; }

    public CollectionChangeEventArgs(T oldValue, T newValue, int index, string action)
    {
        OldValue = oldValue;
        NewValue = newValue;
        Index = index;
        Action = action;
        Timestamp = DateTime.Now;
    }
}

/// <summary>
/// Логгер для колекції
/// </summary>
public class CollectionLogger
{
    private readonly StreamWriter _logWriter;
    private readonly string _logFilePath;

    public CollectionLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
        _logWriter = new StreamWriter(logFilePath, append: true);
        _logWriter.WriteLine($"=== Лог сесії: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
    }

    public void OnItemAdded(object? sender, CollectionEventArgs<string> e)
    {
        string logMessage = $"[{e.Timestamp:HH:mm:ss}] {e.Action}: '{e.Item}'";
        Console.WriteLine($"  {logMessage}");
        _logWriter.WriteLine(logMessage);
        _logWriter.Flush();
    }

    public void OnItemRemoved(object? sender, CollectionEventArgs<string> e)
    {
        string logMessage = $"[{e.Timestamp:HH:mm:ss}] {e.Action}: '{e.Item}'";
        Console.WriteLine($"  {logMessage}");
        _logWriter.WriteLine(logMessage);
        _logWriter.Flush();
    }

    public void OnItemChanged(object? sender, CollectionChangeEventArgs<string> e)
    {
        string logMessage = $"[{e.Timestamp:HH:mm:ss}] {e.Action} [індекс {e.Index}]: '{e.OldValue}' → '{e.NewValue}'";
        Console.WriteLine($"  {logMessage}");
        _logWriter.WriteLine(logMessage);
        _logWriter.Flush();
    }

    public void Close()
    {
        _logWriter.WriteLine($"=== Кінець сесії: {DateTime.Now:yyyy-MM-dd HH:mm:ss} ===");
        _logWriter.WriteLine();
        _logWriter.Close();
    }
}

// ========== ЧАСТИНА 2: АНОНІМНІ МЕТОДИ ТА ЛЯМБДА-ВИРАЗИ ==========

/// <summary>
/// Делегат для перевірки числа на парність
/// </summary>
public delegate string CheckEvenOddDelegate(int number);

/// <summary>
/// Делегат для піднесення числа до степеня
/// </summary>
public delegate double PowerDelegate(double number, int power);

/// <summary>
/// Делегат для перевірки дня на вихідний
/// </summary>
public delegate bool IsWeekendDelegate(DateTime date);

/// <summary>
/// Делегат для пошуку максимального значення та індексу
/// </summary>
public delegate (int value, int index) FindMaxDelegate(int[] array);

/// <summary>
/// Делегат для пошуку мінімального значення та індексу
/// </summary>
public delegate (int value, int index) FindMinDelegate(int[] array);

/// <summary>
/// Делегат для фільтрації масиву
/// </summary>
public delegate int[] FilterArrayDelegate(int[] array);

public static partial class PracticalTasks
{
    // ========== ЗАВДАННЯ 7 (Частина 2, Завдання 1) ==========
    /// <summary>
    /// Завдання 1: Анонімний метод для перевірки числа на парність і непарність
    /// </summary>
    public static void Task7_AnonymousCheckEvenOdd()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 1 (Частина 2): Анонімний метод для перевірки парності");
        Console.WriteLine(new string('═', 60));

        // Створення анонімного методу
        CheckEvenOddDelegate checkEvenOdd = delegate(int number)
        {
            return number % 2 == 0 ? "парне" : "непарне";
        };

        // Тестування
        int[] testNumbers = { 1, 2, 3, 4, 5, 10, 15, 20, 0, -1, -2 };

        Console.WriteLine("\nТестування анонімного методу:");
        foreach (int num in testNumbers)
        {
            string result = checkEvenOdd(num);
            Console.WriteLine($"  Число {num} - {result}");
        }
    }

    // ========== ЗАВДАННЯ 8 (Частина 2, Завдання 2) ==========
    /// <summary>
    /// Завдання 2: Анонімний метод для піднесення числа до степеня
    /// </summary>
    public static void Task8_AnonymousPower()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 2 (Частина 2): Анонімний метод для піднесення до степеня");
        Console.WriteLine(new string('═', 60));

        // Створення анонімного методу
        PowerDelegate powerOperation = delegate(double number, int power)
        {
            return Math.Pow(number, power);
        };

        // Тестування
        Console.WriteLine("\nТестування анонімного методу:");
        var testCases = new[]
        {
            (number: 2.0, power: 3),
            (number: 5.0, power: 2),
            (number: 10.0, power: 4),
            (number: 3.0, power: 5),
            (number: 2.5, power: 2)
        };

        foreach (var (number, power) in testCases)
        {
            double result = powerOperation(number, power);
            Console.WriteLine($"  {number} ^ {power} = {result:F2}");
        }
    }

    // ========== ЗАВДАННЯ 9 (Частина 2, Завдання 3) ==========
    /// <summary>
    /// Завдання 3: Лямбда-вираз для піднесення числа до будь-якого ступеня
    /// </summary>
    public static void Task9_LambdaPower()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 3 (Частина 2): Лямбда-вираз для піднесення до степеня");
        Console.WriteLine(new string('═', 60));

        // Створення лямбда-виразу
        PowerDelegate lambdaPower = (number, power) => Math.Pow(number, power);

        // Тестування
        Console.WriteLine("\nТестування лямбда-виразу:");
        var testCases = new[]
        {
            (number: 2.0, power: 3),
            (number: 5.0, power: 2),
            (number: 10.0, power: 4),
            (number: 3.0, power: 5),
            (number: 2.5, power: 2),
            (number: 4.0, power: 0),
            (number: 2.0, power: -2)
        };

        foreach (var (number, power) in testCases)
        {
            double result = lambdaPower(number, power);
            Console.WriteLine($"  {number} ^ {power} = {result:F4}");
        }
    }

    // ========== ЗАВДАННЯ 10 (Частина 2, Завдання 4) ==========
    /// <summary>
    /// Завдання 4: Лямбда-вираз для перевірки, чи є день вихідним
    /// </summary>
    public static void Task10_LambdaIsWeekend()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 4 (Частина 2): Лямбда-вираз для перевірки вихідного дня");
        Console.WriteLine(new string('═', 60));

        // Створення лямбда-виразу
        IsWeekendDelegate isWeekend = date => date.DayOfWeek == DayOfWeek.Saturday || 
                                               date.DayOfWeek == DayOfWeek.Sunday;

        // Тестування
        Console.WriteLine("\nТестування лямбда-виразу:");
        DateTime[] testDates = new[]
        {
            new DateTime(2024, 1, 1),   // Понеділок
            new DateTime(2024, 1, 6),   // Субота
            new DateTime(2024, 1, 7),   // Неділя
            new DateTime(2024, 1, 10),  // Середа
            new DateTime(2024, 1, 13),  // Субота
            new DateTime(2024, 1, 14),  // Неділя
            new DateTime(2024, 1, 15)   // Понеділок
        };

        foreach (DateTime date in testDates)
        {
            bool result = isWeekend(date);
            string dayName = date.DayOfWeek switch
            {
                DayOfWeek.Monday => "Понеділок",
                DayOfWeek.Tuesday => "Вівторок",
                DayOfWeek.Wednesday => "Середа",
                DayOfWeek.Thursday => "Четвер",
                DayOfWeek.Friday => "П'ятниця",
                DayOfWeek.Saturday => "Субота",
                DayOfWeek.Sunday => "Неділя",
                _ => "Невідомий"
            };
            string status = result ? "ВИХІДНИЙ" : "робочий";
            Console.WriteLine($"  {date:yyyy-MM-dd} ({dayName}) - {status}");
        }
    }

    // ========== ЗАВДАННЯ 11 (Частина 2, Завдання 5) ==========
    /// <summary>
    /// Завдання 5: Лямбда-вираз для пошуку максимального значення в масиві та його індексу
    /// </summary>
    public static void Task11_LambdaFindMax()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 5 (Частина 2): Лямбда-вираз для пошуку максимуму");
        Console.WriteLine(new string('═', 60));

        // Створення лямбда-виразу
        FindMaxDelegate findMax = array =>
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив не може бути порожнім");

            int maxValue = array[0];
            int maxIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }

            return (maxValue, maxIndex);
        };

        // Тестування
        Console.WriteLine("\nТестування лямбда-виразу:");
        int[][] testArrays = new[]
        {
            new[] { 1, 5, 3, 9, 2 },
            new[] { 10, 20, 30, 40, 50 },
            new[] { 100, 50, 75, 25 },
            new[] { 5 },
            new[] { -10, -5, -20, -1 },
            new[] { 1, 2, 3, 3, 2, 1 }
        };

        foreach (int[] array in testArrays)
        {
            var (maxValue, maxIndex) = findMax(array);
            Console.WriteLine($"  Масив: [{string.Join(", ", array)}]");
            Console.WriteLine($"    Максимальне значення: {maxValue}, індекс: {maxIndex}");
        }
    }

    // ========== ЗАВДАННЯ 12 (Частина 2, Завдання 6) ==========
    /// <summary>
    /// Завдання 6: Лямбда-вираз для пошуку мінімального значення в масиві та його індексу
    /// </summary>
    public static void Task12_LambdaFindMin()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 6 (Частина 2): Лямбда-вираз для пошуку мінімуму");
        Console.WriteLine(new string('═', 60));

        // Створення лямбда-виразу
        FindMinDelegate findMin = array =>
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив не може бути порожнім");

            int minValue = array[0];
            int minIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                    minIndex = i;
                }
            }

            return (minValue, minIndex);
        };

        // Тестування
        Console.WriteLine("\nТестування лямбда-виразу:");
        int[][] testArrays = new[]
        {
            new[] { 1, 5, 3, 9, 2 },
            new[] { 10, 20, 30, 40, 50 },
            new[] { 100, 50, 75, 25 },
            new[] { 5 },
            new[] { -10, -5, -20, -1 },
            new[] { 1, 2, 3, 3, 2, 1 }
        };

        foreach (int[] array in testArrays)
        {
            var (minValue, minIndex) = findMin(array);
            Console.WriteLine($"  Масив: [{string.Join(", ", array)}]");
            Console.WriteLine($"    Мінімальне значення: {minValue}, індекс: {minIndex}");
        }
    }

    // ========== ЗАВДАННЯ 13 (Частина 2, Завдання 7) ==========
    /// <summary>
    /// Завдання 7: Лямбда-вираз для фільтрації непарних чисел у масиві
    /// </summary>
    public static void Task13_LambdaFilterOdd()
    {
        Console.WriteLine("\n" + new string('═', 60));
        Console.WriteLine("ЗАВДАННЯ 7 (Частина 2): Лямбда-вираз для фільтрації непарних чисел");
        Console.WriteLine(new string('═', 60));

        // Створення лямбда-виразу
        FilterArrayDelegate filterOdd = array =>
        {
            if (array == null)
                return Array.Empty<int>();

            List<int> oddNumbers = new List<int>();
            foreach (int number in array)
            {
                if (number % 2 != 0)
                {
                    oddNumbers.Add(number);
                }
            }
            return oddNumbers.ToArray();
        };

        // Альтернативний варіант з LINQ (для демонстрації)
        Func<int[], int[]> filterOddLinq = array => 
            array?.Where(x => x % 2 != 0).ToArray() ?? Array.Empty<int>();

        // Тестування
        Console.WriteLine("\nТестування лямбда-виразу:");
        int[][] testArrays = new[]
        {
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new[] { 2, 4, 6, 8 },
            new[] { 1, 3, 5, 7, 9 },
            new[] { 10, 15, 20, 25, 30, 35 },
            new[] { 0, 1, 2, 3 },
            new[] { -5, -4, -3, -2, -1, 0, 1, 2, 3 }
        };

        foreach (int[] array in testArrays)
        {
            int[] oddNumbers = filterOdd(array);
            Console.WriteLine($"  Вихідний масив: [{string.Join(", ", array)}]");
            Console.WriteLine($"  Непарні числа: [{string.Join(", ", oddNumbers)}]");
        }

        // Демонстрація альтернативного варіанту з LINQ
        Console.WriteLine("\nАльтернативний варіант з LINQ:");
        int[] testArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] oddNumbersLinq = filterOddLinq(testArray);
        Console.WriteLine($"  Вихідний масив: [{string.Join(", ", testArray)}]");
        Console.WriteLine($"  Непарні числа (LINQ): [{string.Join(", ", oddNumbersLinq)}]");
    }
}


