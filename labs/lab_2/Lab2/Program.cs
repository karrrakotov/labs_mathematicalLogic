using System;

class Lab_2
{
    static void Main(string[] args) {
        // Первое задание
        task1(0.01);
        task1(0.001);
        task1(0.0001);


        // Второе задание
        double x1 = 1; // контрольное значение аргумента x
        double x2 = 9; // контрольное значение аргумента x
        double x3 = -11; // контрольное значение аргумента x

        // Первое контрольное значение
        Console.WriteLine($"Для x = {x1}");
        Console.WriteLine($"Результат через ряд: {TaylorSeries(x1)}");
        Console.WriteLine($"Результат через функцию: {FuncY(x1)}");

        // Второе контрольное значение
        Console.WriteLine($"Для x = {x2}");
        Console.WriteLine($"Результат через ряд: {TaylorSeries(x2)}");
        Console.WriteLine($"Результат через функцию: {FuncY(x2)}");

        // Третье контрольное значение
        Console.WriteLine($"Для x = {x3}");
        Console.WriteLine($"Результат через ряд: {TaylorSeries(x3)}");
        Console.WriteLine($"Результат через функцию: {FuncY(x3)}");
    }

    // Задание 1.
    static void task1(double precision) {
        int n = 0;
        double previous = 0;
        double current = 1;
        double next;
        double ratio = 0;
        do {
            next = Fibonacci(n);
            ratio = current / previous;
            previous = current;
            current = next;
            n++;
        } while (Math.Abs(current / previous - ratio) > precision);

        Console.WriteLine($"Предел ряда Фибоначчи с точностью {precision} приблизительно равен {ratio}.");
    }

    static double Fibonacci(int n) {
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;

        double a = 0;
        double b = 1;
        double c = 0;
        for (int i = 2; i <= n; i++) {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }

    // Задание 2.
     // Функция для вычисления суммы ряда
    static double TaylorSeries(double x) {
        double sum = 1.0;
        double term = 1.0;
        double denominator = 1.0;

        for (int i = 1; Math.Abs(term) > 1e-6; i++) {
            term *= x / i;
            denominator *= i;
            sum += term;
        }

        return sum;
    }

    // Функция для вычисления значения функции
    static double FuncY(double x) {
        return (1 + x) * Math.Exp(x);
    }
}
