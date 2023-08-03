// Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

int DigitsSum (int number){
    int result = 0;
    if (number < 0) number *= (-1);
    while (number > 0){
        result += number%10;
        number /= 10;
    }
    return result;
}

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());

Console.WriteLine($"The sum of {num}'s digits is: {DigitsSum(num)}");