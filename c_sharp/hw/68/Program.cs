// Напишите программу вычисления функции Аккермана с помощью рекурсии.
// Даны два неотрицательных числа m и n.
// m = 2, n = 3 -> A(m,n) = 9
// m = 3, n = 2 -> A(m,n) = 29

//           { if(m = 0) n+1;
// A(m,n) =  { if(m > 0 && n = 0) A(m - 1, 1);
//           { if(m > 0 && n > 0) A(m - 1, A(m, n - 1));

// 2, 2 = 1, 5 = 7
// 1, 4 = 0, 5
// 1, 3 = 0, 4
// 1, 2 = 0, 3
// 1, 1 = 0, (1, 0) = 0, 2 = 3

Console.Clear();
Console.Write("Enter the first nuber: ");
int firstNum = int.Parse(Console.ReadLine());
if (firstNum < 0){
    Console.WriteLine ("The first number is negative. Try again!");
    return;
}
Console.Write("Enter the second nuber: ");
int secondNum = int.Parse(Console.ReadLine());
if (secondNum < 0 ){
    Console.WriteLine ("The second number is negative. Try again!");
    return;
}
Console.WriteLine(AckermannFunction(firstNum, secondNum));

int AckermannFunction(int m, int n){
    if (m == 0) return n + 1;
    if (m > 0 && n == 0) return AckermannFunction(m - 1, 1);
    return AckermannFunction(m - 1, AckermannFunction(m, n - 1));
}