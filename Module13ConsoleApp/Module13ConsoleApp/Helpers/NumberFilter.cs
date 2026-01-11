namespace Module13ConsoleApp.Helpers;

/// <summary>
/// Допоміжний клас для фільтрації чисел (прості числа, числа Фібоначчі)
/// </summary>
public static class NumberFilter
{
    /// <summary>
    /// Перевіряє, чи є число простим
    /// </summary>
    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int sqrt = (int)Math.Sqrt(number);
        for (int i = 3; i <= sqrt; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    /// <summary>
    /// Перевіряє, чи є число числом Фібоначчі
    /// </summary>
    public static bool IsFibonacci(int number)
    {
        // Число є числом Фібоначчі, якщо одне з виразів 5*n^2 + 4 або 5*n^2 - 4 є ідеальним квадратом
        return IsPerfectSquare(5 * number * number + 4) || 
               IsPerfectSquare(5 * number * number - 4);
    }

    /// <summary>
    /// Перевіряє, чи є число ідеальним квадратом
    /// </summary>
    private static bool IsPerfectSquare(int number)
    {
        int sqrt = (int)Math.Sqrt(number);
        return sqrt * sqrt == number;
    }

    /// <summary>
    /// Фільтрує масив, видаляючи прості числа
    /// </summary>
    public static int[] FilterOutPrimes(int[] numbers)
    {
        return numbers.Where(n => !IsPrime(n)).ToArray();
    }

    /// <summary>
    /// Фільтрує масив, видаляючи числа Фібоначчі
    /// </summary>
    public static int[] FilterOutFibonacci(int[] numbers)
    {
        return numbers.Where(n => !IsFibonacci(n)).ToArray();
    }
}

