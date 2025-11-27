using System;

namespace Module5ConsoleApp
{
    // ============================================
    // ПРИКЛАД 1: Перевантаження унарних операторів
    // ============================================
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Перевантаження унарного мінуса (-vector)
        public static Vector2D operator -(Vector2D v)
        {
            return new Vector2D(-v.X, -v.Y);
        }

        // Перевантаження унарного плюса (+vector)
        public static Vector2D operator +(Vector2D v)
        {
            return new Vector2D(v.X, v.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // ============================================
    // ПРИКЛАД 2: Перевантаження бінарних операторів
    // ============================================
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Перевантаження оператора додавання (a + b)
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        // Перевантаження оператора віднімання (a - b)
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        // Перевантаження оператора множення (a * b)
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(
                a.Real * b.Real - a.Imaginary * b.Imaginary,
                a.Real * b.Imaginary + a.Imaginary * b.Real
            );
        }

        // Перевантаження оператора ділення (a / b)
        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            return new ComplexNumber(
                (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
                (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator
            );
        }

        public override string ToString()
        {
            if (Imaginary >= 0)
                return $"{Real} + {Imaginary}i";
            return $"{Real} - {Math.Abs(Imaginary)}i";
        }
    }

    // ============================================
    // ПРИКЛАД 3: Перевантаження операторів відношень
    // ============================================
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero");
            
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
            
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private int GCD(int a, int b) //НСД
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        // Перевантаження оператора рівності (==)
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (ReferenceEquals(f1, null) && ReferenceEquals(f2, null))
                return true;
            if (ReferenceEquals(f1, null) || ReferenceEquals(f2, null))
                return false;
            
            return f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator;
        }

        // Перевантаження оператора нерівності (!=)
        // ВАЖЛИВО: Якщо перевантажуємо ==, обов'язково перевантажуємо !=
        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        // Перевантаження оператора менше (<)
        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator < f2.Numerator * f1.Denominator;
        }

        // Перевантаження оператора більше (>)
        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f2 < f1;
        }

        // Перевантаження оператора менше або рівно (<=)
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f1 < f2 || f1 == f2;
        }

        // Перевантаження оператора більше або рівно (>=)
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1 > f2 || f1 == f2;
        }

        // Перевизначення Equals для коректної роботи з колекціями
        public override bool Equals(object? obj)
        {
            if (obj is Fraction fraction)
                return this == fraction;
            return false;
        }

        // Перевизначення GetHashCode (обов'язково при перевизначенні Equals)
        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    // ============================================
    // ПРИКЛАД 4: Перевантаження логічних операторів
    // ============================================
    public class BooleanWrapper
    {
        public bool Value { get; set; }

        public BooleanWrapper(bool value)
        {
            Value = value;
        }

        // Перевантаження логічного І (&)
        public static BooleanWrapper operator &(BooleanWrapper a, BooleanWrapper b)
        {
            return new BooleanWrapper(a.Value && b.Value);
        }

        // Перевантаження логічного АБО (|)
        public static BooleanWrapper operator |(BooleanWrapper a, BooleanWrapper b)
        {
            return new BooleanWrapper(a.Value || b.Value);
        }

        // Перевантаження виключного АБО (^)
        public static BooleanWrapper operator ^(BooleanWrapper a, BooleanWrapper b)
        {
            return new BooleanWrapper(a.Value ^ b.Value);
        }

        // Перевантаження логічного заперечення (!)
        public static BooleanWrapper operator !(BooleanWrapper a)
        {
            return new BooleanWrapper(!a.Value);
        }

        // Для && і || потрібні оператори true і false
        public static bool operator true(BooleanWrapper a)
        {
            return a.Value;
        }

        public static bool operator false(BooleanWrapper a)
        {
            return !a.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    // ============================================
    // ПРИКЛАД 5: Перевантаження операторів перетворення
    // ============================================
    public class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get => _celsius;
            set => _celsius = value;
        }

        public Temperature(double celsius)
        {
            _celsius = celsius;
        }

        // Неявне перетворення: double -> Temperature
        // Дозволяє: Temperature t = 25.0;
        public static implicit operator Temperature(double celsius)
        {
            return new Temperature(celsius);
        }

        // Явне перетворення: Temperature -> double
        // Потрібно: double d = (double)t;
        public static explicit operator double(Temperature t)
        {
            return t._celsius;
        }

        // Неявне перетворення: Temperature -> string
        public static implicit operator string(Temperature t)
        {
            return $"{t._celsius}°C";
        }

        public override string ToString()
        {
            return $"{_celsius}°C";
        }
    }

    // ============================================
    // ПРИКЛАД 6: Перевантаження оператора інкремента
    // ============================================
    public class Counter
    {
        public int Value { get; set; }

        public Counter(int value = 0)
        {
            Value = value;
        }

        // Префіксний інкремент (++counter)
        public static Counter operator ++(Counter c)
        {
            c.Value++;
            return c;
        }

        // Постфіксний інкремент (counter++)
        // Використовується той самий оператор ++
        // Різниця в порядку виконання визначається компілятором

        // Декремент (--counter)
        public static Counter operator --(Counter c)
        {
            c.Value--;
            return c;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

