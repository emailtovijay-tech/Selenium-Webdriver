using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium_Webdriver
{
    internal class HandlingNewTabWindow
    {
        [Test]
        public void HandleNewTabWindows()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//button[normalize-space()='New Tab']")).Click();

            var maintab = driver.CurrentWindowHandle;
            var Alltabs = driver.WindowHandles;

            foreach (string tab in Alltabs)

                if (tab != maintab)
                {
                driver.SwitchTo().Window(tab); // Switching to new tab
                    break;
                }

            String Header = driver.FindElement(By.XPath("//h1[normalize-space()='SDET-QA Blog']")).Text;
            Assert.AreEqual(Header, "SDET-QA Blog");

            driver.Quit();
        }


     }
}
