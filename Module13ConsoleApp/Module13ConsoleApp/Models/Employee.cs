using System;

namespace Module13ConsoleApp.Models;

[Serializable]
public class Employee : Person
{
    public int EmployeeId { get; set; }
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    
    [NonSerialized]
    private DateTime lastAccessTime;

    public Employee()
    {
        lastAccessTime = DateTime.Now;
    }

    public Employee(string firstName, string lastName, int age, string email, 
                   int employeeId, string position, decimal salary)
        : base(firstName, lastName, age, email)
    {
        EmployeeId = employeeId;
        Position = position;
        Salary = salary;
        lastAccessTime = DateTime.Now;
    }

    public DateTime GetLastAccessTime()
    {
        return lastAccessTime;
    }

    public void UpdateAccessTime()
    {
        lastAccessTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, ID: {EmployeeId}, Position: {Position}, Salary: {Salary:C}";
    }
}

