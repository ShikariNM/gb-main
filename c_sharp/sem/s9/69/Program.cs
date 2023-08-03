// Напишите программу, которая на вход принимает два числа A и B,
// и возводит число А в целую степень B с помощью рекурсии.

// A = 3; B = 5-> 243(3⁵)
// A = 2; B = 3-> 8

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
Console.Write("Enter the exponent: ");
int exp = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(Exponentiation(num, exp));

int Exponentiation (int number, int exponent){
    if (exponent == 0) return 1;
    return Exponentiation(number, exponent-1) * number;
}