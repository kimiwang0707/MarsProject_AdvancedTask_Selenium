using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        #region 
        // Profile Name used to be the benchmark to verify all contents turn up
        [FindsBy(How = How.ClassName, Using = "title")]
        private IWebElement profileName { get; set; }

        #endregion
        #region Availability Type
        //Click on Availability Edit button
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Time')]/i")]
        private IWebElement AvailabilityTimeEdit { get; set; }

        //Click on Availability Time dropdown
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement AvailabilityTime { get; set; }

        #endregion
        //*********************************************************************
        #region Availability Hours
        //Click on Availability Hour Edit button
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'30hours') or contains(text(),'As needed')]/i")]
        private IWebElement AvailabilityHoursEdit { get; set; }

        //Click on Availability Hour dropdown
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement AvailabilityHours { get; set; }

        #endregion
        //*********************************************************************
        #region Earn Target
        //Click on Salary Edit button
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'per month')]/i")]
        private IWebElement SalaryEdit { get; set; }

        //Click on Salary dropdown
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement Salary { get; set; }

        #endregion
        //*********************************************************************
        #region Location
        ////Click on Location
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div")]
        //private IWebElement Location { get; set; }

        ////Choose Location
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[2]/div/div[2]")]
        //private IWebElement LocationOpt { get; set; }

        ////Click on City
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div")]
        //private IWebElement City { get; set; }

        ////Choose City
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[2]/div/div[3]/div/div[2]")]
        //private IWebElement CityOpt { get; set; }
        #endregion
        //*********************************************************************
        #region Description
        // Click Add Description Icon
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'Description')]/span/i")]
        private IWebElement DescriptionEdit { get; set; }

        //Add Desctiption
        [FindsBy(How = How.XPath, Using = "//textarea[@name='value']")]
        private IWebElement Description { get; set; }

        //Click on Save Button
        [FindsBy(How = How.XPath, Using = "//div[@class='ui twelve wide column']/button")]
        private IWebElement DescriptionSave { get; set; }
        #endregion
        //*********************************************************************
        #region Language tab
        //Click Language Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='first']")]
        private IWebElement LanguageTab { get; set; }

        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//div[contains(text(),'Add New')]")]
        private IWebElement LanguageAddNewBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Language']")]
        private IWebElement LanguageName { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//select[@name='level']")]
        private IWebElement LanguageDropdownBox { get; set; }

        //Add Language
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//input[@value='Add']")]
        private IWebElement LanguageAddBtn { get; set; }

        //Delete Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[2]//div[2]//tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement LanguageDeleteBtn { get; set; }
        #endregion
        //*********************************************************************
        #region Skills Tab
        // Click Skills Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='second']")]
        private IWebElement SkillTab { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//div[contains(text(),'Add New')]")]
        private IWebElement SkillAddNewBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement SkillName { get; set; }

        //Click on skill level dropdown
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//select[@name='level']")]
        private IWebElement SkillDropdownBox { get; set; }

        //Add Skill
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//input[@value='Add']")]
        private IWebElement SkillAddBtn { get; set; }

        //Delete Skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[3]//div[2]//tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement SkillDeleteBtn { get; set; }
        #endregion
        //*********************************************************************
        #region Education Tab
        //Click Education Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='third']")]
        private IWebElement EducationTab { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//div[contains(text(),'Add New')]")]
        private IWebElement EducationAddNewBtn { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.XPath, Using = "//input[@name='instituteName']")]
        private IWebElement EducationName { get; set; }

        //Choose the country dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement EducationCountryDropdownBox { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='title']")]
        private IWebElement EducationTitleDropdownBox { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement EducationDegree { get; set; }

        //Year of graduation dropdown box
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement EducationGraduationYearDropdownBox { get; set; }

        // Click Add button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//input[@value='Add']")]
        private IWebElement EducationAddBtn { get; set; }

        //Delete Education
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[4]//div[2]//tbody[last()]/tr/td[6]/span[2]/i")]
        private IWebElement EducationDeleteBtn { get; set; }
        #endregion
        //*********************************************************************
        #region Certifications Tab
        //Click Certification Tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='fourth']")]
        private IWebElement CertificationTab { get; set; }

        //Click on Add New Button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//div[contains(text(),'Add New')]")]
        private IWebElement CertificationAddNewBtn { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        private IWebElement CertificationName { get; set; }

        //Enter Certified from
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement CertificationFrom { get; set; }

        //Click Year dropdown box
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement CertificationYearDropdownBox { get; set; }

        //Click Add Ceritification
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//input[@value='Add']")]
        private IWebElement CertificationAddBtn { get; set; }

        //Delete Certificate
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]//div[3]" +
            "/form/div[5]//div[2]//tbody[last()]/tr/td[4]/span[2]/i")]
        private IWebElement CertificateDeleteBtn { get; set; }
        #endregion

        #endregion


        // Enter Profile
        internal void EnterProfile()
        {
            // Populate the data saved in Excel to Collection
            try
            {
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            } catch (Exception e)
            {
                Assert.Fail("Test failed to populate in collection at entering profile step", e.Message);
            }
            #region  Enter Availability Type
            try
            {
                // Click Edit icon
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//span[contains(text(),'Time')]/i", 5);
                AvailabilityTimeEdit.Click();

                // Click dropdown menu
                AvailabilityTime.Click();

                // Choose Availability parttime; fulltime
                new SelectElement(AvailabilityTime).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Availability Type"));
                //Base.test.Log(LogStatus.Info, "Enter availability type successfully");
                Base.test.Log(LogStatus.Pass, "Enter availability type successfully");
            } catch(Exception ex)
            {
                Assert.Fail("Test failed to enter Availability Type", ex.Message);
            }
            #endregion

            #region Enter Availability Hours 
            try
            {
                // Click Edit icon
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//span[contains(text(),'30hours') or contains(text(),'As needed')]/i", 5);
                AvailabilityHoursEdit.Click();

                // Click dropdown menu
                AvailabilityHours.Click();

                // Select Hours 0-less than 30h; 1-more than 30h 2-as needed
                new SelectElement(AvailabilityHours).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Availability Hours"));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter availability successfully");
            } catch(Exception ex)
            {
                Assert.Fail("Test failed to enter Availability Hours", ex.Message);
            }
            #endregion

            #region Enter Earn Target 
            try
            {
                // Click Edit icon
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//span[contains(text(),'per month')]/i", 5);
                SalaryEdit.Click();

                // Click dropdown menu
                Salary.Click();

                // Click earn 0-less than 500; 1-500~1000; 2-more than 1000
                new SelectElement(Salary).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Earn Target"));
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter earn target successfully");
            } catch(Exception ex)
            {
                Assert.Fail("Test failed to enter Earn Target", ex.Message);
            }
            #endregion

            #region Enter Description
            try
            {
                // Click Edit icon  
                DescriptionEdit.Click();

                // Input description in text area
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//textarea[@name='value']", 5);
                Description.Clear();
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

                // Click Save
                DescriptionSave.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter description successfully");
            } catch (Exception ex)
            {
                Assert.Fail("Test failed to Enter Description",ex.Message);
            }
            #endregion

            #region Enter Language
            try
            {
                // Click Language tab
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[@data-tab='first']", 5);
                LanguageTab.Click();

                // Click Add New
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//div[@data-tab='first']//div[contains(text(),'Add New')]", 5);
                LanguageAddNewBtn.Click();

                // Enter Language
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//input[@placeholder='Add Language']", 5);
                LanguageName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

                // Choose Language level 0-basic; 1-conversational; 2-fluent; 3-native
                LanguageDropdownBox.Click();
                new SelectElement(LanguageDropdownBox).SelectByText
                    (GlobalDefinitions.ExcelLib.ReadData(2, "Language Level")); // Need using OpenQA.Selenium.Support.UI;

                // Click Add
                LanguageAddBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter language successfully");

            } catch(Exception ex)
            {
                Assert.Fail("Test failed to enter/add Language", ex.Message);
            }
            #endregion

            #region Enter Skills
            try
            {
                // Click Skills tab
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[@data-tab='second']", 5);
                SkillTab.Click();

                // Click Add New
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//div[@data-tab='second']//div[contains(text(),'Add New')]", 5);
                SkillAddNewBtn.Click();

                // Enter Skill
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//input[@placeholder='Add Skill']", 5);
                SkillName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

                // Choose Skill level 0-beginer; 1-intermediate; 2-expert
                SkillDropdownBox.Click();
                new SelectElement(SkillDropdownBox).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Level"));

                // Click Add
                SkillAddBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter skills successfully");

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to enter/add Skills", ex.Message);
            }
            #endregion

            #region Enter Education
            try
            {
                // Click Education tab
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[@data-tab='third']", 5);
                EducationTab.Click();

                // Click Add New
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//div[@data-tab='third']//div[contains(text(),'Add New')]", 5);
                EducationAddNewBtn.Click();

                // Enter University Name
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//input[@name='instituteName']", 5);
                EducationName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

                // Enter Degree
                EducationDegree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

                // Choose Country
                EducationCountryDropdownBox.Click();
                new SelectElement(EducationCountryDropdownBox).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));

                // Choose  Title 0-Associate; 1-B.A; 2-BArch; 3-BFA; 4-B.Sc...
                EducationTitleDropdownBox.Click();
                new SelectElement(EducationTitleDropdownBox).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

                // Choose Year
                EducationGraduationYearDropdownBox.Click();
                new SelectElement(EducationGraduationYearDropdownBox).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Graduation Year"));

                // Click Add
                EducationAddBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter education successfully");

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to enter/add Education", ex.Message);
            }
            #endregion

            #region Enter Certifications
            try
            {
                // Click Certifications tab
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//a[@data-tab='fourth']", 5);
                CertificationTab.Click();

                // Click Add New
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//div[@data-tab='fourth']//div[contains(text(),'Add New')]", 5);
                CertificationAddNewBtn.Click();

                // Enter Certificate name
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, "XPath", "//input[@name='certificationName']", 5);
                CertificationName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

                // Enter Issuing place
                CertificationFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

                // Choose Year
                CertificationYearDropdownBox.Click();
                new SelectElement(CertificationYearDropdownBox).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate Issuing Year"));

                // Click Add
                CertificationAddBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Enter certificate successfully");

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to enter/add Certificate", ex.Message);
            }
            #endregion

        }

        // Verify Enter-Profile
        internal void VerifyEnterProfile()
        {
            try
            {
                // Populate data saved in Excel
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

                // Refresh the page
                GlobalDefinitions.driver.Navigate().Refresh();

                // Wait for all text present in Element
                GlobalDefinitions.WaitForTextPresentInElement(GlobalDefinitions.driver, profileName,
                    GlobalDefinitions.ExcelLib.ReadData(2, "Name"), 10);

            } catch (Exception e)
            {
                Assert.Fail("Test failed to at preparation steps of verifying enter-profile", e.Message);
            }


            #region Verify Enter Availability Type
            try
            {
                var AvaiType = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/" +
                    "section[2]//div[2]//div[3]//div[2]/div/span")).Text;
                Assert.That(AvaiType, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Availability Type")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Availability Type", ex.Message);
            }
            #endregion

            #region Verify Enter Availability Hours
            try
            {
                var AvaiHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[2]//div[3]//div[3]/div/span")).Text;
                Assert.That(AvaiHours, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Availability Hours")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Availability Hours", ex.Message);
            }
            #endregion

            #region Verify Enter Earn Target
            try
            {
                var salary = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[2]//div[3]//div[4]/div/span")).Text;
                Assert.That(salary, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Earn Target")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Earn Target", ex.Message);
            }
            #endregion

            #region Verify Enter Description
            try
            {
                var description = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]/div/div/div/div[3]/div/div/div/span")).Text;
                Assert.That(description, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Description", ex.Message);
            }
            #endregion

            #region Verify Enter Language
            try
            {
                //Verify Language Name
                var lastRowLanguageName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowLanguageName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Language")));

                //Verify Language Level
                var lastRowLanguageLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[2]//div[2]//tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowLanguageLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Language Level")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Language", ex.Message);
            }
            #endregion

            #region Verify Skills
            try
            {
                //Jump to Skill tab
                SkillTab.Click();

                //Verify Skill Name
                var lastRowSkillName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowSkillName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Skill")));

                //Verify Skill Level
                var lastRowSkillLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[3]//div[2]//tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowSkillLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Level")));

            } catch(Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Skills", ex.Message);
            }
            #endregion

            #region Verify Education
            try
            {
                //Jump to Education tab
                EducationTab.Click();

                //Verify Education Country
                var lastRowEducationCountry = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowEducationCountry, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Country")));

                //Verify Education Name
                var lastRowEducationName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowEducationName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "University")));

                //Verify Education Title
                var lastRowEducationTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowEducationTitle, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));

                //Verify Education Degree
                var lastRowEducationDegree = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[4]")).Text;
                Assert.That(lastRowEducationDegree, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Degree")));

                //Verify Education Graduation Year
                var lastRowEducationGraduationYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[4]//div[2]//tbody[last()]/tr/td[5]")).Text;
                Assert.That(lastRowEducationGraduationYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Graduation Year")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Description", ex.Message);
            }

            #endregion

            #region Verify Certifications
            try
            {
                //Jump to Certification tab
                CertificationTab.Click();

                //Verify Certificate Name
                var lastRowCertificateName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowCertificateName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate")));

                //Verify Certificate Issuing Place
                var lastRowCertificateFrom = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowCertificateFrom, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom")));

                //Verify Certificate Year
                var lastRowCertificateYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']" +
                    "/div/section[2]//div[3]/form/div[5]//div[2]//tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowCertificateYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate Issuing Year")));

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Certificate", ex.Message);
            }
            #endregion


        }



        // Delete Profile
        internal void DeleteProfile()
        {
            try
            {
                // Populate data saved in Excel
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile"); 

                // Wait for all text present in Element
                GlobalDefinitions.WaitForTextPresentInElement(GlobalDefinitions.driver, profileName,
                    GlobalDefinitions.ExcelLib.ReadData(2, "Name"), 10);

            } catch (Exception e)
            {
                Assert.Fail("Test failed to wait element for deleting profile", e.Message);
            }

            #region Delete Language
            try
            {
                //Delete the last record
                LanguageTab.Click();
                LanguageDeleteBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete language successfully");
            }
            catch(NoSuchElementException e)
            {
                Assert.Fail("No records in list to delete, please add language first!", e.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete language", ex.Message);
            }
            #endregion

            #region Delete Skills
            try
            {
                //Delete last record
                SkillTab.Click();
                SkillDeleteBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete skill successfully");
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("No records in list to delete, please add skill first!", e.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete skill", ex.Message);
            }
            #endregion

            #region Delete Education
            try
            {
                //Delete last record
                EducationTab.Click();
                EducationDeleteBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete education successfully");
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("No records in list to delete, please add education first!", e.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Education", ex.Message);
            }
            #endregion

            #region Delete Certification
            try
            {
                //Delete last record
                CertificationTab.Click();
                CertificateDeleteBtn.Click();
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete certification successfully");
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("No records in list to delete, please add certification first!", e.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Certification", ex.Message);
            }
            #endregion
        }

        // Verify Delete-Profile
        internal void VerifyDeleteProfile()
        {
            try
            {
                // Populate data saved in Excel
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

                // Refresh the page
                GlobalDefinitions.driver.Navigate().Refresh();

                // Wait for all text present in Element
                GlobalDefinitions.WaitForTextPresentInElement(GlobalDefinitions.driver, profileName,
                    GlobalDefinitions.ExcelLib.ReadData(2, "Name"), 10);

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify deleting profile at preparation steps", ex.Message);
            }

            #region Verify Delete Language

            try
            {
                // Jump to Language tab
                LanguageTab.Click();

                // Read data saved in Excel
                var languageExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Language");

                try
                {
                    // Find the last row data             
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='first']" +
                        "//table/tbody[last()]/tr//*[contains(text(), '" + languageExcel + "')]"));
                    Assert.Fail("Failed to delete language");
                }
                catch (NoSuchElementException)
                {

                }

            } catch(Exception ex)
            {
                Assert.Fail("Test failed to verify deleting language", ex.Message);
            }
            #endregion

            #region Verify Delete Skills
            try
            {
                // Jump to Skill tab
                SkillTab.Click();

                // Read Skill saved in Excel
                var skillExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Skill");

                try
                {
                    // Check the last row data
                    GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='second']" +
                        "//table/tbody[last()]/tr//*[contains(text(), '" + skillExcel + "')]"));

                    Assert.Fail("Failed to delete skill");
                }
                catch (NoSuchElementException)
                {
                }

            }catch (Exception ex)
            {
                Assert.Fail("Test Failed to verify deleting skill",ex.Message);
            }
            #endregion

            #region Verify Delete Education
            // Jump to Education tab
            EducationTab.Click();

            // Read Education info saved in excel
            var instituteNameExcel = GlobalDefinitions.ExcelLib.ReadData(2, "University");
            var instituteCountryExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Country");
            var instituteTitleExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            var instituteDegreeExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Degree");
            var instituteGraduateYearExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Graduation Year");

            try
            {
                // Find the last row data
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + instituteNameExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + instituteCountryExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + instituteTitleExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + instituteDegreeExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + instituteGraduateYearExcel + "')]"));

                Assert.Fail("Failed to delete education.");

            } catch (NoSuchElementException)
            {

            } catch (Exception ex)
            {
                Assert.Fail("Test failed to verify deleting education", ex.Message);
            }

            #endregion

            #region Verify Delete Certificate

            // Jump to Certification tab
            CertificationTab.Click();

            // Read Education info saved in excel
            var certificateNameExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate");
            var certificateFromExcel = GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom");
            var certificateYearExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Certificate Issuing Year");     

            try
            {
                // Find the last row data
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + certificateNameExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + certificateFromExcel + "')]"));
                GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']" +
                            "//table/tbody[last()]/tr//*[contains(text(), '" + certificateYearExcel + "')]"));

                Assert.Fail("Failed to delete certificate.");

            }
            catch (NoSuchElementException)
            {

            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify deleting certificate", ex.Message);
            }
            #endregion


        }

    }
}