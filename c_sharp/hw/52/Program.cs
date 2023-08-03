// Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillPrintDoubleArray(rowsNum, colsNum, 1, 10);
Console.WriteLine();
double[] average = ColumnMean(array1);
PrintSingleArray (average);

// Создаем и выводим в терминал двумерный массив целых чисел.
// Размеры массива и диапазон значений элементов задается пользователем.

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

// Находим среднее арифметическое элементов каждого столбца и
// формируем одномерный массив из полученных чисел.

double[] ColumnMean (int[,] inArray){
    double[] result = new double[inArray.GetLength(1)];
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        for (int j = 0; j < inArray.GetLength(0); j++)
        {
            result[i] += inArray[j, i];
        }
        result[i] /= inArray.GetLength(0);
    }
    return result;
}

// Выводим полученный массив в терминал с округлением значений элементов
// до одного знака после запятой.

void PrintSingleArray (double[] array){
    Console.Write("The means of the columns are: ");
    for (int i = 0; i < array.Length-1; i++)
    {
        Console.Write($"{array[i]:f1} ");
    }
    Console.WriteLine($"{array[array.Length-1]:f1}");
}