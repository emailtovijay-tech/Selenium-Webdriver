using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Webdriver
{
    internal class HandlingTextboxes
    {
   
        [Test]
        public void HandleTextfields()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//input[@id='name']")).SendKeys("Smith");
            driver.FindElement(By.XPath("//input[@placeholder='Enter EMail']")).SendKeys("smithd@test.com");
            driver.FindElement(By.XPath("//input[@id='phone']")).SendKeys("1234567890");
            driver.FindElement(By.XPath("//textarea[@id='textarea']")).SendKeys("This text is added by Automation Team");
           
            // Pause the execution for 2 seconds
            Thread.Sleep(2000);
            
            //Closing the Browser
            driver.Close();


        }
    }
}
