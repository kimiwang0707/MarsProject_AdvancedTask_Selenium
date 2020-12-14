using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ManageRequestsLink
    {
        public ManageRequestsLink()
        {
            PageFactory.InitElements(Base.driver, this);
        }

        #region Initialize Web Element
        //Click on Manage Requests Link
        [FindsBy(How = How.XPath, Using = "//div[@class='ui dropdown link item']")]
        private IWebElement manageRequestsLink { get; set; }

        //Click on Sent Requests Link
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentRequestsLink { get; set; }

        //Click on Search icon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement SearchIcon { get; set; }

        // Search User input field
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search user']")]
        private IWebElement SearchUserInput { get; set; }

        // Dropdown 1st Option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div/div[2]/div[1]/div/img")]
        private IWebElement DropdownFirstOpt { get; set; }

        // Result 1st Option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[2]/div/div[2]/div/div/div[1]/a")]
        private IWebElement ResultFirstOpt { get; set; }

        // Request Button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui teal  button']")]
        private IWebElement RequestButton { get; set; }

        // Confirm YES button
        [FindsBy(How = How.XPath, Using = "//button[@class='ui button ui teal button']")]
        private IWebElement ConfirmButtonYes { get; set; }

        // Withdraw Sending Request
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']//tr[1]/td[8]/button")]
        private IWebElement WithdrawRequest { get; set; }
        
        //Click on Received Requests Link
        [FindsBy(How = How.LinkText, Using = "Received Requests")]
        private IWebElement ReceivedRequestsLink { get; set; }
        #endregion


        string skillTitle;
        // Send Request
        internal void SendRequest(IWebDriver driver)
        {
            // Populate the excel data into system
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Wait and click on Search icon
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//i[@class='search link icon']", 10);
            SearchIcon.Click();

            // Wait and Enter name in Search user part
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//input[@placeholder='Search user']", 10);
            SearchUserInput.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Name"));

            // Wait and Choosse the first one option
            Thread.Sleep(1000);
            DropdownFirstOpt.Click();

            // Wait and Choose the first one result
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/div/div[1]/a/img", 10);
            ResultFirstOpt.Click();

            // Wait, Record Skill Name and Click on Request
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//div[@class='ui teal  button']", 10);
            skillTitle = driver.FindElement(By.ClassName("skill-title")).Text;

            RequestButton.Click();

            // Wait and click on YES
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//button[@role='button']", 10);
            ConfirmButtonYes.Click();
        }

        // Verify Sent-Requests
        internal void VerifySendRequest(IWebDriver driver)
        {
            // Wait and Click on the Manage Requests tab
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//div[@class='ui dropdown link item']", 10);        
            manageRequestsLink.Click();

            // Wait and click on dropdown menu the second option: Sent requests
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//a[@class='item' and @href='/Home/SentRequest']", 10);
            SentRequestsLink.Click();

            // Wait and Assert if the title skill is equal to recorded skill
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]/a", 10);
            string skillTitleExpected = driver.FindElement(By.XPath("" +
                "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]/a")).Text;

            if (skillTitle == skillTitleExpected)
            {
                // Withdraw the request to facilitate following tests
                WithdrawRequest.Click();
                Base.test.Log(LogStatus.Pass, "Verify sending request successfully!");
            }
            else
            {
                Assert.Fail("Failed to verify sending request");
            }


        }

        // Received Request
        internal void ReceivedRequest(IWebDriver driver)
        {
            // Wait and Click on the Manage Requests tab
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//div[@class='ui dropdown link item']", 10);
            manageRequestsLink.Click();

            // Wait and click on received requests button
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//a[@class='item' and @href='/Home/ReceivedRequest']", 10);
            ReceivedRequestsLink.Click();
            Base.test.Log(LogStatus.Pass, "View received requests successfully!");
        }

        // Verify Received-Request
        internal void VerifyReceivedRequest(IWebDriver driver)
        {
            // Verify the page
            GlobalDefinitions.WaitForElement(driver, "XPath",
                "//*[@id='received-request-section']/div[2]/h2", 10);
            string webTitle = driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/h2")).Text;

            if (webTitle == "Received Requests")
            {
                Base.test.Log(LogStatus.Pass, "Verify received requests successfully!");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Failed to verify received requests");
                Assert.Fail("Test failed to verify received requests");
            }

        }



    }
}
