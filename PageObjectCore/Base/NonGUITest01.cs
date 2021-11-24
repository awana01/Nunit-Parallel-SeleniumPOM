using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PageObjectCore.Base
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class NonGUITest01
    {

        [Test]
        public void Test_projectConfig()
        {
            var x = ProjectConfig.GetProjectConfig();
            Console.WriteLine("Browsers:" + x.browsers_options.firefox_options1);
        }

        [Test]
        public void Test_Dirs()
        {
            //string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            //string projectbinPath = new Uri(actualPath).LocalPath;

            var DirectoryofExecution = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string csProjectDir = DirectoryofExecution.Parent.Parent.Parent.FullName;
            string Root = DirectoryofExecution.Parent.FullName;
            string[] dirs = DirectoryofExecution.ToString().Split(@"\");


            //Console.WriteLine("pth:" + pth);
            //Console.WriteLine("actualPath:"+ actualPath);
            //Console.WriteLine("projectbinPath:"+ projectbinPath);


            Console.WriteLine("currentDirectory:"+ DirectoryofExecution);
            Console.WriteLine("projectDirectory:"+ csProjectDir);
            Console.WriteLine("Root:" + Root);
            Console.WriteLine("Total Depth of dirs:" + dirs.Length);
            foreach(string dir in dirs)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine(Settings.ProjectDir);




        }


    }
}
