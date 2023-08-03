// Напиште программу, которая принимает на вход число А и
// выдает сумму чисел от 1 до А
// а = 5
// sum = 1 + 2 + 3 + 4 + 5

Console.Clear();
Console.Write ("Enter the number: ");
int n = int.Parse (Console.ReadLine());
Console.WriteLine ($"The sum of numbers from 1 to {n} equals {GetSum(n)}");

int GetSum (int num){
    int sum = 0;
    for (int i = 1; i <= num; i++)
    {
        sum += i;
    }
    return sum;
}