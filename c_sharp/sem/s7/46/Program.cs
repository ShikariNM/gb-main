//Задайте двумерный массив размером mxn, заполненный случайными числами.

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