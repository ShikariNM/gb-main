// Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее,
//а какое меньшее.
// a = 5; b = 7 -> max = 7
// a = 2 b = 10 -> max = 10
// a = -9 b = -3 -> max = -3

Console.Clear ();
Console.Write("Enter the first number: ");
int num1 = int.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
int num2 = int.Parse(Console.ReadLine());

if (num1 > num2){
    Console.WriteLine("The first one is bigger, the second one is less");
}
if (num1 < num2){
    Console.WriteLine("The second one is bigger, the first one is less");
} 
if (num1 == num2){
    Console.WriteLine("The numbers are equal");
}

//Вывод данных сделал в соответствии с условиями задания, а не примерами.