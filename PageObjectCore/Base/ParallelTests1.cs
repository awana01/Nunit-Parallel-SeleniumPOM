using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
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
    [TestFixture]
    //[Parallelizable(ParallelScope.Self)]
    [Parallelizable(ParallelScope.All)]
    public class ParallelTests1
    {

        public IWebDriver driver;


        [SetUp]
        public void TestInit()
        {
            var options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");



            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), options.ToCapabilities(),TimeSpan.FromSeconds(200));
            //driver = DriverFactory.GetDriver(null);
            //driver = DriverFactory.instance.WebDriver;
        }

        [TearDown]
        public void TestTear()
        {
            //driver.Close();
            DriverFactory.CloseDriver(); 
            //added for jenkin commit
        }


        [Test]
        public void TestMethod1()
        {
            //DriverFactory.instance.StartDriver();
            //IWebDriver driver = DriverFactory.instance.WebDriver;
          
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

        [Test]
        [TestCase("abc", TestName = "Simple Value1", Description = "This test uses a simple input value1")]
        [TestCase("efg", TestName = "Simple Value2", Description = "This test uses a simple input value1")]
        public void TestIt(string value)
        {
            var name = Faker.Name.FullName(); // Tod Yundt
            Console.WriteLine("Full Name:" + name);
            Console.WriteLine("Data Value: " + value);

            
            var firstName = Faker.Name.First(); // Orlando
            var lastName = Faker.Name.Last(); // Brekke
            var address = Faker.Address.StreetAddress(); // 713 Pfeffer Bridge
            var city = Faker.Address.City(); // Reynaton
            var number = Faker.RandomNumber.Next(100); // 30
            var dob = Faker.Identification.DateOfBirth(); // 1971-11-16T00:00:00.0000000Z

            // US - United States
            var ssn = Faker.Identification.SocialSecurityNumber(); // 249-17-9666
            var mbi = Faker.Identification.MedicareBeneficiaryIdentifier(); // 8NK0Q74KT53
            var usPassport = Faker.Identification.UsPassportNumber(); // 335587506

            // UK - United Kingdom
            var nin = Faker.Identification.UkNationalInsuranceNumber(); // YA171053Y
            var ninFormatted = Faker.Identification.UkNationalInsuranceNumber(true); // YA 17 10 53 Y
            var ukPassport = Faker.Identification.UkPassportNumber(); // 496675685
            var ukNhs = Faker.Identification.UkNhsNumber(); // 6584168301
            var ukNhsFormatted = Faker.Identification.UkNhsNumber(true); // 658 416 8301

            // BG - Bulgaria
            var bulgarianPin = Faker.Identification.BulgarianPin(); //6402142606



        }






        public void click_on_Blank(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }


    }
}
