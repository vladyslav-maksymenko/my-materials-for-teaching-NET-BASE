using System;
using System.Linq;

namespace Module7ConsoleApp
{
    // ============================================
    // ЗАВДАННЯ 1: Інтерфейс IOutput
    // ============================================
    
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    // ============================================
    // ЗАВДАННЯ 2: Інтерфейс IMath
    // ============================================
    
    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }

    // ============================================
    // ЗАВДАННЯ 3: Інтерфейс ISort
    // ============================================
    
    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    // ============================================
    // Клас Array з реалізацією всіх інтерфейсів
    // ============================================
    
    class Array : IOutput, IMath, ISort
    {
        private int[] _elements;

        public Array(params int[] elements)
        {
            _elements = elements ?? new int[0];
        }

        public int Length => _elements.Length;

        // Реалізація IOutput
        public void Show()
        {
            Console.Write("Елементи масиву: ");
            if (_elements.Length == 0)
            {
                Console.WriteLine("(масив порожній)");
                return;
            }

            for (int i = 0; i < _elements.Length; i++)
            {
                Console.Write(_elements[i]);
                if (i < _elements.Length - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine($"=== {info} ===");
            Show();
        }

        // Реалізація IMath
        public int Max()
        {
            if (_elements.Length == 0)
                throw new InvalidOperationException("Масив порожній");

            int max = _elements[0];
            for (int i = 1; i < _elements.Length; i++)
            {
                if (_elements[i] > max)
                    max = _elements[i];
            }
            return max;
        }

        public int Min()
        {
            if (_elements.Length == 0)
                throw new InvalidOperationException("Масив порожній");

            int min = _elements[0];
            for (int i = 1; i < _elements.Length; i++)
            {
                if (_elements[i] < min)
                    min = _elements[i];
            }
            return min;
        }

        public float Avg()
        {
            if (_elements.Length == 0)
                throw new InvalidOperationException("Масив порожній");

            int sum = 0;
            foreach (int element in _elements)
            {
                sum += element;
            }
            return (float)sum / _elements.Length;
        }

        public bool Search(int valueToSearch)
        {
            foreach (int element in _elements)
            {
                if (element == valueToSearch)
                    return true;
            }
            return false;
        }

        // Реалізація ISort
        public void SortAsc()
        {
            System.Array.Sort(_elements);
        }

        public void SortDesc()
        {
            System.Array.Sort(_elements);
            System.Array.Reverse(_elements);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }

    // ============================================
    // ЗАВДАННЯ 4: Інтерфейс IShape
    // ============================================
    
    interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Коло (радіус: {Radius})";
        }
    }

    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Прямокутник ({Width} x {Height})";
        }
    }

    class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            // Формула Герона
            double s = CalculatePerimeter() / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override string ToString()
        {
            return $"Трикутник ({SideA}, {SideB}, {SideC})";
        }
    }

    // ============================================
    // ЗАВДАННЯ 5: Інтерфейс IDrivable
    // ============================================
    
    interface IDrivable
    {
        void StartEngine();
        void StopEngine();
        void Drive();
    }

    class Car : IDrivable
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        private bool _engineRunning = false;

        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public void StartEngine()
        {
            if (_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Двигун вже запущений");
                return;
            }
            _engineRunning = true;
            Console.WriteLine($"{Brand} {Model}: Двигун запущено");
        }

        public void StopEngine()
        {
            if (!_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Двигун вже зупинений");
                return;
            }
            _engineRunning = false;
            Console.WriteLine($"{Brand} {Model}: Двигун зупинено");
        }

        public void Drive()
        {
            if (!_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Спочатку запустіть двигун!");
                return;
            }
            Console.WriteLine($"{Brand} {Model}: Їдемо по дорозі...");
        }
    }

    class Motorcycle : IDrivable
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        private bool _engineRunning = false;

        public Motorcycle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public void StartEngine()
        {
            if (_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Двигун вже запущений");
                return;
            }
            _engineRunning = true;
            Console.WriteLine($"{Brand} {Model}: Двигун запущено (мотоцикл)");
        }

        public void StopEngine()
        {
            if (!_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Двигун вже зупинений");
                return;
            }
            _engineRunning = false;
            Console.WriteLine($"{Brand} {Model}: Двигун зупинено");
        }

        public void Drive()
        {
            if (!_engineRunning)
            {
                Console.WriteLine($"{Brand} {Model}: Спочатку запустіть двигун!");
                return;
            }
            Console.WriteLine($"{Brand} {Model}: Їдемо на мотоциклі...");
        }
    }
}
