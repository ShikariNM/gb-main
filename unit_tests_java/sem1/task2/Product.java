package sem1.task2;

public class Product implements Comparable<Product>{
    String name;
    float charge;

    public Product(String name, float charge) {
        this.name = name;
        this.charge = charge;
    }

    @Override
    public int compareTo (Product another) {
        return Math.round(this.charge - another.charge);
    }

    @Override
    public String toString() {
        return this.name;
    }
}
