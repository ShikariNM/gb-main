// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу
// кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
int i = 1;

if (num == 0){
    Console.WriteLine("Enter the number that does not equal 0");
    return;
}
else{
    if (num < 0) num *= -1;
    while (i <= num){
        Console.Write($"{Math.Pow(i, 3)}, ");
        i += 1;
    }
}
