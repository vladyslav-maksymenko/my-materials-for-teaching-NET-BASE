using System;

namespace Module8ConsoleApp;

/// <summary>
/// Приклади роботи з записами (Records)
/// </summary>
public static class RecordsExamples
{
    /// <summary>
    /// Приклад 1: Базовий record
    /// </summary>
    public static void BasicRecordExample()
    {
        Console.WriteLine("\n=== Приклад 1: Базовий record ===");
        
        // Створення екземпляра record
        Person person1 = new("Іван", "Петренко", 25);
        Person person2 = new("Іван", "Петренко", 25);

        Console.WriteLine($"Person1: {person1}");
        Console.WriteLine($"Person2: {person2}");
        
        // Records за замовчуванням порівнюються за значенням
        Console.WriteLine($"person1 == person2: {person1 == person2}");
        Console.WriteLine($"person1.Equals(person2): {person1.Equals(person2)}");
    }

    /// <summary>
    /// Приклад 2: Record з методами та властивостями
    /// </summary>
    public static void RecordWithMembersExample()
    {
        Console.WriteLine("\n=== Приклад 2: Record з методами ===");
        
        Student student = new("Олена", "Коваленко", 20, "Комп'ютерні науки");
        Console.WriteLine($"Студент: {student}");
        Console.WriteLine($"Повна інформація: {student.GetFullInfo()}");
    }

    /// <summary>
    /// Приклад 3: Record з модифікатором init та with
    /// </summary>
    public static void RecordWithModifierExample()
    {
        Console.WriteLine("\n=== Приклад 3: Record з 'with' ===");
        
        Product product1 = new("Ноутбук", 25000, "Електроніка");
        Console.WriteLine($"Оригінальний продукт: {product1}");
        
        // Створення копії зі змінами за допомогою 'with'
        Product product2 = product1 with { Price = 23000 };
        Console.WriteLine($"Продукт зі знижкою: {product2}");
        
        Product product3 = product1 with { Category = "Техніка", Price = 24000 };
        Console.WriteLine($"Модифікований продукт: {product3}");
    }

    /// <summary>
    /// Приклад 4: Positional record vs record class
    /// </summary>
    public static void PositionalRecordExample()
    {
        Console.WriteLine("\n=== Приклад 4: Positional record ===");
        
        // Positional record (короткий синтаксис)
        Point point1 = new(10, 20);
        Point point2 = new(10, 20);
        
        Console.WriteLine($"Point1: X={point1.X}, Y={point1.Y}");
        Console.WriteLine($"Point2: X={point2.X}, Y={point2.Y}");
        Console.WriteLine($"point1 == point2: {point1 == point2}");
        
        // Deconstruction
        var (x, y) = point1;
        Console.WriteLine($"Deconstruction: x={x}, y={y}");
    }

    /// <summary>
    /// Приклад 5: Record struct
    /// </summary>
    public static void RecordStructExample()
    {
        Console.WriteLine("\n=== Приклад 5: Record struct ===");
        
        Color color1 = new(255, 0, 0);
        Color color2 = new(255, 0, 0);
        
        Console.WriteLine($"Color1: {color1}");
        Console.WriteLine($"Color2: {color2}");
        Console.WriteLine($"color1 == color2: {color1 == color2}");
        
        // Модифікація через with
        Color color3 = color1 with { Green = 255 };
        Console.WriteLine($"Color3 (червоний + зелений = жовтий): {color3}");
    }

    /// <summary>
    /// Приклад 6: Наслідування в records
    /// </summary>
    public static void RecordInheritanceExample()
    {
        Console.WriteLine("\n=== Приклад 6: Наслідування в records ===");
        
        Employee employee = new("Петро", "Сидоренко", 30, "Розробник", 50000);
        Console.WriteLine($"Працівник: {employee}");
        Console.WriteLine($"Повна інформація: {employee.GetFullInfo()}");
    }
}

// Базовий record
public record Person(string FirstName, string LastName, int Age);

// Record з методами та додатковими властивостями
public record Student(string FirstName, string LastName, int Age, string Major)
{
    public string GetFullInfo() => $"{FirstName} {LastName}, {Age} років, спеціальність: {Major}";
}

// Record з init-only властивостями
public record Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public string Category { get; init; }

    public Product(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}

// Positional record
public record Point(int X, int Y);

// Record struct
public record struct Color(byte Red, byte Green, byte Blue)
{
    public override string ToString() => $"RGB({Red}, {Green}, {Blue})";
}

// Наслідування в records
public record Employee(string FirstName, string LastName, int Age, string Position, decimal Salary) : Person(FirstName, LastName, Age)
{
    public string GetFullInfo() => 
        $"{FirstName} {LastName}, {Age} років, посада: {Position}, зарплата: {Salary} грн";
}

