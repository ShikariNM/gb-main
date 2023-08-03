// Задайте одномерный массив из 123 случайных чисел.
// Найдите количество элементов массива, значения которых лежат в отрезке [10,99].

int[] FillArray (int length, int from, int to){
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(from, to+1);
    }
    return array;
}

int[] array1 = FillArray(123, 0, 1000);

int findAmountOfElements (int[] array, int minValue, int maxValue){
    int countOfElements = 0;
    int length = array.Length;
    for (int i = 0; i < length; i++)
    {
        if (array[i] >= minValue && array[i] <= maxValue) countOfElements += 1;
    }
    return countOfElements;
}

// Console.WriteLine($"[{String.Join(", ", array1)}]");
Console.WriteLine($"The amount of the elements is {findAmountOfElements(array1, 10, 99)}");