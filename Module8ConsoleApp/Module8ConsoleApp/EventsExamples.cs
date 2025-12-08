using System;

namespace Module8ConsoleApp;

/// <summary>
/// Приклади роботи з подіями
/// </summary>
public class EventsExamples
{
    // 1. Оголошення події
    // Подія - це спеціальний вид делегата, який дозволяє безпечно підписуватися та відписуватися від подій
    
    // Базовий варіант оголошення події
    public event EventHandler? SimpleEvent;
    
    // Подія з кастомними параметрами
    public event EventHandler<CustomEventArgs>? CustomEvent;
    
    // Подія з власним делегатом
    public delegate void TemperatureChangedHandler(object sender, TemperatureEventArgs e);
    public event TemperatureChangedHandler? TemperatureChanged;

    // 2. Використання event accessors (add/remove)
    private EventHandler? _customAccessorEvent;
    public event EventHandler? CustomAccessorEvent
    {
        add
        {
            Console.WriteLine("  [Event Accessor] Додавання підписника");
            _customAccessorEvent += value;
        }
        remove
        {
            Console.WriteLine("  [Event Accessor] Видалення підписника");
            _customAccessorEvent -= value;
        }
    }

    /// <summary>
    /// Приклад 1: Базове використання події
    /// </summary>
    public static void BasicEventExample()
    {
        Console.WriteLine("\n=== Приклад 1: Базове використання події ===");
        
        EventsExamples publisher = new();
        
        // Підписка на подію
        publisher.SimpleEvent += OnSimpleEvent;
        publisher.SimpleEvent += OnSimpleEvent2;
        
        // Виклик події (тільки всередині класу)
        publisher.RaiseSimpleEvent();
        
        // Відписка від події
        publisher.SimpleEvent -= OnSimpleEvent;
        publisher.RaiseSimpleEvent();
    }

    /// <summary>
    /// Приклад 2: Подія з кастомними параметрами
    /// </summary>
    public static void CustomEventArgsExample()
    {
        Console.WriteLine("\n=== Приклад 2: Подія з кастомними параметрами ===");
        
        EventsExamples publisher = new();
        
        publisher.CustomEvent += OnCustomEvent;
        publisher.RaiseCustomEvent("Важливе повідомлення", DateTime.Now);
    }

    /// <summary>
    /// Приклад 3: Подія для multicast делегата
    /// </summary>
    public static void MulticastEventExample()
    {
        Console.WriteLine("\n=== Приклад 3: Подія для multicast делегата ===");
        
        EventsExamples publisher = new();
        
        // Підписка декількох обробників
        publisher.TemperatureChanged += OnTemperatureChanged1;
        publisher.TemperatureChanged += OnTemperatureChanged2;
        publisher.TemperatureChanged += OnTemperatureChanged3;
        
        // Виклик події викличе всі підписані обробники
        publisher.RaiseTemperatureChanged(25.5);
        
        Console.WriteLine("\nПісля видалення одного обробника:");
        publisher.TemperatureChanged -= OnTemperatureChanged2;
        publisher.RaiseTemperatureChanged(30.0);
    }

    /// <summary>
    /// Приклад 4: Використання event accessors
    /// </summary>
    public static void EventAccessorsExample()
    {
        Console.WriteLine("\n=== Приклад 4: Event Accessors (add/remove) ===");
        
        EventsExamples publisher = new();
        
        publisher.CustomAccessorEvent += OnCustomAccessorEvent1;
        publisher.CustomAccessorEvent += OnCustomAccessorEvent2;
        
        publisher.RaiseCustomAccessorEvent();
        
        publisher.CustomAccessorEvent -= OnCustomAccessorEvent1;
        publisher.RaiseCustomAccessorEvent();
    }

    /// <summary>
    /// Приклад 5: Практичний приклад - система сповіщень
    /// </summary>
    public static void NotificationSystemExample()
    {
        Console.WriteLine("\n=== Приклад 5: Система сповіщень ===");
        
        NotificationService service = new();
        User user1 = new("Іван");
        User user2 = new("Марія");
        
        // Підписка користувачів на події
        service.MessageReceived += user1.OnMessageReceived;
        service.MessageReceived += user2.OnMessageReceived;
        
        // Відправка повідомлень
        service.SendMessage("Ласкаво просимо до системи!");
        service.SendMessage("Нове оновлення доступне");
        
        // Відписка одного користувача
        service.MessageReceived -= user1.OnMessageReceived;
        service.SendMessage("Це повідомлення побачить тільки Марія");
    }

    // Методи для виклику подій (тільки всередині класу)
    private void RaiseSimpleEvent()
    {
        SimpleEvent?.Invoke(this, EventArgs.Empty);
    }

    private void RaiseCustomEvent(string message, DateTime time)
    {
        CustomEvent?.Invoke(this, new CustomEventArgs(message, time));
    }

    private void RaiseTemperatureChanged(double temperature)
    {
        TemperatureChanged?.Invoke(this, new TemperatureEventArgs(temperature));
    }

    private void RaiseCustomAccessorEvent()
    {
        _customAccessorEvent?.Invoke(this, EventArgs.Empty);
    }

    // Обробники подій
    private static void OnSimpleEvent(object? sender, EventArgs e)
    {
        Console.WriteLine("  Обробник 1: Проста подія викликана");
    }

    private static void OnSimpleEvent2(object? sender, EventArgs e)
    {
        Console.WriteLine("  Обробник 2: Проста подія викликана");
    }

    private static void OnCustomEvent(object? sender, CustomEventArgs e)
    {
        Console.WriteLine($"  Отримано повідомлення: '{e.Message}' в {e.Time:HH:mm:ss}");
    }

    private static void OnTemperatureChanged1(object? sender, TemperatureEventArgs e)
    {
        Console.WriteLine($"  Датчик 1: Температура = {e.Temperature}°C");
    }

    private static void OnTemperatureChanged2(object? sender, TemperatureEventArgs e)
    {
        Console.WriteLine($"  Датчик 2: Температура = {e.Temperature}°C");
    }

    private static void OnTemperatureChanged3(object? sender, TemperatureEventArgs e)
    {
        Console.WriteLine($"  Датчик 3: Температура = {e.Temperature}°C");
    }

    private static void OnCustomAccessorEvent1(object? sender, EventArgs e)
    {
        Console.WriteLine("  Обробник CustomAccessorEvent 1");
    }

    private static void OnCustomAccessorEvent2(object? sender, EventArgs e)
    {
        Console.WriteLine("  Обробник CustomAccessorEvent 2");
    }
}

// Класи для аргументів подій
public class CustomEventArgs : EventArgs
{
    public string Message { get; }
    public DateTime Time { get; }

    public CustomEventArgs(string message, DateTime time)
    {
        Message = message;
        Time = time;
    }
}

public class TemperatureEventArgs : EventArgs
{
    public double Temperature { get; }

    public TemperatureEventArgs(double temperature)
    {
        Temperature = temperature;
    }
}

// Практичний приклад: Система сповіщень
public class NotificationService
{
    public event EventHandler<string>? MessageReceived;

    public void SendMessage(string message)
    {
        Console.WriteLine($"\n[Сервіс] Відправка повідомлення: {message}");
        MessageReceived?.Invoke(this, message);
    }
}

public class User
{
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void OnMessageReceived(object? sender, string message)
    {
        Console.WriteLine($"  [{Name}] Отримав повідомлення: {message}");
    }
}

