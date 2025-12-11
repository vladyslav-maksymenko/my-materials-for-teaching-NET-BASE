using System;
using System.Collections.Generic;
using System.Linq;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Приклади використання Generic-колекцій в C#
    /// </summary>
    public static class CollectionExamples
    {
        // ============================================
        // 1. LIST<T> - ДИНАМІЧНИЙ МАСИВ
        // ============================================

        public static void DemonstrateList()
        {
            Console.WriteLine("\n=== Демонстрація List<T> ===");
            
            // Створення списку цілих чисел
            List<int> numbers = new List<int>();
            
            // Додавання елементів
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.AddRange(new[] { 40, 50, 60 });
            
            Console.WriteLine($"Кількість елементів: {numbers.Count}");
            Console.WriteLine("Елементи списку:");
            foreach (var num in numbers)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            
            // Доступ за індексом
            Console.WriteLine($"Перший елемент: {numbers[0]}");
            Console.WriteLine($"Останній елемент: {numbers[numbers.Count - 1]}");
            
            // Перевірка наявності
            Console.WriteLine($"Чи містить 30? {numbers.Contains(30)}");
            
            // Пошук
            int index = numbers.IndexOf(30);
            Console.WriteLine($"Індекс елемента 30: {index}");
            
            // Вставка
            numbers.Insert(2, 25);
            Console.WriteLine("\nПісля вставки 25 на позицію 2:");
            numbers.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();
            
            // Видалення
            numbers.Remove(25);
            numbers.RemoveAt(0);
            Console.WriteLine("\nПісля видалення:");
            numbers.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();
            
            // Сортування
            numbers.Sort();
            Console.WriteLine("\nПісля сортування:");
            numbers.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();
        }

        // ============================================
        // 2. DICTIONARY<TKey, TValue> - СЛОВНИК
        // ============================================

        public static void DemonstrateDictionary()
        {
            Console.WriteLine("\n=== Демонстрація Dictionary<TKey, TValue> ===");
            
            // Створення словника (ключ - string, значення - int)
            Dictionary<string, int> ages = new Dictionary<string, int>();
            
            // Додавання пар ключ-значення
            ages["Іван"] = 25;
            ages["Марія"] = 30;
            ages.Add("Петро", 28);
            ages.Add("Олена", 22);
            
            Console.WriteLine("Вік людей:");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value} років");
            }
            
            // Доступ за ключем
            Console.WriteLine($"\nВік Івана: {ages["Іван"]}");
            
            // Безпечне отримання значення
            if (ages.TryGetValue("Марія", out int mariaAge))
            {
                Console.WriteLine($"Вік Марії (через TryGetValue): {mariaAge}");
            }
            
            // Перевірка наявності ключа
            Console.WriteLine($"Чи є ключ 'Петро'? {ages.ContainsKey("Петро")}");
            Console.WriteLine($"Чи є значення 30? {ages.ContainsValue(30)}");
            
            // Отримання всіх ключів та значень
            Console.WriteLine("\nВсі ключі:");
            foreach (var key in ages.Keys)
            {
                Console.Write($"{key} ");
            }
            Console.WriteLine();
            
            Console.WriteLine("Всі значення:");
            foreach (var value in ages.Values)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
            
            // Видалення
            ages.Remove("Олена");
            Console.WriteLine($"\nПісля видалення 'Олена', кількість: {ages.Count}");
        }

        // ============================================
        // 3. STACK<T> - СТЕК (LIFO)
        // ============================================

        public static void DemonstrateStack()
        {
            Console.WriteLine("\n=== Демонстрація Stack<T> (LIFO - Last In, First Out) ===");
            
            Stack<string> stack = new Stack<string>();
            
            // Додавання на вершину стеку (Push)
            stack.Push("Перший");
            stack.Push("Другий");
            stack.Push("Третій");
            stack.Push("Четвертий");
            
            Console.WriteLine($"Кількість елементів у стеку: {stack.Count}");
            Console.WriteLine($"Верхній елемент (Peek): {stack.Peek()}");
            
            Console.WriteLine("\nВидалення елементів зі стеку (в зворотному порядку):");
            while (stack.Count > 0)
            {
                string item = stack.Pop(); // Видаляємо з вершини
                Console.WriteLine($"  Видалено: {item}, залишилось: {stack.Count}");
            }
        }

        // ============================================
        // 4. QUEUE<T> - ЧЕРГА (FIFO)
        // ============================================

        public static void DemonstrateQueue()
        {
            Console.WriteLine("\n=== Демонстрація Queue<T> (FIFO - First In, First Out) ===");
            
            Queue<string> queue = new Queue<string>();
            
            // Додавання в кінець черги (Enqueue)
            queue.Enqueue("Перший");
            queue.Enqueue("Другий");
            queue.Enqueue("Третій");
            queue.Enqueue("Четвертий");
            
            Console.WriteLine($"Кількість елементів у черзі: {queue.Count}");
            Console.WriteLine($"Перший елемент (Peek): {queue.Peek()}");
            
            Console.WriteLine("\nОбробка черги (в порядку додавання):");
            while (queue.Count > 0)
            {
                string item = queue.Dequeue(); // Видаляємо з початку
                Console.WriteLine($"  Оброблено: {item}, залишилось: {queue.Count}");
            }
        }

        // ============================================
        // 5. SORTEDLIST<TKey, TValue> - ВІДСОРТОВАНИЙ СЛОВНИК
        // ============================================

        public static void DemonstrateSortedList()
        {
            Console.WriteLine("\n=== Демонстрація SortedList<TKey, TValue> ===");
            
            SortedList<string, int> scores = new SortedList<string, int>();
            
            // Додавання елементів (автоматично сортуються за ключем)
            scores["Олена"] = 95;
            scores["Іван"] = 87;
            scores["Марія"] = 92;
            scores["Петро"] = 78;
            
            Console.WriteLine("Оцінки (відсортовані за іменем):");
            foreach (var kvp in scores)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
            
            // Доступ за індексом (після сортування)
            Console.WriteLine($"\nПерший за алфавітом: {scores.Keys[0]} - {scores.Values[0]}");
        }

        // ============================================
        // 6. HASHSET<T> - МНОЖИНА УНІКАЛЬНИХ ЕЛЕМЕНТІВ
        // ============================================

        public static void DemonstrateHashSet()
        {
            Console.WriteLine("\n=== Демонстрація HashSet<T> ===");
            
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> set2 = new HashSet<int> { 4, 5, 6, 7, 8 };
            
            Console.WriteLine("Set1:");
            foreach (var item in set1)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            Console.WriteLine("Set2:");
            foreach (var item in set2)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            // Об'єднання (Union)
            var union = new HashSet<int>(set1);
            union.UnionWith(set2);
            Console.WriteLine("\nОб'єднання (Union):");
            foreach (var item in union)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            // Перетин (Intersection)
            var intersection = new HashSet<int>(set1);
            intersection.IntersectWith(set2);
            Console.WriteLine("Перетин (Intersection):");
            foreach (var item in intersection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            // Різниця (Difference)
            var difference = new HashSet<int>(set1);
            difference.ExceptWith(set2);
            Console.WriteLine("Різниця (Set1 - Set2):");
            foreach (var item in difference)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // ============================================
        // 7. LINKEDLIST<T> - ДВОЗВ'ЯЗНИЙ СПИСОК
        // ============================================

        public static void DemonstrateLinkedList()
        {
            Console.WriteLine("\n=== Демонстрація LinkedList<T> ===");
            
            LinkedList<string> list = new LinkedList<string>();
            
            // Додавання елементів
            var node1 = list.AddFirst("Перший");
            var node2 = list.AddAfter(node1, "Другий");
            var node3 = list.AddAfter(node2, "Третій");
            list.AddLast("Останній");
            
            Console.WriteLine("Елементи списку:");
            foreach (var item in list)
            {
                Console.Write($"{item} -> ");
            }
            Console.WriteLine("null");
            
            // Навігація
            Console.WriteLine($"\nПерший елемент: {list.First?.Value}");
            Console.WriteLine($"Останній елемент: {list.Last?.Value}");
            Console.WriteLine($"Наступний після 'Другий': {node2.Next?.Value}");
            Console.WriteLine($"Попередній перед 'Третій': {node3.Previous?.Value}");
            
            // Видалення
            list.Remove(node2);
            Console.WriteLine("\nПісля видалення 'Другий':");
            foreach (var item in list)
            {
                Console.Write($"{item} -> ");
            }
            Console.WriteLine("null");
        }

        // ============================================
        // 8. РОБОТА З ІНТЕРФЕЙСАМИ КОЛЕКЦІЙ
        // ============================================

        public static void DemonstrateInterfaces()
        {
            Console.WriteLine("\n=== Демонстрація інтерфейсів колекцій ===");
            
            // IList<T>
            IList<int> list = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("IList<T> - доступ за індексом:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
            
            // IEnumerable<T>
            IEnumerable<int> enumerable = new[] { 10, 20, 30 };
            Console.WriteLine("\nIEnumerable<T> - перебір:");
            foreach (var item in enumerable)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            
            // ICollection<T>
            ICollection<string> collection = new List<string> { "a", "b", "c" };
            Console.WriteLine($"\nICollection<T> - кількість: {collection.Count}");
            Console.WriteLine($"Чи містить 'b'? {collection.Contains("b")}");
            
            // IDictionary<TKey, TValue>
            IDictionary<string, int> dict = new Dictionary<string, int>
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3
            };
            Console.WriteLine("\nIDictionary<TKey, TValue>:");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"  {kvp.Key} = {kvp.Value}");
            }
        }

        // ============================================
        // 9. ICOMPARER<T> - ПОРІВНЯННЯ ОБ'ЄКТІВ
        // ============================================

        public class Person
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            
            public override string ToString() => $"{Name} ({Age} років)";
        }

        /// <summary>
        /// Кастомний компаратор для сортування Person за віком
        /// </summary>
        public class AgeComparer : IComparer<Person>
        {
            public int Compare(Person? x, Person? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;
                
                return x.Age.CompareTo(y.Age);
            }
        }

        public static void DemonstrateIComparer()
        {
            Console.WriteLine("\n=== Демонстрація IComparer<T> ===");
            
            List<Person> people = new List<Person>
            {
                new Person { Name = "Іван", Age = 30 },
                new Person { Name = "Марія", Age = 25 },
                new Person { Name = "Петро", Age = 35 },
                new Person { Name = "Олена", Age = 28 }
            };
            
            Console.WriteLine("До сортування:");
            foreach (var person in people)
            {
                Console.WriteLine($"  {person}");
            }
            
            // Сортування з використанням кастомного компаратора
            people.Sort(new AgeComparer());
            
            Console.WriteLine("\nПісля сортування за віком:");
            foreach (var person in people)
            {
                Console.WriteLine($"  {person}");
            }
        }

        // ============================================
        // 10. ПРАКТИЧНИЙ ПРИКЛАД: УПРАВЛІННЯ БІБЛІОТЕКОЮ
        // ============================================

        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Author { get; set; } = string.Empty;
            public int Year { get; set; }
            
            public override string ToString() => 
                $"#{Id}: '{Title}' by {Author} ({Year})";
        }

        public static void DemonstrateLibraryExample()
        {
            Console.WriteLine("\n=== Практичний приклад: Управління бібліотекою ===");
            
            // Словник для швидкого пошуку за ID
            Dictionary<int, Book> booksById = new Dictionary<int, Book>();
            
            // Список для зберігання всіх книг
            List<Book> allBooks = new List<Book>();
            
            // Додавання книг
            var book1 = new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 };
            var book2 = new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 };
            var book3 = new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 };
            
            booksById[book1.Id] = book1;
            booksById[book2.Id] = book2;
            booksById[book3.Id] = book3;
            
            allBooks.AddRange(new[] { book1, book2, book3 });
            
            Console.WriteLine("Всі книги:");
            foreach (var book in allBooks)
            {
                Console.WriteLine($"  {book}");
            }
            
            // Швидкий пошук за ID
            if (booksById.TryGetValue(2, out Book? foundBook))
            {
                Console.WriteLine($"\nЗнайдена книга за ID=2: {foundBook}");
            }
            
            // Пошук за автором
            var booksByAuthor = allBooks.Where(b => b.Author.Contains("Orwell")).ToList();
            Console.WriteLine("\nКниги автора 'Orwell':");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($"  {book}");
            }
            
            // Сортування за роком
            allBooks.Sort((a, b) => a.Year.CompareTo(b.Year));
            Console.WriteLine("\nКниги, відсортовані за роком:");
            foreach (var book in allBooks)
            {
                Console.WriteLine($"  {book}");
            }
        }
    }
}

