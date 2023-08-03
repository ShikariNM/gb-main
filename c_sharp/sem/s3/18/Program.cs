// Напишите программу, которая по заданному номеру четверти,
// показывает диапазон возможных координат точек в этой четверти (x и y).

Console.Clear();
Console.Write("Enter the quarter number: ");
int numQ = int.Parse (Console.ReadLine ());
switch (numQ){
    case 1:{
        Console.WriteLine("+X, +Y");
        break;
    }
    case 2:{
        Console.WriteLine("-X, +Y");
        break;
    }
    case 3:{
        Console.WriteLine("-X, -Y");
        break;
    }
    case 4:{
        Console.WriteLine("+X, -Y");
        break;
    }
    default: {
        Console.WriteLine ("Enter correсt number");
        break;
    }
}
// }
// if (numQ < 1 || numQ > 4){
//     Console.WriteLine ("Enter correсt number");
// }
// if (numQ == 1){
    
// }
// if (numQ == 2){
    
// }
// if (numQ == 3){
    
// }
// if (numQ == 4){
    
// }