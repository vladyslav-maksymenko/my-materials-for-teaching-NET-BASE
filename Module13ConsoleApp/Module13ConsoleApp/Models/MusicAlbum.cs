namespace Module13ConsoleApp.Models;

/// <summary>
/// Клас, що представляє музичний альбом
/// </summary>
public class MusicAlbum
{
    /// <summary>
    /// Назва альбому
    /// </summary>
    public string AlbumTitle { get; set; } = string.Empty;

    /// <summary>
    /// Назва виконавця
    /// </summary>
    public string Artist { get; set; } = string.Empty;

    /// <summary>
    /// Рік випуску
    /// </summary>
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Тривалість альбому в секундах
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Студія випуску
    /// </summary>
    public string Studio { get; set; } = string.Empty;

    /// <summary>
    /// Список пісень в альбомі
    /// </summary>
    public List<Song> Songs { get; set; } = new List<Song>();

    /// <summary>
    /// Повертає тривалість у форматі хв:сек
    /// </summary>
    public string GetFormattedDuration()
    {
        int minutes = Duration / 60;
        int seconds = Duration % 60;
        return $"{minutes}:{seconds:D2}";
    }

    /// <summary>
    /// Обчислює загальну тривалість альбому на основі пісень
    /// </summary>
    public void CalculateDurationFromSongs()
    {
        Duration = Songs.Sum(s => s.Duration);
    }

    public override string ToString()
    {
        var result = $"Альбом: {AlbumTitle}\n" +
                    $"Виконавець: {Artist}\n" +
                    $"Рік випуску: {ReleaseYear}\n" +
                    $"Тривалість: {GetFormattedDuration()}\n" +
                    $"Студія: {Studio}";

        if (Songs.Count > 0)
        {
            result += $"\n\nПісні ({Songs.Count}):";
            for (int i = 0; i < Songs.Count; i++)
            {
                result += $"\n{i + 1}. {Songs[i]}";
            }
        }

        return result;
    }
}

