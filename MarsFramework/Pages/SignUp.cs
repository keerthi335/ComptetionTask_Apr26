using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SignUp
    {
        public SignUp()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/button")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            //string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            //string projectPath = new Uri(actualPath).LocalPath;

            //string ExclPath = projectPath + "ExcelData\\TestDataManageListings.xlsx";

            //GlobalDefinitions.ExcelLib.PopulateInCollection(ExclPath, "SignUp");


            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            
            //Click on Join button
            Join.Click();

            //Enter FirstName
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();


        }
        internal void LoginSteps()
        {
            //By WaitCondition = By.XPath("//section[@class='explore']");

            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Click on Sign In Tab
            IWebElement SignIntab = GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(text(),'Sign')]"));
            SignIntab.Click();

            //Giving value for Email field
            GlobalDefinitions.driver.FindElement(By.Name("email")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Email"));

            //Giving value for Password field
            GlobalDefinitions.driver.FindElement(By.Name("password")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Clicking on Login Button
            GlobalDefinitions.driver.FindElement(By.XPath("//button[text()='Login']")).Click();
        }
    }
}
