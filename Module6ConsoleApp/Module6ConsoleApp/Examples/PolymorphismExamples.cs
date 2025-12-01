using System;
using System.Collections.Generic;

namespace Module6ConsoleApp.Examples
{
    // ============================================
    // ПРАКТИЧНІ ПРИКЛАДИ: ПОСИЛАННЯ НА БАЗОВИЙ КЛАС
    // ============================================
    // Теорія: README.md - розділ "Використання посилань на базовий клас"
    // Демонструє:
    // - Поліморфізм через посилання на базовий клас
    // - Роботу з масивами та списками базового класу
    // - Приведення типів (is, as, явне приведення)
    // - Доступ до специфічних методів похідних класів
    // ============================================
    
    // ============================================
    // ПРИКЛАД: Використання посилань на базовий клас (Поліморфізм)
    // ============================================
    
    public class PolymorphismDemo
    {
        // Метод, який працює з базовим класом
        public static void ProcessAnimal(Animal animal)
        {
            Console.WriteLine($"Обробка тварини: {animal.Name}");
            animal.MakeSound();
            animal.Move();
            Console.WriteLine();
        }
        
        // Метод, який працює з масивом базового класу
        public static void ProcessAnimals(Animal[] animals)
        {
            Console.WriteLine("=== Обробка масиву тварин ===");
            foreach (Animal animal in animals)
            {
                ProcessAnimal(animal);
            }
        }
        
        // Метод, який працює зі списком базового класу
        public static void ProcessAnimalList(List<Animal> animals)
        {
            Console.WriteLine("=== Обробка списку тварин ===");
            foreach (Animal animal in animals)
            {
                ProcessAnimal(animal);
            }
        }
    }
    
    // Примітка: Класи Animal, Dog, Cat, Bird визначені в AbstractClasses.cs
    // Тут використовуємо їх для демонстрації поліморфізму
    
    // ============================================
    // ПРИКЛАД: Приведення типів
    // ============================================
    
    public class TypeCastingDemo
    {
        public static void DemonstrateCasting()
        {
            Console.WriteLine("=== Демонстрація приведення типів ===");
            
            // Створення об'єктів через посилання на базовий клас
            Animal animal1 = new Dog("Рекс", 3);
            Animal animal2 = new Cat("Мурка", 2);
            Animal animal3 = new Bird("Чижик", 1);
            
            // Виклик віртуальних методів (поліморфізм)
            animal1.MakeSound(); // викликається Dog.MakeSound()
            animal2.MakeSound(); // викликається Cat.MakeSound()
            animal3.MakeSound(); // викликається Bird.MakeSound()
            
            // Спроба викликати специфічний метод - помилка
            // animal1.Fetch(); //  Помилка компіляції - метод Fetch() не існує в Animal
            
            // Приведення типу через is
            if (animal1 is Dog dog)
            {
                // dog.Fetch(); // ✅ OK - якщо б метод існував
                Console.WriteLine($"Собака {dog.Name} готова до виконання команд");
            }
            
            // Приведення типу через as
            Dog? dog2 = animal1 as Dog;
            if (dog2 != null)
            {
                Console.WriteLine($"Собака {dog2.Name} знайдена через as");
            }
            
            // Перевірка типу
            if (animal2 is Cat)
            {
                Cat cat = (Cat)animal2; // явне приведення
                Console.WriteLine($"Кіт {cat.Name} готовий до лазання");
            }
        }
    }
}

