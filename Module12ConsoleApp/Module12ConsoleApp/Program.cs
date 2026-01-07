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
}
