public class Lab3 {
    public static void Main(String []args) {
        int[] arr = { -2, -6, -9, 6, -8, -5, -7, -1, 5, -2 };

        // Вызов Task1.
        Task1(arr);
        
    }

    // Task1.
    public static void Task1(int[] arr) {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0) count++;
            if (count == 3)
            {
                Console.WriteLine("Индекс 3-го положительного: {0}. Это число {1}", i, arr[i]);
                break;
            }
        }
        if (count < 3)
            Console.WriteLine("В массиве {0} положительных элементов.", count);
    }
}