using System;
using System.IO;
using System.Text;
using Module13ConsoleApp.Models;

namespace Module13ConsoleApp.Serialization;

public class BinarySerializationExample
{
    // Note: BinaryFormatter is deprecated in .NET 5+ and removed in .NET 8+
    // This example demonstrates binary serialization concept using alternative approach
    // For true BinaryFormatter, you would need .NET Framework 4.8 or .NET Core 3.1
    // For modern .NET, consider using System.Text.Json or System.IO.BinaryWriter

    public static void DemonstrateBinarySerialization()
    {
        try
        {
            // Create sample object
            var employee = new Employee("John", "Doe", 30, "john.doe@example.com", 1001, "Software Developer", 75000);

            Console.WriteLine("Note: BinaryFormatter is not available in .NET 8+");
            Console.WriteLine("Demonstrating binary serialization concept using BinaryWriter\n");

            // Serialize to binary format using BinaryWriter (alternative approach)
            string filePath = "employee_binary.dat";
            SerializeToBinary(employee, filePath);
            Console.WriteLine($"Object serialized to binary format: {filePath}");

            // Deserialize from binary format
            var deserializedEmployee = DeserializeFromBinary<Employee>(filePath);
            Console.WriteLine($"Object deserialized from binary format");
            Console.WriteLine($"  Deserialized: {deserializedEmployee}");
            Console.WriteLine($"  Note: lastAccessTime is not serialized (NonSerialized attribute)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error in binary serialization: {ex.Message}");
            Console.WriteLine("  Note: BinaryFormatter requires .NET Framework 4.8 or older .NET Core versions");
        }
    }

    private static void SerializeToBinary<T>(T obj, string filePath) where T : class
    {
        // Alternative binary serialization using BinaryWriter
        // This is a simplified example - real BinaryFormatter would handle complex object graphs
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            if (obj is Employee employee)
            {
                writer.Write(employee.FirstName);
                writer.Write(employee.LastName);
                writer.Write(employee.Age);
                writer.Write(employee.Email);
                writer.Write(employee.EmployeeId);
                writer.Write(employee.Position);
                writer.Write(employee.Salary);
                // Note: lastAccessTime is not written (NonSerialized)
            }
            else if (obj is Department department)
            {
                // Simplified serialization - in real BinaryFormatter, this would handle the full graph
                writer.Write(department.DepartmentId);
                writer.Write(department.Name);
                writer.Write(department.Location);
                writer.Write(department.Employees.Count);
                foreach (var emp in department.Employees)
                {
                    writer.Write(emp.FirstName);
                    writer.Write(emp.LastName);
                    writer.Write(emp.Age);
                    writer.Write(emp.Email);
                    writer.Write(emp.EmployeeId);
                    writer.Write(emp.Position);
                    writer.Write(emp.Salary);
                }
                // Note: Manager relationship is simplified - real formatter would handle references
            }
        }
    }

    private static T? DeserializeFromBinary<T>(string filePath) where T : class
    {
        // Alternative binary deserialization using BinaryReader
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            if (typeof(T) == typeof(Employee))
            {
                string firstName = reader.ReadString();
                string lastName = reader.ReadString();
                int age = reader.ReadInt32();
                string email = reader.ReadString();
                int employeeId = reader.ReadInt32();
                string position = reader.ReadString();
                decimal salary = reader.ReadDecimal();

                var employee = new Employee(firstName, lastName, age, email, employeeId, position, salary);
                // Note: lastAccessTime will be set to current time (default constructor behavior)
                return employee as T;
            }
            else if (typeof(T) == typeof(Department))
            {
                // Simplified deserialization - in real BinaryFormatter, this would restore the full graph
                int departmentId = reader.ReadInt32();
                string name = reader.ReadString();
                string location = reader.ReadString();
                int employeeCount = reader.ReadInt32();
                
                var department = new Department(departmentId, name, location);
                for (int i = 0; i < employeeCount; i++)
                {
                    string firstName = reader.ReadString();
                    string lastName = reader.ReadString();
                    int age = reader.ReadInt32();
                    string email = reader.ReadString();
                    int employeeId = reader.ReadInt32();
                    string position = reader.ReadString();
                    decimal salary = reader.ReadDecimal();
                    
                    var employee = new Employee(firstName, lastName, age, email, employeeId, position, salary);
                    department.AddEmployee(employee);
                }
                // Note: Manager relationship is not restored in this simplified example
                return department as T;
            }
        }
        return null;
    }

    public static void DemonstrateObjectGraphSerialization()
    {
        try
        {
            // Create object graph with relationships
            var department = new Department(1, "IT", "Kyiv");
            var manager = new Manager("Alice", "Smith", 35, "alice.smith@example.com", 2001, "IT Manager", 120000);
            var employee1 = new Employee("Bob", "Johnson", 28, "bob.johnson@example.com", 3001, "Developer", 80000);
            var employee2 = new Employee("Charlie", "Brown", 32, "charlie.brown@example.com", 3002, "Developer", 85000);

            manager.AddTeamMember(employee1);
            manager.AddTeamMember(employee2);
            department.DepartmentManager = manager;
            department.AddEmployee(employee1);
            department.AddEmployee(employee2);

            // Serialize object graph
            string filePath = "department_binary.dat";
            SerializeToBinary(department, filePath);
            Console.WriteLine($"Object graph serialized: {filePath}");

            // Deserialize object graph
            var deserializedDepartment = DeserializeFromBinary<Department>(filePath);
            Console.WriteLine($"Object graph deserialized");
            Console.WriteLine($"  {deserializedDepartment}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in object graph serialization: {ex.Message}");
        }
    }
}

