Console.Clear();
//Type 1
void Method1 (){
    Console.WriteLine("Author is ...");
}

//Method1();

//Type 2
void Method2 (string msg){
    Console.WriteLine(msg);
}
//Method2(msg: "Message text");

void Method21 (string msg, int count){
    int i = 0;
    while (i<count){
        Console.WriteLine(msg);
        i += 1;
    }
}

//Method21 (msg: "Text",count: 4);
//Method21 (count: 4, msg: "New text");

//Type 3
int Method3(){
    return DateTime.Now.Year;
}
//int year = Method3();
//Console.WriteLine(year);

//Type 4
// string Method4(int count, string c){
//     int i = 0;
//     string result = String.Empty;
//     while(i < count){
//         result = result + c;
//         i += 1;
//     }
//     return result;
// }

string Method4(int count, string c){
    string result = String.Empty;
    for (int i = 0; i < count; i += 1){
        result = result + c;
    }
    return result;
}

// string res = Method4(10,"asdf");
// Console.WriteLine(res);

// for (int i = 2; i <= 10; i++)
// {
//     for (int j = 2; j <= 10; j++)
//     {
//         Console.WriteLine($"{i} x {j} = {i*j}");
//     }
//     Console.WriteLine();
// }

//=====Работа с текстом
// Дан текст. В тексте нужно все пробелы заменить чёрточками, // маленькие буквы “к” заменить большими “К”,
// а большие “С” маленькими “с”.
// Ясна ли задача?

string text = "— Я думаю, — сказал князь, улыбаясь, — что,"
            + "ежели бы вас послали вместо нашего милого Винценгероде,"
            + "вы бы взяли приступом согласие прусского короля."
            + "Вы так красноречивы. Вы дадите мне чаю?";

string Replace(string text, char oldValue, char newValue){
    string result = String.Empty;
    int length = text.Length;
    for (int i = 0; i < length; i++)
    {
        if (text[i] == oldValue) result = result + $"{newValue}";
        else result = result + $"{text[i]}";
    }
    return result;
}

// string newText = Replace(text, ' ', '_');
// Console.WriteLine(newText);
// Console.WriteLine();
// string newTextK = Replace(newText, 'к', 'К');
// Console.WriteLine(newTextK);
// Console.WriteLine();
// string newTextC = Replace(newTextK, 'С', 'с');
// Console.WriteLine(newTextC);

//Sort

int[] arr = {1, 2, 3, 4, 5};

void PrintArray (int[] array){
    int count = array.Length;
    for (int i = 0; i < count; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

void SelectionSort(int[] array){
    for (int i = 0; i < array.Length - 1; i++)
    {
        int maxPosition = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if(array[j] > array[maxPosition]) maxPosition = j;
            int temporary = array[i];
            array[i] = array[maxPosition];
            array[maxPosition] = temporary;
            PrintArray(array);
        }
    }
}


PrintArray(arr);
SelectionSort(arr);
PrintArray(arr);