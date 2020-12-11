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
                profilePage.EnterProfile();

                profilePage.VerifyEnterProfile();
            }

            [Test, Description("Delete Profile")]
            public void DeleteProfileTest()
            {
                test = extent.StartTest("Delete Profile");
                Profile profilePage = new Profile();
                profilePage.DeleteProfile();

                profilePage.VerifyDeleteProfile();
            }
            #endregion

            #region  Share Skills Page
            [Test, Description("Add New Skill")]
            public void EnterShareSkillTest()
            {
                test = extent.StartTest("Enter Share Skill");
                ShareSkills shareSkillPage= new ShareSkills();
                shareSkillPage.EnterShareSkill();

                shareSkillPage.VerifyEnterShareSkill();
            }
            #endregion

            #region  Manage Listings Page
            [Test, Description("View Listing")]
            public void ViewListingTest()
            {
                test = extent.StartTest("View Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.ViewListing();

                manageListings.VerifyViewListing();
            }

            [Test, Description("Edit Listing")]
            public void EditListingTest()
            {
                test = extent.StartTest("Edit Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.EditListing();

                manageListings.VerifyEditListing();
            }

            [Test, Description("Delete Listing")]
            public void DeleteListingTest()
            {
                test = extent.StartTest("Delete Listing");
                ManageListingsLink manageListings = new ManageListingsLink();
                manageListings.DeleteListing();

                manageListings.VerifyDeleteListing();
            }
            #endregion


            #region Manage Requests Page
            [Test, Description("Send Request")]
            public void SendRequestTest()
            {
                test = extent.StartTest("Send Request");
                ManageRequestsLink manageRequests = new ManageRequestsLink();
                manageRequests.SendRequest();

                manageRequests.VerifySendRequest();
            }


            [Test, Description("View Received Request")]
            public void ReceivedRequestTest()
            {
                test = extent.StartTest("View Received Request");
                ManageRequestsLink manageRequests = new ManageRequestsLink();
                manageRequests.ReceivedRequest();

                manageRequests.VerifyReceivedRequest();
            }

            #endregion

            #region Search Skills Page
            [Test, Description("Search Skills By Categories")]
            public void SearchSkillsByCategoriesTest()
            {
                test = extent.StartTest("Search Skills By Categories");
                SearchSkills searchSkills = new SearchSkills();
                searchSkills.SearchSkillsByCategories();

                searchSkills.VerifySearchSkillsByCategories();
            }

            [Test, Description("Search Skills By Filters")]
            public void SearchSkillsByFiltersTest()
            {
                test = extent.StartTest("Search Skills By Filters");
                SearchSkills searchSkills = new SearchSkills();
                searchSkills.SearchSkillsByFilters();

                searchSkills.VerifySearchSkillsByFilters();
            }

            #endregion


        }
    }
}