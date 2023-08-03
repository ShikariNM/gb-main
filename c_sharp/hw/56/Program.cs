// Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и
// выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillDoubleArray(rowsNum, colsNum, 0, 10);
PrintDoubleArray(array1);
Console.WriteLine();
int[] sumArray1 = EachRowSum(array1);
Console.WriteLine($"{string.Join(" ", sumArray1)}");
Console.WriteLine();
Console.WriteLine($"The sum of the {SmallestElementIndex(sumArray1)+1} row is the smallest");

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

// Суммируем элементы каждой строки двумерного массива
// и выводим результат в виде одномерного массива

int[] EachRowSum (int[,] array){
    int[] sumArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumArray[i] += array[i, j];
        }
    }
    return sumArray;
}

// Находим индекс наименьшего элемента полученного массива.
// Номер искомой строки равен индекс+1

int SmallestElementIndex (int[] array){
    int result = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if(array[result] > array[i]) result = i;
    }
    return result;
}