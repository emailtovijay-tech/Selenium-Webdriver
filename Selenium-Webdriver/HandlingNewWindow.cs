using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Webdriver
{
    internal class HandlingNewWindow
    {
        [Test]
        public void HandleNewWindows()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//button[@id='PopUp']")).Click();

            var maintab = driver.CurrentWindowHandle;
            var Alltabs = driver.WindowHandles;

            foreach (string tab in Alltabs)

                if (tab != maintab)
                {
                    driver.SwitchTo().Window(tab); // Switching to new Window
                    break;
                }

            driver.Manage().Window.Maximize();
            driver.Quit();


        }
    }
}
