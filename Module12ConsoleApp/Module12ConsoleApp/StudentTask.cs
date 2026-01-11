namespace Module12ConsoleApp;

// Клас для завдань модуля 12
public class StudentTask
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string School { get; set; } = string.Empty;

    public StudentTask(string firstName, string lastName, int age, string school)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        School = school;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}, School: {School}";
    }
}


