using System;
using System.IO;
using System.Text.Json;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Serialization;

public class CustomSerializationExample
{
    // Demonstrates custom serialization concept
    // Note: ISerializable interface is typically used with BinaryFormatter
    // BinaryFormatter is deprecated in .NET 5+ and removed in .NET 8+
    // This example shows the concept using JSON serialization
    // The CustomSerializableClass implements ISerializable for demonstration

    public static void DemonstrateCustomSerialization()
    {
        try
        {
            // Create object with custom serialization
            var customObject = new CustomSerializableClass("CustomObject", 42);
            customObject.SetTemporaryData("This will not be serialized");

            Console.WriteLine($"Original object: {customObject}");
            Console.WriteLine($"Temporary data: {customObject.GetTemporaryData()}");
            Console.WriteLine("Note: ISerializable is typically used with BinaryFormatter");
            Console.WriteLine("      BinaryFormatter is not available in .NET 8+");
            Console.WriteLine("      Demonstrating custom serialization concept using JSON\n");

            // Serialize using JSON (demonstrating the concept)
            string filePath = "custom_object.json";
            SerializeCustomObject(customObject, filePath);
            Console.WriteLine($"✓ Custom object serialized: {filePath}");

            // Read JSON content
            string jsonContent = File.ReadAllText(filePath);
            Console.WriteLine($"JSON content:\n{jsonContent}");

            // Deserialize
            var deserializedObject = DeserializeCustomObject(filePath);
            Console.WriteLine($"✓ Custom object deserialized");
            Console.WriteLine($"  Deserialized: {deserializedObject}");
            Console.WriteLine($"  Temporary data after deserialization: {deserializedObject?.GetTemporaryData() ?? "null"}");
            Console.WriteLine($"  Note: Temporary data is not preserved (NonSerialized + custom logic)");
            Console.WriteLine($"  Note: ISerializable.GetObjectData() would be called with BinaryFormatter");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error in custom serialization: {ex.Message}");
        }
    }

    private static void SerializeCustomObject(CustomSerializableClass obj, string filePath)
    {
        // Using JSON to demonstrate the concept
        // With BinaryFormatter, ISerializable.GetObjectData() would be called
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(filePath, json);
    }

    private static CustomSerializableClass? DeserializeCustomObject(string filePath)
    {
        // Using JSON to demonstrate the concept
        // With BinaryFormatter, the protected constructor would be called
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<CustomSerializableClass>(json);
    }
}

