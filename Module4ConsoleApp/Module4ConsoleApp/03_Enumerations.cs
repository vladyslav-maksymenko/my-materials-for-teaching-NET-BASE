/*
 * МОДУЛЬ 4: ПЕРЕЛІЧУВАННЯ (ENUMERATIONS / ENUM)
 * 
 * ЩО ТАКЕ ПЕРЕЛІЧУВАННЯ?
 * Перелічування (enum) - це тип даних, який визначає набір іменованих констант.
 * Це спосіб створити групу пов'язаних констант зі зрозумілими назвами.
 * 
 * КОЛИ ВИКОРИСТОВУВАТИ ПЕРЕЛІЧУВАННЯ?
 * - Коли потрібно визначити набір фіксованих значень
 * - Коли важлива читабельність коду
 * - Коли потрібно обмежити можливі значення змінної
 * 
 * ОСОБЛИВОСТІ:
 * - За замовчуванням базовий тип - int
 * - Значення починаються з 0 і збільшуються на 1
 * - Можна встановити власні значення
 * - Можна змінити базовий тип
 */

// ============================================
// ПРИКЛАД 1: БАЗОВЕ ОГОЛОШЕННЯ ПЕРЕЛІЧУВАННЯ
// ============================================

public enum DayOfWeek
{
    Monday,    // Значення: 0
    Tuesday,   // Значення: 1
    Wednesday, // Значення: 2
    Thursday,  // Значення: 3
    Friday,    // Значення: 4
    Saturday,  // Значення: 5
    Sunday     // Значення: 6
}

// ============================================
// ПРИКЛАД 2: ПЕРЕЛІЧУВАННЯ З ВЛАСНИМИ ЗНАЧЕННЯМИ
// ============================================

public enum TaskStatus
{
    Pending = 1,    // Починаємо з 1
    InProgress = 2,
    Completed = 3,
    Cancelled = 4
}

public enum TaskPriority
{
    Low = 1,
    Medium = 5,     // Можна пропускати значення
    High,
    Critical = 20
}

// ============================================
// ПРИКЛАД 3: ВСТАНОВЛЕННЯ БАЗОВОГО ТИПУ
// ============================================

// За замовчуванням базовий тип - int
public enum Size : int
{
    Small = 1,
    Medium = 2,
    Large = 3
}

// Можна використовувати інші числові типи
public enum ErrorCode : byte
{
    None = 0,
    FileNotFound = 1,
    AccessDenied = 2,
    InvalidData = 3
}

// ============================================
// ПРИКЛАД 4: ВИКОРИСТАННЯ ПЕРЕЛІЧУВАНЬ
// ============================================

public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public class WeatherExample
{
    public Season CurrentSeason { get; set; }

    public string GetSeasonDescription()
    {
        return CurrentSeason switch
        {
            Season.Spring => "Весна - час цвітіння",
            Season.Summer => "Літо - час відпочинку",
            Season.Autumn => "Осінь - час збору врожаю",
            Season.Winter => "Зима - час снігу",
            _ => "Невідомий сезон"
        };
    }
}

// ============================================
// ПРИКЛАД 5: МЕТОДИ ДЛЯ ПЕРЕЛІЧУВАНЬ
// ============================================

public enum ColorEnum
{
    Red,
    Green,
    Blue,
    Yellow,
    Black,
    White
}

/*
 * ВИКОРИСТАННЯ МЕТОДІВ:
 * 
 * // Отримати всі значення перелічування
 * ColorEnum[] allColors = Enum.GetValues<ColorEnum>();
 * 
 * // Отримати назву значення
 * string name = Enum.GetName<ColorEnum>(ColorEnum.Red); // "Red"
 * 
 * // Перевірити, чи існує значення
 * bool exists = Enum.IsDefined<ColorEnum>(ColorEnum.Red); // true
 * 
 * // Конвертувати рядок в перелічування
    ColorEnum color = Enum.Parse<ColorEnum>("Red");
 * 
 * // Отримати числове значення
 * int value = (int)ColorEnum.Red; // 0
 * 
 * // Конвертувати число в перелічування
 * ColorEnum colorFromInt = (ColorEnum)0; // ColorEnum.Red
 */

// ============================================
// ПРИКЛАД 6: ПРАКТИЧНЕ ЗАСТОСУВАННЯ
// ============================================

public enum UserRole
{
    Guest = 0,
    User = 1,
    Moderator = 2,
    Administrator = 3
}

public class UserExample
{
    public string Name { get; set; } = "";
    public UserRole Role { get; set; }

    public bool CanEdit()
    {
        return Role == UserRole.Moderator || Role == UserRole.Administrator;
    }

    public bool CanDelete()
    {
        return Role == UserRole.Administrator;
    }
}

// ============================================
// ПРИКЛАД 7: ПЕРЕЛІЧУВАННЯ З ФЛАГАМИ (BIT FLAGS)
// ============================================

// Використовується для комбінації значень
[Flags] //Вказує розробникам, що цей enum призначений для комбінування.
public enum Permissions : byte
{
    None = 0,           // 0000 0000
    Read = 1,           // 0000 0001
    Write = 2,          // 0000 0010
    Execute = 4,        // 0000 0100
    Delete = 8          // 0000 1000
}

/*
 * ВИКОРИСТАННЯ ФЛАГІВ:
 * 
 * // Комбінація прав - Оператор | працює як "додавання" перемикачів.
 * Permissions userPermissions = Permissions.Read | Permissions.Write;
 *      0001 (Read)
      | 0010 (Write)
        ------
        0011 (Результат: увімкнено і те, і те)
 * 
 * // Перевірка наявності права
 * bool canRead = userPermissions.HasFlag(Permissions.Read);
 * 
 * // Додавання права
 * userPermissions |= Permissions.Execute;
 * // Було 0011 (Read, Write), стало 0111 (Read, Write, Execute)
 * 
 * // Видалення права
 * userPermissions &= ~Permissions.Write;
 * Беремо Write (0010).
 * Робимо інверсію ~Write: все, що було 0, стає 1, і навпаки (1101). Це називається "маска".
 *      0111 (Наші права: Read, Write, Execute)
       & 1101 (Маска: ВСЕ, КРІМ Write)
        ------
          0101 (Результат: Read, Execute. Write зникло)
 */

// ============================================
// ПРИКЛАД 8: ПЕРЕЛІЧУВАННЯ В СТРУКТУРАХ ТА КЛАСАХ
// ============================================

public struct Order
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Amount { get; set; }
}

public enum OrderStatus
{
    Created,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

/*
 * КЛЮЧОВІ МОМЕНТИ:
 * 
 * 1. Перелічування визначають набір іменованих констант
 * 2. За замовчуванням значення починаються з 0
 * 3. Можна встановити власні значення
 * 4. Можна змінити базовий тип (int, byte, short, long)
 * 5. Enum.GetValues<T>() - отримати всі значення
 * 6. Enum.Parse<T>() - конвертувати рядок в enum
 * 7. Enum.IsDefined<T>() - перевірити існування значення
 * 8. [Flags] дозволяє комбінувати значення (для бітових операцій)
 * 9. Використовуйте enum для обмеження можливих значень
 * 10. Enum покращує читабельність коду
 */

