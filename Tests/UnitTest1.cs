using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();

        [Fact]
        public void Test1()
        {
            driver.Url = "https://localhost:7279/";
            driver.Navigate().GoToUrl(driver.Url);

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/a[2]"));
            loginButton.Click();

            IWebElement usernameField = driver.FindElement(By.XPath("//*[@id=\"Username\"]"));
            usernameField.Click();
            usernameField.SendKeys("admin");

            IWebElement passwordField = driver.FindElement(By.XPath("//*[@id=\"Password\"]"));
            passwordField.Click();
            passwordField.SendKeys("praseta123");

            IWebElement submitButton = driver.FindElement(By.XPath("/html/body/div/main/div/form/input[1]"));
            submitButton.Click();

            driver.Close();
        }
    }
}