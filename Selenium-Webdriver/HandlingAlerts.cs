using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium_Webdriver
{
    internal class HandlingAlerts
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

            driver.FindElement(By.XPath("//button[@id='alertBtn']")).Click();
            //Switching to NormalAlert
            IAlert NormalAlert = driver.SwitchTo().Alert();
            String Alerttext = NormalAlert.Text;
            Console.WriteLine(Alerttext);
          
            NormalAlert.Accept();
  
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='confirmBtn']")).Click();
            //Switching to Confirmation Alert
            IAlert ConfirmAlert = driver.SwitchTo().Alert();
            ConfirmAlert.Dismiss();
            // ConfirmAlert.Accept();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@id='promptBtn']")).Click();
            //Switching to Prompt Alert
            IAlert PromptAlert = driver.SwitchTo().Alert();
            PromptAlert.SendKeys("Potter");
            PromptAlert.Accept();

            driver.Close();






        }
    }
}
