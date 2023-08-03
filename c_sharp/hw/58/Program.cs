// Задайте две матрицы. Напишите программу, которая будет находить
// произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.Clear();
Console.Write("Enter the number of the rows in the first array: ");
int rowsNum1 = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns in the first array: ");
int colsNum1 = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the rows in the second array: ");
int rowsNum2 = int.Parse(Console.ReadLine());
Console.Write("Enter the number of the columns in the second array: ");
int colsNum2 = int.Parse(Console.ReadLine());
int[,] array1 = FillDoubleArray(rowsNum1, colsNum1, 1, 7);
int[,] array2 = FillDoubleArray(rowsNum2, colsNum2, 1, 7);
PrintDoubleArray(array1);
Console.WriteLine();
PrintDoubleArray(array2);
Console.WriteLine();

if (array1.GetLength(1) == array2.GetLength(0)){
    int[,] MultipliedMatrix = ProductOfMatrix(array1, array2);
    PrintDoubleArray(MultipliedMatrix);
}
else Console.WriteLine("The matrices are not suitable to multiply");

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

int[,] ProductOfMatrix (int[,] matrix1, int[,] matrix2){
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    int sum = 0;                  // sum - переменная для получения элементов новой матрицы
    for (int i = 0; i < matrix1.GetLength(0); i++)  // i - кол-во строк в 1 матрице
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)  // j - кол-во столбцов во 2 матрице
        {
            for (int k = 0; k < matrix1.GetLength(1); k++)  // k - количество столбцов в 1
            {                                               // матрице и строк во 2 матрице
                sum += (matrix1[i, k] * matrix2[k, j]);
            }
            result[i, j] = sum;
            sum = 0;
        }   
    }
    return result;
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