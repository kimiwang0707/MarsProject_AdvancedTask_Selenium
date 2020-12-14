using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Base
        {
            #region  Profile Page
            [Test, Description("Enter Profile")]
            public void EnterProfileTest()
            {
                test = extent.StartTest("Enter Profile");
                Profile profilePage = new Profile();
                profilePage.EnterProfile(driver);

                profilePage.VerifyEnterProfile(driver);
            }

            [Test, Description("Delete Profile")]
            public void DeleteProfileTest()
            {
                test = extent.StartTest("Delete Profile");
                Profile profilePage = new Profile();
                profilePage.DeleteProfile(driver);

                profilePage.VerifyDeleteProfile(driver);
            }
            #endregion

            #region  Share Skills Page
            [Test, Description("Add New Skill")]
            public void EnterShareSkillTest()
            {
                test = extent.StartTest("Enter Share Skill");
                ShareSkills shareSkillPage= new ShareSkills();
                shareSkillPage.EnterShareSkill(driver);

                shareSkillPage.VerifyEnterShareSkill(driver);
            }
            #endregion

            #region  Manage Listings Page
            [Test, Description("View Listing")]
            public void ViewListingTest()
            {
                test = extent.StartTest("View Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.ViewListing(driver);

                manageListings.VerifyViewListing(driver);
            }

            [Test, Description("Edit Listing")]
            public void EditListingTest()
            {
                test = extent.StartTest("Edit Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.EditListing(driver);

                manageListings.VerifyEditListing(driver);
            }

            [Test, Description("Delete Listing")]
            public void DeleteListingTest()
            {
                test = extent.StartTest("Delete Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.DeleteListing(driver);

                manageListings.VerifyDeleteListing(driver);
            }
            #endregion


            #region Manage Requests Page
            [Test, Description("Send Request")]
            public void SendRequestTest()
            {
                test = extent.StartTest("Send Request");
                ManageRequestsLink manageRequests = new ManageRequestsLink();
                manageRequests.SendRequest(driver);

                manageRequests.VerifySendRequest(driver);
            }


            [Test, Description("View Received Request")]
            public void ReceivedRequestTest()
            {
                test = extent.StartTest("View Received Request");
                ManageRequestsLink manageRequests = new ManageRequestsLink();
                manageRequests.ReceivedRequest(driver);

                manageRequests.VerifyReceivedRequest(driver);
            }

            #endregion

            #region Search Skills Page
            [Test, Description("Search Skills By Categories")]
            public void SearchSkillsByCategoriesTest()
            {
                test = extent.StartTest("Search Skills By Categories");
                SearchSkills searchSkills = new SearchSkills();
                searchSkills.SearchSkillsByCategories(driver);

                searchSkills.VerifySearchSkillsByCategories(driver);
            }

            [Test, Description("Search Skills By Filters")]
            public void SearchSkillsByFiltersTest()
            {
                test = extent.StartTest("Search Skills By Filters");
                SearchSkills searchSkills = new SearchSkills();
                searchSkills.SearchSkillsByFilters(driver);

                searchSkills.VerifySearchSkillsByFilters(driver);
            }

            #endregion

            #region Notification Page
            [Test, Description("Notification Operations")]
            public void NotificationOperations()
            {
                Notification notification = new Notification();
                notification.ShowLessAndMoreNotification(driver);
                notification.VerifyShowLessAndMoreNotification(driver);

                notification.SelectNotification(driver);
                notification.VerifySelectNotification(driver);

                notification.UnselectNotification(driver);
                notification.VerifyUnselectNotification(driver);
            }

            [Test, Description("Mark Notification as Read")]
            public void NotificationMarkAsRead()
            {
                Notification notification = new Notification();

                notification.MarkAsReadNotification(driver);
                notification.VerifyMarkAsReadNotification(driver);
            }


            [Test, Description("Notification Deletion")]
            public void NotificationDelete()
            {
                Notification notification = new Notification();

                notification.DeleteNotification(driver);
                notification.VerifyDeleteNotification(driver);
            }

            #endregion

            #region Chat Page
            [Test, Description("Chat With Other Users")]
            public void ChatTest()
            {
                Chat chat = new Chat();
                chat.ChatWithOtherUser(driver);
                chat.VerifyChatWithOtherUser(driver);
            }

            [Test, Description("View Chat History")]
            public void ViewChatHistoryTest()
            {
                Chat chat = new Chat();
                chat.ViewChatHistory(driver);
                chat.VerifyViewChatHistory(driver);
            }

            #endregion

        }
    }
}