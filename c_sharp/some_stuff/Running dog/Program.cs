//Console.Write ("Enter first friend speed: ");
int firstFriendSpeed = 1; // Convert.ToInt32(Console.ReadLine());
//Console.Write ("Enter second friend speed: ");
int secondFriendSpeed = 2; //Convert.ToInt32(Console.ReadLine());
//Console.Write ("Enter dog speed: ");
int dogSpeed = 5; //Convert.ToInt32(Console.ReadLine());
//Console.Write ("Enter distance between friends: ");
double distance = 10000; //Convert.ToInt32(Console.ReadLine());
int friend = 2;
int count = 0;
double time = 0;

while (distance > 10)
{
    if (friend == 2)
    {
        time = distance / (secondFriendSpeed + dogSpeed);
        friend = 1;
    }
    else
    {
        time = distance / (firstFriendSpeed + dogSpeed);
        friend = 2;
    }
    distance = distance - time * (firstFriendSpeed + secondFriendSpeed);
    count += 1;
}
Console.WriteLine ($"The dog will run {count} times");