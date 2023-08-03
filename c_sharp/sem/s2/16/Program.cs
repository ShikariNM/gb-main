// Напишите программу, которая принимает на вход два числа и проверяет,
// является ли одно число квадратом другого.

// 5, 25  ->  да
// -4, 16  ->  да
// 25, 5  ->  да
// 8,9  ->  нет

Console.Clear ();
Console.Write ("Enter the first number: ");
int num1 = int.Parse (Console.ReadLine ());
Console.Write ("Enter the second number: ");
int num2 = int.Parse (Console.ReadLine ());

if (num1 == num2*num2 || num2 == num1*num1){
    Console.WriteLine ("Yes");
}
else{
    Console.WriteLine ("No");
}