// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

Console.Clear();
Console.Write("Enter the number of rows: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int n = int.Parse(Console.ReadLine());
double[,] array1 = FillArray(m, n, 1, 10);
Console.WriteLine();
PrintArray(array1);
Console.WriteLine();

// Создаем двумерный массив случайных вещественных чисел.
// Размеры массива и диапазон значений элементов задаются пользователем.

double[,] FillArray (int numberOfRows, int numberOfColumns, double minValue, double maxValue){
    double[,] array = new double[numberOfRows, numberOfColumns];
    for (int i = 0; i < numberOfRows; i++)
    {
        for (int j = 0; j < numberOfColumns; j++)
        {
            array[i, j] = new Random().NextDouble()*(maxValue-minValue) + minValue;
        }
    }
    return array;
}

// Выводим массив в терминал с округлением значений элементов
// до одного знака после запятой.

void PrintArray(double[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]:f1} ");
        }
        Console.WriteLine();
    }
}