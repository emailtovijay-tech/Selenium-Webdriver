using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium_Webdriver
{
    
    internal class HandlingRadiobuttons
    {

        [Test]
        public void HandleRadiobuttons()
        {
            // Launching the Browser
            IWebDriver driver = new ChromeDriver();

            // Global implicit wait 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");
            driver.Manage().Window.Maximize();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Scroll down by 500 pixels
            js.ExecuteScript("window.scrollBy(0, 500);");

            IWebElement MaleRadiobtn = driver.FindElement(By.XPath("//input[@id='male']"));
            IWebElement FemaleRadiobtn = driver.FindElement(By.XPath("//input[@id='female']"));

            Thread.Sleep(3000);

            // Selecting the Radio button

            if (MaleRadiobtn.Selected)
            {
                FemaleRadiobtn.Click();
            }
            else 
            {
                MaleRadiobtn.Click();
            }

            driver.Close();


        }
    }
}
