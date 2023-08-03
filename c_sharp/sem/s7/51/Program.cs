// Задайте двумерный массив. Найдите сумму элементов, находящихся
// на главной диагонали (с индексами (0,0); (1; 1) и т.д.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Сумма элементов главной диагонали: 1+9+2 = 12

Console.Clear();
Console.Write("Enter the number of rows: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int n = int.Parse(Console.ReadLine());
int[,] array1= FillDoubleArray(m, n, 0, 10);
PrintDoubleArray(array1);
Console.WriteLine($"The sum of the main diagonal elements is {MainDiagonalSum(array1)}");

int[,] FillDoubleArray(int numberOfRows, int numberOfColumns, int minValue, int maxValue){
    int[,] array = new int[numberOfRows, numberOfColumns];
    for (int i = 0; i < numberOfRows; i++)
    {
        for (int j = 0; j < numberOfColumns; j++)
        {
            array[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return array;
}

void PrintDoubleArray(int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int MainDiagonalSum (int[,] array){
    int result = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (i == j) result += array[i, j];
        }
    }
    return result;
}