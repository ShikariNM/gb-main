//  Напишите программу, которая принимает на вход три числа и проверяет,
//  может ли существовать треугольник с сторонами такой длины.

Console.Clear();
Console.Write ("Enter the lengths of the triangle sides with space: ");
string sidesString = Console.ReadLine();
int[] sides = GetArrayFromString(sidesString);
if (CheckTriangle1(sides)) Console.WriteLine("The triangle can exist");
else Console.WriteLine("The triangle is impossible");

bool CheckTriangle1 (int[] inArray){
    if (inArray[0] > inArray[1] + inArray[2]) return false;
    else if (inArray[1] > inArray[2] + inArray[0]) return false;
    else if (inArray[2] > inArray[0] + inArray[1]) return false;
    else return true;
}

int[] GetArrayFromString (string stringArray){
    string[] nums = stringArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] res = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        res[i] = int.Parse(nums[i]);
    }
    return res;
}