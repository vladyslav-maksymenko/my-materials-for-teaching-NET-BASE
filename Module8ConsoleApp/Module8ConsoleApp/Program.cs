// Модуль 8. Делегати, події, записи
// Головний файл для демонстрації всіх практичних кейсів

using Module8ConsoleApp;

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║   МОДУЛЬ 8: ДЕЛЕГАТИ, ПОДІЇ, ЗАПИСИ                      ║");
Console.WriteLine("║   Практичні кейси та приклади                             ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();

// Меню для вибору прикладів
while (true)
{
    Console.WriteLine("\n" + "═".PadRight(60, '═'));
    Console.WriteLine("ВИБЕРІТЬ РОЗДІЛ:");
    Console.WriteLine("═".PadRight(60, '═'));
    Console.WriteLine("1. Делегати");
    Console.WriteLine("2. Події");
    Console.WriteLine("3. Анонімні методи");
    Console.WriteLine("4. Лямбда-вирази");
    Console.WriteLine("5. Extension-методи");
    Console.WriteLine("6. Записи (Records)");
    Console.WriteLine("7. Запустити всі приклади");
    Console.WriteLine("0. Вихід");
    Console.WriteLine("═".PadRight(60, '═'));
    Console.Write("Ваш вибір: ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            DelegatesExamplesDemo.RunAllExamples();
            break;
        case "2":
            EventsExamplesDemo.RunAllExamples();
            break;
        case "3":
            AnonymousMethodsExamplesDemo.RunAllExamples();
            break;
        case "4":
            LambdaExpressionsExamplesDemo.RunAllExamples();
            break;
        case "5":
            ExtensionMethodsExamplesDemo.RunAllExamples();
            break;
        case "6":
            RecordsExamplesDemo.RunAllExamples();
            break;
        case "7":
            Console.WriteLine("Запуск всіх прикладів...\n");
            DelegatesExamplesDemo.RunAllExamples();
            Console.WriteLine("\n\n");
            EventsExamplesDemo.RunAllExamples();
            Console.WriteLine("\n\n");
            AnonymousMethodsExamplesDemo.RunAllExamples();
            Console.WriteLine("\n\n");
            LambdaExpressionsExamplesDemo.RunAllExamples();
            Console.WriteLine("\n\n");
            ExtensionMethodsExamplesDemo.RunAllExamples();
            Console.WriteLine("\n\n");
            RecordsExamplesDemo.RunAllExamples();
            break;
        case "0":
            Console.WriteLine("До побачення!");
            return;
        default:
            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            break;
    }

    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
    Console.ReadKey();
    Console.Clear();
}
