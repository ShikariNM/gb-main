package s5;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

public class Program {
    public static void main(String[] args) {

        HashMap<String, ArrayList<String>> phonebook = new HashMap<>();
        
        putNumber(phonebook, "Захаров Андрей Генадьевич", "8 953 582 68 36");
        putNumber(phonebook, "Абакаров Александр Сергеевич", "8 934 234 54 64");
        putNumber(phonebook, "Бондаренко Юрий Александрович", "8 324 572 54 32");
        putNumber(phonebook, "Борисов Роберт Николаевич", "8 924 737 75 67");
        putNumber(phonebook, "Захаров Андрей Генадьевич", "8 523 629 97 89");
        putNumber(phonebook, "Борисов Роберт Николаевич", "8 925 682 89 04");
        putNumber(phonebook, "Захаров Андрей Генадьевич", "8 984 046 04 86");
        putNumber(phonebook, "Абакаров Александр Сергеевич", "8 932 874 45 62");
        putNumber(phonebook, "Захаров Андрей Генадьевич", "8 903 374 68 83");
        putNumber(phonebook, "Борисов Роберт Николаевич", "8 962 563 52 90");

        printSortedNumbers(phonebook);
    }


    public static void putNumber
    (HashMap<String, ArrayList<String>> phonebook, String name, String number) {

        if (phonebook.containsKey(name)) phonebook.get(name).add(number);
        else phonebook.put(name, new ArrayList<String>(Arrays.asList(number)));
    }


    public static void printSortedNumbers
    (HashMap<String, ArrayList<String>> phonebook) {

        List<String> names = new ArrayList<>(phonebook.keySet());

        Collections.sort(names, new Comparator<String>() {
            @Override
            public int compare(String o1, String o2) {
                return phonebook.get(o2).size() - phonebook.get(o1).size();
            }
        });

        System.out.println();
        names.forEach(n -> System.out.println(
            n + ": " +
            phonebook.get(n).stream()
            .map(m -> String.valueOf(m))
            .collect(Collectors.joining(", "))));
    }
}
