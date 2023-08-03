int n = 1;
void FindWords(string alphabet, char[] word, int length = 0){
    if (length == word.Length){
        Console.WriteLine($"{n++} {new String(word)}");
        return;
    }
    for (int i = 0; i < alphabet.Length; i++)
    {
        word[length] = alphabet[i];
        FindWords(alphabet, word, length+1);
    }
}

FindWords("abcd", new char[2]);

// string path = "/Users/nikitamavrinsky/Documents/Учеба/С#/Examples/Example001";
// DirectoryInfo di = new DirectoryInfo(path);
// Console.WriteLine(di.CreationTime);
// FileInfo[] fi = di.GetFiles();
// for (int i = 0; i < fi.Length; i++)
// {
//     Console.WriteLine(fi[i].Name);
// }

// void CatalogInfo (string path, string indent = ""){
//     DirectoryInfo catalog = new DirectoryInfo(path);
//     DirectoryInfo[] catalogs = catalog.GetDirectories();
//     for (int i = 0; i < catalogs.Length; i++)
//     {
//         Console.WriteLine($"{indent}{catalogs[i].Name}");
//         CatalogInfo(catalogs[i].FullName, indent + "  ");
//     }
//     FileInfo[] files = catalog.GetFiles();
//     for (int i = 0; i < files.Length; i++)
//     {
//         Console.WriteLine($"{indent}{files[i].Name}");
//     }
// }

// string path = "/Users/nikitamavrinsky/Documents/Учеба/С#/Examples/Example001";
// CatalogInfo(path);

// void Towers(string with = "1", string on = "3", string some = "2", int count = 4){
//     if(count > 1) Towers(with, some, on, count - 1);
//     Console.WriteLine($"{with} >> {on}");
//     // Console.WriteLine(with);
//     if(count > 1) Towers(some, on, with, count - 1);
// }

// Towers();