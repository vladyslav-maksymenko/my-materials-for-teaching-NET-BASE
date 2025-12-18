using System;
using System.Diagnostics;
using System.IO;

namespace Module10ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Модуль 10. Збирання сміття в .NET ===\n");

        // Приклад 1: Життєвий цикл об'єкта та покоління
        DemonstrateObjectLifecycle();

        // Приклад 2: Моніторинг пам'яті
        DemonstrateMemoryMonitoring();

        // Приклад 3: IDisposable та using
        DemonstrateDisposePattern();

        // Приклад 4: Деструктор vs Dispose
        DemonstrateFinalizerVsDispose();

        // Приклад 5: Робота з System.GC
        DemonstrateGCClass();

        // Приклад 6: Покоління об'єктів
        DemonstrateGenerations();

        // Приклад 7: IAsyncDisposable (сучасний підхід)
        await DemonstrateAsyncDispose();

        Console.WriteLine("\n=== Всі приклади виконано ===");
        Console.ReadKey();
    }

    /// <summary>
    /// Демонстрація життєвого циклу об'єкта та відстеження поколінь
    /// </summary>
    static void DemonstrateObjectLifecycle()
    {
        Console.WriteLine("--- Приклад 1: Життєвий цикл об'єкта ---");
        
        // Створення об'єкта - він потрапляє в Gen 0
        var obj = new SimpleClass("Об'єкт 1");
        Console.WriteLine($"Об'єкт створено. Покоління: {GC.GetGeneration(obj)}");

        // Об'єкт використовується
        obj.DoSomething();

        // Після збірки Gen 0, об'єкт переходить в Gen 1
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"Після збірки Gen 0. Покоління: {GC.GetGeneration(obj)}");

        // Після збірки Gen 1, об'єкт переходить в Gen 2
        GC.Collect(1, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"Після збірки Gen 1. Покоління: {GC.GetGeneration(obj)}");

        // Втрата посилання
        obj = null;
        Console.WriteLine("Посилання втрачено. Об'єкт стане кандидатом на видалення.\n");
    }

    /// <summary>
    /// Демонстрація моніторингу використання пам'яті
    /// </summary>
    static void DemonstrateMemoryMonitoring()
    {
        Console.WriteLine("--- Приклад 2: Моніторинг пам'яті ---");

        // Пам'ять до створення об'єктів
        GC.Collect();
        long memoryBefore = GC.GetTotalMemory(false);
        Console.WriteLine($"Пам'ять до створення об'єктів: {memoryBefore / 1024.0:F2} KB");

        // Створення багатьох об'єктів
        var objects = new List<SimpleClass>();
        for (int i = 0; i < 10000; i++)
        {
            objects.Add(new SimpleClass($"Об'єкт {i}"));
        }

        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine($"Пам'ять після створення 10000 об'єктів: {memoryAfter / 1024.0:F2} KB");
        Console.WriteLine($"Різниця: {(memoryAfter - memoryBefore) / 1024.0:F2} KB");

        // Звільнення посилань
        objects.Clear();
        objects = null;

        // Збірка сміття
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoryAfterGC = GC.GetTotalMemory(false);
        Console.WriteLine($"Пам'ять після збірки сміття: {memoryAfterGC / 1024.0:F2} KB");
        Console.WriteLine($"Звільнено: {(memoryAfter - memoryAfterGC) / 1024.0:F2} KB\n");
    }

    /// <summary>
    /// Демонстрація паттерну IDisposable та using statement
    /// </summary>
    static void DemonstrateDisposePattern()
    {
        Console.WriteLine("--- Приклад 3: IDisposable та using ---");

        // Використання using statement (класичний синтаксис)
        Console.WriteLine("Використання using (класичний синтаксис):");
        using (var resource = new FileResource("test1.txt"))
        {
            resource.WriteData("Дані для тесту 1");
            Console.WriteLine("  Ресурс використовується...");
        } // Dispose викликається автоматично тут
        Console.WriteLine("  Ресурс звільнено (Dispose викликано)\n");

        // Використання using declaration (C# 8.0+)
        Console.WriteLine("Використання using declaration (C# 8.0+):");
        using var resource2 = new FileResource("test2.txt");
        resource2.WriteData("Дані для тесту 2");
        Console.WriteLine("  Ресурс використовується...");
        // Dispose викликається в кінці області видимості
        Console.WriteLine("  Ресурс буде звільнено в кінці методу\n");
    }

    /// <summary>
    /// Демонстрація різниці між деструктором та Dispose
    /// </summary>
    static void DemonstrateFinalizerVsDispose()
    {
        Console.WriteLine("--- Приклад 4: Деструктор vs Dispose ---");

        // Об'єкт з деструктором (без Dispose)
        Console.WriteLine("Створення об'єкта з деструктором:");
        var objWithFinalizer = new ClassWithFinalizer("Об'єкт з деструктором");
        objWithFinalizer.DoSomething();
        objWithFinalizer = null;

        Console.WriteLine("  Об'єкт втратив посилання, але деструктор ще не викликано");
        Console.WriteLine("  Виконуємо збірку сміття...");
        
        GC.Collect();
        GC.WaitForPendingFinalizers(); // Чекаємо виконання деструктора
        GC.Collect(); // Повторна збірка після фіналізації
        
        Console.WriteLine("  Деструктор виконано\n");

        // Об'єкт з Dispose
        Console.WriteLine("Створення об'єкта з Dispose:");
        using (var objWithDispose = new ClassWithDispose("Об'єкт з Dispose"))
        {
            objWithDispose.DoSomething();
        } // Dispose викликається миттєво
        Console.WriteLine("  Dispose викликано миттєво\n");
    }

    /// <summary>
    /// Демонстрація роботи з класом System.GC
    /// </summary>
    static void DemonstrateGCClass()
    {
        Console.WriteLine("--- Приклад 5: Робота з System.GC ---");

        // Отримання інформації про GC
        Console.WriteLine($"Максимальне покоління: {GC.MaxGeneration}");
        Console.WriteLine($"Загальна пам'ять: {GC.GetTotalMemory(false) / 1024.0:F2} KB");

        // Створення об'єктів різних поколінь
        var obj1 = new SimpleClass("Об'єкт 1");
        Console.WriteLine($"Об'єкт 1 - Покоління: {GC.GetGeneration(obj1)}");

        GC.Collect(0);
        var obj2 = new SimpleClass("Об'єкт 2");
        Console.WriteLine($"Об'єкт 2 (після збірки Gen 0) - Покоління: {GC.GetGeneration(obj2)}");
        Console.WriteLine($"Об'єкт 1 (після збірки Gen 0) - Покоління: {GC.GetGeneration(obj1)}");

        // Перевірка, чи потрібна збірка сміття
        Console.WriteLine($"Потрібна збірка Gen 0: {GC.CollectionCount(0)} разів");
        Console.WriteLine($"Потрібна збірка Gen 1: {GC.CollectionCount(1)} разів");
        Console.WriteLine($"Потрібна збірка Gen 2: {GC.CollectionCount(2)} разів\n");
    }

    /// <summary>
    /// Демонстрація роботи поколінь об'єктів
    /// </summary>
    static void DemonstrateGenerations()
    {
        Console.WriteLine("--- Приклад 6: Покоління об'єктів ---");

        // Створення об'єктів
        var objects = new List<SimpleClass>();
        for (int i = 0; i < 5; i++)
        {
            objects.Add(new SimpleClass($"Об'єкт {i + 1}"));
        }

        Console.WriteLine("Початкові покоління об'єктів:");
        for (int i = 0; i < objects.Count; i++)
        {
            Console.WriteLine($"  {objects[i].Name}: Gen {GC.GetGeneration(objects[i])}");
        }

        // Збірка Gen 0
        Console.WriteLine("\nВиконуємо збірку Gen 0...");
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Покоління після збірки Gen 0:");
        for (int i = 0; i < objects.Count; i++)
        {
            Console.WriteLine($"  {objects[i].Name}: Gen {GC.GetGeneration(objects[i])}");
        }

        // Збірка Gen 1
        Console.WriteLine("\nВиконуємо збірку Gen 1...");
        GC.Collect(1, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Покоління після збірки Gen 1:");
        for (int i = 0; i < objects.Count; i++)
        {
            Console.WriteLine($"  {objects[i].Name}: Gen {GC.GetGeneration(objects[i])}");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Демонстрація IAsyncDisposable (C# 8.0+, .NET Core 3.0+)
    /// </summary>
    static async Task DemonstrateAsyncDispose()
    {
        Console.WriteLine("--- Приклад 7: IAsyncDisposable (сучасний підхід) ---");

        // Використання await using для асинхронного очищення
        await using (var asyncResource = new AsyncResource("async-resource.txt"))
        {
            await asyncResource.WriteDataAsync("Асинхронні дані");
            Console.WriteLine("  Асинхронний ресурс використовується...");
        } // DisposeAsync викликається автоматично тут
        Console.WriteLine("  Асинхронний ресурс звільнено (DisposeAsync викликано)\n");
    }
}

/// <summary>
/// Простий клас для демонстрації життєвого циклу
/// </summary>
class SimpleClass
{
    public string Name { get; }

    public SimpleClass(string name)
    {
        Name = name;
    }

    public void DoSomething()
    {
        Console.WriteLine($"  {Name} виконує дію");
    }
}

/// <summary>
/// Клас з реалізацією IDisposable (правильний паттерн)
/// </summary>
class FileResource : IDisposable
{
    private string _fileName;
    private bool _disposed = false;
    private StreamWriter? _writer;

    public FileResource(string fileName)
    {
        _fileName = fileName;
        _writer = new StreamWriter(fileName);
        Console.WriteLine($"  Файловий ресурс '{fileName}' створено");
    }

    public void WriteData(string data)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(FileResource));

        _writer?.WriteLine(data);
        Console.WriteLine($"  Дані записано в '{_fileName}': {data}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // Не викликати деструктор
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Звільнення управляних ресурсів
                _writer?.Dispose();
                _writer = null;
                Console.WriteLine($"  Управляні ресурси звільнено для '{_fileName}'");
            }
            // Тут можна звільнити неуправляні ресурси
            _disposed = true;
        }
    }
}

