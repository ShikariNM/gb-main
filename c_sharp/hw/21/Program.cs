// Напишите программу, которая принимает на вход координаты двух точек и находит
// расстояние между ними в 3D пространстве.

// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

Console.Clear ();
Console.Write ("Enter X1 value: ");
int X1 = int.Parse(Console.ReadLine());
Console.Write ("Enter Y1 value: ");
int Y1 = int.Parse(Console.ReadLine());
Console.Write ("Enter Z1 value: ");
int Z1 = int.Parse(Console.ReadLine());
Console.Write ("Enter X2 value: ");
int X2 = int.Parse(Console.ReadLine());
Console.Write ("Enter Y2 value: ");
int Y2 = int.Parse(Console.ReadLine());
Console.Write ("Enter Z2 value: ");
int Z2 = int.Parse(Console.ReadLine());

double dist = Math.Sqrt(Math.Pow(X1-X2, 2) + Math.Pow(Y1-Y2, 2) + Math.Pow(Z1-Z2, 2));
Console.WriteLine($"Distance between points is {dist:f2}");