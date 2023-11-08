using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Lab8
{
    static void Main(string[] args)
    {
        // Задание 1
        int[] array = GenerateRandomArray(10);
        for (int i = 0; i < array.Length; i++) {
            Console.WriteLine(array[i]);
        }
        Array.Sort(array);
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++) {
            Console.WriteLine(array[i]);
        }
        Console.WriteLine("Массив успешно отсортирован.");

        // Ввод числа с клавиатуры
        Console.WriteLine("Введите число для поиска:");
        int numberToSearch = Convert.ToInt32(Console.ReadLine());
        int index = InterpolationSearch(array, numberToSearch);
        if (index != -1)
        {
            Console.WriteLine($"Число {numberToSearch} находится в массиве на позиции {index}");
        }
        else
        {
            Console.WriteLine($"Число {numberToSearch} не найдено в массиве.");
        }

        // Задание 2
        Console.WriteLine("Введите слово для поиска в файле:");
        string wordToSearch = Console.ReadLine();
        FindWordInFile("example.txt", wordToSearch);

        // Задание 3
        CreateGlossary("example.txt", "glossary.txt");
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 10000);
        }
        return array;
    }

    static int InterpolationSearch(int[] array, int key)
    {
        int low = 0;
        int high = array.Length - 1;
        while (low <= high && key >= array[low] && key <= array[high])
        {
            if (low == high)
            {
                if (array[low] == key) return low;
                return -1;
            }

            int position = low + ((key - array[low]) * (high - low)) / (array[high] - array[low]);

            if (array[position] == key)
                return position;

            if (array[position] < key)
                low = position + 1;
            else
                high = position - 1;
        }
        return -1;
    }

    static void FindWordInFile(string filePath, string wordToSearch)
    {
        string[] lines = File.ReadAllLines(filePath);
        List<int> positions = new List<int>();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(wordToSearch))
            {
                positions.Add(i);
            }
        }
        if (positions.Count > 0)
        {
            Console.WriteLine($"Слово найдено в следующих позициях: {string.Join(", ", positions)}");
        }
        else
        {
            Console.WriteLine("Слово не найдено в файле.");
        }
    }

    static void CreateGlossary(string inputFilePath, string outputFilePath)
    {
        Dictionary<string, List<int>> glossary = new Dictionary<string, List<int>>();
        string[] lines = File.ReadAllLines(inputFilePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] words = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (glossary.ContainsKey(word))
                {
                    glossary[word].Add(i + 1);
                }
                else
                {
                    glossary.Add(word, new List<int> { i + 1 });
                }
            }
        }
        using (StreamWriter file = new StreamWriter(outputFilePath))
        {
            file.WriteLine("Слово | Список ссылок на строки");
            foreach (var entry in glossary)
            {
                file.WriteLine($"{entry.Key} | {string.Join(", ", entry.Value)}");
            }
        }
        Console.WriteLine($"Файл-глоссарий успешно создан: {outputFilePath}");
    }
}
