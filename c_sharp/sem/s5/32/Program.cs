// Напишите программу замена элементов массива: положительные элементы замените 
// на соответствующие отрицательные, и наоборот.
// [-4, -8, 8, 2] -> [4, 8, -8, -2] 

Console.Clear();
int[] FillArray (int length, int from, int to){
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(from, to+1);
    }
    return array;
}

int[] array1 = FillArray(8, -9, 9);
Console.WriteLine($"The array is [{String.Join(", ", array1)}]");

int[] ChangePolarity(int[] array){
    for (int i = 0; i < array.Length; i++){
        array[i] *= (-1);
    }
    return array;
}

Console.WriteLine($"The array is [{String.Join(", ", ChangePolarity(array1))}]");