//  Задайте массив из 12 элементов, заполненный случайными числами из промежутка
// [-9, 9]. Найдите сумму отрицательных и положительных элементов массива.
// Например, в массиве [3,9,-8,1,0,-7,2,-1,8,-3,-1,6] сумма положительных чисел 
// равна 29, сумма отрицательных равна -20.

int[] FillArray (int length, int from, int to){
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(from, to+1);
    }
    return array;
}

Console.Clear();
int[] array1 = FillArray(12, -9, 9);
Console.WriteLine($"The array is [{String.Join(", ", array1)}]");

void SumPosNeg (int[] array){
    // int length = array.Length;
    int SumNeg = 0;
    int SumPos = 0;
    foreach (int el in array){
        SumNeg += el < 0 ? el : 0;
        SumPos += el > 0 ? el : 0;
    }
    // for (int i = 0; i < length; i++)
    // {
    // if (array[i] > 0){
    //     SumPos += array[i];
    // }
    // else {
    //     SumNeg += array[i];
    // }
    // }
    Console.WriteLine($"The sum of negative numbers is {SumNeg}");
    Console.WriteLine($"The sum of positive numbers is {SumPos}");
}

SumPosNeg(array1);
