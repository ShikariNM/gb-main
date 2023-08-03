//  Напишите программу, которая будет создавать копию заданного массива
// с помощью поэлементного копирования.

Console.Clear();

int[] array1 = FillArray (10, 0, 10);
int[] array2 = CopyArray(array1);
Console.WriteLine($"[{string.Join(" ", array1)}]");
Console.WriteLine($"[{string.Join(" ", array2)}]");

int[] CopyArray (int[] array){
    int [] newArray = new int[array.Length];
    for (int i = 0; i < array.Length; i++)
    {
        newArray[i] = array[i];
    }
    return newArray;
}

int[] FillArray (int length, int from, int to){
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(from, to+1);
    }
    return array;
}