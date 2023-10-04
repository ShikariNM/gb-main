package s1;
public class task3 {
    public static void main(String[] args) {
        
    }

    public int[] divArrays(int[] a, int[] b){
        // Введите свое решение ниже
            if (a.length != b.length) return new int[]{0};
            else{
                int[] res = new int[a.length];
                for (int i = 0; i < res.length; i++) {
                    try{
                        res[i] = a[i] / b[i];
                    }
                    catch (RuntimeException e){
                        
                    }
                }
                return res;
            }
      }
}
