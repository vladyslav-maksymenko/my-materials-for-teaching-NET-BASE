using System;

namespace Module5ConsoleApp
{
    // ============================================
    // ЗАВДАННЯ 1: Клас Співробітник (Employee)
    // ============================================
    // ШАБЛОН ДЛЯ СТУДЕНТІВ
    // ============================================

    /*
    // Базовий клас Співробітник з попереднього завдання (якщо студенти його не мають)
    public class Employee
    {
        // Додайте поля для співробітника (ім'я, прізвище, посада тощо)
        // Використовуйте властивості (properties) замість публічних полів
        
        // Додайте властивість для заробітної плати
        // public decimal Salary { get; set; }
        
        // Перевантажте оператор + (збільшення зарплати на величину)
        // public static Employee operator +(Employee emp, decimal amount) { }
        
        // Перевантажте оператор - (зменшення зарплати на величину)
        // public static Employee operator -(Employee emp, decimal amount) { }
        
        // Перевантажте оператор == (порівняння зарплат)
        // public static bool operator ==(Employee emp1, Employee emp2) { }
        
        // Перевантажте оператор != (обов'язково разом з ==)
        // public static bool operator !=(Employee emp1, Employee emp2) { }
        
        // Перевантажте оператор < (менша зарплата)
        // public static bool operator <(Employee emp1, Employee emp2) { }
        
        // Перевантажте оператор > (більша зарплата)
        // public static bool operator >(Employee emp1, Employee emp2) { }
        
        // Перевизначте метод Equals
        // public override bool Equals(object obj) { }
        
        // Перевизначте метод GetHashCode (обов'язково при перевизначенні Equals)
        // public override int GetHashCode() { }
    }
    */

