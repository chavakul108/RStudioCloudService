using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;

namespace RStudioService.UI
{
    [Binding]
    public class CreatingASpaceStepsfile
    {
        ChromeDriver _driver;
        private CreatingASpace _CreatingASpace;
     

        [Given(@"User selects Log In on the RStudio Cloud Hope page")]
        public void GivenUserSelectsLogInOnTheRStudioCloudHopePage()
        {
            _CreatingASpace = CreatingASpace.NavigateTo(_driver);
          
        }
        
        [Given(@"User Enters Email in the text box")]
        public void GivenUserEntersEmailInTheTextBox()
        {
            HelperFunctions.Pause();
            _CreatingASpace.LoginClick();
        }
        
        [When(@"Click on Continue button")]
        public void GivenClickOnContinueButton()
        {
            
            _CreatingASpace.EmailEnter("chavakula.sriman@gmail.com");
             HelperFunctions.Pause();
            _CreatingASpace.ContinueLink();
             HelperFunctions.Pause();
            _CreatingASpace.EnterPassWord("Sriman123948");
            _CreatingASpace.ClickOnLogIn();
            // HelperFunctions.Pause();
          
        }

        [Then(@"RStudio Cloud Projects Page is displayed to the user")]
        public void ThenRStudioCloudProjectsPageIsDisplayedToTheUser()
        {
            _CreatingASpace.WiatforThePageToLoad();
             Assert.AreEqual("Projects", _CreatingASpace.ValidateProjectsPageAfterLogIn());
          // _CreatingASpace.EnsurePageIsLoaded();
           _CreatingASpace.DisposeWebDriver();
        }

        [When(@"User selects New Space")]
        public void WhenUserSelectsNewSpace()
        {
            _CreatingASpace.NewSpaceCreation();
            _CreatingASpace.NewSpaceNameTextBox("SrimanSpace");
        }

        [Then(@"New Space is created")]
        public void ThenNewSpaceIsCreated()
        {
            
             _CreatingASpace.NewSpaceCreateButton();
             _CreatingASpace.WiatforUpgradeButton();
              Assert.AreEqual("Upgrade Account", _CreatingASpace.UpgradeAccountButton());
             _CreatingASpace.DisposeWebDriver();
        }
           


        [When(@"User Selects New Project from the drop down")]
        public void ThenUserSelectsNewProjectFromTheDropDown()
        {
            _CreatingASpace.DropDownSelect();
            _CreatingASpace.NewRStudioProject();
        }


        [When(@"Untitle Project is displayed to the user")]
        public void ThenUntitleProjectIsDisplayedToTheUser()
        {
            _CreatingASpace.UnTitleProjectLoad();
        }

        [Then(@"IDE is loaded successfully")]
        public void ThenIDEIsLoadedSuccessfully()
        {
            Assert.AreEqual("Unnamed Project", _CreatingASpace.IdeLoaded());
            _CreatingASpace.DisposeWebDriver();
        }

    }
}
