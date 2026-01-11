using System.Text.Json;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Tasks;

/// <summary>
/// Завдання 4: Робота з масивом альбомів
/// Розширена версія завдання 3 з можливістю роботи з масивом альбомів
/// </summary>
public static class Task4_AlbumArray
{
    private const string FileName = "albums_array.json";

    /// <summary>
    /// Головний метод для виконання завдання 4
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Завдання 4: Робота з масивом альбомів");
        Console.WriteLine("========================================\n");

        try
        {
            // 1. Введення масиву альбомів
            List<MusicAlbum> albums = InputAlbumsArray();
            
            // Обчислюємо тривалість для кожного альбому
            foreach (var album in albums)
            {
                album.CalculateDurationFromSongs();
            }

            // 2. Виведення інформації про альбоми
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Інформація про всі альбоми:");
            Console.WriteLine(new string('=', 60));
            for (int i = 0; i < albums.Count; i++)
            {
                Console.WriteLine($"\n--- Альбом {i + 1} ---");
                Console.WriteLine(albums[i]);
                Console.WriteLine();
            }

            // 3. Серіалізація та збереження
            SerializeAndSave(albums);

            // 4. Завантаження та десеріалізація
            List<MusicAlbum> loadedAlbums = LoadAndDeserialize();
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("Завантажені альбоми:");
            Console.WriteLine(new string('=', 60));
            for (int i = 0; i < loadedAlbums.Count; i++)
            {
                Console.WriteLine($"\n--- Альбом {i + 1} ---");
                Console.WriteLine(loadedAlbums[i]);
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n✗ Помилка: {ex.Message}");
        }
    }

    /// <summary>
    /// Введення масиву альбомів
    /// </summary>
    private static List<MusicAlbum> InputAlbumsArray()
    {
        Console.WriteLine("Введіть кількість альбомів:");
        if (!int.TryParse(Console.ReadLine(), out int albumCount) || albumCount <= 0)
        {
            throw new ArgumentException("Невірна кількість альбомів");
        }

        var albums = new List<MusicAlbum>();

        for (int albumIndex = 0; albumIndex < albumCount; albumIndex++)
        {
            Console.WriteLine($"\n{new string('=', 50)}");
            Console.WriteLine($"Альбом {albumIndex + 1} з {albumCount}");
            Console.WriteLine(new string('=', 50));

            var album = new MusicAlbum();

            Console.Write("Назва альбому: ");
            album.AlbumTitle = Console.ReadLine() ?? string.Empty;

            Console.Write("Назва виконавця: ");
            album.Artist = Console.ReadLine() ?? string.Empty;

            Console.Write("Рік випуску: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 1900 || year > DateTime.Now.Year + 1)
            {
                throw new ArgumentException($"Невірний рік випуску для альбому {albumIndex + 1}");
            }
            album.ReleaseYear = year;

            Console.Write("Студія випуску: ");
            album.Studio = Console.ReadLine() ?? string.Empty;

            // Введення пісень для альбому
            Console.WriteLine("\nВведіть кількість пісень в альбомі:");
            if (!int.TryParse(Console.ReadLine(), out int songCount) || songCount <= 0)
            {
                throw new ArgumentException($"Невірна кількість пісень для альбому {albumIndex + 1}");
            }

            album.Songs = new List<Song>();
            for (int i = 0; i < songCount; i++)
            {
                Console.WriteLine($"\n  Пісня {i + 1}:");
                var song = new Song();

                Console.Write("    Назва пісні: ");
                song.Title = Console.ReadLine() ?? string.Empty;

                Console.Write("    Тривалість (в секундах): ");
                if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
                {
                    throw new ArgumentException($"Невірна тривалість для пісні {i + 1} альбому {albumIndex + 1}");
                }
                song.Duration = duration;

                Console.Write("    Стиль пісні: ");
                song.Genre = Console.ReadLine() ?? string.Empty;

                album.Songs.Add(song);
            }

            albums.Add(album);
        }

        return albums;
    }

    /// <summary>
    /// Серіалізація масиву альбомів у JSON та збереження у файл
    /// </summary>
    private static void SerializeAndSave(List<MusicAlbum> albums)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(albums, options);
        File.WriteAllText(FileName, json);
        Console.WriteLine($"\n✓ Масив альбомів серіалізовано та збережено у файл: {FileName}");
    }

    /// <summary>
    /// Завантаження та десеріалізація масиву альбомів з файлу
    /// </summary>
    private static List<MusicAlbum> LoadAndDeserialize()
    {
        if (!File.Exists(FileName))
        {
            throw new FileNotFoundException($"Файл {FileName} не знайдено");
        }

        string json = File.ReadAllText(FileName);
        List<MusicAlbum>? albums = JsonSerializer.Deserialize<List<MusicAlbum>>(json);

        if (albums == null)
        {
            throw new InvalidOperationException("Помилка десеріалізації масиву альбомів");
        }

        Console.WriteLine($"\n✓ Масив альбомів завантажено та десеріалізовано з файлу: {FileName}");
        return albums;
    }
}

