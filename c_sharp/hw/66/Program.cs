// Задайте значения M и N. Напишите программу, которая найдёт сумму
// натуральных элементов в промежутке от M до N.
// M = 1; N = 15 -> 120
// M = 4; N = 8. -> 30

Console.Clear();
Console.Write("Enter the first number: ");
int firstNum = int.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
int secondNum = int.Parse(Console.ReadLine());
if (firstNum > secondNum){
    Console.WriteLine("The second number must be bigger than the first one");
    return;
}
Console.WriteLine(NumbersSum(firstNum, secondNum));

int NumbersSum (int start, int end){
    if(start == end) return end;
    return NumbersSum(start+1, end) + start;
}