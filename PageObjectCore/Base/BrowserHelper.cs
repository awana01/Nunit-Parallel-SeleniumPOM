using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PageObjectCore.Base
{
    public class BrowserHelper
    {
        public IWebDriver driver;
        public static void ScreenShotAsBase64(IWebDriver d)
        {
            Screenshot ss = ((ITakesScreenshot)d).GetScreenshot();
            byte[] fileContent = ss.AsByteArray;
            Allure.Commons.AllureLifecycle.Instance.AddAttachment("Image1", "image/png", fileContent);
            //return fileContent;
        }
        public static byte[] ReadImageAsBase64(String filepath)
        {
            string _b64 = Convert.ToBase64String(File.ReadAllBytes(filepath));
            byte[] _filebytes = System.Convert.FromBase64String(_b64);
            return _filebytes;
        }





    }
}
