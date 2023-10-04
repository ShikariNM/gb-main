package s2;

import java.util.Scanner;

public class task1 {
    public static void main(String[] args) {
        float f = floatInput();
        System.out.println(f);
    }

    public static float floatInput(){
        Scanner scanner = new Scanner(System.in);
        boolean done = false;
        float res = 0f;
        while (! done){
            try {
                System.out.print("Enter the number: ");
                res = Float.parseFloat(scanner.nextLine());
                done = true;
            }
            catch(NumberFormatException e){
            }
        }
        scanner.close();
        return res;
    }
}
