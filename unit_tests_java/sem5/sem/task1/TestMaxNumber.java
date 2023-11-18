package sem5.sem.task1;

import static sem5.sem.task1.RandomNumbers.getNumbers;
import static sem5.sem.task1.FindMaxNumber.getMaxNumber;

import java.util.Collections;
import java.util.Arrays;

import static org.junit.Assert.assertEquals;
import org.junit.Test;

public class TestMaxNumber {
    @Test
    public void getNumbersTest() {
        assertEquals(getNumbers().getClass(), Integer[].class);
    }

    @Test
    public void getMaxNumberTest() {
        assertEquals(getMaxNumber(new Integer[] {1,2,3,4}), (Integer) 4);
    }

    @Test
    public void fullTest() {
        Integer[] array = getNumbers();
        assertEquals(Collections.max(Arrays.asList(array)), getMaxNumber(array));
    }
}