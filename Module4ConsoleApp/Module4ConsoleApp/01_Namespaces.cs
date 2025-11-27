/*
 * МОДУЛЬ 4: ПРОСТОРИ ІМЕН (NAMESPACES)
 * 
 * ЩО ТАКЕ ПРОСТІР ІМЕН?
 * Простір імен (namespace) - це спосіб організації коду в логічні групи.
 * Уявіть собі бібліотеку: книги розташовані по полицях, кожна полиця має свою назву.
 * Простори імен - це "полиці" для вашого коду.
 * 
 * ЦІЛІ ТА ЗАВДАННЯ:
 * 1. Уникати конфліктів імен (коли два класи мають однакову назву)
 * 2. Організувати код логічно
 * 3. Полегшити пошук та використання коду
 * 4. Створити ієрархію коду
 */

// ============================================
// ПРИКЛАД 1: ОГОЛОШЕННЯ ПРОСТОРУ ІМЕН
// ============================================

namespace School.Students
{
    // Клас Student знаходиться в просторі імен School.Students
    public class Student
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}

namespace School.Teachers
{
    // Клас Teacher знаходиться в просторі імен School.Teachers
    public class Teacher
    {
        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";
    }
}

// ============================================
// ПРИКЛАД 2: ВКЛАДЕНІ ПРОСТОРИ ІМЕН
// ============================================

//namespace ITAcademy
//{
//    namespace ProgrammingDepartment
//    {
//        namespace CSharp
//        {
//            namespace Basics
//            {
//                classMyClass
//                {
//                    //...
//                }
//        }
//    }
//}
//}

namespace Company
{
    namespace HR
    {
        // Повний шлях: Company.HR.Employee
        public class Employee
        {
            public string Name { get; set; } = "";
        }

    }

    namespace Finance
    {
        // Повний шлях: Company.Finance.Accountant
        public class Accountant
        {
            public string Name { get; set; } = "";
        }
    }
}

// Альтернативний спосіб запису вкладених просторів імен:
namespace Company.IT
{
    // Повний шлях: Company.IT.Developer
    public class Developer
    {
        public string Name { get; set; } = "";
    }
}

// ============================================
// ПРИКЛАД 3: РОЗБИТТЯ ПРОСТОРУ ІМЕН НА ЧАСТИНИ
// ============================================

// Можна розбити один простір імен на кілька файлів // Class1.cs
namespace Geometry
{
    // Частина 1: Трикутник
    public class Triangle
    {
        public double CalculateArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }
    }
}

// Це продовження простору імен Geometry (в іншому файлі або тут) // Class2.cs
namespace Geometry
{
    // Частина 2: Коло
    public class Circle
    {
        public double CalculateArea(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}

// ============================================
// ПРИКЛАД 4: ПРОСТІР ІМЕН ЗА ЗАМОВЧУВАННЯМ (GLOBAL)
// ============================================

// Класи без явного простору імен знаходяться в глобальному просторі імен
public class GlobalClass
{
    public string Message { get; set; } = "Я в глобальному просторі імен";
}

// ============================================
// ПРИКЛАД 5: ВИКОРИСТАННЯ КЛЮЧОВОГО СЛОВА USING
// ============================================

// БЕЗ using - потрібно вказувати повний шлях
namespace Examples
{
    public class Example1
    {
        public void Method1()
        {
            // Повне ім'я з простором імен
            School.Students.Student student = new School.Students.Student();
            student.Name = "Іван";
        }
    }
}

// ПРИМІТКА: У реальному коді using завжди пишуться на початку файлу!
// Тут показано концепцію - у вашому коді використовуйте using на початку файлу

namespace Examples
{
    public class Example2
    {
        public void Method2()
        {
            // З using на початку файлу можна використовувати короткі імена:
            // using School.Students;
            // using School.Teachers;
            // 
            // Тоді можна писати:
            // Student student = new Student();
            // Teacher teacher = new Teacher();
            
            // Без using потрібно вказувати повний шлях:
            School.Students.Student student = new School.Students.Student();
            student.Name = "Марія";

            School.Teachers.Teacher teacher = new School.Teachers.Teacher();
            teacher.Name = "Олена";
        }
    }
}

// ============================================
// ПРИКЛАД 6: ДРУГА ФОРМА USING (ALIAS)
// ============================================

namespace Examples
{
    public class Example3
    {
        public void Method3()
        {
            // Якщо є конфлікт імен, можна створити псевдонім (alias)
            // На початку файлу: using Students = School.Students;
            // Тоді можна використовувати: Students.Student student = new Students.Student();
            
            // Без alias потрібно вказувати повний шлях:
            School.Students.Student student = new School.Students.Student();
        }
    }
}

// ============================================
// ПРИКЛАД 7: USING ДЛЯ СТАТИЧНИХ ЧЛЕНІВ
// ============================================

namespace Examples
{
    public class Example4
    {
        public void Method4()
        {
            // На початку файлу: using static System.Math;
            // Тоді замість Math.PI можна просто PI
            double radius = 5;
            double area = Math.PI * radius * radius; // Без using static

            // На початку файлу: using static System.Console;
            // Тоді замість Console.WriteLine можна просто WriteLine
            System.Console.WriteLine($"Площа кола: {area}"); // Без using static
        }
    }
}

// ============================================
// ПРИКЛАД 8: ВИРІШЕННЯ КОНФЛІКТІВ ІМЕН
// ============================================

namespace Library1
{
    public class Book
    {
        public string Title { get; set; } = "";
    }
}

namespace Library2
{
    public class Book
    {
        public string Title { get; set; } = "";
    }
}

namespace Examples
{
    public class Example5
    {
        public void Method5()
        {
            // На початку файлу можна створити alias:
            // using Book1 = Library1.Book;
            // using Book2 = Library2.Book;
            // 
            // Тоді можна використовувати:
            // Book1 book1 = new Book1 { Title = "Книга 1" };
            // Book2 book2 = new Book2 { Title = "Книга 2" };
            
            // Без alias потрібно вказувати повний шлях:
            Library1.Book book1 = new Library1.Book { Title = "Книга 1" };
            Library2.Book book2 = new Library2.Book { Title = "Книга 2" };
        }
    }
}

/*
 * КЛЮЧОВІ МОМЕНТИ:
 * 
 * 1. Простори імен організовують код логічно
 * 2. Використовуйте using для спрощення доступу до класів
 * 3. Вкладені простори імен створюють ієрархію
 * 4. Один простір імен може бути розбитий на кілька файлів
 * 5. Alias (псевдоніми) допомагають вирішувати конфлікти імен
 * 6. using static дозволяє використовувати статичні методи без імені класу
 */

