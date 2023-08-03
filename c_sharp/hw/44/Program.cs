// Не используя рекурсию, выведите первые N чисел Фибоначчи.
// Первые два числа Фибоначчи: 0 и 1.
// Если N = 5 -> 0 1 1 2 3
// Если N = 3 -> 0 1 1
// Если N = 7 -> 0 1 1 2 3 5 8

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
Console.WriteLine($"{string.Join(" ", Fibonacci(num))}");

int[] Fibonacci(int number){
    int[] result = new int[number];
    if (number >= 2) result[1] = 1;
    for (int i = 2; i < number; i++)
    {
        result[i] = result[i-1] + result[i-2];
    }
    return result;
}