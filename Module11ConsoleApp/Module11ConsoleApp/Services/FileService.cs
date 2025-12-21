using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Module11ConsoleApp.Services
{
    public static class FileService
    {
        public static void DisplayFileContent(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return;
                }

                Console.WriteLine($"\nВміст файлу '{filePath}':");
                Console.WriteLine(new string('-', 50));
                
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string? line;
                    int lineNumber = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"{lineNumber}: {line}");
                        lineNumber++;
                    }
                }
                
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
            }
        }

        public static void SaveArrayToFile(int[] array, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    foreach (int item in array)
                    {
                        writer.WriteLine(item);
                    }
                }
                Console.WriteLine($"Масив успішно збережено у файл '{filePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні масиву: {ex.Message}");
            }
        }

        public static int[] LoadArrayFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return Array.Empty<int>();
                }

                List<int> list = new List<int>();
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int value))
                        {
                            list.Add(value);
                        }
                    }
                }
                
                Console.WriteLine($"Масив успішно завантажено з файлу '{filePath}' ({list.Count} елементів)");
                return list.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при завантаженні масиву: {ex.Message}");
                return Array.Empty<int>();
            }
        }

        public static void SeparateEvenOddNumbers(int count, string evenFilePath, string oddFilePath)
        {
            Random random = new Random();
            int evenCount = 0;
            int oddCount = 0;
            long evenSum = 0;
            long oddSum = 0;

            using (StreamWriter evenWriter = new StreamWriter(evenFilePath, false, Encoding.UTF8))
            using (StreamWriter oddWriter = new StreamWriter(oddFilePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next();
                    if (number % 2 == 0)
                    {
                        evenWriter.WriteLine(number);
                        evenCount++;
                        evenSum += number;
                    }
                    else
                    {
                        oddWriter.WriteLine(number);
                        oddCount++;
                        oddSum += number;
                    }
                }
            }

            Console.WriteLine("\n=== Статистика ===");
            Console.WriteLine($"Парні числа:");
            Console.WriteLine($"  Кількість: {evenCount}");
            Console.WriteLine($"  Сума: {evenSum}");
            Console.WriteLine($"  Середнє: {(evenCount > 0 ? (double)evenSum / evenCount : 0):F2}");
            Console.WriteLine($"  Файл: {evenFilePath}");
            
            Console.WriteLine($"\nНепарні числа:");
            Console.WriteLine($"  Кількість: {oddCount}");
            Console.WriteLine($"  Сума: {oddSum}");
            Console.WriteLine($"  Середнє: {(oddCount > 0 ? (double)oddSum / oddCount : 0):F2}");
            Console.WriteLine($"  Файл: {oddFilePath}");
        }

        public static void SearchWordInFile(string filePath, string searchWord)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return;
                }

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                string pattern = $@"\b{Regex.Escape(searchWord)}\b";
                MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);

                Console.WriteLine($"\nРезультати пошуку слова '{searchWord}':");
                if (matches.Count > 0)
                {
                    Console.WriteLine($"  Знайдено збігів: {matches.Count}");
                    Console.WriteLine($"  Позиції знаходжень:");
                    foreach (Match match in matches)
                    {
                        int lineNumber = content.Substring(0, match.Index).Split('\n').Length;
                        Console.WriteLine($"    - Рядок {lineNumber}, позиція {match.Index}");
                    }
                }
                else
                {
                    Console.WriteLine($"  Слово '{searchWord}' не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при пошуку: {ex.Message}");
            }
        }

        public static int CountWordOccurrences(string filePath, string searchWord)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return 0;
                }

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                string pattern = $@"\b{Regex.Escape(searchWord)}\b";
                MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);

                Console.WriteLine($"\nКількість входжень слова '{searchWord}': {matches.Count}");
                return matches.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при підрахунку: {ex.Message}");
                return 0;
            }
        }

        public static int SearchReversedWord(string filePath, string searchWord)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return 0;
                }

                char[] charArray = searchWord.ToCharArray();
                Array.Reverse(charArray);
                string reversedWord = new string(charArray);

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                string pattern = $@"\b{Regex.Escape(reversedWord)}\b";
                MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);

                Console.WriteLine($"\nПошук слова '{searchWord}' у зворотному порядку ('{reversedWord}'):");
                Console.WriteLine($"  Знайдено входжень: {matches.Count}");
                return matches.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при пошуку: {ex.Message}");
                return 0;
            }
        }

        public static void DisplayFileStatistics(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Помилка: Файл '{filePath}' не існує.");
                    return;
                }

                string content = File.ReadAllText(filePath, Encoding.UTF8);
                
                // Підрахунок речень (закінчуються на . ! ?)
                int sentences = Regex.Matches(content, @"[.!?]+").Count;
                
                // Підрахунок великих літер
                int uppercaseLetters = Regex.Matches(content, @"[A-ZА-ЯЁІЇЄ]").Count;
                
                // Підрахунок маленьких літер
                int lowercaseLetters = Regex.Matches(content, @"[a-zа-яёіїє]").Count;
                
                // Підрахунок голосних (українські та англійські)
                int vowels = Regex.Matches(content, @"[aeiouаеєиіїоуюяAEIOUАЕЄИІЇОУЮЯ]", RegexOptions.IgnoreCase).Count;
                
                // Підрахунок приголосних
                int consonants = Regex.Matches(content, @"[bcdfghjklmnpqrstvwxyzбвгґджзйклмнпрсттфхцчшщBCDFGHJKLMNPQRSTVWXYZБВГҐДЖЗЙКЛМНПРСТТФХЦЧШЩ]", RegexOptions.IgnoreCase).Count;
                
                // Підрахунок цифр
                int digits = Regex.Matches(content, @"\d").Count;

                Console.WriteLine($"\n=== Статистика файлу '{filePath}' ===");
                Console.WriteLine($"Кількість речень: {sentences}");
                Console.WriteLine($"Кількість великих літер: {uppercaseLetters}");
                Console.WriteLine($"Кількість маленьких літер: {lowercaseLetters}");
                Console.WriteLine($"Кількість голосних букв: {vowels}");
                Console.WriteLine($"Кількість приголосних букв: {consonants}");
                Console.WriteLine($"Кількість цифр: {digits}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при аналізі файлу: {ex.Message}");
            }
        }

        public static bool CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine($"Помилка: Файл '{sourcePath}' не існує.");
                    return false;
                }

                string? directory = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.Copy(sourcePath, destinationPath, true);
                Console.WriteLine($"Файл успішно скопійовано з '{sourcePath}' в '{destinationPath}'");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при копіюванні файлу: {ex.Message}");
                return false;
            }
        }

        public static bool MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine($"Помилка: Файл '{sourcePath}' не існує.");
                    return false;
                }

                string? directory = Path.GetDirectoryName(destinationPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.Move(sourcePath, destinationPath, true);
                Console.WriteLine($"Файл успішно переміщено з '{sourcePath}' в '{destinationPath}'");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при переміщенні файлу: {ex.Message}");
                return false;
            }
        }

        public static bool CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(sourcePath))
                {
                    Console.WriteLine($"Помилка: Папка '{sourcePath}' не існує.");
                    return false;
                }

                Directory.CreateDirectory(destinationPath);

                // Копіювання файлів
                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(destinationPath, fileName);
                    File.Copy(file, destFile, true);
                }

                // Рекурсивне копіювання підпапок
                foreach (string directory in Directory.GetDirectories(sourcePath))
                {
                    string dirName = Path.GetFileName(directory);
                    string destDir = Path.Combine(destinationPath, dirName);
                    CopyDirectory(directory, destDir);
                }

                Console.WriteLine($"Папка успішно скопійована з '{sourcePath}' в '{destinationPath}'");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при копіюванні папки: {ex.Message}");
                return false;
            }
        }

        public static bool MoveDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(sourcePath))
                {
                    Console.WriteLine($"Помилка: Папка '{sourcePath}' не існує.");
                    return false;
                }

                if (Directory.Exists(destinationPath))
                {
                    Console.WriteLine($"Помилка: Папка '{destinationPath}' вже існує.");
                    return false;
                }

                Directory.Move(sourcePath, destinationPath);
                Console.WriteLine($"Папка успішно переміщена з '{sourcePath}' в '{destinationPath}'");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при переміщенні папки: {ex.Message}");
                return false;
            }
        }
    }
}

