/*
 * МОДУЛЬ 4: ДЕМОНСТРАЦІЙНА ПРОГРАМА
 * 
 * Ця програма демонструє використання:
 * 1. Просторів імен (Namespaces)
 * 2. Структур (Structures)
 * 3. Перелічувань (Enumerations)
 * 4. Nullable типів
 */

using System;
using Module4ConsoleApp.Examples;

// ============================================
// ДЕМОНСТРАЦІЯ 1: ПРОСТОРИ ІМЕН
// ============================================

namespace Module4ConsoleApp.Examples
{
    namespace Geometry
    {
        public class Circle
        {
            public double Radius { get; set; }
            public double GetArea() => Math.PI * Radius * Radius;
        }
    }

    namespace Geometry
    {
        public class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double GetArea() => Width * Height;
        }
    }
}

// ============================================
// ДЕМОНСТРАЦІЯ 2: СТРУКТУРИ
// ============================================

public struct Point2D
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point2D other)
    {
        int dx = X - other.X;
        int dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString() => $"({X}, {Y})";
}

// ============================================
// ДЕМОНСТРАЦІЯ 3: ПЕРЕЛІЧУВАННЯ
// ============================================

public enum Status
{
    Pending,
    InProgress,
    Completed,
    Cancelled
}

public enum Priority : byte
{
    Low = 1,
    Medium = 2,
    High = 3
}

// ============================================
// ДЕМОНСТРАЦІЯ 4: NULLABLE ТИПИ
// ============================================

public class Task
{
    public string Title { get; set; } = "";
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public int? EstimatedHours { get; set; }  // Nullable - може бути невідомим
    public DateTime? DueDate { get; set; }    // Nullable - може не мати дедлайну
}

