package s1;
public class task2 {
    public static void main(String[] args) {
        
    }

    public int[] subArrays(int[] a, int[] b){
        // Введите свое решение ниже
        if (a.length != b.length) return new int[]{0};
        else{
            int[] res = new int[a.length];
            for (int i = 0; i < res.length; i++) {
                res[i] = a[i] - b[i];
            }
            return res;
        }
    }
}
