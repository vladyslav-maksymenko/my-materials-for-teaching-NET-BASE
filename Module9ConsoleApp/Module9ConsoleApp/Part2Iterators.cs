using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Частина 2: Реалізація ітераторів для різних класів
    /// </summary>
    public static class Part2Iterators
    {
        // ============================================
        // Завдання 1: Клас "Алфавіт"
        // ============================================
        
        /// <summary>
        /// Клас, що містить літери англійського алфавіту з підтримкою ітератора
        /// </summary>
        public class Alphabet : IEnumerable<char>
        {
            private readonly char[] _letters;

            public Alphabet()
            {
                // Створюємо масив з 26 літер англійського алфавіту
                _letters = new char[26];
                for (int i = 0; i < 26; i++)
                {
                    _letters[i] = (char)('A' + i);
                }
            }

            public IEnumerator<char> GetEnumerator()
            {
                foreach (var letter in _letters)
                {
                    yield return letter;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        // ============================================
        // Завдання 2: Класи "Будинок" та "Квартира"
        // ============================================
        
        /// <summary>
        /// Клас, що представляє мешканця квартири
        /// </summary>
        public class Resident
        {
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }

            public override string ToString() => $"{Name} ({Age} років)";
        }

        /// <summary>
        /// Клас, що представляє квартиру з мешканцями
        /// </summary>
        public class Apartment : IEnumerable<Resident>
        {
            private readonly List<Resident> _residents = new List<Resident>();
            public int Number { get; set; }

            public Apartment(int number)
            {
                Number = number;
            }

            public void AddResident(Resident resident)
            {
                _residents.Add(resident);
            }

            public IEnumerator<Resident> GetEnumerator()
            {
                foreach (var resident in _residents)
                {
                    yield return resident;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString() => $"Квартира №{Number}";
        }

        /// <summary>
        /// Клас, що представляє будинок з квартирами
        /// </summary>
        public class House : IEnumerable<Apartment>
        {
            private readonly List<Apartment> _apartments = new List<Apartment>();
            public string Address { get; set; } = string.Empty;

            public House(string address)
            {
                Address = address;
            }

            public void AddApartment(Apartment apartment)
            {
                _apartments.Add(apartment);
            }

            public IEnumerator<Apartment> GetEnumerator()
            {
                foreach (var apartment in _apartments)
                {
                    yield return apartment;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString() => $"Будинок за адресою: {Address}";
        }

        // ============================================
        // Завдання 3: Класи "Гараж" та "Автомобіль"
        // ============================================
        
        /// <summary>
        /// Клас, що представляє автомобіль
        /// </summary>
        public class Car
        {
            public string Brand { get; set; } = string.Empty;
            public string Model { get; set; } = string.Empty;
            public int Year { get; set; }
            public string LicensePlate { get; set; } = string.Empty;

            public override string ToString() => 
                $"{Brand} {Model} ({Year}), номер: {LicensePlate}";
        }

        /// <summary>
        /// Клас, що представляє гараж з автомобілями
        /// </summary>
        public class Garage : IEnumerable<Car>
        {
            private readonly List<Car> _cars = new List<Car>();
            public string Address { get; set; } = string.Empty;

            public Garage(string address)
            {
                Address = address;
            }

            public void AddCar(Car car)
            {
                _cars.Add(car);
            }

            public IEnumerator<Car> GetEnumerator()
            {
                foreach (var car in _cars)
                {
                    yield return car;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString() => $"Гараж за адресою: {Address}";
        }

        // ============================================
        // Завдання 4: Узагальнений клас Бібліотека<T>
        // ============================================
        
        /// <summary>
        /// Базовий клас для книги
        /// </summary>
        public abstract class BookBase
        {
            public string Title { get; set; } = string.Empty;
            public string Author { get; set; } = string.Empty;
            public int Year { get; set; }
            public string Genre { get; set; } = string.Empty;

            public override string ToString() => 
                $"'{Title}' - {Author} ({Year}), жанр: {Genre}";
        }

        /// <summary>
        /// Клас для друкованої книги
        /// </summary>
        public class PrintedBook : BookBase
        {
            public int Pages { get; set; }
            public string Publisher { get; set; } = string.Empty;

            public override string ToString() => 
                base.ToString() + $", {Pages} сторінок, видавництво: {Publisher}";
        }

        /// <summary>
        /// Клас для електронної книги
        /// </summary>
        public class ElectronicBook : BookBase
        {
            public string Format { get; set; } = string.Empty; // PDF, EPUB, etc.
            public long FileSize { get; set; } // в байтах

            public override string ToString() => 
                base.ToString() + $", формат: {Format}, розмір: {FileSize} байт";
        }

        /// <summary>
        /// Узагальнений клас бібліотеки з підтримкою ітератора
        /// </summary>
        public class Library<T> : IEnumerable<T> where T : BookBase
        {
            private readonly List<T> _books = new List<T>();

            public void AddBook(T book)
            {
                _books.Add(book);
            }

            public bool RemoveBook(T book)
            {
                return _books.Remove(book);
            }

            /// <summary>
            /// Пошук книг за жанром
            /// </summary>
            public IEnumerable<T> FindByGenre(string genre)
            {
                foreach (var book in _books)
                {
                    if (book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                    {
                        yield return book;
                    }
                }
            }

            /// <summary>
            /// Пошук книг за роком видання
            /// </summary>
            public IEnumerable<T> FindByYear(int year)
            {
                foreach (var book in _books)
                {
                    if (book.Year == year)
                    {
                        yield return book;
                    }
                }
            }

            /// <summary>
            /// Пошук книг за автором
            /// </summary>
            public IEnumerable<T> FindByAuthor(string author)
            {
                foreach (var book in _books)
                {
                    if (book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                    {
                        yield return book;
                    }
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var book in _books)
                {
                    yield return book;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int Count => _books.Count;
        }

        // ============================================
        // Демонстраційні методи
        // ============================================
        
        public static void DemonstrateTask1()
        {
            Console.WriteLine("\n=== Завдання 1: Клас 'Алфавіт' з ітератором ===");
            
            var alphabet = new Alphabet();
            
            Console.WriteLine("Літери англійського алфавіту (через foreach):");
            foreach (var letter in alphabet)
            {
                Console.Write($"{letter} ");
            }
            Console.WriteLine();
        }

        public static void DemonstrateTask2()
        {
            Console.WriteLine("\n=== Завдання 2: Класи 'Будинок' та 'Квартира' з ітераторами ===");
            
            // Створюємо будинок
            var house = new House("вул. Хрещатик, 1");
            
            // Створюємо квартири
            var apt1 = new Apartment(1);
            apt1.AddResident(new Resident { Name = "Іван Петренко", Age = 35 });
            apt1.AddResident(new Resident { Name = "Марія Петренко", Age = 32 });
            
            var apt2 = new Apartment(2);
            apt2.AddResident(new Resident { Name = "Петро Коваленко", Age = 28 });
            
            var apt3 = new Apartment(3);
            apt3.AddResident(new Resident { Name = "Олена Сидоренко", Age = 45 });
            apt3.AddResident(new Resident { Name = "Андрій Сидоренко", Age = 47 });
            apt3.AddResident(new Resident { Name = "Софія Сидоренко", Age = 12 });
            
            house.AddApartment(apt1);
            house.AddApartment(apt2);
            house.AddApartment(apt3);
            
            Console.WriteLine(house);
            Console.WriteLine("\nКвартири в будинку (через foreach):");
            foreach (var apartment in house)
            {
                Console.WriteLine($"\n  {apartment}");
                Console.WriteLine("  Мешканці:");
                foreach (var resident in apartment)
                {
                    Console.WriteLine($"    - {resident}");
                }
            }
        }

        public static void DemonstrateTask3()
        {
            Console.WriteLine("\n=== Завдання 3: Класи 'Гараж' та 'Автомобіль' з ітератором ===");
            
            var garage = new Garage("вул. Автомобільна, 10");
            
            garage.AddCar(new Car 
            { 
                Brand = "Toyota", 
                Model = "Camry", 
                Year = 2020, 
                LicensePlate = "AA1234BB" 
            });
            
            garage.AddCar(new Car 
            { 
                Brand = "BMW", 
                Model = "X5", 
                Year = 2019, 
                LicensePlate = "BC5678DE" 
            });
            
            garage.AddCar(new Car 
            { 
                Brand = "Mercedes-Benz", 
                Model = "C-Class", 
                Year = 2021, 
                LicensePlate = "EF9012GH" 
            });
            
            Console.WriteLine(garage);
            Console.WriteLine("\nАвтомобілі в гаражі (через foreach):");
            foreach (var car in garage)
            {
                Console.WriteLine($"  - {car}");
            }
        }

        public static void DemonstrateTask4()
        {
            Console.WriteLine("\n=== Завдання 4: Узагальнений клас Бібліотека<T> ===");
            
            // Бібліотека друкованих книг
            var printedLibrary = new Library<PrintedBook>();
            
            printedLibrary.AddBook(new PrintedBook
            {
                Title = "1984",
                Author = "George Orwell",
                Year = 1949,
                Genre = "Антиутопія",
                Pages = 328,
                Publisher = "Secker & Warburg"
            });
            
            printedLibrary.AddBook(new PrintedBook
            {
                Title = "Гаррі Поттер і філософський камінь",
                Author = "J.K. Rowling",
                Year = 1997,
                Genre = "Фентезі",
                Pages = 320,
                Publisher = "Bloomsbury"
            });
            
            printedLibrary.AddBook(new PrintedBook
            {
                Title = "Війна і мир",
                Author = "Лев Толстой",
                Year = 1869,
                Genre = "Роман",
                Pages = 1225,
                Publisher = "Русский вестник"
            });
            
            Console.WriteLine("\n--- Бібліотека друкованих книг ---");
            Console.WriteLine("Всі книги (через foreach):");
            foreach (var book in printedLibrary)
            {
                Console.WriteLine($"  - {book}");
            }
            
            Console.WriteLine("\nПошук за жанром 'Фентезі':");
            foreach (var book in printedLibrary.FindByGenre("Фентезі"))
            {
                Console.WriteLine($"  - {book}");
            }
            
            Console.WriteLine("\nПошук за роком 1949:");
            foreach (var book in printedLibrary.FindByYear(1949))
            {
                Console.WriteLine($"  - {book}");
            }
            
            // Бібліотека електронних книг
            var electronicLibrary = new Library<ElectronicBook>();
            
            electronicLibrary.AddBook(new ElectronicBook
            {
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Year = 2008,
                Genre = "Програмування",
                Format = "PDF",
                FileSize = 5242880 // 5 MB
            });
            
            electronicLibrary.AddBook(new ElectronicBook
            {
                Title = "Design Patterns",
                Author = "Gang of Four",
                Year = 1994,
                Genre = "Програмування",
                Format = "EPUB",
                FileSize = 3145728 // 3 MB
            });
            
            Console.WriteLine("\n--- Бібліотека електронних книг ---");
            Console.WriteLine("Всі книги (через foreach):");
            foreach (var book in electronicLibrary)
            {
                Console.WriteLine($"  - {book}");
            }
            
            Console.WriteLine("\nПошук за жанром 'Програмування':");
            foreach (var book in electronicLibrary.FindByGenre("Програмування"))
            {
                Console.WriteLine($"  - {book}");
            }
        }

        public static void RunAllTasks()
        {
            Console.WriteLine("\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 2: ІТЕРАТОРИ");
            Console.WriteLine(new string('═', 70));
            
            DemonstrateTask1();
            DemonstrateTask2();
            DemonstrateTask3();
            DemonstrateTask4();
        }
    }
}

