// Вариант 13.

// Задание 1.
// Разработайте программу, которая вычисляет периметр правильного шестиугольника.
// Значение длины стороны вводится с клавиатуры.

// Задание 2.
// Определить для своего варианта номер N области, в которой находится точка M(x,y)
// с заданными координатами. Границы области относить к области с наибольшим номером.

public class Lab1 {

    // Вызов функций
    public static void Main(String []args) {
        // Задание 1.
        task1();

        // Задание 2.
        task2();
    }

    // Задание 1.
    public static void task1() {
        Console.Write("Введите сторону правильного шестиугольника и нажмите клавишу Enter: ");

        int side = Convert.ToInt32(Console.ReadLine());
        int perimetr = side * 6;
        
        Console.WriteLine("Периметр правильного шестиугольника равен = " + perimetr);
    }

    // Задание 2.
    public static void task2() {
        Console.Write("\nВведите x: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        // Проверяем находится ли точка в отрицательной Y
        if (y < 0) {
            // Если да, то проверяем Y меньше 12, если да, то значит точка находится за пределами круга и N = 4
            // Если не меньше, значит N = 3
            if (y < -12) {
                Console.WriteLine("N = 4");
                return;
            } else {
                Console.WriteLine("N = 3");
                return;
            }
        } else if (y > 0) {
            // Если Y > 0, то проверяем Y больше 12, если да, то значит точка находится за пределами круга и N = 4
            // Если не больше, то проверяем, находится ли точка в параболе
            if (y > 12) {
                Console.WriteLine("N = 4");
                return;
            } else {
                int xParabol = x * x;

                // Сравниваем входной y и y нашей параболы
                if (y == xParabol) {
                    // Если равны, значит входная точка лежит прямо на параболе и N = 2
                    Console.WriteLine("N = 2");
                    return;
                } else if (y < xParabol) {
                    // Если меньше, значит входная точка лежит внутри параболы и N = 2
                    Console.WriteLine("N = 2");
                    return;
                } else {
                    // Если больше, значит точка лежит за пределами параболы и N = 1
                    Console.WriteLine("N = 1");
                    return;
                }
            }
        } else {
            // Тут y = 0
            // Проверим x
            if (x > 0 || x < 0) {
                // Если х > 0 или x < 0 значит N = 2
                Console.WriteLine("N = 2");
                return;
            } else {
                // Если x = 0, то Определить к какому N принадлежит входная точка - невозможно.
                Console.WriteLine("Координаты входной точки = (0, 0). Определить N - невозможно.");
                return;
            }
        }
    }
}