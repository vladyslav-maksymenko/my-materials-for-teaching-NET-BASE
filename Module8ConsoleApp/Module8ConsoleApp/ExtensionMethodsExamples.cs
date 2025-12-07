using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Module8ConsoleApp
{
    // ============================================
    // ПРАКТИЧНІ КЕЙСИ: EXTENSION-МЕТОДИ
    // ============================================

    // Кейс 1: Extension-методи для string
    public static class StringExtensions
    {
        // Реверс рядка
        public static string Reverse(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        // Перевірка, чи рядок містить тільки цифри
        public static bool IsNumeric(this string str)
        {
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }

        // Форматування телефону
        public static string FormatPhone(this string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return phone;

            // Видаляємо всі нецифрові символи
            string digits = new string(phone.Where(char.IsDigit).ToArray());

            if (digits.Length == 10)
            {
                return $"+38 ({digits.Substring(0, 3)}) {digits.Substring(3, 3)}-{digits.Substring(6, 2)}-{digits.Substring(8, 2)}";
            }
            else if (digits.Length == 12 && digits.StartsWith("380"))
            {
                return $"+{digits.Substring(0, 2)} ({digits.Substring(2, 3)}) {digits.Substring(5, 3)}-{digits.Substring(8, 2)}-{digits.Substring(10, 2)}";
            }

            return phone;
        }

        // Перша літера велика, решта малі
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        // Перевірка email
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Обрізання рядка з додаванням "..."
        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
                return str;

            return str.Substring(0, maxLength) + "...";
        }

        // Видалення зайвих пробілів
        public static string RemoveExtraSpaces(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return Regex.Replace(str, @"\s+", " ").Trim();
        }
    }

    // Кейс 2: Extension-методи для колекцій
    public static class CollectionExtensions
    {
        // Виведення всіх елементів
        public static void PrintAll<T>(this IEnumerable<T> collection, string separator = ", ")
        {
            Console.WriteLine(string.Join(separator, collection));
        }

        // Отримання випадкового елемента
        public static T GetRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("Список порожній");

            Random random = new Random();
            return list[random.Next(list.Count)];
        }

        // Перевірка, чи колекція порожня або null
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        // Розбиття на батчі (групи)
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
        {
            var batch = new List<T>();
            foreach (var item in source)
            {
                batch.Add(item);
                if (batch.Count >= batchSize)
                {
                    yield return batch;
                    batch = new List<T>();
                }
            }
            if (batch.Count > 0)
                yield return batch;
        }

        // Перемішування колекції
        public static List<T> Shuffle<T>(this IList<T> list)
        {
            var result = new List<T>(list);
            Random random = new Random();
            for (int i = result.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }
            return result;
        }
    }

    // Кейс 3: Extension-методи для DateTime
    public static class DateTimeExtensions
    {
        // Перевірка, чи дата в межах робочого дня
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        // Отримання віку
        public static int GetAge(this DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;
            return age;
        }

        // Форматування відносного часу (2 години тому, вчора тощо)
        public static string ToRelativeTime(this DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "щойно";
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} хвилин тому";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} годин тому";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} днів тому";
            if (timeSpan.TotalDays < 30)
                return $"{(int)(timeSpan.TotalDays / 7)} тижнів тому";
            if (timeSpan.TotalDays < 365)
                return $"{(int)(timeSpan.TotalDays / 30)} місяців тому";

            return $"{(int)(timeSpan.TotalDays / 365)} років тому";
        }

        // Початок дня
        public static DateTime StartOfDay(this DateTime date)
        {
            return date.Date;
        }

        // Кінець дня
        public static DateTime EndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }
    }

    // Кейс 4: Extension-методи для числових типів
    public static class NumericExtensions
    {
        // Перевірка, чи число в діапазоні
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        // Округлення до найближчого кратного
        public static int RoundToNearest(this int value, int multiple)
        {
            return (int)Math.Round((double)value / multiple) * multiple;
        }

        // Форматування як валюта
        public static string ToCurrency(this decimal value, string currency = "UAH")
        {
            return $"{value:N2} {currency}";
        }

        // Перевірка, чи число парне
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        // Перевірка, чи число непарне
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        // Обмеження значення в діапазоні
        public static int Clamp(this int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

    // Кейс 5: Extension-методи для об'єктів
    public static class ObjectExtensions
    {
        // Безпечне перетворення в рядок
        public static string ToSafeString(this object obj)
        {
            return obj?.ToString() ?? "null";
        }

        // Перевірка, чи об'єкт в колекції
        public static bool IsIn<T>(this T item, params T[] collection)
        {
            return collection.Contains(item);
        }

        // Виконання дії, якщо об'єкт не null
        public static void IfNotNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj != null)
                action(obj);
        }
    }

    // Кейс 6: Extension-методи для роботи з файлами та шляхами
    public static class PathExtensions
    {
        // Отримання розширення файлу
        public static string GetFileExtension(this string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return string.Empty;

            int lastDot = filePath.LastIndexOf('.');
            if (lastDot == -1 || lastDot == filePath.Length - 1)
                return string.Empty;

            return filePath.Substring(lastDot + 1).ToLower();
        }

        // Отримання імені файлу без розширення
        public static string GetFileNameWithoutExtension(this string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return string.Empty;

            string fileName = System.IO.Path.GetFileName(filePath);
            int lastDot = fileName.LastIndexOf('.');
            if (lastDot == -1)
                return fileName;

            return fileName.Substring(0, lastDot);
        }

        // Перевірка, чи шлях валідний
        public static bool IsValidPath(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            try
            {
                System.IO.Path.GetFullPath(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    // Кейс 7: Extension-методи для роботи з JSON (симуляція)
    public static class JsonExtensions
    {
        // Симуляція серіалізації в JSON
        public static string ToJson(this object obj)
        {
            // Спрощена версія для демонстрації
            if (obj == null)
                return "null";

            if (obj is string str)
                return $"\"{str}\"";

            if (obj is int || obj is decimal || obj is double || obj is float)
                return obj.ToString();

            if (obj is bool b)
                return b ? "true" : "false";

            return $"\"{obj}\"";
        }
    }

    // ============================================
    // ДЕМОНСТРАЦІЯ ВСІХ КЕЙСІВ
    // ============================================
    public static class ExtensionMethodsExamplesDemo
    {
        public static void RunAllExamples()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("ПРАКТИЧНІ КЕЙСИ: EXTENSION-МЕТОДИ");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 1: String extensions
            Console.WriteLine("КЕЙС 1: Extension-методи для string");
            Console.WriteLine("-".PadRight(60, '-'));
            
            string text = "Привіт, світ!";
            Console.WriteLine($"Оригінал: {text}");
            Console.WriteLine($"Реверс: {text.Reverse()}");
            Console.WriteLine($"Капіталізація: {text.Capitalize()}");
            Console.WriteLine($"Обрізання (5): {text.Truncate(5)}");
            Console.WriteLine($"Без зайвих пробілів: {"  Привіт    світ  ".RemoveExtraSpaces()}");

            string phone = "0501234567";
            Console.WriteLine($"\nТелефон: {phone}");
            Console.WriteLine($"Відформатований: {phone.FormatPhone()}");

            string email1 = "test@example.com";
            string email2 = "invalid-email";
            Console.WriteLine($"\nEmail '{email1}' валідний: {email1.IsValidEmail()}");
            Console.WriteLine($"Email '{email2}' валідний: {email2.IsValidEmail()}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 2: Collection extensions
            Console.WriteLine("КЕЙС 2: Extension-методи для колекцій");
            Console.WriteLine("-".PadRight(60, '-'));
            
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Числа: ");
            numbers.PrintAll();

            Console.WriteLine($"Випадкове число: {numbers.GetRandom()}");
            Console.WriteLine($"Колекція порожня: {numbers.IsNullOrEmpty()}");

            Console.WriteLine("\nРозбиття на батчі по 3:");
            var batches = numbers.Batch(3);
            foreach (var batch in batches)
            {
                Console.Write("  ");
                batch.PrintAll();
            }

            var shuffled = numbers.Shuffle();
            Console.Write("\nПеремішані: ");
            shuffled.PrintAll();

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 3: DateTime extensions
            Console.WriteLine("КЕЙС 3: Extension-методи для DateTime");
            Console.WriteLine("-".PadRight(60, '-'));
            
            DateTime birthDate = new DateTime(1990, 5, 15);
            Console.WriteLine($"Дата народження: {birthDate:dd.MM.yyyy}");
            Console.WriteLine($"Вік: {birthDate.GetAge()} років");
            Console.WriteLine($"Робочий день: {birthDate.IsWorkingDay()}");

            DateTime recentDate = DateTime.Now.AddHours(-2);
            Console.WriteLine($"\nДата: {recentDate:dd.MM.yyyy HH:mm}");
            Console.WriteLine($"Відносний час: {recentDate.ToRelativeTime()}");

            DateTime today = DateTime.Now;
            Console.WriteLine($"\nСьогодні:");
            Console.WriteLine($"  Початок дня: {today.StartOfDay():dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"  Кінець дня: {today.EndOfDay():dd.MM.yyyy HH:mm:ss}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 4: Numeric extensions
            Console.WriteLine("КЕЙС 4: Extension-методи для числових типів");
            Console.WriteLine("-".PadRight(60, '-'));
            
            int value = 15;
            Console.WriteLine($"Значення: {value}");
            Console.WriteLine($"В діапазоні 10-20: {value.IsBetween(10, 20)}");
            Console.WriteLine($"Округлення до 5: {value.RoundToNearest(5)}");
            Console.WriteLine($"Парне: {value.IsEven()}");
            Console.WriteLine($"Непарне: {value.IsOdd()}");

            int clamped = 25;
            Console.WriteLine($"\nЗначення: {clamped}");
            Console.WriteLine($"Обмежене 0-20: {clamped.Clamp(0, 20)}");

            decimal price = 1234.56m;
            Console.WriteLine($"\nЦіна: {price.ToCurrency()}");
            Console.WriteLine($"Ціна (USD): {price.ToCurrency("USD")}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 5: Object extensions
            Console.WriteLine("КЕЙС 5: Extension-методи для об'єктів");
            Console.WriteLine("-".PadRight(60, '-'));
            
            string name = "Іван";
            Console.WriteLine($"Ім'я '{name}' в списку: {name.IsIn("Іван", "Петро", "Марія")}");
            Console.WriteLine($"Ім'я '{name}' в списку: {name.IsIn("Олена", "Андрій")}");

            object obj = null;
            Console.WriteLine($"\nБезпечний рядок (null): {obj.ToSafeString()}");

            string notNull = "Привіт";
            notNull.IfNotNull(s => Console.WriteLine($"Обробка не-null значення: {s}"));

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 6: Path extensions
            Console.WriteLine("КЕЙС 6: Extension-методи для роботи з шляхами");
            Console.WriteLine("-".PadRight(60, '-'));
            
            string filePath = "C:\\Documents\\report.pdf";
            Console.WriteLine($"Шлях: {filePath}");
            Console.WriteLine($"Розширення: {filePath.GetFileExtension()}");
            Console.WriteLine($"Ім'я без розширення: {filePath.GetFileNameWithoutExtension()}");
            Console.WriteLine($"Валідний шлях: {filePath.IsValidPath()}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();

            // Кейс 7: JSON extensions
            Console.WriteLine("КЕЙС 7: Extension-методи для JSON (симуляція)");
            Console.WriteLine("-".PadRight(60, '-'));
            
            Console.WriteLine($"String: {"Привіт".ToJson()}");
            Console.WriteLine($"Number: {123.ToJson()}");
            Console.WriteLine($"Bool: {true.ToJson()}");
            Console.WriteLine($"Null: {((object)null).ToJson()}");

            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine();
        }
    }
}

