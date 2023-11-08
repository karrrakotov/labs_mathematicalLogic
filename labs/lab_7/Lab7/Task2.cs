using System;
using System.Collections.Generic;

class Lab7t2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите элементы массива через пробел:");
        string input = Console.ReadLine();
        string[] stringArray = input.Split(' ');

        int[] intArray = Array.ConvertAll(stringArray, int.Parse);

        QuickSortWithQueue(intArray, 0, intArray.Length - 1);

        Console.WriteLine("Отсортированный массив:");
        foreach (var item in intArray)
        {
            Console.Write(item + " ");
        }
    }

    static void QuickSortWithQueue(int[] array, int left, int right)
    {
        if (left < right)
        {
            Queue<int> queueLeft = new Queue<int>();
            Queue<int> queueRight = new Queue<int>();

            int pivot = Partition(array, left, right, queueLeft, queueRight);

            if (queueLeft.Count > 1)
            {
                int[] leftArray = new int[queueLeft.Count];
                int i = 0;
                while (queueLeft.Count > 0)
                {
                    leftArray[i] = queueLeft.Dequeue();
                    i++;
                }
                QuickSortWithQueue(leftArray, 0, leftArray.Length - 1);
                Array.Copy(leftArray, 0, array, left, leftArray.Length);
            }

            if (queueRight.Count > 1)
            {
                int[] rightArray = new int[queueRight.Count];
                int j = 0;
                while (queueRight.Count > 0)
                {
                    rightArray[j] = queueRight.Dequeue();
                    j++;
                }
                QuickSortWithQueue(rightArray, 0, rightArray.Length - 1);
                Array.Copy(rightArray, 0, array, pivot + 1, rightArray.Length);
            }
        }
    }

    static int Partition(int[] array, int left, int right, Queue<int> queueLeft, Queue<int> queueRight)
    {
        int pivot = array[left];
        int i = left;
        int j = right;

        while (i < j)
        {
            while (array[j] > pivot)
            {
                queueRight.Enqueue(array[j]);
                j--;
            }

            while (i < j && array[i] <= pivot)
            {
                queueLeft.Enqueue(array[i]);
                i++;
            }

            if (i < j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        array[i] = pivot;

        return i;
    }
}
