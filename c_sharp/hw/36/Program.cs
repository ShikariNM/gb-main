// Задайте одномерный массив, заполненный случайными числами.
// Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

//Не ясен диапазон значений элементов массива из условий задачи,
//поэтому выбрал вариант, где его задает пользователь.

int[] FillArray (int length, int from, int to){
    int[] array = new int[length];
    for (int i = 0; i < length; i++)
    {
        array[i] = new Random().Next(from, to+1);
    }
    return array;
}
Console.Clear();
Console.Write("Enter the length of the array: ");
int len = int.Parse(Console.ReadLine());
Console.Write("Enter the minimum value of the array elements: ");
int start = int.Parse(Console.ReadLine());
Console.Write("Enter the maximum value  of the array elements: ");
int end = int.Parse(Console.ReadLine());

int[] array1 = FillArray(len, start, end);
Console.WriteLine($"[{string.Join(" ", array1 )}]");

int SumOfOddElems (int[] array){
    int sum = 0;
    for (int i = 1; i < array.Length; i++){
        if (i%2 != 0) sum += array[i];
    }
    return sum;
}

Console.WriteLine($"The sum of odd array elements is {SumOfOddElems(array1)}");