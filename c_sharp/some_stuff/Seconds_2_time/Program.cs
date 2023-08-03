Console.Write ("Enter how much seconds you would like to convert: ");
int input = Convert.ToInt32(Console.ReadLine());
if (input >= 0)
{
int hours = input / 3600;
int minutes = input % 3600 / 60;
int seconds = input % 60;
Console.WriteLine ($"{hours}:{minutes}:{seconds}");
}
else
{
    Console.WriteLine ("Number must be positive. Try again.");
}