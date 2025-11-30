using System;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: SEALED КЛАСИ ТА МЕТОДИ
    // ============================================
    // Теорія: README.md - розділ "Ключове слово sealed"
    // Демонструє:
    // - Sealed класи (заборона успадкування)
    // - Sealed методи (заборона перевизначення)
    // - Практичне використання sealed для безпеки
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Sealed клас
    // ============================================
    
    // Звичайний клас - можна успадковувати
    public class BaseMath
    {
        public virtual double Calculate(double x, double y)
        {
            return x + y;
        }
    }
    
    // Sealed клас - НЕ можна успадковувати
    public sealed class MathHelper
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        
        public static double Power(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }
    }
    
    // Спроба успадкувати sealed клас призведе до помилки компіляції:
    // public class AdvancedMath : MathHelper { } // ❌ Помилка!
    
    // ============================================
    // ПРИКЛАД 2: Sealed метод
    // ============================================
    
    public class BaseClassSealed
    {
        public virtual void Method1()
        {
            Console.WriteLine("BaseClassSealed.Method1()");
        }
        
        public virtual void Method2()
        {
            Console.WriteLine("BaseClassSealed.Method2()");
        }
    }
    
    public class DerivedClassSealed : BaseClassSealed
    {
        // Перевизначення методу
        public override void Method1()
        {
            Console.WriteLine("DerivedClassSealed.Method1()");
        }
        
        // Sealed override - цей метод не можна перевизначити в наступних похідних класах
        public sealed override void Method2()
        {
            Console.WriteLine("DerivedClassSealed.Method2() - запечатаний");
        }
    }
    
    public class ThirdClassSealed : DerivedClassSealed
    {
        // Можна перевизначити Method1
        public override void Method1()
        {
            Console.WriteLine("ThirdClassSealed.Method1()");
        }
        
        // НЕ можна перевизначити Method2, бо він sealed
        // public override void Method2() { } // ❌ Помилка компіляції!
    }
    
    // ============================================
    // ПРИКЛАД 3: Практичне використання sealed
    // ============================================
    
    public abstract class PaymentMethod
    {
        public abstract void ProcessPayment(double amount);
        
        public virtual void Validate()
        {
            Console.WriteLine("Базова валідація платежу");
        }
    }
    
    public class CreditCard : PaymentMethod
    {
        public string CardNumber { get; set; }
        
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обробка платежу на суму {amount} через кредитну картку {CardNumber}");
        }
        
        // Sealed override - забороняє подальше перевизначення
        public sealed override void Validate()
        {
            Console.WriteLine("Валідація кредитної картки");
            if (string.IsNullOrEmpty(CardNumber))
                throw new ArgumentException("Номер картки не може бути порожнім");
        }
    }
    
    public class VisaCard : CreditCard
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Обробка платежу Visa на суму {amount}");
        }
        
        // Validate() не можна перевизначити, бо він sealed в CreditCard
    }
    
    // ============================================
    // ПРИКЛАД 4: Sealed для безпеки
    // ============================================
    
    // Sealed клас для критичних операцій
    public sealed class SecurityManager
    {
        private static SecurityManager? instance;
        private static readonly object lockObject = new object();
        
        private SecurityManager() { }
        
        public static SecurityManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new SecurityManager();
                        }
                    }
                }
                return instance;
            }
        }
        
        public void Authenticate(string username, string password)
        {
            Console.WriteLine($"Аутентифікація користувача: {username}");
        }
    }
}

