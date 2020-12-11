using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Notification
    {
        public Notification()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        // Click on Notification Button
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[1]/div[2]/div/div")]
        private IWebElement NotificationBtn { get; set; }

        // Click on See All
        [FindsBy(How = How.XPath, Using = "//a[@href='/Account/Dashboard']")]
        private IWebElement SeeAllLink { get; set; }

        // Click on ShowLess/ Load More button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui button']")]
        private IWebElement ShowLessAndLoadMoreBtn { get; set; }

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


        internal void ShowLessAndMoreNotification()
        {

        }

        internal void VerifyShowLessAndMoreNotification()
        {

        }

        internal void DeleteNotification()
        {

        }

        internal void VerifyDeleteNotification()
        {

        }

        internal void MarkAsReadNotification()
        {

        }

        internal void VerifyMarkAsReadNotification()
        {

        }

        internal void SelectAndUnselectNotification()
        {

        }

        internal void VerifySelectAndUnselectNotification()
        {

        }



    }
}
