// Модуль 8. Делегати, події, записи
// Демонстрація всіх прикладів

using Module8ConsoleApp;

Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
Console.WriteLine("║  Модуль 8: Делегати, Події, Записи                        ║");
Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");

// ========== ДЕЛЕГАТИ ==========
Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("ЧАСТИНА 1: ДЕЛЕГАТИ");
Console.WriteLine(new string('═', 60));

DelegatesExamples.BasicDelegateExample();
DelegatesExamples.DelegateWithReturnValue();
DelegatesExamples.MulticastDelegateExample();
DelegatesExamples.BaseClassesExample();
DelegatesExamples.AnonymousMethodsExample();
DelegatesExamples.DelegateAsParameter();

// ========== ПОДІЇ ==========
Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("ЧАСТИНА 2: ПОДІЇ");
Console.WriteLine(new string('═', 60));

EventsExamples.BasicEventExample();
EventsExamples.CustomEventArgsExample();
EventsExamples.MulticastEventExample();
EventsExamples.EventAccessorsExample();
EventsExamples.NotificationSystemExample();

// ========== ЗАПИСИ ==========
Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("ЧАСТИНА 3: ЗАПИСИ (RECORDS)");
Console.WriteLine(new string('═', 60));

RecordsExamples.BasicRecordExample();
RecordsExamples.RecordWithMembersExample();
RecordsExamples.RecordWithModifierExample();
RecordsExamples.PositionalRecordExample();
RecordsExamples.RecordStructExample();
RecordsExamples.RecordInheritanceExample();

// ========== ПРАКТИЧНІ ЗАВДАННЯ ==========
Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("ЧАСТИНА ПЕРША: ПРАКТИЧНІ ЗАВДАННЯ");
Console.WriteLine(new string('═', 60));

// Завдання 1: Відображення текстового повідомлення через делегат
PracticalTasks.Task1_MessageDisplay();

// Завдання 2: Арифметичні операції через делегати
PracticalTasks.Task2_ArithmeticOperations();

// Завдання 3: Перевірка чисел через Predicate
PracticalTasks.Task3_NumberPredicates();

// Завдання 4: Арифметичні операції з використанням Invoke
PracticalTasks.Task4_ArithmeticWithInvoke();

// Завдання 5: Фільтрація елементів List через делегати
PracticalTasks.Task5_FilterList();

// Завдання 6: Система логування на подіях для колекції
PracticalTasks.Task6_EventBasedLogging();

// ========== ПРАКТИЧНІ ЗАВДАННЯ ЧАСТИНА 2 ==========
Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("ЧАСТИНА ДРУГА: ПРАКТИЧНІ ЗАВДАННЯ (АНОНІМНІ МЕТОДИ ТА ЛЯМБДА-ВИРАЗИ)");
Console.WriteLine(new string('═', 60));

// Завдання 1: Анонімний метод для перевірки числа на парність і непарність
PracticalTasks.Task7_AnonymousCheckEvenOdd();

// Завдання 2: Анонімний метод для піднесення числа до степеня
PracticalTasks.Task8_AnonymousPower();

// Завдання 3: Лямбда-вираз для піднесення числа до будь-якого ступеня
PracticalTasks.Task9_LambdaPower();

// Завдання 4: Лямбда-вираз для перевірки, чи є день вихідним
PracticalTasks.Task10_LambdaIsWeekend();

// Завдання 5: Лямбда-вираз для пошуку максимального значення в масиві та його індексу
PracticalTasks.Task11_LambdaFindMax();

// Завдання 6: Лямбда-вираз для пошуку мінімального значення в масиві та його індексу
PracticalTasks.Task12_LambdaFindMin();

// Завдання 7: Лямбда-вираз для фільтрації непарних чисел у масиві
PracticalTasks.Task13_LambdaFilterOdd();

Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("Демонстрація завершена!");
Console.WriteLine(new string('═', 60));
Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
Console.ReadKey();
