using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Webdriver
{
    internal class Handlingmultiselectdropdowns
    {
        [Test]
        public void Handledropdowns()
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

            // Selecting the value from the multi select drop down
            for (int i = 1; i <= 7; i++)
            {
                IWebElement multiselect = driver.FindElement(By.XPath("//select[@id='colors']//option[" + i + "]"));
                String color = multiselect.Text;

                if (color.Equals("Green"))
                {
                    multiselect.Click();
                    break;
                }
            }

            Thread.Sleep(2000);

            driver.Close();

        }
    }
}
