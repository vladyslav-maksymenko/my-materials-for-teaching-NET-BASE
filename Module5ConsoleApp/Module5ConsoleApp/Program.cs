using System;
using Module5ConsoleApp;

namespace Module5ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== МОДУЛЬ 5: Перевантаження операторів, Індексатори і Властивості ===\n");

            // ============================================
            // ДЕМОНСТРАЦІЯ 1: Перевантаження унарних операторів
            // ============================================
            Console.WriteLine("1. ПЕРЕВАНТАЖЕННЯ УНАРНИХ ОПЕРАТОРІВ");
            Console.WriteLine("=====================================");
            
            Vector2D v1 = new Vector2D(3, 4);
            Console.WriteLine($"Вектор v1: {v1}");
            Console.WriteLine($"Унарний мінус (-v1): {-v1}");
            Console.WriteLine($"Унарний плюс (+v1): {+v1}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 2: Перевантаження бінарних операторів
            // ============================================
            Console.WriteLine("2. ПЕРЕВАНТАЖЕННЯ БІНАРНИХ ОПЕРАТОРІВ");
            Console.WriteLine("=====================================");
            
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(1, 4);
            
            Console.WriteLine($"Комплексне число c1: {c1}");
            Console.WriteLine($"Комплексне число c2: {c2}");
            Console.WriteLine($"c1 + c2 = {c1 + c2}");
            Console.WriteLine($"c1 - c2 = {c1 - c2}");
            Console.WriteLine($"c1 * c2 = {c1 * c2}");
            Console.WriteLine($"c1 / c2 = {c1 / c2}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 3: Перевантаження операторів відношень
            // ============================================
            Console.WriteLine("3. ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ВІДНОШЕНЬ");
            Console.WriteLine("=====================================");
            
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 4);
            Fraction f3 = new Fraction(3, 4);
            
            Console.WriteLine($"Дріб f1: {f1}");
            Console.WriteLine($"Дріб f2: {f2}");
            Console.WriteLine($"Дріб f3: {f3}");
            Console.WriteLine($"f1 == f2: {f1 == f2}"); // True (1/2 == 2/4)
            Console.WriteLine($"f1 != f2: {f1 != f2}"); // False
            Console.WriteLine($"f1 < f3: {f1 < f3}");   // True (1/2 < 3/4)
            Console.WriteLine($"f1 > f3: {f1 > f3}");   // False
            Console.WriteLine($"f1 <= f2: {f1 <= f2}"); // True
            Console.WriteLine($"f1 >= f3: {f1 >= f3}"); // False
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 4: Перевантаження логічних операторів
            // ============================================
            Console.WriteLine("4. ПЕРЕВАНТАЖЕННЯ ЛОГІЧНИХ ОПЕРАТОРІВ");
            Console.WriteLine("=====================================");
            
            BooleanWrapper b1 = new BooleanWrapper(true);
            BooleanWrapper b2 = new BooleanWrapper(false);
            
            Console.WriteLine($"b1 = {b1}, b2 = {b2}");
            Console.WriteLine($"b1 & b2 = {b1 & b2}");  // False
            Console.WriteLine($"b1 | b2 = {b1 | b2}");  // True
            Console.WriteLine($"b1 ^ b2 = {b1 ^ b2}");  // True
            Console.WriteLine($"!b1 = {!b1}");          // False
            
            // Використання операторів true/false
            if (b1)
                Console.WriteLine("b1 is true");
            if (!b2)
                Console.WriteLine("b2 is false");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 5: Перевантаження операторів перетворення
            // ============================================
            Console.WriteLine("5. ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ПЕРЕТВОРЕННЯ");
            Console.WriteLine("=====================================");
            
            // Неявне перетворення: double -> Temperature
            Temperature t1 = 25.0; // Неявне перетворення
            Console.WriteLine($"Неявне перетворення: Temperature t1 = 25.0; -> {t1}");
            
            // Явне перетворення: Temperature -> double
            double celsius = (double)t1; // Явне перетворення
            Console.WriteLine($"Явне перетворення: double celsius = (double)t1; -> {celsius}");
            
            // Неявне перетворення: Temperature -> string
            string tempStr = t1;
            Console.WriteLine($"Неявне перетворення в string: string tempStr = t1; -> {tempStr}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 6: Перевантаження оператора інкремента
            // ============================================
            Console.WriteLine("6. ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРА ІНКРЕМЕНТА");
            Console.WriteLine("=====================================");
            
            Counter counter = new Counter(5);
            Console.WriteLine($"Початкове значення: {counter}");
            Console.WriteLine($"Префіксний ++counter: {++counter}");
            Console.WriteLine($"Після інкремента: {counter}");
            Console.WriteLine($"Постфіксний counter++: {counter++}");
            Console.WriteLine($"Після інкремента: {counter}");
            Console.WriteLine($"Декремент --counter: {--counter}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 7: Простий одновимірний індексатор
            // ============================================
            Console.WriteLine("7. ПРОСТИЙ ОДНОВИМІРНИЙ ІНДЕКСАТОР");
            Console.WriteLine("=====================================");
            
            SimpleArray arr = new SimpleArray(5);
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            
            Console.WriteLine($"arr[0] = {arr[0]}");
            Console.WriteLine($"arr[1] = {arr[1]}");
            Console.WriteLine($"arr[2] = {arr[2]}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 8: Індексатор з рядковим ключем
            // ============================================
            Console.WriteLine("8. ІНДЕКСАТОР З РЯДКОВИМ КЛЮЧЕМ");
            Console.WriteLine("=====================================");
            
            DictionaryWrapper dict = new DictionaryWrapper();
            dict["name"] = "Іван";
            dict["age"] = "25";
            dict["city"] = "Київ";
            
            Console.WriteLine($"dict[\"name\"] = {dict["name"]}");
            Console.WriteLine($"dict[\"age\"] = {dict["age"]}");
            Console.WriteLine($"dict[\"city\"] = {dict["city"]}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 9: Багатовимірний індексатор
            // ============================================
            Console.WriteLine("9. БАГАТОВИМІРНИЙ ІНДЕКСАТОР");
            Console.WriteLine("=====================================");
            
            Matrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            
            Console.WriteLine("Матриця 3x3:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 10: Перевантаження індексаторів
            // ============================================
            Console.WriteLine("10. ПЕРЕВАНТАЖЕННЯ ІНДЕКСАТОРІВ");
            Console.WriteLine("=====================================");
            
            SmartCollection collection = new SmartCollection();
            collection.Add("Перший");
            collection.Add("Другий");
            collection.Add("третій", "Третій");
            
            Console.WriteLine($"collection[0] = {collection[0]}");
            Console.WriteLine($"collection[1] = {collection[1]}");
            Console.WriteLine($"collection[\"третій\"] = {collection["третій"]}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 11: Індексатор тільки для читання
            // ============================================
            Console.WriteLine("11. ІНДЕКСАТОР ТІЛЬКИ ДЛЯ ЧИТАННЯ");
            Console.WriteLine("=====================================");
            
            ReadOnlyCollection readOnly = new ReadOnlyCollection("А", "Б", "В", "Г");
            Console.WriteLine($"readOnly[0] = {readOnly[0]}");
            Console.WriteLine($"readOnly[2] = {readOnly[2]}");
            // readOnly[0] = "X"; // Помилка - немає set аксесора
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 12: Складний індексатор
            // ============================================
            Console.WriteLine("12. СКЛАДНИЙ ІНДЕКСАТОР (СТУДЕНТИ ТА ОЦІНКИ)");
            Console.WriteLine("=====================================");
            
            StudentGrades grades = new StudentGrades();
            grades["Іван", "Математика"] = 95;
            grades["Іван", "Фізика"] = 88;
            grades["Марія", "Математика"] = 92;
            
            Console.WriteLine($"Оцінка Івана з Математики: {grades["Іван", "Математика"]}");
            Console.WriteLine($"Оцінка Івана з Фізики: {grades["Іван", "Фізика"]}");
            Console.WriteLine($"Оцінка Марії з Математики: {grades["Марія", "Математика"]}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 13: Повний синтаксис властивості
            // ============================================
            Console.WriteLine("13. ПОВНИЙ СИНТАКСИС ВЛАСТИВОСТІ");
            Console.WriteLine("=====================================");
            
            PersonFullSyntax person1 = new PersonFullSyntax();
            person1.Name = "Олександр";
            person1.Age = 30;
            
            Console.WriteLine($"Ім'я: {person1.Name}, Вік: {person1.Age}");
            // person1.Age = 200; // Помилка - валідація не дозволить
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 14: Автоматичні властивості
            // ============================================
            Console.WriteLine("14. АВТОМАТИЧНІ ВЛАСТИВОСТІ");
            Console.WriteLine("=====================================");
            
            PersonAutoProperty person2 = new PersonAutoProperty
            {
                Name = "Марія",
                Age = 25,
                Email = "maria@example.com"
            };
            
            Console.WriteLine($"Ім'я: {person2.Name}, Вік: {person2.Age}, Email: {person2.Email}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 15: Властивості з init
            // ============================================
            Console.WriteLine("15. ВЛАСТИВОСТІ З INIT");
            Console.WriteLine("=====================================");
            
            PersonInit person3 = new PersonInit
            {
                Name = "Петро",
                Age = 28,
                Email = "petro@example.com",
                Phone = "+380501234567"
            };
            
            Console.WriteLine($"Ім'я: {person3.Name}, Вік: {person3.Age}");
            Console.WriteLine($"Email: {person3.Email}, Телефон: {person3.Phone}");
            // person3.Name = "Нове ім'я"; // Помилка - init дозволяє тільки при створенні
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 16: Обчислювані властивості
            // ============================================
            Console.WriteLine("16. ОБЧИСЛЮВАНІ ВЛАСТИВОСТІ");
            Console.WriteLine("=====================================");
            
            Rectangle rect = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine($"Прямокутник: ширина = {rect.Width}, висота = {rect.Height}");
            Console.WriteLine($"Площа: {rect.Area}");
            Console.WriteLine($"Периметр: {rect.Perimeter}");
            Console.WriteLine($"Чи є квадратом: {rect.IsSquare}");
            
            rect.Width = 5;
            rect.Height = 5;
            Console.WriteLine($"\nПісля зміни: ширина = {rect.Width}, висота = {rect.Height}");
            Console.WriteLine($"Чи є квадратом: {rect.IsSquare}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 17: Ініціалізація автоматичних властивостей
            // ============================================
            Console.WriteLine("17. ІНІЦІАЛІЗАЦІЯ АВТОМАТИЧНИХ ВЛАСТИВОСТЕЙ");
            Console.WriteLine("=====================================");
            
            PersonInitialized person4 = new PersonInitialized();
            Console.WriteLine($"За замовчуванням - Ім'я: {person4.Name}, Вік: {person4.Age}");
            Console.WriteLine($"Активний: {person4.IsActive}, Створено: {person4.CreatedAt}");
            
            PersonInitialized person5 = new PersonInitialized
            {
                Name = "Анна",
                Age = 22
            };
            Console.WriteLine($"Після ініціалізації - Ім'я: {person5.Name}, Вік: {person5.Age}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 18: Властивості з логікою
            // ============================================
            Console.WriteLine("18. ВЛАСТИВОСТІ З ЛОГІКОЮ В GET/SET");
            Console.WriteLine("=====================================");
            
            BankAccount account = new BankAccount("ACC001", 1000);
            Console.WriteLine($"Баланс: {account.Balance}");
            account.Balance = 1500;
            Console.WriteLine($"Новий баланс: {account.Balance}");
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 19: Властивості тільки для читання
            // ============================================
            Console.WriteLine("19. ВЛАСТИВОСТІ ТІЛЬКИ ДЛЯ ЧИТАННЯ");
            Console.WriteLine("=====================================");
            
            PersonReadOnly person6 = new PersonReadOnly("ID001", "Сергій", new DateTime(1990, 5, 15));
            Console.WriteLine($"ID: {person6.Id}");
            Console.WriteLine($"Ім'я: {person6.Name}");
            Console.WriteLine($"Вік (обчислюваний): {person6.Age}");
            // person6.Id = "NEW_ID"; // Помилка - тільки для читання
            Console.WriteLine();

            // ============================================
            // ДЕМОНСТРАЦІЯ 20: Властивості з init та валідацією
            // ============================================
            Console.WriteLine("20. ВЛАСТИВОСТІ З INIT ТА ВАЛІДАЦІЄЮ");
            Console.WriteLine("=====================================");
            
            Student student = new Student
            {
                StudentId = "STU12345",
                Name = "Олена",
                Year = 2
            };
            
            Console.WriteLine($"Студент: {student.Name}, ID: {student.StudentId}, Рік: {student.Year}");
            Console.WriteLine($"Активний: {student.IsActive}");
            Console.WriteLine();

            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА ===");
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
