// Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями
// y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

Console.Clear();
Console.WriteLine("The First line equation is y = k1*x + b1");
Console.WriteLine("The Second line equation is y = k2*x + b2");
Console.Write("Enter the coefficients of the equations in the following way: \"k1 b1 k2 b2\": ");
string stringCoeffs = Console.ReadLine();
double[] array1 = GetArrayFromString(stringCoeffs);
Console.WriteLine($"X = {FindTheCrossOfLines(array1)[0]}, Y = {FindTheCrossOfLines(array1)[1]}");


double[] FindTheCrossOfLines (double[] array){
    double[] result = new double[2];
    result[0] = (array[3] - array[1]) / (array[0] - array[2]);
    result[1] = array[0] * result[0] + array[1];
    return result;
}

double[] GetArrayFromString (string stringArray){
    string[] nums = stringArray.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    double[] res = new double[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        res[i] = double.Parse(nums[i]);
    }
    return res;
}