package O;

public abstract class Vehicle implements SpeedCalculation{
    int maxSpeed;
    String type;
    double speedCoefficient;

    public Vehicle(int maxSpeed, String type, double speedCoefficient) {
        this.maxSpeed = maxSpeed;
        this.type = type;
        this.speedCoefficient = speedCoefficient;
    }

    public int getMaxSpeed() {
        return this.maxSpeed;
    }

    public String getType() {
        return this.type;
    }

    public double calculateAllowedSpeed(Vehicle vehicle) {
        return vehicle.getMaxSpeed() * speedCoefficient;
    }
}