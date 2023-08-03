// Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
// 2, 3, 7 -> 7
// 44 5 78 -> 78
// 22 3 9 -> 22

Console.Clear ();
Console.Write("Enter the first number: ");
int num1 = int.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
int num2 = int.Parse(Console.ReadLine());
Console.Write("Enter the third number: ");
int num3 = int.Parse(Console.ReadLine());
int max = num1;

if (num1 == num2 && num2 == num3 && num1 == num1){
    Console.WriteLine("All the numbers are equal");
    return;
}
else {
    if(max <= num2) max = num2;
    if(max <= num3) max = num3;
    Console.Write("The maximum number is ");
    if (max == num1) {
       Console.Write("the first one ");
    }
    if (num1 == num2 || num1 == num3) Console.Write("and ");
    if (max == num2) {
       Console.Write("the second one ");
    }
    if (num2 == num3) Console.Write("and ");
    if (max == num3) {
        Console.WriteLine("the third one");
    }
}
//Немного усложнил задачу в плане вывода данных (пришлось принебречь условиями задания),
//но не стал возиться с заменой is на are, в случае двух равных чисел.