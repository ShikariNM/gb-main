// Напишите программу, которая принимает на вход пятизначное число и проверяет,
// является ли оно палиндромом.

// 14212 -> нет
// 12821 -> да
// 23432 -> да

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse (Console.ReadLine ());
if (num < 10000 || num > 99999){
    Console.WriteLine("Enter correct number");
    return;
}
if (num/10000 == num%10 && (num/1000)%10 == (num/10)%10){
    Console.WriteLine("The number is palindrome");
}
else {
    Console.WriteLine("The number is NOT palindrome");
}