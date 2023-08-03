int[] array = {23, 54, 96, 76, 38, 96, 21, 53, 64};

int n = array.Length;
int find = 96;

int index = 0;

while(index < n){
    if(array[index] == find){
        Console.WriteLine(index);
        break;
    }
    index += 1;
}