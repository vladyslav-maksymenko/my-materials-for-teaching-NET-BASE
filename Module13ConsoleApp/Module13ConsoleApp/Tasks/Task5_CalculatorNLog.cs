using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 5: Калькулятор з логуванням через NLog
/// Підтримує базові арифметичні операції з логуванням у файл або консоль
/// </summary>
public static class Task5_CalculatorNLog
{
    private static Logger? logger;

    /// <summary>
    /// Головний метод для виконання завдання 5
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 5: Калькулятор з NLog");
        Console.WriteLine("========================================\n");

        // Налаштування логування
        ConfigureLogging();

        bool continueRunning = true;

        while (continueRunning)
        {
            try
            {
                Console.WriteLine("\nОберіть операцію:");
                Console.WriteLine("1. Додавання (+)");
                Console.WriteLine("2. Віднімання (-)");
                Console.WriteLine("3. Множення (*)");
                Console.WriteLine("4. Ділення (/)");
                Console.WriteLine("5. Відсоток (%)");
                Console.WriteLine("6. Піднесення до степеня (^)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                string? choice = Console.ReadLine();

                if (choice == "0")
                {
                    continueRunning = false;
                    logger?.Info("Користувач вийшов з калькулятора");
                    break;
                }

                if (string.IsNullOrEmpty(choice) || !"123456".Contains(choice))
                {
                    logger?.Warn("Невірний вибір операції");
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }

                // Введення чисел
                Console.Write("Введіть перше число: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    logger?.Error("Помилка введення першого числа");
                    Console.WriteLine("Невірне значення першого числа!");
                    continue;
                }

                Console.Write("Введіть друге число: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    logger?.Error("Помилка введення другого числа");
                    Console.WriteLine("Невірне значення другого числа!");
                    continue;
                }

                // Виконання операції
                double result = PerformOperation(choice, num1, num2);
                string operation = GetOperationSymbol(choice);

                logger?.Info($"Операція: {num1} {operation} {num2} = {result}");
                Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                logger?.Fatal(ex, "Серйозна помилка: ділення на нуль");
                Console.WriteLine("\n✗ ПОМИЛКА: Ділення на нуль неможливе!");
            }
            catch (Exception ex)
            {
                logger?.Error(ex, "Помилка під час виконання операції");
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }
        }

        // Закриття логера
        LogManager.Shutdown();
    }

    /// <summary>
    /// Налаштування NLog залежно від вибору користувача
    /// </summary>
    private static void ConfigureLogging()
    {
        // Створюємо папку для логів, якщо її немає
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        Console.WriteLine("Оберіть спосіб логування:");
        Console.WriteLine("1. Логування у файл");
        Console.WriteLine("2. Логування у консоль");
        Console.Write("Ваш вибір: ");

        string? choice = Console.ReadLine();

        var config = new LoggingConfiguration();

        if (choice == "1")
        {
            // Логування тільки у файл
            var fileTarget = new FileTarget("file")
            {
                FileName = "logs/calculator-nlog-${shortdate}.txt",
                Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${message} ${exception}")
            };
            config.AddTarget(fileTarget);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);
        }
        else if (choice == "2")
        {
            // Логування тільки у консоль
            var consoleTarget = new ConsoleTarget("console")
            {
                Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${message} ${exception}")
            };
            config.AddTarget(consoleTarget);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);
        }
        else
        {
            // За замовчуванням - у консоль
            var consoleTarget = new ConsoleTarget("console")
            {
                Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${message} ${exception}")
            };
            config.AddTarget(consoleTarget);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);
        }

        // Для серйозних помилок завжди логуємо і в консоль, і в файл
        var consoleTargetForErrors = new ConsoleTarget("consoleErrors")
        {
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${message} ${exception}")
        };
        var fileTargetForErrors = new FileTarget("fileErrors")
        {
            FileName = "logs/calculator-nlog-errors-${shortdate}.txt",
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${message} ${exception}")
        };

        config.AddTarget(consoleTargetForErrors);
        config.AddTarget(fileTargetForErrors);
        config.AddRule(LogLevel.Fatal, LogLevel.Fatal, consoleTargetForErrors);
        config.AddRule(LogLevel.Fatal, LogLevel.Fatal, fileTargetForErrors);

        LogManager.Configuration = config;
        logger = LogManager.GetCurrentClassLogger();

        logger.Info("Калькулятор запущено");
    }

    /// <summary>
    /// Виконання арифметичної операції
    /// </summary>
    private static double PerformOperation(string choice, double num1, double num2)
    {
        return choice switch
        {
            "1" => num1 + num2,           // Додавання
            "2" => num1 - num2,           // Віднімання
            "3" => num1 * num2,           // Множення
            "4" => num1 / num2,           // Ділення (може викинути DivideByZeroException)
            "5" => num1 * num2 / 100.0,   // Відсоток
            "6" => Math.Pow(num1, num2),  // Піднесення до степеня
            _ => throw new ArgumentException("Невідома операція")
        };
    }

    /// <summary>
    /// Отримання символу операції для виведення
    /// </summary>
    private static string GetOperationSymbol(string choice)
    {
        return choice switch
        {
            "1" => "+",
            "2" => "-",
            "3" => "*",
            "4" => "/",
            "5" => "%",
            "6" => "^",
            _ => "?"
        };
    }
}

