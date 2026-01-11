namespace Module13ConsoleApp.Models;

/// <summary>
/// Клас, що представляє пісню в альбомі
/// </summary>
public class Song
{
    /// <summary>
    /// Назва пісні
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Тривалість пісні в секундах
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// Стиль пісні (жанр)
    /// </summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Повертає тривалість у форматі хв:сек
    /// </summary>
    public string GetFormattedDuration()
    {
        int minutes = Duration / 60;
        int seconds = Duration % 60;
        return $"{minutes}:{seconds:D2}";
    }

    public override string ToString()
    {
        return $"{Title} ({GetFormattedDuration()}) - {Genre}";
    }
}

