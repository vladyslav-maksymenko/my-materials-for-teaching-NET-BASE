using System;

namespace Module13ConsoleApp.Models;

[Serializable]
public class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Email { get; set; } = string.Empty;

    public Person()
    {
    }

    public Person(string firstName, string lastName, int age, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Email = email;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}, Email: {Email}";
    }
}

