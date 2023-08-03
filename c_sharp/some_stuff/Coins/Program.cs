Console.Clear();
int[] array = new int[100];
int index = 0;
while (index < 100){
    array[index] = new Random().Next(0, 2);
    index += 1;
}

int ind = 0;
int count0 = 0;
int count1 = 0;
while (ind < 100){
    if (array[ind] == 0) count0 = count0 +=1;
    else{
        count1 = count1 += 1;
    }
    ind +=1;
}
Console.WriteLine($"0 = {count0}");
Console.WriteLine($"1 = {count1}");

index = 0;
if (count0 < count1){
    while (index < 100){
        if (array[index] == 0) array[index] = 1;
        Console.Write(array[index]);
        index = index +=1;
    }
}
else{
    while (index < 100){
        if (array[index] == 1) array[index] = 0;
        Console.Write(array[index]);
        index = index +=1;
    }
}