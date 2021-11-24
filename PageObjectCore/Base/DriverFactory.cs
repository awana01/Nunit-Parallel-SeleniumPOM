using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObjectCore.Base
{


    public class DriverFactory
    {

        private static ThreadLocal<IWebDriver> Browsers = new ThreadLocal<IWebDriver>();
        
        public static IWebDriver GetDriver(String browserType)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());


            //ProjectConfig.GetProjectConfig().browsers.name1


            if (browserType.Contains(""))
            {
                if (ProjectConfig.GetProjectConfig().browsers.name1.Contains("chrome"))
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments(ProjectConfig.GetProjectConfig().browsers.browsers_options);
                    DriverStored = new ChromeDriver(options);
                }
            }
            
            
            if (browserType.Contains("chrome"))
            {

                ChromeOptions options = new ChromeOptions();

                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.SuppressInitialDiagnosticInformation = true;

                var service2 = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true; // HIDE Chrome Driver
                service.SuppressInitialDiagnosticInformation = true;
                DriverStored = new ChromeDriver(service2,options);
            }
            if (browserType.Contains("firefox"))
            {
                DriverStored = new FirefoxDriver();
            }
            if (browserType.Contains("grid"))
            {
                //var chromeOptions = new ChromeOptions
                //{
                //    BrowserVersion = "latest",
                //    PlatformName = "Windows 10"
                //};

                var options = new ChromeOptions();

                options.AcceptInsecureCertificates=true;
                //options.AddArguments(new string[]);
                //options.UnhandledPromptBehavior ;

                //Map<String, Object> prefs = new HashMap<String, Object>();
                //prefs.put("profile.default_content_setting_values.automatic_downloads", 1);
                //options.setExperimentalOption("prefs", prefs);
                //prefs.put("download.default_directory", "C:\\Downloads");


                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");

                DriverStored = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
            }

            return DriverStored;
        }

        public static IWebDriver DriverStored
        {
            get
            {
                if (Browsers == null)
                { return null; }
                else
                { return Browsers.Value; }
            }
            set
            { Browsers.Value = value; }
        }

        public static void CloseDriver()
        {
            Browsers.Value.Close();
            Browsers.Value.Quit();
        }



        

    }


    public enum BrowserType
    {
        Chrome,
        Firefox
    }






}


//public class SafeBrowserFactory
//{
//    IWebDriver driver;
//    public static ThreadLocal<IWebDriver> BrowserThread = new ThreadLocal<IWebDriver>();


//    private SafeBrowserFactory()
//    {
//       //Do not instance out side
//    }
//    public static SafeBrowserFactory instance = new SafeBrowserFactory();

//    public static SafeBrowserFactory Instance()
//    {
//        return instance;
//    }


//    public IWebDriver WebDriver
//    {
//        get
//        {
//            if (BrowserThread.Value == null)
//            //if (webDriver == null)
//            {
//                throw new NullReferenceException("The driver instance was not initialized. You should first call the method startDriver.");
//            }
//            return BrowserThread.Value;
//            //return webDriver;
//        }

//        private set
//        {
//            driver = value;
//        }
//    }

//    public void StartDriver()
//    {
//        BrowserThread.Value = new ChromeDriver();
//        //BrowserType
//    }

//    /*
//     public void StartDriver (DriverType driverType)
//     {
//       switch (driverType)
//       {               
//        case DriverType.Chrome:
//            ThreadDriver = new ThreadLocal<IWebDriver>(() =>
//            {
//                return new ChromeDriver(Utils.DriverHelper.DriverPath());  
//            },true);                 

//            break;               
//        default:
//            break;
//      }           
//    }
//  */








//    public void CloseWebDriver()
//    {
//        //WebDriver.Close();
//        //WebDriver.Quit();
//        //WebDriver = null;
//        //ThreadDriver.Value.Close();
//        BrowserThread.Value.Quit();
//        BrowserThread.Values.Clear();
//    }

//}

//IWebDriver webDriver;
//ThreadLocal<IWebDriver> ThreadDriver;
//private DriverFactory()
//{

//    //Do not instance out side
//}
//public static DriverFactory instance = new DriverFactory();
//public static DriverFactory Instance()
//{
//    return instance;
//}
///// <summary>
///// This method is use for return WebDriver
///// </summary>
//public IWebDriver WebDriver
//{
//    get
//    {
//        if (ThreadDriver.Value == null)
//        //if (webDriver == null)
//        {
//            throw new NullReferenceException("The driver instance was not initialized. You should first call the method startDriver.");
//        }
//        return ThreadDriver.Value;
//        //return webDriver;
//    }

//    private set
//    {
//        webDriver = value;
//    }
//}
//public void StartDriver()
//{

//    ThreadDriver   = new ThreadLocal<IWebDriver>(()=> {
//        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
//        return new ChromeDriver();
//                                                     },true);

//}
///// <summary>
///// This method is use for close WebDriver
///// </summary>
//public void CloseWebDriver()
//{
//    //WebDriver.Close();
//    //WebDriver.Quit();
//    //WebDriver = null;
//    //ThreadDriver.Value.Close();
//    ThreadDriver.Value.Quit();
//    ThreadDriver.Values.Clear();
//}

