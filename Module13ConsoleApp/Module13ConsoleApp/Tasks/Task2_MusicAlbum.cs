using System.Text.Json;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 2: Робота з інформацією про музичний альбом
/// - Введення інформації про альбом
/// - Виведення інформації про альбом
/// - Серіалізація та збереження у файл
/// - Завантаження та десеріалізація з файлу
/// </summary>
public static class Task2_MusicAlbum
{
    private const string FileName = "music_album.json";

    /// <summary>
    /// Головний метод для виконання завдання 2
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 2: Робота з музичним альбомом");
        Console.WriteLine("========================================\n");

        try
        {
            // 1. Введення інформації про альбом
            MusicAlbum album = InputAlbum();
            
            // 2. Виведення інформації про альбом
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Інформація про альбом:");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(album);

            // 3. Серіалізація та збереження
            SerializeAndSave(album);

            // 4. Завантаження та десеріалізація
            MusicAlbum loadedAlbum = LoadAndDeserialize();
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("Завантажений альбом:");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(loadedAlbum);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Помилка: {ex.Message}");
        }
    }

    /// <summary>
    /// Введення інформації про альбом з клавіатури
    /// </summary>
    private static MusicAlbum InputAlbum()
    {
        var album = new MusicAlbum();

        Console.WriteLine("Введіть інформацію про альбом:");
        Console.Write("Назва альбому: ");
        album.AlbumTitle = Console.ReadLine() ?? string.Empty;

        Console.Write("Назва виконавця: ");
        album.Artist = Console.ReadLine() ?? string.Empty;

        Console.Write("Рік випуску: ");
        if (!int.TryParse(Console.ReadLine(), out int year) || year < 1900 || year > DateTime.Now.Year + 1)
        {
            throw new ArgumentException("Невірний рік випуску");
        }
        album.ReleaseYear = year;

        Console.Write("Тривалість (в секундах): ");
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
        {
            throw new ArgumentException("Невірна тривалість");
        }
        album.Duration = duration;

        Console.Write("Студія випуску: ");
        album.Studio = Console.ReadLine() ?? string.Empty;

        return album;
    }

    /// <summary>
    /// Серіалізація альбому у JSON та збереження у файл
    /// JSON обрано як сучасний, читабельний формат для структурованих даних
    /// </summary>
    private static void SerializeAndSave(MusicAlbum album)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // Для читабельності
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(album, options);
        File.WriteAllText(FileName, json);
        Console.WriteLine($"\n✓ Альбом серіалізовано та збережено у файл: {FileName}");
    }

    /// <summary>
    /// Завантаження та десеріалізація альбому з файлу
    /// </summary>
    private static MusicAlbum LoadAndDeserialize()
    {
        if (!File.Exists(FileName))
        {
            throw new FileNotFoundException($"Файл {FileName} не знайдено");
        }

        string json = File.ReadAllText(FileName);
        MusicAlbum? album = JsonSerializer.Deserialize<MusicAlbum>(json);

        if (album == null)
        {
            throw new InvalidOperationException("Помилка десеріалізації альбому");
        }

        Console.WriteLine($"\n✓ Альбом завантажено та десеріалізовано з файлу: {FileName}");
        return album;
    }
}

