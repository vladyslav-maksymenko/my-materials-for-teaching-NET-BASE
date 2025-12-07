using System;

namespace Module7ConsoleApp
{
    // ============================================
    // Клас для тестування практичних завдань
    // ============================================
    
    class TasksTesting
    {
        public static void RunAllTests()
        {
            Console.WriteLine("=== ПРАКТИЧНІ ЗАВДАННЯ ===\n");

            TestTask1();
            TestTask2();
            TestTask3();
            TestTask4();
            TestTask5();

            Console.WriteLine("\n=== КІНЕЦЬ ТЕСТУВАННЯ ПРАКТИЧНИХ ЗАВДАНЬ ===");
        }

        // ============================================
        // ЗАВДАННЯ 1: Тестування IOutput
        // ============================================
        static void TestTask1()
        {
            Console.WriteLine("--- ЗАВДАННЯ 1: Інтерфейс IOutput ---");
            Array arr = new Array(5, 2, 8, 1, 9, 3);

            Console.WriteLine("\nМетод Show() без параметрів:");
            arr.Show();

            Console.WriteLine("\nМетод Show(string info) з параметром:");
            arr.Show("Масив чисел");

            Console.WriteLine("\nТестування з порожнім масивом:");
            Array emptyArr = new Array();
            emptyArr.Show();
            emptyArr.Show("Порожній масив");

            Console.WriteLine("\n" + new string('-', 50) + "\n");
        }

        // ============================================
        // ЗАВДАННЯ 2: Тестування IMath
        // ============================================
        static void TestTask2()
        {
            Console.WriteLine("--- ЗАВДАННЯ 2: Інтерфейс IMath ---");
            Array arr = new Array(5, 2, 8, 1, 9, 3, 7);

            arr.Show("Початковий масив");

            Console.WriteLine($"\nМаксимум: {arr.Max()}");
            Console.WriteLine($"Мінімум: {arr.Min()}");
            Console.WriteLine($"Середнє арифметичне: {arr.Avg():F2}");

            int searchValue = 8;
            bool found = arr.Search(searchValue);
            Console.WriteLine($"Пошук значення {searchValue}: {(found ? "Знайдено ✓" : "Не знайдено ✗")}");

            int searchValue2 = 10;
            bool found2 = arr.Search(searchValue2);
            Console.WriteLine($"Пошук значення {searchValue2}: {(found2 ? "Знайдено ✓" : "Не знайдено ✗")}");

            Console.WriteLine("\nТестування з одним елементом:");
            Array singleArr = new Array(42);
            singleArr.Show();
            Console.WriteLine($"Максимум = Мінімум = Середнє = {singleArr.Max()}");

            Console.WriteLine("\n" + new string('-', 50) + "\n");
        }

        // ============================================
        // ЗАВДАННЯ 3: Тестування ISort
        // ============================================
        static void TestTask3()
        {
            Console.WriteLine("--- ЗАВДАННЯ 3: Інтерфейс ISort ---");
            Array arr = new Array(5, 2, 8, 1, 9, 3, 7);

            arr.Show("Початковий масив");

            // Сортування за зростанням
            arr.SortAsc();
            arr.Show("Після сортування за зростанням (SortAsc)");

            // Сортування за спаданням
            arr.SortDesc();
            arr.Show("Після сортування за спаданням (SortDesc)");

            // Сортування за параметром (за зростанням)
            arr.SortByParam(true);
            arr.Show("Після сортування за параметром (isAsc = true)");

            // Сортування за параметром (за спаданням)
            arr.SortByParam(false);
            arr.Show("Після сортування за параметром (isAsc = false)");

            Console.WriteLine("\nТестування з масивом, що вже відсортований:");
            Array sortedArr = new Array(1, 2, 3, 4, 5);
            sortedArr.Show("Відсортований масив");
            sortedArr.SortDesc();
            sortedArr.Show("Після SortDesc");

            Console.WriteLine("\n" + new string('-', 50) + "\n");
        }

        // ============================================
        // ЗАВДАННЯ 4: Тестування IShape
        // ============================================
        static void TestTask4()
        {
            Console.WriteLine("--- ЗАВДАННЯ 4: Інтерфейс IShape ---");

            IShape[] shapes = new IShape[]
            {
                new Circle(5.0),
                new Rectangle(4.0, 6.0),
                new Triangle(3.0, 4.0, 5.0),
                new Circle(10.0),
                new Rectangle(2.5, 3.5)
            };

            Console.WriteLine("\nОбчислення площі та периметра для різних фігур:\n");

            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape}:");
                Console.WriteLine($"  Площа: {shape.CalculateArea():F2}");
                Console.WriteLine($"  Периметр: {shape.CalculatePerimeter():F2}");
                Console.WriteLine();
            }

            // Демонстрація поліморфізму через інтерфейсне посилання
            Console.WriteLine("Демонстрація поліморфізму через інтерфейсне посилання:");
            IShape shapeRef = new Circle(7.0);
            Console.WriteLine($"Площа кола через IShape: {shapeRef.CalculateArea():F2}");

            shapeRef = new Rectangle(5.0, 8.0);
            Console.WriteLine($"Площа прямокутника через IShape: {shapeRef.CalculateArea():F2}");

            Console.WriteLine("\n" + new string('-', 50) + "\n");
        }

        // ============================================
        // ЗАВДАННЯ 5: Тестування IDrivable
        // ============================================
        static void TestTask5()
        {
            Console.WriteLine("--- ЗАВДАННЯ 5: Інтерфейс IDrivable ---");

            IDrivable car = new Car("Toyota", "Camry");
            IDrivable motorcycle = new Motorcycle("Honda", "CBR600");

            Console.WriteLine("\n--- Тестування автомобіля ---");
            car.StartEngine();
            car.Drive();
            car.StopEngine();

            Console.WriteLine("\n--- Тестування мотоцикла ---");
            motorcycle.StartEngine();
            motorcycle.Drive();
            motorcycle.StopEngine();

            Console.WriteLine("\n--- Спроба їхати без запуску двигуна ---");
            IDrivable car2 = new Car("BMW", "X5");
            car2.Drive();

            Console.WriteLine("\n--- Спроба запустити вже запущений двигун ---");
            IDrivable motorcycle2 = new Motorcycle("Yamaha", "R1");
            motorcycle2.StartEngine();
            motorcycle2.StartEngine(); // Спроба запустити знову

            Console.WriteLine("\n--- Спроба зупинити вже зупинений двигун ---");
            motorcycle2.StopEngine();
            motorcycle2.StopEngine(); // Спроба зупинити знову

            Console.WriteLine("\n--- Демонстрація поліморфізму ---");
            IDrivable[] vehicles = new IDrivable[]
            {
                new Car("Mercedes", "E-Class"),
                new Motorcycle("Kawasaki", "Ninja"),
                new Car("Audi", "A4")
            };

            foreach (var vehicle in vehicles)
            {
                vehicle.StartEngine();
                vehicle.Drive();
                vehicle.StopEngine();
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}
