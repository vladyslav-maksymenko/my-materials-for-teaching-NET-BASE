namespace Module12ConsoleApp;

// Клас для демонстрації роботи з LINQ
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, string category, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Stock = stock;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Category: {Category}, Price: {Price:C}, Stock: {Stock}";
    }
}

