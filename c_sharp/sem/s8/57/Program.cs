// Составить частотный словарь элементов двумерного массива.
// Частотный словарь содержит информацию о том, сколько раз 
// встречается элемент входных данных.

Console.Clear();
Console.Write("Enter the number of the rows: ");
int rowsNum = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns: ");
int colsNum = int.Parse(Console.ReadLine());
int[,] array1 = FillPrintDoubleArray(rowsNum, colsNum, -100, 100);
Console.WriteLine();
// int[] array2 = DoubleArreyToSingle(array1);
// Console.WriteLine($"{string.Join(" ", array2)}");
// SortArray(array2);
// Console.WriteLine($"{string.Join(" ", array2)}");
// LookForAmountOfValues(array2);

int[] minMax1 = MinMaxElements(array1);
Console.WriteLine($"{string.Join(" ", minMax1)}");
Console.WriteLine();
int[] result = CountElements (array1, minMax1);
Console.WriteLine($"{string.Join(" ", result)}");

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

int[] DoubleArreyToSingle (int[,] array){
    int[] singleArray = new int[array.GetLength(0)*array.GetLength(1)];
    for (int i = 0, k =0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++, k++)
        {
            singleArray[k] = array[i, j];
        }
    }
    return singleArray;
}

void SortArray(int[] array){
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = i+1; j < array.Length; j++)
        {
            if(array[i] > array[j]){
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}

void LookForAmountOfValues (int[] array){
    int count = 1;
    int i = 0;
    while(i < array.Length-1){
        if(array[i] == array[i+1]){
            count += 1;
        }
        else {
            Console.WriteLine($"The element {array[i]} is met {count} times");
            count = 1;
        }
        i += 1;
    }
    Console.WriteLine($"The element {array[i]} is met {count} times");
}

int[] MinMaxElements (int[,] array){
    int[] minMax = new int[2];
    minMax[0] = array[0, 0];
    minMax[1] = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 1; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minMax[0]) minMax[0] = array[i, j];
            if (array[i, j] > minMax[1]) minMax[1] = array[i, j];
        }
    }
    return minMax;
}

int[] CountElements (int[,] array, int[] minMax){
    int num = minMax[1] + 1 - minMax[0];
    int[] countArray = new int[num];
    int t = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            t = array[i, j] - minMax[0]; 
            countArray[t] += 1;
        }
    }
    return countArray;
}