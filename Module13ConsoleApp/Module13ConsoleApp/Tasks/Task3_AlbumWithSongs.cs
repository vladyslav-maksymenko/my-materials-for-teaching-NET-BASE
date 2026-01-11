using System.Text.Json;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 3: Робота з музичним альбомом зі списком пісень
/// Розширена версія завдання 2 з додаванням списку пісень
/// </summary>
public static class Task3_AlbumWithSongs
{
    private const string FileName = "music_album_with_songs.json";

    /// <summary>
    /// Головний метод для виконання завдання 3
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 3: Альбом зі списком пісень");
        Console.WriteLine("========================================\n");

        try
        {
            // 1. Введення інформації про альбом з піснями
            MusicAlbum album = InputAlbumWithSongs();
            
            // Автоматично обчислюємо тривалість альбому на основі пісень
            album.CalculateDurationFromSongs();

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
    /// Введення інформації про альбом зі списком пісень
    /// </summary>
    private static MusicAlbum InputAlbumWithSongs()
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

        Console.Write("Студія випуску: ");
        album.Studio = Console.ReadLine() ?? string.Empty;

        // Введення пісень
        Console.WriteLine("\nВведіть кількість пісень в альбомі:");
        if (!int.TryParse(Console.ReadLine(), out int songCount) || songCount <= 0)
        {
            throw new ArgumentException("Невірна кількість пісень");
        }

        album.Songs = new List<Song>();
        for (int i = 0; i < songCount; i++)
        {
            Console.WriteLine($"\nПісня {i + 1}:");
            var song = new Song();

            Console.Write("  Назва пісні: ");
            song.Title = Console.ReadLine() ?? string.Empty;

            Console.Write("  Тривалість (в секундах): ");
            if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
            {
                throw new ArgumentException($"Невірна тривалість для пісні {i + 1}");
            }
            song.Duration = duration;

            Console.Write("  Стиль пісні: ");
            song.Genre = Console.ReadLine() ?? string.Empty;

            album.Songs.Add(song);
        }

        return album;
    }

    /// <summary>
    /// Серіалізація альбому з піснями у JSON та збереження у файл
    /// </summary>
    private static void SerializeAndSave(MusicAlbum album)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(album, options);
        File.WriteAllText(FileName, json);
        Console.WriteLine($"\n✓ Альбом з піснями серіалізовано та збережено у файл: {FileName}");
    }

    /// <summary>
    /// Завантаження та десеріалізація альбому з піснями з файлу
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

        Console.WriteLine($"\n✓ Альбом з піснями завантажено та десеріалізовано з файлу: {FileName}");
        return album;
    }
}

