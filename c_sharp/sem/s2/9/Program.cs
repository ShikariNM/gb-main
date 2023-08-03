// Напишите программу, которая выводит случайное число из отрезка [10, 99] и 
//показывает наибольшую цифру числа.

// 78 -> 8
// 12-> 2
// 85 -> 8

Console.Clear();
string number = Convert.ToString(new Random().Next(10, 100));
Console.WriteLine (number);
int length = number.Length;
int index = 0;
int max = 0;
while (index < length){
    string digit1 = Convert.ToString (number[index]);
    int digit = int.Parse (digit1);
    if (max < digit) max = digit;
    index += 1;
}
Console.WriteLine($"The biggest digit is {max}");