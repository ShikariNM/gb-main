package O;

public class Car extends Vehicle {

    public Car(int maxSpeed, String type, double speedCoefficient) {
        super(maxSpeed, type, speedCoefficient);
    }

    public Car(int maxSpeed, String type) {
        this(maxSpeed, type, 0.8f);
    }
}
