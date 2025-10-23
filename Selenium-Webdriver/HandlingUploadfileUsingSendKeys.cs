using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium_Webdriver
{
    internal class HandlingUploadfileUsingSendKeys
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

           // Uploading Single file using the ID locator and send the path in Sendkeys directly

            driver.FindElement(By.XPath("//input[@id='singleFileInput']")).SendKeys(@"C:\Users\user\Downloads\TestUploadFile.xls");
            driver.FindElement(By.XPath("//button[normalize-space()='Upload Single File']")).Click();
            String ExpectedSingleUploadtext = driver.FindElement(By.XPath("//p[@id='singleFileStatus']")).Text;
            String ActualSingleUploadtext = "Single file selected: TestUploadFile.xls, Size: 23552 bytes, Type: application/vnd.ms-excel";
            Assert.That(ActualSingleUploadtext, Is.EqualTo(ExpectedSingleUploadtext), "Single file upload text is wrong");
            Thread.Sleep(2000); 
           

            // Uploading Multi file using the ID locator and send the path in Sendkeys directly

            driver.FindElement(By.XPath("//input[@id='multipleFilesInput']")).SendKeys(@"C:\Users\user\Downloads\TestUploadFile.xls" + "\n" + @"C:\Users\user\Downloads\TestUploadFile2.xls");
            driver.FindElement(By.XPath("//button[normalize-space()='Upload Multiple Files']")).Click();
            String ExpectedMultiUploadtext = driver.FindElement(By.XPath("//p[@id='multipleFilesStatus']")).Text;
            String ActualMultiUploadtext = "Multiple files selected:\r\nTestUploadFile.xls, Size: 23552 bytes, Type: application/vnd.ms-excel\r\nTestUploadFile2.xls, Size: 23552 bytes, Type: application/vnd.ms-excel";
            Assert.That(ActualMultiUploadtext, Is.EqualTo(ExpectedMultiUploadtext), "Multi file upload text is wrong");

            driver.Close();

        }

    }
}
