// Напишите программу, которая принимает на вход число и проверяет,
// кратно ли оно одновременно 7 и 23.

// 14 -> нет 
// 46 -> нет 
// 161 -> да

Console.Clear ();
Console.Write ("Enter the number: ");
int num = int.Parse (Console.ReadLine ());
if (num % 7 == 0 && num % 23 == 0){
    Console.WriteLine ($"{num} is a multiple of both 7 and 23");
}
else{
    Console.WriteLine ($"{num} is not a multiple");
}