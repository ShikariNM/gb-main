package sem5.sem;

import static org.junit.Assert.assertEquals;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;

public class Task5 {
    @Test
    public void TestAithorisation() {
        System.setProperty("webdriver.firefox.driver", "/Users/nikitamavrinsky/Documents/Study/GeekBrains/repo/unit_tests_java/lib/selenium-java-4.15.0/selenium-firefox-driver-4.15.0.jar");
        WebDriver driver = new FirefoxDriver();
        driver.get("https://www.saucedemo.com/");
        WebElement username = driver.findElement(By.id("user-name"));
        username.sendKeys("standard_user");
        WebElement password = driver.findElement(By.id("password"));
        password.sendKeys("secret_sauce");
        WebElement login = driver.findElement(By.id("login-button"));
        login.click();
        WebElement label = driver.findElement(By.className("title"));
        assertEquals("Products", label.getText());
        try { Thread.sleep(3000);}
        catch (InterruptedException e) {System.out.println("trouble");}
        driver.quit();
    }
}
