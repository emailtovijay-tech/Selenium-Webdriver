using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Webdriver
{
    internal class HandlingScrolls
    {

        [Test]
        public void HandleAlert()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0, 500);");

            JS.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");


            IWebElement element = driver.FindElement(By.XPath("//h2[normalize-space()='Footer Links']"));

            JS.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            driver.Close();

        }

        }
}
