using System;
using System.Text;
using Module11ConsoleApp.Services;

namespace Module11ConsoleApp.Tasks
{
    public static class Part1Tasks
    {
        public static void Task1_ViewFileContent()
        {
            Console.WriteLine("\n=== Завдання 1: Перегляд вмісту файлу ===");
            Console.Write("Введіть шлях до файлу: ");
            string? filePath = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Помилка: Шлях до файлу не може бути порожнім.");
                return;
            }

            FileService.DisplayFileContent(filePath);
        }

        public static void Task2_ArraySaveLoad()
        {
            Console.WriteLine("\n=== Завдання 2: Робота з масивом ===");
            
            Console.Write("Введіть кількість елементів масиву: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Помилка: Некоректна кількість елементів.");
                return;
            }

            int[] array = new int[count];
            Console.WriteLine($"Введіть {count} елементів масиву:");
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Елемент [{i}]: ");
                if (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine($"Помилка: Некоректне значення для елемента [{i}].");
                    return;
                }
            }

            Console.WriteLine("\nВиберіть дію:");
            Console.WriteLine("1. Зберегти масив у файл");
            Console.WriteLine("2. Завантажити масив з файлу");
            Console.Write("Ваш вибір: ");
            
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть шлях до файлу для збереження: ");
                    string? savePath = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(savePath))
                    {
                        FileService.SaveArrayToFile(array, savePath);
                    }
                    break;
                case "2":
                    Console.Write("Введіть шлях до файлу для завантаження: ");
                    string? loadPath = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadPath))
                    {
                        int[] loadedArray = FileService.LoadArrayFromFile(loadPath);
                        if (loadedArray.Length > 0)
                        {
                            Console.WriteLine("\nЗавантажений масив:");
                            for (int i = 0; i < loadedArray.Length; i++)
                            {
                                Console.WriteLine($"  [{i}] = {loadedArray[i]}");
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }

        public static void Task3_SeparateEvenOdd()
        {
            Console.WriteLine("\n=== Завдання 3: Генерація та розділення чисел ===");
            
            Console.Write("Введіть шлях для файлу з парними числами: ");
            string? evenPath = Console.ReadLine();
            Console.Write("Введіть шлях для файлу з непарними числами: ");
            string? oddPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(evenPath) || string.IsNullOrWhiteSpace(oddPath))
            {
                Console.WriteLine("Помилка: Шляхи до файлів не можуть бути порожніми.");
                return;
            }

            FileService.SeparateEvenOddNumbers(10000, evenPath, oddPath);
        }

        public static void Task4_FileSearch()
        {
            Console.WriteLine("\n=== Завдання 4: Пошук по файлу ===");
            Console.Write("Введіть шлях до файлу: ");
            string? filePath = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Помилка: Шлях до файлу не може бути порожнім.");
                return;
            }

            Console.WriteLine("\nВиберіть тип пошуку:");
            Console.WriteLine("1. Пошук заданого слова");
            Console.WriteLine("2. Підрахунок кількості входжень слова");
            Console.WriteLine("3. Пошук слова у зворотному порядку");
            Console.Write("Ваш вибір: ");
            
            string? choice = Console.ReadLine();
            Console.Write("Введіть слово для пошуку: ");
            string? searchWord = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchWord))
            {
                Console.WriteLine("Помилка: Слово для пошуку не може бути порожнім.");
                return;
            }

            switch (choice)
            {
                case "1":
                    FileService.SearchWordInFile(filePath, searchWord);
                    break;
                case "2":
                    FileService.CountWordOccurrences(filePath, searchWord);
                    break;
                case "3":
                    FileService.SearchReversedWord(filePath, searchWord);
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }

        public static void Task5_FileStatistics()
        {
            Console.WriteLine("\n=== Завдання 5: Статистика файлу ===");
            Console.Write("Введіть шлях до файлу: ");
            string? filePath = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Помилка: Шлях до файлу не може бути порожнім.");
                return;
            }

            FileService.DisplayFileStatistics(filePath);
        }
    }
}

