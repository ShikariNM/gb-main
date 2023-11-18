package sem5.sem;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;

public class Task0 {
    public static void main(String[] args) {
        // System.setProperty("webdriver.firefox.driver", "/Users/nikitamavrinsky/Documents/Study/GeekBrains/repo/unit_tests_java/lib/selenium-java-4.15.0/selenium-safari-driver-4.15.0-sources.jar");
        WebDriver driver = new FirefoxDriver();
        driver.get("http://google.com");
        WebElement searchBox = driver.findElement(By.name("q"));
        searchBox.sendKeys("GeekBrains");
        searchBox.submit();
        try { Thread.sleep(10000);}
        catch (InterruptedException e) {System.out.println("trouble");}
        driver.quit();
    }
}
