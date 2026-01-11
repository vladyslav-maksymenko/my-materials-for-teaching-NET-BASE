using System;
using System.Collections.Generic;

namespace Module13ConsoleApp.Models;

[Serializable]
public class Manager : Employee
{
    public List<Employee> TeamMembers { get; set; } = new List<Employee>();
    public int TeamSize { get; set; }

    [NonSerialized]
    private string? temporaryNotes;

    public Manager()
    {
    }

    public Manager(string firstName, string lastName, int age, string email,
                  int employeeId, string position, decimal salary)
        : base(firstName, lastName, age, email, employeeId, position, salary)
    {
        TeamSize = 0;
    }

    public void AddTeamMember(Employee employee)
    {
        TeamMembers.Add(employee);
        TeamSize = TeamMembers.Count;
    }

    public void SetTemporaryNotes(string notes)
    {
        temporaryNotes = notes;
    }

    public string? GetTemporaryNotes()
    {
        return temporaryNotes;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Team Size: {TeamSize}";
    }
}

