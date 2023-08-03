//Напишите программу, которая выводит массив из 8 элементов, 
//заполненный нулями и единицами в случайном порядке.

//[1,0,1,1,0,1,0,0]

Console.Clear();
Console.Write("Enter the length of the array: ");
int num = int.Parse(Console.ReadLine());

int[] FillArray (int length){
    int[] array = new int[length];
    for (int index = 0; index < length; index++){
                array[index] = new Random().Next(0, 2);
    }
    return array;
}

Console.WriteLine($"The array is [{String.Join(", ", FillArray(num))}]");