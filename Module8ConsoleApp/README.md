# Модуль 8. Делегати, події, записи

## Зміст
1. [Делегати](#делегати)
2. [Події](#події)
3. [Записи (Records)](#записи-records)

---

## Делегати

### Поняття делегата

**Делегат** - це тип, який представляє посилання на метод з певною сигнатурою. Делегат дозволяє зберігати посилання на методи та викликати їх через змінну делегата.

**Аналогія**: Делегат можна порівняти з покажчиком на функцію в C/C++, але з додатковою безпекою типів та можливістю викликати декілька методів одночасно.

### Синтаксис оголошення делегата

```csharp
// Базовий синтаксис
public delegate void MyDelegate(string message);

// Делегат з поверненням значення
public delegate int MathOperation(int a, int b);

// Делегат без параметрів
public delegate void SimpleAction();
```

**Ключові моменти:**
- Ключове слово `delegate`
- Вказується тип повернення та параметри
- Делегат визначає "контракт" для методів, які можуть бути до нього прив'язані

### Цілі та завдання делегатів

1. **Інкапсуляція методів**: Делегат дозволяє передавати методи як параметри
2. **Зворотні виклики (Callbacks)**: Реалізація механізму зворотних викликів
3. **Події**: Основа для реалізації подій в .NET
4. **Гнучкість**: Можливість змінювати поведінку програми під час виконання
5. **Асинхронне програмування**: Використання в асинхронних операціях

**Приклад використання:**
```csharp
public delegate void ProcessHandler(int value);

public void ProcessData(int[] data, ProcessHandler handler)
{
    foreach (int item in data)
    {
        handler(item); // Виклик методу через делегат
    }
}
```

### Виклик декількох методів через делегат (Multicasting)

**Multicast делегат** - це делегат, який містить посилання на декілька методів. При виклику делегата виконуються всі методи в порядку їх додавання.

**Операції:**
- `+=` - додавання методу до делегата
- `-=` - видалення методу з делегата

**Приклад:**
```csharp
public delegate void MultiMethodDelegate();

MultiMethodDelegate multiDel = Method1;
multiDel += Method2;  // Додаємо Method2
multiDel += Method3;  // Додаємо Method3

multiDel(); // Викликаються Method1, Method2, Method3

multiDel -= Method2;  // Видаляємо Method2
multiDel(); // Викликаються тільки Method1, Method3
```

**Важливо:**
- Методи викликаються в порядку додавання
- Якщо делегат повертає значення, повертається значення останнього методу
- Якщо один з методів викидає виняток, наступні методи можуть не виконатися

### Базові класи для делегатів

#### System.Delegate

`System.Delegate` - це абстрактний базовий клас для всіх типів делегатів.

**Основні властивості та методи:**
- `Method` - отримує інформацію про метод
- `Target` - отримує об'єкт, на якому викликається метод (null для статичних методів)
- `GetInvocationList()` - отримує масив делегатів (для multicast)

**Приклад:**
```csharp
SimpleDelegate del = PrintMessage;
Delegate baseDelegate = del;

Console.WriteLine($"Метод: {baseDelegate.Method.Name}");
Console.WriteLine($"Target: {baseDelegate.Target ?? "null"}");
```

#### System.MulticastDelegate

`System.MulticastDelegate` - це клас, який наслідується від `System.Delegate` і додає підтримку multicast функціональності.

**Особливості:**
- Всі делегати в C# автоматично наслідуються від `MulticastDelegate`
- Підтримує виклик декількох методів
- Має внутрішній список викликів (invocation list)

**Приклад:**
```csharp
if (del is MulticastDelegate multicastDel)
{
    Delegate[] invocationList = multicastDel.GetInvocationList();
    Console.WriteLine($"Кількість методів: {invocationList.Length}");
}
```

---

## Події

### Поняття події

**Подія (Event)** - це спеціальний вид делегата, який забезпечує безпечний механізм для реалізації патерну Observer. Події дозволяють об'єктам сповіщати інші об'єкти про зміни стану.

**Відмінності від звичайного делегата:**
- Подію можна викликати тільки всередині класу, де вона оголошена
- Ззовні можна тільки підписуватися (`+=`) та відписуватися (`-=`)
- Забезпечує інкапсуляцію та безпеку

### Синтаксис оголошення події

```csharp
// Базовий синтаксис
public event EventHandler? MyEvent;

// Подія з кастомними параметрами
public event EventHandler<CustomEventArgs>? CustomEvent;

// Подія з власним делегатом
public delegate void TemperatureChangedHandler(object sender, TemperatureEventArgs e);
public event TemperatureChangedHandler? TemperatureChanged;
```

**Ключові моменти:**
- Ключове слово `event`
- Використовується делегат для визначення сигнатури
- Зазвичай використовується `EventHandler` або `EventHandler<T>`

### Необхідність і особливості застосування подій

**Чому використовувати події:**
1. **Інкапсуляція**: Захист від прямого виклику ззовні
2. **Безпека**: Неможливо випадково очистити всіх підписників (`= null`)
3. **Стандартизація**: Узгоджений підхід до реалізації патерну Observer
4. **Зручність**: Простий синтаксис для підписки/відписки

**Особливості:**
- Подію можна викликати тільки всередині класу-видавача
- Ззовні доступні тільки операції `+=` та `-=`
- Підтримує multicast (багатоадресність)

**Приклад:**
```csharp
public class Button
{
    public event EventHandler? Clicked;
    
    public void Click()
    {
        // Виклик події (тільки всередині класу)
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

// Використання
Button button = new();
button.Clicked += OnButtonClicked;  // Підписка
button.Click();  // Виклик події
```

### Застосування події для багатоадресного делегата

Події автоматично підтримують multicast функціональність. Кілька обробників можуть підписатися на одну подію, і всі вони будуть викликані при виникненні події.

**Приклад:**
```csharp
public class TemperatureSensor
{
    public event EventHandler<double>? TemperatureChanged;
    
    public void UpdateTemperature(double temp)
    {
        TemperatureChanged?.Invoke(this, temp);
    }
}

// Використання
TemperatureSensor sensor = new();
sensor.TemperatureChanged += Logger.OnTemperatureChanged;
sensor.TemperatureChanged += Display.UpdateTemperature;
sensor.TemperatureChanged += Alarm.CheckTemperature;

sensor.UpdateTemperature(25.5); // Викликаються всі три обробники
```

**Переваги:**
- Декілька обробників можуть реагувати на одну подію
- Легко додавати/видаляти обробники
- Обробники незалежні один від одного

### Використання подієвих засобів доступу (Event Accessors)

Події можуть мати власні засоби доступу `add` та `remove`, що дозволяє контролювати процес підписки та відписки.

**Синтаксис:**
```csharp
private EventHandler? _myEvent;

public event EventHandler? MyEvent
{
    add
    {
        // Код, який виконується при підписці
        Console.WriteLine("Додавання підписника");
        _myEvent += value;
    }
    remove
    {
        // Код, який виконується при відписці
        Console.WriteLine("Видалення підписника");
        _myEvent -= value;
    }
}
```

**Застосування:**
- Логування підписок/відписок
- Обмеження кількості підписників
- Синхронізація в багатопоточному середовищі
- Додаткова валідація

**Приклад з синхронізацією:**
```csharp
private EventHandler? _threadSafeEvent;
private readonly object _lockObject = new();

public event EventHandler? ThreadSafeEvent
{
    add
    {
        lock (_lockObject)
        {
            _threadSafeEvent += value;
        }
    }
    remove
    {
        lock (_lockObject)
        {
            _threadSafeEvent -= value;
        }
    }
}
```

---

## Записи (Records)

### Поняття запису

**Record** - це новий тип посилання, введений в C# 9.0, який призначений для створення незмінних типів даних з автоматичною реалізацією рівності за значенням.

**Основні характеристики:**
- Порівняння за значенням (value-based equality)
- Автоматична генерація `Equals`, `GetHashCode`, `ToString`
- Підтримка `with` виразів для створення копій
- Підтримка deconstruction

### Синтаксис оголошення запису

**Positional record (короткий синтаксис):**
```csharp
public record Person(string FirstName, string LastName, int Age);
```

**Record class (повний синтаксис):**
```csharp
public record Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
```

### Основні можливості

#### 1. Порівняння за значенням

```csharp
Person person1 = new("Іван", "Петренко", 25);
Person person2 = new("Іван", "Петренко", 25);

Console.WriteLine(person1 == person2); // True (порівняння за значенням)
Console.WriteLine(person1.Equals(person2)); // True
```

#### 2. Вираз `with` для створення копій

```csharp
Person original = new("Іван", "Петренко", 25);
Person modified = original with { Age = 26 }; // Новий об'єкт зі зміненим Age
```

#### 3. Deconstruction

```csharp
Person person = new("Іван", "Петренко", 25);
var (firstName, lastName, age) = person;
```

#### 4. Record struct

```csharp
public record struct Point(int X, int Y);
```

### Застосування

**Коли використовувати records:**
- DTO (Data Transfer Objects)
- Незмінні об'єкти даних
- Value objects
- Конфігураційні об'єкти
- Результати запитів

**Переваги:**
- Менше коду для написання
- Автоматична реалізація рівності
- Незмінність за замовчуванням
- Зручний синтаксис

---

## Структура проєкту

```
Module8ConsoleApp/
├── Program.cs                 - Головний файл з демонстрацією
├── DelegatesExamples.cs      - Приклади роботи з делегатами
├── EventsExamples.cs         - Приклади роботи з подіями
├── RecordsExamples.cs         - Приклади роботи з записами
└── README.md                 - Документація (цей файл)
```

## Запуск проєкту

```bash
dotnet build
dotnet run
```

## Цільовий фреймворк

Проєкт націлений на **.NET 10.0**

---

## Додаткові ресурси

- [Документація Microsoft про делегати](https://docs.microsoft.com/dotnet/csharp/programming-guide/delegates/)
- [Документація Microsoft про події](https://docs.microsoft.com/dotnet/csharp/programming-guide/events/)
- [Документація Microsoft про records](https://docs.microsoft.com/dotnet/csharp/language-reference/builtin-types/record)

