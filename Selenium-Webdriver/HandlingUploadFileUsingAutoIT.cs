using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;


namespace Selenium_Webdriver
{
    internal class HandlingUploadFileUsingAutoIT
    {

        [Test]
        public void HandleUploadfile()

        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0, 1500);");

            Thread.Sleep(3000);

            // uploading using AutoIt tool

            IWebElement Uploadbutton = driver.FindElement(By.XPath("//input[@id='singleFileInput']"));

            Actions act = new Actions (driver);
            act.MoveToElement(Uploadbutton).Click().Perform();
            Thread.Sleep(2000);

            Process.Start(@"C:\Users\user\Desktop\Fileupload.exe", @"C:\Users\user\Downloads\TestUploadFile.xls");

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//button[normalize-space()='Upload Single File']")).Click();

            String ExpectedSingleUploadtext = driver.FindElement(By.XPath("//p[@id='singleFileStatus']")).Text;
            String ActualSingleUploadtext = "Single file selected: TestUploadFile.xls, Size: 23552 bytes, Type: application/vnd.ms-excel";
            Assert.That(ActualSingleUploadtext, Is.EqualTo(ExpectedSingleUploadtext), "Single file upload text is wrong");
            Thread.Sleep(2000);
            driver.Close();

        }

        }
}
