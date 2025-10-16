using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Webdriver
{
    internal class HandlingiFrame
    {

        [Test]
        public void HandleiFrame()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://ui.vision/demo/webtest/frames/");
            driver.Manage().Window.Maximize();


            IWebElement Frame1 =  driver.FindElement(By.XPath("//frame[@src = 'frame_1.html']"));
            driver.SwitchTo().Frame(Frame1);  // Passed Frame as WebElement
            driver.FindElement(By.XPath("//input[@name='mytext1']")).SendKeys("Frame1");
            driver.SwitchTo().DefaultContent(); // Retrun from iFrame

 
            IWebElement Frame2 = driver.FindElement(By.XPath("//frame[@src = 'frame_2.html']"));
            driver.SwitchTo().Frame(Frame2);  // Passed Frame as WebElement
            driver.FindElement(By.XPath("//input[@name='mytext2']")).SendKeys("Frame2");
            driver.SwitchTo().DefaultContent(); // Retrun from iFrame


            IWebElement Frame3 = driver.FindElement(By.XPath("//frame[@src = 'frame_3.html']"));

            driver.SwitchTo().Frame(Frame3);  // Passed Frame as WebElement

            driver.FindElement(By.XPath("//input[@name='mytext3']")).SendKeys("Frame3");

            driver.SwitchTo().Frame(0);  // Switching to inner iframe which is inside the Frame 3 and only one iframe is there so used the Index as 0.

            driver.FindElement(By.XPath("//div[@aria-label = 'I am a human' ]")).Click();


            Thread.Sleep(2000);

            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0, 300);");

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//div[@aria-label='Web Testing']")).Click();

            Thread.Sleep(2000);

            JS.ExecuteScript("window.scrollBy(0, 200);");

            driver.FindElement(By.XPath("//span[normalize-space()='Choose']")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//div[@role='option']//span[@class='vRMGwf oJeWuf'][normalize-space()='Yes']")).Click();

            driver.SwitchTo().ParentFrame();  // Go back to Parent frame

            driver.SwitchTo().DefaultContent(); // Go back to Main page

            driver.Close();













        }

       
    }
}
