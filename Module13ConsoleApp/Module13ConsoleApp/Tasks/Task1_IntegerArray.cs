using System.Text.Json;
using Module13ConsoleApp.Helpers;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 1: Робота з масивом цілих чисел
/// - Введення масиву з клавіатури
/// - Фільтрація (прості числа або числа Фібоначчі)
/// - Серіалізація та збереження у файл
/// - Завантаження та десеріалізація з файлу
/// </summary>
public static class Task1_IntegerArray
{
    private const string FileName = "integer_array.json";

    /// <summary>
    /// Головний метод для виконання завдання 1
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 1: Робота з масивом цілих чисел");
        Console.WriteLine("========================================\n");

        try
        {
            // 1. Введення масиву з клавіатури
            int[] array = InputArray();
            Console.WriteLine($"\nВведений масив: [{string.Join(", ", array)}]");

            // 2. Фільтрація масиву
            int[] filteredArray = FilterArray(array);
            Console.WriteLine($"Відфільтрований масив: [{string.Join(", ", filteredArray)}]");

            // 3. Серіалізація та збереження
            SerializeAndSave(filteredArray);

            // 4. Завантаження та десеріалізація
            int[] loadedArray = LoadAndDeserialize();
            Console.WriteLine($"\nЗавантажений масив: [{string.Join(", ", loadedArray)}]");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n Помилка: {ex.Message}");
        }
    }

    /// <summary>
    /// Введення масиву цілих чисел з клавіатури
    /// </summary>
    private static int[] InputArray()
    {
        Console.WriteLine("Введіть кількість елементів масиву:");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            throw new ArgumentException("Невірна кількість елементів");
        }

        int[] array = new int[count];
        Console.WriteLine($"Введіть {count} цілих чисел (по одному на рядок):");

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Елемент {i + 1}: ");
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                throw new ArgumentException($"Невірне значення для елемента {i + 1}");
            }
        }

        return array;
    }

    /// <summary>
    /// Фільтрація масиву залежно від вибору користувача
    /// </summary>
    private static int[] FilterArray(int[] array)
    {
        Console.WriteLine("\nОберіть тип фільтрації:");
        Console.WriteLine("1. Видалити прості числа");
        Console.WriteLine("2. Видалити числа Фібоначчі");
        Console.Write("Ваш вибір: ");

        string? choice = Console.ReadLine();

        return choice switch
        {
            "1" => NumberFilter.FilterOutPrimes(array),
            "2" => NumberFilter.FilterOutFibonacci(array),
            _ => throw new ArgumentException("Невірний вибір фільтрації")
        };
    }

    /// <summary>
    /// Серіалізація масиву у JSON та збереження у файл
    /// Використовуємо JSON, оскільки це сучасний, читабельний формат,
    /// який підтримується в .NET Core/.NET 5+ без додаткових залежностей
    /// </summary>
    private static void SerializeAndSave(int[] array)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // Для читабельності
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(array, options);
        File.WriteAllText(FileName, json);
        Console.WriteLine($"\n✓ Масив серіалізовано та збережено у файл: {FileName}");
    }

    /// <summary>
    /// Завантаження та десеріалізація масиву з файлу
    /// </summary>
    private static int[] LoadAndDeserialize()
    {
        if (!File.Exists(FileName))
        {
            throw new FileNotFoundException($"Файл {FileName} не знайдено");
        }

        string json = File.ReadAllText(FileName);
        int[]? array = JsonSerializer.Deserialize<int[]>(json);

        if (array == null)
        {
            throw new InvalidOperationException("Помилка десеріалізації масиву");
        }

        Console.WriteLine($"\n Масив завантажено та десеріалізовано з файлу: {FileName}");
        return array;
    }
}

