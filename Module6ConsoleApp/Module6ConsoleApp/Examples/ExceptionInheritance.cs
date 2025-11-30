using System;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: УСПАДКУВАННЯ ВИНЯТКІВ
    // ============================================
    // Теорія: README.md - розділ "Успадкування та винятки"
    // Демонструє:
    // - Створення власних класів винятків
    // - Успадкування від стандартних класів винятків
    // - Ієрархію винятків
    // - Обробку винятків при успадкуванні
    // - Винятки в конструкторах
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Створення власного винятку
    // ============================================
    
    // Власний виняток, успадкований від Exception
    public class CustomException : Exception
    {
        public CustomException() : base()
        {
        }
        
        public CustomException(string message) : base(message)
        {
        }
        
        public CustomException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
    
    // ============================================
    // ПРИКЛАД 2: Виняток для валідації
    // ============================================
    
    public class ValidationException : ArgumentException
    {
        public string FieldName { get; }
        
        public ValidationException(string fieldName, string message) 
            : base(message)
        {
            FieldName = fieldName;
        }
        
        public override string ToString()
        {
            return $"Помилка валідації поля '{FieldName}': {Message}";
        }
    }
    
    // ============================================
    // ПРИКЛАД 3: Виняток для бізнес-логіки
    // ============================================
    
    public class InsufficientFundsException : InvalidOperationException
    {
        public decimal CurrentBalance { get; }
        public decimal RequiredAmount { get; }
        
        public InsufficientFundsException(decimal currentBalance, decimal requiredAmount)
            : base($"Недостатньо коштів. Поточний баланс: {currentBalance}, Потрібно: {requiredAmount}")
        {
            CurrentBalance = currentBalance;
            RequiredAmount = requiredAmount;
        }
    }
    
    // ============================================
    // ПРИКЛАД 4: Клас з винятками в конструкторі
    // ============================================
    
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrEmpty(accountNumber))
                throw new ArgumentException("Номер рахунку не може бути порожнім", nameof(accountNumber));
            
            if (initialBalance < 0)
                throw new ArgumentException("Початковий баланс не може бути від'ємним", nameof(initialBalance));
            
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума зняття повинна бути більше нуля", nameof(amount));
            
            if (amount > Balance)
                throw new InsufficientFundsException(Balance, amount);
            
            Balance -= amount;
            Console.WriteLine($"Знято {amount}. Залишок: {Balance}");
        }
        
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума внесення повинна бути більше нуля", nameof(amount));
            
            Balance += amount;
            Console.WriteLine($"Внесено {amount}. Баланс: {Balance}");
        }
    }
    
    // ============================================
    // ПРИКЛАД 5: Ієрархія винятків
    // ============================================
    
    // Базовий виняток для всіх помилок додатку
    public class ApplicationBaseException : Exception
    {
        public string ErrorCode { get; }
        
        public ApplicationBaseException(string errorCode, string message) 
            : base(message)
        {
            ErrorCode = errorCode;
        }
        
        public ApplicationBaseException(string errorCode, string message, Exception innerException) 
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
    
    // Похідний виняток для помилок бази даних
    public class DatabaseException : ApplicationBaseException
    {
        public string TableName { get; }
        
        public DatabaseException(string errorCode, string tableName, string message) 
            : base(errorCode, message)
        {
            TableName = tableName;
        }
    }
    
    // Похідний виняток для помилок мережі
    public class NetworkException : ApplicationBaseException
    {
        public string Endpoint { get; }
        
        public NetworkException(string errorCode, string endpoint, string message) 
            : base(errorCode, message)
        {
            Endpoint = endpoint;
        }
    }
    
    // ============================================
    // ПРИКЛАД 6: Обробка винятків при успадкуванні
    // ============================================
    
    public class ExceptionHandlingExample
    {
        public static void DemonstrateExceptionHandling()
        {
            try
            {
                // Створення рахунку з некоректними даними
                BankAccount account = new BankAccount("", -100);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка аргументу: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Загальна помилка: {ex.Message}");
            }
            
            try
            {
                BankAccount account = new BankAccount("12345", 100);
                account.Withdraw(200); // спроба зняти більше, ніж є
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Недостатньо коштів: {ex.Message}");
                Console.WriteLine($"Поточний баланс: {ex.CurrentBalance}, Потрібно: {ex.RequiredAmount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Інша помилка: {ex.Message}");
            }
        }
    }
}

