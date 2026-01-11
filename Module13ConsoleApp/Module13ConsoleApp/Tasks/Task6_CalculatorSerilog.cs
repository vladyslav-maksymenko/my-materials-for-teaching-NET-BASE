using Serilog;
using Serilog.Events;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 6: Калькулятор з логуванням через Serilog
/// Підтримує базові арифметичні операції з логуванням у файл або консоль
/// </summary>
public static class Task6_CalculatorSerilog
{
    /// <summary>
    /// Головний метод для виконання завдання 6
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 6: Калькулятор з Serilog");
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
                    Log.Information("Користувач вийшов з калькулятора");
                    break;
                }

                if (string.IsNullOrEmpty(choice) || !"123456".Contains(choice))
                {
                    Log.Warning("Невірний вибір операції");
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    continue;
                }

                // Введення чисел
                Console.Write("Введіть перше число: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Log.Error("Помилка введення першого числа");
                    Console.WriteLine("Невірне значення першого числа!");
                    continue;
                }

                Console.Write("Введіть друге число: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Log.Error("Помилка введення другого числа");
                    Console.WriteLine("Невірне значення другого числа!");
                    continue;
                }

                // Виконання операції
                double result = PerformOperation(choice, num1, num2);
                string operation = GetOperationSymbol(choice);

                Log.Information("Операція: {Num1} {Operation} {Num2} = {Result}", num1, operation, num2, result);
                Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Log.Fatal(ex, "Серйозна помилка: ділення на нуль");
                Console.WriteLine("\n✗ ПОМИЛКА: Ділення на нуль неможливе!");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Помилка під час виконання операції");
                Console.WriteLine($"\n✗ Помилка: {ex.Message}");
            }
        }

        // Закриття логера
        Log.CloseAndFlush();
    }

    /// <summary>
    /// Налаштування Serilog залежно від вибору користувача
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

        var loggerConfig = new LoggerConfiguration()
            .MinimumLevel.Information();

        if (choice == "1")
        {
            // Логування тільки у файл
            loggerConfig.WriteTo.File(
                "logs/calculator-serilog-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
        }
        else if (choice == "2")
        {
            // Логування тільки у консоль
            loggerConfig.WriteTo.Console(
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
        }
        else
        {
            // За замовчуванням - у консоль
            loggerConfig.WriteTo.Console(
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
        }

        // Для серйозних помилок завжди логуємо і в консоль, і в файл
        loggerConfig.WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
            .WriteTo.Console(
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                "logs/calculator-serilog-errors-.txt",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}"));

        Log.Logger = loggerConfig.CreateLogger();
        Log.Information("Калькулятор запущено");
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

