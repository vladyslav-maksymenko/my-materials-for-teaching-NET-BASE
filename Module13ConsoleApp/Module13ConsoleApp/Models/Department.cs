using System;
using System.Collections.Generic;

namespace Module13ConsoleApp.Models;

[Serializable]
public class Department
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } = new List<Employee>();
    public Manager? DepartmentManager { get; set; }

    public Department()
    {
    }

    public Department(int departmentId, string name, string location)
    {
        DepartmentId = departmentId;
        Name = name;
        Location = location;
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public override string ToString()
    {
        return $"Department: {Name} (ID: {DepartmentId}), Location: {Location}, " +
               $"Employees: {Employees.Count}, Manager: {DepartmentManager?.ToString() ?? "None"}";
    }
}

