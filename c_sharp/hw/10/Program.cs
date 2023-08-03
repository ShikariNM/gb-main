// Напишите программу, которая принимает на вход трёхзначное число и
// на выходе показывает вторую цифру этого числа.

// 456 -> 5
// 782 -> 8 
// 918 -> 1

Console.Clear ();
Console.Write ("Enter the number: ");
string num = Console.ReadLine ();
if (num.Length != 3){
    Console.WriteLine ("The number is invalid");
    return;
}
else{
    int numInt = int.Parse (num);
    Console.WriteLine($"The second digit is {(numInt % 100 - numInt % 10) / 10}");
}