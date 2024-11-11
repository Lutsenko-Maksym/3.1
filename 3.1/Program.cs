using System;
using System.Linq;

class ExtendedNumberProcessing
{
    static void Main()
    {
        // Введення 10 чисел від користувача та збереження їх у масиві
        double[] numbers = new double[10];
        Console.WriteLine("Введіть 10 чисел:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Число {i + 1}: ");
            while (!double.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.WriteLine("Некоректний ввід. Спробуйте знову.");
                Console.Write($"Число {i + 1}: ");
            }
        }

        // Виклик методів для обробки чисел
        DisplayNumbersInReverse(numbers);
        Console.WriteLine($"Сума чисел: {CalculateSum(numbers)}");
        Console.WriteLine($"Середнє значення: {CalculateAverage(numbers):F2}");
        Console.WriteLine($"Медіана: {CalculateMedian(numbers):F2}");
        Console.WriteLine($"Мінімальне значення: {numbers.Min()}");
        Console.WriteLine($"Максимальне значення: {numbers.Max()}");
        Console.WriteLine($"Кількість чисел, більших за середнє: {CountAboveAverage(numbers)}");

        // Арифметичні операції між першим і другим числом
        Console.WriteLine($"\nРезультати арифметичних операцій між першим ({numbers[0]}) та другим ({numbers[1]}) числом:");
        Console.WriteLine($"Додавання: {Add(numbers[0], numbers[1])}");
        Console.WriteLine($"Віднімання: {Subtract(numbers[0], numbers[1])}");
        Console.WriteLine($"Множення: {Multiply(numbers[0], numbers[1])}");
        Console.WriteLine($"Ділення: {Divide(numbers[0], numbers[1])}");

        // Сортування масиву і обчислення різниці між максимальним та мінімальним значенням
        SortArray(numbers);
        Console.WriteLine("\nВідсортований масив:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine($"\nРізниця між максимальним і мінімальним значенням: {numbers.Max() - numbers.Min()}");
    }

    // Метод для виведення чисел у зворотному порядку
    static void DisplayNumbersInReverse(double[] numbers)
    {
        Console.WriteLine("\nЧисла у зворотному порядку:");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }

    // Метод для обчислення суми чисел
    static double CalculateSum(double[] numbers)
    {
        double sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    // Метод для обчислення середнього значення чисел
    static double CalculateAverage(double[] numbers)
    {
        return CalculateSum(numbers) / numbers.Length;
    }

    // Метод для обчислення медіани чисел
    static double CalculateMedian(double[] numbers)
    {
        double[] sortedNumbers = (double[])numbers.Clone();
        Array.Sort(sortedNumbers);
        int mid = sortedNumbers.Length / 2;

        if (sortedNumbers.Length % 2 == 0)
        {
            return (sortedNumbers[mid - 1] + sortedNumbers[mid]) / 2;
        }
        else
        {
            return sortedNumbers[mid];
        }
    }

    // Метод для підрахунку чисел, що більші за середнє значення
    static int CountAboveAverage(double[] numbers)
    {
        double average = CalculateAverage(numbers);
        int count = 0;
        foreach (var num in numbers)
        {
            if (num > average)
            {
                count++;
            }
        }
        return count;
    }

    // Методи для арифметичних операцій між двома числами
    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;

    // Метод для ділення двох чисел з перевіркою на ділення на нуль
    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль.");
            return double.NaN;
        }
        return a / b;
    }

    // Метод для сортування масиву у порядку зростання
    static void SortArray(double[] numbers)
    {
        Array.Sort(numbers);
    }
}