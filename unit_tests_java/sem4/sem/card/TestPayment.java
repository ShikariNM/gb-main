package sem4.sem.card;

import static org.mockito.Mockito.*;

import org.junit.Test;

public class TestPayment {
    @Test
    public void paymentTest() {
        CreditCard mockCard = mock(CreditCard.class);
        // when(mockCard.getCardNumber()).thenReturn("1234");
        // when(mockCard.getCardHolder()).thenReturn("NIKITA");
        // when(mockCard.getExpiryDate()).thenReturn("12.12.23");
        // when(mockCard.getCvv()).thenReturn("123");
        PaymentForm pForm = new PaymentForm(mockCard);
        pForm.pay(100);
        verify(mockCard, times(1)).charge(100);
    }
}
