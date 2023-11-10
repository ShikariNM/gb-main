package sem4.sem.hotel;

import static org.junit.Assert.*;
import static org.mockito.Mockito.*;

import org.junit.Test;

public class HotelTest {
    @Test
    public void bookRoomTest() {
        HotelService mockHotServ = mock(HotelService.class);
        BookingService bookServ = new BookingService(mockHotServ);
        int roomId = 37;
        when(mockHotServ.isRoomAvailable(roomId)).thenReturn(false);
        assertFalse(bookServ.bookRoom(roomId));
        verify(mockHotServ, times(1)).isRoomAvailable(roomId);
    }
}
