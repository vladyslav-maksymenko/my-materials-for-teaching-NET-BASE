using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 7: Парсинг текстового файлу з виразами
/// Формат: Число операція Число
/// Підтримує операції: +, -, *, /
/// </summary>
public static class Task7_FileParser
{
    private static Logger? logger;

    /// <summary>
    /// Головний метод для виконання завдання 7
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 7: Парсинг текстового файлу");
        Console.WriteLine("========================================\n");

        // Налаштування логування
        ConfigureLogging();

        try
        {
            // Запит шляху до файлу
            Console.Write("Введіть шлях до файлу (або натисніть Enter для використання expressions.txt): ");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = "expressions.txt";
            }

            // Перевірка існування файлу
            if (!File.Exists(filePath))
            {
                logger?.Warn("Файл не знайдено, створюємо приклад файлу");
                CreateSampleFile(filePath);
                Console.WriteLine($"\n✓ Створено приклад файлу: {filePath}");
                Console.WriteLine("Можете відредагувати його та запустити програму знову.");
                return;
            }

            logger?.Info("Початок обробки файлу: {FilePath}", filePath);

            // Читання та обробка файлу
            ProcessFile(filePath);

            logger?.Info("Обробка файлу завершена успішно");
        }
        catch (Exception ex)
        {
            logger?.Error(ex, "Помилка під час обробки файлу");
            Console.WriteLine($"\n✗ Помилка: {ex.Message}");
        }
        finally
        {
            LogManager.Shutdown();
        }
    }

    /// <summary>
    /// Налаштування NLog для логування
    /// </summary>
    private static void ConfigureLogging()
    {
        // Створюємо папку для логів, якщо її немає
        if (!Directory.Exists("logs"))
        {
            Directory.CreateDirectory("logs");
        }

        var config = new LoggingConfiguration();

        // Логування у консоль
        var consoleTarget = new ConsoleTarget("console")
        {
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${logger} ${message} ${exception}")
        };
        config.AddTarget(consoleTarget);
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);

        // Логування у файл
        var fileTarget = new FileTarget("file")
        {
            FileName = "logs/file-parser-${shortdate}.txt",
            Layout = new SimpleLayout("${longdate} ${level:uppercase=true} ${logger} ${message} ${exception}")
        };
        config.AddTarget(fileTarget);
        config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);

        LogManager.Configuration = config;
        logger = LogManager.GetCurrentClassLogger();
    }

    /// <summary>
    /// Створення прикладового файлу з виразами
    /// </summary>
    private static void CreateSampleFile(string filePath)
    {
        var sampleContent = @"3 + 4
2 * 5
6 - 2
10 / 2
15 + 3
4 * 7
20 - 8
12 / 3";

        File.WriteAllText(filePath, sampleContent);
    }

    /// <summary>
    /// Обробка файлу з виразами
    /// </summary>
    private static void ProcessFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        logger?.Info("Прочитано {LineCount} рядків з файлу", lines.Length);

        Console.WriteLine("\nРезультати обробки:\n");

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            // Пропускаємо порожні рядки
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            try
            {
                // Парсинг рядка
                var expression = ParseExpression(line);

                if (expression == null)
                {
                    logger?.Warn("Не вдалося розпарсити рядок {LineNumber}: {Line}", i + 1, line);
                    Console.WriteLine($"Рядок {i + 1}: {line} - помилка парсингу");
                    continue;
                }

                // Обчислення результату
                int result = Calculate(expression.Value.Number1, expression.Value.Operation, expression.Value.Number2);

                // Виведення результату
                string output = $"{expression.Value.Number1} {expression.Value.Operation} {expression.Value.Number2} = {result}";
                Console.WriteLine(output);

                logger?.Debug("Оброблено рядок {LineNumber}: {Output}", i + 1, output);
            }
            catch (Exception ex)
            {
                logger?.Error(ex, "Помилка обробки рядка {LineNumber}: {Line}", i + 1, line);
                Console.WriteLine($"Рядок {i + 1}: {line} - помилка: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Парсинг виразу з рядка
    /// Формат: Число операція Число
    /// </summary>
    private static (int Number1, char Operation, int Number2)? ParseExpression(string line)
    {
        // Видаляємо крапку з комою в кінці, якщо є
        line = line.TrimEnd(';', ' ', '\t');

        // Шукаємо операцію
        char[] operations = { '+', '-', '*', '/' };
        int operationIndex = -1;
        char operation = ' ';

        foreach (char op in operations)
        {
            int index = line.IndexOf(op);
            if (index > 0 && index < line.Length - 1)
            {
                operationIndex = index;
                operation = op;
                break;
            }
        }

        if (operationIndex == -1)
        {
            return null;
        }

        // Розділяємо на дві частини
        string part1 = line.Substring(0, operationIndex).Trim();
        string part2 = line.Substring(operationIndex + 1).Trim();

        // Парсимо числа
        if (!int.TryParse(part1, out int num1) || !int.TryParse(part2, out int num2))
        {
            return null;
        }

        return (num1, operation, num2);
    }

    /// <summary>
    /// Обчислення результату виразу
    /// </summary>
    private static int Calculate(int num1, char operation, int num2)
    {
        return operation switch
        {
            '+' => num1 + num2,
            '-' => num1 - num2,
            '*' => num1 * num2,
            '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Ділення на нуль"),
            _ => throw new ArgumentException($"Невідома операція: {operation}")
        };
    }
}

