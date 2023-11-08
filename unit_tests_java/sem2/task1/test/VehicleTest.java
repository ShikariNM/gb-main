package sem2.task1.test;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

import sem2.task1.src.Car;
import sem2.task1.src.Motorcycle;
import sem2.task1.src.Vehicle;

class VehicleTest {
    Car car = new Car("Suzuki", "Jimny", 2018);
    Motorcycle moto = new Motorcycle("Triumph", "Bonneville", 2020);

    @Test
    void beingVehicleTest() {
        assertTrue(car instanceof Vehicle);
    }

    @Test
    void carHasFourWheelsTest() {
        assertEquals(4, car.getNumWheels());
    }

    @Test
    void motorcycleHasTwoWheelsTest() {
        assertEquals(2, moto.getNumWheels());
    }

    @Test
    void carTestDriveSpeedTest() {
        car.testDrive();
        assertEquals(60, car.getSpeed());
    }

    @Test
    void motorcycleTestDriveSpeedTest() {
        moto.testDrive();
        assertEquals(75, moto.getSpeed());
    }

    @Test
    void carParkTest() {
        car.testDrive();
        car.park();
        assertEquals(0, car.getSpeed());
    }

    @Test
    void motocycleParkTest() {
        moto.testDrive();
        moto.park();
        assertEquals(0, moto.getSpeed());
    }
}