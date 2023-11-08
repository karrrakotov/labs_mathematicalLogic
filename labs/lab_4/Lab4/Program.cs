using System;

class Lab4 {
    static void Main(string[] args) {
        // Пример ввода данных с клавиатуры. Можно также использовать другие способы ввода данных.
        Console.WriteLine("Введите размерность матрицы (число строк): ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите размерность матрицы (число столбцов): ");
        int m = Convert.ToInt32(Console.ReadLine());

        int[,] matrixA = new int[n, m];
        int[] vectorB = new int[m];

        Console.WriteLine("Введите элементы матрицы A:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                matrixA[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Введите элементы вектора B:");
        for (int i = 0; i < m; i++) {
            vectorB[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Вызов процедуры перемножения матрицы A на вектор B.
        int[] result = MultiplyMatrixByVector(matrixA, vectorB);

        Console.WriteLine("Результат перемножения матрицы A на вектор B:");
        for (int i = 0; i < n; i++) {
            Console.Write(result[i] + " ");
        }
    }

    static int[] MultiplyMatrixByVector(int[,] matrix, int[] vector) {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        if (columns != vector.Length) {
            throw new ArgumentException("Число столбцов матрицы должно быть равно размерности вектора.");
        }

        int[] result = new int[rows];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                result[i] += matrix[i, j] * vector[j];
            }
        }

        return result;
    }
}
