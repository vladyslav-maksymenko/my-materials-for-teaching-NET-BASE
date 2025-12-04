using System;
using System.Collections;
using System.Collections.Generic;

namespace Module7ConsoleApp
{
    // ============================================
    // ПРИКЛАД 1: Базовий інтерфейс
    // ============================================
    
    // Оголошення простого інтерфейсу
    interface IFlyable
    {
        void Fly();
        double MaxSpeed { get; }
    }

    // Реалізація інтерфейсу в класі
    class Bird : IFlyable
    {
        public string Name { get; set; } = string.Empty;
        public double MaxSpeed => 50.0; // Автоматична властивість

        public void Fly()
        {
            Console.WriteLine($"{Name} летить зі швидкістю до {MaxSpeed} км/год");
        }
    }

    class Airplane : IFlyable
    {
        public string Model { get; set; } = string.Empty;
        public double MaxSpeed => 900.0;

        public void Fly()
        {
            Console.WriteLine($"Літак {Model} летить зі швидкістю до {MaxSpeed} км/год");
        }
    }

    // ============================================
    // ПРИКЛАД 2: Інтерфейс з кількома методами
    // ============================================
    
    interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
        void Draw();
        string Name { get; }
    }

    class Circle : IShape
    {
        public double Radius { get; set; }
        public string Name => "Коло";

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Малюю коло з радіусом {Radius}");
        }
    }

    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name => "Прямокутник";

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public void Draw()
        {
            Console.WriteLine($"Малюю прямокутник {Width}x{Height}");
        }
    }

    // ============================================
    // ПРИКЛАД 3: Інтерфейсні посилання (поліморфізм)
    // ============================================
    
    interface IAnimal
    {
        void MakeSound();
        string Species { get; }
    }

    class Dog : IAnimal
    {
        public string Species => "Собака";
        
        public void MakeSound()
        {
            Console.WriteLine("Гав-гав!");
        }
    }

    class Cat : IAnimal
    {
        public string Species => "Кіт";
        
        public void MakeSound()
        {
            Console.WriteLine("Мяу-мяу!");
        }
    }

    // ============================================
    // ПРИКЛАД 4: Інтерфейсні властивості
    // ============================================
    
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        string Email { get; set; }
    }

    class Student : IPerson
    {
        private string _name = string.Empty;
        private int _age;
        private string _email = string.Empty;

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(Name));
        }

        public int Age
        {
            get => _age;
            set => _age = value > 0 ? value : throw new ArgumentException("Вік має бути додатнім");
        }

        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException(nameof(Email));
        }

        public string StudentId { get; set; } = string.Empty;
    }

    // ============================================
    // ПРИКЛАД 5: Інтерфейсні індексатори
    // ============================================
    
    interface IListContainer
    {
        int this[int index] { get; set; }
        int Count { get; }
        void Add(int item);
    }

    class NumberList : IListContainer
    {
        private List<int> _items = new List<int>();

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _items.Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }

        public int Count => _items.Count;

        public void Add(int item)
        {
            _items.Add(item);
        }
    }

    // ============================================
    // ПРИКЛАД 6: Успадкування інтерфейсів
    // ============================================
    
    interface IMovable
    {
        void Move();
    }

    interface IResizable
    {
        void Resize(double factor);
    }

    // Інтерфейс успадковує два інші інтерфейси
    interface ITransformable : IMovable, IResizable
    {
        void Rotate(double angle);
    }

    class TransformableShape : ITransformable
    {
        public void Move()
        {
            Console.WriteLine("Фігура переміщена");
        }

        public void Resize(double factor)
        {
            Console.WriteLine($"Фігура змінена в {factor} разів");
        }

        public void Rotate(double angle)
        {
            Console.WriteLine($"Фігура повернута на {angle} градусів");
        }
    }

    // ============================================
    // ПРИКЛАД 7: Проблеми приховування імен
    // ============================================
    
    interface IFirst
    {
        void DoSomething();
        void CommonMethod();
    }

    interface ISecond
    {
        void DoSomething();
        void CommonMethod();
    }

    class MultipleInterfaces : IFirst, ISecond
    {
        // Явна реалізація для IFirst
        void IFirst.DoSomething()
        {
            Console.WriteLine("Реалізація IFirst.DoSomething()");
        }

        // Явна реалізація для ISecond
        void ISecond.DoSomething()
        {
            Console.WriteLine("Реалізація ISecond.DoSomething()");
        }

        // Загальна реалізація для обох інтерфейсів
        public void CommonMethod()
        {
            Console.WriteLine("Загальна реалізація CommonMethod()");
        }
    }

    // ============================================
    // ПРИКЛАД 8: Стандартний інтерфейс IComparable<T>
    // ============================================
    
    class Product : IComparable<Product>
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name}: {Price:C}";
        }
    }

    // ============================================
    // ПРИКЛАД 9: Стандартний інтерфейс IDisposable
    // ============================================
    
    class ResourceManager : IDisposable
    {
        private bool _disposed = false;

        public void DoWork()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(ResourceManager));
            
            Console.WriteLine("Виконується робота з ресурсами...");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine("Звільняю ресурси...");
                _disposed = true;
            }
        }
    }

    // ============================================
    // ПРИКЛАД 10: Стандартний інтерфейс IEnumerable<T>
    // ============================================
    
    class NumberCollection : IEnumerable<int>
    {
        private int[] _numbers;

        public NumberCollection(params int[] numbers)
        {
            _numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var number in _numbers)
            {
                yield return number;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // ============================================
    // ПРИКЛАД 11: Стандартний інтерфейс IEquatable<T>
    // ============================================
    
    class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point? other)
        {
            if (other == null) return false;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // ============================================
    // ОСНОВНА ПРОГРАМА
    // ============================================
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== МОДУЛЬ 7: ІНТЕРФЕЙСИ В C# ===\n");

            // ============================================
            // ПРИКЛАД 1: Базовий інтерфейс
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 1: Базовий інтерфейс ---");
            IFlyable bird = new Bird { Name = "Голуб" };
            IFlyable airplane = new Airplane { Model = "Boeing 737" };
            
            bird.Fly();
            airplane.Fly();
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 2: Інтерфейс з кількома методами
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 2: Інтерфейс з кількома методами ---");
            IShape circle = new Circle { Radius = 5.0 };
            IShape rectangle = new Rectangle { Width = 4.0, Height = 6.0 };

            Console.WriteLine($"{circle.Name}:");
            circle.Draw();
            Console.WriteLine($"Площа: {circle.CalculateArea():F2}");
            Console.WriteLine($"Периметр: {circle.CalculatePerimeter():F2}");

            Console.WriteLine($"\n{rectangle.Name}:");
            rectangle.Draw();
            Console.WriteLine($"Площа: {rectangle.CalculateArea():F2}");
            Console.WriteLine($"Периметр: {rectangle.CalculatePerimeter():F2}");
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 3: Інтерфейсні посилання (поліморфізм)
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 3: Інтерфейсні посилання (поліморфізм) ---");
            IAnimal[] animals = new IAnimal[]
            {
                new Dog(),
                new Cat(),
                new Dog()
            };

            foreach (var animal in animals)
            {
                Console.Write($"{animal.Species}: ");
                animal.MakeSound();
            }
            Console.WriteLine();

            // Демонстрація поліморфізму
            ProcessAnimal(new Dog());
            ProcessAnimal(new Cat());
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 4: Інтерфейсні властивості
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 4: Інтерфейсні властивості ---");
            IPerson student = new Student
            {
                Name = "Іван Петренко",
                Age = 20,
                Email = "ivan@example.com"
            };

            Console.WriteLine($"Ім'я: {student.Name}");
            Console.WriteLine($"Вік: {student.Age}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 5: Інтерфейсні індексатори
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 5: Інтерфейсні індексатори ---");
            IListContainer list = new NumberList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            Console.WriteLine($"Кількість елементів: {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"list[{i}] = {list[i]}");
            }

            list[1] = 25;
            Console.WriteLine($"Після зміни: list[1] = {list[1]}");
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 6: Успадкування інтерфейсів
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 6: Успадкування інтерфейсів ---");
            ITransformable shape = new TransformableShape();
            shape.Move();
            shape.Resize(2.5);
            shape.Rotate(45);

            // Можна також використовувати базові інтерфейси
            IMovable movable = shape;
            movable.Move();
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 7: Проблеми приховування імен
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 7: Проблеми приховування імен ---");
            MultipleInterfaces obj = new MultipleInterfaces();
            
            // Явна реалізація - потрібно приведення до типу інтерфейсу
            IFirst first = obj;
            first.DoSomething();

            ISecond second = obj;
            second.DoSomething();

            // Загальна реалізація - можна викликати безпосередньо
            obj.CommonMethod();
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 8: Стандартний інтерфейс IComparable<T>
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 8: Стандартний інтерфейс IComparable<T> ---");
            List<Product> products = new List<Product>
            {
                new Product { Name = "Хліб", Price = 25.50 },
                new Product { Name = "Молоко", Price = 35.00 },
                new Product { Name = "Масло", Price = 120.00 },
                new Product { Name = "Яйця", Price = 45.00 }
            };

            Console.WriteLine("До сортування:");
            foreach (var product in products)
            {
                Console.WriteLine($"  {product}");
            }

            products.Sort();

            Console.WriteLine("\nПісля сортування (за ціною):");
            foreach (var product in products)
            {
                Console.WriteLine($"  {product}");
            }
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 9: Стандартний інтерфейс IDisposable
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 9: Стандартний інтерфейс IDisposable ---");
            using (var resource = new ResourceManager())
            {
                resource.DoWork();
            } // Автоматичний виклик Dispose()

            // Або явний виклик
            var resource2 = new ResourceManager();
            resource2.DoWork();
            resource2.Dispose();
            Console.WriteLine();

            // ============================================
            // ПРИКЛАД 10: Стандартний інтерфейс IEnumerable<T>
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 10: Стандартний інтерфейс IEnumerable<T> ---");
            NumberCollection collection = new NumberCollection(1, 2, 3, 4, 5);

            Console.WriteLine("Елементи колекції:");
            foreach (var number in collection)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n");

            // ============================================
            // ПРИКЛАД 11: Стандартний інтерфейс IEquatable<T>
            // ============================================
            Console.WriteLine("--- ПРИКЛАД 11: Стандартний інтерфейс IEquatable<T> ---");
            Point p1 = new Point { X = 10, Y = 20 };
            Point p2 = new Point { X = 10, Y = 20 };
            Point p3 = new Point { X = 15, Y = 25 };

            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p2 = {p2}");
            Console.WriteLine($"p3 = {p3}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
            Console.WriteLine();

            // ============================================
            // ДОДАТКОВИЙ ПРИКЛАД: Масив інтерфейсних посилань
            // ============================================
            Console.WriteLine("--- ДОДАТКОВИЙ ПРИКЛАД: Масив інтерфейсних посилань ---");
            IFlyable[] flyingObjects = new IFlyable[]
            {
                new Bird { Name = "Орел" },
                new Airplane { Model = "Airbus A320" },
                new Bird { Name = "Сокіл" }
            };

            foreach (var flyingObj in flyingObjects)
            {
                flyingObj.Fly();
            }

            Console.WriteLine("\n=== КІНЕЦЬ ДЕМОНСТРАЦІЇ ===");
        }

        // Допоміжний метод для демонстрації поліморфізму
        static void ProcessAnimal(IAnimal animal)
        {
            Console.WriteLine($"Обробка {animal.Species}...");
            animal.MakeSound();
        }
    }
}
