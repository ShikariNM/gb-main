// **Задача 53:** Задайте двумерный массив. 
// Напишите программу, которая поменяет местами первую и последнюю строку массива.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:

// 8 4 2 4
// 5 9 2 3
// 1 4 7 2

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillPrintDoubleArray(rowsNum, colsNum, 1, 10);
int[,] array2 = ReplaceFirstLastRows(array1, 1, 3);
Console.WriteLine();
PrintDoubleArray(array2);


int[,] FillPrintDoubleArray (int numberOfRows, int numberOfColumns, int minValue, int maxValue){
    int[,] array = new int[numberOfRows, numberOfColumns];
    for (int i = 0; i < numberOfRows; i++)
    {
        for (int j = 0; j < numberOfColumns; j++)
        {
            array[i, j] = new Random().Next(minValue, maxValue);
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    return array;
}

int[,] ReplaceFirstLastRows (int[,] array, int a, int b){
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int temp = array[a-1, i];
        array[a-1, i] = array[b-1, i];
        array[b-1, i] = temp;
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