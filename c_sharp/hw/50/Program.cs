// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// [1, 7] -> такого числа в массиве нет

Console.Clear();

Console.Write("Enter the number of rows: ");
int m = int.Parse(Console.ReadLine());
Console.Write("Enter the number of columns: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine("The array is filled in row by row from top to bottom");
Console.Write($"Enter {m*n} array elements with spaces: ");
string input = Console.ReadLine();
int[,] array = FillArrayByUser(input, m, n);
PrintArray(array);
Console.Write("Enter the position of the element in the following way: \"row column\": ");
string position = Console.ReadLine();
int[] positionInt = TransitionToIntArray(position);
LookForElement(array, positionInt);


// Создаем двумерный массив из строки, которую вводит пользователь. Количество
// строк и столбцов также вводит пользователь.

int[,] FillArrayByUser(string userText, int numberOfRows, int numberOfColumns){
    string[] stringArray = userText.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[,] result = new int[numberOfRows, numberOfColumns];
    for (int i = 0, k = 0; i < numberOfRows; i++)
    {
        for (int j = 0; j < numberOfColumns; j++, k++)
        {
            result[i, j] = int.Parse(stringArray[k]);
        }
    }
    return result;
}

// Вывод созданного массива в терминал

void PrintArray(int[,] array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

// Пользователь вводит "адрес" искомого элемента в виде строки. Следующая функция
// преобразует ее в массив натуральных чисел, для удобства работы.

int[] TransitionToIntArray (string inString){
    string[] stringArray = inString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] result = new int[stringArray.Length];
    for (int i = 0; i < stringArray.Length; i++)
    {
        result[i] = int.Parse(stringArray[i]);
    }
    return result;
}

// Функция поиска искомого элемента в массиве и вывод соответствующего сообщения, 
// в случае если позиция элемента находится за пределами массива.

void LookForElement (int[,] array, int[] position){
    if(position[0] >= array.GetLength(0) || position[1] >= array.GetLength(1)){
        Console.WriteLine("There is no the element with this position in the array");
    }
    else Console.WriteLine($"The element is {array[position[0], position[1]]}");
}