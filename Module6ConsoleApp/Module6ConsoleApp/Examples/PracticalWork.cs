using System;
using System.Collections.Generic;
using System.Linq;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНА РОБОТА: УСПАДКУВАННЯ В C#
    // ============================================
    // Цей файл містить 6 завдань для практичного закріплення матеріалу
    // Теорія: README.md
    // ============================================

    // ============================================
    // ЗАВДАННЯ 1: Клас Human з похідними класами
    // ============================================
    
    /// <summary>
    /// Базовий клас, що представляє людину
    /// </summary>
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
        /// <summary>
        /// Конструктор базового класу
        /// </summary>
        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            
            if (age < 0)
                throw new ArgumentException("Вік не може бути від'ємним", nameof(age));
            
            Age = age;
        }
        
        /// <summary>
        /// Виводить інформацію про людину
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {FirstName} {LastName}, Вік: {Age}");
        }
        
        /// <summary>
        /// Віртуальний метод для опису професії
        /// </summary>
        public virtual void Work()
        {
            Console.WriteLine($"{FirstName} {LastName} працює");
        }
    }
    
    /// <summary>
    /// Клас будівельника, успадкований від Human
    /// </summary>
    public class Builder : Human
    {
        public string Specialization { get; set; } // наприклад: "Електрик", "Сантехнік", "Маляр"
        public int YearsOfExperience { get; set; }
        
        /// <summary>
        /// Конструктор класу Builder
        /// </summary>
        public Builder(string firstName, string lastName, int age, string specialization, int yearsOfExperience) 
            : base(firstName, lastName, age)
        {
            Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
            
            if (yearsOfExperience < 0)
                throw new ArgumentException("Досвід не може бути від'ємним", nameof(yearsOfExperience));
            
            YearsOfExperience = yearsOfExperience;
        }
        
        /// <summary>
        /// Перевизначення методу для виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Професія: Будівельник, Спеціалізація: {Specialization}, Досвід: {YearsOfExperience} років");
        }
        
        /// <summary>
        /// Перевизначення методу роботи
        /// </summary>
        public override void Work()
        {
            Console.WriteLine($"{FirstName} {LastName} будує як {Specialization}");
        }
        
        /// <summary>
        /// Специфічний метод будівельника
        /// </summary>
        public void Build()
        {
            Console.WriteLine($"{FirstName} виконує будівельні роботи");
        }
    }

    /// <summary>
    /// Клас моряка, успадкований від Human
    /// </summary>
    public class Sailor : Human
    {
        public string ShipName { get; set; }
        public string Rank { get; set; } // наприклад: "Капітан", "Штурман", "Матрос"
        
        /// <summary>
        /// Конструктор класу Sailor
        /// </summary>
        public Sailor(string firstName, string lastName, int age, string shipName, string rank) 
            : base(firstName, lastName, age)
        {
            ShipName = shipName ?? throw new ArgumentNullException(nameof(shipName));
            Rank = rank ?? throw new ArgumentNullException(nameof(rank));
        }
        
        /// <summary>
        /// Перевизначення методу для виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Професія: Моряк, Корабель: {ShipName}, Звання: {Rank}");
        }
        
        /// <summary>
        /// Перевизначення методу роботи
        /// </summary>
        public override void Work()
        {
            Console.WriteLine($"{FirstName} {LastName} працює на кораблі {ShipName} як {Rank}");
        }
        
        /// <summary>
        /// Специфічний метод моряка
        /// </summary>
        public void Navigate()
        {
            Console.WriteLine($"{FirstName} керує кораблем {ShipName}");
        }
    }
    
    /// <summary>
    /// Клас льотчика, успадкований від Human
    /// </summary>
    public class Pilot : Human
    {
        public string AircraftType { get; set; } // наприклад: "Boeing 737", "Airbus A320"
        public int FlightHours { get; set; }
        
        /// <summary>
        /// Конструктор класу Pilot
        /// </summary>
        public Pilot(string firstName, string lastName, int age, string aircraftType, int flightHours) 
            : base(firstName, lastName, age)
        {
            AircraftType = aircraftType ?? throw new ArgumentNullException(nameof(aircraftType));
            
            if (flightHours < 0)
                throw new ArgumentException("Кількість годин польоту не може бути від'ємною", nameof(flightHours));
            
            FlightHours = flightHours;
        }
        
        /// <summary>
        /// Перевизначення методу для виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Професія: Льотчик, Тип літака: {AircraftType}, Години польоту: {FlightHours}");
        }
        
        /// <summary>
        /// Перевизначення методу роботи
        /// </summary>
        public override void Work()
        {
            Console.WriteLine($"{FirstName} {LastName} керує літаком {AircraftType}");
        }
        
        /// <summary>
        /// Специфічний метод льотчика
        /// </summary>
        public void Fly()
        {
            Console.WriteLine($"{FirstName} виконує політ на {AircraftType}");
        }
    }
    
    // ============================================
    // ЗАВДАННЯ 2: Клас Passport з похідним ForeignPassport
    // ============================================
    
    /// <summary>
    /// Базовий клас, що представляє паспорт
    /// </summary>
    public class Passport
    {
        public string PassportNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingAuthority { get; set; }
        
        /// <summary>
        /// Конструктор класу Passport
        /// </summary>
        public Passport(string passportNumber, string fullName, DateTime dateOfBirth, string placeOfBirth, 
                       DateTime issueDate, string issuingAuthority)
        {
            PassportNumber = passportNumber ?? throw new ArgumentNullException(nameof(passportNumber));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            PlaceOfBirth = placeOfBirth ?? throw new ArgumentNullException(nameof(placeOfBirth));
            IssuingAuthority = issuingAuthority ?? throw new ArgumentNullException(nameof(issuingAuthority));
            
            if (issueDate > DateTime.Now)
                throw new ArgumentException("Дата видачі не може бути в майбутньому", nameof(issueDate));
            
            DateOfBirth = dateOfBirth;
            IssueDate = issueDate;
        }
        
        /// <summary>
        /// Виводить інформацію про паспорт
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine("=== ВНУТРІШНІЙ ПАСПОРТ ===");
            Console.WriteLine($"Номер паспорта: {PassportNumber}");
            Console.WriteLine($"ПІБ: {FullName}");
            Console.WriteLine($"Дата народження: {DateOfBirth:dd.MM.yyyy}");
            Console.WriteLine($"Місце народження: {PlaceOfBirth}");
            Console.WriteLine($"Дата видачі: {IssueDate:dd.MM.yyyy}");
            Console.WriteLine($"Орган, що видав: {IssuingAuthority}");
        }
        
        /// <summary>
        /// Перевіряє валідність паспорта
        /// </summary>
        public virtual bool IsValid()
        {
            // Паспорт вважається валідним, якщо не минуло більше 10 років з дати видачі
            return (DateTime.Now - IssueDate).TotalDays <= 3650; // 10 років
        }
    }
    
    /// <summary>
    /// Клас візи для закордонного паспорта
    /// </summary>
    public class Visa
    {
        public string Country { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string VisaType { get; set; } // наприклад: "Туристична", "Робоча", "Транзитна"
        
        public Visa(string country, DateTime issueDate, DateTime expiryDate, string visaType)
        {
            Country = country ?? throw new ArgumentNullException(nameof(country));
            VisaType = visaType ?? throw new ArgumentNullException(nameof(visaType));
            
            if (expiryDate <= issueDate)
                throw new ArgumentException("Дата закінчення візи повинна бути пізніше дати видачі", nameof(expiryDate));
            
            IssueDate = issueDate;
            ExpiryDate = expiryDate;
        }
        
        public bool IsValid()
        {
            return DateTime.Now >= IssueDate && DateTime.Now <= ExpiryDate;
        }
        
        public override string ToString()
        {
            return $"Віза: {Country} ({VisaType}), {IssueDate:dd.MM.yyyy} - {ExpiryDate:dd.MM.yyyy}";
        }
    }
    
    /// <summary>
    /// Клас закордонного паспорта, успадкований від Passport
    /// </summary>
    public class ForeignPassport : Passport
    {
        public string ForeignPassportNumber { get; set; }
        public List<Visa> Visas { get; set; }
        
        /// <summary>
        /// Конструктор класу ForeignPassport
        /// </summary>
        public ForeignPassport(string passportNumber, string fullName, DateTime dateOfBirth, string placeOfBirth,
                              DateTime issueDate, string issuingAuthority, string foreignPassportNumber)
            : base(passportNumber, fullName, dateOfBirth, placeOfBirth, issueDate, issuingAuthority)
        {
            ForeignPassportNumber = foreignPassportNumber ?? throw new ArgumentNullException(nameof(foreignPassportNumber));
            Visas = new List<Visa>();
        }
        
        /// <summary>
        /// Додає візу до закордонного паспорта
        /// </summary>
        public void AddVisa(Visa visa)
        {
            if (visa == null)
                throw new ArgumentNullException(nameof(visa));
            
            Visas.Add(visa);
        }
        
        /// <summary>
        /// Перевизначення методу для виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("\n=== ЗАКОРДОННИЙ ПАСПОРТ ===");
            Console.WriteLine($"Номер закордонного паспорта: {ForeignPassportNumber}");
            
            if (Visas.Count > 0)
            {
                Console.WriteLine("\nВізи:");
                foreach (var visa in Visas)
                {
                    Console.WriteLine($"  - {visa}");
                }
            }
            else
            {
                Console.WriteLine("Візи відсутні");
            }
        }
        
        /// <summary>
        /// Перевіряє наявність валідної візи для країни
        /// </summary>
        public bool HasValidVisaFor(string country)
        {
            return Visas.Any(v => v.Country.Equals(country, StringComparison.OrdinalIgnoreCase) && v.IsValid());
        }
    }
    
    // ============================================
    // ЗАВДАННЯ 3: Базовий клас "Тварина" з похідними
    // ============================================
    
    /// <summary>
    /// Базовий клас, що представляє тварину
    /// </summary>
    public class AnimalPractical
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public double Weight { get; set; } // вага в кілограмах
        public int Age { get; set; } // вік в роках
        
        /// <summary>
        /// Конструктор базового класу
        /// </summary>
        public AnimalPractical(string name, string species, double weight, int age)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Species = species ?? throw new ArgumentNullException(nameof(species));
            
            if (weight <= 0)
                throw new ArgumentException("Вага повинна бути більше нуля", nameof(weight));
            
            if (age < 0)
                throw new ArgumentException("Вік не може бути від'ємним", nameof(age));
            
            Weight = weight;
            Age = age;
        }
        
        /// <summary>
        /// Віртуальний метод для виведення інформації
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Тварина: {Name}");
            Console.WriteLine($"Вид: {Species}");
            Console.WriteLine($"Вага: {Weight} кг");
            Console.WriteLine($"Вік: {Age} років");
        }
        
        /// <summary>
        /// Віртуальний метод для звуку тварини
        /// </summary>
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} видає звук");
        }
        
        /// <summary>
        /// Віртуальний метод для руху тварини
        /// </summary>
        public virtual void Move()
        {
            Console.WriteLine($"{Name} рухається");
        }
    }
    
    /// <summary>
    /// Клас тигра, успадкований від Animal
    /// </summary>
    public class Tiger : AnimalPractical
    {
        public int StripesCount { get; set; } // кількість смуг
        public string Habitat { get; set; } // середовище існування
        
        /// <summary>
        /// Конструктор класу Tiger
        /// </summary>
        public Tiger(string name, double weight, int age, int stripesCount, string habitat)
            : base(name, "Тигр", weight, age)
        {
            if (stripesCount < 0)
                throw new ArgumentException("Кількість смуг не може бути від'ємною", nameof(stripesCount));
            
            StripesCount = stripesCount;
            Habitat = habitat ?? throw new ArgumentNullException(nameof(habitat));
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Кількість смуг: {StripesCount}");
            Console.WriteLine($"Середовище існування: {Habitat}");
        }
        
        /// <summary>
        /// Перевизначення методу звуку
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} реве: Р-р-р-р!");
        }
        
        /// <summary>
        /// Перевизначення методу руху
        /// </summary>
        public override void Move()
        {
            Console.WriteLine($"{Name} біжить швидко по {Habitat}");
        }
        
        /// <summary>
        /// Специфічний метод тигра
        /// </summary>
        public void Hunt()
        {
            Console.WriteLine($"{Name} полює");
        }
    }
    
    /// <summary>
    /// Клас крокодила, успадкований від Animal
    /// </summary>
    public class Crocodile : AnimalPractical
    {
        public double Length { get; set; } // довжина в метрах
        public bool IsInWater { get; set; } // чи знаходиться у воді
        
        /// <summary>
        /// Конструктор класу Crocodile
        /// </summary>
        public Crocodile(string name, double weight, int age, double length, bool isInWater)
            : base(name, "Крокодил", weight, age)
        {
            if (length <= 0)
                throw new ArgumentException("Довжина повинна бути більше нуля", nameof(length));
            
            Length = length;
            IsInWater = isInWater;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Довжина: {Length} м");
            Console.WriteLine($"Місцезнаходження: {(IsInWater ? "У воді" : "На суші")}");
        }
        
        /// <summary>
        /// Перевизначення методу звуку
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} видає звук: Гр-р-р!");
        }
        
        /// <summary>
        /// Перевизначення методу руху
        /// </summary>
        public override void Move()
        {
            if (IsInWater)
                Console.WriteLine($"{Name} плаває у воді");
            else
                Console.WriteLine($"{Name} повзає по суші");
        }
        
        /// <summary>
        /// Специфічний метод крокодила
        /// </summary>
        public void BaskInSun()
        {
            if (!IsInWater)
                Console.WriteLine($"{Name} гріється на сонці");
            else
                Console.WriteLine($"{Name} не може грітися на сонці, бо у воді");
        }
    }
    
    /// <summary>
    /// Клас кенгуру, успадкований від Animal
    /// </summary>
    public class Kangaroo : AnimalPractical
    {
        public double JumpHeight { get; set; } // висота стрибка в метрах
        public bool HasBaby { get; set; } // чи має дитинча в сумці
        
        /// <summary>
        /// Конструктор класу Kangaroo
        /// </summary>
        public Kangaroo(string name, double weight, int age, double jumpHeight, bool hasBaby)
            : base(name, "Кенгуру", weight, age)
        {
            if (jumpHeight < 0)
                throw new ArgumentException("Висота стрибка не може бути від'ємною", nameof(jumpHeight));
            
            JumpHeight = jumpHeight;
            HasBaby = hasBaby;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Висота стрибка: {JumpHeight} м");
            Console.WriteLine($"Дитинча в сумці: {(HasBaby ? "Так" : "Ні")}");
        }
        
        /// <summary>
        /// Перевизначення методу звуку
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} видає звук: Хоп-хоп!");
        }
        
        /// <summary>
        /// Перевизначення методу руху
        /// </summary>
        public override void Move()
        {
            Console.WriteLine($"{Name} стрибає на висоту {JumpHeight} м");
        }
        
        /// <summary>
        /// Специфічний метод кенгуру
        /// </summary>
        public void Jump()
        {
            Console.WriteLine($"{Name} виконує стрибок на {JumpHeight} м");
        }
    }
    
    // ============================================
    // ЗАВДАННЯ 4: Абстрактний клас "Фігура"
    // ============================================
    
    /// <summary>
    /// Абстрактний базовий клас для геометричних фігур
    /// </summary>
    public abstract class Figure
    {
        public string Name { get; set; }
        
        /// <summary>
        /// Конструктор базового класу
        /// </summary>
        protected Figure(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        /// <summary>
        /// Абстрактний метод для обчислення площі
        /// </summary>
        public abstract double CalculateArea();
        
        /// <summary>
        /// Віртуальний метод для виведення інформації
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Фігура: {Name}");
            Console.WriteLine($"Площа: {CalculateArea():F2}");
        }
    }
    
    /// <summary>
    /// Клас прямокутника
    /// </summary>
    public class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        
        /// <summary>
        /// Конструктор класу Rectangle
        /// </summary>
        public Rectangle(string name, double width, double height) : base(name)
        {
            if (width <= 0)
                throw new ArgumentException("Ширина повинна бути більше нуля", nameof(width));
            if (height <= 0)
                throw new ArgumentException("Висота повинна бути більше нуля", nameof(height));
            
            Width = width;
            Height = height;
        }
        
        /// <summary>
        /// Реалізація методу обчислення площі
        /// </summary>
        public override double CalculateArea()
        {
            return Width * Height;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Розміри: {Width} x {Height}");
        }
    }
    
    /// <summary>
    /// Клас кола
    /// </summary>
    public class Circle : Figure
    {
        public double Radius { get; set; }
        
        /// <summary>
        /// Конструктор класу Circle
        /// </summary>
        public Circle(string name, double radius) : base(name)
        {
            if (radius <= 0)
                throw new ArgumentException("Радіус повинен бути більше нуля", nameof(radius));
            
            Radius = radius;
        }
        
        /// <summary>
        /// Реалізація методу обчислення площі
        /// </summary>
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Радіус: {Radius}");
        }
    }
    
    /// <summary>
    /// Клас прямокутного трикутника
    /// </summary>
    public class RightTriangle : Figure
    {
        public double LegA { get; set; }
        public double LegB { get; set; }
        
        /// <summary>
        /// Конструктор класу RightTriangle
        /// </summary>
        public RightTriangle(string name, double legA, double legB) : base(name)
        {
            if (legA <= 0)
                throw new ArgumentException("Катет A повинен бути більше нуля", nameof(legA));
            if (legB <= 0)
                throw new ArgumentException("Катет B повинен бути більше нуля", nameof(legB));
            
            LegA = legA;
            LegB = legB;
        }
        
        /// <summary>
        /// Реалізація методу обчислення площі
        /// </summary>
        public override double CalculateArea()
        {
            return (LegA * LegB) / 2.0;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Катети: {LegA} x {LegB}");
        }
    }
    
    /// <summary>
    /// Клас трапеції
    /// </summary>
    public class Trapezoid : Figure
    {
        public double BaseA { get; set; } // верхня основа
        public double BaseB { get; set; } // нижня основа
        public double Height { get; set; } // висота
        
        /// <summary>
        /// Конструктор класу Trapezoid
        /// </summary>
        public Trapezoid(string name, double baseA, double baseB, double height) : base(name)
        {
            if (baseA <= 0)
                throw new ArgumentException("Основа A повинна бути більше нуля", nameof(baseA));
            if (baseB <= 0)
                throw new ArgumentException("Основа B повинна бути більше нуля", nameof(baseB));
            if (height <= 0)
                throw new ArgumentException("Висота повинна бути більше нуля", nameof(height));
            
            BaseA = baseA;
            BaseB = baseB;
            Height = height;
        }
        
        /// <summary>
        /// Реалізація методу обчислення площі
        /// </summary>
        public override double CalculateArea()
        {
            return ((BaseA + BaseB) / 2.0) * Height;
        }
        
        /// <summary>
        /// Перевизначення методу виведення інформації
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Основи: {BaseA} і {BaseB}, Висота: {Height}");
        }
    }
    
    // ============================================
    // ЗАВДАННЯ 5: Власний клас винятку та клас Person
    // ============================================
    
    /// <summary>
    /// Власний клас винятку для невалідного віку
    /// </summary>
    public class InvalidAgeException : ArgumentException
    {
        public int InvalidAge { get; }
        
        /// <summary>
        /// Конструктор з повідомленням
        /// </summary>
        public InvalidAgeException(int invalidAge) 
            : base($"Невалідний вік: {invalidAge}. Вік повинен бути від 0 до 120 років.")
        {
            InvalidAge = invalidAge;
        }
        
        /// <summary>
        /// Конструктор з повідомленням та ім'ям параметра
        /// </summary>
        public InvalidAgeException(int invalidAge, string paramName) 
            : base($"Невалідний вік: {invalidAge}. Вік повинен бути від 0 до 120 років.", paramName)
        {
            InvalidAge = invalidAge;
        }
    }
    
    /// <summary>
    /// Клас, що представляє особу з валідацією віку
    /// </summary>
    public class PersonPractical
    {
        private int _age;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        /// <summary>
        /// Властивість віку з валідацією
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 120)
                    throw new InvalidAgeException(value, nameof(Age));
                
                _age = value;
            }
        }
        
        /// <summary>
        /// Конструктор класу PersonPractical
        /// </summary>
        public PersonPractical(string firstName, string lastName, int age)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Age = age; // використовуємо властивість, яка виконає валідацію
        }
        
        /// <summary>
        /// Виводить інформацію про особу
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {FirstName} {LastName}, Вік: {Age}");
        }
    }
    
    // ============================================
    // ЗАВДАННЯ 6: Абстрактний клас Document з похідними
    // ============================================
    
    /// <summary>
    /// Власний клас винятку для невалідних даних документа
    /// </summary>
    public class InvalidDocumentDataException : Exception
    {
        public string DocumentType { get; }
        public string MissingField { get; }
        
        /// <summary>
        /// Конструктор винятку
        /// </summary>
        public InvalidDocumentDataException(string documentType, string missingField) 
            : base($"Документ '{documentType}' не може бути надрукований. Відсутнє обов'язкове поле: {missingField}")
        {
            DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
            MissingField = missingField ?? throw new ArgumentNullException(nameof(missingField));
        }
    }
    
    /// <summary>
    /// Абстрактний базовий клас для документів
    /// </summary>
    public abstract class Document
    {
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Конструктор базового класу
        /// </summary>
        protected Document(string documentNumber, DateTime date)
        {
            DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
            Date = date;
        }
        
        /// <summary>
        /// Абстрактний метод для друку документа
        /// </summary>
        public abstract void Print();
        
        /// <summary>
        /// Віртуальний метод для виведення базової інформації
        /// </summary>
        public virtual void DisplayBasicInfo()
        {
            Console.WriteLine($"Номер документа: {DocumentNumber}");
            Console.WriteLine($"Дата: {Date:dd.MM.yyyy}");
        }
    }
    
    /// <summary>
    /// Клас звіту, успадкований від Document
    /// </summary>
    public class Report : Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        
        /// <summary>
        /// Конструктор класу Report
        /// </summary>
        public Report(string documentNumber, DateTime date, string title, string content, string author)
            : base(documentNumber, date)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }
        
        /// <summary>
        /// Реалізація методу друку
        /// </summary>
        public override void Print()
        {
            Console.WriteLine("=== ЗВІТ ===");
            DisplayBasicInfo();
            Console.WriteLine($"Назва: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Зміст:\n{Content}");
            Console.WriteLine("=== КІНЕЦЬ ЗВІТУ ===\n");
        }
    }
    
    /// <summary>
    /// Клас рахунку-фактури, успадкований від Document
    /// </summary>
    public class Invoice : Document
    {
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public decimal? Amount { get; set; }
        public string? ItemDescription { get; set; }
        
        /// <summary>
        /// Конструктор класу Invoice
        /// </summary>
        public Invoice(string documentNumber, DateTime date) 
            : base(documentNumber, date)
        {
            // Поля залишаються null - будуть встановлені пізніше
        }
        
        /// <summary>
        /// Реалізація методу друку з валідацією
        /// </summary>
        public override void Print()
        {
            // Валідація обов'язкових полів
            if (string.IsNullOrWhiteSpace(CustomerName))
                throw new InvalidDocumentDataException("Рахунок-фактура", "Ім'я клієнта");
            
            if (string.IsNullOrWhiteSpace(CustomerAddress))
                throw new InvalidDocumentDataException("Рахунок-фактура", "Адреса клієнта");
            
            if (Amount == null || Amount <= 0)
                throw new InvalidDocumentDataException("Рахунок-фактура", "Сума (має бути більше нуля)");
            
            if (string.IsNullOrWhiteSpace(ItemDescription))
                throw new InvalidDocumentDataException("Рахунок-фактура", "Опис товару/послуги");
            
            // Якщо всі дані валідні, виводимо рахунок
            Console.WriteLine("=== РАХУНОК-ФАКТУРА ===");
            DisplayBasicInfo();
            Console.WriteLine($"Клієнт: {CustomerName}");
            Console.WriteLine($"Адреса: {CustomerAddress}");
            Console.WriteLine($"Опис: {ItemDescription}");
            Console.WriteLine($"Сума: {Amount:C}");
            Console.WriteLine("=== КІНЕЦЬ РАХУНКУ-ФАКТУРИ ===\n");
        }
    }
    
    // ============================================
    // КЛАС ДЛЯ ДЕМОНСТРАЦІЇ ВСІХ ЗАВДАНЬ
    // ============================================
    
    /// <summary>
    /// Клас для демонстрації всіх завдань практичної роботи
    /// </summary>
    public static class PracticalWorkDemo
    {
        /// <summary>
        /// Демонстрація завдання 1: Human з похідними класами
        /// </summary>
        public static void DemonstrateTask1()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 1: Клас Human з похідними класами");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            var builder = new Builder("Іван", "Петренко", 35, "Електрик", 10);
            var sailor = new Sailor("Олександр", "Коваленко", 28, "Титанік", "Капітан");
            var pilot = new Pilot("Марія", "Іваненко", 32, "Boeing 737", 5000);
            
            Console.WriteLine("--- Інформація про будівельника ---");
            builder.DisplayInfo();
            builder.Work();
            builder.Build();
            Console.WriteLine();
            
            Console.WriteLine("--- Інформація про моряка ---");
            sailor.DisplayInfo();
            sailor.Work();
            sailor.Navigate();
            Console.WriteLine();
            
            Console.WriteLine("--- Інформація про льотчика ---");
            pilot.DisplayInfo();
            pilot.Work();
            pilot.Fly();
            Console.WriteLine();
        }
        
        /// <summary>
        /// Демонстрація завдання 2: Passport з похідним ForeignPassport
        /// </summary>
        public static void DemonstrateTask2()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 2: Клас Passport з похідним ForeignPassport");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            var passport = new Passport(
                "КМ123456",
                "Петренко Іван Олександрович",
                new DateTime(1990, 5, 15),
                "м. Київ",
                new DateTime(2020, 1, 10),
                "Управління ДМС у м. Києві"
            );
            
            Console.WriteLine("--- Внутрішній паспорт ---");
            passport.DisplayInfo();
            Console.WriteLine($"Валідність: {(passport.IsValid() ? "Валідний" : "Невалідний")}\n");
            
            var foreignPassport = new ForeignPassport(
                "КМ123456",
                "Петренко Іван Олександрович",
                new DateTime(1990, 5, 15),
                "м. Київ",
                new DateTime(2020, 1, 10),
                "Управління ДМС у м. Києві",
                "AB123456"
            );
            
            foreignPassport.AddVisa(new Visa("Польща", new DateTime(2024, 1, 1), new DateTime(2024, 12, 31), "Туристична"));
            foreignPassport.AddVisa(new Visa("Німеччина", new DateTime(2024, 6, 1), new DateTime(2024, 12, 31), "Робоча"));
            
            Console.WriteLine("--- Закордонний паспорт ---");
            foreignPassport.DisplayInfo();
            Console.WriteLine($"Валідна віза для Польщі: {foreignPassport.HasValidVisaFor("Польща")}");
            Console.WriteLine($"Валідна віза для Франції: {foreignPassport.HasValidVisaFor("Франція")}\n");
        }
        
        /// <summary>
        /// Демонстрація завдання 3: Тварини
        /// </summary>
        public static void DemonstrateTask3()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 3: Базовий клас 'Тварина' з похідними");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            var tiger = new Tiger("Амур", 200, 8, 100, "Тайга");
            var crocodile = new Crocodile("Гена", 500, 15, 4.5, false);
            var kangaroo = new Kangaroo("Джек", 70, 5, 3.0, true);
            
            Console.WriteLine("--- Тигр ---");
            tiger.DisplayInfo();
            tiger.MakeSound();
            tiger.Move();
            tiger.Hunt();
            Console.WriteLine();
            
            Console.WriteLine("--- Крокодил ---");
            crocodile.DisplayInfo();
            crocodile.MakeSound();
            crocodile.Move();
            crocodile.BaskInSun();
            Console.WriteLine();
            
            Console.WriteLine("--- Кенгуру ---");
            kangaroo.DisplayInfo();
            kangaroo.MakeSound();
            kangaroo.Move();
            kangaroo.Jump();
            Console.WriteLine();
        }
        
        /// <summary>
        /// Демонстрація завдання 4: Абстрактний клас Фігура
        /// </summary>
        public static void DemonstrateTask4()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 4: Абстрактний клас 'Фігура' з похідними");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            // Створюємо масив посилань на абстрактний клас
            Figure[] figures = new Figure[]
            {
                new Rectangle("Прямокутник 1", 10, 5),
                new Circle("Коло 1", 7),
                new RightTriangle("Трикутник 1", 6, 8),
                new Trapezoid("Трапеція 1", 5, 10, 4),
                new Rectangle("Прямокутник 2", 15, 8),
                new Circle("Коло 2", 10)
            };
            
            Console.WriteLine("=== Обчислення площ фігур ===\n");
            foreach (var figure in figures)
            {
                figure.DisplayInfo();
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Демонстрація завдання 5: Власний виняток та клас Person
        /// </summary>
        public static void DemonstrateTask5()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 5: Власний виняток InvalidAgeException та клас Person");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            // Валідні об'єкти
            try
            {
                var person1 = new PersonPractical("Іван", "Петренко", 25);
                Console.WriteLine("✅ Створено особу:");
                person1.DisplayInfo();
                Console.WriteLine();
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}\n");
            }
            
            try
            {
                var person2 = new PersonPractical("Марія", "Іваненко", 30);
                Console.WriteLine("✅ Створено особу:");
                person2.DisplayInfo();
                Console.WriteLine();
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}\n");
            }
            
            // Невалідний вік (від'ємний)
            try
            {
                var person3 = new PersonPractical("Петро", "Коваленко", -5);
                person3.DisplayInfo();
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"❌ Помилка при створенні особи з віком -5:");
                Console.WriteLine($"   {ex.Message}");
                Console.WriteLine($"   Невалідний вік: {ex.InvalidAge}\n");
            }
            
            // Невалідний вік (більше 120)
            try
            {
                var person4 = new PersonPractical("Олександра", "Сидоренко", 150);
                person4.DisplayInfo();
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine($"❌ Помилка при створенні особи з віком 150:");
                Console.WriteLine($"   {ex.Message}");
                Console.WriteLine($"   Невалідний вік: {ex.InvalidAge}\n");
            }
        }
        
        /// <summary>
        /// Демонстрація завдання 6: Абстрактний клас Document
        /// </summary>
        public static void DemonstrateTask6()
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("ЗАВДАННЯ 6: Абстрактний клас Document з похідними");
            Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
            
            // Створюємо масив об'єктів Document
            Document[] documents = new Document[]
            {
                new Report("RPT-001", DateTime.Now, "Звіт про продажі", 
                          "У першому кварталі продажі зросли на 15%", "Іван Петренко"),
                new Invoice("INV-001", DateTime.Now)
                {
                    CustomerName = "ТОВ 'Компанія'",
                    CustomerAddress = "м. Київ, вул. Хрещатик, 1",
                    Amount = 50000,
                    ItemDescription = "Розробка веб-сайту"
                },
                new Report("RPT-002", DateTime.Now, "Фінансовий звіт", 
                          "Прибуток за рік склав 1 млн грн", "Марія Іваненко"),
                new Invoice("INV-002", DateTime.Now) // невалідний - не встановлені дані
            };
            
            Console.WriteLine("=== Друк документів ===\n");
            foreach (var document in documents)
            {
                try
                {
                    document.Print();
                }
                catch (InvalidDocumentDataException ex)
                {
                    Console.WriteLine($"❌ Помилка друку документа {document.DocumentNumber}:");
                    Console.WriteLine($"   {ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Неочікувана помилка: {ex.Message}\n");
                }
            }
        }
        
        /// <summary>
        /// Запуск всіх демонстрацій
        /// </summary>
        public static void RunAll()
        {
            DemonstrateTask1();
            DemonstrateTask2();
            DemonstrateTask3();
            DemonstrateTask4();
            DemonstrateTask5();
            DemonstrateTask6();
        }
    }
}