// ============================================
// ОСНОВНА ПРОГРАМА
// ============================================

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== МОДУЛЬ 4: ДЕМОНСТРАЦІЯ КОНЦЕПЦІЙ ===\n");

        // ============================================
        // ПРИКЛАД 1: ПРОСТОРИ ІМЕН
        // ============================================
        Console.WriteLine("1. ПРОСТОРИ ІМЕН (NAMESPACES)");
        Console.WriteLine("-------------------------------");
        
        var circle = new Module4ConsoleApp.Examples.Geometry.Circle { Radius = 5 };
        Console.WriteLine($"Коло з радіусом 5: площа = {circle.GetArea():F2}");
        
        var rectangle = new Module4ConsoleApp.Examples.Geometry.Rectangle { Width = 4, Height = 6 };
        Console.WriteLine($"Прямокутник 4x6: площа = {rectangle.GetArea()}");
        Console.WriteLine();

        // ============================================
        // ПРИКЛАД 2: СТРУКТУРИ
        // ============================================
        Console.WriteLine("2. СТРУКТУРИ (STRUCTURES)");
        Console.WriteLine("-------------------------");
        
        Point2D point1 = new Point2D(0, 0);
        Point2D point2 = new Point2D(3, 4);
        
        Console.WriteLine($"Точка 1: {point1}");
        Console.WriteLine($"Точка 2: {point2}");
        Console.WriteLine($"Відстань між точками: {point2.DistanceTo(point1):F2}");
        
        // Демонстрація копіювання структури
        Point2D point3 = point1;  // Копіюється значення
        point3.X = 10;
        Console.WriteLine($"Після зміни point3: point1 = {point1}, point3 = {point3}");
        Console.WriteLine();

        // ============================================
        // ПРИКЛАД 3: ПЕРЕЛІЧУВАННЯ
        // ============================================
        Console.WriteLine("3. ПЕРЕЛІЧУВАННЯ (ENUMERATIONS)");
        Console.WriteLine("------------------------------");
        
        Status taskStatus = Status.InProgress;
        Priority taskPriority = Priority.High;
        
        Console.WriteLine($"Статус задачі: {taskStatus}");
        Console.WriteLine($"Пріоритет: {taskPriority}");
        Console.WriteLine($"Числове значення пріоритету: {(byte)taskPriority}");
        
        // Отримання всіх значень перелічування
        Console.WriteLine("\nВсі можливі статуси:");
        foreach (Status status in Enum.GetValues<Status>())
        {
            Console.WriteLine($"  - {status}");
        }
        Console.WriteLine();

        // ============================================
        // ПРИКЛАД 4: NULLABLE ТИПИ
        // ============================================
        Console.WriteLine("4. NULLABLE ТИПИ");
        Console.WriteLine("----------------");
        
        Task task1 = new Task
        {
            Title = "Вивчити простори імен",
            Status = Status.Completed,
            Priority = Priority.High,
            EstimatedHours = 2,      // Має значення
            DueDate = DateTime.Now.AddDays(1)
        };
        
        Task task2 = new Task
        {
            Title = "Нова задача",
            Status = Status.Pending,
            Priority = Priority.Medium,
            EstimatedHours = null,   // Не встановлено
            DueDate = null           // Немає дедлайну
        };
        
        Console.WriteLine($"Задача 1: {task1.Title}");
        Console.WriteLine($"  Оцінка годин: {task1.EstimatedHours?.ToString() ?? "не встановлено"}");
        Console.WriteLine($"  Дедлайн: {task1.DueDate?.ToString("dd.MM.yyyy") ?? "не встановлено"}");
        
        Console.WriteLine($"\nЗадача 2: {task2.Title}");
        Console.WriteLine($"  Оцінка годин: {task2.EstimatedHours?.ToString() ?? "не встановлено"}");
        Console.WriteLine($"  Дедлайн: {task2.DueDate?.ToString("dd.MM.yyyy") ?? "не встановлено"}");
        
        // Демонстрація операторів
        int? nullableInt = null;
        int result = nullableInt ?? 100;
        Console.WriteLine($"\nПриклад null-coalescing: null ?? 100 = {result}");
        
        nullableInt = 50;
        result = nullableInt ?? 100;
        Console.WriteLine($"Приклад null-coalescing: 50 ?? 100 = {result}");
        Console.WriteLine();

        // ============================================
        // КОМБІНОВАНИЙ ПРИКЛАД
        // ============================================
        Console.WriteLine("5. КОМБІНОВАНИЙ ПРИКЛАД");
        Console.WriteLine("------------------------");
        
        Task[] tasks = new Task[]
        {
            new Task { Title = "Задача 1", Status = Status.Pending, Priority = Priority.Low, EstimatedHours = 1 },
            new Task { Title = "Задача 2", Status = Status.InProgress, Priority = Priority.High, EstimatedHours = null },
            new Task { Title = "Задача 3", Status = Status.Completed, Priority = Priority.Medium, EstimatedHours = 3 }
        };
        
        Console.WriteLine("Список задач:");
        for (int i = 0; i < tasks.Length; i++)
        {
            var task = tasks[i];
            string hours = task.EstimatedHours?.ToString() ?? "не встановлено";
            Console.WriteLine($"  {i + 1}. {task.Title} - {task.Status} ({task.Priority}) - {hours} год.");
        }
        
        Console.WriteLine("\n=== ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА ===");
        
        // Додаткова опція: запуск практичних завдань
        Console.WriteLine("\n\n════════════════════════════════════════════════════════");
        Console.WriteLine("ПРАКТИЧНІ ЗАВДАННЯ");
        Console.WriteLine("════════════════════════════════════════════════════════");
        Console.WriteLine("Натисніть 'P' для запуску практичних завдань");
        Console.WriteLine("Або будь-яку іншу клавішу для виходу...");
        
        var key = Console.ReadKey();
        if (key.KeyChar == 'P' || key.KeyChar == 'p')
        {
            Console.Clear();
            PracticeDemo.PracticeTasksDemo.RunAllTasks();
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
