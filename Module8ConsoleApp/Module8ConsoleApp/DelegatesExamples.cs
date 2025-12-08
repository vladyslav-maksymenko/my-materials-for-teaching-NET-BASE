using System;

namespace Module8ConsoleApp;

/// <summary>
/// Приклади роботи з делегатами
/// </summary>
public static class DelegatesExamples
{
    // 1. Оголошення делегата
    // Делегат - це тип, який визначає сигнатуру методу
    public delegate void SimpleDelegate(string message);
    public delegate int MathOperation(int a, int b);
    public delegate void MultiMethodDelegate();

    /// <summary>
    /// Приклад 1: Базове використання делегата
    /// </summary>
    public static void BasicDelegateExample()
    {
        Console.WriteLine("\n=== Приклад 1: Базове використання делегата ===");
        
        // Створення екземпляра делегата та прив'язка до методу
        SimpleDelegate del = PrintMessage;
        
        // Виклик методу через делегат
        del("Привіт з делегата!");
        
        // Альтернативний синтаксис
        del.Invoke("Виклик через Invoke");
    }

    /// <summary>
    /// Приклад 2: Делегат з параметрами та поверненням значення
    /// </summary>
    public static void DelegateWithReturnValue()
    {
        Console.WriteLine("\n=== Приклад 2: Делегат з поверненням значення ===");
        
        MathOperation add = Add;
        MathOperation multiply = Multiply;
        
        int result1 = add(10, 5);
        int result2 = multiply(10, 5);
        
        Console.WriteLine($"Додавання: {result1}");
        Console.WriteLine($"Множення: {result2}");
    }

    /// <summary>
    /// Приклад 3: Multicast делегат (виклик декількох методів)
    /// </summary>
    public static void MulticastDelegateExample()
    {
        Console.WriteLine("\n=== Приклад 3: Multicast делегат ===");
        
        MultiMethodDelegate multiDel = Method1;
        
        // Додавання методів до делегата
        multiDel += Method2;
        multiDel += Method3;
        
        Console.WriteLine("Виклик всіх методів:");
        multiDel();
        
        // Видалення методу з делегата
        Console.WriteLine("\nПісля видалення Method2:");
        multiDel -= Method2;
        multiDel?.Invoke();
    }

    /// <summary>
    /// Приклад 4: Використання базових класів System.Delegate та System.MulticastDelegate
    /// </summary>
    public static void BaseClassesExample()
    {
        Console.WriteLine("\n=== Приклад 4: Базові класи делегатів ===");
        
        SimpleDelegate del = PrintMessage;
        
        // System.Delegate - базовий клас для всіх делегатів
        Delegate baseDelegate = del;
        Console.WriteLine($"Тип базового делегата: {baseDelegate.GetType()}");
        Console.WriteLine($"Метод: {baseDelegate.Method.Name}");
        Console.WriteLine($"Target: {baseDelegate.Target ?? "null (статичний метод)"}");
        
        // System.MulticastDelegate - базовий клас для multicast делегатів
        if (del is MulticastDelegate multicastDel)
        {
            Delegate[] invocationList = multicastDel.GetInvocationList();
            Console.WriteLine($"Кількість методів у списку виклику: {invocationList.Length}");
        }
    }

    /// <summary>
    /// Приклад 5: Анонімні методи та лямбда-вирази з делегатами
    /// </summary>
    public static void AnonymousMethodsExample()
    {
        Console.WriteLine("\n=== Приклад 5: Анонімні методи та лямбда-вирази ===");
        
        // Анонімний метод
        SimpleDelegate anonymousDel = delegate(string msg)
        {
            Console.WriteLine($"Анонімний метод: {msg}");
        };
        anonymousDel("Тест");
        
        // Лямбда-вираз
        SimpleDelegate lambdaDel = (msg) => Console.WriteLine($"Лямбда: {msg}");
        lambdaDel("Тест");
        
        // Лямбда з делегатом, що повертає значення
        MathOperation lambdaMath = (a, b) => a * b + 10;
        Console.WriteLine($"Результат лямбда-виразу: {lambdaMath(5, 3)}");
    }

    /// <summary>
    /// Приклад 6: Передача делегата як параметра методу
    /// </summary>
    public static void DelegateAsParameter()
    {
        Console.WriteLine("\n=== Приклад 6: Делегат як параметр ===");
        
        ProcessNumbers(10, 5, Add, "Додавання");
        ProcessNumbers(10, 5, Multiply, "Множення");
        ProcessNumbers(10, 5, (a, b) => a - b, "Віднімання");
    }

    // Допоміжні методи
    private static void PrintMessage(string message)
    {
        Console.WriteLine($"Повідомлення: {message}");
    }

    private static int Add(int a, int b) => a + b;
    private static int Multiply(int a, int b) => a * b;

    private static void Method1()
    {
        Console.WriteLine("  Метод 1 виконано");
    }

    private static void Method2()
    {
        Console.WriteLine("  Метод 2 виконано");
    }

    private static void Method3()
    {
        Console.WriteLine("  Метод 3 виконано");
    }

    private static void ProcessNumbers(int a, int b, MathOperation operation, string operationName)
    {
        int result = operation(a, b);
        Console.WriteLine($"{operationName}: {a} і {b} = {result}");
    }
}

