using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Web;
//using ImageMagick;

using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectCore.Base;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Core;
//using AutomCore1.Web.Utils;

namespace Web
{


    [TestFixture(Author = "unickq", Description = "Examples")]
    [AllureNUnit]
    public class TestBase
    {
        protected IWebDriver _driver;
        protected Actions action;



        //protected static string _projBasePath = ProjectSettings.GetProjectBaseDirectory(); //GetProjectBaseDirectory();
        protected string TimeToken { get; } = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        //protected string ProjectBase  = ProjectSettings.GetProjectBaseDirectory();     //GetProjectBaseDirectory();
        protected string _completeTestName = string.Empty;// { get; } = null; // completeTestName()

        [OneTimeSetUp]
        public void TestStartMethod()
        {
           
            _driver = DriverFactory.GetDriver("");
        }


        [OneTimeTearDown]
        public void TestFinishMethod()
        {
            _driver.Close();
            _driver.Quit();
            //DriverFactory.CloseDriver();
        }
    }
        /*
        public string GetDateTimeToken()
        {
            return DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
        }

        public static string completeTestName()
        {
            return TestContext.CurrentContext.Test.ClassName+"."+TestContext.CurrentContext.Test.MethodName; //.ClassName;
        }

        //public string SetupProjectDirectory()
        //{
        //    string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //    string projectPath = new Uri(actualPath).LocalPath;
        //    try
        //    {
        //        Console.WriteLine($"SetupResources Path1 :{Path.GetFullPath("../../../../")}");
        //        Console.WriteLine($"SetupResources Path2 :{Path.GetFullPath("../../../")}");
        //        Console.WriteLine($"SetupResources Path3 :{Path.GetFullPath("../../")}");
        //        Console.WriteLine($"SetupResources Path4 :{Path.GetFullPath("../")}");

        //        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        //        string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;
        //        //Console.WriteLine($"project directory :{projectDirectory}");

        //        bool result_exists = System.IO.Directory.Exists(projectDirectory + "/Results");
        //        if (!result_exists)
        //        {
        //            System.IO.Directory.CreateDirectory(projectDirectory + "/Results");
        //            System.IO.Directory.CreateDirectory(projectDirectory + "/Results/SnapShots");
        //        }
        //        bool _snapDir = System.IO.Directory.Exists(projectDirectory + "/Results/SnapShots");
        //        if (!_snapDir) { System.IO.Directory.CreateDirectory(projectDirectory + "/Results/SnapShots"); }
        //        //Console.WriteLine("============");

        //        Console.WriteLine($"Uri format path to calling Assenbly: {pth}");
        //        Console.WriteLine($"Uri format Actual project Path: {actualPath}");
        //        Console.WriteLine($"Local root: {projectPath}");
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return projectPath;
        //}
        
        //public static string GetProjectBaseDirectory()
        //{
        //    string projectPath = string.Empty;
        //  try { 
        //       var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        //       string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;


        //    Console.WriteLine("project Directory {0}",projectDirectory);
            
        //    string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        //    projectPath = new Uri(actualPath).LocalPath;
        //}
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return projectPath;
        //}
        
        public static Dictionary<string,string> GetProjectConfigData()
        {
            //string proj_path = new TestSetUp().GetProjectBaseDirectory();
            ArrayList data1 = new ArrayList();
            Dictionary<string,string> data = new Dictionary<string, string>();
            //Console.WriteLine(ProjectSettings.ExecutingDir());

            // using (StreamReader r = new StreamReader(_projBasePath+"/projectConfig.json")) //"E:/docker/docker-dotnet/PomCore31/PomCore31/
            // {
            //     string json = r.ReadToEnd();
            //     dynamic array = JsonConvert.DeserializeObject(json);
            //     
            //     foreach(var item in array)
            //     {
            //         data.Add(item.browser);
            //     }
            // }
            //
            // using (StreamReader r = new StreamReader(_projBasePath+"/conf.json")) //"E:/docker/docker-dotnet/PomCore31/PomCore31/
            // {
            //     string json = r.ReadToEnd();
            //     //Get data into dictonory
            //     var table = JsonConvert.DeserializeObject<dynamic>(json);
            //     Console.WriteLine(table["chrome"]);
            //     Console.WriteLine(table["chrome-headless"]);
            //     
            //     
            // }
            string project_config = ProjectSettings.ExecutingDir() + "/projectConfig.json";
            using (StreamReader r = new StreamReader(project_config)) //"E:/docker/docker-dotnet/PomCore31/PomCore31/
            {
                string json = r.ReadToEnd();
                //Get data into dictonory
                //var table = JsonConvert.DeserializeObject<dynamic>(json);
                
                Dictionary<string,string>[] values = JsonConvert.DeserializeObject<Dictionary<string,string>[]>(json);
                Console.WriteLine(values[0]["chrome"]);
                Console.WriteLine(values[0]["chrome-headless"]);

                foreach (var item in values[0])
                {
                    Console.WriteLine("key: {0} value:{1} ",item.Key,item.Value);
                    if (item.Value == "true")
                    {
                        data.Add(item.Key,item.Value);
                    }
                }
            }
            return data;
        }
        
        public static string TakeShots()
        {
            string fileName = string.Format("Screenshot_" + DateTime.Now.ToString("dd-MM-yyyy-hhmm-ss") + ".png");
            string shot_dir = Path.Combine(ProjectSettings.GetProjectBaseDirectory(), "Results", "SnapShots") +"/";
            
            Screenshot ss = ((ITakesScreenshot)Browsers.getDriver).GetScreenshot();
            string path = Directory.GetCurrentDirectory();
            var ss_dir = "../../../Results/SnapShots/" + fileName;

            //Console.WriteLine("Screen Shot: {0}", ss_dir);
            ss.SaveAsFile(ss_dir);
            return fileName;
        }

        public static byte[] TakeShotsAsBase64()
        {
            Screenshot ss = ((ITakesScreenshot)Browsers.getDriver).GetScreenshot();
            byte[] fileContent = ss.AsByteArray;
            return fileContent;
        }

        public static byte[] ScreenShotAsBase64()
        {
            Screenshot ss = ((ITakesScreenshot)Browsers.getDriver).GetScreenshot();
            byte[] fileContent = ss.AsByteArray;
            return fileContent;
        }

        public static byte[] ReadImageAsBase64(String filepath)
        {
            string _b64 = Convert.ToBase64String(File.ReadAllBytes(filepath));
            byte[] _filebytes = System.Convert.FromBase64String(_b64);
            return _filebytes;
        }


        

        protected static void GifMaker(ArrayList images,String _GifFileName)
        {
            string pathToSnap = Path.Combine(ProjectSettings.GetProjectBaseDirectory(), "Results", "SnapShots")+"/";
            //Console.WriteLine("Gif Maker pathtoSnap:{0}", pathToSnap);
            try
            {
                using (MagickImageCollection collection = new MagickImageCollection())
                {
                    if (images.Count == 1)
                    {
                        ReadImageAsBase64(TakeShots());
                        Console.WriteLine("Image is only one");
                        Allure.Commons.AllureLifecycle.Instance.AddAttachment("Image1", "image/png", ReadImageAsBase64(images[0].ToString()));
                    }


                    if (images.Count > 1)
                    {
                        // Add first image and set the animation delay to 100ms
                        for (int i = 0; i < images.Count; i++)
                        {
                            collection.Add("../../../Results/SnapShots/" + images[i]);
                            //collection.Add(pathToSnap+ images[i]);

                        }

                        collection[0].AnimationDelay = 100;
                        for (int i = 1; i < images.Count; i++)  {  collection[i].AnimationDelay = 100;  }
                        QuantizeSettings settings = new QuantizeSettings();
                        settings.Colors = 256;
                        collection.Quantize(settings);
                        collection.Optimize();

                        // Save gif
                        collection.Write("../../../Results/SnapShots/" + _GifFileName + ".gif");
                        //collection.Write(pathToSnap +_GifFileName+".gif");
                    }//if
                } //using
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception :"+ pathToSnap + _GifFileName + ".gif");
            }
        }
       
        protected static void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                if (fi.Extension.Contains(".png"))
                {
                    //Console.WriteLine("file name: {0} full name: {1}",fi.Name,fi.FullName);
                    fi.Delete();
                }
            }

            // foreach (DirectoryInfo di in dir.GetDirectories())
            // {
            //     clearFolder(di.FullName);
            //     di.Delete();
            // }
        }
       
    }*/
}