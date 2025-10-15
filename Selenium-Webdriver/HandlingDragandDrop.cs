using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Script;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;


namespace Selenium_Webdriver
{
    internal class HandlingDragandDrop
    {
        [Test]
        public void HandleDragandDrop()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();


            // Scroll down by 1500 pixels
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0, 1500);");
          

            IWebElement Source = driver.FindElement(By.XPath("//p[normalize-space()='Drag me to my target']"));
            IWebElement Target = driver.FindElement(By.XPath("//div[@id='droppable']"));

            Thread.Sleep(3000);
            Actions DD = new Actions(driver);

            // Draging the source and droping it to Target
            DD.ClickAndHold(Source).MoveToElement(Target).Perform();

            driver.Close();




        }
    }
}