    // ============================================
    // ВИРІШЕННЯ ЗАВДАННЯ 1
    // ============================================
    public class Employee
    {
        // Властивості для інформації про співробітника
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        // Властивість для заробітної плати
        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата не може бути від'ємною");
                _salary = value;
            }
        }

        public Employee(string firstName, string lastName, string position, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Salary = salary;
        }

        // Перевантаження оператора + (збільшення зарплати)
        public static Employee operator +(Employee emp, decimal amount)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));

            Employee result = new Employee(emp.FirstName, emp.LastName, emp.Position, emp.Salary);
            result.Salary += amount;
            return result;
        }

        // Перевантаження оператора - (зменшення зарплати)
        public static Employee operator -(Employee emp, decimal amount)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));

            Employee result = new Employee(emp.FirstName, emp.LastName, emp.Position, emp.Salary);
            result.Salary -= amount;
            return result;
        }

        // Перевантаження оператора == (порівняння зарплат)
        public static bool operator ==(Employee? emp1, Employee? emp2)
        {
            if (emp1 is null && emp2 is null)
                return true;
            if (emp1 is null || emp2 is null)
                return false;

            return emp1.Salary == emp2.Salary;
        }

        // Перевантаження оператора != (обов'язково разом з ==)
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Перевантаження оператора < (менша зарплата)
        public static bool operator <(Employee? emp1, Employee? emp2)
        {
            if (emp1 is null || emp2 is null)
                throw new ArgumentNullException();

            return emp1.Salary < emp2.Salary;
        }

        // Перевантаження оператора > (більша зарплата)
        public static bool operator >(Employee? emp1, Employee? emp2)
        {
            if (emp1 is null || emp2 is null)
                throw new ArgumentNullException();

            return emp1.Salary > emp2.Salary;
        }

        // Перевизначення методу Equals
        public override bool Equals(object? obj)
        {
            if (obj is Employee employee)
                return this == employee;
            return false;
        }

        // Перевизначення методу GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Position, Salary);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Position}, Зарплата: {Salary:C}";
        }
    }



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Employee emp1 = new Employee("Vasya", "Kobko", "Main", 20000);
    //        Employee emp2 = new Employee("asgf", "DD", "sf", 40000);

    //        emp1 += 2000;
    //        Console.WriteLine(emp1.Salary);

    //        //if (emp1 != emp2)
    //        //{
    //        //    Console.WriteLine("ss");
    //        //}
    //    }
    //}

    // ============================================
    // ЗАВДАННЯ 2: Клас Матриця (Matrix)
    // ============================================
    // ШАБЛОН ДЛЯ СТУДЕНТІВ
    // ============================================

    /*
    // Базовий клас Матриця з попереднього завдання
    public class Matrix
    {
        // Використовуйте двовимірний масив для зберігання елементів
        // private int[,] _data;
        
        // Властивості для розмірів матриці
        // public int Rows { get; private set; }
        // public int Cols { get; private set; }
        
        // Індексатор для доступу до елементів матриці
        // public int this[int row, int col] { get; set; }
        
        // Перевантажте оператор + (додавання матриць)
        // public static Matrix operator +(Matrix m1, Matrix m2) { }
        
        // Перевантажте оператор - (віднімання матриць)
        // public static Matrix operator -(Matrix m1, Matrix m2) { }
        
        // Перевантажте оператор * (множення матриць)
        // public static Matrix operator *(Matrix m1, Matrix m2) { }
        
        // Перевантажте оператор * (множення матриці на число)
        // public static Matrix operator *(Matrix m, int scalar) { }
        
        // Перевантажте оператор == (рівність матриць)
        // public static bool operator ==(Matrix m1, Matrix m2) { }
        
        // Перевантажте оператор !=
        // public static bool operator !=(Matrix m1, Matrix m2) { }
        
        // Перевизначте Equals та GetHashCode
    }
    */

    // ============================================
    // ВИРІШЕННЯ ЗАВДАННЯ 2
    // ============================================
    public class MatrixTask
    {
        private int[,] _data;
        
        // Властивості для розмірів матриці
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public MatrixTask(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Розміри матриці повинні бути додатними");
            
            Rows = rows;
            Cols = cols;
            _data = new int[rows, cols];
        }

        // Індексатор для доступу до елементів матриці
        public int this[int row, int col]
        {
            get
            {
                ValidateIndex(row, col);
                return _data[row, col];
            }
            set
            {
                ValidateIndex(row, col);
                _data[row, col] = value;
            }
        }

        private void ValidateIndex(int row, int col)
        {
            if (row < 0 || row >= Rows)
                throw new IndexOutOfRangeException($"Рядок {row} виходить за межі");
            if (col < 0 || col >= Cols)
                throw new IndexOutOfRangeException($"Стовпець {col} виходить за межі");
        }

        // Перевантаження оператора + (додавання матриць)
        public static MatrixTask operator +(MatrixTask? m1, MatrixTask? m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці повинні мати однакові розміри");
            
            MatrixTask result = new MatrixTask(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        // Перевантаження оператора - (віднімання матриць)
        public static MatrixTask operator -(MatrixTask? m1, MatrixTask? m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці повинні мати однакові розміри");
            
            MatrixTask result = new MatrixTask(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return result;
        }

        // Перевантаження оператора * (множення матриць)
        public static MatrixTask operator *(MatrixTask? m1, MatrixTask? m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();
            if (m1.Cols != m2.Rows)
                throw new ArgumentException("Кількість стовпців першої матриці повинна дорівнювати кількості рядків другої");
            
            MatrixTask result = new MatrixTask(m1.Rows, m2.Cols);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        sum += m1[i, k] * m2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        // Перевантаження оператора * (множення матриці на число)
        public static MatrixTask operator *(MatrixTask? m, int scalar)
        {
            if (m is null)
                throw new ArgumentNullException();
            
            MatrixTask result = new MatrixTask(m.Rows, m.Cols);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = m[i, j] * scalar;
                }
            }
            return result;
        }

        // Перевантаження оператора == (рівність матриць)
        public static bool operator ==(MatrixTask? m1, MatrixTask? m2)
        {
            if (m1 is null && m2 is null)
                return true;
            if (m1 is null || m2 is null)
                return false;
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                return false;
            
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }
            return true;
        }

        // Перевантаження оператора !=
        public static bool operator !=(MatrixTask m1, MatrixTask m2)
        {
            return !(m1 == m2);
        }

        // Перевизначення Equals
        public override bool Equals(object? obj)
        {
            if (obj is MatrixTask matrix)
                return this == matrix;
            return false;
        }

        // Перевизначення GetHashCode
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Rows.GetHashCode();
            hash = hash * 23 + Cols.GetHashCode();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    hash = hash * 23 + _data[i, j].GetHashCode();
                }
            }
            return hash;
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Append($"{_data[i, j],4}");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }

    // ============================================
    // ЗАВДАННЯ 3: Клас Місто (City)
    // ============================================
    // ШАБЛОН ДЛЯ СТУДЕНТІВ
    // ============================================
    
    /*
    // Базовий клас Місто з попереднього завдання
    public class City
    {
        // Додайте поля для міста (назва, країна тощо)
        // Використовуйте властивості
        
        // Додайте властивість для кількості мешканців
        // public int Population { get; set; }
        
        // Перевантажте оператор + (збільшення кількості мешканців)
        // public static City operator +(City city, int amount) { }
        
        // Перевантажте оператор - (зменшення кількості мешканців)
        // public static City operator -(City city, int amount) { }
        
        // Перевантажте оператор == (порівняння за кількістю мешканців)
        // public static bool operator ==(City c1, City c2) { }
        
        // Перевантажте оператор !=
        // public static bool operator !=(City c1, City c2) { }
        
        // Перевантажте оператор < (менше мешканців)
        // public static bool operator <(City c1, City c2) { }
        
        // Перевантажте оператор > (більше мешканців)
        // public static bool operator >(City c1, City c2) { }
        
        // Перевизначте Equals та GetHashCode
    }
    */

    // ============================================
    // ВИРІШЕННЯ ЗАВДАННЯ 3
    // ============================================
    public class City
    {
        // Властивості для інформації про місто
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        
        // Властивість для кількості мешканців
        private int _population;
        public int Population
        {
            get => _population;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість мешканців не може бути від'ємною");
                _population = value;
            }
        }

        public City(string name, string country, int population)
        {
            Name = name;
            Country = country;
            Population = population;
        }

        // Перевантаження оператора + (збільшення кількості мешканців)
        public static City operator +(City city, int amount)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            
            City result = new City(city.Name, city.Country, city.Population);
            result.Population += amount;
            return result;
        }

        // Перевантаження оператора - (зменшення кількості мешканців)
        public static City operator -(City city, int amount)
        {
            if (city == null)
                throw new ArgumentNullException(nameof(city));
            
            City result = new City(city.Name, city.Country, city.Population);
            result.Population -= amount;
            return result;
        }

        // Перевантаження оператора == (порівняння за кількістю мешканців)
        public static bool operator ==(City? c1, City? c2)
        {
            if (c1 is null && c2 is null)
                return true;
            if (c1 is null || c2 is null)
                return false;
            
            return c1.Population == c2.Population;
        }

        // Перевантаження оператора !=
        public static bool operator !=(City c1, City c2)
        {
            return !(c1 == c2);
        }

        // Перевантаження оператора < (менше мешканців)
        public static bool operator <(City? c1, City? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            return c1.Population < c2.Population;
        }

        // Перевантаження оператора > (більше мешканців)
        public static bool operator >(City? c1, City? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            return c1.Population > c2.Population;
        }

        // Перевизначення Equals
        public override bool Equals(object? obj)
        {
            if (obj is City city)
                return this == city;
            return false;
        }

        // Перевизначення GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Country, Population);
        }

        public override string ToString()
        {
            return $"{Name}, {Country}, Населення: {Population:N0}";
        }
    }

    // ============================================
    // ЗАВДАННЯ 4: Клас Кредитна картка (CreditCard)
    // ============================================
    // ШАБЛОН ДЛЯ СТУДЕНТІВ
    // ============================================
    
    /*
    // Базовий клас Кредитна картка з попереднього завдання
    public class CreditCard
    {
        // Додайте поля для картки (номер, термін дії, CVC тощо)
        // Використовуйте властивості
        
        // Додайте властивість для суми грошей на картці
        // public decimal Balance { get; set; }
        
        // Додайте властивість для CVC коду
        // public string CVC { get; set; }
        
        // Перевантажте оператор + (збільшення суми)
        // public static CreditCard operator +(CreditCard card, decimal amount) { }
        
        // Перевантажте оператор - (зменшення суми)
        // public static CreditCard operator -(CreditCard card, decimal amount) { }
        
        // Перевантажте оператор == (порівняння за CVC кодом)
        // public static bool operator ==(CreditCard c1, CreditCard c2) { }
        
        // Перевантажте оператор !=
        // public static bool operator !=(CreditCard c1, CreditCard c2) { }
        
        // Перевантажте оператор < (менша сума)
        // public static bool operator <(CreditCard c1, CreditCard c2) { }
        
        // Перевантажте оператор > (більша сума)
        // public static bool operator >(CreditCard c1, CreditCard c2) { }
        
        // Перевизначте Equals та GetHashCode
    }
    */

    // ============================================
    // ВИРІШЕННЯ ЗАВДАННЯ 4
    // ============================================
    public class CreditCard
    {
        // Властивості для інформації про картку
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public string CVC { get; set; } = string.Empty;
        
        // Властивість для суми грошей на картці
        private decimal _balance;
        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не може бути від'ємним");
                _balance = value;
            }
        }

        public CreditCard(string cardNumber, DateTime expiryDate, string cvc, decimal balance)
        {
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CVC = cvc;
            Balance = balance;
        }

        // Перевантаження оператора + (збільшення суми)
        public static CreditCard operator +(CreditCard card, decimal amount)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card));
            if (amount < 0)
                throw new ArgumentException("Сума не може бути від'ємною");
            
            CreditCard result = new CreditCard(card.CardNumber, card.ExpiryDate, card.CVC, card.Balance);
            result.Balance += amount;
            return result;
        }

        // Перевантаження оператора - (зменшення суми)
        public static CreditCard operator -(CreditCard card, decimal amount)
        {
            if (card == null)
                throw new ArgumentNullException(nameof(card));
            if (amount < 0)
                throw new ArgumentException("Сума не може бути від'ємною");
            
            CreditCard result = new CreditCard(card.CardNumber, card.ExpiryDate, card.CVC, card.Balance);
            result.Balance -= amount;
            return result;
        }

        // Перевантаження оператора == (порівняння за CVC кодом)
        public static bool operator ==(CreditCard? c1, CreditCard? c2)
        {
            if (c1 is null && c2 is null)
                return true;
            if (c1 is null || c2 is null)
                return false;
            
            return c1.CVC == c2.CVC;
        }

        // Перевантаження оператора !=
        public static bool operator !=(CreditCard c1, CreditCard c2)
        {
            return !(c1 == c2);
        }

        // Перевантаження оператора < (менша сума)
        public static bool operator <(CreditCard? c1, CreditCard? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            return c1.Balance < c2.Balance;
        }

        // Перевантаження оператора > (більша сума)
        public static bool operator >(CreditCard? c1, CreditCard? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            return c1.Balance > c2.Balance;
        }

        // Перевизначення Equals
        public override bool Equals(object? obj)
        {
            if (obj is CreditCard card)
                return this == card;
            return false;
        }

        // Перевизначення GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(CardNumber, ExpiryDate, CVC, Balance);
        }

        public override string ToString()
        {
            return $"Картка: {CardNumber}, CVC: {CVC}, Баланс: {Balance:C}";
        }
    }

    // ============================================
    // ЗАВДАННЯ 5: Клас Currency (Конвертація валют)
    // ============================================
    // ПОВНЕ ВИРІШЕННЯ
    // ============================================
    public class Currency
    {
        // Властивості для назви валюти та курсу обміну
        public string CurrencyName { get; set; } = string.Empty;
        public decimal ExchangeRate { get; set; } // Курс відносно USD (1 USD = ExchangeRate одиниць валюти)
        public decimal Amount { get; set; }

        // Статичні курси обміну (для прикладу)
        private static readonly decimal USD_TO_EUR = 0.85m;
        private static readonly decimal USD_TO_GBP = 0.73m;
        private static readonly decimal EUR_TO_USD = 1.18m;
        private static readonly decimal GBP_TO_USD = 1.37m;

        public Currency(string currencyName, decimal amount)
        {
            CurrencyName = currencyName.ToUpper();
            Amount = amount;
            
            // Встановлюємо курс обміну залежно від валюти
            ExchangeRate = CurrencyName switch
            {
                "USD" => 1.0m,
                "EUR" => USD_TO_EUR,
                "GBP" => USD_TO_GBP,
                _ => throw new ArgumentException($"Невідома валюта: {currencyName}")
            };
        }

        // Неявне перетворення: double -> Currency (USD)
        public static implicit operator Currency(double amount)
        {
            return new Currency("USD", (decimal)amount);
        }

        // Явне перетворення: Currency -> double
        public static explicit operator double(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));
            
            // Конвертуємо в USD, потім в double
            decimal usdAmount = currency.ToUSD();
            return (double)usdAmount;
        }

        // Неявне перетворення: Currency -> decimal (сума в USD)
        public static implicit operator decimal(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));
            
            return currency.ToUSD();
        }

        // Явне перетворення: Currency -> string
        public static explicit operator string(Currency currency)
        {
            if (currency == null)
                throw new ArgumentNullException(nameof(currency));
            
            return $"{currency.Amount} {currency.CurrencyName}";
        }

        // Метод для конвертації в USD
        public decimal ToUSD()
        {
            return CurrencyName switch
            {
                "USD" => Amount,
                "EUR" => Amount * EUR_TO_USD,
                "GBP" => Amount * GBP_TO_USD,
                _ => throw new InvalidOperationException($"Невідома валюта: {CurrencyName}")
            };
        }

        // Метод для конвертації з USD
        public static Currency FromUSD(decimal usdAmount, string targetCurrency)
        {
            decimal amount = targetCurrency.ToUpper() switch
            {
                "USD" => usdAmount,
                "EUR" => usdAmount * USD_TO_EUR,
                "GBP" => usdAmount * USD_TO_GBP,
                _ => throw new ArgumentException($"Невідома валюта: {targetCurrency}")
            };
            
            return new Currency(targetCurrency, amount);
        }

        // Перевантаження оператора + (додавання валют)
        public static Currency operator +(Currency? c1, Currency? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            decimal totalUSD = c1.ToUSD() + c2.ToUSD();
            return FromUSD(totalUSD, c1.CurrencyName);
        }

        // Перевантаження оператора - (віднімання валют)
        public static Currency operator -(Currency? c1, Currency? c2)
        {
            if (c1 is null || c2 is null)
                throw new ArgumentNullException();
            
            decimal totalUSD = c1.ToUSD() - c2.ToUSD();
            return FromUSD(totalUSD, c1.CurrencyName);
        }

        public override string ToString()
        {
            return $"{Amount:F2} {CurrencyName}";
        }
    }

    // ============================================
    // ЗАВДАННЯ 6: Клас Player (Гравець з автоматичним підвищенням рівня)
    // ============================================
    // ПОВНЕ ВИРІШЕННЯ
    // ============================================
    public class Player
    {
        // Автоматичні властивості
        public string Name { get; set; } = string.Empty;
        
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                // Автоматичне підвищення рівня при досягненні порогу
                UpdateLevel();
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            private set => _level = value;
        }

        // Поріг очок для кожного рівня (100 очок на рівень)
        private const int SCORE_PER_LEVEL = 100;

        public Player(string name, int initialScore = 0)
        {
            Name = name;
            Score = initialScore;
            Level = 1;
        }

        // Метод для оновлення рівня на основі очок
        private void UpdateLevel()
        {
            // Розраховуємо новий рівень: Level = (Score / SCORE_PER_LEVEL) + 1
            int newLevel = (_score / SCORE_PER_LEVEL) + 1;
            
            if (newLevel > _level)
            {
                int oldLevel = _level;
                _level = newLevel;
                Console.WriteLine($"🎉 {Name} підвищив рівень з {oldLevel} до {_level}!");
            }
        }

        // Метод для додавання очок
        public void AddScore(int points)
        {
            if (points < 0)
                throw new ArgumentException("Очки не можуть бути від'ємними");
            
            Score += points;
        }

        public override string ToString()
        {
            return $"{Name} - Рівень: {Level}, Очки: {Score}";
        }
    }
}

