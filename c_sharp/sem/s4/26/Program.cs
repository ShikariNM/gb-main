// Напишите программу, которая принимает на вход
// число и выдает количество цифр в числе.

// 456 -> 3
// 78 -> 2
// 89126 -> 5

void CountDigits (int num){
    int count = 0;
    if(num == 0){
        count = 1;
    }
    if (num < 0) num *= -1;
    while(num%10 > 0){
        count += 1;
        num = num / 10;
    }
    Console.WriteLine (count);
}

CountDigits(-12342);