using System;
using System.Collections.Generic;
using System.Linq;

namespace Module9ConsoleApp
{
    /// <summary>
    /// Частина 3: Додатки з використанням колекцій
    /// </summary>
    public static class Part3Collections
    {
        // ============================================
        // Завдання 1: Додаток для обліку співробітників (List<T>)
        // ============================================
        
        public class Employee
        {
            public string FullName { get; set; } = string.Empty; // ПІБ
            public string Position { get; set; } = string.Empty; // Посада
            public decimal Salary { get; set; } // Заробітна плата
            public string Email { get; set; } = string.Empty; // Робочий email

            public override string ToString() => 
                $"{FullName} - {Position}, зарплата: {Salary:C}, email: {Email}";
        }

        public class EmployeeManagement
        {
            private readonly List<Employee> _employees = new List<Employee>();

            public void AddEmployee(Employee employee)
            {
                _employees.Add(employee);
                Console.WriteLine($"Додано співробітника: {employee.FullName}");
            }

            public bool RemoveEmployee(Employee employee)
            {
                bool removed = _employees.Remove(employee);
                if (removed)
                    Console.WriteLine($"Видалено співробітника: {employee.FullName}");
                return removed;
            }

            public bool UpdateEmployee(Employee oldEmployee, Employee newEmployee)
            {
                int index = _employees.IndexOf(oldEmployee);
                if (index >= 0)
                {
                    _employees[index] = newEmployee;
                    Console.WriteLine($"Оновлено інформацію про співробітника: {newEmployee.FullName}");
                    return true;
                }
                return false;
            }

