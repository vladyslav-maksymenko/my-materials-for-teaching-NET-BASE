using System;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: БАЗОВЕ УСПАДКУВАННЯ
    // ============================================
    // Теорія: README.md - розділ "Успадкування в C#"
    // Демонструє:
    // - Механізм успадкування
    // - Специфікатори доступу (public, protected, private)
    // - Використання конструкторів при успадкуванні
    // - Приховування імен (name hiding)
    // - Ключове слово base
    // ============================================
    
    // ============================================
    // ПРИКЛАД 1: Базове успадкування
    // ============================================
    
    // Базовий клас
    public class AnimalBase
    {
        // Публічне поле - доступне всюди
        public string Name { get; set; }
        
        // Захищене поле - доступне в похідних класах
        protected int Age { get; set; }
        
        // Приватне поле - недоступне в похідних класах
        private string Species { get; set; }
        
        // Конструктор без параметрів
        public AnimalBase()
        {
            Console.WriteLine("Викликано конструктор AnimalBase()");
            Species = "Unknown";
        }
        
        // Конструктор з параметрами
        public AnimalBase(string name, int age)
        {
            Console.WriteLine($"Викликано конструктор AnimalBase(name: {name}, age: {age})");
            Name = name;
            Age = age;
            Species = "Unknown";
        }
        
        // Публічний метод
        public void Eat()
        {
            Console.WriteLine($"{Name} їсть");
        }
        
        // Захищений метод
        protected void Sleep()
        {
            Console.WriteLine($"{Name} спить");
        }
        
        // Метод для демонстрації доступу до приватного поля
        public void ShowSpecies()
        {
            Console.WriteLine($"Вид: {Species}");
        }
    }
    
    // Похідний клас
    public class DogBase : AnimalBase
    {
        // Додаткове поле
        public string Breed { get; set; }
        
        // Конструктор без параметрів - викликає базовий конструктор
        public DogBase() : base()
        {
            Console.WriteLine("Викликано конструктор DogBase()");
        }
        
        // Конструктор з параметрами - викликає базовий конструктор з параметрами
        public DogBase(string name, int age, string breed) : base(name, age)
        {
            Console.WriteLine($"Викликано конструктор DogBase(name: {name}, age: {age}, breed: {breed})");
            Breed = breed;
        }
        
        // Власний метод
        public void Bark()
        {
            Console.WriteLine($"{Name} гавкає");
        }
        
        // Метод, який використовує захищені члени базового класу
        public void ShowInfo()
        {
            Console.WriteLine($"Собака: {Name}, Вік: {Age}, Порода: {Breed}");
            // Age доступний, бо він protected
            // Species недоступний, бо він private
        }
        
        // Метод, який викликає захищений метод базового класу
        public void MakeSleep()
        {
            Sleep(); // виклик захищеного методу
        }
    }
    
    // ============================================
    // ПРИКЛАД 2: Приховування імен (name hiding)
    // ============================================
    
    public class BaseClassInheritance
    {
        public void Method()
        {
            Console.WriteLine("Метод базового класу");
        }
        
        public int Value { get; set; } = 10;
    }
    
    public class DerivedClassInheritance : BaseClassInheritance
    {
        // Приховування методу базового класу
        public new void Method()
        {
            Console.WriteLine("Метод похідного класу");
        }
        
        // Приховування властивості
        public new int Value { get; set; } = 20;
        
        // Доступ до прихованого члена базового класу через base
        public void ShowBaseValue()
        {
            Console.WriteLine($"Значення базового класу: {base.Value}");
            Console.WriteLine($"Значення похідного класу: {this.Value}");
        }
    }
    
    // ============================================
    // ПРИКЛАД 3: Використання ключового слова base
    // ============================================
    
    public class VehicleBase
    {
        protected string brand;
        protected int year;
        
        public VehicleBase(string brand, int year)
        {
            this.brand = brand;
            this.year = year;
            Console.WriteLine($"Створено транспорт: {brand} {year}");
        }
        
        public virtual void Start()
        {
            Console.WriteLine($"{brand} запускається");
        }
        
        protected void DisplayInfo()
        {
            Console.WriteLine($"Марка: {brand}, Рік: {year}");
        }
    }
    
    public class CarBase : VehicleBase
    {
        private int doors;
        
        public CarBase(string brand, int year, int doors) : base(brand, year)
        {
            this.doors = doors;
            Console.WriteLine($"Двері: {doors}");
        }
        
        public override void Start()
        {
            base.Start(); // виклик методу базового класу
            Console.WriteLine("Автомобіль готовий до руху");
        }
        
        public void ShowFullInfo()
        {
            base.DisplayInfo(); // виклик захищеного методу базового класу
            Console.WriteLine($"Кількість дверей: {doors}");
        }
    }
}

