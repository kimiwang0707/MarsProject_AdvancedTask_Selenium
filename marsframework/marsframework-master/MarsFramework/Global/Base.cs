using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Diagnostics;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        public static string ReportXMLPath = MarsResource.ReportXMLPath;

        public static string ShareSkillPath = MarsResource.ShareSkillPath;
        public static string ManageListingPath = MarsResource.ManageListingPath;

        #endregion

        #region Declare web driver
        public static IWebDriver driver;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [OneTimeSetUp]
        public void Inititalize()
        {
            // Set the current project as the BaseDirectory then can set relative path for external files. 
            // Or the project will have default path as : c:\windows\system32
            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    driver = new FirefoxDriver();
                    break;
                case 2:
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;

            }         

            // Populate the data saved in excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);
            //test = extent.StartTest("My First Test", "Sample description");

            #endregion

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                 loginobj.LoginSteps(driver);
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

            // Obtain current file path to write relative path for excel later instead of absolute path
            //String path = System.IO.Directory.GetCurrentDirectory();
            //Debug.WriteLine("Obtain Path:");
            //Debug.WriteLine(path);
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            //// log(LogStatus, details)
            //test.Log(LogStatus.Info, "This step shows usage of log(logStatus, details)");

            //// Report with Screenshot
            //String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            //test.Log(LogStatus.Info, "Image example: " + img);


            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                // Screenshot
                String img = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            }

            // end test. (Reports)
            extent.EndTest(test);
            
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();

            // Close the driver(would better add driver.close() before dispose to avoid error "unable to delete file chromedriver.exe")
            driver.Close();
            driver.Dispose();
        }
        #endregion

    }
}