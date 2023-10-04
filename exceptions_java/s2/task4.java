package s2;

import java.util.Scanner;

public class task4 {
    public static void main(String[] args) {
        String str = input();
        System.out.println(str);
    }

    public static String input() throws EmptyStringException{
        Scanner scanner = new Scanner(System.in);
        String res = scanner.nextLine();
        scanner.close();
        if (res == ""){
            throw new EmptyStringException("Запрещено вводить пустую строку");
        }
        return res;
    }
}

class EmptyStringException extends RuntimeException{
    public EmptyStringException(String message){
        super(message);
    }
}