/// <summary>
/// Клас з деструктором (finalizer)
/// </summary>
class ClassWithFinalizer
{
    private string _name;

    public ClassWithFinalizer(string name)
    {
        _name = name;
        Console.WriteLine($"  Об'єкт '{_name}' створено");
    }

    public void DoSomething()
    {
        Console.WriteLine($"  Об'єкт '{_name}' виконує дію");
    }

    // Деструктор (finalizer)
    ~ClassWithFinalizer()
    {
        Console.WriteLine($"  Деструктор викликано для '{_name}'");
        // Звільнення неуправляних ресурсів
    }
}

/// <summary>
/// Клас з реалізацією IDisposable (без деструктора)
/// </summary>
class ClassWithDispose : IDisposable
{
    private string _name;
    private bool _disposed = false;

    public ClassWithDispose(string name)
    {
        _name = name;
        Console.WriteLine($"  Об'єкт '{_name}' створено");
    }

    public void DoSomething()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(ClassWithDispose));

        Console.WriteLine($"  Об'єкт '{_name}' виконує дію");
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            Console.WriteLine($"  Dispose викликано для '{_name}'");
            // Звільнення ресурсів
            _disposed = true;
        }
    }
}

/// <summary>
/// Клас з реалізацією IAsyncDisposable (для асинхронного очищення ресурсів)
/// </summary>
class AsyncResource : IAsyncDisposable
{
    private string _fileName;
    private StreamWriter? _writer;
    private bool _disposed = false;

    public AsyncResource(string fileName)
    {
        _fileName = fileName;
        _writer = new StreamWriter(fileName);
        Console.WriteLine($"  Асинхронний ресурс '{fileName}' створено");
    }

    public async Task WriteDataAsync(string data)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(AsyncResource));

        if (_writer != null)
        {
            await _writer.WriteLineAsync(data);
            Console.WriteLine($"  Дані асинхронно записано в '{_fileName}': {data}");
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_disposed)
        {
            if (_writer != null)
            {
                await _writer.DisposeAsync();
                _writer = null;
                Console.WriteLine($"  Асинхронні ресурси звільнено для '{_fileName}'");
            }
            _disposed = true;
        }
    }
}
