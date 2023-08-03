package s3;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.Random;

public class Program {
    public static void main(String[] args) {

        ArrayList<Integer> list = new ArrayList<>();
        for (int i = 0; i < 15; i++) {
            list.add(new Random().nextInt(99));
        }
        System.out.println(list);

        Iterator<Integer> iter = list.iterator();
        while (iter.hasNext()) {
            if (iter.next() % 2 == 0) iter.remove();
        }
        System.out.println(list);
        // Оказалось, удаляя элемент из итератора, мы удаляем его
        // и из родительского списка. О_о

        list.sort(null);
        Integer min = list.get(0);
        System.out.println(min);

        Collections.reverse(list);
        Integer max = list.get(0);
        System.out.println(max);
        
        Float sum = 0f;
        for (Integer el : list) {
            sum += el;
        }
        Float mean = sum / list.size();
        System.out.printf("%.2f %n", mean);
    }
}
