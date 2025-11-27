/*
 * МОДУЛЬ 4: СТРУКТУРИ (STRUCTURES)
 * 
 * ЩО ТАКЕ СТРУКТУРА?
 * Структура (struct) - це тип даних, схожий на клас, але з важливими відмінностями.
 * Структури є value types (типи-значення), а класи - reference types (типи-посилання).
 * 
 * КОЛИ ВИКОРИСТОВУВАТИ СТРУКТУРИ?
 * - Коли потрібна невелика група пов'язаних даних
 * - Коли важлива продуктивність (структури швидші)
 * - Коли дані не повинні змінюватися часто
 * - Коли не потрібна спадковість
 * 
 * ОСОБЛИВОСТІ:
 * - Структури зберігаються в стеку (швидше)
 * - Структури не можуть бути null (якщо не Nullable)
 * - Структури копіюються при присвоєнні
 * - Структури не підтримують спадковість
 */

// ============================================
// ПРИКЛАД 1: БАЗОВЕ ОГОЛОШЕННЯ СТРУКТУРИ
// ============================================

using System.Xml.Linq;

public struct PointStruct
{
    // Поля структури
    public int X;
    public int Y;

    // Метод структури
    public void Display()
    {
        Console.WriteLine($"Точка: ({X}, {Y})");
    }
}

// ============================================
// ПРИКЛАД 2: СТРУКТУРА З ВЛАСТИВОСТЯМИ
// ============================================

public struct Rectangle
{
    // Властивості структури
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    // Метод для обчислення площі
    public double GetArea()
    {
        return Width * Height;
    }

    // Метод для обчислення периметра
    public double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}

// ============================================
// ПРИКЛАД 3: СТРУКТУРА З КОНСТРУКТОРОМ
// ============================================

public struct PersonStruct
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Конструктор з параметрами
    public PersonStruct(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}");
    }
}

// ============================================
// ПРИКЛАД 4: КОНСТРУКТОР БЕЗ ПАРАМЕТРІВ (C# 10+)
// ============================================

public struct ColorStruct
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    // У C# 10+ можна створювати конструктор без параметрів
    public ColorStruct()
    {
        Red = 0;
        Green = 0;
        Blue = 0;
    }

    // Або можна використовувати default значення
    public ColorStruct(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    public void Display()
    {
        Console.WriteLine($"RGB: ({Red}, {Green}, {Blue})");
    }
}

//public void DoSomething()
//{
//    Dimensions d;
//    // пам'ять виділена, але поля значеннями не ініціалізовані;
//    d = new Dimensions();
//    d.Print(); // Length дорівнює 0, Width дорівнює 0;
//    d.Length += 2;
//    d.Width += 4;
//    d.Print(); // Length дорівнює 2, а Width дорівнює 4;
//}

// ============================================
// ПРИКЛАД 5: СТРУКТУРА З МЕТОДАМИ
// ============================================

public struct Time
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    public Time(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    // Метод для додавання секунд
    public void AddSeconds(int seconds)
    {
        Seconds += seconds;
        if (Seconds >= 60)
        {
            Minutes += Seconds / 60;
            Seconds = Seconds % 60;
        }
        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes = Minutes % 60;
        }
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
    }
}

// ============================================
// ПРИКЛАД 6: ВІДМІННІСТЬ МІЖ СТРУКТУРОЮ ТА КЛАСОМ
// ============================================

// Структура (value type)
public struct StructExample
{
    public int Value { get; set; }
}

// Клас (reference type)
public class ClassExample
{
    public int Value { get; set; }
}

/*
 * ДЕМОНСТРАЦІЯ ВІДМІННОСТЕЙ:
 * 
 * StructExample struct1 = new StructExample { Value = 10 };
 * StructExample struct2 = struct1;  // Копіюється значення
 * struct2.Value = 20;              // struct1.Value залишається 10
 * 
 * ClassExample class1 = new ClassExample { Value = 10 };
 * ClassExample class2 = class1;    // Копіюється посилання
 * class2.Value = 20;               // class1.Value теж стає 20
 */

// ============================================
// ПРИКЛАД 7: ПРАКТИЧНЕ ЗАСТОСУВАННЯ СТРУКТУР
// ============================================

public struct Coordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    // Метод для обчислення відстані (спрощена версія)
    public double DistanceTo(Coordinates other)
    {
        double latDiff = Latitude - other.Latitude;
        double lonDiff = Longitude - other.Longitude;
        return Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff);
    }
}

public struct Money
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
}

/*
 * КЛЮЧОВІ МОМЕНТИ:
 * 
 * 1. Структури - це value types (типи-значення)
 * 2. Структури зберігаються в стеку, що робить їх швидшими
 * 3. При присвоєнні структури створюється копія
 * 4. Структури не можуть бути null (окрім Nullable)
 * 5. Структури не підтримують спадковість
 * 6. Використовуйте структури для невеликих груп даних
 * 7. У C# 10+ можна створювати конструктор без параметрів
 * 8. Всі поля структури повинні бути ініціалізовані перед використанням
 */

