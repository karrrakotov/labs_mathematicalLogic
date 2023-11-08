using System;
using System.Collections.Generic;

namespace QueueTasks {
    class Lab6 {
        static void Main(string[] args) {
            // Задание 1
            Queue<int> queue = new Queue<int>();
            Random random = new Random();
            for (int i = 0; i < 10; i++) {
                queue.Enqueue(random.Next(-40, 51));
            }

            int positiveCount = CountPositiveNumbers(queue);
            Console.WriteLine($"Количество положительных чисел в очереди: {positiveCount}");

            // Задание 2
            Console.WriteLine("\nОригинальная очередь:");
            PrintQueue(queue);
            SortQueueBySelection(queue);
            Console.WriteLine("\nОтсортированная очередь:");
            PrintQueue(queue);
        }

        // Функция подсчета положительных чисел в очереди
        static int CountPositiveNumbers(Queue<int> queue) {
            int count = 0;
            foreach (var num in queue) {
                if (num > 0) {
                    count++;
                }
            }
            return count;
        }

        // Задание 2.
        // Функция сортировки выбором для очереди
        static void SortQueueBySelection(Queue<int> queue) {
            List<int> tempList = new List<int>(queue);
            queue.Clear();
            while (tempList.Count > 0) {
                int minIndex = 0;
                for (int i = 1; i < tempList.Count; i++) {
                    if (tempList[i] < tempList[minIndex]) {
                        minIndex = i;
                    }
                }
                queue.Enqueue(tempList[minIndex]);
                tempList.RemoveAt(minIndex);
            }
        }

        // Функция для печати элементов в очереди
        static void PrintQueue(Queue<int> queue) {
            foreach (var item in queue) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
