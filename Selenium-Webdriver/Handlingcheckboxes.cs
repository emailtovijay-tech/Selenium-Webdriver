using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Webdriver
{
    internal class Handlingcheckboxes
    {
        [Test]
        public void HandleCheckboxes()
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


            IList<IWebElement> Checkboxes = driver.FindElements(By.XPath("//input[@class='form-check-input' and @type = 'checkbox']"));

            int Totalchecks = Checkboxes.Count();

            // Selecting all the checkboxes
            for (int i = 0; i < Totalchecks; i++)
            {
                Checkboxes[i].Click();
            }

            //Select only last three check boxes
            for (int i = Totalchecks - 3; i < Totalchecks; i++)
            {
                Checkboxes[i].Click();
            }

            driver.Close();


        }
    }
}
