// Напишите программу, которая будет принимать на вход два числа и выводить,
// является ли второе число кратным первому. Если число 2 не кратно числу 1,
// то программа выводит остаток от деления.

// 34, 5 -> не кратно, остаток 4 
// 16, 4 -> кратно

Console.Clear ();
Console.Write ("Enter the first number: ");
int num1 = int.Parse (Console.ReadLine ());
Console.Write ("Enter the second number: ");
int num2 = int.Parse (Console.ReadLine ());

if (num1 % num2 == 0){
    Console.WriteLine ("The first number is a multiple of the second one");
}
else{
    Console.WriteLine ($"Remainder is {num1%num2}");
}