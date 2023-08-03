// Задайте массив заполненный случайными положительными трёхзначными числами. 
// Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2

Console.Clear();

int[] GetArray000(int length){
    int[] array = new int[length];
    for (int i = 0; i < length; i++){
        array[i] = new Random().Next(100, 1000);
    }
    return array;
}

Console.Write("Enter the length of the array: ");
int len = int.Parse(Console.ReadLine());
int[] array1 = GetArray000(len);
Console.WriteLine($"[{String.Join(" ", array1)}]");

int AmountOfEven (int[] array){
    int count = 0;
    foreach (var el in array) {count += el%2 == 0 ? 1 : 0;
    }
    return count;
}

Console.WriteLine($"Amount of even numbers in the array is {AmountOfEven(array1)}");