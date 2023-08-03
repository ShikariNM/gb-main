// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу
// квадратов чисел от 1 до N.

// 5 -> 1, 4, 9, 16, 25.
// 2 -> 1,4

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse (Console.ReadLine ());
int i = 1;

if (num < 0) num = num * -1;
double[] array = new double[num];
while (i <= num){
    array[i-1] = Math.Pow(i, 2);
    Console.Write($"{array[i-1]}, ");
    i += 1;
}

// while (i <= num){
//     Console.Write($"{Math.Pow(i, 2)}, ");
//     i += 1;
// }