using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Web;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectCore.Base
{
    [TestFixture(Author = "unickq", Description = "Examples")]
    [AllureNUnit]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("Google")]
    public class ParallelGoogleClass1:TestBase
    {

        public IWebDriver driver;
        public GooglePage googlePage;
        public GoogleSearchPage SearchPage;

        //[OneTimeSetUp]
        
        //public void TestStart()
        //{
            
        //    driver = DriverFactory.GetDriver("firefox");

        //    googlePage=new GooglePage();
        //    //SearchPage=new GoogleSearchPage();

        //    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,0,15);
        //    //driver.Url = "https://www.google.com";
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

            SearchPage = googlePage.SearchGoogle("r system interview questions");
            
            //Thread.Sleep(2000);

            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("arguments[0].click()", googlePage.SearchBTN);

            ////Actions action = new Actions(driver);
            ////action.Click(SearchBTN).Build().Perform();
            //Thread.Sleep(5000);
            BrowserHelper.ScreenShotAsBase64(_driver);
        }

        [Test]
        public void Test02_VerifyResultTest()
        {
            //SearchPage = new GoogleSearchPage();

            Console.WriteLine("Result Stat:" + SearchPage.result_Stat.Text);

            var theNumber = SearchPage.result_Stat.Text.Where(x => char.IsNumber(x));


            string num = new string(SearchPage.result_Stat.Text.Where(c => Char.IsDigit(c)).ToArray());
            Console.WriteLine("Digits :" + num);



            Console.WriteLine("Results :" + SearchPage.result_TextHeading.Count);

            SearchPage.result_TextHeading[0].Click();
            Thread.Sleep(5000);

            Assert.AreEqual(_driver.Title, "R Systems Interview Questions | Glassdoor");

        }




    

        //[OneTimeTearDown]
        //public void TestFinsih()
        //{
        //    driver.Manage().Window.Minimize();
        //    DriverFactory.CloseDriver();
            
        //}
        
        public void click_on_Blank(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }


    }
}
