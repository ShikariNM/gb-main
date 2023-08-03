// Напишите программу, которая будет выдавать название дня недели по заданному номеру.

// 3 -> Среда
// 5 -> Пятница

Console.Clear();
Console.Write ("Enter the number of the day: ");
int dayNumber = int.Parse (Console.ReadLine ());
if (dayNumber < 1 || dayNumber > 7){Console.WriteLine ("Enter correct value");
return;
}
if (dayNumber == 1){Console.WriteLine ("Mondey");
}
if (dayNumber == 2){Console.WriteLine ("Tuesday");
}
if (dayNumber == 3){Console.WriteLine ("Wednesday");
}
if (dayNumber == 4){Console.WriteLine ("Thursday");
}
if (dayNumber == 5){Console.WriteLine ("Friday");
}
if (dayNumber == 6){Console.WriteLine ("Saturday");
}
if (dayNumber == 7){Console.WriteLine ("Sunday");
}