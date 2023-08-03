// Напишите программу, которая выводит третью цифру заданного числа или сообщает,
// что третьей цифры нет.

// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

Console.Clear ();
Console.Write ("Enter the number: ");
string num = Console.ReadLine ();
if (num.Length < 3){
    Console.WriteLine ("The number consists of less then 3 digits");
    return;
}
else{
    string digit3 = Convert.ToString(num[2]);
    Console.WriteLine ($"The third digit is {digit3}");
}