using System;
using System.Collections.Generic;

// Абстрактный тип данных "Список"
public interface IList<T>
{
    void Next(); // Переход к следующему элементу списка
    int CountVisited(); // Получение количества просмотренных операцией элементов списка
    void Insert(T data); // Вставка элемента в список
    void Remove(T data); // Удаление элемента из списка
    void Search(T data); // Поиск элемента в списке
}

// Реализация абстрактного типа данных "Список"
public class MyList<T> : IList<T>
{
    private List<T> internalList;
    private int visitedCount;

    public MyList()
    {
        internalList = new List<T>();
        visitedCount = 0;
    }

    public void Next()
    {
        if (visitedCount < internalList.Count - 1)
        {
            visitedCount++;
            Console.WriteLine("Переход к следующему элементу списка.");
        }
        else
        {
            Console.WriteLine("Достигнут конец списка.");
        }
    }

    public int CountVisited()
    {
        return visitedCount;
    }

    public void Insert(T data)
    {
        internalList.Add(data);
        Console.WriteLine($"Элемент {data} добавлен в список.");
    }

    public void Remove(T data)
    {
        if (internalList.Remove(data))
        {
            Console.WriteLine($"Элемент {data} удален из списка.");
        }
        else
        {
            Console.WriteLine($"Элемент {data} не найден в списке.");
        }
    }

    public void Search(T data)
    {
        if (internalList.Contains(data))
        {
            Console.WriteLine($"Элемент {data} найден в списке.");
        }
        else
        {
            Console.WriteLine($"Элемент {data} не найден в списке.");
        }
    }
}

class Lab5
{
    static void Main(string[] args)
    {
        IList<string> myList = new MyList<string>();

        myList.Insert("элемент1");
        myList.Insert("элемент2");
        myList.Insert("элемент3");

        myList.Search("элемент2");

        myList.Next();
        myList.Next();
        myList.Next();

        Console.WriteLine("Количество просмотренных элементов: " + myList.CountVisited());

        myList.Remove("элемент2");

        Console.ReadLine();
    }
}
