using System.Xml.Serialization;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Serialization;

public class SoapSerializationExample
{
    // Note: SoapFormatter is deprecated and not available in .NET Core/.NET 5+
    // This example demonstrates XML serialization as a modern alternative
    // For true SOAP serialization, you would need .NET Framework

    public static void DemonstrateSoapSerialization()
    {
        try
        {
            // Create sample object
            var employee = new Employee("Jane", "Williams", 29, "jane.williams@example.com", 1002, "QA Engineer", 70000);

            // Serialize to XML format (alternative to SOAP)
            string filePath = "employee_soap.xml";
            SerializeToXml(employee, filePath);
            Console.WriteLine($"Object serialized to XML format: {filePath}");
            Console.WriteLine("Note: Using XmlSerializer as SoapFormatter is not available in .NET 8+");

            // Read and display XML content
            string xmlContent = File.ReadAllText(filePath);
            Console.WriteLine($"XML content:\n{xmlContent.Substring(0, Math.Min(500, xmlContent.Length))}...");

            // Deserialize from XML format
            var deserializedEmployee = DeserializeFromXml<Employee>(filePath);
            Console.WriteLine($"Object deserialized from XML format");
            Console.WriteLine($"Deserialized: {deserializedEmployee}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in XML serialization: {ex.Message}");
            Console.WriteLine("Note: SoapFormatter requires .NET Framework and is not available in .NET Core/.NET 5+");
            Console.WriteLine("This example uses XmlSerializer as a modern alternative");
        }
    }

    private static void SerializeToXml<T>(T obj, string filePath) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, obj);
        }
    }

    private static T? DeserializeFromXml<T>(string filePath) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            return serializer.Deserialize(stream) as T;
        }
    }
}

