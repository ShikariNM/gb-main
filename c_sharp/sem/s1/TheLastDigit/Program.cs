Console.Clear ();
Console.Write("Enter the number: ");
int number = int.Parse(Console.ReadLine());
if (number < 100 || number > 999){
    Console.WriteLine("Enter correct value");
    return;
}
else{
    int digit = number % 10;
    Console.WriteLine($"The last digit is {digit}");
}

Console.WriteLine("_________________________________");
Console.WriteLine("The second way");
Console.Write("Enter the number: ");
string number2 = Console.ReadLine();
string digit2 = Convert.ToString (number2[2]);
Console.WriteLine($"The last digit is {digit2}");