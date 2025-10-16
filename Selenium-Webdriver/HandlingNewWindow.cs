using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection.Metadata;

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

            Thread.Sleep(3000);

            // Getting all window handles in a collection
            IReadOnlyCollection<string> windowsIDs = driver.WindowHandles;

            //Converted it to List collection
            List<string> windowsList = windowsIDs.ToList();

            String ParentWindow = windowsList[0];

            String ChildSeleniumwindow = windowsList[1];

            String ChildPlaywritewindow = windowsList[2];

            driver.SwitchTo().Window(ChildSeleniumwindow);
            driver.Manage().Window.Maximize();

            driver.SwitchTo().Window(ChildPlaywritewindow);
            driver.Manage().Window.Maximize();

            // If we have many windows then we can handle through for each loop


            foreach (String winid in windowsIDs)
            {
                String title = driver.SwitchTo().Window(winid).Title;
                Console.Write(title);

                if (title.Contains("Playwright"))
                {
                    driver.Close();
                }

                
            }

            driver.Quit();







        }
    }
}
