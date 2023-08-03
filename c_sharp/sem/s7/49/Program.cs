// Задайте двумерный массив.
// Найдите элементы, у которых оба индекса чётные,
// и замените эти элементы на их квадраты.

// Например, изначально массив выглядел вот так:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 1 2 3 4

// Новый массив будет выглядеть вот так:
// 1 4 7 2
// 5 **81** 2 **9**
// 8 4 2 4
// 1 **4** 3 **16**

Console.Clear();
Console.Write("Enter the number of rows: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int n = int.Parse(Console.ReadLine());
int[,] array1= FillDoubleArray(m, n, 2, 2);
PrintDoubleArray(array1);
int[,] array2 = Task49Method(array1);
Console.WriteLine();
PrintDoubleArray(array2);

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

int[,] Task49Method (int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if ((i+1)%2==0 && (j+1)%2==0) array[i, j] *= array[i, j];
        }
    }
    return array;
}