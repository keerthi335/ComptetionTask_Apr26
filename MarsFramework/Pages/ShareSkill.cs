using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {

            //GlobalDefinitions.ExcelLib.PopulateInCollection(@"C:\Users\kranthi\source\repos\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            By WaitCondition = By.XPath("//a[text()=\"Share Skill\"]");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);


            //Click on ShareSkill button to enter the details of skill
            ShareSkillButton.Click();

            By WaitCondition1 = By.XPath("//input[@name='title']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);
            
            //Enter value for Title field
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter value for Description field
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select value for Category
            SelectElement Category = new SelectElement(CategoryDropDown);
            Category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select value for SubCategory
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Select Service type
            string ServiceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");

            if (ServiceType == "One-off service")
                ServiceTypeOptions.FindElement(By.XPath("//label[contains(text(),'One-off')]")).Click();
            else
                ServiceTypeOptions.FindElement(By.XPath("//label[contains(text(),'Hourly')]")).Click();

            //Select Location type
            string LocationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");

            if (LocationType == "On-site")
                LocationTypeOption.FindElement(By.XPath("//label[contains(text(),'On-site')]")).Click();
            else
                LocationTypeOption.FindElement(By.XPath("//label[contains(text(),'Online')]")).Click();

            //Enter Calender values
            //SelectElement StartDate = new SelectElement(StartDateDropDown);

            //Click on Skill-Trade Option
            string SkillTrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");

            if (SkillTrade == "Skill-Exchange")
            {
                SkillTradeOption.FindElement(By.XPath("//label[contains(text(),'Skill-exchange')]")).Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                SkillTradeOption.FindElement(By.XPath("//label[contains(text(),'Credit')]")).Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
            }


            IWebElement Sample = GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
            Sample.Click();

            Thread.Sleep(1500);

            AutoItX3 AutoIT = new AutoItX3();
            AutoIT.WinActivate("Open");

            Thread.Sleep(1500);

            AutoIT.Send(Base.ImagePath);

            Thread.Sleep(1500);

            AutoIT.Send("{ENTER}");

            //Click on Active field
            string Activefield = GlobalDefinitions.ExcelLib.ReadData(2, "Active");

            if (Activefield == "Active")
                ActiveOption.FindElement(By.XPath("//label[contains(text(),'Active')]"));
            else
                ActiveOption.FindElement(By.XPath("//label[contains(text(),'Hidden')]"));

            Save.Click();


        }

        public bool ValidateShareSkill(IWebDriver driver)
        {

            driver.FindElement(By.LinkText("Manage Listings")).Click();
            By WaitCondition = By.XPath("//table[@class='ui striped table']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            IWebElement table = driver.FindElement(By.XPath("//table[@class='ui striped table']"));

            IWebElement CategoryInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[2]"));

            if (CategoryInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
            {
                IWebElement TitleInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[3]"));

                if (TitleInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))
                {
                    IWebElement DescriptionInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[4]"));
                    if (DescriptionInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                    {
                        IWebElement ServiceTypeInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[5]"));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
    }
}
