using System;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: АБСТРАКТНІ КЛАСИ
    // ============================================
    // Теорія: README.md - розділ "Абстрактний клас"
    // Демонструє:
    // - Створення абстрактних класів
    // - Абстрактні методи (без реалізації)
    // - Реалізацію абстрактних методів в похідних класах
    // - Комбінацію абстрактних та звичайних методів
    // - Віртуальні методи в абстрактних класах
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Абстрактний клас з абстрактними методами
    // ============================================
    
    // Абстрактний клас - не можна створити об'єкт
    public abstract class Animal
    {
        // Звичайна властивість з реалізацією
        public string Name { get; set; }
        public int Age { get; set; }
        
        // Абстрактний метод - без реалізації, повинен бути реалізований в похідних класах
        public abstract void MakeSound();
        
        // Абстрактний метод
        public abstract void Move();
        
        // Звичайний метод з реалізацією
        public void Sleep()
        {
            Console.WriteLine($"{Name} спить");
        }
        
        // Віртуальний метод - може бути перевизначений
        public virtual void Eat()
        {
            Console.WriteLine($"{Name} їсть");
        }
    }
    
    // Похідний клас - повинен реалізувати всі абстрактні методи
    public class Dog : Animal
    {
        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        // Реалізація абстрактного методу
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} гавкає: Гав-гав!");
        }
        
        // Реалізація абстрактного методу
        public override void Move()
        {
            Console.WriteLine($"{Name} біжить на чотирьох лапах");
        }
        
        // Перевизначення віртуального методу (необов'язково)
        public override void Eat()
        {
            base.Eat();
            Console.WriteLine($"{Name} їсть з миски");
        }
    }
    
    public class Cat : Animal
    {
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} мяукає: Мяу!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{Name} крадеться тихо");
        }
    }
    
    public class Bird : Animal
    {
        public Bird(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} співає: Чик-чирик!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{Name} літає");
        }
    }
    
    // ============================================
    // ПРИКЛАД 2: Абстрактний клас для фігур
    // ============================================
    
    public abstract class ShapeAbstract
    {
        public string Color { get; set; }
        
        // Абстрактний метод для обчислення площі
        public abstract double CalculateArea();
        
        // Абстрактний метод для обчислення периметра
        public abstract double CalculatePerimeter();
        
        // Звичайний метод
        public void DisplayColor()
        {
            Console.WriteLine($"Колір фігури: {Color}");
        }
        
        // Віртуальний метод
        public virtual void Draw()
        {
            Console.WriteLine($"Малювання фігури кольору {Color}");
        }
    }
    
    public class CircleAbstract : ShapeAbstract
    {
        public double Radius { get; set; }
        
        public CircleAbstract(double radius, string color)
        {
            Radius = radius;
            Color = color;
        }
        
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Малювання кола з радіусом {Radius} кольору {Color}");
        }
    }
    
    public class RectangleAbstract : ShapeAbstract
    {
        public double Width { get; set; }
        public double Height { get; set; }
        
        public RectangleAbstract(double width, double height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }
        
        public override double CalculateArea()
        {
            return Width * Height;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Малювання прямокутника {Width}x{Height} кольору {Color}");
        }
    }
    
    // ============================================
    // ПРИКЛАД 3: Абстрактний клас для транспортних засобів
    // ============================================
    
    public abstract class Vehicle
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public int MaxSpeed { get; set; }
        
        // Абстрактні методи
        public abstract void Start();
        public abstract void Stop();
        public abstract void Accelerate();
        
        // Звичайні методи
        public void DisplayInfo()
        {
            Console.WriteLine($"Марка: {Brand}, Рік: {Year}, Макс. швидкість: {MaxSpeed} км/год");
        }
        
        // Віртуальний метод
        public virtual void Maintenance()
        {
            Console.WriteLine("Проведення технічного обслуговування");
        }
    }
    
    public class Car : Vehicle
    {
        public int Doors { get; set; }
        
        public Car(string brand, int year, int maxSpeed, int doors)
        {
            Brand = brand;
            Year = year;
            MaxSpeed = maxSpeed;
            Doors = doors;
        }
        
        public override void Start()
        {
            Console.WriteLine("Автомобіль заводиться (ключ повернуто)");
        }
        
        public override void Stop()
        {
            Console.WriteLine("Автомобіль зупиняється (натиснуто гальмо)");
        }
        
        public override void Accelerate()
        {
            Console.WriteLine("Автомобіль прискорюється (натиснуто педаль газу)");
        }
        
        public override void Maintenance()
        {
            base.Maintenance();
            Console.WriteLine("Перевірка двигуна, гальм, шин");
        }
    }
    
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }
        
        public Motorcycle(string brand, int year, int maxSpeed, bool hasSidecar)
        {
            Brand = brand;
            Year = year;
            MaxSpeed = maxSpeed;
            HasSidecar = hasSidecar;
        }
        
        public override void Start()
        {
            Console.WriteLine("Мотоцикл заводиться (натиснуто кнопку старту)");
        }
        
        public override void Stop()
        {
            Console.WriteLine("Мотоцикл зупиняється (натиснуто гальмо)");
        }
        
        public override void Accelerate()
        {
            Console.WriteLine("Мотоцикл прискорюється (повернуто ручку газу)");
        }
        
        public override void Maintenance()
        {
            base.Maintenance();
            Console.WriteLine("Перевірка двигуна, ланцюга, гальм");
        }
    }
}

