package sem4.sem.database;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import java.util.Arrays;
import java.util.List;

import org.junit.Test;

public class DatabaseTest {
    @Test
    public void processDataTest() {
        Database mockDb = mock(Database.class);
        DataProcessor dp = new DataProcessor(mockDb);
        String sql = "sql";
        List<String> data = Arrays.asList("Data1", "Data2", "Data3");
        when(mockDb.query(sql)).thenReturn(data);
        assertEquals(data, dp.processData(sql));
        verify(mockDb, times(1)).query(sql);
    }
}
