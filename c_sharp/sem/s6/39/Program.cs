// Напишите программу, которая перевернёт одномерный массив
// (последний элемент будет на первом месте, а первый - на последнем и т.д.)
// [1 2 3 4 5] -> [5 4 3 2 1]
// [6 7 3 6] -> [6 3 7 6]

Console.Clear();
Console.Write("Enter the elements of the array with space: ");
string newArray = Console.ReadLine();
int[] array1 = GetArrayFromString(newArray);
Console.WriteLine($"[{string.Join(" ", ArrayReverse1(array1))}]");
Console.WriteLine($"[{string.Join(" ", ArrayReverse2(array1))}]");

int[] GetArrayFromString (string stringArray){
    string[] nums = stringArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        res[i] = int.Parse(nums[i]);
    }
    return res;
}

int[] ArrayReverse1 (int[] array){
    int temp = 0;
    for (int i = 0; i < array.Length/2; i++){
        temp = array[i];
        array[i] = array[array.Length - 1 - i];
        array[array.Length - 1 - i] = temp;
    }
    return array;
}

int[] ArrayReverse2 (int[] array){
    int[] result = new int[array.Length];
    for (int i = 0; i < array.Length; i++){
        result[i] = array[array.Length - 1 - i];
    }
    return result;
}