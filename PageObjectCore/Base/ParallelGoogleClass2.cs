using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Web;

namespace PageObjectCore.Base
{
    [TestFixture(Author = "unickq", Description = "Examples")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Fixtures)]
    
    public class ParallelGoogleClass2: TestBase
    {

        //public IWebDriver driver;
        public GooglePage googlePage;
        public GoogleSearchPage SearchPage;

        public string testName;
        public string testFullName;

        Actions action;

        //[OneTimeSetUp]

        //public void TestStart()
        //{

        //    testName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
        //    testFullName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

        //    Console.WriteLine("Test Start: "+testFullName);

        //    ////driver = DriverFactory.GetDriver("firefox");
        //    //driver = DriverFactory.GetDriver("");
        //    Actions action = new Actions(driver);

        //    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
        //    driver.Url = "https://www.google.com";
        //}

        //[OneTimeTearDown]
        //public void TestFinsih()
        //{
        //    driver.Manage().Window.Minimize();
        //    DriverFactory.CloseDriver();

        //}

        [Test]
        public void Test01_VerifySearchTest()
        {

            _driver.Url = "https://www.google.com";
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);

            googlePage = new GooglePage();

            Console.WriteLine("Google Test");

            IWebElement blankSpace = _driver.FindElement(By.XPath("//body"));

            Thread.Sleep(500);
            googlePage.search_box.Click();
            googlePage.search_box.Clear();
            googlePage.search_box.SendKeys("r system interview questions");
            Thread.Sleep(500);


            Thread.Sleep(2000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click()", googlePage.SearchBTN);

            //Actions action = new Actions(driver);
            //action.Click(SearchBTN).Build().Perform();
            Thread.Sleep(5000);
            BrowserHelper.ScreenShotAsBase64(_driver);
        }

        [Test]
        public void Test02_VerifyResultTest()
        {
            SearchPage = new GoogleSearchPage();

            Console.WriteLine("Result Stat:" + SearchPage.result_Stat.Text);

            Console.WriteLine("Results :" + SearchPage.result_TextHeading.Count);
        }

        [Test]
        public void Test03_ChangeSearchSetting()
        {
            SearchPage = new GoogleSearchPage();

            SearchPage.search_setting_button.Click();
            Thread.Sleep(600);
            SearchPage.search_settings_option.Click();
            Thread.Sleep(7000);

            new Actions(_driver).DragAndDropToOffset(SearchPage.search_slider_point, 10, 0).Release()
                  .Build()
                  .Perform();
            Thread.Sleep(5000);
            
            SearchPage.save_searchsetting_btn.Click();

            Thread.Sleep(2000);

            //driver.SwitchTo().ActiveElement().Click();

            _driver.SwitchTo().Alert().Accept(); //.SendKeys(Keys.Enter);

            Thread.Sleep(6000);

            _driver.SwitchTo().DefaultContent();


            Console.WriteLine("Results :" + SearchPage.result_TextHeading.Count);
        }




        

        public void click_on_Blank(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }


    }
}


