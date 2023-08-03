package s1;
import java.util.Random;

public class Program {

    public static int randomNum(int min, int max) {
        return new Random().nextInt(min, max);
    }

    public static int maxBitNum(int num) {
        int n = -1;
        while (num > 0) {
            n++;
            num /= 2;
        }
        return n;
    }

    public static int[] getArrayLengths(int i, int n, int min, int max) {
        int[] res = new int[2];
        int multiples = -1 * min / n + max / n + 1; // "+ 1" is zero
        res[0] = -1 * min / n + i / n + 1; // m2 length
        res[1] = multiples - res[0]; // m1 length
        if (i % n == 0) res[1]++;
        return res;
    }

    public static int[] getArray(int length, int n, int start, int end) {
        int[] array = new int[length];
        for (int indx = 0, j = start; j <= end; j++) {
            if (j % n == 0) {
                array[indx++] = j;
            }
        }
        return array;
    }

    public static void main(String[] args) {
        // 1
        // Исключил 0 и 1 из рандома для i, поскольку делить на 0 нельзя.
        int i = randomNum(2, 2000);
        System.out.println("i = " + i);
        // 2
        int n = maxBitNum(i);
        System.out.println("n = " + n);

        int min = Short.MIN_VALUE;
        int max = Short.MAX_VALUE;
        // 3
        int[] length = getArrayLengths(i, n, min, max);
        System.out.println("m1 length = " + length[1]);
        System.out.println("m2 length = " + length[0]);
        // 4
        int[] m1 = getArray(length[1], n, i, max);
        int[] m2 = getArray(length[0], n, min, i);
        // не стал выводить массивы, т.к. слишком много строк
    }
}
