# Модуль 6. Успадкування в C#

## Зміст
1. [Успадкування в C#](#успадкування-в-c)
2. [Ключове слово sealed](#ключове-слово-sealed)
3. [Використання посилань на базовий клас](#використання-посилань-на-базовий-клас)
4. [Віртуальні методи](#віртуальні-методи)
5. [Абстрактний клас](#абстрактний-клас)
6. [Базовий клас Object](#базовий-клас-object)
7. [Пакування та розпакування (Boxing, Unboxing)](#пакування-та-розпакування-boxing-unboxing)

---

## Успадкування в C#

### Аналіз механізму успадкування

**Успадкування** — це механізм об'єктно-орієнтованого програмування, який дозволяє створювати нові класи на основі існуючих, успадковуючи їх властивості та методи. Клас, від якого успадковується інший клас, називається **базовим класом** (base class) або **батьківським класом** (parent class). Клас, який успадковує, називається **похідним класом** (derived class) або **дочірнім класом** (child class).

**Синтаксис успадкування:**
```csharp
class BaseClass
{
    // члени базового класу
}

class DerivedClass : BaseClass
{
    // члени похідного класу
}
```

**Особливості успадкування в C#:**
- C# підтримує **одинарне успадкування** (single inheritance) — клас може успадковуватися тільки від одного базового класу
- Успадковуються всі публічні та захищені члени базового класу
- Приватні члени базового класу не доступні в похідному класі, але вони все ще існують в об'єкті
- Конструктори не успадковуються, але можуть викликатися через `base`

**Приклад:**
```csharp
class Animal
{
    public string Name { get; set; }
    
    public void Eat()
    {
        Console.WriteLine($"{Name} їсть");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{Name} гавкає");
    }
}

// Використання
Dog dog = new Dog();
dog.Name = "Рекс";
dog.Eat();    // успадкований метод
dog.Bark();   // власний метод
```

### Специфікатори доступу при успадкуванні

При успадкуванні важливо розуміти, як різні специфікатори доступу впливають на доступність членів:

| Специфікатор | Доступність в похідному класі | Доступність ззовні |
|--------------|-------------------------------|-------------------|
| `public` | ✅ Доступний | ✅ Доступний |
| `protected` | ✅ Доступний | ❌ Недоступний |
| `internal` | ✅ Доступний (в межах збірки) | ✅ Доступний (в межах збірки) |
| `protected internal` | ✅ Доступний | ✅ Доступний (в межах збірки) |
| `private` | ❌ Недоступний | ❌ Недоступний |
| `private protected` | ✅ Доступний (в межах збірки) | ❌ Недоступний |

**Приклад:**
```csharp
class BaseClass
{
    public int PublicField = 1;
    protected int ProtectedField = 2;
    private int PrivateField = 3;
    internal int InternalField = 4;
}

class DerivedClass : BaseClass
{
    public void ShowFields()
    {
        Console.WriteLine(PublicField);      // ✅ OK
        Console.WriteLine(ProtectedField);   // ✅ OK
        // Console.WriteLine(PrivateField);   // ❌ Помилка компіляції
        Console.WriteLine(InternalField);    // ✅ OK
    }
}
```

### Особливості використання конструкторів при успадкуванні

**Важливі правила:**
1. Конструктори **не успадковуються** від базового класу
2. При створенні об'єкта похідного класу **спочатку викликається конструктор базового класу**, потім конструктор похідного класу
3. Якщо в базовому класі немає конструктора без параметрів, похідний клас **обов'язково** повинен викликати конструктор базового класу через `base`

**Приклад 1: Базовий клас з конструктором без параметрів**
```csharp
class BaseClass
{
    public BaseClass()
    {
        Console.WriteLine("Конструктор BaseClass");
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass()
    {
        Console.WriteLine("Конструктор DerivedClass");
    }
}

// При створенні DerivedClass виведеться:
// Конструктор BaseClass
// Конструктор DerivedClass
```

**Приклад 2: Базовий клас з конструктором з параметрами**
```csharp
class BaseClass
{
    protected string name;
    
    public BaseClass(string name)
    {
        this.name = name;
        Console.WriteLine($"BaseClass: {name}");
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass(string name) : base(name)
    {
        Console.WriteLine($"DerivedClass: {name}");
    }
}

// Використання
DerivedClass obj = new DerivedClass("Тест");
// Виведеться:
// BaseClass: Тест
// DerivedClass: Тест
```

### Приховування імен при успадкуванні

Якщо в похідному класі визначено член з тим самим ім'ям, що й в базовому класі, то член базового класу **приховується** (hidden). Для явного вказівки на приховування використовується ключове слово `new`.

**Приклад:**
```csharp
class BaseClass
{
    public void Method()
    {
        Console.WriteLine("Метод базового класу");
    }
}

class DerivedClass : BaseClass
{
    // Приховування методу базового класу
    public new void Method()
    {
        Console.WriteLine("Метод похідного класу");
    }
}

// Використання
DerivedClass derived = new DerivedClass();
derived.Method();  // "Метод похідного класу"

BaseClass baseRef = new DerivedClass();
baseRef.Method();  // "Метод базового класу" (викликається метод базового класу)
```

**Важливо:** Приховування відрізняється від перевизначення (override). При приховуванні метод базового класу не перевизначається, а просто приховується новим методом.

### Ключове слово base

Ключове слово `base` використовується для доступу до членів базового класу з похідного класу.

**Використання `base`:**
1. **Виклик конструктора базового класу:**
```csharp
class DerivedClass : BaseClass
{
    public DerivedClass(int x) : base(x)
    {
        // викликається конструктор BaseClass(int x)
    }
}
```

2. **Виклик методу базового класу:**
```csharp
class BaseClass
{
    public virtual void Method()
    {
        Console.WriteLine("Базовий метод");
    }
}

class DerivedClass : BaseClass
{
    public override void Method()
    {
        base.Method();  // виклик методу базового класу
        Console.WriteLine("Додаткова логіка");
    }
}
```

3. **Доступ до полів та властивостей базового класу:**
```csharp
class BaseClass
{
    protected int value = 10;
}

class DerivedClass : BaseClass
{
    public void ShowValue()
    {
        Console.WriteLine(base.value);  // доступ до поля базового класу
    }
}
```

### Успадкування та винятки

При роботі з винятками в контексті успадкування важливо пам'ятати:

1. **Обробка винятків в конструкторах:** Якщо конструктор базового класу викидає виняток, він повинен бути оброблений або в конструкторі похідного класу, або при створенні об'єкта.

2. **Успадкування винятків:** Винятки можуть успадковуватися один від одного, створюючи ієрархію винятків.

**Приклад:**
```csharp
class BaseClass
{
    public BaseClass()
    {
        if (someCondition)
            throw new Exception("Помилка в базовому класі");
    }
}

class DerivedClass : BaseClass
{
    public DerivedClass() : base()  // виняток може виникнути тут
    {
        // код може не виконатися, якщо базовий конструктор викинув виняток
    }
}

// Використання
try
{
    DerivedClass obj = new DerivedClass();
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
}
```

### Успадкування від стандартних класів винятків

У C# всі винятки успадковуються від класу `Exception`. Можна створювати власні класи винятків, успадковуючись від стандартних класів винятків.

**Стандартні класи винятків:**
- `Exception` — базовий клас для всіх винятків
- `SystemException` — для системних винятків
- `ApplicationException` — для винятків додатку (застарілий)
- `ArgumentException` — для некоректних аргументів
- `NullReferenceException` — для посилань на null
- `InvalidOperationException` — для некоректних операцій

**Приклад створення власного винятку:**
```csharp
class CustomException : Exception
{
    public CustomException() : base()
    {
    }
    
    public CustomException(string message) : base(message)
    {
    }
    
    public CustomException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}

// Використання
class MyClass
{
    public void DoSomething()
    {
        throw new CustomException("Щось пішло не так");
    }
}
```

---

## Ключове слово sealed

Ключове слово `sealed` використовується для **заборони успадкування** від класу або **заборони перевизначення** методу.

### Sealed клас

Клас, позначений як `sealed`, не може бути базовим класом для інших класів.

**Синтаксис:**
```csharp
sealed class SealedClass
{
    // члени класу
}

// class DerivedClass : SealedClass  // ❌ Помилка компіляції
```

**Коли використовувати:**
- Коли клас містить критичну логіку, яку не можна змінювати через успадкування
- Для оптимізації продуктивності (компілятор може робити додаткові оптимізації)
- Для забезпечення безпеки та цілісності даних

**Приклад:**
```csharp
sealed class MathHelper
{
    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }
}
```

### Sealed метод

Метод, позначений як `sealed`, не може бути перевизначений в похідних класах. Використовується тільки з `override`.

**Синтаксис:**
```csharp
class BaseClass
{
    public virtual void Method()
    {
        Console.WriteLine("Базовий метод");
    }
}

class DerivedClass : BaseClass
{
    public sealed override void Method()
    {
        Console.WriteLine("Похідний метод (запечатаний)");
    }
}

class ThirdClass : DerivedClass
{
    // public override void Method()  // ❌ Помилка компіляції
}
```

---

## Використання посилань на базовий клас

Посилання на базовий клас дозволяють працювати з об'єктами похідних класів через тип базового класу. Це основа **поліморфізму** в об'єктно-орієнтованому програмуванні.

**Приклад:**
```csharp
class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Тварина видає звук");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Гав-гав!");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Мяу!");
    }
}

// Використання посилань на базовий клас
Animal[] animals = new Animal[]
{
    new Dog(),
    new Cat(),
    new Dog()
};

foreach (Animal animal in animals)
{
    animal.MakeSound();  // поліморфізм: викликається метод конкретного похідного класу
}
```

**Переваги:**
- Можливість працювати з різними похідними класами через один інтерфейс
- Реалізація поліморфізму
- Спрощення коду та підвищення гнучкості

**Важливо:** При використанні посилань на базовий клас доступні тільки члени, визначені в базовому класі. Для доступу до специфічних членів похідного класу потрібно виконати приведення типів або перевірку типу.

```csharp
Animal animal = new Dog();

// animal.Bark();  // ❌ Помилка: метод Bark() не визначений в Animal

if (animal is Dog dog)
{
    dog.Bark();  // ✅ OK: приведення типу
}

// або
Dog dog2 = animal as Dog;
if (dog2 != null)
{
    dog2.Bark();
}
```

---

## Віртуальні методи

### Що таке віртуальний метод

**Віртуальний метод** (virtual method) — це метод базового класу, який може бути **перевизначений** (overridden) в похідних класах. Віртуальні методи дозволяють реалізувати **поліморфізм** — можливість викликати різні реалізації методу залежно від типу об'єкта.

**Синтаксис:**
```csharp
class BaseClass
{
    public virtual void VirtualMethod()
    {
        Console.WriteLine("Віртуальний метод базового класу");
    }
}

class DerivedClass : BaseClass
{
    public override void VirtualMethod()
    {
        Console.WriteLine("Перевизначений метод похідного класу");
    }
}
```

### Необхідність використання віртуальних методів

**Проблема без віртуальних методів:**
```csharp
class Animal
{
    public void MakeSound()  // НЕ віртуальний метод
    {
        Console.WriteLine("Тварина видає звук");
    }
}

class Dog : Animal
{
    public new void MakeSound()  // приховування, не перевизначення
    {
        Console.WriteLine("Гав-гав!");
    }
}

Animal animal = new Dog();
animal.MakeSound();  // "Тварина видає звук" ❌ Неправильно!
```

**Рішення з віртуальними методами:**
```csharp
class Animal
{
    public virtual void MakeSound()  // віртуальний метод
    {
        Console.WriteLine("Тварина видає звук");
    }
}

class Dog : Animal
{
    public override void MakeSound()  // перевизначення
    {
        Console.WriteLine("Гав-гав!");
    }
}

Animal animal = new Dog();
animal.MakeSound();  // "Гав-гав!" ✅ Правильно!
```

**Переваги віртуальних методів:**
- Реалізація поліморфізму
- Правильна робота з посиланнями на базовий клас
- Можливість змінювати поведінку в похідних класах
- Підтримка принципу відкритості/закритості (Open/Closed Principle)

### Перевизначення віртуальних методів

Для перевизначення віртуального методу використовується ключове слово `override`.

**Правила перевизначення:**
1. Метод базового класу повинен бути позначений як `virtual` або `abstract`
2. Метод похідного класу повинен мати модифікатор `override`
3. Сигнатура методу (ім'я, параметри, тип повернення) повинна співпадати
4. Модифікатор доступу не може бути більш обмеженим

**Приклад:**
```csharp
class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
    
    public virtual void Draw()
    {
        Console.WriteLine("Малювання фігури");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }
    
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    
    public override void Draw()
    {
        Console.WriteLine($"Малювання кола з радіусом {Radius}");
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public override double CalculateArea()
    {
        return Width * Height;
    }
    
    public override void Draw()
    {
        Console.WriteLine($"Малювання прямокутника {Width}x{Height}");
    }
}
```

**Виклик базової реалізації:**
```csharp
class DerivedClass : BaseClass
{
    public override void VirtualMethod()
    {
        base.VirtualMethod();  // виклик базової реалізації
        // додаткова логіка
        Console.WriteLine("Додаткова функціональність");
    }
}
```

---

## Абстрактний клас

**Абстрактний клас** (abstract class) — це клас, який не може бути інстанційований (не можна створити об'єкт цього класу). Абстрактні класи використовуються як базові класи для інших класів.

### Особливості абстрактних класів

1. **Не можна створити об'єкт абстрактного класу:**
```csharp
abstract class AbstractClass
{
    // члени класу
}

// AbstractClass obj = new AbstractClass();  // ❌ Помилка компіляції
```

2. **Може містити абстрактні методи** — методи без реалізації, які повинні бути реалізовані в похідних класах:
```csharp
abstract class Animal
{
    public abstract void MakeSound();  // абстрактний метод без реалізації
    
    public void Sleep()  // звичайний метод з реалізацією
    {
        Console.WriteLine("Тварина спить");
    }
}
```

3. **Може містити як абстрактні, так і звичайні члени:**
```csharp
abstract class Shape
{
    // абстрактні члени
    public abstract double CalculateArea();
    public abstract void Draw();
    
    // звичайні члени
    public string Color { get; set; }
    
    public void SetColor(string color)
    {
        Color = color;
    }
}
```

4. **Похідний клас повинен реалізувати всі абстрактні методи:**
```csharp
abstract class Animal
{
    public abstract void MakeSound();
    public abstract void Move();
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Гав-гав!");
    }
    
    public override void Move()
    {
        Console.WriteLine("Собака біжить");
    }
}
```

### Коли використовувати абстрактні класи

- Коли потрібно визначити загальну структуру для групи пов'язаних класів
- Коли деякі методи повинні мати реалізацію, а інші — залишатися абстрактними
- Коли потрібно забезпечити, щоб похідні класи реалізували певні методи

### Порівняння з інтерфейсами

| Абстрактний клас | Інтерфейс |
|------------------|-----------|
| Може містити реалізацію методів | Тільки сигнатури методів (до C# 8.0) |
| Може містити поля | Не може містити поля (до C# 8.0) |
| Підтримує конструктори | Не підтримує конструктори |
| Підтримує модифікатори доступу | Всі члени публічні |
| Одиночне успадкування | Множинне успадкування |

**Приклад використання:**
```csharp
abstract class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }
    
    // абстрактні методи
    public abstract void Start();
    public abstract void Stop();
    
    // звичайний метод
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Марка: {Brand}, Рік: {Year}");
    }
}

class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Автомобіль заводиться");
    }
    
    public override void Stop()
    {
        Console.WriteLine("Автомобіль зупиняється");
    }
}

class Motorcycle : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Мотоцикл заводиться");
    }
    
    public override void Stop()
    {
        Console.WriteLine("Мотоцикл зупиняється");
    }
}
```

---

## Базовий клас Object

У C# всі класи неявно успадковуються від класу `Object` (також доступний як `object`). Це означає, що всі класи мають доступ до методів, визначених в класі `Object`.

### Методи класу Object

**Основні методи:**

1. **`ToString()`** — повертає рядкове представлення об'єкта:
```csharp
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public override string ToString()
    {
        return $"Ім'я: {Name}, Вік: {Age}";
    }
}

Person person = new Person { Name = "Іван", Age = 25 };
Console.WriteLine(person.ToString());  // "Ім'я: Іван, Вік: 25"
```

2. **`Equals(object obj)`** — порівнює об'єкти на рівність:
```csharp
class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Point))
            return false;
        
        Point other = (Point)obj;
        return this.X == other.X && this.Y == other.Y;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
```

3. **`GetHashCode()`** — повертає хеш-код об'єкта (використовується в колекціях):
```csharp
// При перевизначенні Equals() обов'язково перевизначити GetHashCode()
public override int GetHashCode()
{
    return HashCode.Combine(X, Y);
}
```

4. **`GetType()`** — повертає тип об'єкта:
```csharp
object obj = new Person();
Type type = obj.GetType();
Console.WriteLine(type.Name);  // "Person"
```

5. **`ReferenceEquals(object objA, object objB)`** — статичний метод для порівняння посилань:
```csharp
string str1 = "Hello";
string str2 = "Hello";
bool areSame = ReferenceEquals(str1, str2);  // може бути false через інтернування рядків
```

### Перевизначення методів Object

**Рекомендації:**
- Завжди перевизначайте `ToString()` для зручного виведення інформації про об'єкт
- При перевизначенні `Equals()` обов'язково перевизначте `GetHashCode()`
- Дотримуйтесь правил рівності: якщо `a.Equals(b)` повертає `true`, то `a.GetHashCode()` == `b.GetHashCode()`

**Приклад повної реалізації:**
```csharp
class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
    
    public override string ToString()
    {
        return $"Student: {Name} (ID: {Id})";
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Student))
            return false;
        
        Student other = (Student)obj;
        return this.Id == other.Id && this.Name == other.Name;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}
```

---

## Пакування та розпакування (Boxing, Unboxing)

### Пакування (Boxing)

**Пакування** — це процес перетворення значення типу-значення (value type) в об'єкт типу-посилання (reference type) або в інтерфейсний тип, який реалізує цей тип-значення.

**Як відбувається пакування:**
1. Створюється об'єкт в керованій пам'яті (heap)
2. Значення типу-значення копіюється в цей об'єкт
3. Повертається посилання на об'єкт

**Приклад:**
```csharp
int value = 42;           // тип-значення в стеку
object boxed = value;     // пакування: створюється об'єкт в heap
```

**Візуалізація:**
```
До пакування:
┌─────────┐
│ value   │ → 42 (в стеку)
└─────────┘

Після пакування:
┌─────────┐      ┌──────────┐
│ boxed   │ ───→ │  Object  │
└─────────┘      │  (heap)  │
                 │  value:  │
                 │    42    │
                 └──────────┘
```

### Розпакування (Unboxing)

**Розпакування** — це процес перетворення об'єкта типу-посилання назад в тип-значення.

**Як відбувається розпакування:**
1. Перевіряється, що об'єкт є пакуванням потрібного типу
2. Якщо тип не співпадає, викидається `InvalidCastException`
3. Значення копіюється з об'єкта в змінну типу-значення

**Приклад:**
```csharp
object boxed = 42;        // пакування
int unboxed = (int)boxed; // розпакування
```

### Приклади використання

**Приклад 1: Базовий приклад**
```csharp
int number = 100;
object obj = number;      // пакування
int result = (int)obj;    // розпакування
Console.WriteLine(result); // 100
```

**Приклад 2: Пакування в ArrayList (застарілий, але демонструє концепцію)**
```csharp
ArrayList list = new ArrayList();
list.Add(10);    // пакування int в object
list.Add(20);    // пакування int в object
list.Add(30);    // пакування int в object

int first = (int)list[0];  // розпакування
```

**Приклад 3: Помилка при розпакуванні**
```csharp
object obj = 42;
// long value = (long)obj;  // ❌ InvalidCastException - некоректний тип
int value = (int)obj;      // ✅ OK
```

**Приклад 4: Пакування структур**
```csharp
struct Point
{
    public int X, Y;
}

Point p = new Point { X = 10, Y = 20 };
object boxed = p;           // пакування структури
Point unboxed = (Point)boxed; // розпакування
```

### Вплив на продуктивність

**Проблеми пакування/розпакування:**
- **Витрати пам'яті:** Створення об'єктів в heap замість використання стеку
- **Витрати часу:** Додаткові операції копіювання
- **Збільшення навантаження на Garbage Collector**

**Приклад проблеми продуктивності:**
```csharp
// Погано: багато пакувань
for (int i = 0; i < 1000000; i++)
{
    object obj = i;  // пакування на кожній ітерації
}

// Краще: використання узагальнених колекцій
List<int> list = new List<int>();
for (int i = 0; i < 1000000; i++)
{
    list.Add(i);  // без пакування
}
```

### Як уникнути пакування/розпакування

1. **Використовуйте узагальнені колекції (generics):**
```csharp
// Замість ArrayList використовуйте List<T>
List<int> numbers = new List<int>();  // без пакування
```

2. **Використовуйте перевантажені методи:**
```csharp
// Замість object використовуйте конкретні типи
void Process(int value) { }      // без пакування
void Process(object value) { }   // з пакуванням
```

3. **Використовуйте інтерфейси з обмеженнями:**
```csharp
void Process<T>(T value) where T : struct
{
    // T - тип-значення, але без пакування
}
```

### Перевірка наявності пакування

```csharp
int value = 42;
object boxed = value;

// Перевірка типу перед розпакуванням
if (boxed is int intValue)
{
    Console.WriteLine($"Значення: {intValue}");
}

// Або з використанням as (тільки для reference types)
// int? nullableValue = boxed as int?;  // для nullable types
```

---

## Висновок

Успадкування в C# — це потужний механізм, який дозволяє:
- Створювати ієрархії класів
- Перевикористовувати код
- Реалізовувати поліморфізм
- Створювати гнучкі та розширювані архітектури

Розуміння всіх аспектів успадкування, віртуальних методів, абстрактних класів та механізмів пакування/розпакування є критично важливим для ефективного програмування на C#.

---

## Корисні посилання

- [Microsoft Docs: Inheritance (C#)](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [Microsoft Docs: Abstract and Sealed Classes](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract)
- [Microsoft Docs: Boxing and Unboxing](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing)

