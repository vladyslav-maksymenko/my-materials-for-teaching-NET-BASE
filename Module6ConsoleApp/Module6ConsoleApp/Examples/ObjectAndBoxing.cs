using System;
using System.Collections;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: OBJECT ТА BOXING/UNBOXING
    // ============================================
    // Теорія: README.md - розділи "Базовий клас Object" та "Пакування та розпакування"
    // Демонструє:
    // - Перевизначення ToString(), Equals(), GetHashCode()
    // - Використання GetType()
    // - Пакування (boxing) типів-значень
    // - Розпакування (unboxing)
    // - Вплив на продуктивність та як уникнути пакування
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Перевизначення методів Object
    // ============================================
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        
        // Перевизначення ToString()
        public override string ToString()
        {
            return $"Person: {Name}, Вік: {Age}, Email: {Email}";
        }
        
        // Перевизначення Equals()
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Person))
                return false;
            
            Person other = (Person)obj;
            return this.Name == other.Name && 
                   this.Age == other.Age && 
                   this.Email == other.Email;
        }
        
        // Перевизначення GetHashCode() - обов'язково при перевизначенні Equals()
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Email);
        }
    }
    
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        
        public override string ToString()
        {
            return $"Student [ID: {Id}] {Name} - {Course}";
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Student))
                return false;
            
            Student other = (Student)obj;
            return this.Id == other.Id;
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
    
    // ============================================
    // ПРИКЛАД 2: Пакування (Boxing)
    // ============================================
    
    public class BoxingExamples
    {
        public static void DemonstrateBoxing()
        {
            Console.WriteLine("=== Демонстрація пакування ===");
            
            // Пакування int в object
            int number = 42;
            object boxed = number;  // пакування
            Console.WriteLine($"Оригінальне значення: {number}");
            Console.WriteLine($"Запаковане значення: {boxed}");
            Console.WriteLine($"Тип запакованого об'єкта: {boxed.GetType()}");
            
            // Пакування структури
            Point point = new Point { X = 10, Y = 20 };
            object boxedPoint = point;  // пакування структури
            Console.WriteLine($"Запакована точка: {boxedPoint}");
            
            // Пакування в ArrayList (застарілий спосіб)
            ArrayList list = new ArrayList();
            list.Add(10);    // пакування int
            list.Add(20);    // пакування int
            list.Add(30);    // пакування int
            Console.WriteLine($"Кількість елементів в ArrayList: {list.Count}");
        }
    }
    
    // ============================================
    // ПРИКЛАД 3: Розпакування (Unboxing)
    // ============================================
    
    public class UnboxingExamples
    {
        public static void DemonstrateUnboxing()
        {
            Console.WriteLine("=== Демонстрація розпакування ===");
            
            // Пакування
            int originalValue = 100;
            object boxed = originalValue;
            
            // Розпакування
            int unboxed = (int)boxed;
            Console.WriteLine($"Оригінальне значення: {originalValue}");
            Console.WriteLine($"Розпаковане значення: {unboxed}");
            
            // Розпакування структури
            Point originalPoint = new Point { X = 5, Y = 15 };
            object boxedPoint = originalPoint;
            Point unboxedPoint = (Point)boxedPoint;
            Console.WriteLine($"Оригінальна точка: X={originalPoint.X}, Y={originalPoint.Y}");
            Console.WriteLine($"Розпакована точка: X={unboxedPoint.X}, Y={unboxedPoint.Y}");
            
            // Помилка при некоректному розпакуванні
            try
            {
                object obj = 42;
                // long value = (long)obj;  // InvalidCastException
                int value = (int)obj;  // OK
                Console.WriteLine($"Успішне розпакування: {value}");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Помилка розпакування: {ex.Message}");
            }
        }
    }
    
    // ============================================
    // ПРИКЛАД 4: Структура для демонстрації boxing/unboxing
    // ============================================
    
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }
    
    // ============================================
    // ПРИКЛАД 5: Проблеми продуктивності
    // ============================================
    
    public class PerformanceComparison
    {
        // Погано: багато пакувань
        public static void BadExample()
        {
            Console.WriteLine("=== Поганий приклад (з пакуванням) ===");
            ArrayList list = new ArrayList();
            
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);  // пакування на кожній ітерації
            }
            
            Console.WriteLine($"Створено {list.Count} елементів з пакуванням");
        }
        
        // Добре: без пакування
        public static void GoodExample()
        {
            Console.WriteLine("=== Хороший приклад (без пакування) ===");
            List<int> list = new List<int>();
            
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);  // без пакування
            }
            
            Console.WriteLine($"Створено {list.Count} елементів без пакування");
        }
    }
    
    // ============================================
    // ПРИКЛАД 6: GetType() та Type
    // ============================================
    
    public class TypeExamples
    {
        public static void DemonstrateGetType()
        {
            Console.WriteLine("=== Демонстрація GetType() ===");
            
            object obj1 = new Person { Name = "Іван", Age = 25 };
            object obj2 = new Student { Id = 1, Name = "Марія" };
            object obj3 = 42;
            object obj4 = "Hello";
            
            Console.WriteLine($"obj1 тип: {obj1.GetType().Name}");
            Console.WriteLine($"obj2 тип: {obj2.GetType().Name}");
            Console.WriteLine($"obj3 тип: {obj3.GetType().Name}");
            Console.WriteLine($"obj4 тип: {obj4.GetType().Name}");
            
            // Перевірка типу
            if (obj1 is Person person)
            {
                Console.WriteLine($"obj1 є Person: {person.Name}");
            }
        }
    }
}

