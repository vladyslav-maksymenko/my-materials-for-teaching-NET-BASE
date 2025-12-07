using System;
using System.Collections.Generic;
using System.Linq;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: ЗАПИСИ (RECORDS)
    // ============================================

    // Кейс 1: Модель даних для замовлень
    public record Address(string Street, string City, string PostalCode, string Country = "Україна");

    public record Customer(string Name, string Email, Address Address)
    {
        public string FullAddress => $"{Address.Street}, {Address.City}, {Address.PostalCode}, {Address.Country}";
    }

    public record Order(int OrderId, Customer Customer, List<OrderItem> Items, DateTime OrderDate)
    {
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }

    public record OrderItem(string ProductName, decimal Price, int Quantity);

    // Кейс 2: Система управління студентами
    public record Person(string FirstName, string LastName, DateTime BirthDate)
    {
        public int Age => DateTime.Now.Year - BirthDate.Year - 
                         (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
    }

    public record Student(string FirstName, string LastName, DateTime BirthDate, int StudentId, string Major)
        : Person(FirstName, LastName, BirthDate)
    {
        public string FullName => $"{FirstName} {LastName}";
    }

    public record Teacher(string FirstName, string LastName, DateTime BirthDate, string Subject, int ExperienceYears)
        : Person(FirstName, LastName, BirthDate)
    {
        public string FullName => $"{FirstName} {LastName}";
    }

    // Кейс 3: Система управління продуктами
    public record Product(string Name, decimal Price, string Category, int Stock)
    {
        public bool IsInStock => Stock > 0;
        public bool IsLowStock => Stock > 0 && Stock < 10;
    }

    public record ProductWithDiscount(string Name, decimal Price, string Category, int Stock, decimal DiscountPercent)
        : Product(Name, Price, Category, Stock)
    {
        public decimal DiscountedPrice => Price * (1 - DiscountPercent / 100);
    }

    // Кейс 4: DTO для API
    public record ApiResponse<T>(bool Success, string Message, T? Data = default, int StatusCode = 200);

    public record UserDto(int Id, string Username, string Email, DateTime CreatedAt);

    public record CreateUserRequest(string Username, string Email, string Password);

    // Кейс 5: Система логування
    public record LogEntry(DateTime Timestamp, string Level, string Message, string? Source = null)
    {
        public string FormattedMessage => $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] {Message}" +
                                         (Source != null ? $" (Source: {Source})" : "");
    }

    // Кейс 6: Система координат та геометрії
    public record Point(int X, int Y)
    {
        public double DistanceFromOrigin => Math.Sqrt(X * X + Y * Y);
        
        public double DistanceTo(Point other)
        {
            int dx = X - other.X;
            int dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    public record Rectangle(Point TopLeft, Point BottomRight)
    {
        public int Width => Math.Abs(BottomRight.X - TopLeft.X);
        public int Height => Math.Abs(BottomRight.Y - TopLeft.Y);
        public int Area => Width * Height;
    }

    // Кейс 7: Система налаштувань
    public record AppSettings(string AppName, string Version, bool EnableLogging, int MaxConnections)
    {
        public static AppSettings Default => new AppSettings("MyApp", "1.0.0", true, 100);
    }

    // Кейс 8: Система результатів операцій
    public record OperationResult(bool Success, string Message, object? Data = null)
    {
        public static OperationResult Ok(string message, object? data = null) 
            => new OperationResult(true, message, data);
        
        public static OperationResult Error(string message) 
            => new OperationResult(false, message);
    }

    // Кейс 9: Система фінансів
    public record Transaction(int Id, string Description, decimal Amount, DateTime Date, string Category)
    {
        public bool IsIncome => Amount > 0;
        public bool IsExpense => Amount < 0;
    }

    public record AccountBalance(string AccountName, decimal Balance, string Currency = "UAH")
    {
        public bool IsPositive => Balance >= 0;
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class RecordsExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: ЗАПИСИ (RECORDS)");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: Замовлення
            Console.WriteLine("КЕЙС 1: Модель даних для замовлень");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var address = new Address("Вулиця Хрещатик, 1", "Київ", "01001");
            var customer = new Customer("Іван Петренко", "ivan@example.com", address);
            var items = new List<OrderItem>
            {
                new OrderItem("Ноутбук", 25000, 1),
                new OrderItem("Мишка", 500, 2)
            };
            var order = new Order(12345, customer, items, DateTime.Now);

            Console.WriteLine($"Замовлення #{order.OrderId}");
            Console.WriteLine($"Клієнт: {customer.Name}");
            Console.WriteLine($"Адреса: {customer.FullAddress}");
            Console.WriteLine($"Дата: {order.OrderDate:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Загальна сума: {order.TotalAmount:C}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Порівняння records
            Console.WriteLine("КЕЙС 2: Порівняння records за значеннями");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var point1 = new Point(1, 2);
            var point2 = new Point(1, 2);
            var point3 = new Point(3, 4);

            Console.WriteLine($"point1: {point1}");
            Console.WriteLine($"point2: {point2}");
            Console.WriteLine($"point3: {point3}");
            Console.WriteLine($"\npoint1 == point2: {point1 == point2}"); // True
            Console.WriteLine($"point1 == point3: {point1 == point3}"); // False
            Console.WriteLine($"point1.Equals(point2): {point1.Equals(point2)}"); // True
            Console.WriteLine($"HashCode point1: {point1.GetHashCode()}");
            Console.WriteLine($"HashCode point2: {point2.GetHashCode()}"); // Однаковий

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: Використання with для створення копій
            Console.WriteLine("КЕЙС 3: Використання 'with' для створення копій");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var product1 = new Product("Ноутбук", 25000, "Електроніка", 5);
            Console.WriteLine($"Оригінал: {product1}");

            // Створюємо новий record зі зміненою ціною
            var product2 = product1 with { Price = 23000 };
            Console.WriteLine($"Зі знижкою: {product2}");

            // Змінюємо кілька властивостей
            var product3 = product1 with { Price = 24000, Stock = 10 };
            Console.WriteLine($"Оновлений: {product3}");

            Console.WriteLine($"\nproduct1 == product2: {product1 == product2}"); // False
            Console.WriteLine($"product1 == product3: {product1 == product3}"); // False

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: Наслідування records
            Console.WriteLine("КЕЙС 4: Наслідування records");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var student = new Student("Марія", "Іваненко", new DateTime(2000, 5, 15), 12345, "Комп'ютерні науки");
            var teacher = new Teacher("Петро", "Сидоренко", new DateTime(1980, 3, 20), "Математика", 15);

            Console.WriteLine($"Студент: {student.FullName}, Вік: {student.Age}, ID: {student.StudentId}, Спеціальність: {student.Major}");
            Console.WriteLine($"Вчитель: {teacher.FullName}, Вік: {teacher.Age}, Предмет: {teacher.Subject}, Досвід: {teacher.ExperienceYears} років");

            // Поліморфізм
            Person[] people = { student, teacher };
            Console.WriteLine("\nПоліморфізм:");
            foreach (var person in people)
            {
                Console.WriteLine($"  {person.FirstName} {person.LastName}, {person.Age} років");
            }

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Records у колекціях
            Console.WriteLine("КЕЙС 5: Records у колекціях (HashSet, Dictionary)");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var books = new List<Product>
            {
                new Product("C# для початківців", 500, "Книги", 10),
                new Product("ASP.NET Core", 750, "Книги", 5),
                new Product("C# для початківців", 500, "Книги", 10) // Дублікат
            };

            Console.WriteLine("Всі книги:");
            books.ForEach(b => Console.WriteLine($"  {b}"));

            // HashSet автоматично видаляє дублікати завдяки GetHashCode
            var uniqueBooks = new HashSet<Product>(books);
            Console.WriteLine($"\nУнікальних книг: {uniqueBooks.Count}");

            // Dictionary використовує records як ключі
            var inventory = new Dictionary<Product, int>();
            foreach (var book in uniqueBooks)
            {
                inventory[book] = book.Stock;
            }

            Console.WriteLine("\nІнвентар:");
            foreach (var kvp in inventory)
            {
                Console.WriteLine($"  {kvp.Key.Name}: {kvp.Value} шт.");
            }

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 6: DTO для API
            Console.WriteLine("КЕЙС 6: Records як DTO для API");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var userDto = new UserDto(1, "ivan_petrenko", "ivan@example.com", DateTime.Now.AddDays(-30));
            Console.WriteLine($"UserDto: {userDto}");

            var successResponse = new ApiResponse<UserDto>(true, "Користувач знайдено", userDto, 200);
            Console.WriteLine($"\nSuccess Response: {successResponse}");

            var errorResponse = ApiResponse.Error<UserDto>("Користувач не знайдено", 404);
            Console.WriteLine($"Error Response: {errorResponse}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 7: Геометрія
            Console.WriteLine("КЕЙС 7: Система координат та геометрії");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var origin = new Point(0, 0);
            var pointA = new Point(3, 4);
            var pointB = new Point(6, 8);

            Console.WriteLine($"Точка A: {pointA}");
            Console.WriteLine($"Відстань від початку координат: {pointA.DistanceFromOrigin:F2}");
            Console.WriteLine($"Точка B: {pointB}");
            Console.WriteLine($"Відстань між A і B: {pointA.DistanceTo(pointB):F2}");

            var rectangle = new Rectangle(new Point(0, 0), new Point(5, 3));
            Console.WriteLine($"\nПрямокутник: {rectangle}");
            Console.WriteLine($"Ширина: {rectangle.Width}, Висота: {rectangle.Height}");
            Console.WriteLine($"Площа: {rectangle.Area}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 8: Налаштування та результати операцій
            Console.WriteLine("КЕЙС 8: Налаштування та результати операцій");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var settings = AppSettings.Default;
            Console.WriteLine($"Налаштування за замовчуванням: {settings}");

            var customSettings = settings with { MaxConnections = 200, EnableLogging = false };
            Console.WriteLine($"Кастомні налаштування: {customSettings}");

            var successResult = OperationResult.Ok("Операція виконана успішно", new { Id = 123 });
            Console.WriteLine($"\nУспішний результат: {successResult}");

            var errorResult = OperationResult.Error("Помилка виконання операції");
            Console.WriteLine($"Помилка: {errorResult}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 9: Фінанси
            Console.WriteLine("КЕЙС 9: Система фінансів");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var transactions = new List<Transaction>
            {
                new Transaction(1, "Зарплата", 50000, DateTime.Now.AddDays(-5), "Доходи"),
                new Transaction(2, "Покупка продуктів", -1500, DateTime.Now.AddDays(-3), "Продукти"),
                new Transaction(3, "Оренда", -8000, DateTime.Now.AddDays(-1), "Житло"),
                new Transaction(4, "Фріланс", 10000, DateTime.Now, "Доходи")
            };

            var totalIncome = transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
            var totalExpense = Math.Abs(transactions.Where(t => t.IsExpense).Sum(t => t.Amount));
            var balance = totalIncome - totalExpense;

            Console.WriteLine("Транзакції:");
            transactions.ForEach(t => Console.WriteLine($"  {t.Date:dd.MM.yyyy} | {t.Description} | {t.Amount:C} | {t.Category}"));

            Console.WriteLine($"\nДоходи: {totalIncome:C}");
            Console.WriteLine($"Витрати: {totalExpense:C}");
            Console.WriteLine($"Баланс: {balance:C}");

            var account = new AccountBalance("Основний рахунок", balance);
            Console.WriteLine($"\n{account.AccountName}: {account.Balance:C} {account.Currency}");
            Console.WriteLine($"Позитивний баланс: {account.IsPositive}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }

    // Допоміжний клас для демонстрації
    public static class ApiResponse
    {
        public static ApiResponse<T> Error<T>(string message, int statusCode = 400)
            => new ApiResponse<T>(false, message, default, statusCode);
    }
}

