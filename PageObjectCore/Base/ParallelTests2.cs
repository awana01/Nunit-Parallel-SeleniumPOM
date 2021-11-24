using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web;

namespace PageObjectCore.Base
{
    [AllureNUnit]
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    [Parallelizable(ParallelScope.All)]
    public class ParallelTests2
    {

        public IWebDriver driver;
        public String browser;

        public ParallelTests2(String browser)
        {
            this.browser = browser;
            
        }

        [SetUp]
        public void TestInit()
        {
           // driver = DriverFactory.GetDriver(browser);  
        }

        [TearDown]
        public void TestTear()
        {
            //driver.Close();
            //DriverFactory.CloseDriver(); 

        }


        [Test]
        public void TestMethod1()
        {
            //DriverFactory.instance.StartDriver();
            //IWebDriver driver = DriverFactory.instance.WebDriver;
            driver = DriverFactory.GetDriver(browser);
            driver.Url = "https://www.google.com/";
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
            driver.Manage().Window.Maximize();

            IWebElement blankSpace = driver.FindElement(By.XPath("//body"));
            IWebElement SearchBox = driver.FindElement(By.Name("q"));
            //IWebElement SearchBTN = driver.FindElement(By.Name("btnK"));

            //blankSpace.Click();


            Thread.Sleep(500);
            SearchBox.Click();
            SearchBox.Clear();
            SearchBox.SendKeys("banana");
            Thread.Sleep(5000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", driver.FindElement(By.Name("btnK")));

            //Actions action = new Actions(driver);
            //action.Click(SearchBTN).Build().Perform();
            Thread.Sleep(5000);


        }

        [Test]
        public void TestMethod2()
        {

            driver = DriverFactory.GetDriver(browser);
            driver.Url = "https://www.payscale.com/research/IN/Country=India/Salary";
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 20);
            driver.Manage().Window.Maximize();
            Thread.Sleep(7000);
            BrowserHelper.ScreenShotAsBase64(driver);


            //Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(By.XPath("//div/nav[@id='navbar']"))).Build().Perform();
            //Thread.Sleep(1000);


            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("arguments[0].scrollIntoView()", driver.FindElement(By.Id("searchTxt")));


            //action.MoveToElement(driver.FindElement(By.Id("searchTxt")))
            //       .Click(driver.FindElement(By.Id("searchTxt")))
            //       .SendKeys("Australia")
            //       .Build()
            //       .Perform();

            ////driver.FindElement(By.Id("searchTxt")).Click();
            ////driver.FindElement(By.Id("searchTxt")).Clear();
            ////driver.FindElement(By.Id("searchTxt")).SendKeys("Australia");
            //Thread.Sleep(2000);

            ////IList<IWebElement> Options = driver.FindElements(By.XPath("//div[@id='rclandinghero']/div/div/div/div/form/div/div/div"));
            ////Options[9].Click();

            ////IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ////js.ExecuteScript("arguments[0].click()", Options[9]);



            //driver.FindElement(By.CssSelector("input.search-bar__button")).Click();


            //Thread.Sleep(6000);
            //BrowserHelper.ScreenShotAsBase64(driver);
            //Console.WriteLine("Test for blank");

        }


        public void click_on_Blank(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }


    }
}
