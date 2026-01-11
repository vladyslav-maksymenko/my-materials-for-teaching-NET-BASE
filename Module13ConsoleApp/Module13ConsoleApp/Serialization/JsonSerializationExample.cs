using System.Text.Json;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Serialization;

public class JsonSerializationExample
{
    // Modern alternative to BinaryFormatter and SoapFormatter
    // Available in all .NET versions and recommended for new projects

    public static void DemonstrateJsonSerialization()
    {
        // Create sample object
        var employee = new Employee("David", "Miller", 31, "david.miller@example.com", 1003, "DevOps Engineer", 90000);
        employee.UpdateAccessTime();

        Console.WriteLine($"Original object: {employee}");
        Console.WriteLine($"Last access time: {employee.GetLastAccessTime()}");

        // Serialize to JSON
        string filePath = "employee.json";
        SerializeToJson(employee, filePath);
        Console.WriteLine($"Object serialized to JSON: {filePath}");

        // Read and display JSON content
        string jsonContent = File.ReadAllText(filePath);
        Console.WriteLine($"JSON content:\n{jsonContent}");

        // Deserialize from JSON
        var deserializedEmployee = DeserializeFromJson<Employee>(filePath);
        Console.WriteLine($"Object deserialized from JSON");
        Console.WriteLine($"  Deserialized: {deserializedEmployee}");
        Console.WriteLine($"  Note: lastAccessTime is not in JSON (NonSerialized attribute)");
    }

    public static void DemonstrateObjectGraphJsonSerialization()
    {
        // Create object graph
        var department = new Department(2, "HR", "Lviv");
        var manager = new Manager("Eva", "Davis", 38, "eva.davis@example.com", 2002, "HR Manager", 110000);
        var employee1 = new Employee("Frank", "Wilson", 26, "frank.wilson@example.com", 3003, "Recruiter", 60000);
        var employee2 = new Employee("Grace", "Moore", 29, "grace.moore@example.com", 3004, "HR Specialist", 65000);

        manager.AddTeamMember(employee1);
        manager.AddTeamMember(employee2);
        department.DepartmentManager = manager;
        department.AddEmployee(employee1);
        department.AddEmployee(employee2);

        // Serialize object graph
        string filePath = "department.json";
        SerializeToJson(department, filePath);
        Console.WriteLine($"Object graph serialized to JSON: {filePath}");

        // Deserialize object graph
        var deserializedDepartment = DeserializeFromJson<Department>(filePath);
        Console.WriteLine($"Object graph deserialized from JSON");
        Console.WriteLine($" {deserializedDepartment}");
    }

    private static void SerializeToJson<T>(T obj, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(filePath, json);
    }

    private static T? DeserializeFromJson<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<T>(json, options);
    }
}

