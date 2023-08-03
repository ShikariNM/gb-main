// Задайте значение N. Напишите программу, которая выведет все натуральные числа 
// в промежутке от 1 до N.

// N = 5 -> "1, 2, 3, 4, 5"
// N = 6 -> "1, 2, 3, 4, 5, 6"

Console.Clear();
Console.Write("Enter the number: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine(NumbersRow(n));

string NumbersRow(int number){
    if(number == 1) return "1";
    string s = NumbersRow(number - 1) + " " + number.ToString();
    return s;
}