using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Webdriver
{
    internal class HandlingdoubleClick
    {
        [Test]
        public void HandledoubleClick()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            // Scroll down by 1300 pixels
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0, 1300);");

            Thread.Sleep(2000);
            String Field1text = driver.FindElement(By.XPath("//input[@id='field1']")).GetAttribute("value");
            IWebElement button = driver.FindElement(By.XPath("//button[normalize-space()='Copy Text']"));
            Actions DC = new Actions(driver);
            DC.DoubleClick(button).Perform();

           String Field2text = driver.FindElement(By.XPath("//input[@id='field2']")).GetAttribute("value");

            Assert.AreEqual(Field1text, Field2text, "Text is not copied after double click");
        }
        }
}
