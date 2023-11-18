package sem5.sem.task1;

import static sem5.sem.task1.RandomNumbers.getNumbers;
import static sem5.sem.task1.FindMaxNumber.getMaxNumber;

public class Main {
    public static void main(String[] args) {
        System.out.println(getMaxNumber(getNumbers()));
    }
}
