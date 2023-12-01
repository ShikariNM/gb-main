package O;

public class Bus extends Vehicle{

    public Bus(int maxSpeed, String type, double speedCoefficient) {
        super(maxSpeed, type, speedCoefficient);
    }

    public Bus(int maxSpeed, String type) {
        this(maxSpeed, type, 0.6f);
    }
}
