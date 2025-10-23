using Mailosaur;
using System.Threading;
using Mailosaur.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Core;

namespace MFAHandling
{
    internal class MFAHandle
    {
        // Replace with your Mailosaur credentials
        string apiKey = "i8YL1WLMC8qrcrvJYQmliHznGHh2kQJB";
        string serverId = "ff8ofqo5";
        string serverDomain = "ff8ofqo5.mailosaur.net";
        string otp;

        public string GetRandomEmail()
        {
           return "Sample" + "@" + serverDomain;
        }

        [Test]
        public void TestMailExample()
        {
            // Generate a unique test email
            string emailId = GetRandomEmail();

            // Launch Chrome
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://groww.in");

            // Enter the dynamically generated email ID
            driver.FindElement(By.XPath("//span[normalize-space()='Login/Sign up']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='login_email1']")).SendKeys(emailId);
            driver.FindElement(By.XPath("//button[@type='button']")).Click();

            // Wait for the OTP email
            var mailosaur = new MailosaurClient(apiKey);

            var criteria = new SearchCriteria()
            {
                SentTo = emailId
            };

            Console.WriteLine("Waiting for OTP email...");

            Message message = mailosaur.Messages.Get(serverId, criteria, timeout:5000);


            Console.WriteLine("Email received!");

            Console.WriteLine("Subject: " + message.Subject);

            // Extract OTP using regex if needed
            string body = message.Text.Body;
            Console.WriteLine("Body: " + body);

            string subject = message.Subject;

            // Example: extract 6-digit OTP

            var otpMatch = System.Text.RegularExpressions.Regex.Match(subject, @"\b\d{6}\b");
             if (otpMatch.Success)
             {
                 otp = otpMatch.Value;
                 Console.WriteLine("OTP: " + otp);
                 // You can now enter this OTP into the web app
             }
             else
             {
                 Console.WriteLine("No OTP found in email.");
             }

           // Now enter OTP on the webpage (if there’s an input field for OTP)

                driver.FindElement(By.XPath("//input[@id='signup_otp1']")).SendKeys(otp);
                driver.FindElement(By.XPath("//div[@class='col l12 leeos194LoginButton']")).Click();

            driver.Close();

        }
    }
}