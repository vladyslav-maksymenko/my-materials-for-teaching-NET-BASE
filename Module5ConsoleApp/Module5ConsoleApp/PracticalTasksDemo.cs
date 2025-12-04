using System;

namespace Module5ConsoleApp
{
    // ============================================
    // ДЕМОНСТРАЦІЯ ВИКОРИСТАННЯ ПРАКТИЧНИХ ЗАВДАНЬ
    // ============================================
    // Цей файл показує приклади використання всіх завдань
    // Використовуйте для швидкої допомоги студентам
    // ============================================

    public class PracticalTasksDemo
    {
        public static void RunAllDemos()
        {
            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ПРАКТИЧНИХ ЗАВДАНЬ ===\n");

            DemoTask1();
            DemoTask2();
            DemoTask3();
            DemoTask4();
            DemoTask5();
            DemoTask6();
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 1: Співробітник
        // ============================================
        static void DemoTask1()
        {
            Console.WriteLine("ЗАВДАННЯ 1: Клас Співробітник (Employee)");
            Console.WriteLine("===========================================");

            Employee emp1 = new Employee("Іван", "Петренко", "Розробник", 50000);
            Employee emp2 = new Employee("Марія", "Коваленко", "Тестувальник", 45000);

            Console.WriteLine($"Співробітник 1: {emp1}");
            Console.WriteLine($"Співробітник 2: {emp2}");
            Console.WriteLine();

            // Перевантаження оператора +
            Employee emp1Raised = emp1 + 5000;
            Console.WriteLine($"Після підвищення зарплати на 5000: {emp1Raised}");
            Console.WriteLine();

            // Перевантаження оператора -
            Employee emp2Reduced = emp2 - 2000;
            Console.WriteLine($"Після зниження зарплати на 2000: {emp2Reduced}");
            Console.WriteLine();

            // Перевантаження операторів порівняння
            Console.WriteLine($"emp1 == emp2: {emp1 == emp2}");
            Console.WriteLine($"emp1 != emp2: {emp1 != emp2}");
            Console.WriteLine($"emp1 > emp2: {emp1 > emp2}");
            Console.WriteLine($"emp1 < emp2: {emp1 < emp2}");
            Console.WriteLine();

            // Метод Equals
            Employee emp3 = new Employee("Іван", "Петренко", "Розробник", 50000);
            Console.WriteLine($"emp1.Equals(emp3): {emp1.Equals(emp3)}");
            Console.WriteLine($"emp1 == emp3: {emp1 == emp3}");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 2: Матриця
        // ============================================
        static void DemoTask2()
        {
            Console.WriteLine("ЗАВДАННЯ 2: Клас Матриця (MatrixTask)");
            Console.WriteLine("===========================================");

            // Створюємо дві матриці 2x2
            MatrixTask m1 = new MatrixTask(2, 2);
            m1[0, 0] = 1; m1[0, 1] = 2;
            m1[1, 0] = 3; m1[1, 1] = 4;

            MatrixTask m2 = new MatrixTask(2, 2);
            m2[0, 0] = 5; m2[0, 1] = 6;
            m2[1, 0] = 7; m2[1, 1] = 8;

            Console.WriteLine("Матриця 1:");
            Console.WriteLine(m1);
            Console.WriteLine("Матриця 2:");
            Console.WriteLine(m2);

            // Додавання матриць
            MatrixTask sum = m1 + m2;
            Console.WriteLine("Матриця 1 + Матриця 2:");
            Console.WriteLine(sum);

            // Віднімання матриць
            MatrixTask diff = m2 - m1;
            Console.WriteLine("Матриця 2 - Матриця 1:");
            Console.WriteLine(diff);

            // Множення матриць
            MatrixTask product = m1 * m2;
            Console.WriteLine("Матриця 1 * Матриця 2:");
            Console.WriteLine(product);

            // Множення матриці на число
            MatrixTask scaled = m1 * 3;
            Console.WriteLine("Матриця 1 * 3:");
            Console.WriteLine(scaled);

            // Порівняння матриць
            MatrixTask m3 = new MatrixTask(2, 2);
            m3[0, 0] = 1; m3[0, 1] = 2;
            m3[1, 0] = 3; m3[1, 1] = 4;

            Console.WriteLine($"m1 == m3: {m1 == m3}");
            Console.WriteLine($"m1 != m2: {m1 != m2}");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 3: Місто
        // ============================================
        static void DemoTask3()
        {
            Console.WriteLine("ЗАВДАННЯ 3: Клас Місто (City)");
            Console.WriteLine("===========================================");

            City kyiv = new City("Київ", "Україна", 2967000);
            City lviv = new City("Львів", "Україна", 721000);

            Console.WriteLine($"Місто 1: {kyiv}");
            Console.WriteLine($"Місто 2: {lviv}");
            Console.WriteLine();

            // Збільшення населення
            City kyivGrown = kyiv + 50000;
            Console.WriteLine($"Київ після збільшення на 50000: {kyivGrown}");
            Console.WriteLine();

            // Зменшення населення
            City lvivReduced = lviv - 10000;
            Console.WriteLine($"Львів після зменшення на 10000: {lvivReduced}");
            Console.WriteLine();

            // Порівняння міст
            Console.WriteLine($"kyiv == lviv: {kyiv == lviv}");
            Console.WriteLine($"kyiv != lviv: {kyiv != lviv}");
            Console.WriteLine($"kyiv > lviv: {kyiv > lviv}");
            Console.WriteLine($"kyiv < lviv: {kyiv < lviv}");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 4: Кредитна картка
        // ============================================
        static void DemoTask4()
        {
            Console.WriteLine("ЗАВДАННЯ 4: Клас Кредитна картка (CreditCard)");
            Console.WriteLine("===========================================");

            CreditCard card1 = new CreditCard("1234-5678-9012-3456", 
                new DateTime(2025, 12, 31), "123", 10000);
            CreditCard card2 = new CreditCard("9876-5432-1098-7654", 
                new DateTime(2026, 6, 30), "456", 5000);

            Console.WriteLine($"Картка 1: {card1}");
            Console.WriteLine($"Картка 2: {card2}");
            Console.WriteLine();

            // Поповнення балансу
            CreditCard card1Recharged = card1 + 2000;
            Console.WriteLine($"Картка 1 після поповнення на 2000: {card1Recharged}");
            Console.WriteLine();

            // Зняття коштів
            CreditCard card2Withdrawn = card2 - 1000;
            Console.WriteLine($"Картка 2 після зняття 1000: {card2Withdrawn}");
            Console.WriteLine();

            // Порівняння за CVC
            CreditCard card3 = new CreditCard("1111-2222-3333-4444", 
                new DateTime(2025, 12, 31), "123", 5000);
            Console.WriteLine($"card1 == card3 (за CVC): {card1 == card3}");
            Console.WriteLine($"card1 != card2 (за CVC): {card1 != card2}");
            Console.WriteLine();

            // Порівняння за балансом
            Console.WriteLine($"card1 > card2 (за балансом): {card1 > card2}");
            Console.WriteLine($"card1 < card2 (за балансом): {card1 < card2}");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 5: Currency
        // ============================================
        static void DemoTask5()
        {
            Console.WriteLine("ЗАВДАННЯ 5: Клас Currency (Конвертація валют)");
            Console.WriteLine("===========================================");

            // Створення валют
            Currency usd = new Currency("USD", 100);
            Currency eur = new Currency("EUR", 100);
            Currency gbp = new Currency("GBP", 100);

            Console.WriteLine($"USD: {usd}");
            Console.WriteLine($"EUR: {eur}");
            Console.WriteLine($"GBP: {gbp}");
            Console.WriteLine();

            // Неявне перетворення: double -> Currency
            Currency usdFromDouble = 50.0;
            Console.WriteLine($"Неявне перетворення: Currency usdFromDouble = 50.0; -> {usdFromDouble}");
            Console.WriteLine();

            // Явне перетворення: Currency -> double
            double usdAmount = (double)usd;
            Console.WriteLine($"Явне перетворення: double usdAmount = (double)usd; -> {usdAmount}");
            Console.WriteLine();

            // Неявне перетворення: Currency -> decimal
            decimal usdDecimal = usd;
            Console.WriteLine($"Неявне перетворення: decimal usdDecimal = usd; -> {usdDecimal}");
            Console.WriteLine();

            // Явне перетворення: Currency -> string
            string usdString = (string)usd;
            Console.WriteLine($"Явне перетворення: string usdString = (string)usd; -> {usdString}");
            Console.WriteLine();

            // Додавання валют
            Currency total = usd + eur;
            Console.WriteLine($"USD + EUR = {total}");
            Console.WriteLine();

            // Віднімання валют
            Currency difference = usd - gbp;
            Console.WriteLine($"USD - GBP = {difference}");
            Console.WriteLine();

            // Конвертація в USD
            Console.WriteLine($"100 EUR в USD: {eur.ToUSD():F2} USD");
            Console.WriteLine($"100 GBP в USD: {gbp.ToUSD():F2} USD");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }

        // ============================================
        // ДЕМОНСТРАЦІЯ ЗАВДАННЯ 6: Player
        // ============================================
        static void DemoTask6()
        {
            Console.WriteLine("ЗАВДАННЯ 6: Клас Player (Гравець)");
            Console.WriteLine("===========================================");

            Player player = new Player("Гравець1", 0);
            Console.WriteLine($"Початковий стан: {player}");
            Console.WriteLine();

            // Додаємо очки поступово
            Console.WriteLine("Додаємо очки:");
            player.AddScore(50);
            Console.WriteLine($"Після +50: {player}");
            Console.WriteLine();

            player.AddScore(30);
            Console.WriteLine($"Після +30: {player}");
            Console.WriteLine();

            player.AddScore(30); // Загалом 110, має підвищити рівень до 2
            Console.WriteLine($"Після +30: {player}");
            Console.WriteLine();

            player.AddScore(100); // Загалом 210, має підвищити рівень до 3
            Console.WriteLine($"Після +100: {player}");
            Console.WriteLine();

            // Встановлення очок напряму через властивість
            Console.WriteLine("Встановлюємо очки напряму:");
            player.Score = 250; // Має підвищити рівень до 3 (250 / 100 + 1 = 3)
            Console.WriteLine($"Після встановлення 250: {player}");
            Console.WriteLine();

            player.Score = 350; // Має підвищити рівень до 4
            Console.WriteLine($"Після встановлення 350: {player}");
            Console.WriteLine();

            Console.WriteLine("---\n");
        }
    }
}


