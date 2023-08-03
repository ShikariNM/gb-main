void FillArray (int[] collection){
    int length = collection.Length;
    int index = 0;
    while (index < length){
        collection[index] = new Random().Next(1, 10);
        index += 1;
    }
}

void PrintArray(int[] col){
    int count = col.Length;
    int position = 0;
    while (position < count){
        Console.Write($"{col[position]}, ");
        position += 1;
    }
}

Console.Clear();

int IndexOf(int[] collection, int find){
    int count =  collection.Length;
    int index = 0;
    int position = -1;
    while (index < count){
        if (collection[index] == find){
            position = index;
            break;
        }
        index += 1;
    }
    return position;
}


int[] array = new int[15];

FillArray(array);

array[4] = 4;
array[12] = 4;

PrintArray(array);
Console.WriteLine();

int pos = IndexOf(array,421);
Console.WriteLine(pos);