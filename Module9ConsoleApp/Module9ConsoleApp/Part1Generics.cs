using System;
using System.Linq;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Частина 1: Generic-методи для обчислень
    /// </summary>
    public static class Part1Generics
    {
        // ============================================
        // Завдання 1: Generic-метод обчислення максимуму з трьох чисел
        // ============================================
        
        /// <summary>
        /// Знаходить максимальне значення з трьох чисел
        /// </summary>
        /// <typeparam name="T">Тип, що реалізує IComparable&lt;T&gt;</typeparam>
        /// <param name="a">Перше число</param>
        /// <param name="b">Друге число</param>
        /// <param name="c">Третє число</param>
        /// <returns>Максимальне значення</returns>
        public static T Max<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;
            
            if (b.CompareTo(max) > 0)
                max = b;
            
            if (c.CompareTo(max) > 0)
                max = c;
            
            return max;
        }

        // ============================================
        // Завдання 2: Generic-метод обчислення мінімуму з трьох чисел
        // ============================================
        
        /// <summary>
        /// Знаходить мінімальне значення з трьох чисел
        /// </summary>
        /// <typeparam name="T">Тип, що реалізує IComparable&lt;T&gt;</typeparam>
        /// <param name="a">Перше число</param>
        /// <param name="b">Друге число</param>
        /// <param name="c">Третє число</param>
        /// <returns>Мінімальне значення</returns>
        public static T Min<T>(T a, T b, T c) where T : IComparable<T>
        {
            T min = a;
            
            if (b.CompareTo(min) < 0)
                min = b;
            
            if (c.CompareTo(min) < 0)
                min = c;
            
            return min;
        }

        // ============================================
        // Завдання 3: Generic-метод пошуку суми елементів у масиві
        // ============================================
        
        /// <summary>
        /// Обчислює суму елементів масиву
        /// </summary>
        /// <typeparam name="T">Числовий тип</typeparam>
        /// <param name="array">Масив елементів</param>
        /// <returns>Сума елементів</returns>
        public static T Sum<T>(T[] array) where T : struct, IConvertible
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив не може бути порожнім або null");

            // Використовуємо dynamic для обчислення суми різних типів
            dynamic sum = default(T);
            
            foreach (var item in array)
            {
                sum += (dynamic)item;
            }
            
            return sum;
        }

        // ============================================
        // Демонстраційні методи
        // ============================================
        
        public static void DemonstrateTask1()
        {
            Console.WriteLine("\n=== Завдання 1: Generic-метод максимуму з трьох чисел ===");
            
            // Тестування з int
            int maxInt = Max(10, 25, 15);
            Console.WriteLine($"Максимум з (10, 25, 15) = {maxInt}");
            
            // Тестування з double
            double maxDouble = Max(3.14, 2.71, 1.41);
            Console.WriteLine($"Максимум з (3.14, 2.71, 1.41) = {maxDouble}");
            
            // Тестування з string
            string maxString = Max("apple", "zebra", "banana");
            Console.WriteLine($"Максимум з ('apple', 'zebra', 'banana') = '{maxString}'");
        }

        public static void DemonstrateTask2()
        {
            Console.WriteLine("\n=== Завдання 2: Generic-метод мінімуму з трьох чисел ===");
            
            // Тестування з int
            int minInt = Min(10, 25, 15);
            Console.WriteLine($"Мінімум з (10, 25, 15) = {minInt}");
            
            // Тестування з double
            double minDouble = Min(3.14, 2.71, 1.41);
            Console.WriteLine($"Мінімум з (3.14, 2.71, 1.41) = {minDouble}");
            
            // Тестування з string
            string minString = Min("apple", "zebra", "banana");
            Console.WriteLine($"Мінімум з ('apple', 'zebra', 'banana') = '{minString}'");
        }

        public static void DemonstrateTask3()
        {
            Console.WriteLine("\n=== Завдання 3: Generic-метод суми елементів масиву ===");
            
            // Тестування з int
            int[] intArray = { 1, 2, 3, 4, 5 };
            int sumInt = Sum(intArray);
            Console.WriteLine($"Сума масиву [1, 2, 3, 4, 5] = {sumInt}");
            
            // Тестування з double
            double[] doubleArray = { 1.5, 2.5, 3.5, 4.5 };
            double sumDouble = Sum(doubleArray);
            Console.WriteLine($"Сума масиву [1.5, 2.5, 3.5, 4.5] = {sumDouble}");
            
            // Тестування з float
            float[] floatArray = { 1.1f, 2.2f, 3.3f };
            float sumFloat = Sum(floatArray);
            Console.WriteLine($"Сума масиву [1.1, 2.2, 3.3] = {sumFloat}");
        }

        public static void RunAllTasks()
        {
            Console.WriteLine("\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 1: GENERIC-МЕТОДИ");
            Console.WriteLine(new string('═', 70));
            
            DemonstrateTask1();
            DemonstrateTask2();
            DemonstrateTask3();
        }
    }
}

