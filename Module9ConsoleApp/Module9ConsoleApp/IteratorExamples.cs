using System;
using System.Collections;
using System.Collections.Generic;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Приклади використання ітераторів в C#
    /// </summary>
    public static class IteratorExamples
    {
        // ============================================
        // 1. ПРОСТИЙ ІТЕРАТОР З YIELD RETURN
        // ============================================

        /// <summary>
        /// Простий ітератор, який повертає послідовність чисел від 0 до n-1
        /// yield return - ключове слово, яке повертає значення та зберігає стан методу
        /// </summary>
        public static IEnumerable<int> GetNumbers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return i; // Повертаємо значення та зберігаємо поточну позицію
            }
        }

        /// <summary>
        /// Ітератор для послідовності Фібоначчі
        /// Демонструє, що ітератор може генерувати нескінченну послідовність
        /// </summary>
        public static IEnumerable<long> Fibonacci(int count)
        {
            long a = 0, b = 1;
            yield return a; // Перше число
            yield return b; // Друге число

            for (int i = 2; i < count; i++)
            {
                long next = a + b;
                yield return next;
                a = b;
                b = next;
            }
        }

        // ============================================
        // 2. ІТЕРАТОР З YIELD BREAK
        // ============================================

        /// <summary>
        /// Ітератор з умовним завершенням через yield break
        /// yield break - завершує ітерацію достроково
        /// </summary>
        public static IEnumerable<int> GetNumbersUntil(int maxValue, int stopAt)
        {
            for (int i = 0; i < maxValue; i++)
            {
                if (i >= stopAt)
                {
                    yield break; // Завершуємо ітерацію, якщо досягли stopAt
                }
                yield return i;
            }
        }

        // ============================================
        // 3. ІТЕРАТОР ЯК ВЛАСТИВІСТЬ
        // ============================================

        /// <summary>
        /// Клас з ітератором як властивістю
        /// </summary>
        public class NumberRange
        {
            private int _start;
            private int _end;

            public NumberRange(int start, int end)
            {
                _start = start;
                _end = end;
            }

            /// <summary>
            /// Властивість-ітератор, яка повертає числа в діапазоні
            /// </summary>
            public IEnumerable<int> Numbers
            {
                get
                {
                    for (int i = _start; i <= _end; i++)
                    {
                        yield return i;
                    }
                }
            }
        }

        // ============================================
        // 4. КОМПОЗИЦІЯ ІТЕРАТОРІВ
        // ============================================

        /// <summary>
        /// Ітератор, який використовує інший ітератор
        /// </summary>
        public static IEnumerable<int> GetEvenNumbers(int count)
        {
            foreach (var number in GetNumbers(count))
            {
                if (number % 2 == 0)
                {
                    yield return number; // Повертаємо тільки парні числа
                }
            }
        }

        /// <summary>
        /// Ітератор для фільтрації колекції
        /// </summary>
        public static IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // ============================================
        // 5. КАСТОМНИЙ ІТЕРАТОР З IENUMERABLE<T>
        // ============================================

        /// <summary>
        /// Клас, який реалізує IEnumerable<T> з кастомним ітератором
        /// </summary>
        public class CustomCollection<T> : IEnumerable<T>
        {
            private T[] _items;

            public CustomCollection(T[] items)
            {
                _items = items;
            }

            /// <summary>
            /// Реалізація GetEnumerator() з використанням yield return
            /// </summary>
            public IEnumerator<T> GetEnumerator()
            {
                foreach (var item in _items)
                {
                    yield return item;
                }
            }

            /// <summary>
            /// Явна реалізація для не-generic інтерфейсу
            /// </summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        // ============================================
        // 6. ЛІНИВЕ ВИКОНАННЯ (LAZY EVALUATION)
        // ============================================

        /// <summary>
        /// Демонстрація лінивого виконання ітераторів
        /// Значення обчислюються тільки коли вони потрібні
        /// </summary>
        public static IEnumerable<int> GetLazyNumbers()
        {
            Console.WriteLine("Початок генерації чисел");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Генерується число: {i}");
                yield return i;
            }
            Console.WriteLine("Завершення генерації чисел");
        }

        // ============================================
        // 7. ДЕМОНСТРАЦІЙНІ МЕТОДИ
        // ============================================

        public static void DemonstrateBasicIterator()
        {
            Console.WriteLine("\n=== Демонстрація базового ітератора ===");
            
            Console.WriteLine("Числа від 0 до 4:");
            foreach (var number in GetNumbers(5))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateFibonacci()
        {
            Console.WriteLine("\n=== Демонстрація послідовності Фібоначчі ===");
            
            Console.WriteLine("Перші 10 чисел Фібоначчі:");
            foreach (var fib in Fibonacci(10))
            {
                Console.Write($"{fib} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateYieldBreak()
        {
            Console.WriteLine("\n=== Демонстрація yield break ===");
            
            Console.WriteLine("Числа до 10, але зупиняємося на 5:");
            foreach (var number in GetNumbersUntil(10, 5))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        public static void DemonstratePropertyIterator()
        {
            Console.WriteLine("\n=== Демонстрація ітератора як властивості ===");
            
            var range = new NumberRange(10, 15);
            Console.WriteLine("Числа в діапазоні 10-15:");
            foreach (var number in range.Numbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateComposition()
        {
            Console.WriteLine("\n=== Демонстрація композиції ітераторів ===");
            
            Console.WriteLine("Парні числа від 0 до 9:");
            foreach (var number in GetEvenNumbers(10))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            // Використання Filter з лямбда-виразом
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("\nЧисла більше 5:");
            foreach (var number in Filter(numbers, x => x > 5))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateCustomCollection()
        {
            Console.WriteLine("\n=== Демонстрація кастомної колекції з ітератором ===");
            
            var collection = new CustomCollection<string>(new[] { "Apple", "Banana", "Cherry" });
            
            Console.WriteLine("Елементи колекції:");
            foreach (var item in collection)
            {
                Console.WriteLine($"  - {item}");
            }
        }

        public static void DemonstrateLazyEvaluation()
        {
            Console.WriteLine("\n=== Демонстрація лінивого виконання ===");
            
            Console.WriteLine("Створюємо ітератор (ще нічого не обчислюється):");
            var iterator = GetLazyNumbers();
            
            Console.WriteLine("\nПочинаємо перебір (тепер обчислюються значення):");
            int count = 0;
            foreach (var number in iterator)
            {
                Console.WriteLine($"Отримано число: {number}");
                count++;
                if (count >= 2) // Перериваємо після 2 елементів
                {
                    Console.WriteLine("Перериваємо перебір");
                    break;
                }
            }
            Console.WriteLine("\nЗверніть увагу: не всі числа були згенеровані!");
        }
    }
}

