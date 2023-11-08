using System;

class Lab9 {
    static void Main(string[] args) {
        // Задание 1: Процедура сортировки массива методом простого выбора
        int[] testArray1 = { 64, 25, 12, 22, 11 };
        int[] testArray2 = { 38, 27, 43, 3, 9, 82, 10 };

        Console.WriteLine("Пример сортировки массива методом простого выбора:");

        Console.Write("Исходный массив 1: ");
        PrintArray(testArray1);
        SelectionSort(testArray1);
        Console.Write("Отсортированный массив 1: ");
        PrintArray(testArray1);

        Console.Write("Исходный массив 2: ");
        PrintArray(testArray2);
        SelectionSort(testArray2);
        Console.Write("Отсортированный массив 2: ");
        PrintArray(testArray2);

        Console.WriteLine();

        // Задание 2: Рекурсивный факториал
        Console.WriteLine("Введите число для вычисления факториала:");
        int number = Convert.ToInt32(Console.ReadLine());

        long result = Factorial(number);

        Console.WriteLine($"Факториал числа {number} равен {result}");

        Console.WriteLine();

        // Задание 3: Рекурсивный алгоритм Фибоначчи
        Console.WriteLine("Введите количество элементов последовательности Фибоначчи:");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Последовательность Фибоначчи:");
        for (int i = 0; i < count; i++) {
            Console.Write(Fibonacci(i) + " ");
        }

        Console.WriteLine();

        // Задание 4: Решение головоломки "Ханойская башня"
        int n = 3; // Количество дисков
        SolveHanoi(n, 'A', 'C', 'B');
    }

    // Задание 1: Процедура сортировки массива методом простого выбора
    static void SelectionSort(int[] arr) {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++) {
            int minIndex = i;
            for (int j = i + 1; j < n; j++) {
                if (arr[j] < arr[minIndex]) {
                    minIndex = j;
                }
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void PrintArray(int[] arr) {
        foreach (var item in arr) {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Задание 2: Рекурсивный факториал
    static long Factorial(int n) {
        if (n == 0)
            return 1;
        else
            return n * Factorial(n - 1);
    }

    // Задание 3: Рекурсивный алгоритм Фибоначчи
    static int Fibonacci(int n) {
        if (n <= 1)
            return n;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // Задание 4: Решение головоломки "Ханойская башня"
    static void SolveHanoi(int n, char from_rod, char to_rod, char aux_rod) {
        if (n == 1) {
            Console.WriteLine("Переместить диск 1 с колышка " + from_rod + " на колышек " + to_rod);
            return;
        }
        SolveHanoi(n - 1, from_rod, aux_rod, to_rod);
        Console.WriteLine("Переместить диск " + n + " с колышка " + from_rod + " на колышек " + to_rod);
        SolveHanoi(n - 1, aux_rod, to_rod, from_rod);
    }
}
