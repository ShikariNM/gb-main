//  Напишите программу, которая будет преобразовывать десятичное число в двоичное.
// 45 -> 101101
// 3  -> 11
// 2  -> 10

Console.Clear();
Console.Write ("Enter the number: ");
int num1 = int.Parse(Console.ReadLine());
Console.WriteLine($"Binary version of the number is {Binarization1(num1)}");
Console.WriteLine($"Binary version of the number is {Binarization2(num1)}");
Console.WriteLine($"Binary version of the number is {Binarization3(num1)}");
Console.WriteLine($"Binary version of the number is {Binarization4(num1, 2)}");

string Binarization1 (int num){
    string res = "";
    int divider = 1;
    while (num/divider != 1){
        divider *= 2;
    }
    while (divider > 0){
        if (num/divider > 0){
            res += $"1";
            num -= divider;
        }
        else{
            res += $"0";
        }
        divider /= 2;
    }
    return res;
}

int Binarization2 (int num){
    int res = 1;
    int divider = 1;
    while (num/divider != 1){
        divider *= 2;
        res *= 10;
    }
    int por = res/10;
    num -= divider;
    divider /= 2;
    while (divider > 0){
        if (num/divider > 0){
            res = res + por;
            num -= divider;
        }
        por /= 10;
        divider /= 2;
    }
    return res;
}

string Binarization3 (int num){
    string res = "";
    while (num > 0){
        if(num%2 == 0){
            res = $"0" + res;
        }
        else {
            res = $"1" + res;
            num -= 1;
        }
        num /= 2;
    }
    return res;
}

string Binarization4 (int decNum, int system){
    string res = "";
    string nums = "0123456789ABCDEF";
    while (decNum > 0){
        int ost = decNum / system;
        res = nums[decNum - system * ost] + res;
        decNum /= system;
    }
    return res;
}