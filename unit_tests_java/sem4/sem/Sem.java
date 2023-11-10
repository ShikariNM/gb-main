package sem4.sem;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;
import org.junit.Test;

import java.util.Iterator;

public class Sem {
    @Test
    public void iteratorWillReturnHelloWorld() {
        Iterator iteratorMock = mock(Iterator.class);
        when(iteratorMock.next()).thenReturn("Hello").thenReturn("World");
        String result = iteratorMock.next() + " " + iteratorMock.next();
        assertEquals("Hello World", result);
    }
}
