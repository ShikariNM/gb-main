// Вывести первые N строк треугольника Паскаля.
// Сделать вывод в виде равнобедренного треугольника.

//                 1
//               1   1
//             1   2   1
//           1   3   3   1
//         1   4   6   4   1
//       1   5   10  10  5   1             array[i] = previousArray[i] + previousArray[i-1]
//     1   6   15  20  15  6   1
//   1   7   21  35  35  21  7   1

// 1 (1 1) (1 2 1) (1 3 3 1) (1 4 9 4 1) (1 5 13 13 5 1)

// Для строк с четным кол-вом элементов основной цикл делает лишнюю итерацию,
// которая не влияет на результат.
// Этого можно было бы избежать сделав разные циклы для четных и нечетных строк,
// но я не знаю, будет ли это более оптимально - дополнять программу лишними строками
// и циклом, чтобы избежать одну итерацию для каждой четной строки. Поэтому оставил так.

Console.Clear();
Console.Write("Enter the number of Pascal's triangle lines you want to see: ");
int n = int.Parse(Console.ReadLine());
PascalTriangle(n);

void PascalTriangle(int n){
    if(n >= 1){
        Console.SetCursorPosition(60, 2); // выбрал за середину экрана
        Console.WriteLine("1");
    }
    int[] array = {1, 1};
    if(n >= 2){
        Console.SetCursorPosition(57, 3); // отцентровал
        Console.WriteLine($"{string.Join("     ", array)}");
    }
    if(n > 2){
        for (int j = 0; j < n - 2; j++)
        {
            int[] array1 = new int[array.Length+1];
            array1[array1.Length-1] = array1[0] = 1;
            array1[1] = array1[array1.Length-2] = array[1]+1;
            for (int i = 2; i <= array1.Length/2; i++)
            {
                array1[i] = array[i] + array[i-1];
                array1[array1.Length-1-i] = array1[i];
            }
            Console.SetCursorPosition(60 - string.Join("     ", array1).Length/2, j+4); // начало строки = центр - половина длины строки
            Console.WriteLine($"{string.Join("     ", array1)}");
            array = array1;
        }
    }
}