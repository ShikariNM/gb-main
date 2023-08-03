// Найдите произведение пар чисел в одномерном массиве.
// Парой считаем первый и последний элемент, второй и предпоследний и т.д.
// Результат запишите в новом массиве.
// [1 2 3 4 5] -> 5 8 3
// [6 7 3 6] -> 36 21

int[] GetArrayFromString (string stringArray){
    string[] nums = stringArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        res[i] = int.Parse(nums[i]);
    }
    return res;
}

Console.Clear();
Console.Write("Enter the elements of the array with spaces: ");
string stringArray1 = Console.ReadLine();
int[] array1 = GetArrayFromString(stringArray1);

int[] SumOfEnds (int[] array){
    int sumArrayLength = array.Length/2;
    if (array.Length%2 != 0) sumArrayLength = array.Length/2+1;
    int[] sumArray = new int[sumArrayLength];
    for (int i = 0; i < sumArrayLength; i++)
    {
        sumArray[i] = array[i] + array[array.Length - 1 - i];
        if (i == array.Length - 1 - i) sumArray[i] = array[i];
    }
    return sumArray;
}

Console.WriteLine($"[{String.Join(", ", SumOfEnds(array1))}]");