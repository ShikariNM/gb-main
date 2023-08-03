// Задайте значения M и N.
// Напишите программу, которая выведет все
// натуральные числа в промежутке от M до N.

// M = 1; N = 5. -> "1, 2, 3, 4, 5"
// M = 4; N = 8. -> "4, 5, 6, 7, 8"

Console.Clear();
Console.Write("Enter the first number: ");
int n = int.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
int m = int.Parse(Console.ReadLine());
Console.WriteLine(NumbersRow(n, m));

string NumbersRow(int number1, int number2){
    if(number2 == number1) return $"{number1}";
    string s = NumbersRow(number1, number2-1) + " " + number2.ToString();
    return s;
}