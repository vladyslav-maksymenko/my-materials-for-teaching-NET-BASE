using System;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Головний файл програми для демонстрації концепцій Generics, Ітераторів та Колекцій
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Модуль 9. Вступ до Generics, Ітераторів та Колекцій       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            
            // ============================================
            // ЧАСТИНА 1: GENERICS
            // ============================================
            Console.WriteLine("\n\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 1: GENERICS (УЗАГАЛЬНЕННЯ)");
            Console.WriteLine(new string('═', 70));
            
            // 1.1 Простий Generic-клас
            GenericExamples.DemonstrateBox();
            
            // 1.2 Обмеження (Constraints)
            GenericExamples.DemonstrateConstraints();
            
            // 1.3 Вкладені типи
            GenericExamples.DemonstrateNestedTypes();
            
            // 1.4 Generic-інтерфейси
            GenericExamples.DemonstrateGenericInterfaces();
            
            // 1.5 Generic-делегати
            GenericExamples.DemonstrateGenericDelegates();
            
            // 1.6 Generic-методи
            GenericExamples.DemonstrateGenericMethods();
            
            // ============================================
            // ЧАСТИНА 2: ІТЕРАТОРИ
            // ============================================
            Console.WriteLine("\n\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 2: ІТЕРАТОРИ (ITERATORS)");
            Console.WriteLine(new string('═', 70));
            
            // 2.1 Базовий ітератор
            IteratorExamples.DemonstrateBasicIterator();
            
            // 2.2 Послідовність Фібоначчі
            IteratorExamples.DemonstrateFibonacci();
            
            // 2.3 yield break
            IteratorExamples.DemonstrateYieldBreak();
            
            // 2.4 Ітератор як властивість
            IteratorExamples.DemonstratePropertyIterator();
            
            // 2.5 Композиція ітераторів
            IteratorExamples.DemonstrateComposition();
            
            // 2.6 Кастомна колекція
            IteratorExamples.DemonstrateCustomCollection();
            
            // 2.7 Ліниве виконання
            IteratorExamples.DemonstrateLazyEvaluation();
            
            // ============================================
            // ЧАСТИНА 3: КОЛЕКЦІЇ
            // ============================================
            Console.WriteLine("\n\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 3: КОЛЕКЦІЇ (COLLECTIONS)");
            Console.WriteLine(new string('═', 70));
            
            // 3.1 List<T>
            CollectionExamples.DemonstrateList();
            
            // 3.2 Dictionary<TKey, TValue>
            CollectionExamples.DemonstrateDictionary();
            
            // 3.3 Stack<T>
            CollectionExamples.DemonstrateStack();
            
            // 3.4 Queue<T>
            CollectionExamples.DemonstrateQueue();
            
            // 3.5 SortedList<TKey, TValue>
            CollectionExamples.DemonstrateSortedList();
            
            // 3.6 HashSet<T>
            CollectionExamples.DemonstrateHashSet();
            
            // 3.7 LinkedList<T>
            CollectionExamples.DemonstrateLinkedList();
            
            // 3.8 Інтерфейси колекцій
            CollectionExamples.DemonstrateInterfaces();
            
            // 3.9 IComparer<T>
            CollectionExamples.DemonstrateIComparer();
            
            // 3.10 Практичний приклад
            CollectionExamples.DemonstrateLibraryExample();


            // ============================================
            // ЧАСТИНА 1: GENERIC-МЕТОДИ
            // ============================================
            //Part1Generics.RunAllTasks();

            //// ============================================
            //// ЧАСТИНА 2: ІТЕРАТОРИ
            //// ============================================
            //Part2Iterators.RunAllTasks();

            //// ============================================
            //// ЧАСТИНА 3: КОЛЕКЦІЇ
            //// ============================================
            //Part3Collections.RunAllTasks();

            // ============================================
            // ЗАВЕРШЕННЯ
            // ============================================
            Console.WriteLine("\n\n" + new string('═', 70));
            Console.WriteLine("Демонстрація завершена!");
            Console.WriteLine(new string('═', 70));
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
