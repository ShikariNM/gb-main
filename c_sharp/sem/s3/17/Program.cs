// Напишите программу, которая принимает на вход координаты точки (X и Y), 
// причем X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится
// эта точка.

Console.Clear();
Console.Write("Enter the value of X: ");
int X = int.Parse (Console.ReadLine());
Console.Write("Enter the value of Y: ");
int Y = int.Parse (Console.ReadLine());
if (X == 0 || Y == 0){
    Console.WriteLine ("The point on an axis");
}
if (X > 0 && Y > 0){
    Console.WriteLine ("The point is in the 1st quarter");
}
if (X < 0 && Y > 0){
    Console.WriteLine ("The point is in the 2nd quarter");
}
if (X < 0 && Y < 0){
    Console.WriteLine ("The point is in the  3rd quarter");
}
if (X > 0 && Y < 0){
    Console.WriteLine ("The point is in the 4st quarter");
}