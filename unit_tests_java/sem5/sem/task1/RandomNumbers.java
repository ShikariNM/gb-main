package sem5.sem.task1;

import java.util.Random;

public class RandomNumbers {

    public static Integer[] getNumbers() {
        Integer[] array = new Integer[10];
        for (int i = 0; i < array.length; i++) {
            array[i] = new Random().nextInt(10);
        }
        return array;
    }
}
