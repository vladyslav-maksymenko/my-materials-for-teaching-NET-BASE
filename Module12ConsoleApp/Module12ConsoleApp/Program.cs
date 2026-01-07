using Module12ConsoleApp;

namespace Module12ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Модуль 12. Вступ до LINQ ===\n");

        // Розділ 1: Базові операції LINQ
        DemonstrateBasicOperations();

        // Розділ 2: Робота з колекціями об'єктів
        DemonstrateObjectCollections();

        // Розділ 3: Сортування
        DemonstrateSorting();

        // Розділ 4: Групування
        DemonstrateGrouping();

        // Розділ 5: Агрегація та математичні операції
        DemonstrateAggregation();

        // Розділ 6: Комбіновані запити
        DemonstrateComplexQueries();

        // Розділ 7: Інші корисні операції
        DemonstrateOtherOperations();

        Console.WriteLine("\n\n=== ПРАКТИЧНІ ЗАВДАННЯ ===\n");

        // Частина перша
        PartOne_Task1();
        PartOne_Task2();
        PartOne_Task3();
        PartOne_Task4();

        // Частина друга
        PartTwo_Task1();
        PartTwo_Task2();
        PartTwo_Task3();
        PartTwo_Task4();
        PartTwo_Task5();

        // Частина третя
        PartThree_Task1();
        PartThree_Task2();

        Console.WriteLine("\n=== Натисніть будь-яку клавішу для виходу ===");
        Console.ReadKey();
    }

    // ============================================
    // РОЗДІЛ 1: БАЗОВІ ОПЕРАЦІЇ LINQ
    // ============================================
    static void DemonstrateBasicOperations()
    {
        Console.WriteLine("--- Розділ 1: Базові операції LINQ ---\n");

        // Створюємо масив чисел для прикладів
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        // Приклад 1: Фільтрація (Where) - знайти всі парні числа
        Console.WriteLine("1. Фільтрація: знайти всі парні числа");
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine($"Результат: {string.Join(", ", evenNumbers)}");
        Console.WriteLine();

        // Приклад 2: Проекція (Select) - перетворити числа в їх квадрати
        Console.WriteLine("2. Проекція: перетворити числа в квадрати");
        var squares = numbers.Select(n => n * n);
        Console.WriteLine($"Результат: {string.Join(", ", squares)}");
        Console.WriteLine();

        // Приклад 3: Комбінація Where та Select
        Console.WriteLine("3. Комбінація: парні числа, зведені в квадрат");
        var evenSquares = numbers
            .Where(n => n % 2 == 0)
            .Select(n => n * n);
        Console.WriteLine($"Результат: {string.Join(", ", evenSquares)}");
        Console.WriteLine();

        // Приклад 4: Query Syntax (синтаксис запитів)
        Console.WriteLine("4. Query Syntax: числа більше 5, помножені на 2");
        var queryResult = from n in numbers
                          where n > 5
                          select n * 2;
        Console.WriteLine($"Результат: {string.Join(", ", queryResult)}");
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 2: РОБОТА З КОЛЕКЦІЯМИ ОБ'ЄКТІВ
    // ============================================
    static void DemonstrateObjectCollections()
    {
        Console.WriteLine("--- Розділ 2: Робота з колекціями об'єктів ---\n");

        // Створюємо список студентів
        var students = new List<Student>
        {
            new Student(1, "Ivan Petrov", 20, 2, 85.5, "Computer Science"),
            new Student(2, "Maria Ivanova", 19, 1, 92.0, "Mathematics"),
            new Student(3, "Petro Sidorov", 21, 3, 78.5, "Physics"),
            new Student(4, "Olena Kovalenko", 20, 2, 88.0, "Computer Science"),
            new Student(5, "Andriy Shevchenko", 22, 4, 95.5, "Mathematics"),
            new Student(6, "Natalia Bondarenko", 19, 1, 90.0, "Physics"),
            new Student(7, "Dmytro Melnyk", 21, 3, 82.5, "Computer Science"),
            new Student(8, "Kateryna Tkachenko", 20, 2, 87.0, "Mathematics")
        };

        Console.WriteLine("Всі студенти:");
        foreach (var student in students)
        {
            Console.WriteLine($"  {student}");
        }
        Console.WriteLine();

        // Приклад 1: Фільтрація - студенти з оцінкою вище 85
        Console.WriteLine("1. Студенти з середньою оцінкою вище 85:");
        var excellentStudents = students.Where(s => s.AverageGrade > 85);
        foreach (var student in excellentStudents)
        {
            Console.WriteLine($"  {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 2: Проекція - тільки імена студентів
        Console.WriteLine("2. Список імен всіх студентів:");
        var studentNames = students.Select(s => s.Name);
        foreach (var name in studentNames)
        {
            Console.WriteLine($"  {name}");
        }
        Console.WriteLine();

        // Приклад 3: Комбінована проекція - ім'я та оцінка
        Console.WriteLine("3. Імена та оцінки студентів:");
        var nameAndGrade = students.Select(s => new { s.Name, s.AverageGrade });
        foreach (var item in nameAndGrade)
        {
            Console.WriteLine($"  {item.Name}: {item.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 4: Фільтрація за кількома умовами
        Console.WriteLine("4. Студенти 2-го курсу з оцінкою вище 85:");
        var filteredStudents = students
            .Where(s => s.Course == 2 && s.AverageGrade > 85);
        foreach (var student in filteredStudents)
        {
            Console.WriteLine($"  {student.Name} - Course: {student.Course}, Grade: {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 3: СОРТУВАННЯ
    // ============================================
    static void DemonstrateSorting()
    {
        Console.WriteLine("--- Розділ 3: Сортування ---\n");

        var students = new List<Student>
        {
            new Student(1, "Ivan Petrov", 20, 2, 85.5, "Computer Science"),
            new Student(2, "Maria Ivanova", 19, 1, 92.0, "Mathematics"),
            new Student(3, "Petro Sidorov", 21, 3, 78.5, "Physics"),
            new Student(4, "Olena Kovalenko", 20, 2, 88.0, "Computer Science"),
            new Student(5, "Andriy Shevchenko", 22, 4, 95.5, "Mathematics"),
            new Student(6, "Natalia Bondarenko", 19, 1, 90.0, "Physics")
        };

        // Приклад 1: Сортування за оцінкою (зростання)
        Console.WriteLine("1. Сортування за оцінкою (зростання):");
        var sortedByGrade = students.OrderBy(s => s.AverageGrade);
        foreach (var student in sortedByGrade)
        {
            Console.WriteLine($"  {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 2: Сортування за оцінкою (спадання)
        Console.WriteLine("2. Сортування за оцінкою (спадання):");
        var sortedByGradeDesc = students.OrderByDescending(s => s.AverageGrade);
        foreach (var student in sortedByGradeDesc)
        {
            Console.WriteLine($"  {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 3: Багаторівневе сортування (курс, потім оцінка)
        Console.WriteLine("3. Багаторівневе сортування: спочатку за курсом, потім за оцінкою:");
        var multiSorted = students
            .OrderBy(s => s.Course)
            .ThenByDescending(s => s.AverageGrade);
        foreach (var student in multiSorted)
        {
            Console.WriteLine($"  Course {student.Course}: {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 4: Query Syntax для сортування
        Console.WriteLine("4. Query Syntax: сортування за віком:");
        var sortedByAge = from s in students
                          orderby s.Age
                        select s;
        foreach (var student in sortedByAge)
        {
            Console.WriteLine($"  {student.Name} - Age: {student.Age}");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 4: ГРУПУВАННЯ
    // ============================================
    static void DemonstrateGrouping()
    {
        Console.WriteLine("--- Розділ 4: Групування ---\n");

        var students = new List<Student>
        {
            new Student(1, "Ivan Petrov", 20, 2, 85.5, "Computer Science"),
            new Student(2, "Maria Ivanova", 19, 1, 92.0, "Mathematics"),
            new Student(3, "Petro Sidorov", 21, 3, 78.5, "Physics"),
            new Student(4, "Olena Kovalenko", 20, 2, 88.0, "Computer Science"),
            new Student(5, "Andriy Shevchenko", 22, 4, 95.5, "Mathematics"),
            new Student(6, "Natalia Bondarenko", 19, 1, 90.0, "Physics"),
            new Student(7, "Dmytro Melnyk", 21, 3, 82.5, "Computer Science"),
            new Student(8, "Kateryna Tkachenko", 20, 2, 87.0, "Mathematics")
        };

        // Приклад 1: Групування за курсом
        Console.WriteLine("1. Групування студентів за курсом:");
        var groupedByCourse = students.GroupBy(s => s.Course);
        foreach (var group in groupedByCourse)
        {
            Console.WriteLine($"  Курс {group.Key} ({group.Count()} студентів):");
            foreach (var student in group)
            {
                Console.WriteLine($"    - {student.Name}");
            }
        }
        Console.WriteLine();

        // Приклад 2: Групування за кафедрою
        Console.WriteLine("2. Групування студентів за кафедрою:");
        var groupedByDepartment = students.GroupBy(s => s.Department);
        foreach (var group in groupedByDepartment)
        {
            Console.WriteLine($"  Кафедра: {group.Key} ({group.Count()} студентів):");
            foreach (var student in group)
            {
                Console.WriteLine($"    - {student.Name}");
            }
        }
        Console.WriteLine();

        // Приклад 3: Групування з обчисленням середньої оцінки
        Console.WriteLine("3. Групування за курсом з середньою оцінкою:");
        var groupedWithAverage = students
            .GroupBy(s => s.Course)
            .Select(g => new
            {
                Course = g.Key,
                Count = g.Count(),
                AverageGrade = g.Average(s => s.AverageGrade),
                Students = g.ToList()
            });
        foreach (var group in groupedWithAverage)
        {
            Console.WriteLine($"  Курс {group.Course}: {group.Count} студентів, середня оцінка: {group.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 4: Query Syntax для групування
        Console.WriteLine("4. Query Syntax: групування за кафедрою:");
        var queryGrouped = from s in students
                           group s by s.Department into g
                           select new { Department = g.Key, Count = g.Count(), Students = g };
        foreach (var group in queryGrouped)
        {
            Console.WriteLine($"  {group.Department}: {group.Count} студентів");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 5: АГРЕГАЦІЯ ТА МАТЕМАТИЧНІ ОПЕРАЦІЇ
    // ============================================
    static void DemonstrateAggregation()
    {
        Console.WriteLine("--- Розділ 5: Агрегація та математичні операції ---\n");

        var students = new List<Student>
        {
            new Student(1, "Ivan Petrov", 20, 2, 85.5, "Computer Science"),
            new Student(2, "Maria Ivanova", 19, 1, 92.0, "Mathematics"),
            new Student(3, "Petro Sidorov", 21, 3, 78.5, "Physics"),
            new Student(4, "Olena Kovalenko", 20, 2, 88.0, "Computer Science"),
            new Student(5, "Andriy Shevchenko", 22, 4, 95.5, "Mathematics"),
            new Student(6, "Natalia Bondarenko", 19, 1, 90.0, "Physics")
        };

        int[] numbers = { 10, 20, 30, 40, 50 };

        // Приклад 1: Count - кількість елементів
        Console.WriteLine("1. Кількість студентів:");
        var studentCount = students.Count();
        Console.WriteLine($"  Всього студентів: {studentCount}");
        Console.WriteLine();

        // Приклад 2: Count з умовою
        Console.WriteLine("2. Кількість студентів з оцінкою вище 85:");
        var excellentCount = students.Count(s => s.AverageGrade > 85);
        Console.WriteLine($"  Студентів з оцінкою > 85: {excellentCount}");
        Console.WriteLine();

        // Приклад 3: Sum - сума
        Console.WriteLine("3. Сума чисел:");
        var sum = numbers.Sum();
        Console.WriteLine($"  Сума чисел {string.Join(", ", numbers)} = {sum}");
        Console.WriteLine();

        // Приклад 4: Average - середнє значення
        Console.WriteLine("4. Середня оцінка всіх студентів:");
        var averageGrade = students.Average(s => s.AverageGrade);
        Console.WriteLine($"  Середня оцінка: {averageGrade:F2}");
        Console.WriteLine();

        // Приклад 5: Min та Max
        Console.WriteLine("5. Мінімальна та максимальна оцінка:");
        var minGrade = students.Min(s => s.AverageGrade);
        var maxGrade = students.Max(s => s.AverageGrade);
        Console.WriteLine($"  Мінімальна оцінка: {minGrade:F2}");
        Console.WriteLine($"  Максимальна оцінка: {maxGrade:F2}");
        Console.WriteLine();

        // Приклад 6: First та Last
        Console.WriteLine("6. Перший та останній студент (за ім'ям):");
        var firstStudent = students.OrderBy(s => s.Name).First();
        var lastStudent = students.OrderBy(s => s.Name).Last();
        Console.WriteLine($"  Перший: {firstStudent.Name}");
        Console.WriteLine($"  Останній: {lastStudent.Name}");
        Console.WriteLine();

        // Приклад 7: FirstOrDefault - безпечний спосіб отримати перший елемент
        Console.WriteLine("7. Перший студент з оцінкою > 100 (не існує):");
        var highGradeStudent = students.FirstOrDefault(s => s.AverageGrade > 100);
        if (highGradeStudent == null)
        {
            Console.WriteLine("  Студентів з оцінкою > 100 не знайдено (повернуто null)");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 6: КОМБІНОВАНІ ЗАПИТИ
    // ============================================
    static void DemonstrateComplexQueries()
    {
        Console.WriteLine("--- Розділ 6: Комбіновані запити ---\n");

        var students = new List<Student>
        {
            new Student(1, "Ivan Petrov", 20, 2, 85.5, "Computer Science"),
            new Student(2, "Maria Ivanova", 19, 1, 92.0, "Mathematics"),
            new Student(3, "Petro Sidorov", 21, 3, 78.5, "Physics"),
            new Student(4, "Olena Kovalenko", 20, 2, 88.0, "Computer Science"),
            new Student(5, "Andriy Shevchenko", 22, 4, 95.5, "Mathematics"),
            new Student(6, "Natalia Bondarenko", 19, 1, 90.0, "Physics"),
            new Student(7, "Dmytro Melnyk", 21, 3, 82.5, "Computer Science"),
            new Student(8, "Kateryna Tkachenko", 20, 2, 87.0, "Mathematics")
        };

        // Приклад 1: Складний запит - топ-3 студенти за оцінкою
        Console.WriteLine("1. Топ-3 студенти за середньою оцінкою:");
        var topStudents = students
            .OrderByDescending(s => s.AverageGrade)
            .Take(3);
        foreach (var student in topStudents)
        {
            Console.WriteLine($"  {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 2: Середня оцінка по кожній кафедрі
        Console.WriteLine("2. Середня оцінка по кафедрах:");
        var departmentAverages = students
            .GroupBy(s => s.Department)
            .Select(g => new
            {
                Department = g.Key,
                AverageGrade = g.Average(s => s.AverageGrade),
                StudentCount = g.Count()
            })
            .OrderByDescending(x => x.AverageGrade);
        foreach (var dept in departmentAverages)
        {
            Console.WriteLine($"  {dept.Department}: {dept.AverageGrade:F2} ({dept.StudentCount} студентів)");
        }
        Console.WriteLine();

        // Приклад 3: Студенти з оцінкою вище середньої
        Console.WriteLine("3. Студенти з оцінкою вище загальної середньої:");
        var overallAverage = students.Average(s => s.AverageGrade);
        var aboveAverage = students
            .Where(s => s.AverageGrade > overallAverage)
            .OrderByDescending(s => s.AverageGrade);
        Console.WriteLine($"  Загальна середня оцінка: {overallAverage:F2}");
        foreach (var student in aboveAverage)
        {
            Console.WriteLine($"  {student.Name} - {student.AverageGrade:F2}");
        }
        Console.WriteLine();

        // Приклад 4: Query Syntax для складного запиту
        Console.WriteLine("4. Query Syntax: студенти 2-го та 3-го курсу, відсортовані за оцінкою:");
        var queryResult = from s in students
                          where s.Course == 2 || s.Course == 3
                          orderby s.AverageGrade descending
                          select new { s.Name, s.Course, s.AverageGrade };
        foreach (var item in queryResult)
        {
            Console.WriteLine($"  {item.Name} (Курс {item.Course}) - {item.AverageGrade:F2}");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // РОЗДІЛ 7: ІНШІ КОРИСНІ ОПЕРАЦІЇ
    // ============================================
    static void DemonstrateOtherOperations()
    {
        Console.WriteLine("--- Розділ 7: Інші корисні операції ---\n");

        var products = new List<Product>
        {
            new Product(1, "Laptop", "Electronics", 1500.00m, 10),
            new Product(2, "Mouse", "Electronics", 25.00m, 50),
            new Product(3, "Keyboard", "Electronics", 75.00m, 30),
            new Product(4, "Monitor", "Electronics", 300.00m, 15),
            new Product(5, "Desk", "Furniture", 200.00m, 5),
            new Product(6, "Chair", "Furniture", 150.00m, 8),
            new Product(7, "Table", "Furniture", 250.00m, 3)
        };

        // Приклад 1: Any - перевірка наявності елементів
        Console.WriteLine("1. Any: чи є продукти дорожче 1000?");
        var hasExpensive = products.Any(p => p.Price > 1000);
        Console.WriteLine($"  Результат: {hasExpensive}");
        Console.WriteLine();

        // Приклад 2: All - перевірка, чи всі елементи відповідають умові
        Console.WriteLine("2. All: чи всі продукти мають запас?");
        var allInStock = products.All(p => p.Stock > 0);
        Console.WriteLine($"  Результат: {allInStock}");
        Console.WriteLine();

        // Приклад 3: Distinct - унікальні значення
        Console.WriteLine("3. Distinct: унікальні категорії продуктів:");
        var categories = products.Select(p => p.Category).Distinct();
        foreach (var category in categories)
        {
            Console.WriteLine($"  - {category}");
        }
        Console.WriteLine();

        // Приклад 4: Take та Skip - пагінація
        Console.WriteLine("4. Take/Skip: перші 3 продукти, потім наступні 3:");
        var firstThree = products.Take(3);
        Console.WriteLine("  Перші 3:");
        foreach (var product in firstThree)
        {
            Console.WriteLine($"    {product.Name}");
        }
        var nextThree = products.Skip(3).Take(3);
        Console.WriteLine("  Наступні 3:");
        foreach (var product in nextThree)
        {
            Console.WriteLine($"    {product.Name}");
        }
        Console.WriteLine();

        // Приклад 5: SelectMany - "розгортання" колекцій
        Console.WriteLine("5. SelectMany: всі категорії та продукти в них:");
        var categoryProducts = products
            .GroupBy(p => p.Category)
            .SelectMany(g => g.Select(p => new { Category = g.Key, Product = p.Name }));
        foreach (var item in categoryProducts)
        {
            Console.WriteLine($"  {item.Category}: {item.Product}");
        }
        Console.WriteLine();

        // Приклад 6: Concat - об'єднання колекцій
        Console.WriteLine("6. Concat: об'єднання двох списків:");
        var list1 = new[] { 1, 2, 3 };
        var list2 = new[] { 4, 5, 6 };
        var combined = list1.Concat(list2);
        Console.WriteLine($"  Результат: {string.Join(", ", combined)}");
        Console.WriteLine();

        // Приклад 7: Робота з різними типами колекцій
        Console.WriteLine("7. Робота зі словником:");
        var dict = new Dictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" }
        };
        var valuesStartingWithT = dict.Values.Where(v => v.StartsWith("T"));
        Console.WriteLine($"  Значення, що починаються з 'T': {string.Join(", ", valuesStartingWithT)}");
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // ПРАКТИЧНІ ЗАВДАННЯ - ЧАСТИНА ПЕРША
    // ============================================

    static void PartOne_Task1()
    {
        Console.WriteLine("--- Частина перша. Завдання 1: Масив цілих ---\n");

        int[] numbers = { 15, 8, 23, 42, 7, 14, 56, 91, 28, 35, 49, 63, 77, 21, 84 };

        Console.WriteLine("1. Отримати весь масив цілих:");
        var allNumbers = numbers.Select(n => n);
        Console.WriteLine($"   Результат: {string.Join(", ", allNumbers)}\n");

        Console.WriteLine("2. Отримати парні цілі:");
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine($"   Результат: {string.Join(", ", evenNumbers)}\n");

        Console.WriteLine("3. Отримати непарні цілі:");
        var oddNumbers = numbers.Where(n => n % 2 != 0);
        Console.WriteLine($"   Результат: {string.Join(", ", oddNumbers)}\n");

        int threshold = 30;
        Console.WriteLine($"4. Отримати значення більше {threshold}:");
        var greaterThan = numbers.Where(n => n > threshold);
        Console.WriteLine($"   Результат: {string.Join(", ", greaterThan)}\n");

        int min = 20, max = 50;
        Console.WriteLine($"5. Отримати числа в діапазоні [{min}, {max}]:");
        var inRange = numbers.Where(n => n >= min && n <= max);
        Console.WriteLine($"   Результат: {string.Join(", ", inRange)}\n");

        Console.WriteLine("6. Отримати числа кратні семи (відсортовані за зростанням):");
        var multiplesOf7 = numbers.Where(n => n % 7 == 0).OrderBy(n => n);
        Console.WriteLine($"   Результат: {string.Join(", ", multiplesOf7)}\n");

        Console.WriteLine("7. Отримати числа кратні восьми (відсортовані за спаданням):");
        var multiplesOf8 = numbers.Where(n => n % 8 == 0).OrderByDescending(n => n);
        Console.WriteLine($"   Результат: {string.Join(", ", multiplesOf8)}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartOne_Task2()
    {
        Console.WriteLine("--- Частина перша. Завдання 2: Масив міст ---\n");

        string[] cities = { "Kyiv", "Lviv", "Odessa", "Kharkiv", "Amsterdam", "Athens", "Berlin", "Rome", "Naples", "New York", "Nairobi", "Nuremberg", "Netherlands" };

        Console.WriteLine("1. Отримати весь масив міст:");
        var allCities = cities.Select(c => c);
        Console.WriteLine($"   Результат: {string.Join(", ", allCities)}\n");

        int length = 6;
        Console.WriteLine($"2. Отримати міста з довжиною назви {length}:");
        var citiesWithLength = cities.Where(c => c.Length == length);
        Console.WriteLine($"   Результат: {string.Join(", ", citiesWithLength)}\n");

        Console.WriteLine("3. Отримати міста, назви яких починаються з літери A:");
        var citiesStartingWithA = cities.Where(c => c.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"   Результат: {string.Join(", ", citiesStartingWithA)}\n");

        Console.WriteLine("4. Отримати міста, назви яких закінчуються літерою M:");
        var citiesEndingWithM = cities.Where(c => c.EndsWith("M", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"   Результат: {string.Join(", ", citiesEndingWithM)}\n");

        Console.WriteLine("5. Отримати міста, назви яких починаються з літери N і закінчуються літерою K:");
        var citiesNtoK = cities.Where(c => c.StartsWith("N", StringComparison.OrdinalIgnoreCase) && c.EndsWith("K", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"   Результат: {string.Join(", ", citiesNtoK)}\n");

        Console.WriteLine("6. Отримати міста, назви яких починаються на Ne (відсортовані за спаданням):");
        var citiesStartingWithNe = cities.Where(c => c.StartsWith("Ne", StringComparison.OrdinalIgnoreCase)).OrderByDescending(c => c);
        Console.WriteLine($"   Результат: {string.Join(", ", citiesStartingWithNe)}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartOne_Task3()
    {
        Console.WriteLine("--- Частина перша. Завдання 3: Масив студентів ---\n");

        var students = new List<StudentTask>
        {
            new StudentTask("Boris", "Johnson", 20, "MIT"),
            new StudentTask("Boris", "Petrov", 19, "Oxford"),
            new StudentTask("Ivan", "Brody", 21, "Harvard"),
            new StudentTask("Maria", "Brown", 22, "MIT"),
            new StudentTask("Petro", "Brooks", 18, "Cambridge"),
            new StudentTask("Olena", "Bronson", 23, "Oxford"),
            new StudentTask("Andriy", "Smith", 20, "MIT"),
            new StudentTask("Natalia", "Brogan", 19, "Oxford"),
            new StudentTask("Dmytro", "Williams", 21, "Harvard")
        };

        Console.WriteLine("1. Отримати весь масив студентів:");
        var allStudents = students.Select(s => s);
        foreach (var student in allStudents)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("2. Отримати студентів з ім'ям Boris:");
        var borisStudents = students.Where(s => s.FirstName == "Boris");
        foreach (var student in borisStudents)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("3. Отримати студентів із прізвищем, яке починається з Bro:");
        var broLastName = students.Where(s => s.LastName.StartsWith("Bro", StringComparison.OrdinalIgnoreCase));
        foreach (var student in broLastName)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("4. Отримати студентів, які старші за 19 років:");
        var olderThan19 = students.Where(s => s.Age > 19);
        foreach (var student in olderThan19)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("5. Отримати студентів, які старше 20 років і молодше 23 років:");
        var ageBetween = students.Where(s => s.Age > 20 && s.Age < 23);
        foreach (var student in ageBetween)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("6. Отримати студентів, які навчаються в MIT:");
        var mitStudents = students.Where(s => s.School == "MIT");
        foreach (var student in mitStudents)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("7. Отримати студентів, які навчаються в Oxford і їхній вік старший за 18 років (відсортовані за віком за спаданням):");
        var oxfordOlder18 = students.Where(s => s.School == "Oxford" && s.Age > 18).OrderByDescending(s => s.Age);
        foreach (var student in oxfordOlder18)
        {
            Console.WriteLine($"   {student}");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    static void PartOne_Task4()
    {
        Console.WriteLine("--- Частина перша. Завдання 4: Користувацьке сортування рядків ---\n");

        string[] strings = { "apple", "banana", "kiwi", "orange", "grape", "pear", "watermelon" };

        Console.WriteLine("1. Сортування за кількістю символів (за зростанням):");
        var sortedAsc = strings.OrderBy(s => s.Length);
        foreach (var str in sortedAsc)
        {
            Console.WriteLine($"   {str} ({str.Length} символів)");
        }
        Console.WriteLine();

        Console.WriteLine("2. Сортування за кількістю символів (за спаданням):");
        var sortedDesc = strings.OrderByDescending(s => s.Length);
        foreach (var str in sortedDesc)
        {
            Console.WriteLine($"   {str} ({str.Length} символів)");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // ПРАКТИЧНІ ЗАВДАННЯ - ЧАСТИНА ДРУГА
    // ============================================

    static void PartTwo_Task1()
    {
        Console.WriteLine("--- Частина друга. Завдання 1: Операції з двома масивами цілих ---\n");

        int[] array1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] array2 = { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        Console.WriteLine($"Масив 1: {string.Join(", ", array1)}");
        Console.WriteLine($"Масив 2: {string.Join(", ", array2)}\n");

        Console.WriteLine("1. Різниця двох масивів (елементи першого масиву, яких немає в другому):");
        var difference = array1.Except(array2);
        Console.WriteLine($"   Результат: {string.Join(", ", difference)}\n");

        Console.WriteLine("2. Перетин масивів (елементи, які є спільними в обох масивах):");
        var intersection = array1.Intersect(array2);
        Console.WriteLine($"   Результат: {string.Join(", ", intersection)}\n");

        Console.WriteLine("3. Об'єднання масивів (елементи обох масивів без наявності дублікатів):");
        var union = array1.Union(array2);
        Console.WriteLine($"   Результат: {string.Join(", ", union)}\n");

        Console.WriteLine("4. Вміст першого масиву без повторень:");
        var distinct = array1.Distinct();
        Console.WriteLine($"   Результат: {string.Join(", ", distinct)}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartTwo_Task2()
    {
        Console.WriteLine("--- Частина друга. Завдання 2: Операції з двома масивами автомобілів ---\n");

        var cars1 = new List<Car>
        {
            new Car("Model S", "Tesla", 2020),
            new Car("Camry", "Toyota", 2019),
            new Car("Civic", "Honda", 2021),
            new Car("F-150", "Ford", 2020)
        };

        var cars2 = new List<Car>
        {
            new Car("Model 3", "Tesla", 2022),
            new Car("Corolla", "Toyota", 2021),
            new Car("Accord", "Honda", 2020),
            new Car("Mustang", "Ford", 2021),
            new Car("X5", "BMW", 2020)
        };

        Console.WriteLine("Масив 1:");
        foreach (var car in cars1)
        {
            Console.WriteLine($"   {car}");
        }
        Console.WriteLine();

        Console.WriteLine("Масив 2:");
        foreach (var car in cars2)
        {
            Console.WriteLine($"   {car}");
        }
        Console.WriteLine();

        Console.WriteLine("1. Різниця масивів (критерій - виробник):");
        var difference = cars1.Except(cars2);
        foreach (var car in difference)
        {
            Console.WriteLine($"   {car}");
        }
        Console.WriteLine();

        Console.WriteLine("2. Перетин масивів (критерій - виробник):");
        var intersection = cars1.Intersect(cars2);
        foreach (var car in intersection)
        {
            Console.WriteLine($"   {car}");
        }
        Console.WriteLine();

        Console.WriteLine("3. Об'єднання масивів (критерій - виробник):");
        var union = cars1.Union(cars2);
        foreach (var car in union)
        {
            Console.WriteLine($"   {car}");
        }
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    static void PartTwo_Task3()
    {
        Console.WriteLine("--- Частина друга. Завдання 3: Агрегатні операції ---\n");

        int[] numbers = { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70, 77, 84, 91, 98, 945, 952, 959, 966, 973, 980 };

        Console.WriteLine($"Масив: {string.Join(", ", numbers)}\n");

        Console.WriteLine("1. Добуток елементів масиву:");
        var product = numbers.Aggregate(1, (acc, n) => acc * n);
        Console.WriteLine($"   Результат: {product}\n");

        Console.WriteLine("2. Кількість елементів масиву:");
        var count = numbers.Count();
        Console.WriteLine($"   Результат: {count}\n");

        Console.WriteLine("3. Кількість елементів масиву, кратних 9:");
        var countMultiplesOf9 = numbers.Count(n => n % 9 == 0);
        Console.WriteLine($"   Результат: {countMultiplesOf9}\n");

        Console.WriteLine("4. Кількість елементів масиву, кратних 7 і більших, ніж 945:");
        var countCondition = numbers.Count(n => n % 7 == 0 && n > 945);
        Console.WriteLine($"   Результат: {countCondition}\n");

        Console.WriteLine("5. Сума елементів масиву:");
        var sum = numbers.Sum();
        Console.WriteLine($"   Результат: {sum}\n");

        Console.WriteLine("6. Сума парних елементів масиву:");
        var sumEven = numbers.Where(n => n % 2 == 0).Sum();
        Console.WriteLine($"   Результат: {sumEven}\n");

        Console.WriteLine("7. Мінімум у масиві:");
        var min = numbers.Min();
        Console.WriteLine($"   Результат: {min}\n");

        Console.WriteLine("8. Максимум у масиві:");
        var max = numbers.Max();
        Console.WriteLine($"   Результат: {max}\n");

        Console.WriteLine("9. Середнє значення в масиві:");
        var average = numbers.Average();
        Console.WriteLine($"   Результат: {average:F2}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartTwo_Task4()
    {
        Console.WriteLine("--- Частина друга. Завдання 4: Три перші максимальні та мінімальні елементи ---\n");

        int[] numbers = { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70, 77, 84, 91, 98, 945, 952, 959, 966, 973, 980 };

        Console.WriteLine($"Масив: {string.Join(", ", numbers)}\n");

        Console.WriteLine("1. Три перші максимальні елементи:");
        var top3Max = numbers.OrderByDescending(n => n).Take(3);
        Console.WriteLine($"   Результат: {string.Join(", ", top3Max)}\n");

        Console.WriteLine("2. Три перші мінімальні елементи:");
        var top3Min = numbers.OrderBy(n => n).Take(3);
        Console.WriteLine($"   Результат: {string.Join(", ", top3Min)}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartTwo_Task5()
    {
        Console.WriteLine("--- Частина друга. Завдання 5: Статистика входження ---\n");

        int[] numbers = { 7, 5, 8, 7, 2, 5, 8, 8, 6, 2, 7, 8, 2, 6, 2 };

        Console.WriteLine($"Масив: {string.Join(", ", numbers)}\n");

        Console.WriteLine("1. Статистика входження кожного числа в масив:");
        var stats = numbers.GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count() }).OrderBy(x => x.Number);
        foreach (var stat in stats)
        {
            Console.WriteLine($"   {stat.Number} — {stat.Count} рази");
        }
        Console.WriteLine();

        Console.WriteLine("2. Статистика входження парних чисел у масив:");
        var evenStats = numbers.Where(n => n % 2 == 0).GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count() }).OrderBy(x => x.Number);
        foreach (var stat in evenStats)
        {
            Console.WriteLine($"   {stat.Number} — {stat.Count} рази");
        }
        Console.WriteLine();

        Console.WriteLine("3. Статистика входження парних і непарних чисел у масив:");
        var evenCount = numbers.Count(n => n % 2 == 0);
        var oddCount = numbers.Count(n => n % 2 != 0);
        Console.WriteLine($"   Парні — {evenCount} рази");
        Console.WriteLine($"   Непарні — {oddCount} рази");
        Console.WriteLine();

        Console.WriteLine("===========================================\n");
    }

    // ============================================
    // ПРАКТИЧНІ ЗАВДАННЯ - ЧАСТИНА ТРЕТЯ
    // ============================================

    static void PartThree_Task1()
    {
        Console.WriteLine("--- Частина третя. Завдання 1: Перевірки для масиву цілих ---\n");

        int[] numbers = { 12, 15, 20, 25, 30, 35, 40, 7, -5, 10, 15, 20, 25, 30, 35 };

        Console.WriteLine($"Масив: {string.Join(", ", numbers)}\n");

        Console.WriteLine("1. Перевірка, чи всі елементи в масиві парні (All):");
        var allEven = numbers.All(n => n % 2 == 0);
        Console.WriteLine($"   Результат: {allEven}\n");

        Console.WriteLine("2. Перевірка, чи всі елементи в масиві більші за 10 і менші за 45 (All):");
        var allInRange = numbers.All(n => n > 10 && n < 45);
        Console.WriteLine($"   Результат: {allInRange}\n");

        Console.WriteLine("3. Перевірка, чи є в масиві хоча б один від'ємний елемент (Any):");
        var hasNegative = numbers.Any(n => n < 0);
        Console.WriteLine($"   Результат: {hasNegative}\n");

        Console.WriteLine("4. Перевірка, чи є в масиві хоча б один непарний, негативний елемент (Any):");
        var hasOddNegative = numbers.Any(n => n % 2 != 0 && n < 0);
        Console.WriteLine($"   Результат: {hasOddNegative}\n");

        Console.WriteLine("5. Перевірка, чи є в масиві значення 7 (Contains):");
        var contains7 = numbers.Contains(7);
        Console.WriteLine($"   Результат: {contains7}\n");

        Console.WriteLine("6. Перший елемент більший за 723 (FirstOrDefault):");
        var firstGreater723 = numbers.FirstOrDefault(n => n > 723);
        Console.WriteLine($"   Результат: {(firstGreater723 == 0 ? "не знайдено" : firstGreater723.ToString())}\n");

        Console.WriteLine("7. Останній від'ємний елемент (LastOrDefault):");
        var lastNegative = numbers.LastOrDefault(n => n < 0);
        Console.WriteLine($"   Результат: {(lastNegative == 0 ? "не знайдено" : lastNegative.ToString())}\n");

        Console.WriteLine("===========================================\n");
    }

    static void PartThree_Task2()
    {
        Console.WriteLine("--- Частина третя. Завдання 2: Перевірки для масиву книг ---\n");

        var books = new List<Book>
        {
            new Book("Війна і мир", "Толстой", "Історичний", 1200, 1869),
            new Book("1984", "Орвелл", "Антиутопія", 328, 1949),
            new Book("Гамлет", "Шекспір", "Трагедія", 250, 1603),
            new Book("Макбет", "Шекспір", "Трагедія", 200, 1606),
            new Book("Дон Кіхот", "Сервantes", "Сатира", 863, 1605),
            new Book("Гордість і упередження", "Остін", "Роман", 432, 1813),
            new Book("Дракула", "Стокер", "Жахи", 418, 1897),
            new Book("Франкенштейн", "Шеллі", "Жахи", 280, 1818),
            new Book("Чайка", "Чехов", "Сатира", 150, 1896),
            new Book("Історія України", "Грушевський", "Історичний", 800, 1993),
            new Book("Кобзар", "Шевченко", "Поезія", 200, 2002),
            new Book("Енеїда", "Котляревський", "Сатира", 300, 2002)
        };

        Console.WriteLine("Список книг:");
        foreach (var book in books)
        {
            Console.WriteLine($"   {book}");
        }
        Console.WriteLine();

        Console.WriteLine("1. Перевірка, чи у всіх книг кількість сторінок більша за 100 (All):");
        var allPagesOver100 = books.All(b => b.Pages > 100);
        Console.WriteLine($"   Результат: {allPagesOver100}\n");

        Console.WriteLine("2. Перевірка, чи всі книги мають жанр Історичний або Сатира (All):");
        var allHistoricalOrSatire = books.All(b => b.Genre == "Історичний" || b.Genre == "Сатира");
        Console.WriteLine($"   Результат: {allHistoricalOrSatire}\n");

        Console.WriteLine("3. Перевірка, чи є хоча б одна книга в жанрі Жахи (Any):");
        var hasHorror = books.Any(b => b.Genre == "Жахи");
        Console.WriteLine($"   Результат: {hasHorror}\n");

        Console.WriteLine("4. Перевірка, чи є в масиві хоча б одна книга Шекспіра (Any):");
        var hasShakespeare = books.Any(b => b.Author == "Шекспір");
        Console.WriteLine($"   Результат: {hasShakespeare}\n");

        Console.WriteLine("5. Перевірка, чи є в масиві книги Байрона (Contains через Any):");
        var containsByron = books.Any(b => b.Author == "Байрон");
        Console.WriteLine($"   Результат: {containsByron}\n");

        Console.WriteLine("6. Перша книга з роком випуску 1993 (FirstOrDefault):");
        var first1993 = books.FirstOrDefault(b => b.Year == 1993);
        Console.WriteLine($"   Результат: {(first1993 == null ? "не знайдено" : first1993.ToString())}\n");

        Console.WriteLine("7. Остання книга з роком випуску 2002 (LastOrDefault):");
        var last2002 = books.LastOrDefault(b => b.Year == 2002);
        Console.WriteLine($"   Результат: {(last2002 == null ? "не знайдено" : last2002.ToString())}\n");

        Console.WriteLine("===========================================\n");
    }
}
