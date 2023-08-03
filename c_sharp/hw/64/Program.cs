// Задайте значение N. Напишите программу, которая выведет все натуральные числа
// в промежутке от N до 1. Выполнить с помощью рекурсии.
// N = 5 -> "5, 4, 3, 2, 1"
// N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
if (num <= 0){
    Console.WriteLine("The number must be positive. Try again!");
    return;
}
Console.WriteLine(RowOfNumbers(num));

string RowOfNumbers (int number){
    if(number == 1) return "1";
    return number.ToString() + ' ' + RowOfNumbers(number-1).ToString();
}