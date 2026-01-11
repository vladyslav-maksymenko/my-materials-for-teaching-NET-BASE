using Module13ConsoleApp.Serialization;
using Module13ConsoleApp.Logging;

namespace Module13ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Module 13: Serialization and Logging");
        Console.WriteLine("========================================\n");

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("\nSelect an example to run:");
            Console.WriteLine("1. Binary Serialization (Note: Requires .NET Framework)");
            Console.WriteLine("2. SOAP Serialization (Note: Requires .NET Framework)");
            Console.WriteLine("3. Custom Serialization (ISerializable)");
            Console.WriteLine("4. JSON Serialization (Modern approach)");
            Console.WriteLine("5. log4net Logging");
            Console.WriteLine("6. Serilog Logging");
            Console.WriteLine("7. NLog Logging");
            Console.WriteLine("8. Run All Serialization Examples");
            Console.WriteLine("9. Run All Logging Examples");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        BinarySerializationExample.DemonstrateBinarySerialization();
                        BinarySerializationExample.DemonstrateObjectGraphSerialization();
                        break;

                    case "2":
                        SoapSerializationExample.DemonstrateSoapSerialization();
                        break;

                    case "3":
                        CustomSerializationExample.DemonstrateCustomSerialization();
                        break;

                    case "4":
                        JsonSerializationExample.DemonstrateJsonSerialization();
                        Console.WriteLine();
                        JsonSerializationExample.DemonstrateObjectGraphJsonSerialization();
                        break;

                    case "5":
                        Log4NetExample.DemonstrateLog4Net();
                        Log4NetExample.DemonstrateLog4NetWithContext();
                        break;

                    case "6":
                        SerilogExample.DemonstrateSerilog();
                        SerilogExample.DemonstrateSerilogStructuredLogging();
                        SerilogExample.Cleanup();
                        break;

                    case "7":
                        NLogExample.DemonstrateNLog();
                        NLogExample.DemonstrateNLogWithContext();
                        break;

                    case "8":
                        Console.WriteLine("=== Running All Serialization Examples ===\n");
                        JsonSerializationExample.DemonstrateJsonSerialization();
                        Console.WriteLine();
                        JsonSerializationExample.DemonstrateObjectGraphJsonSerialization();
                        Console.WriteLine();
                        CustomSerializationExample.DemonstrateCustomSerialization();
                        Console.WriteLine();
                        BinarySerializationExample.DemonstrateBinarySerialization();
                        Console.WriteLine();
                        BinarySerializationExample.DemonstrateObjectGraphSerialization();
                        Console.WriteLine();
                        SoapSerializationExample.DemonstrateSoapSerialization();
                        break;

                    case "9":
                        Console.WriteLine("=== Running All Logging Examples ===\n");
                        Log4NetExample.DemonstrateLog4Net();
                        Log4NetExample.DemonstrateLog4NetWithContext();
                        Console.WriteLine();
                        SerilogExample.DemonstrateSerilog();
                        SerilogExample.DemonstrateSerilogStructuredLogging();
                        SerilogExample.Cleanup();
                        Console.WriteLine();
                        NLogExample.DemonstrateNLog();
                        NLogExample.DemonstrateNLogWithContext();
                        break;

                    case "0":
                        continueRunning = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            if (continueRunning && choice != "0")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}



//using Module13ConsoleApp.Serialization;
//using Module13ConsoleApp.Logging;
//using Module13ConsoleApp.Tasks;

//namespace Module13ConsoleApp;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("========================================");
//        Console.WriteLine("Module 13: Serialization and Logging");
//        Console.WriteLine("========================================\n");

//        bool continueRunning = true;

//        while (continueRunning)
//        {
//            Console.WriteLine("\n=== ПРАКТИЧНІ ЗАВДАННЯ ===");
//            Console.WriteLine("Частина перша (Серіалізація):");
//            Console.WriteLine("  1. Завдання 1: Масив цілих чисел");
//            Console.WriteLine("  2. Завдання 2: Музичний альбом");
//            Console.WriteLine("  3. Завдання 3: Альбом зі списком пісень");
//            Console.WriteLine("  4. Завдання 4: Масив альбомів");
//            Console.WriteLine("\nЧастина друга (Логування):");
//            Console.WriteLine("  5. Завдання 5: Калькулятор з NLog");
//            Console.WriteLine("  6. Завдання 6: Калькулятор з Serilog");
//            Console.WriteLine("  7. Завдання 7: Парсинг текстового файлу");
//            Console.WriteLine("\n=== ПРИКЛАДИ ===");
//            Console.WriteLine("  8. Binary Serialization (Note: Requires .NET Framework)");
//            Console.WriteLine("  9. SOAP Serialization (Note: Requires .NET Framework)");
//            Console.WriteLine(" 10. Custom Serialization (ISerializable)");
//            Console.WriteLine(" 11. JSON Serialization (Modern approach)");
//            Console.WriteLine(" 12. log4net Logging");
//            Console.WriteLine(" 13. Serilog Logging");
//            Console.WriteLine(" 14. NLog Logging");
//            Console.WriteLine(" 15. Run All Serialization Examples");
//            Console.WriteLine(" 16. Run All Logging Examples");
//            Console.WriteLine("\n  0. Exit");
//            Console.Write("\nEnter your choice: ");

