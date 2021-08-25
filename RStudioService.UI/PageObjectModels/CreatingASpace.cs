using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;





namespace RStudioService.UI
{
    public class CreatingASpace
    {
        // Chrome driver initiali
        ChromeDriver _driver;
        private const string PageUri = @"https://rstudio.cloud/";
       

        public CreatingASpace(ChromeDriver _driver)
        {
            this._driver = _driver;
        

        }

        public static CreatingASpace NavigateTo(ChromeDriver _driver)
        {

            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(PageUri);
            _driver.Manage().Window.Maximize();
             return new CreatingASpace(_driver);
        }
        //For login functionality
        IWebElement logInLink => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div/div[2]/div/div/a[1]/span");
        IWebElement emailLink => _driver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div/form/fieldset[1]/input");
        IWebElement continueLink => _driver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div/form/fieldset[2]/button");
        IWebElement enterPassWord => _driver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div/div[2]/form/fieldset[1]/input");
        IWebElement clickOnLogIn => _driver.FindElementByXPath("/html/body/div[1]/div/div[1]/div/div/div[2]/form/fieldset[2]/button");
        IWebElement projectTitle => _driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div/div[2]/span/a[1]/span"));

        //For New Space functionality

        IWebElement newSpaceLink => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[3]/div[1]/div[3]/div[1]/div[2]/button");
        IWebElement newSpaceNameTextBox => _driver.FindElementById("name");
        IWebElement newSpaceCreateButton => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[4]/div/div/form/div[2]/button/span");

        IWebElement upgradeAccountButton => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[4]/div/div/form/div[2]/a/span");

        //For IDE functionality
                
       IWebElement dropDownSelect => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[2]/div/div/div[1]/div[1]/div/span/div/button/span");
       IWebElement newRStudioProject=> _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[2]/div/div/div[1]/div[1]/div/span/div/div/button[1]/span");

       IWebElement unTitleProject => _driver.FindElementByXPath("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div/div[1]/div[3]/div[2]/span");


        //Login button click
        public void LoginClick ()
        {
            logInLink.Click();
        }
               
        //Enter email address 
        public void EmailEnter(string emailAddress)
        {
            emailLink.SendKeys(emailAddress);
          
         
        }

        //Continue after entering the email
        public void ContinueLink()
        {
            continueLink.Click();
            

        }

        //Enter user password
        public void EnterPassWord(string password)
        {
            enterPassWord.SendKeys(password);

        }

        // Ligin after entering the password
        public void ClickOnLogIn()
        {
            clickOnLogIn.Click();

        }

        //Validating the projects page after login
        public string ValidateProjectsPageAfterLogIn()
        {
            string header = projectTitle.Text;
            return header;

        }

        //Disposing web driver
        public void DisposeWebDriver()
        {
            _driver.Close();


        }

        //To check if the web page is loaded or not
        public void EnsurePageIsLoaded()
        {
            bool pageHasLoaded = _driver.Title == PageUri;
            if(!pageHasLoaded)
            {
                throw new Exception($"Failed to load the page");

            }
        }

        //Waiting for the page to load after login
        public void WiatforThePageToLoad()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("navPanelPinner")));
        }

        //Waiting for the Upgrade button to be avaialble
        public void WiatforUpgradeButton()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div/div[1]/div[4]/div/div/form/div[2]/a/span")));
        }

        //Waiting for the Untitle Project page to load
        public void UnTitleProjectLoad()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div/div[1]/div[1]/div[1]/div/div[1]/div[3]/div[2]/span")));
        }

        //Selecting New Space link
        public void NewSpaceCreation()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div/div[3]/div[1]/div[3]/div[1]/div[2]/button/span")));
            newSpaceLink.Click();
            
        }

        //Entering New Space Name
        public void NewSpaceNameTextBox(string spaceName)
        {
          // IAlert alert = _driver.SwitchTo().Alert();
            newSpaceNameTextBox.SendKeys(spaceName);
        }

        //Selecting Create button for a new Space
        public void NewSpaceCreateButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("html/body/div[1]/div/div/div[1]/div[4]/div/div/form/div[2]/button/span")));
            newSpaceCreateButton.Click();
        }

        //Getting text from the upgrade account button
        public string UpgradeAccountButton()
        {
            string header = upgradeAccountButton.Text;
            return header;

        }

        //New Projects drop down to load
        public void DropDownSelect()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("navPanelPinner")));
            dropDownSelect.Click();
        }

        // New RStudio Project to select
        public void NewRStudioProject()
        {

            newRStudioProject.Click();
        }

        //Getting text from the untitled project in the IDE
        public string IdeLoaded()
        {

            string header = unTitleProject.Text;
            return header;
        }

    }
}
