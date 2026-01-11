namespace Module12ConsoleApp;

// Клас для завдань модуля 12
public class Car
{
    public string Name { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Year { get; set; }

    public Car(string name, string manufacturer, int year)
    {
        Name = name;
        Manufacturer = manufacturer;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Name} ({Manufacturer}), Year: {Year}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Car car)
        {
            return Manufacturer == car.Manufacturer;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Manufacturer.GetHashCode();
    }
}


