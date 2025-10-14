using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Webdriver
{
    internal class HandlingSingleSelectDropDown
    {
        [Test]
        public void Handledropdowns()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Scroll down by 500 pixels
            js.ExecuteScript("window.scrollBy(0, 500);");

            // Selecting the value from the single selection drop down
            IWebElement Singleselectdropdwon = driver.FindElement(By.XPath("(//select[@id='country'])"));

            SelectElement DP = new SelectElement (Singleselectdropdwon);

            DP.SelectByIndex(5);
            DP.SelectByValue("uk");
            DP.SelectByText("India");

            Thread.Sleep(2000);

            driver.Close();

        }

    }
}
