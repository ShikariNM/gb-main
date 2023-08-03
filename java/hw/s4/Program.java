// Организовать ввод и хранение данных пользователей. ФИО возраст и пол
// вывод в формате Фамилия И.О. возраст пол
// добавить возможность выхода или вывода списка отсортированного по возрасту!)
// *реализовать сортировку по возрасту с использованием индексов
// *реализовать сортировку по возрасту и полу с использованием индексов

package s4;

import java.util.ArrayList;
import java.util.Scanner;

public class Program {
    public static void main(String[] args) {

        String[] prompts = new String[] {
            "\nEnter last name: ",
            "Enter first name: ",
            "Enter patronymic: ",
            "Enter age: ",
            "Enter gender: "
        };
        Scanner input = new Scanner(System.in);
        ArrayList<String>[] mainArray = createArrayLists(prompts.length);
        System.out.println("\nEnter \"q\" to exit");
        boolean flag = true;

        while (flag) {

            // добавил массив temp, чтобы, при прерывании записи данных в ее середине,
            // в основном массиве не сохранялись неполные данные.
            String[] temp = new String[prompts.length];

            for (int i = 0; i < temp.length; i++) {
                System.out.print(prompts[i]);
                String userInput = input.nextLine();
                if (userInput.equals("q")) {
                    flag = false;
                    break;
                }
                else temp[i] = userInput;
            }
            if (flag) {
                for (int i = 0; i < mainArray.length; i++) {
                    mainArray[i].add(temp[i]);
                }
            }
        }
        System.out.println();
        printArrayLists(mainArray);

        System.out.print("\nWould you like to sort the list by age? Enter \"y\" to affirm: ");
        String userAns = input.nextLine();
        if (userAns.equals("y")) {
            sortArrayLists(mainArray, 3);
            printArrayLists(mainArray);
        }

        System.out.print("\nWould you like to sort the list by gender as well? Enter \"y\" to affirm: ");
        userAns = input.nextLine();
        if (userAns.equals("y")) {
            sortArrayLists(mainArray, 4);
            printArrayLists(mainArray);
        }

        input.close();
    }


    public static ArrayList<String>[] createArrayLists(int length) {

        ArrayList<String>[] array = new ArrayList[length];
        for (int i = 0; i < array.length; i++) {
            array[i] = new ArrayList<String>();
        }
        return array;
    }


    public static void printArrayLists(ArrayList<String>[] arrayLists) {

        for (int i = 0; i < arrayLists[0].size(); i++) {
            StringBuilder str = new StringBuilder(arrayLists[0].get(i));
            for (int j = 1; j < arrayLists.length; j++) {
                String el = arrayLists[j].get(i);
                if (j == 1 || j == 2) el = el.charAt(0) + ".";
                str.append(" " + el);
            }
            System.out.println(str.toString());
        }
    }


    public static int[] getSortedIndexes(ArrayList<String> list) {

        ArrayList<String> usedList = new ArrayList<>(list);
        ArrayList<String> sortedList = new ArrayList<>(list);
        sortedList.sort(null);
        int[] sortedIndexes = new int[usedList.size()];
        for (int i = 0; i < usedList.size(); i++) {
            int index = usedList.indexOf(sortedList.get(i));
            sortedIndexes[i] = index;
            usedList.set(index, null);
        }
        return sortedIndexes;
        // usedList создал, поскольку, если менять элементы в аргументе list,
        // то они меняются в mainArray в методе main.
    }


    public static void sortArrayLists
    (ArrayList<String>[] arrayLists, int attrNum) {
        
        int[] sortedIndexes = getSortedIndexes(arrayLists[attrNum]);
        for (int j = 0; j < arrayLists.length; j++) {
            ArrayList<String> temp = new ArrayList<>(arrayLists[j].size());
            for (int i : sortedIndexes) {
                temp.add(arrayLists[j].get(i));
            }
            arrayLists[j] = temp;
        }
    }
}
