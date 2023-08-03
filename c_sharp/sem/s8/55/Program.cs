// Задайте двумерный массив.
// Напишите программу, которая заменяет строки на столбцы.
// В случае, если это невозможно, программа должна вывести сообщение для пользователя.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// В итоге получается вот такой массив:

// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillPrintDoubleArray(rowsNum, colsNum, 1, 10);
Console.WriteLine();
ReplaceRowsColumns(array1);

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

void ReplaceRowsColumns (int[,] array){
    if(array.GetLength(0) != array.GetLength(1)){
        Console.WriteLine("The array is not square");
    }
    else{
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = i; j < array.GetLength(1); j++)
            {
                int temp = array[i, j];
                array[i, j] = array[j, i];
                array[j, i] = temp;
            }
        }
        PrintDoubleArray(array);
    }
}