package sem1.task1;

public class Calculator {
    public static float calculateDiscount(float sum, float discount){
        if (sum < 0) throw new ArithmeticException("Стоимость не может быть отрицательной");
        else if (discount < 0) throw new ArithmeticException("Скидка не может быть отрицательной");
        else if (discount > 100) throw new ArithmeticException("Скидка не может быть больше 100%");
        return Math.round((sum * (1 - discount * 0.01f)) * 100) / 100f;
    }
}
