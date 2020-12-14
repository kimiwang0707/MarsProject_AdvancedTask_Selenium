using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;
using System.Threading;
using System.Diagnostics;
//using OpenQA.Selenium.Support.PageObjects;
//using PageFactory = SeleniumExtras.PageObjects.PageFactory;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Base.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion




        internal void LoginSteps(IWebDriver driver)
        {
            // extent reports
            Base.test = Base.extent.StartTest("Login steps test");

            //Populate excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Wait Element
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[contains(text(),'Sign')]", 10);

            // Click signin tab to signin page
            SignIntab.Click();

            // Input username
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            // Input password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click Login button
            LoginBtn.Click();

            // Verify the login status                      
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']" +
                "//div[1]/div[2]/div/span", 10);         

            var greeting = driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[1]/div[2]/div/span")).Text;
            //Assert.That(loginName, Contains.Substring("Kimi"));
            if (greeting.Contains("Hi"))
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Login Successful");
            }
            else
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Login failed");
                Assert.Fail("Failed to login");
            }


        }
    }
}