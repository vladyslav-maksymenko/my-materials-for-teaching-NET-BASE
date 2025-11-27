/*
 * МОДУЛЬ 4: ТИПИ NULLABLE
 * 
 * ЩО ТАКЕ ТИП NULLABLE?
 * Nullable тип - це тип значення (value type), який може також мати значення null.
 * За замовчуванням типи-значення (int, bool, double, struct) не можуть бути null.
 * Nullable дозволяє їм бути null, що корисне для представлення "відсутності значення".
 * 
 * СИНТАКСИС:
 * - int? (коротка форма)
 * - Nullable<int> (повна форма)
 * 
 * ЦІЛІ ТА ЗАВДАННЯ:
 * - Представляти відсутність значення
 * - Робота з базами даних (де поля можуть бути NULL)
 * - Опціональні параметри
 * - Перевірка наявності значення
 */

// ============================================
// ПРИКЛАД 1: БАЗОВЕ ВИКОРИСТАННЯ NULLABLE
// ============================================

public class NullableExamples
{
    public void Example1()
    {
        // Звичайний int не може бути null
        int normalInt = 10;
        //int nullInt = null; // ПОМИЛКА!

        // Nullable int може бути null
        int? nullableInt = null;
        nullableInt = 10; // Тепер має значення

        // Аналогічно для інших типів
        bool nullableBool;
        // bool? IsCanDoSOmething;
        double? nullableDouble = null;
        DateTime? nullableDate = null;
    }
}

// ============================================
// ПРИКЛАД 2: ПЕРЕВІРКА НА НАЯВНІСТЬ ЗНАЧЕННЯ
// ============================================

public class NullableCheck
{
    public void Example2()
    {
        int? number = 10;

        // Спосіб 1: Перевірка через HasValue
        if (number.HasValue)
        {
            Console.WriteLine($"Значення: {number.Value}");
        }
        else
        {
            Console.WriteLine("Значення відсутнє");
        }

        // Спосіб 2: Перевірка через null
        if (number != null)
        {
            Console.WriteLine($"Значення: {number}");
        }
        else
        {
            Console.WriteLine("Значення відсутнє");
        }

        // Спосіб 3: Використання оператора ??
        int result = number ?? 0; // Якщо number == null, то result = 0
        Console.WriteLine($"Результат: {result}");
    }
}

// ============================================
// ПРИКЛАД 3: ОПЕРАЦІЇ З NULLABLE ТИПАМИ
// ============================================

public class NullableOperations
{
    public void Example3()
    {
        int? a = 10;
        int? b = null;
        int? c = 5;

        // Арифметичні операції
        int? sum = a + c;        // 15
        int? sumWithNull = a + b; // null (якщо один операнд null, результат null)

        // Порівняння
        bool isEqual = a == c;        // false
        bool isNullEqual = b == null; // true

        // Отримання значення
        int valueA = a.Value;         // 10 (якщо HasValue == true)
        if (b.HasValue)
        {
            int valueB = b.Value;
        }
        // int valueB = b.Value;      // ПОМИЛКА! NullReferenceException

        // Безпечне отримання значення
        int safeValue = a ?? 0;       // 10 (бо a має значення)
        int safeValueB = b ?? 0;      // 0 (бо b == null)
    }
}

// ============================================
// ПРИКЛАД 4: NULLABLE З СТРУКТУРАМИ
// ============================================

public struct PointNullable
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class NullableStruct
{
    public void Example4()
    {
        // Структура може бути Nullable
        PointNullable? point = null;
        point = new PointNullable { X = 10, Y = 20 };

        if (point.HasValue)
        {
            PointNullable actualPoint = point.Value;
            Console.WriteLine($"Точка: ({actualPoint.X}, {actualPoint.Y})");
        }
    }
}

// ============================================
// ПРИКЛАД 5: ПРАКТИЧНЕ ЗАСТОСУВАННЯ - БАЗА ДАНИХ
// ============================================

public class UserNullable
{
    public string Name { get; set; } = "";
    public int? Age { get; set; }        // Вік може бути невідомим
    public DateTime? LastLogin { get; set; } // Останній вхід може бути null
    public bool? IsActive { get; set; }  // Статус може бути невстановленим
}

