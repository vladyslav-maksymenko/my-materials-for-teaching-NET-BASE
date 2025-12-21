using System;
using System.Text;
using Module11ConsoleApp.Tasks;

namespace Module11ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Модуль 11. Взаємодія з файловою системою ===\n");

            while (true)
            {
                ShowMainMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowPart1Menu();
                        break;
                    case "2":
                        ShowPart2Menu();
                        break;
                    case "0":
                        Console.WriteLine("\nДо побачення!");
                        return;
                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("\n=== Головне меню ===");
            Console.WriteLine("1. Частина перша");
            Console.WriteLine("2. Частина друга");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");
        }

        static void ShowPart1Menu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Частина перша ===");
                Console.WriteLine("1. Завдання 1: Перегляд вмісту файлу");
                Console.WriteLine("2. Завдання 2: Збереження/завантаження масиву");
                Console.WriteLine("3. Завдання 3: Генерація та розділення чисел");
                Console.WriteLine("4. Завдання 4: Пошук по файлу");
                Console.WriteLine("5. Завдання 5: Статистика файлу");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Part1Tasks.Task1_ViewFileContent();
                        break;
                    case "2":
                        Part1Tasks.Task2_ArraySaveLoad();
                        break;
                    case "3":
                        Part1Tasks.Task3_SeparateEvenOdd();
                        break;
                    case "4":
                        Part1Tasks.Task4_FileSearch();
                        break;
                    case "5":
                        Part1Tasks.Task5_FileStatistics();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некоректний вибір.");
                        break;
                }
            }
        }

        static void ShowPart2Menu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Частина друга ===");
                Console.WriteLine("1. Завдання 1: Управління рецептами");
                Console.WriteLine("2. Завдання 2: Копіювання файлу");
                Console.WriteLine("3. Завдання 3: Переміщення файлу");
                Console.WriteLine("4. Завдання 4: Копіювання папки");
                Console.WriteLine("5. Завдання 5: Переміщення папки");
                Console.WriteLine("6. Завдання 6: Валідація ПІБ (англійські літери)");
                Console.WriteLine("7. Завдання 7: Валідація віку (цифри)");
                Console.WriteLine("8. Завдання 8: Валідація адреси");
                Console.WriteLine("9. Завдання 9: Валідація email");
                Console.WriteLine("10. Завдання 10: Реєстраційна анкета");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Part2Tasks.Task1_RecipeManagement();
                        break;
                    case "2":
                        Part2Tasks.Task2_CopyFile();
                        break;
                    case "3":
                        Part2Tasks.Task3_MoveFile();
                        break;
                    case "4":
                        Part2Tasks.Task4_CopyDirectory();
                        break;
                    case "5":
                        Part2Tasks.Task5_MoveDirectory();
                        break;
                    case "6":
                        Part2Tasks.Task6_ValidateEnglishName();
                        break;
                    case "7":
                        Part2Tasks.Task7_ValidateAge();
                        break;
                    case "8":
                        Part2Tasks.Task8_ValidateAddress();
                        break;
                    case "9":
                        Part2Tasks.Task9_ValidateEmail();
                        break;
                    case "10":
                        Part2Tasks.Task10_RegistrationForm();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некоректний вибір.");
                        break;
                }
            }
        }
    }
}
