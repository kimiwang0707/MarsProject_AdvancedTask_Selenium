using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SearchSkills
    {
        public SearchSkills()
        {
            PageFactory.InitElements(Base.driver, this);
        }

        #region Initialize web elements

        //Click on Search icon
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement SearchIcon { get; set; }

        // Category list
        [FindsBy(How = How.XPath, Using = "//div[@role='list']")]
        private IWebElement CategoryList { get; set; }

        // Sub-Category list
        [FindsBy(How = How.XPath, Using = "//a[@class='item subcategory']")]
        private IWebElement SubCategoryList { get; set; }

        //Click on Filter - Online
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[5]/button[1]")]
        private IWebElement FilterOnline { get; set; }

        //Click on Filter - Onsite
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[5]/button[2]")]
        private IWebElement FilterOnsite { get; set; }

        //Click on Filter - ShowAll
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[5]/button[3]")]
        private IWebElement FilterShowAll { get; set; }

        // Total Pages
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[2]/div/button[last()-1]")]
        private IWebElement Pages { get; set; }

        //Click on Next Page
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']//div[2]/div/button[last()]")]
        private IWebElement SkipToNextPage{ get; set; }

        #endregion


        #region Search Skills By Categories
        internal void SearchSkillsByCategories(IWebDriver driver)
        {
            // Populate the excel data into system
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillPath, "ShareSkill");

            // Wait and click on Search icon
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//i[@class='search link icon']", 10);
            SearchIcon.Click();

            // Wait, Click on Category and Sub-Category
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//*[@id='service-search-section']//section/div/div[1]/div[1]/div/a[last()]", 10);
            IWebElement Category = driver.FindElement(By.XPath("//a[contains(text(), '" 
                + GlobalDefinitions.ExcelLib.ReadData(2, "Category") +"')]"));
            Category.Click();

            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//a[@class='item subcategory']", 10);
            IWebElement SubCategory = driver.FindElement(By.XPath("//a[contains(text(), '"
                + GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory") + "')]"));
            SubCategory.Click();

            // Test extent report
            Base.test.Log(LogStatus.Pass, "Search Skills by Category sucessfully!");
        }

        internal void VerifySearchSkillsByCategories(IWebDriver driver)
        {
            // Wait
            //GlobalDefinitions.WaitForElementClickable(driver, "XPath",
            //        "//*[@id='service-search-section']//div[2]/div/button[last()-1]", 10);
            Thread.Sleep(1000);

            // Search results on page, if find results stop, if no jump to next page
            int totalPages = int.Parse(Pages.Text);
            //Debug.WriteLine("The total page is:" + totalPages);
            int count;
            for(count = 0; count < totalPages; count++)
            {
                // Wait 
                //GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                //    "//*[@id='service-search-section']//div[last()]/div[1]/a[2]/p", 10);
                Thread.Sleep(1000);

                // Find results
                try
                {
                    driver.FindElement(By.XPath("//p[text()='Breakdancing']"));
                    Base.test.Log(LogStatus.Pass, "Verify Search Skills successfully!");
                    return;
                } catch(NoSuchElementException)
                {
                    try
                    {
                        SkipToNextPage.Click();
                    } catch(Exception)
                    {
                        break;
                    }
                }
            }
            Base.test.Log(LogStatus.Fail, "Failed to verify Search Skills!");
            Assert.Fail("Failed to verify search skills!");

        }
        #endregion



        #region Search Skills By Filters
        int totalResults;
        int onlineResults;
        int onsiteResults;
        int showAllResults;
        internal void SearchSkillsByFilters(IWebDriver driver)
        {
            // Wait and click on Search icon
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//i[@class='search link icon']", 10);
            SearchIcon.Click();

            // Wait and check total results
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/button[2]", 10);
            totalResults = int.Parse(driver.FindElement(By.XPath("//*[@id='service-search-section']//" +
                "div[1]/div[1]/div/a[1]/span")).Text);

            // Check online results
            FilterOnline.Click();
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/button[2]", 10);
            onlineResults = int.Parse(driver.FindElement(By.XPath("//*[@id='service-search-section']//" +
                "div[1]/div[1]/div/a[1]/span")).Text);

            // Check onsite results
            FilterOnsite.Click();
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/button[2]", 10);
            onsiteResults = int.Parse(driver.FindElement(By.XPath("//*[@id='service-search-section']//" +
                "div[1]/div[1]/div/a[1]/span")).Text);

            // Check show all results
            FilterShowAll.Click();
            GlobalDefinitions.WaitForElementClickable(driver, "XPath",
                "//*[@id='service-search-section']//div[2]/div/button[2]", 10);
            showAllResults = int.Parse(driver.FindElement(By.XPath("//*[@id='service-search-section']//" +
                "div[1]/div[1]/div/a[1]/span")).Text);

            // Extent report
            Base.test.Log(LogStatus.Pass, "Search skills by filter successfully!");
        }

        internal void VerifySearchSkillsByFilters(IWebDriver driver)
        {
            if (onlineResults + onsiteResults == totalResults && totalResults == showAllResults)
            {
                //Debug.WriteLine(onlineResults + "****" + 
                //    onsiteResults + "****" + showAllResults + "****" + totalResults);
                Base.test.Log(LogStatus.Pass, "Verify search skills by filter successfully!");      
            }
            else
            {
                //Debug.WriteLine(onlineResults + "****" +
                //    onsiteResults + "****" + showAllResults + "****" + totalResults);
                Base.test.Log(LogStatus.Fail, "Failed to verify search skills by filter!");
                Assert.Fail("Test failed to verify search skills by filter!");
            }

        }

        #endregion
    }
}
