package sem4.sem.weather;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import org.junit.Test;

public class WetherTest {
    @Test
    public void generateReportTest() {
        WeatherService mockWeathServ = mock(WeatherService.class);
        WeatherReporter weathRep = new WeatherReporter(mockWeathServ);
        when(mockWeathServ.getCurrentTemperature()).thenReturn(25);
        assertEquals("Текущая температура: 25 градусов.", weathRep.generateReport());
        verify(mockWeathServ, times(1)).getCurrentTemperature();
    }
}
