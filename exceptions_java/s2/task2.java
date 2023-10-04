package s2;

import java.util.Random;

public class task2 {
    // Не очень понятно какая именно ошибка имеется в виду.
    // Сделал как понял.
    static Random random = new Random();

    public static void main(String[] args) {
        int[] intArray = new int[random.nextInt(8, 10)];
        try {
            int d = random.nextInt(2);
            double catchedRes1 = intArray[8] / d;
            System.out.println("catchedRes1 = " + catchedRes1);
        } catch (ArithmeticException | ArrayIndexOutOfBoundsException e) {
            System.out.println("Catching exception: " + e);
        }
    }
}
