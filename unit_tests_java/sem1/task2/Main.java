package sem1.task2;

public class Main {
    public static void main(String[] args) {
        Shop shop = new Shop(
            new Product("one", 123),
            new Product("two", 321),
            new Product("three", 111),
            new Product("four", 987),
            new Product("five", 678)
        );

        shop.sortProductsByPrice();
        System.out.println(shop.productRange.toString());

        Product mostExpensiveProduct = shop.getMostExpensiveProduct();
        System.err.println(mostExpensiveProduct.toString());
    }
}
