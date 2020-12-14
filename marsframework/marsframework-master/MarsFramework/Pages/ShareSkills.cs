using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.IO;
using MarsFramework.Config;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkills
    {
        public ShareSkills()
        {
            PageFactory.InitElements(Base.driver, this);
        }

        #region Initialize Web Elements
        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillBtn { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropdown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropdown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]//input")]
        private IWebElement Tags { get; set; }

        //Enter Start Date 
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateInputArea { get; set; }

        //Enter End Date 
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateInputArea { get; set; }

        //Enter Skill Exchange tag
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        // Click on Upload the work samples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement UploadIcon { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }


        #endregion



        internal void EnterShareSkill(IWebDriver driver)
        {
            // Populate data saved in excel to collection
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ShareSkillPath, "ShareSkill");

            // Click ShareSkill Button 
            GlobalDefinitions.WaitForElementClickable(driver, "LinkText", "Share Skill", 5);
            ShareSkillBtn.Click();

            // Wait Elements on new page
            GlobalDefinitions.WaitForTextPresentInElement(driver, Title, "", 10);

            // Enter Title from excel
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            // Enter Description from excel
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            // Select Category from Excel
            GlobalDefinitions.WaitForElement(driver, "Name", "categoryId", 10);

            new SelectElement(CategoryDropdown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            new SelectElement(SubCategoryDropdown).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            // Enter tags from excel
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            // Choose Service Type radio button from excel
            IWebElement ServiceTypeRadioBtn = driver.FindElement(By.XPath("//input[@name='serviceType' " +
                "and @value='" + GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") + "'] "));
            ServiceTypeRadioBtn.Click();

            // Choose Location Type radio button from excel
            IWebElement LocationTypeRadioBtn = driver.FindElement(By.XPath("//input[@name='locationType' " +
                "and @value='" + GlobalDefinitions.ExcelLib.ReadData(2, "LocationType") + "']"));
            LocationTypeRadioBtn.Click();

            // Enter Available days from excel
            // *** Enter start date and end date ***
            StartDateInputArea.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            EndDateInputArea.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));

            // *** Set loop for days checkbox ***
            for (int rows = 2; rows < 9; rows++)
            {
                var sr = GlobalDefinitions.ExcelLib.ReadData(rows, "SelectDay").ToString();
                if (sr != null && sr != "")
                {
                    // Select checkbox
                    IWebElement DaysCheckbox = driver.FindElement(By.XPath("//input[@name='Available' " +
                "and @index='" + GlobalDefinitions.ExcelLib.ReadData(rows, "SelectDay") + "']"));
                    DaysCheckbox.Click();

                    // Enter start time
                    IWebElement StartTimeInputArea = driver.FindElement(By.XPath("//input[@name='StartTime' " +
                        "and @index='" + GlobalDefinitions.ExcelLib.ReadData(rows, "SelectDay") + "']"));
                    StartTimeInputArea.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rows, "StartTime"));

                    // Enter end time
                    IWebElement EndTimeInputArea = driver.FindElement(By.XPath("//input[@name='EndTime' " +
                       "and @index='" + GlobalDefinitions.ExcelLib.ReadData(rows, "SelectDay") + "']"));
                    EndTimeInputArea.SendKeys(GlobalDefinitions.ExcelLib.ReadData(rows, "EndTime"));
                }
                else
                {
                    break;
                }
            }


            // Choose Skill Trade radio button 
            try
            {
                string SkillTradeTypeExcel = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade").ToString();
                IWebElement SkillTradeRadioBtn = driver.FindElement(By.XPath("//input[@name='skillTrades' " +
                    "and @value='" + SkillTradeTypeExcel + "']"));
                SkillTradeRadioBtn.Click();

                // Condition1: Enter Skill-Exchange from excel-------Condition2: Enter Credit            
                if (SkillTradeTypeExcel == "true")
                {
                    SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange Tag"));
                    SkillExchange.SendKeys(Keys.Enter);
                }
                if (SkillTradeTypeExcel == "false")
                {
                    try
                    {
                        var CreditExcel = Convert.ToDecimal(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));

                        if (0 <= CreditExcel && CreditExcel <= 10)
                        {
                            CreditAmount.SendKeys(CreditExcel.ToString());
                        }
                        else
                        {
                            Assert.Fail("Please enter a number between 0-10.");
                        }
                    } catch (Exception e)
                    {
                        Assert.Fail("Credit input is illegal, please check format!", e.Message);
                    }
                }


            } catch (Exception ex)
            {
                Assert.Fail("Test failed at choosing skill trade type", ex.Message);
            }



            //Upload document from the path saved in excel, if it's input type, then can send path directly
            // Option 1: SendKeys
            //try
            //{
            //    IWebElement upload = driver.FindElement(By.XPath("//input[@id='selectFile']"));
            //    // Uploading File path
            //    var SampleWorkPath = MarsResource.SampleWorkPath;
            //    string fullPath = System.IO.Path.GetFullPath(SampleWorkPath);
            //    upload.SendKeys(fullPath);
            //}
            //catch (Exception e)
            //{
            //    Assert.Fail("Failed to upload work sample", e.Message);
            //}

            // Option 2: AutoIt
            //driver.FindElement(By.ClassName("huge plus circle icon padding-25")).Click(); //Class Name Shouldn't have space inside, or use xpath or css.
            driver.FindElement(By.CssSelector("i[class='huge plus circle icon padding-25']")).Click();
        
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            // Must wait input text ready to input or will lose part of the url
            AutoIt.WinWaitActive("Open", "Edit", 3);

            var SampleWorkPath = MarsResource.SampleWorkPath;
            AutoIt.Send(Path.GetFullPath(SampleWorkPath));
            Thread.Sleep(1500);
            AutoIt.Send("{ENTER}");


            // Choose Active radio button
            GlobalDefinitions.WaitForElement(driver, "XPath", "//i[@class='remove sign icon floatRight']", 10);
            IWebElement IsActiveRadioBtn = driver.FindElement(By.XPath("//input[@name='isActive' and" +
                " @value='" + GlobalDefinitions.ExcelLib.ReadData(2, "Active") + "']"));
            IsActiveRadioBtn.Click();

            // Click Save Button to save all data
            Save.Click();

        }

    
        internal void VerifyEnterShareSkill(IWebDriver driver)
        {
            // Wait element turn up &  Verify part info on default manage listing page
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='listing-management-section']" +
                "//tr[1]/td[8]/div/button[1]/i", 10);

            // Verify Title           
            var titleExpected = driver.FindElement(By.XPath("//*[@id='listing-management-section']" +
                "//tbody/tr[1]/td[3]")).Text;
            Assert.That(titleExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));
                      
            // Verify Category
            var categoryExpected = driver.FindElement(By.XPath("//*[@id='listing-management-section']" +
                "//tbody/tr[1]/td[2]")).Text;
            Assert.That(categoryExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Category")));

            // Verify Tags
            // Not available now on this page

            // Verify Service Type
            var serviceTypeExpected = driver.FindElement(By.XPath("//*[@id='listing-management-section']" +
                "//tbody/tr[1]/td[5]")).Text;
            if(serviceTypeExpected == "Hourly")
            {
                serviceTypeExpected = "0";
                Assert.That(serviceTypeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")));
            }
            if (serviceTypeExpected == "One-off")
            {
                serviceTypeExpected = "1";
                Assert.That(serviceTypeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")));
            }         

            // Verify Skill Trade / Two conditions
            string skillTradeExpected = driver.FindElement(By.XPath("//*[@id='listing-management-section']" +
                "//tbody/tr[1]/td[6]")).GetAttribute("class").ToString();
            if (skillTradeExpected == "grey remove circle large icon")
            {
                skillTradeExpected = "false";
                Assert.That(skillTradeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")));
            }
            else if (skillTradeExpected == "blue check circle outline large icon")
            {
                skillTradeExpected = "true";
                Assert.That(skillTradeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")));
            }

            // Verify Active
            // Not available


            // Verify remaining parts on detail page
            // Click eye icon and wait element turn up
            driver.FindElement(By.XPath("//*[@id='listing-management-section']" +
                "//tr[1]/td[8]/div/button[1]/i")).Click();

            IWebElement titleOnDetailsPage = driver.FindElement(By.XPath("//span[@class='skill-title']"));
            GlobalDefinitions.WaitForTextPresentInElement(driver, titleOnDetailsPage, GlobalDefinitions.ExcelLib.ReadData(2, "Title"), 10);

            // Verify Description
            var descriptionExpected = driver.FindElement(By.XPath("//*[@id='service-detail-section']" +
                "/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]//div[2]")).Text;
            Assert.That(descriptionExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));

            // Verify Location Tyoe
            var locationTypeExpected = driver.FindElement(By.XPath("//*[@id='service-detail-section']" +
                "//div[1]//div[2]//div[3]//div[3]//div[2]")).Text;
            if (locationTypeExpected == "On-Site")
            {
                locationTypeExpected = "0";
                Assert.That(locationTypeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")));
            }
            if (locationTypeExpected == "Online")
            {
                locationTypeExpected = "1";
                Assert.That(locationTypeExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")));
            }

            // Verify Subcategory
            var subCategoryExpected = driver.FindElement(By.XPath("//*[@id='service-detail-section']" +
                "//div[2]/div[2]/div//div[2]//div[2]/div/div[2]")).Text;
            Assert.That(subCategoryExpected, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory")));

            // Verify Available days and time
            var startDateExpected = driver.FindElement(By.XPath("//*[@id='service-detail-section']" +
                "//div[3]/div/div[1]/div/div[2]")).Text;
            var startDateExcel = GlobalDefinitions.ExcelLib.ReadData(2, "StartDate");
            DateTime startDt = DateTime.Parse(startDateExcel);
            var startDateFormat = startDt.ToString("yyyy-MM-dd");
            Assert.That(startDateExpected, Is.EqualTo(startDateFormat));

            var endDateExpected = driver.FindElement(By.XPath("//*[@id='service-detail-section']" +
                "//div[2]//div[3]//div[2]//div[2]")).Text;
            var endDateExcel = GlobalDefinitions.ExcelLib.ReadData(2, "EndDate");
            DateTime endDt = DateTime.Parse(endDateExcel);
            var endDateFormat = endDt.ToString("yyyy-MM-dd");
            Assert.That(endDateExpected, Is.EqualTo(endDateFormat));

        }
    }
}
