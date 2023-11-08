using System;
using System.Diagnostics;

class Lab7t1 {
    static void Main(string[] args) {
        Console.WriteLine("Выберите тип элементов массива: \n1. Целый \n2. Строковый");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice) {
            case 1:
                // Пример массива с целыми числами
                int[] intArray = { 5, 2, 7, 3, 9, 1, 4, 6, 8 };
                TestSortingMethods(intArray);
                break;
            case 2:
                // Пример массива со строками
                string[] stringArray = { "banana", "cherry", "apple", "date", "grape", "fig" };
                TestSortingMethods(stringArray);
                break;
            default:
                Console.WriteLine("Выбран неверный вариант. Попробуйте еще раз.");
                break;
        }
    }

    static void TestSortingMethods<T>(T[] array) where T : IComparable {
        // Сортировка обменами
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        BubbleSort(array);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки обменами: {stopwatch.Elapsed}");

        // Сортировка выбором
        stopwatch.Restart();
        SelectionSort(array);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки выбором: {stopwatch.Elapsed}");

        // Сортировка включением
        stopwatch.Restart();
        InsertionSort(array);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения сортировки включением: {stopwatch.Elapsed}");

        // Быстрая сортировка
        stopwatch.Restart();
        QuickSort(array, 0, array.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Время выполнения быстрой сортировки: {stopwatch.Elapsed}");
    }

    static void BubbleSort<T>(T[] array) where T : IComparable {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - i - 1; j++) {
                if (array[j].CompareTo(array[j + 1]) > 0) {
                    T temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static void SelectionSort<T>(T[] array) where T : IComparable {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++) {
            int minIndex = i;
            for (int j = i + 1; j < n; j++) {
                if (array[j].CompareTo(array[minIndex]) < 0) {
                    minIndex = j;
                }
            }
            T temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }

    static void InsertionSort<T>(T[] array) where T : IComparable {
        int n = array.Length;
        for (int i = 1; i < n; ++i) {
            T key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].CompareTo(key) > 0) {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }

    static void QuickSort<T>(T[] array, int low, int high) where T : IComparable {
        if (low < high) {
            int pi = Partition(array, low, high);

            QuickSort(array, low, pi - 1);
            QuickSort(array, pi + 1, high);
        }
    }

    static int Partition<T>(T[] array, int low, int high) where T : IComparable {
        T pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++) {
            if (array[j].CompareTo(pivot) < 0) {
                i++;
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        T temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }
}
