using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void EditListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            
            By WaitCond1 = By.LinkText("Manage Listings");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCond1, 60);


            //Click on ManageListings tab
            manageListingsLink.Click();

            By WaitCondition = By.XPath("//th[text()='Image']");

            IWebElement Edit = GlobalDefinitions.WaitForElement(GlobalDefinitions.driver,WaitCondition, 60);

            //Click on View button
            edit.Click();

            By WaitCond = By.XPath("//input[@name='title']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCond, 60);

            //Identify and Enter the "Title" field
            IWebElement Title = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='title']"));
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Identify and Enter the "Description" field
            GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name=\"description\"]")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Identify and Select the Category
            IWebElement CategoryDropDown = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name=\"categoryId\"]"));
            SelectElement category = new SelectElement(CategoryDropDown);
            category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Identify and Select the Subcategory
            IWebElement SubCategoryDropDown = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name=\"subcategoryId\"]"));
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Identify and enter the value for "Add new tag"
            IWebElement Tags = GlobalDefinitions.driver.FindElement(By.XPath("//h3[text()=\"Tags\"]/parent::div/following-sibling::div//input[@placeholder=\"Add new tag\"]"));
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Identify and Click Service type
            GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'One-off')]")).Click();

            //Identify and Click Location Type
            GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'On-site')]")).Click();


            //Identify and  Enter Calender

            //Identify and  select Skill Trade
            GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Skill-exchange')]")).Click();

            //Identify and select Skill-exchange
            IWebElement SkillExchangeTag = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
            SkillExchangeTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchangeTag.SendKeys(Keys.Enter);

            //Identify and Click the Active
            GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]")).Click();

            //Identify and Click on Save button
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@class='ui teal button']")).Click();
        }

        public bool ValidateEdit(IWebDriver driver)
        {
            By WaitCondition = By.XPath("(//button[@class='ui button'])[1]");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            //    IWebElement table = driver.FindElement(By.XPath("//table[@class='ui striped table']"));

            //    IWebElement CategoryInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[1]"));

            //    if (CategoryInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
            //    {
            //        IWebElement TitleInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[2]"));

            //        if (TitleInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))
            //        {
            //            IWebElement DescriptionInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[3]"));
            //            if (DescriptionInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
            //            {
            //                IWebElement ServiceTypeInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[4]"));

            //                if (ServiceTypeInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"))
            //                {
            //                    return true;
            //                }
            //                else
            //                {
            //                    return false;
            //                }
            //            }
            //            else
            //            {
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            try
            {
                driver.FindElement(By.XPath("//td[contains(text(),'" + GlobalDefinitions.ExcelLib.ReadData(2, "Title") + "')]"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "DeleteAction");

            By WaitCondition = By.XPath("//a[contains(text(),'Manage')]");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            //Click on ManageListings tab
            manageListingsLink.Click();

            By WaitCondition1 = By.XPath("//th[text()='Image']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

           //Click on Delete button
            delete.Click();

            //Click Yes on Popup window
            // GlobalDefinitions.driver.SwitchTo().Alert().Accept();

            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();

        }

        public bool ValidateDelete(IWebDriver driver)
        {
            By WaitCondition = By.XPath("//th[contains(text(),'Title')]");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            try
            {
                driver.FindElement(By.XPath("//th[contains(text(),'" + GlobalDefinitions.ExcelLib.ReadData(2,"Title") + "')]"));
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}