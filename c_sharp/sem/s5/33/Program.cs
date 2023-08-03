// Задайте массив. Напишите программу, которая определяет, присутствует ли 
// заданное число в массиве.
// 4; массив [6, 7, 19, 345, 3] -> нет
// 3; массив [6, 7, 19, 345, 3] -> да

// int[] NewArrayByUser (int length){
//     int[] array = new int[length];
//     for (int i = 0; i < length; i++){
//         Console.Write ($"Enter the element for index {i}: ");
//         int element = int.Parse(Console.ReadLine());
//         array[i] = element;
//     }
//     return array;
// }

// int[] array1 = NewArrayByUser(5);
// Console.WriteLine($"[{String.Join(", ", array1)}]");

Console.Clear();
Console.Write("Enter the elements of the array with spaces: ");
string elements = Console.ReadLine();
int[] array1 = GetArrayFromString(elements);
Console.Write("Enter the number to find in the array: ");
int num = int.Parse(Console.ReadLine());
if (FindElement(array1, num)){
    Console.WriteLine($"The number is present in the array");
}
else{
    Console.WriteLine($"The number is absent in the array");
}

int[] GetArrayFromString (string stringArray){
    string[] nums = stringArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        res[i] = int.Parse(nums[i]);
    }
    return res;
}

// void FindElement (int[] array, int num){
//     int factOfpresence = 0;
//     for (int i = 0; i < array.Length; i++){
//         if (array[i] == num) factOfpresence += 1;
//     }
//     if (factOfpresence > 0){
//         Console.WriteLine($"The number is present in the array");
//     }
//     else{
//         Console.WriteLine($"The number is absent in the array");
//     }
// }

bool FindElement (int[] array, int num){
    foreach (var el in array){
        if (el == num) return true;
    }
    return false;
}