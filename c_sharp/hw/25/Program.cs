// Напишите цикл, который принимает на вход два числа (A и B) и
// возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

int Exponentiation (int number, int exponent){
    int result = number;
    for (int i = 1; i < exponent; i++){
    result *= number;
    }
    return result;
}

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
Console.Write("Enter the exponent: ");
int exp = int.Parse(Console.ReadLine());

if (exp <= 0){
    Console.WriteLine($"{exp} is not a natural number. Try again!");
}
else {
    Console.WriteLine($"{num} to the power of {exp} is {Exponentiation(num, exp)}");
    Console.WriteLine($"Verification: {Math.Pow(num, exp)}");
}