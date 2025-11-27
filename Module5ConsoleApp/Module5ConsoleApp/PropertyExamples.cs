using System;

namespace Module5ConsoleApp
{
    // ============================================
    // ПРИКЛАД 1: Повний синтаксис властивості
    // ============================================
    public class PersonFullSyntax
    {
        // Приватне поле (backing field)
        private string _name = string.Empty;
        private int _age;

        // Властивість з повним синтаксисом
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }

        // Властивість з валідацією
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150");
                _age = value;
            }
        }
    }

    // ============================================
    // ПРИКЛАД 2: Автоматичні властивості
    // ============================================
    public class PersonAutoProperty
    {
        // Автоматична властивість - компілятор створює приватне поле автоматично
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
    }

    // ============================================
    // ПРИКЛАД 3: Властивості з різними модифікаторами доступу
    // ============================================
    public class PersonAccessModifiers
    {
        // Публічний get, приватний set
        public string Name { get; private set; } = string.Empty;

        // Публічний get, внутрішній set
        public int Age { get; internal set; }

        // Публічний get, захищений set
        public string Email { get; protected set; } = string.Empty;

        public PersonAccessModifiers(string name)
        {
            Name = name; // Можна встановити в конструкторі
        }

        public void ChangeName(string newName)
        {
            Name = newName; // Можна встановити в методі класу
        }
    }

    // ============================================
    // ПРИКЛАД 4: Властивість тільки для читання
    // ============================================
    public class PersonReadOnly
    {
        private string _id = string.Empty;
        private DateTime _birthDate;

        // Властивість тільки для читання (немає set)
        public string Id
        {
            get { return _id; }
        }

        // Або використовуючи автоматичну властивість з приватним set
        public string Name { get; private set; } = string.Empty;

        // Властивість тільки для читання з обчисленням
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - _birthDate.Year;
                if (_birthDate.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }

        public PersonReadOnly(string id, string name, DateTime birthDate)
        {
            _id = id;
            Name = name;
            _birthDate = birthDate;
        }
    }

    // ============================================
    // ПРИКЛАД 5: Властивість з init аксесором
    // ============================================
    public class PersonInit
    {
        // Властивість з init - можна встановити тільки при створенні об'єкта
        public string Name { get; init; } = string.Empty;
        public int Age { get; init; }
        public string Email { get; init; } = string.Empty;

        // Можна також мати init з валідацією
        private string _phone = string.Empty;
        public string Phone
        {
            get => _phone;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Phone cannot be empty");
                _phone = value;
            }
        }
    }

    // ============================================
    // ПРИКЛАД 6: Обчислювані властивості
    // ============================================
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        // Обчислювана властивість - значення обчислюється на льоту
        public double Area
        {
            get
            {
                return Width * Height;
            }
        }

        // Обчислювана властивість з коротким синтаксисом
        public double Perimeter => 2 * (Width + Height);

        // Обчислювана властивість з логікою
        public bool IsSquare => Width == Height && Width > 0;
    }

    // ============================================
    // ПРИКЛАД 7: Ініціалізація автоматичних властивостей
    // ============================================
    public class PersonInitialized
    {
        // Ініціалізація при оголошенні
        public string Name { get; set; } = "Unknown";
        public int Age { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Ініціалізація з викликом методу
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Ініціалізація з виразом
        public string FullInfo => $"{Name}, {Age} years old";
    }

    // ============================================
    // ПРИКЛАД 8: Властивості з логікою в get/set
    // ============================================
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get
            {
                Console.WriteLine($"Balance accessed: {_balance}");
                return _balance;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                
                Console.WriteLine($"Balance changed from {_balance} to {value}");
                _balance = value;
            }
        }

        public string AccountNumber { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
    }

    // ============================================
    // ПРИКЛАД 9: Властивості з різними типами
    // ============================================
    public class Product
    {
        // Автоматичні властивості різних типів
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public DateTime CreatedDate { get; set; }

        // Властивість з nullable типом
        public string? Description { get; set; }

        // Властивість з колекцією
        public List<string> Tags { get; set; } = new List<string>();

        // Обчислювана властивість з nullable
        public decimal? DiscountedPrice
        {
            get
            {
                // Якщо немає знижки, повертаємо null
                return null; // Приклад - тут може бути логіка знижки
            }
        }
    }

    // ============================================
    // ПРИКЛАД 10: Властивості з init та валідацією
    // ============================================
    public class Student
    {
        // Init властивість з валідацією
        private string _studentId = string.Empty;
        public string StudentId
        {
            get => _studentId;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Student ID cannot be empty");
                if (value.Length < 5)
                    throw new ArgumentException("Student ID must be at least 5 characters");
                _studentId = value;
            }
        }

        public string Name { get; init; } = string.Empty;
        public int Year { get; init; }

        // Init з ініціалізацією за замовчуванням
        public bool IsActive { get; init; } = true;
    }
}

