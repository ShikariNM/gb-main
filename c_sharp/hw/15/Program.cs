// Напишите программу, которая принимает на вход цифру, обозначающую день недели,
// и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет

Console.Clear ();
Console.Write ("Enter the number of the day: ");
int num = int.Parse (Console.ReadLine ());
if (num > 7 || num < 1){
    Console.WriteLine ("The number is invalid. Try again.");
    return;
}
else{
    if (num > 5) Console.WriteLine ("Congrats, it is a day off! Enjoy!");
    else{
        Console.WriteLine ("Unfortunately, it is a workday:( Go to work!");
    }
}