package sem1.task2;

import java.util.ArrayList;
import java.util.Collections;

public class Shop {
    ArrayList<Product> productRange;

    public Shop(Product ... products) {
        productRange = new ArrayList<>();
        for (Product product : products) {
            productRange.add(product);
        }
    }

    public void sortProductsByPrice() {
        Collections.sort(productRange);
    }

    public Product getMostExpensiveProduct() {
        Collections.reverse(productRange);
        return productRange.get(0);
    }
}
