import java.util.Arrays;
import java.util.Random;

public class s2_hw {
    public static void main(String[] args) {
        int[] array = createArray();
        System.out.println(Arrays.toString(array));
        heapSort(array);
        System.out.println(Arrays.toString(array));
    }

    private static void heapify(int[] array, int heapSize, int root_idx){
        int largest = root_idx;
        int left = 2 * root_idx + 1;
        int right = 2 * root_idx + 2;

        if (left < heapSize && array[left] > array[largest]){
            largest = left;
        }
        if (right < heapSize && array[right] > array[largest]){
            largest = right;
        }
        if (array[largest] != array[root_idx]){
            array[largest] = array[largest] + array[root_idx];
            array[root_idx] = array[largest] - array[root_idx];
            array[largest] = array[largest] - array[root_idx];
            heapify(array, heapSize, largest);
        }
    }

    private static void heapSort(int[] array){
        for (int i = array.length / 2 - 1; i >= 0; i--) {
            heapify(array, array.length, i);
        }
        for (int i = array.length - 1; i > 0; i--) {
            array[0] = array[0] + array[i];
            array[i] = array[0] - array[i];
            array[0] = array[0] - array[i];
            heapify(array, i, 0);
        }
    }

    private static int[] createArray(int length, int min, int max){
        int[] array = new int[length];
        for (int i = 0; i < length; i++) {
            array[i] = new Random().nextInt(min, max);
        }
        return array;
    }

    private static int[] createArray(){
        return createArray(20, -10, 10);
    }
}
