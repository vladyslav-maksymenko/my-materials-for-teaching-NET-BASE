using System;
using System.Collections.Generic;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Приклади використання Generics в C#
    /// </summary>
    public static class GenericExamples
    {
        // ============================================
        // 1. ПРОСТИЙ GENERIC-КЛАС
        // ============================================
        
        /// <summary>
        /// Простий Generic-клас для зберігання одного елемента будь-якого типу
        /// T - це параметр типу, який буде визначений при створенні об'єкта
        /// </summary>
        public class Box<T>
        {
            private T _item;

            /// <summary>
            /// Конструктор, який приймає елемент типу T
            /// </summary>
            public Box(T item)
            {
                _item = item;
            }

            /// <summary>
            /// Властивість для отримання та встановлення значення
            /// </summary>
            public T Item
            {
                get => _item;
                set => _item = value;
            }

            /// <summary>
            /// Метод для отримання інформації про тип збереженого елемента
            /// </summary>
            public string GetTypeInfo()
            {
                return $"Box містить елемент типу: {typeof(T).Name}, значення: {_item}";
            }
        }

        // ============================================
        // 2. GENERIC-КЛАС З ОБМЕЖЕННЯМИ
        // ============================================

        /// <summary>
        /// Generic-клас з обмеженням: T має реалізувати IComparable<T>
        /// Це дозволяє порівнювати елементи типу T
        /// </summary>
        public class SortedContainer<T> where T : IComparable<T>
        {
            private List<T> _items = new List<T>();

            /// <summary>
            /// Додає елемент та автоматично сортує колекцію
            /// </summary>
            public void Add(T item)
            {
                _items.Add(item);
                _items.Sort(); // Можемо викликати Sort(), бо T реалізує IComparable<T>
            }

            public List<T> GetItems() => _items;
        }

        /// <summary>
        /// Generic-клас з кількома обмеженнями
        /// T має бути класом (не структурою), реалізувати IEntity та мати конструктор без параметрів
        /// </summary>
        public interface IEntity
        {
            int Id { get; set; }
        }

        public class Repository<T> where T : class, IEntity, new()
        {
            private List<T> _entities = new List<T>();

            /// <summary>
            /// Створює новий об'єкт типу T (можливо, бо є new())
            /// </summary>
            public T Create()
            {
                return new T(); // Можемо створити, бо є обмеження new()
            }

            public void Add(T entity)
            {
                _entities.Add(entity);
            }

            /// <summary>
            /// Знаходить об'єкт за Id (можливо, бо T реалізує IEntity)
            /// </summary>
            public T? FindById(int id)
            {
                return _entities.Find(e => e.Id == id);
            }
        }

        // ============================================
        // 3. ВКЛАДЕНІ ТИПИ В GENERIC-КЛАСІ
        // ============================================

        /// <summary>
        /// Зовнішній Generic-клас
        /// </summary>
        public class Container<T>
        {
            private T _value;

            public Container(T value)
            {
                _value = value;
            }

            /// <summary>
            /// Властивість для отримання та встановлення значення
            /// </summary>
            public T Item
            {
                get => _value;
                set => _value = value;
            }

            /// <summary>
            /// Вкладений клас, який може використовувати параметр типу T зовнішнього класу
            /// та мати свій власний параметр типу U
            /// </summary>
            public class NestedNode<U>
            {
                private T _containerValue;
                private U _nodeValue;

                public NestedNode(T containerValue, U nodeValue)
                {
                    _containerValue = containerValue;
                    _nodeValue = nodeValue;
                }

                public string GetInfo()
                {
                    return $"Container: {_containerValue} (тип: {typeof(T).Name}), " +
                           $"Node: {_nodeValue} (тип: {typeof(U).Name})";
                }
            }
        }

        // ============================================
        // 4. GENERIC-ІНТЕРФЕЙСИ
        // ============================================

        /// <summary>
        /// Generic-інтерфейс для роботи з репозиторієм
        /// </summary>
        public interface IRepository<T> where T : IEntity
        {
            void Add(T item);
            bool Remove(int id);
            T? GetById(int id);
            IEnumerable<T> GetAll();
        }

        /// <summary>
        /// Реалізація Generic-інтерфейсу
        /// </summary>
        public class UserRepository : IRepository<User>
        {
            private List<User> _users = new List<User>();

            public void Add(User item)
            {
                _users.Add(item);
            }

            public bool Remove(int id)
            {
                var user = _users.Find(u => u.Id == id);
                if (user != null)
                {
                    _users.Remove(user);
                    return true;
                }
                return false;
            }

            public User? GetById(int id)
            {
                return _users.Find(u => u.Id == id);
            }

            public IEnumerable<User> GetAll()
            {
                return _users;
            }
        }

        /// <summary>
        /// Приклад класу, що реалізує IEntity
        /// </summary>
        public class User : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;

            public override string ToString()
            {
                return $"User [Id: {Id}, Name: {Name}, Email: {Email}]";
            }
        }

        // ============================================
        // 5. GENERIC-ДЕЛЕГАТИ
        // ============================================

        /// <summary>
        /// Generic-делегат для перетворення значення типу T
        /// </summary>
        public delegate T Transformer<T>(T input);

        /// <summary>
        /// Generic-делегат для операції над двома значеннями
        /// </summary>
        public delegate TResult Operation<T, TResult>(T a, T b);

        // ============================================
        // 6. GENERIC-МЕТОДИ
        // ============================================

        /// <summary>
        /// Статичний Generic-метод для знаходження максимального значення
        /// Обмеження: T має реалізувати IComparable<T>
        /// </summary>
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        /// <summary>
        /// Generic-метод для обміну значень двох змінних
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Generic-метод для перетворення масиву в список
        /// </summary>
        public static List<T> ArrayToList<T>(T[] array)
        {
            return new List<T>(array);
        }

        /// <summary>
        /// Generic-метод з кількома параметрами типів
        /// </summary>
        public static TResult Convert<TInput, TResult>(TInput input, Func<TInput, TResult> converter)
        {
            return converter(input);
        }

        // ============================================
        // 7. ДЕМОНСТРАЦІЙНІ МЕТОДИ
        // ============================================

        public static void DemonstrateBox()
        {
            Console.WriteLine("\n=== Демонстрація простого Generic-класу Box<T> ===");
            
            // Створюємо Box для різних типів
            var intBox = new Box<int>(42);
            var stringBox = new Box<string>("Hello Generics!");
            var doubleBox = new Box<double>(3.14);

            Console.WriteLine(intBox.GetTypeInfo());
            Console.WriteLine(stringBox.GetTypeInfo());
            Console.WriteLine(doubleBox.GetTypeInfo());
        }

        public static void DemonstrateConstraints()
        {
            Console.WriteLine("\n=== Демонстрація обмежень (Constraints) ===");
            
            // SortedContainer може працювати тільки з типами, що реалізують IComparable<T>
            var sortedInts = new SortedContainer<int>();
            sortedInts.Add(5);
            sortedInts.Add(2);
            sortedInts.Add(8);
            sortedInts.Add(1);

            Console.WriteLine("Відсортовані числа:");
            foreach (var num in sortedInts.GetItems())
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateNestedTypes()
        {
            Console.WriteLine("\n=== Демонстрація вкладених типів ===");
            
            var container = new Container<string>("ContainerValue");
            var node = new Container<string>.NestedNode<int>(container.Item, 100);
            
            Console.WriteLine(node.GetInfo());
        }

        public static void DemonstrateGenericInterfaces()
        {
            Console.WriteLine("\n=== Демонстрація Generic-інтерфейсів ===");
            
            IRepository<User> repository = new UserRepository();
            
            repository.Add(new User { Id = 1, Name = "Іван", Email = "ivan@example.com" });
            repository.Add(new User { Id = 2, Name = "Марія", Email = "maria@example.com" });
            repository.Add(new User { Id = 3, Name = "Петро", Email = "petro@example.com" });

            Console.WriteLine("Всі користувачі:");
            foreach (var user in repository.GetAll())
            {
                Console.WriteLine(user);
            }

            var foundUser = repository.GetById(2);
            Console.WriteLine($"\nЗнайдений користувач: {foundUser}");
        }

        public static void DemonstrateGenericDelegates()
        {
            Console.WriteLine("\n=== Демонстрація Generic-делегатів ===");
            
            // Створюємо делегат для подвоєння числа
            Transformer<int> doubleNumber = x => x * 2;
            Console.WriteLine($"Подвоєння 5: {doubleNumber(5)}");

            // Створюємо делегат для операції додавання
            Operation<int, int> add = (a, b) => a + b;
            Console.WriteLine($"10 + 20 = {add(10, 20)}");
        }

        public static void DemonstrateGenericMethods()
        {
            Console.WriteLine("\n=== Демонстрація Generic-методів ===");
            
            // Використання методу Max
            int maxInt = Max(10, 20);
            Console.WriteLine($"Максимум з 10 і 20: {maxInt}");

            string maxString = Max("apple", "zebra");
            Console.WriteLine($"Максимум з 'apple' і 'zebra': {maxString}");

            // Використання методу Swap
            int a = 5, b = 10;
            Console.WriteLine($"До Swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"Після Swap: a = {a}, b = {b}");

            // Використання методу Convert
            string numberStr = "123";
            int number = Convert(numberStr, int.Parse);
            Console.WriteLine($"Конвертація '{numberStr}' в int: {number}");
        }
    }
}

