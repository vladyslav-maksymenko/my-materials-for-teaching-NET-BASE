// ============================================
// МОДУЛЬ 6: УСПАДКУВАННЯ В C#
// ============================================
// Цей проект містить практичні приклади до теорії з README.md
// 
// Структура проекту:
// - README.md - детальна теорія з усіма концепціями успадкування
// - Examples/BasicInheritance.cs - базове успадкування, конструктори, base
// - Examples/VirtualMethods.cs - віртуальні методи та поліморфізм
// - Examples/AbstractClasses.cs - абстрактні класи
// - Examples/SealedClasses.cs - sealed класи та методи
// - Examples/PolymorphismExamples.cs - посилання на базовий клас
// - Examples/ObjectAndBoxing.cs - клас Object, boxing/unboxing
// - Examples/ExceptionInheritance.cs - успадкування винятків
// 
// Запустіть проект, щоб побачити всі приклади в дії!
// ============================================

using System;
using Module6ConsoleApp.Examples;

namespace Module6ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║     МОДУЛЬ 6: УСПАДКУВАННЯ В C# - ПРАКТИЧНІ ПРИКЛАДИ     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // ============================================
            // 1. БАЗОВЕ УСПАДКУВАННЯ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("1. БАЗОВЕ УСПАДКУВАННЯ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 1.1: Створення об'єктів з успадкуванням ---");
            DogBase dog1 = new DogBase();
            Console.WriteLine();
            
            DogBase dog2 = new DogBase("Рекс", 3, "Лабрадор");
            dog2.Eat();
            dog2.Bark();
            dog2.ShowInfo();
            dog2.MakeSleep();
            Console.WriteLine();

            Console.WriteLine("--- Приклад 1.2: Приховування імен ---");
            DerivedClassInheritance derived = new DerivedClassInheritance();
            derived.Method(); // викликається метод похідного класу
            derived.ShowBaseValue();
            
            BaseClassInheritance baseRef = new DerivedClassInheritance();
            baseRef.Method(); // викликається метод базового класу
            Console.WriteLine();

            Console.WriteLine("--- Приклад 1.3: Використання ключового слова base ---");
            CarBase car = new CarBase("Toyota", 2023, 4);
            car.Start();
            car.ShowFullInfo();
            Console.WriteLine();

            // ============================================
            // 2. ВІРТУАЛЬНІ МЕТОДИ ТА ПОЛІМОРФІЗМ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("2. ВІРТУАЛЬНІ МЕТОДИ ТА ПОЛІМОРФІЗМ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 2.1: Віртуальні методи ---");
            ShapeVirtual circle = new CircleVirtual { Radius = 5, Color = "Червоний" };
            circle.CalculateArea();
            circle.Draw();
            Console.WriteLine();

            ShapeVirtual rectangle = new RectangleVirtual { Width = 10, Height = 5, Color = "Синій" };
            rectangle.CalculateArea();
            rectangle.Draw();
            Console.WriteLine();


            Console.WriteLine("--- Приклад 2.2: Порівняння virtual vs new ---");
            AnimalVirtual animal1 = new DogVirtual();
            animal1.MakeSound(); // викликається перевизначений метод
            animal1.Move();      // викликається метод базового класу (не перевизначений)
            
            DogVirtual dog3 = new DogVirtual();
            dog3.MakeSound(); // викликається перевизначений метод
            dog3.Move();      // викликається прихований метод
            Console.WriteLine();

            Console.WriteLine("--- Приклад 2.3: Виклик базової реалізації ---");
            BaseLogger baseLogger = new BaseLogger();
            baseLogger.Log("Повідомлення");
            Console.WriteLine();

            FileLogger fileLogger = new FileLogger();
            fileLogger.Log("Повідомлення для файлу");
            Console.WriteLine();

            // ============================================
            // 3. АБСТРАКТНІ КЛАСИ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("3. АБСТРАКТНІ КЛАСИ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 3.1: Абстрактні класи тварин ---");
            Animal dog = new Dog("Барсік", 5);
            dog.MakeSound();
            dog.Move();
            dog.Eat();
            dog.Sleep();
            Console.WriteLine();

            Animal cat = new Cat("Мурка", 3);
            cat.MakeSound();
            cat.Move();
            Console.WriteLine();

            Animal bird = new Bird("Чижик", 1);
            bird.MakeSound();
            bird.Move();
            Console.WriteLine();

            Console.WriteLine("--- Приклад 3.2: Абстрактні класи фігур ---");
            ShapeAbstract circle2 = new CircleAbstract(7, "Жовтий");
            Console.WriteLine($"Площа кола: {circle2.CalculateArea():F2}");
            Console.WriteLine($"Периметр кола: {circle2.CalculatePerimeter():F2}");
            circle2.Draw();
            Console.WriteLine();

            ShapeAbstract rect2 = new RectangleAbstract(12, 8, "Фіолетовий");
            Console.WriteLine($"Площа прямокутника: {rect2.CalculateArea():F2}");
            Console.WriteLine($"Периметр прямокутника: {rect2.CalculatePerimeter():F2}");
            rect2.Draw();
            Console.WriteLine();

            Console.WriteLine("--- Приклад 3.3: Абстрактні класи транспортних засобів ---");
            Vehicle car2 = new Car("BMW", 2024, 250, 4);
            car2.DisplayInfo();
            car2.Start();
            car2.Accelerate();
            car2.Stop();
            car2.Maintenance();
            Console.WriteLine();

            Vehicle motorcycle = new Motorcycle("Yamaha", 2023, 180, false);
            motorcycle.DisplayInfo();
            motorcycle.Start();
            motorcycle.Accelerate();
            motorcycle.Stop();
            motorcycle.Maintenance();
            Console.WriteLine();

            // ============================================
            // 4. SEALED КЛАСИ ТА МЕТОДИ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("4. SEALED КЛАСИ ТА МЕТОДИ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 4.1: Sealed клас ---");
            double sum = MathHelper.Add(10, 20);
            double product = MathHelper.Multiply(5, 6);
            double power = MathHelper.Power(2, 8);
            Console.WriteLine($"10 + 20 = {sum}");
            Console.WriteLine($"5 * 6 = {product}");
            Console.WriteLine($"2^8 = {power}");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 4.2: Sealed метод ---");
            BaseClassSealed baseClass = new BaseClassSealed();
            baseClass.Method1();
            baseClass.Method2();
            Console.WriteLine();

            DerivedClassSealed derivedClass = new DerivedClassSealed();
            derivedClass.Method1();
            derivedClass.Method2();
            Console.WriteLine();

            ThirdClassSealed thirdClass = new ThirdClassSealed();
            thirdClass.Method1();
            thirdClass.Method2(); // викликається sealed метод з DerivedClassSealed
            Console.WriteLine();

            Console.WriteLine("--- Приклад 4.3: Sealed для безпеки ---");
            SecurityManager security = SecurityManager.Instance;
            security.Authenticate("admin", "password123");
            Console.WriteLine();

            // ============================================
            // 5. ПОСИЛАННЯ НА БАЗОВИЙ КЛАС (ПОЛІМОРФІЗМ)
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("5. ПОСИЛАННЯ НА БАЗОВИЙ КЛАС (ПОЛІМОРФІЗМ)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 5.1: Масив базового класу ---");
            Animal[] animals = new Animal[]
            {
                new Dog("Рекс", 3),
                new Cat("Мурка", 2),
                new Bird("Чижик", 1),
                new Dog("Шарик", 4)
            };

            PolymorphismDemo.ProcessAnimals(animals);
            Console.WriteLine();

            Console.WriteLine("--- Приклад 5.2: Список базового класу ---");
            List<Animal> animalList = new List<Animal>
            {
                new Dog("Барсік", 5),
                new Cat("Васька", 3),
                new Bird("Кеша", 2)
            };

            PolymorphismDemo.ProcessAnimalList(animalList);
            Console.WriteLine();

            Console.WriteLine("--- Приклад 5.3: Приведення типів ---");
            TypeCastingDemo.DemonstrateCasting();
            Console.WriteLine();

            // ============================================
            // 6. БАЗОВИЙ КЛАС OBJECT
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("6. БАЗОВИЙ КЛАС OBJECT");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 6.1: Перевизначення ToString() ---");
            Person person1 = new Person { Name = "Іван", Age = 25, Email = "ivan@example.com" };
            Person person2 = new Person { Name = "Марія", Age = 30, Email = "maria@example.com" };
            Console.WriteLine(person1.ToString());
            Console.WriteLine(person2.ToString());
            Console.WriteLine();

            Console.WriteLine("--- Приклад 6.2: Перевизначення Equals() ---");
            Person person3 = new Person { Name = "Іван", Age = 25, Email = "ivan@example.com" };
            Console.WriteLine($"person1 == person3: {person1.Equals(person3)}");
            Console.WriteLine($"person1 == person2: {person1.Equals(person2)}");
            Console.WriteLine();

            Student student1 = new Student { Id = 1, Name = "Олександр", Course = "C# Basics" };
            Student student2 = new Student { Id = 1, Name = "Олександр", Course = "C# Basics" };
            Student student3 = new Student { Id = 2, Name = "Олександр", Course = "C# Basics" };
            Console.WriteLine($"student1 == student2: {student1.Equals(student2)}");
            Console.WriteLine($"student1 == student3: {student1.Equals(student3)}");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 6.3: GetType() ---");
            TypeExamples.DemonstrateGetType();
            Console.WriteLine();

            // ============================================
            // 7. ПАКУВАННЯ ТА РОЗПАКУВАННЯ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("7. ПАКУВАННЯ ТА РОЗПАКУВАННЯ (BOXING/UNBOXING)");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            BoxingExamples.DemonstrateBoxing();
            Console.WriteLine();

            UnboxingExamples.DemonstrateUnboxing();
            Console.WriteLine();

            Console.WriteLine("--- Приклад 7.3: Порівняння продуктивності ---");
            PerformanceComparison.BadExample();
            Console.WriteLine();
            PerformanceComparison.GoodExample();
            Console.WriteLine();

            // ============================================
            // 8. УСПАДКУВАННЯ ВИНЯТКІВ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("8. УСПАДКУВАННЯ ВИНЯТКІВ");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.WriteLine("--- Приклад 8.1: Власні винятки ---");
            try
            {
                throw new CustomException("Це власний виняток");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Спіймано CustomException: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Приклад 8.2: Винятки валідації ---");
            try
            {
                throw new ValidationException("Email", "Email має бути валідним");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("--- Приклад 8.3: Бізнес-логіка з винятками ---");
            ExceptionHandlingExample.DemonstrateExceptionHandling();
            Console.WriteLine();

            Console.WriteLine("--- Приклад 8.4: Робота з банківським рахунком ---");
            try
            {
                BankAccount account = new BankAccount("12345", 500);
                account.Deposit(200);
                account.Withdraw(100);
                account.Withdraw(700); // спроба зняти більше, ніж є
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка аргументу: {ex.Message}");
            }
            Console.WriteLine();

            // ============================================
            // ЗАВЕРШЕННЯ
            // ============================================
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("Всі приклади успішно виконано!");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
