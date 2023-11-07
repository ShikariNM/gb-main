package sem1.task1;

import static org.assertj.core.api.Assertions.*;

public class CalculatorTest {
    public static void main(String[] args) {
        assertThat(Calculator.calculateDiscount(900, 10)).isEqualTo(810);
        assertThat(Calculator.calculateDiscount(123.97f, 17.13f)).isEqualTo(102.73f);
        assertThatThrownBy(() -> Calculator.calculateDiscount(-1, 10))
            .isInstanceOf(ArithmeticException.class);
        assertThatThrownBy(() -> Calculator.calculateDiscount(10, -1))
            .isInstanceOf(ArithmeticException.class);
        assertThatThrownBy(() -> Calculator.calculateDiscount(10, 110))
            .isInstanceOf(ArithmeticException.class);
    }
}
