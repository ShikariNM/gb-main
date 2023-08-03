// Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]

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
Console.Write("Enter the begining of the range for defining array elements: ");
int start = int.Parse(Console.ReadLine());
Console.Write("Enter the end of the range for defining array elements: ");
int end = int.Parse(Console.ReadLine());
Console.WriteLine($"The array is [{String.Join(", ", FillArray(len, start, end))}]");