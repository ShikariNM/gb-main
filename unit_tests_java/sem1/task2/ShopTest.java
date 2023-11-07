package sem1.task2;

import static org.assertj.core.api.Assertions.*;

public class ShopTest {
    public static void main(String[] args) {
        Shop shop = new Shop(
            new Product("one", 123),
            new Product("two", 321),
            new Product("three", 111),
            new Product("four", 987),
            new Product("five", 678)
        );

        shop.sortProductsByPrice();
        assertThat(shop.productRange).isSorted();
        assertThat(shop.getMostExpensiveProduct().charge).isEqualTo(987);

        shop = new Shop(
            new Product("one", 6),
            new Product("two", 3),
            new Product("three", 8),
            new Product("four", 1),
            new Product("five", 7)
        );

        shop.sortProductsByPrice();
        assertThat(shop.productRange).isSorted();
        assertThat(shop.getMostExpensiveProduct().charge).isEqualTo(8);
    }
}
