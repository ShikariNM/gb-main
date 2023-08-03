Console.Clear();

// Получаем входные данные от пользователя. Добавил переменную количества символов,
// из которых состоят искомые элементы. По условию задачи  num = 3.

Console.WriteLine("Default number of symbols of sougth-for element is 3");
Console.WriteLine("Would you like to change the number?");
Console.Write("Type \"y\" or \"n\": ");
string userResponse = Console.ReadLine()!;
int num;
if (userResponse == "y"){
    Console.Write("Enter the number: ");
    num = int.Parse(Console.ReadLine()!);
}
else if (userResponse == "n"){
    Console.WriteLine("OK! Default value has been set.");
    num = 3;
}
else {
    Console.WriteLine("Invalid response format. Try again!");
    return;
}
Console.Write("Enter the array elements with spaces: ");
string input = Console.ReadLine()!;

// Преобразуем входную строку в массив, который является объектом, данным по условию задачи

string[] array = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

// Три метода решения задачи. Хотя в условии задачи рекомендовано избегать использования
// коллекций, решил, что, в качестве дополнительного метода, можно.

if (SeveralSymbolElements1(array, num).Length > 0){
    Console.WriteLine($"[{string.Join(" ", SeveralSymbolElements1(array, num))}]");// Метод №1
    Console.WriteLine($"[{string.Join(" ", SeveralSymbolElements2(array, num))}]");// Метод №2
    Console.WriteLine($"[{string.Join(" ", SeveralSymbolElements3(array, num))}]");// Метод №3
}
else Console.WriteLine("There is no element, that meets the set conditions, in the array");

// Метод №1
string[] SeveralSymbolElements1(string[] inArray, int number){
    string result = string.Empty;
    foreach (var element in inArray){
        if(element.Length <= number) result += element + " ";
    }
    return result.Split(" ", StringSplitOptions.RemoveEmptyEntries);
}

// Метод №2
string[] SeveralSymbolElements2(string[] inArray, int number){
    int count = 0;
    for (int i = 0; i < inArray.Length; i++){
        if (inArray[i].Length <= number) count++;
    }
    string[] result = new string[count];
    for (int i = 0, j = 0; i < inArray.Length; i++){
        if (inArray[i].Length <= number){
            result[j] = inArray[i];
            j++;
        }
    }
    return result;
}

// Метод №3
string[] SeveralSymbolElements3(string[] inArray, int number){
    List<string> temp = new List<string>();
    foreach (var element in inArray){
        if (element.Length <= number) temp.Add(element);
    }
    string[] result = new string[temp.Count];
    temp.CopyTo(result);
    return result;
}