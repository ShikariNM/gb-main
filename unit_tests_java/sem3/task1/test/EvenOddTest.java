package sem3.task1.test;

import static sem3.task1.src.EvenOdd.evenOddNumber;

import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

public class EvenOddTest {

    @ParameterizedTest
    @ValueSource(ints = {-14, 0, 2, 1030})
    void evenNumberTest(int number) {
        assertTrue(evenOddNumber(number));
    }

    @ParameterizedTest
    @ValueSource(ints = {-17, 37, 177})
    void oddNumberTest(int number) {
        assertFalse(evenOddNumber(number));
    }
}