            public List<Employee> SearchByFullName(string fullName)
            {
                return _employees.Where(e => e.FullName.Contains(fullName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Employee> SearchByPosition(string position)
            {
                return _employees.Where(e => e.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Employee> SearchBySalaryRange(decimal minSalary, decimal maxSalary)
            {
                return _employees.Where(e => e.Salary >= minSalary && e.Salary <= maxSalary).ToList();
            }

            public void SortByFullName()
            {
                _employees.Sort((a, b) => string.Compare(a.FullName, b.FullName, StringComparison.OrdinalIgnoreCase));
            }

            public void SortByPosition()
            {
                _employees.Sort((a, b) => string.Compare(a.Position, b.Position, StringComparison.OrdinalIgnoreCase));
            }

            public void SortBySalary()
            {
                _employees.Sort((a, b) => a.Salary.CompareTo(b.Salary));
            }

            public void DisplayAll()
            {
                Console.WriteLine("\nВсі співробітники:");
                foreach (var emp in _employees)
                {
                    Console.WriteLine($"  - {emp}");
                }
            }

            public int Count => _employees.Count;
        }

        // ============================================
        // Завдання 2: Додаток для обліку книг (LinkedList<T>)
        // ============================================
        
        public class Book
        {
            public string Title { get; set; } = string.Empty; // Назва книги
            public string AuthorFullName { get; set; } = string.Empty; // ПІБ автора
            public string Genre { get; set; } = string.Empty; // Жанр книги
            public int Year { get; set; } // Рік випуску

            public override string ToString() => 
                $"'{Title}' - {AuthorFullName}, {Genre} ({Year})";
        }

        public class BookManagement
        {
            private readonly LinkedList<Book> _books = new LinkedList<Book>();

            public void AddBook(Book book)
            {
                _books.AddLast(book);
                Console.WriteLine($"Додано книгу: {book.Title}");
            }

            public bool RemoveBook(Book book)
            {
                var node = _books.Find(book);
                if (node != null)
                {
                    _books.Remove(node);
                    Console.WriteLine($"Видалено книгу: {book.Title}");
                    return true;
                }
                return false;
            }

            public bool UpdateBook(Book oldBook, Book newBook)
            {
                var node = _books.Find(oldBook);
                if (node != null)
                {
                    node.Value = newBook;
                    Console.WriteLine($"Оновлено інформацію про книгу: {newBook.Title}");
                    return true;
                }
                return false;
            }

            public List<Book> SearchByTitle(string title)
            {
                return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Book> SearchByAuthor(string author)
            {
                return _books.Where(b => b.AuthorFullName.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Book> SearchByGenre(string genre)
            {
                return _books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public List<Book> SearchByYear(int year)
            {
                return _books.Where(b => b.Year == year).ToList();
            }

            public void AddToBeginning(Book book)
            {
                _books.AddFirst(book);
                Console.WriteLine($"Додано книгу на початок: {book.Title}");
            }

            public void AddToEnd(Book book)
            {
                _books.AddLast(book);
                Console.WriteLine($"Додано книгу в кінець: {book.Title}");
            }

            public void InsertAt(int position, Book book)
            {
                if (position < 0 || position > _books.Count)
                {
                    Console.WriteLine($"Невірна позиція: {position}");
                    return;
                }

                var current = _books.First;
                for (int i = 0; i < position && current != null; i++)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    _books.AddBefore(current, book);
                }
                else
                {
                    _books.AddLast(book);
                }

                Console.WriteLine($"Вставлено книгу на позицію {position}: {book.Title}");
            }

            public bool RemoveFromBeginning()
            {
                if (_books.First != null)
                {
                    var book = _books.First.Value;
                    _books.RemoveFirst();
                    Console.WriteLine($"Видалено книгу з початку: {book.Title}");
                    return true;
                }
                return false;
            }

            public bool RemoveFromEnd()
            {
                if (_books.Last != null)
                {
                    var book = _books.Last.Value;
                    _books.RemoveLast();
                    Console.WriteLine($"Видалено книгу з кінця: {book.Title}");
                    return true;
                }
                return false;
            }

            public bool RemoveAt(int position)
            {
                if (position < 0 || position >= _books.Count)
                {
                    Console.WriteLine($"Невірна позиція: {position}");
                    return false;
                }

                var current = _books.First;
                for (int i = 0; i < position && current != null; i++)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    var book = current.Value;
                    _books.Remove(current);
                    Console.WriteLine($"Видалено книгу з позиції {position}: {book.Title}");
                    return true;
                }
                return false;
            }

            public void DisplayAll()
            {
                Console.WriteLine("\nВсі книги:");
                int index = 0;
                foreach (var book in _books)
                {
                    Console.WriteLine($"  [{index++}] {book}");
                }
            }

            public int Count => _books.Count;
        }

        // ============================================
        // Завдання 3: Додаток, що емулює чергу в поліклініку (PriorityQueue)
        // ============================================
        
        public class Patient
        {
            public string Name { get; set; } = string.Empty;
            public int Priority { get; set; } // Пріоритет (менше = вище пріоритет)
            public DateTime ArrivalTime { get; set; }

            public override string ToString() => 
                $"{Name} (пріоритет: {Priority}, прийшов: {ArrivalTime:HH:mm:ss})";
        }

        public class ClinicQueue
        {
            private readonly PriorityQueue<Patient, int> _queue = new PriorityQueue<Patient, int>();

            public void AddPatient(Patient patient)
            {
                _queue.Enqueue(patient, patient.Priority);
                Console.WriteLine($"Пацієнт {patient.Name} доданий до черги (пріоритет: {patient.Priority})");
                
                if (_queue.Count > 3)
                {
                    Console.WriteLine($"  Увага: В черзі {_queue.Count} пацієнтів. {patient.Name} потрапив в кінець черги.");
                }
            }

            public Patient? ProcessNextPatient()
            {
                if (_queue.TryDequeue(out Patient? patient, out int priority))
                {
                    Console.WriteLine($"Лікар приймає пацієнта: {patient}");
                    return patient;
                }
                return null;
            }

            public void DisplayQueue()
            {
                Console.WriteLine($"\nПоточна черга ({_queue.Count} пацієнтів):");
                
                // PriorityQueue не підтримує прямого перегляду, тому створюємо копію
                var tempQueue = new PriorityQueue<Patient, int>(_queue.UnorderedItems);
                int position = 1;
                
                while (tempQueue.Count > 0)
                {
                    if (tempQueue.TryDequeue(out Patient? patient, out int priority))
                    {
                        Console.WriteLine($"  {position++}. {patient}");
                    }
                }
            }

            public int Count => _queue.Count;
        }

        // ============================================
        // Завдання 4: Додаток для керування абонементами в спортзалі (Stack<T>)
        // ============================================
        
        public class Visit
        {
            public string ClientName { get; set; } = string.Empty;
            public DateTime VisitDate { get; set; }
            public string Activity { get; set; } = string.Empty; // Тренування, басейн, тощо

            public override string ToString() => 
                $"{ClientName} - {VisitDate:yyyy-MM-dd HH:mm:ss}, активність: {Activity}";
        }

        public class GymMembership
        {
            private readonly Dictionary<string, Stack<Visit>> _clientVisits = new Dictionary<string, Stack<Visit>>();

            public void AddVisit(string clientName, string activity)
            {
                if (!_clientVisits.ContainsKey(clientName))
                {
                    _clientVisits[clientName] = new Stack<Visit>();
                }

                var visit = new Visit
                {
                    ClientName = clientName,
                    VisitDate = DateTime.Now,
                    Activity = activity
                };

                _clientVisits[clientName].Push(visit);
                Console.WriteLine($"Додано відвідування для {clientName}: {activity}");
            }

            public void ViewLastVisits(string clientName, int count)
            {
                if (!_clientVisits.ContainsKey(clientName) || _clientVisits[clientName].Count == 0)
                {
                    Console.WriteLine($"Немає відвідувань для клієнта {clientName}");
                    return;
                }

                Console.WriteLine($"\nОстанні {count} відвідувань для {clientName}:");
                var visits = _clientVisits[clientName].ToArray();
                int shown = 0;
                
                for (int i = visits.Length - 1; i >= 0 && shown < count; i--)
                {
                    Console.WriteLine($"  {shown + 1}. {visits[i]}");
                    shown++;
                }
            }

            public bool CancelLastVisit(string clientName)
            {
                if (_clientVisits.ContainsKey(clientName) && _clientVisits[clientName].Count > 0)
                {
                    var visit = _clientVisits[clientName].Pop();
                    Console.WriteLine($"Скасовано останнє відвідування для {clientName}: {visit}");
                    return true;
                }
                Console.WriteLine($"Немає відвідувань для скасування для клієнта {clientName}");
                return false;
            }

            public void DisplayRecentVisits(DateTime fromDate, DateTime toDate)
            {
                Console.WriteLine($"\nВідвідування всіх клієнтів з {fromDate:yyyy-MM-dd} по {toDate:yyyy-MM-dd}:");
                bool found = false;

                foreach (var kvp in _clientVisits)
                {
                    var visits = kvp.Value.ToArray();
                    foreach (var visit in visits)
                    {
                        if (visit.VisitDate >= fromDate && visit.VisitDate <= toDate)
                        {
                            Console.WriteLine($"  - {visit}");
                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("  Відвідувань не знайдено за вказаний період.");
                }
            }

            public int GetVisitCount(string clientName)
            {
                return _clientVisits.ContainsKey(clientName) ? _clientVisits[clientName].Count : 0;
            }
        }

        // ============================================
        // Демонстраційні методи
        // ============================================
        
        public static void DemonstrateTask1()
        {
            Console.WriteLine("\n=== Завдання 1: Облік співробітників (List<T>) ===");
            
            var management = new EmployeeManagement();
            
            // Додавання співробітників
            management.AddEmployee(new Employee
            {
                FullName = "Іван Петренко",
                Position = "Розробник",
                Salary = 50000,
                Email = "ivan.petrenko@company.com"
            });
            
            management.AddEmployee(new Employee
            {
                FullName = "Марія Коваленко",
                Position = "Менеджер",
                Salary = 45000,
                Email = "maria.kovalenko@company.com"
            });
            
            management.AddEmployee(new Employee
            {
                FullName = "Петро Сидоренко",
                Position = "Розробник",
                Salary = 55000,
                Email = "petro.sydorenko@company.com"
            });
            
            management.DisplayAll();
            
            // Пошук
            Console.WriteLine("\nПошук за посадою 'Розробник':");
            foreach (var emp in management.SearchByPosition("Розробник"))
            {
                Console.WriteLine($"  - {emp}");
            }
            
            Console.WriteLine("\nПошук за зарплатою від 45000 до 52000:");
            foreach (var emp in management.SearchBySalaryRange(45000, 52000))
            {
                Console.WriteLine($"  - {emp}");
            }
            
            // Сортування
            Console.WriteLine("\nСортування за ПІБ:");
            management.SortByFullName();
            management.DisplayAll();
            
            Console.WriteLine("\nСортування за зарплатою:");
            management.SortBySalary();
            management.DisplayAll();
        }

        public static void DemonstrateTask2()
        {
            Console.WriteLine("\n=== Завдання 2: Облік книг (LinkedList<T>) ===");
            
            var bookManagement = new BookManagement();
            
            // Додавання книг
            bookManagement.AddBook(new Book
            {
                Title = "1984",
                AuthorFullName = "George Orwell",
                Genre = "Антиутопія",
                Year = 1949
            });
            
            bookManagement.AddBook(new Book
            {
                Title = "Гаррі Поттер",
                AuthorFullName = "J.K. Rowling",
                Genre = "Фентезі",
                Year = 1997
            });
            
            bookManagement.DisplayAll();
            
            // Вставка на початок
            bookManagement.AddToBeginning(new Book
            {
                Title = "Війна і мир",
                AuthorFullName = "Лев Толстой",
                Genre = "Роман",
                Year = 1869
            });
            
            // Вставка в кінець
            bookManagement.AddToEnd(new Book
            {
                Title = "Маленький принц",
                AuthorFullName = "Antoine de Saint-Exupéry",
                Genre = "Казка",
                Year = 1943
            });
            
            // Вставка на позицію
            bookManagement.InsertAt(2, new Book
            {
                Title = "Майстер і Маргарита",
                AuthorFullName = "Михайло Булгаков",
                Genre = "Роман",
                Year = 1967
            });
            
            bookManagement.DisplayAll();
            
            // Пошук
            Console.WriteLine("\nПошук за жанром 'Роман':");
            foreach (var book in bookManagement.SearchByGenre("Роман"))
            {
                Console.WriteLine($"  - {book}");
            }
            
            // Видалення
            Console.WriteLine("\nВидалення з початку:");
            bookManagement.RemoveFromBeginning();
            
            Console.WriteLine("\nВидалення з кінця:");
            bookManagement.RemoveFromEnd();
            
            Console.WriteLine("\nВидалення з позиції 1:");
            bookManagement.RemoveAt(1);
            
            bookManagement.DisplayAll();
        }

        public static void DemonstrateTask3()
        {
            Console.WriteLine("\n=== Завдання 3: Черга в поліклініку (PriorityQueue) ===");
            
            var clinic = new ClinicQueue();
            
            // Додавання пацієнтів
            clinic.AddPatient(new Patient
            {
                Name = "Іван Петренко",
                Priority = 2,
                ArrivalTime = DateTime.Now.AddMinutes(-30)
            });
            
            clinic.AddPatient(new Patient
            {
                Name = "Марія Коваленко",
                Priority = 1, // Вищий пріоритет
                ArrivalTime = DateTime.Now.AddMinutes(-20)
            });
            
            clinic.AddPatient(new Patient
            {
                Name = "Петро Сидоренко",
                Priority = 3,
                ArrivalTime = DateTime.Now.AddMinutes(-10)
            });
            
            clinic.AddPatient(new Patient
            {
                Name = "Олена Іваненко",
                Priority = 2,
                ArrivalTime = DateTime.Now
            });
            
            clinic.DisplayQueue();
            
            // Лікар приймає пацієнтів
            Console.WriteLine("\n--- Лікар приймає пацієнтів ---");
            clinic.ProcessNextPatient();
            clinic.ProcessNextPatient();
            
            clinic.DisplayQueue();
        }

        public static void DemonstrateTask4()
        {
            Console.WriteLine("\n=== Завдання 4: Керування абонементами в спортзалі (Stack<T>) ===");
            
            var gym = new GymMembership();
            
            // Додавання відвідувань
            gym.AddVisit("Іван Петренко", "Тренування з вагами");
            System.Threading.Thread.Sleep(100); // Невелика затримка для різних часів
            
            gym.AddVisit("Марія Коваленко", "Басейн");
            System.Threading.Thread.Sleep(100);
            
            gym.AddVisit("Іван Петренко", "Кардіо тренування");
            System.Threading.Thread.Sleep(100);
            
            gym.AddVisit("Петро Сидоренко", "Йога");
            System.Threading.Thread.Sleep(100);
            
            gym.AddVisit("Іван Петренко", "Тренування з вагами");
            System.Threading.Thread.Sleep(100);
            
            gym.AddVisit("Марія Коваленко", "Аеробіка");
            
            // Перегляд останніх відвідувань
            gym.ViewLastVisits("Іван Петренко", 3);
            gym.ViewLastVisits("Марія Коваленко", 2);
            
            // Скасування останнього візиту
            Console.WriteLine("\n--- Скасування останнього візиту ---");
            gym.CancelLastVisit("Іван Петренко");
            gym.ViewLastVisits("Іван Петренко", 3);
            
            // Виведення відвідувань за період
            Console.WriteLine("\n--- Відвідування за останній день ---");
            gym.DisplayRecentVisits(DateTime.Now.AddDays(-1), DateTime.Now);
        }

        public static void RunAllTasks()
        {
            Console.WriteLine("\n" + new string('═', 70));
            Console.WriteLine("ЧАСТИНА 3: КОЛЕКЦІЇ");
            Console.WriteLine(new string('═', 70));
            
            DemonstrateTask1();
            DemonstrateTask2();
            DemonstrateTask3();
            DemonstrateTask4();
        }
    }
}