//            string? choice = Console.ReadLine();
//            Console.WriteLine();

//            try
//            {
//                switch (choice)
//                {
//                    // Практичні завдання - Частина перша
//                    case "1":
//                        Task1_IntegerArray.Run();
//                        break;

//                    case "2":
//                        Task2_MusicAlbum.Run();
//                        break;

//                    case "3":
//                        Task3_AlbumWithSongs.Run();
//                        break;

//                    case "4":
//                        Task4_AlbumArray.Run();
//                        break;

//                    // Практичні завдання - Частина друга
//                    case "5":
//                        Task5_CalculatorNLog.Run();
//                        break;

//                    case "6":
//                        Task6_CalculatorSerilog.Run();
//                        break;

//                    case "7":
//                        Task7_FileParser.Run();
//                        break;

//                    // Приклади
//                    case "8":
//                        BinarySerializationExample.DemonstrateBinarySerialization();
//                        BinarySerializationExample.DemonstrateObjectGraphSerialization();
//                        break;

//                    case "9":
//                        SoapSerializationExample.DemonstrateSoapSerialization();
//                        break;

//                    case "10":
//                        CustomSerializationExample.DemonstrateCustomSerialization();
//                        break;

//                    case "11":
//                        JsonSerializationExample.DemonstrateJsonSerialization();
//                        Console.WriteLine();
//                        JsonSerializationExample.DemonstrateObjectGraphJsonSerialization();
//                        break;

//                    case "12":
//                        Log4NetExample.DemonstrateLog4Net();
//                        Log4NetExample.DemonstrateLog4NetWithContext();
//                        break;

//                    case "13":
//                        SerilogExample.DemonstrateSerilog();
//                        SerilogExample.DemonstrateSerilogStructuredLogging();
//                        SerilogExample.Cleanup();
//                        break;

//                    case "14":
//                        NLogExample.DemonstrateNLog();
//                        NLogExample.DemonstrateNLogWithContext();
//                        break;

//                    case "15":
//                        Console.WriteLine("=== Running All Serialization Examples ===\n");
//                        JsonSerializationExample.DemonstrateJsonSerialization();
//                        Console.WriteLine();
//                        JsonSerializationExample.DemonstrateObjectGraphJsonSerialization();
//                        Console.WriteLine();
//                        CustomSerializationExample.DemonstrateCustomSerialization();
//                        Console.WriteLine();
//                        BinarySerializationExample.DemonstrateBinarySerialization();
//                        Console.WriteLine();
//                        BinarySerializationExample.DemonstrateObjectGraphSerialization();
//                        Console.WriteLine();
//                        SoapSerializationExample.DemonstrateSoapSerialization();
//                        break;

//                    case "16":
//                        Console.WriteLine("=== Running All Logging Examples ===\n");
//                        Log4NetExample.DemonstrateLog4Net();
//                        Log4NetExample.DemonstrateLog4NetWithContext();
//                        Console.WriteLine();
//                        SerilogExample.DemonstrateSerilog();
//                        SerilogExample.DemonstrateSerilogStructuredLogging();
//                        SerilogExample.Cleanup();
//                        Console.WriteLine();
//                        NLogExample.DemonstrateNLog();
//                        NLogExample.DemonstrateNLogWithContext();
//                        break;

//                    case "0":
//                        continueRunning = false;
//                        Console.WriteLine("Exiting...");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"\n✗ Error: {ex.Message}");
//                Console.WriteLine($"Stack trace: {ex.StackTrace}");
//            }

//            if (continueRunning && choice != "0")
//            {
//                Console.WriteLine("\nPress any key to continue...");
//                Console.ReadKey();
//                Console.Clear();
//            }
//        }
//    }
//}
