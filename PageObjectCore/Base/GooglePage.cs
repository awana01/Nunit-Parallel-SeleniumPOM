using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PageObjectCore.Base
{
    public class GooglePage : LoadableComponent<GooglePage>
    {
        public GooglePage()
        {
            DriverFactory.DriverStored.Url = "https://www.google.com/";
            PageFactory.InitElements(DriverFactory.DriverStored, this);
        }


        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        public IWebElement search_box;

        [FindsBy(How = How.Name, Using = "btnK")]
        [CacheLookup]
        public IWebElement SearchBTN;


        public GoogleSearchPage SearchGoogle(String search_text)
        {
            search_box.SendKeys(search_text);
            Thread.Sleep(2000);
            search_box.SendKeys(Keys.Escape);
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverFactory.DriverStored;
            js.ExecuteScript("arguments[0].click()",SearchBTN);
            //SearchBTN.Click();
            return new GoogleSearchPage();
        }


        protected override bool EvaluateLoadedStatus() { throw new NotImplementedException();  }

        protected override void ExecuteLoad() { throw new NotImplementedException(); }
    }

    public class GoogleSearchPage : LoadableComponent<GoogleSearchPage>
    {
        public GoogleSearchPage()
        {
            PageFactory.InitElements(DriverFactory.DriverStored, this);
        }

        [FindsBy(How=How.Id, Using = "result-stats")]
        [CacheLookup]
        public IWebElement result_Stat;

        //// Will find the element with the tag name "input" that also has an ID
        //// attribute matching "elementId".
        //[FindsByAll]
        //[FindsBy(How = How.TagName, Using = "input", Priority = 0)]
        //[FindsBy(How = How.Id, Using = "elementId", Priority = 1)]
        //public IWebElement thisElement;

        [FindsBy(How = How.XPath, Using = ".//h3//following::*[name()='svg'][1]")]
        [CacheLookup]
        public IList<IWebElement> AboutSearchResultInfo;
        
        [FindsBy(How=How.CssSelector,Using = "h3.LC20lb.MBeuO.DKV0Md")]
        [CacheLookup]
        public IList<IWebElement> result_TextHeading;

        [FindsBy(How = How.Id, Using = "abar_button_opt")]
        [CacheLookup]
        public IWebElement search_setting_button;


        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Search settings')]")]
        [CacheLookup]
        public IWebElement search_settings_option;

        [FindsBy(How=How.CssSelector,Using= "div.goog-slider-thumb")]
        [CacheLookup]
        public IWebElement search_slider_point;


        [FindsBy(How=How.XPath,Using = "//div[@id='form-buttons']/div[1]")]
        public IWebElement save_searchsetting_btn;



        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateLoadedStatus()
        {
            throw new NotImplementedException();
        }
    }







}
