package sem4.sem.message;

import static org.mockito.Mockito.*;

import org.junit.Test;

public class MessageTest {
    @Test
    public void sendNotificationTest() {
        MessageService mockMessServ = mock(MessageService.class);
        NotificationService noteServ = new NotificationService(mockMessServ);
        noteServ.sendNotification("message", "Nikita");
        verify(mockMessServ, times(1)).sendMessage("message", "Nikita");
    }
}
