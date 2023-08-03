//  Задайте двумерный массив. Напишите программу, которая упорядочит
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillDoubleArray(rowsNum, colsNum, 0, 100);
PrintDoubleArray(array1);
Console.WriteLine();
int[,] sortedArray = SortRowElements(array1);
PrintDoubleArray(sortedArray);

int[,] FillDoubleArray (int numberOfRows, int numberOfColumns, int minValue, int maxValue){
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

void PrintDoubleArray (int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] SortRowElements (int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {                                                // j раз пробегаем по каждой строке
        for (int j = 0; j < array.GetLength(1); j++) // переставляя элементы в порядке возрастания
        {
            for (int k = 0; k < array.GetLength(1)-1-j; k++) // "-j" для сокращения числа бесполезных итераций
            {
                if (array[i, k] > array[i, k+1]){   // сравниваем соседние элементы и
                    int temp = array[i, k];         // меняем местами, если последующий
                    array[i, k] = array[i, k+1];    // меньше предыдущего
                    array[i, k+1] = temp;
                }
            }
        }
    }
    return array;
}