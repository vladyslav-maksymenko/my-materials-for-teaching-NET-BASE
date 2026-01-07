namespace Module12ConsoleApp;

// Клас для демонстрації роботи з LINQ
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Course { get; set; }
    public double AverageGrade { get; set; }
    public string Department { get; set; } = string.Empty;

    public Student(int id, string name, int age, int course, double averageGrade, string department)
    {
        Id = id;
        Name = name;
        Age = age;
        Course = course;
        AverageGrade = averageGrade;
        Department = department;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, Course: {Course}, Grade: {AverageGrade:F2}, Department: {Department}";
    }
}

