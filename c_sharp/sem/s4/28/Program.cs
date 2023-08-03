// Напишите программу, которая принимает на вход число N
// и выдаёт произведение чисел от 1 до N.

// 4 -> 24 
// 5 -> 120

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());

int Multiplication (int n){
    int result = 1;
    for (int i = 1; i <= n; i++)
    {
            result *= i;
    }
    return result;
}

Console.WriteLine($"Multiplication of the numbers from 1 to {num} is {Multiplication(num)}");