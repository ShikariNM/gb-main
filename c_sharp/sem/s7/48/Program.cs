// Задайте двумерный массив размера m на n, каждый элемент
// в массиве находится по формуле: A[i][j] = i + j. 
// Выведите полученный массив на экран.

// m = 3, n = 4.
// 0 1 2 3
// 1 2 3 4
// 2 3 4 5

Console.Clear();
Console.Write("Enter the number of rows: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int n = int.Parse(Console.ReadLine());
int[,] array1= FillDoubleArray(m, n, 0, 10);
PrintDoubleArray(array1);

int[,] FillDoubleArray(int numberOfRows, int numberOfColumns, int minValue, int maxValue){
    int[,] array = new int[numberOfRows, numberOfColumns];
    for (int i = 0; i < numberOfRows; i++)
    {
        for (int j = 0; j < numberOfColumns; j++)
        {
            array[i, j] = i + j;
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