public class DatabaseExample
{
    public void Example5()
    {
        UserNullable user = new UserNullable
        {
            Name = "Іван",
            Age = null,              // Вік невідомий
            LastLogin = null,        // Ніколи не входив
            IsActive = true
        };

        // Перевірка та використання
        if (user.Age.HasValue)
        {
            Console.WriteLine($"Вік користувача: {user.Age.Value}");
        }
        else
        {
            Console.WriteLine("Вік невідомий");
        }

        // Використання оператора ??
        int displayAge = user.Age ?? 0;
        Console.WriteLine($"Вік для відображення: {displayAge}");
    }
}

// ============================================
// ПРИКЛАД 6: ОПЕРАТОР NULL-COALESCING (??)
// ============================================

public class NullCoalescing
{
    public void Example6()
    {
        int? number = null;

        // Оператор ?? повертає значення зліва, якщо воно не null, інакше - справа
        int result1 = number ?? 100;        // 100 (бо number == null)
        
        number = 50;
        int result2 = number ?? 100;        // 50 (бо number != null)

        // Ланцюжок ??
        int? a = null;
        int? b = null;
        int? c = null;
        int final = a ?? b ?? c ?? 0;       // 10 (перше не-null значення)
    }
}

// ============================================
// ПРИКЛАД 7: ОПЕРАТОР NULL-CONDITIONAL (?.)
// ============================================

public class PersonNullable
{
    public string? Name { get; set; }
    public Address? Address { get; set; }
}

public class Address
{
    public string? City { get; set; }
    public string? Street { get; set; }
}

public class NullConditional
{
    public void Example7()
    {
        PersonNullable? person = null;

        // Без null-conditional (можлива помилка)
         //string city = person.Address.City; // NullReferenceException!

        // З null-conditional (безпечно)
        string? city = person?.Address?.City; // null (без помилки)

        // Комбінація з null-coalescing
        string safeCity = person?.Address?.City ?? "Невідомо";
        Console.WriteLine($"Місто: {safeCity}");
    }
}

// ============================================
// ПРИКЛАД 8: КОНВЕРТАЦІЯ NULLABLE
// ============================================

public class NullableConversion
{
    public void Example8()
    {
        int? nullableInt = 10;
        int normalInt = 5;

        // Неявна конвертація: int -> int?
        int? result1 = normalInt; // OK

        // Явна конвертація: int? -> int
        int result2 = nullableInt.Value; // Якщо HasValue == true
        int result3 = nullableInt ?? 0;  // Безпечніше

        // Перевірка перед конвертацією
        if (nullableInt.HasValue)
        {
            int safeValue = nullableInt.Value;
        }
    }
}

// ============================================
// ПРИКЛАД 9: МЕТОДИ З NULLABLE ПАРАМЕТРАМИ
// ============================================

public class NullableMethods
{
    // Метод з nullable параметром
    public int Calculate(int? value)
    {
        // Якщо value == null, повертаємо 0
        return value ?? 0;
    }

    // Метод, що повертає nullable
    public int? FindValue(int[] array, int searchValue)
    {
        foreach (int item in array)
        {
            if (item == searchValue)
                return item;
        }
        return null; // Значення не знайдено
    }

    public void Example9()
    {
        int result1 = Calculate(10);    // 10
        int result2 = Calculate(null);  // 0

        int[] numbers = { 1, 2, 3, 4, 5 };
        int? found = FindValue(numbers, 3);  // 3
        int? notFound = FindValue(numbers, 10); // null
    }
}

/*
 * КЛЮЧОВІ МОМЕНТИ:
 * 
 * 1. Nullable типи дозволяють value types бути null
 * 2. Синтаксис: int? або Nullable<int>
 * 3. HasValue - перевірка наявності значення
 * 4. Value - отримання значення (тільки якщо HasValue == true)
 * 5. Оператор ?? (null-coalescing) - повертає значення за замовчуванням
 * 6. Оператор ?. (null-conditional) - безпечний доступ до членів
 * 7. Арифметичні операції з null дають null
 * 8. Використовуйте для опціональних значень
 * 9. Корисно при роботі з базами даних
 * 10. Завжди перевіряйте HasValue перед використанням Value
 */

