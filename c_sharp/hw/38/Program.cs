// Задайте массив вещественных чисел.
// Найдите разницу между максимальным и минимальным элементами массива.
// [3 7 22 2 78] -> 76

double[] GetNewArray (string newArray){
    string[] stringArray = newArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    double[] array = new double[stringArray.Length];
    for (int i = 0; i < stringArray.Length; i++){
        array[i] = double.Parse(stringArray[i]);
    }
    return array;
}

Console.Clear();
Console.Write($"Enter the elements of the array with spaces: ");
string elements = Console.ReadLine();
double[] array1 = GetNewArray(elements);

double DifferenceMaxMin (double[] array){
    double maxEl = array[0];
    double minEl = array[0];
    foreach (var el in array){
        maxEl = el > maxEl ? el : maxEl;
        minEl = el < minEl ? el : minEl;
    }
    return maxEl - minEl;
}

Console.WriteLine("The difference between maximum and");
Console.WriteLine($"minimum array elements is {DifferenceMaxMin(array1)}");