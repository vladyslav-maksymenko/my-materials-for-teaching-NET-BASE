using Module11ConsoleApp.Tasks;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Module11ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Модуль 11. Взаємодія з файловою системою ===\n");

            // 1. Модель потоків у C#. Простір System.IO
            DemonstrateStreamBasics();

            // 2. Клас Stream
            DemonstrateStreamClass();

            // 3. Байтові класи потоків
            DemonstrateByteStreams();

            // 4. Символьні класи потоків
            DemonstrateCharacterStreams();

            // 5. Двійкові класи потоків
            DemonstrateBinaryStreams();

            // 6. FileStream
            DemonstrateFileStream();

            // 7. StreamWriter
            DemonstrateStreamWriter();

            // 8. StreamReader
            DemonstrateStreamReader();

            // 9. BinaryWriter
            DemonstrateBinaryWriter();

            // 10. BinaryReader
            DemonstrateBinaryReader();

            // 11. Directory, DirectoryInfo, FileInfo
            DemonstrateFileSystemClasses();

            // 12. Регулярні вирази
            DemonstrateRegularExpressions();

            Console.WriteLine("\n=== Всі приклади виконано успішно ===");

            Console.WriteLine("=== Модуль 11. Взаємодія з файловою системою. Практика=\n");
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

        // 1. Модель потоків у C#. Простір System.IO
        static void DemonstrateStreamBasics()
        {
            Console.WriteLine("\n--- 1. Модель потоків у C# ---");

            // MemoryStream - приклад базового потоку
            using (MemoryStream ms = new MemoryStream())
            {
                Console.WriteLine($"CanRead: {ms.CanRead}");
                Console.WriteLine($"CanWrite: {ms.CanWrite}");
                Console.WriteLine($"CanSeek: {ms.CanSeek}");
                Console.WriteLine($"Length: {ms.Length}");
                Console.WriteLine($"Position: {ms.Position}");
            }
        }

        // 2. Клас Stream
        static void DemonstrateStreamClass()
        {
            Console.WriteLine("\n--- 2. Клас Stream ---");

            using (MemoryStream stream = new MemoryStream())
            {
                // Запис даних
                byte[] data = { 1, 2, 3, 4, 5 };
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"Записано {data.Length} байтів");

                // Повернення на початок
                stream.Position = 0;
                Console.WriteLine($"Позиція після Seek: {stream.Position}");

                // Читання даних
                byte[] buffer = new byte[5];
                int bytesRead = stream.Read(buffer, 0, 5);
                Console.WriteLine($"Прочитано {bytesRead} байтів: {string.Join(", ", buffer)}");
            }
        }

        // 3. Байтові класи потоків
        static void DemonstrateByteStreams()
        {
            Console.WriteLine("\n--- 3. Байтові класи потоків ---");

            // FileStream - робота з файлами
            string fileName = "byte_data.bin";

            // Запис байтів у файл
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] data = { 65, 66, 67, 68, 69 }; // ABCDE в ASCII
                fs.Write(data, 0, data.Length);
                Console.WriteLine($"Записано байти у файл {fileName}");
            }

            // Читання байтів з файлу
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] buffer = new byte[5];
                int bytesRead = fs.Read(buffer, 0, 5);
                Console.WriteLine($"Прочитано байти: {string.Join(", ", buffer)}");
                Console.WriteLine($"Як текст: {Encoding.ASCII.GetString(buffer)}");
            }

            // MemoryStream - робота з пам'яттю
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] data = { 1, 2, 3, 4, 5 };
                ms.Write(data, 0, data.Length);
                byte[] result = ms.ToArray();
                Console.WriteLine($"MemoryStream дані: {string.Join(", ", result)}");
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 4. Символьні класи потоків
        static void DemonstrateCharacterStreams()
        {
            Console.WriteLine("\n--- 4. Символьні класи потоків ---");

            string fileName = "text_data.txt";

            // StreamWriter - запис тексту
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Перший рядок");
                writer.WriteLine("Другий рядок");
                writer.Write("Третій рядок без переносу");
                writer.WriteLine(); // Додаємо перенос
                Console.WriteLine($"Записано текст у файл {fileName}");
            }

            // StreamReader - читання тексту
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                Console.WriteLine("Вміст файлу:");
                string? line;
                int lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"  Рядок {lineNumber}: {line}");
                    lineNumber++;
                }
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 5. Двійкові класи потоків
        static void DemonstrateBinaryStreams()
        {
            Console.WriteLine("\n--- 5. Двійкові класи потоків ---");

            string fileName = "binary_data.dat";

            // BinaryWriter - запис двійкових даних
            using (BinaryWriter writer = new BinaryWriter(File.Create(fileName)))
            {
                writer.Write("Іван Петренко");
                writer.Write(20);
                writer.Write(85.5);
                writer.Write(true);
                Console.WriteLine($"Записано двійкові дані у файл {fileName}");
            }

            // BinaryReader - читання двійкових даних
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                double average = reader.ReadDouble();
                bool hasScholarship = reader.ReadBoolean();

                Console.WriteLine($"Прочитано дані:");
                Console.WriteLine($"  Ім'я: {name}");
                Console.WriteLine($"  Вік: {age}");
                Console.WriteLine($"  Середній бал: {average}");
                Console.WriteLine($"  Стипендія: {hasScholarship}");
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 6. FileStream
        static void DemonstrateFileStream()
        {
            Console.WriteLine("\n--- 6. FileStream ---");

            string fileName = "filestream_example.bin";

            // Створення та запис
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello, FileStream!");
                fs.Write(data, 0, data.Length);
                fs.Flush();
                Console.WriteLine($"Записано у файл через FileStream");
            }

            // Читання з позиціонуванням
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                // Переміщення на позицію 7
                fs.Seek(7, SeekOrigin.Begin);
                Console.WriteLine($"Позиція після Seek(7): {fs.Position}");

                byte[] buffer = new byte[5];
                int bytesRead = fs.Read(buffer, 0, 5);
                string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Прочитано з позиції 7: {result}");
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 7. StreamWriter
        static void DemonstrateStreamWriter()
        {
            Console.WriteLine("\n--- 7. StreamWriter ---");

            string fileName = "streamwriter_example.txt";

            // Базовий запис
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine($"{DateTime.Now}: Початок роботи");
                writer.WriteLine($"{DateTime.Now}: Обробка даних");
                writer.WriteLine($"{DateTime.Now}: Завершення роботи");
                Console.WriteLine($"Записано лог у файл {fileName}");
            }

            // Додавання в кінець файлу
            using (StreamWriter writer = new StreamWriter(fileName, append: true, Encoding.UTF8))
            {
                writer.WriteLine($"{DateTime.Now}: Новий запис");
                Console.WriteLine("Додано новий запис у кінець файлу");
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 8. StreamReader
        static void DemonstrateStreamReader()
        {
            Console.WriteLine("\n--- 8. StreamReader ---");

            string fileName = "streamreader_example.txt";

            // Створюємо тестовий файл
            File.WriteAllText(fileName, "Рядок 1\nРядок 2\nРядок 3\n", Encoding.UTF8);

            // Читання по рядках
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                Console.WriteLine("Читання по рядках:");
                int lineNumber = 1;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"  Рядок {lineNumber}: {line}");
                    lineNumber++;
                }
            }

            // Читання всього файлу
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine($"Всій вміст файлу:\n{content}");
            }

            // Перевірка кінця файлу
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8))
            {
                Console.WriteLine("Читання з перевіркою EndOfStream:");
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    Console.WriteLine($"  {line}");
                }
            }

            // Очищення тестового файлу
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // 9. BinaryWriter
        static void DemonstrateBinaryWriter()
        {
            Console.WriteLine("\n--- 9. BinaryWriter ---");

            string fileName = "binarywriter_example.dat";

            // Запис різних типів даних
            using (BinaryWriter writer = new BinaryWriter(File.Create(fileName)))
            {
                writer.Write("Іван Петренко");
                writer.Write(20);
                writer.Write(85.5);
                writer.Write(true);
                Console.WriteLine($"Записано дані студента у файл {fileName}");
            }

            // Запис масивів
            string arrayFileName = "binarywriter_array.dat";
            int[] grades = { 85, 90, 78, 92, 88 };

            using (BinaryWriter writer = new BinaryWriter(File.Create(arrayFileName)))
            {
                writer.Write(grades.Length);
                foreach (int grade in grades)
                {
                    writer.Write(grade);
                }
                Console.WriteLine($"Записано масив оцінок у файл {arrayFileName}");
            }

            // Очищення тестових файлів
            if (File.Exists(fileName))
                File.Delete(fileName);
            if (File.Exists(arrayFileName))
                File.Delete(arrayFileName);
        }

        // 10. BinaryReader
        static void DemonstrateBinaryReader()
        {
            Console.WriteLine("\n--- 10. BinaryReader ---");

            string fileName = "binaryreader_example.dat";

            // Створюємо тестовий файл
            using (BinaryWriter writer = new BinaryWriter(File.Create(fileName)))
            {
                writer.Write("Іван Петренко");
                writer.Write(20);
                writer.Write(85.5);
                writer.Write(true);
            }

            // Читання різних типів даних
            using (BinaryReader reader = new BinaryReader(File.OpenRead(fileName)))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                double average = reader.ReadDouble();
                bool hasScholarship = reader.ReadBoolean();

                Console.WriteLine("Прочитано дані студента:");
                Console.WriteLine($"  Ім'я: {name}");
                Console.WriteLine($"  Вік: {age}");
                Console.WriteLine($"  Середній бал: {average}");
                Console.WriteLine($"  Стипендія: {hasScholarship}");
            }

            // Читання масивів
            string arrayFileName = "binaryreader_array.dat";
            int[] grades = { 85, 90, 78, 92, 88 };

            using (BinaryWriter writer = new BinaryWriter(File.Create(arrayFileName)))
            {
                writer.Write(grades.Length);
                foreach (int grade in grades)
                {
                    writer.Write(grade);
                }
            }

            using (BinaryReader reader = new BinaryReader(File.OpenRead(arrayFileName)))
            {
                int count = reader.ReadInt32();
                int[] readGrades = new int[count];

                for (int i = 0; i < count; i++)
                {
                    readGrades[i] = reader.ReadInt32();
                }

                Console.WriteLine($"Прочитано оцінки: {string.Join(", ", readGrades)}");
            }

            // Очищення тестових файлів
            if (File.Exists(fileName))
                File.Delete(fileName);
            if (File.Exists(arrayFileName))
                File.Delete(arrayFileName);
        }

        // 11. Directory, DirectoryInfo, FileInfo
        static void DemonstrateFileSystemClasses()
        {
            Console.WriteLine("\n--- 11. Directory, DirectoryInfo, FileInfo ---");

            // Статичні класи File та Directory
            string testDir = "TestDirectory";
            string testFile = Path.Combine(testDir, "test.txt");

            // Створення директорії
            if (!Directory.Exists(testDir))
            {
                Directory.CreateDirectory(testDir);
                Console.WriteLine($"Створено директорію: {testDir}");
            }

            // Створення файлу
            File.WriteAllText(testFile, "Тестовий вміст", Encoding.UTF8);
            Console.WriteLine($"Створено файл: {testFile}");

            // Перевірка існування
            Console.WriteLine($"Файл існує: {File.Exists(testFile)}");
            Console.WriteLine($"Директорія існує: {Directory.Exists(testDir)}");

            // FileInfo
            FileInfo fileInfo = new FileInfo(testFile);
            if (fileInfo.Exists)
            {
                Console.WriteLine("\nІнформація про файл (FileInfo):");
                Console.WriteLine($"  Ім'я: {fileInfo.Name}");
                Console.WriteLine($"  Повний шлях: {fileInfo.FullName}");
                Console.WriteLine($"  Розмір: {fileInfo.Length} байт");
                Console.WriteLine($"  Створено: {fileInfo.CreationTime}");
                Console.WriteLine($"  Змінено: {fileInfo.LastWriteTime}");
                Console.WriteLine($"  Розширення: {fileInfo.Extension}");
            }

            // DirectoryInfo
            DirectoryInfo dirInfo = new DirectoryInfo(testDir);
            Console.WriteLine("\nІнформація про директорію (DirectoryInfo):");
            Console.WriteLine($"  Ім'я: {dirInfo.Name}");
            Console.WriteLine($"  Повний шлях: {dirInfo.FullName}");
            Console.WriteLine($"  Створено: {dirInfo.CreationTime}");

            // Отримання файлів
            FileInfo[] files = dirInfo.GetFiles();
            Console.WriteLine($"\nФайлів у директорії: {files.Length}");
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"  - {file.Name} ({file.Length} байт)");
            }

            // Очищення тестових файлів
            if (File.Exists(testFile))
                File.Delete(testFile);
            if (Directory.Exists(testDir))
                Directory.Delete(testDir);
            Console.WriteLine("\nТестові файли та директорії видалено");
        }

        // 12. Регулярні вирази
        static void DemonstrateRegularExpressions()
        {
            Console.WriteLine("\n--- 12. Регулярні вирази ---");

            // Перевірка формату email
            string email = "user@example.com";
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(email, emailPattern))
            {
                Console.WriteLine($"Email '{email}' валідний");
            }

            // Пошук чисел у тексті
            string text = "Ціна товару: 1234 грн, знижка: 15%";
            string numberPattern = @"\d+";

            MatchCollection numberMatches = Regex.Matches(text, numberPattern);
            Console.WriteLine($"\nЗнайдено чисел у тексті '{text}': {numberMatches.Count}");
            foreach (Match match in numberMatches)
            {
                Console.WriteLine($"  Число: {match.Value}");
            }

            // Заміна телефонного номера
            string phoneText = "Телефон: 050-123-45-67";
            string phonePattern = @"\d{3}-\d{3}-\d{2}-\d{2}";
            string replacement = "XXX-XXX-XX-XX";

            string maskedPhone = Regex.Replace(phoneText, phonePattern, replacement);
            Console.WriteLine($"\nМаскування телефону:");
            Console.WriteLine($"  До: {phoneText}");
            Console.WriteLine($"  Після: {maskedPhone}");

            // Розділення рядка
            string fruitsText = "apple,banana,orange,grape";
            string delimiterPattern = @",";

            string[] fruits = Regex.Split(fruitsText, delimiterPattern);
            Console.WriteLine($"\nРозділення рядка '{fruitsText}':");
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"  - {fruit}");
            }

            // Використання груп
            string dateText = "Дата: 2024-12-15";
            string datePattern = @"(\d{4})-(\d{2})-(\d{2})";

            Match dateMatch = Regex.Match(dateText, datePattern);
            if (dateMatch.Success)
            {
                Console.WriteLine($"\nРозбір дати '{dateText}':");
                Console.WriteLine($"  Рік: {dateMatch.Groups[1].Value}");
                Console.WriteLine($"  Місяць: {dateMatch.Groups[2].Value}");
                Console.WriteLine($"  День: {dateMatch.Groups[3].Value}");
            }

            // Валідація українського телефону
            string ukrainianPhone = "+380501234567";
            string ukrainianPhonePattern = @"^\+380\d{9}$";

            if (Regex.IsMatch(ukrainianPhone, ukrainianPhonePattern))
            {
                Console.WriteLine($"\nУкраїнський телефон '{ukrainianPhone}' валідний");
            }

            // Пошук слів
            string codeText = "C# це мова програмування. C# дуже потужна.";
            string wordPattern = @"\bC#\b";

            MatchCollection wordMatches = Regex.Matches(codeText, wordPattern);
            Console.WriteLine($"\nУ тексті '{codeText}'");
            Console.WriteLine($"  Знайдено збігів 'C#': {wordMatches.Count}");
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
