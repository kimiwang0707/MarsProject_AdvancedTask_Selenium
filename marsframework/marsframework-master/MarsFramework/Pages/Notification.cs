using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    class Notification
    {
        public Notification()
        {
            PageFactory.InitElements(Base.driver, this);
        }

        #region Initialize web elements

        // Click on Notification Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement NotificationBtn { get; set; }

        // Click on See All
        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'See All')]")]
        private IWebElement SeeAllLink { get; set; }

        // Click on ShowLess/ Load More button
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Load More')]")]
        private IWebElement ShowLessAndLoadMoreBtn { get; set; }

        // Click on Checkbox of first one notification to select
        [FindsBy(How = How.XPath, Using = "(//div[@class='fourteen wide column' and @style='font-weight: bold;'])[1]/../div[3]/input")]
        private IWebElement FirstUnreadNotisCheckbox { get; set; }

        // Click on Checkbox of last one notification to select
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']//div[last()-1]/div/div/div[3]/input")]
        private IWebElement LastNotificationCheckbox { get; set; }

        // Click on Delete Button
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Delete selection']")]
        private IWebElement DeleteBtn { get; set; }
        
        // Click on Mark As Read Button
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Mark selection as read']")]
        private IWebElement MarkAsReadBtn { get; set; }
        
        // Click on Select All
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Select all']")]
        private IWebElement SelectAllBtn { get; set; }

        // Click on Unselect All
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Unselect all']")]
        private IWebElement UnselectAllBtn { get; set; }

        #endregion

        int requestsQtyLoadMore;
        int requestsQtyShowLess;
        internal void ShowLessAndMoreNotification(IWebDriver driver)
        {
            // Wait and Click on Notification
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10);
            NotificationBtn.Click();

            // Wait and Click on See All button
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[contains(text(), 'See All')]", 10);
            SeeAllLink.Click();

            // Judge if the load more button appear, or remind user to add more notifications
            try
            {
                // Wait and scroll down to bottom of page   
                GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[@class='ui button']", 10);
                GlobalDefinitions.ScrollToBottom();

                // Click on Load More and record the qty of notification
                Thread.Sleep(500);
                ShowLessAndLoadMoreBtn.Click();
            } catch (NoSuchElementException e)
            {
                Base.test.Log(LogStatus.Fail, "Make sure the notifications are more than 5 to use load more function");
                Assert.Fail("Please make sure more than 5 notifications to use load more function!", e.Message);
            }

            //GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//" +
            //    "div[last()-1]/div/div/div[3]/input", 10);
            Thread.Sleep(1500);
            var requestsLoadMore = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            requestsQtyLoadMore = requestsLoadMore.Count();

            // Wait and Click on Show Less and record the qty of notifications
            ShowLessAndLoadMoreBtn.Click();

            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//" +
                "div[last()-1]/div/div/div[3]/input", 10);
            var requestsShowLess = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            requestsQtyShowLess = requestsShowLess.Count();

            // Extent report
            Base.test.Log(LogStatus.Fail, "Show less and load more notifications successfully!");

            Debug.WriteLine("Load MORE qty:" + requestsQtyLoadMore + "SHOW LESS QTY:" + requestsQtyShowLess);

        }

        internal void VerifyShowLessAndMoreNotification(IWebDriver driver)
        {
            // Compare the qty of notifications exhibit
            if (requestsQtyShowLess <= requestsQtyLoadMore)
            {
                Base.test.Log(LogStatus.Pass, "Verify show less and load more notifications successfully!");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Test failed to verify show less and load more notifications.");
                Assert.Fail("Test failed to verify show less and load more notifications.");
            }

        }


       
        internal void SelectNotification(IWebDriver driver)
        {
            // Scroll up the page
            GlobalDefinitions.ScrollToTop();
            Thread.Sleep(500);

            try
            {
                // Wait 
                GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//" +
                    "div[last()-1]/div/div/div[3]/input", 10);

                // Click on select all button and judge if all notifications' status
                SelectAllBtn.Click();
                Thread.Sleep(1000);

            }
            catch (NoSuchElementException e)
            {
                Base.test.Log(LogStatus.Fail, "Make sure at least 1 notification inside to operate!");
                Assert.Fail("Please make sure at least 1 notification inside to operate!", e.Message);
            }

            Base.test.Log(LogStatus.Pass, "Select all notifications successfully!");
        }


        internal void VerifySelectNotification(IWebDriver driver)
        {
            // Judge the qty of elements
            var notifications = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            int notificationsQty = notifications.Count();
            //Debug.WriteLine("Test Notification QTY:" + notificationsQty);

            for (int count = 1; count <= notificationsQty; count++)
            {
                if (driver.FindElement(By.XPath("//*[@id='notification-section']//div[" + count +"]/div/div/div[3]/input")).Selected)
                {
                    //Debug.WriteLine("Test Notification No:" + count);
                }
                else
                {
                    Base.test.Log(LogStatus.Fail, "Failed to verify select and unselect notifications!");
                    Assert.Fail("Test failed to verify select and unselect notifications!");
                }
            }
            Base.test.Log(LogStatus.Pass, "Verify select all notifications successfully!");

        }


        internal void UnselectNotification(IWebDriver driver)
        {
            
                // Wait and Click on unselect all button
                UnselectAllBtn.Click();
                Thread.Sleep(1000);
        }

        internal void VerifyUnselectNotification(IWebDriver driver)
        {
            // Judge the qty of elements
            var notifications = driver.FindElements(By.XPath("//h4[contains(text(), 'Service Request')]"));
            int notificationsQty = notifications.Count();
            //Debug.WriteLine("Test Notification QTY:" + notificationsQty);

            for (int count = 1; count <= notificationsQty; count++)
            {
                if (driver.FindElement(By.XPath("//*[@id='notification-section']//div[" + count + "]/div/div/div[3]/input")).Selected)
                {
                    Base.test.Log(LogStatus.Fail, "Failed to verify select and unselect notifications!");
                    Assert.Fail("Test failed to verify select and unselect notifications!");
                }
                else
                {
                }
            }
            Base.test.Log(LogStatus.Pass, "Verify select all notifications successfully!");         
        }

        int unreadNoticQty;
        internal void MarkAsReadNotification(IWebDriver driver)
        {
            // Wait and Click on Notification
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10);
            NotificationBtn.Click();

            // Wait and Click on See All button
            GlobalDefinitions.WaitForElement(driver, "XPath", "//a[contains(text(), 'See All')]", 10);
            SeeAllLink.Click();

            // Wait and scroll down to bottom of page   
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[@class='ui button']", 10);
            GlobalDefinitions.ScrollToBottom();

            // Click on Load More and record the qty of notification
            Thread.Sleep(500);
            ShowLessAndLoadMoreBtn.Click();

            //Judge if there are unread notifications
            //GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='notification-section']//div[last()-1]/div/div/div[3]/input", 10);
            Thread.Sleep(1500);     
            try
            {
                var unreadNotis = driver.FindElements(By.XPath("//div[@class='fourteen wide column' and @style='font-weight: bold;']"));
                unreadNoticQty = unreadNotis.Count();
            } catch (NoSuchElementException)
            {
                Base.test.Log(LogStatus.Fail, "No unread notifications now, please add some first!");
                Assert.Fail("There is no unread notification in list! Please try to add some first!");
            }

            //If so, click on the 1st Notification checkbox
            GlobalDefinitions.ScrollToTop();
            Thread.Sleep(500);
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "(//div[@class='fourteen wide column' " +
                "and @style='font-weight: bold;'])[1]/../div[3]/input", 10);
            FirstUnreadNotisCheckbox.Click();

            // Click on mark as read
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//div[@data-tooltip='Mark selection as read']", 10);
            MarkAsReadBtn.Click();
            Debug.WriteLine("Unread Notification QTY Now:" +unreadNoticQty);

            // Extent report
            Base.test.Log(LogStatus.Pass, "Mark notification ad read successfully!");
        }


        internal void VerifyMarkAsReadNotification(IWebDriver driver)
        {
            // Wait
            Thread.Sleep(2500);
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "(//input[@type='checkbox'])[last()]", 10);

            // Judge the updated qty of notification with "BOLD"
            var unreadNotis = driver.FindElements(By.XPath("//div[@class='fourteen wide column' and @style='font-weight: bold;']"));
            int unreadNotisQtyUpdate = unreadNotis.Count();
            Debug.WriteLine("Unread Notification QTY Now:" + unreadNotisQtyUpdate);
            if (unreadNotisQtyUpdate == unreadNoticQty - 1)
            {
                Base.test.Log(LogStatus.Pass, "Verify mark notification ad read successfully!");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Failed to verify notification mark as read!");
                Assert.Fail("Failed to verify notification mark as read!");
            }
        }

        int NotificationQty;
        internal void DeleteNotification(IWebDriver driver)
        {
            // Wait and Click on Notification
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10);
            NotificationBtn.Click();

            // Wait and Click on See All button
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[contains(text(), 'See All')]", 10);
            SeeAllLink.Click();

            // Wait and Click on Load More 
            Thread.Sleep(2000);
            GlobalDefinitions.ScrollToBottom();
            Thread.Sleep(500);
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//a[contains(text(),'Load More')]", 15);

            ShowLessAndLoadMoreBtn.Click();

            // Judge if all notifications are fully loaded
            Thread.Sleep(1500);
            bool present;          
            do
            {
                try
                {
                    driver.FindElement(By.XPath("//a[contains(text(),'Load More')]"));
                    present = true;
                }
                catch (NoSuchElementException)
                {
                    present = false;
                    break;
                }

                GlobalDefinitions.ScrollToBottom();
                Thread.Sleep(500);
                driver.FindElement(By.XPath("//a[contains(text(),'Load More')]")).Click();
                Thread.Sleep(1500);
            }
            while (present);


            // Record the elements qty
            Thread.Sleep(500);
            var notification = driver.FindElements(By.XPath("//h4[contains(text(),'Service Request')]"));
            NotificationQty = notification.Count();
            Debug.WriteLine("The qty of notification is:" + NotificationQty);

            // Scroll down to end of page and Select the notification
            GlobalDefinitions.ScrollToBottom();
            Thread.Sleep(1000);
            LastNotificationCheckbox.Click();
            Thread.Sleep(300);

            // Scroll to top of page
            GlobalDefinitions.ScrollToTop();
            Thread.Sleep(500);

            // Click on delete button
            GlobalDefinitions.WaitForElementClickable(driver, "XPath", "//div[@data-tooltip='Delete selection']", 10);
            DeleteBtn.Click();

            // Extent report
            Base.test.Log(LogStatus.Pass, "Delete notification successfully!");
        }

        internal void VerifyDeleteNotification(IWebDriver driver)
        {
            // Record the elements qty
            Thread.Sleep(2000);
            var notification = driver.FindElements(By.XPath("//h4[contains(text(),'Service Request')]"));
            int NotificationQtyUpdate = notification.Count();
            Debug.WriteLine("The qty of notification after deletion:" + NotificationQtyUpdate);

            // Judge if the qty is decreased by 1
            GlobalDefinitions.WaitForElement(driver, "XPath", "//h4[contains(text(), 'Service Request')]", 10);
            Thread.Sleep(1000);

            if (NotificationQtyUpdate == NotificationQty - 1)
            {
                Base.test.Log(LogStatus.Pass, "Verify delete notification successfully!");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Failed to verify delete notification successfully!");
                Assert.Fail("Failed to verify delete notification successfully!");
            }

        }




    }
}
