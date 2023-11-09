package sem3.task2.test;

import static sem3.task2.src.Interval.numberInIterval;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

public class IntervalTest {
    @ParameterizedTest
    @ValueSource(ints = {26, 66, 99})
    void numberInItervalTest(int number) {
        assertTrue(numberInIterval(number));
    }

    @ParameterizedTest
    @ValueSource(ints = {-13, 0, 25, 100, 1501})
    void numberNotInItervalTest(int number) {
        assertFalse(numberInIterval(number));
    }
}
