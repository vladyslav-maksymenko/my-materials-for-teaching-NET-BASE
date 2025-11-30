using System;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: ВІРТУАЛЬНІ МЕТОДИ
    // ============================================
    // Теорія: README.md - розділ "Віртуальні методи"
    // Демонструє:
    // - Що таке віртуальний метод
    // - Необхідність використання віртуальних методів
    // - Перевизначення віртуальних методів (override)
    // - Порівняння virtual vs new (приховування)
    // - Виклик базової реалізації через base
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Віртуальні методи та поліморфізм
    // ============================================
    // Примітка: Класи Shape, Circle, Rectangle для абстрактних класів 
    // визначені в AbstractClasses.cs. Тут використовуємо простіші версії
    // для демонстрації віртуальних методів (не абстрактних)
    
    public class ShapeVirtual
    {
        public string Color { get; set; }
        
        // Віртуальний метод - може бути перевизначений
        public virtual double CalculateArea()
        {
            Console.WriteLine("Обчислення площі базової фігури");
            return 0;
        }
        
        // Віртуальний метод для малювання
        public virtual void Draw()
        {
            Console.WriteLine($"Малювання фігури кольору {Color}");
        }
        
        // Звичайний метод (не віртуальний)
        public void DisplayColor()
        {
            Console.WriteLine($"Колір: {Color}");
        }
    }
    
    public class CircleVirtual : ShapeVirtual
    {
        public double Radius { get; set; }
        
        // Перевизначення віртуального методу
        public override double CalculateArea()
        {
            double area = Math.PI * Radius * Radius;
            Console.WriteLine($"Площа кола з радіусом {Radius}: {area:F2}");
            return area;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Малювання кола з радіусом {Radius} кольору {Color}");
        }
    }
    
    public class RectangleVirtual : ShapeVirtual
    {
        public double Width { get; set; }
        public double Height { get; set; }
        
        public override double CalculateArea()
        {
            double area = Width * Height;
            Console.WriteLine($"Площа прямокутника {Width}x{Height}: {area:F2}");
            return area;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Малювання прямокутника {Width}x{Height} кольору {Color}");
        }
    }
    
    
    // ============================================
    // ПРИКЛАД 2: Порівняння virtual vs new
    // ============================================
    
    public class AnimalVirtual
    {
        // Віртуальний метод
        public virtual void MakeSound()
        {
            Console.WriteLine("Тварина видає звук");
        }
        
        // Звичайний метод (не віртуальний)
        public void Move()
        {
            Console.WriteLine("Тварина рухається");
        }
    }
    
    public class DogVirtual : AnimalVirtual
    {
        // Перевизначення віртуального методу
        public override void MakeSound()
        {
            Console.WriteLine("Гав-гав!");
        }
        
        // Приховування методу (new) - НЕ перевизначення
        public new void Move()
        {
            Console.WriteLine("Собака біжить");
        }
    }
    
    public class CatVirtual : AnimalVirtual
    {
        public override void MakeSound()
        {
            Console.WriteLine("Мяу!");
        }
        
        public new void Move()
        {
            Console.WriteLine("Кіт крадеться");
        }
    }
    
    // ============================================
    // ПРИКЛАД 3: Виклик базової реалізації
    // ============================================
    
    public class BaseLogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine($"[BASE] {DateTime.Now:HH:mm:ss} - {message}");
        }
    }
    
    public class FileLogger : BaseLogger
    {
        public override void Log(string message)
        {
            base.Log(message); // виклик базової реалізації
            Console.WriteLine($"[FILE] Записано в файл: {message}");
        }
    }
    
    public class ConsoleLogger : BaseLogger
    {
        public override void Log(string message)
        {
            base.Log(message);
            Console.WriteLine($"[CONSOLE] Виведено в консоль: {message}");
        }
    }
}

