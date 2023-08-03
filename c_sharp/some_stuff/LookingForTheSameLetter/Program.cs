Console.Clear();
string ABC = "hrRteeIIIEElgoIIIetbBbBbs";
string DEF = ABC.ToLower();
int length = ABC.Length;
int count = 1;
int maxCount = 1;
char letter = DEF[0];
for (int i = 1; i < length; i++)
{
    if(DEF[i] == DEF[i-1]){
        count += 1;
    }
    else{
        count = 1;
    }
    if(count > maxCount) {
        maxCount = count;
        letter = DEF[i];
    }
}
Console.WriteLine($"The max quantity of the same letter in a row is {maxCount}");
Console.WriteLine($"The letter is {letter}");