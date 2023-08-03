// Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
// 453 -> 12
// 45 -> 9

Console.Clear();
Console.Write("Enter the number: ");
int num = int.Parse(Console.ReadLine());
Console.WriteLine(DigitsSum(num));


// int DigitsSum(string number, int i = 0){
//     if(i == number.Length - 1){
//         return Convert.ToInt32(Convert.ToString(number[2]));
//     }
//     int sum = Convert.ToInt32(Convert.ToString(DigitsSum(number, i+1))) + Convert.ToInt32(Convert.ToString(number[i]));
//     return sum;
// }


int DigitsSum(int number){
    if(number == 0) return 0;
    int sum = DigitsSum(number/10)+number%10;
    return sum;
}