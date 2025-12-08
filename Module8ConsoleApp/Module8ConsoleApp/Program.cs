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

Console.WriteLine("\n\n" + new string('═', 60));
Console.WriteLine("Демонстрація завершена!");
Console.WriteLine(new string('═', 60));
Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
Console.ReadKey();
