using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PageObjectCore.Base
{
    public class Settings
    {
        private static string ProjectBase = null;
        
        public static string ProjectDir
        {
            get
            {
                if (ProjectBase == null) 
                {
                    ProjectBase = GetProjectBaseDir();
                    
                }
                return ProjectBase;

            }
            set
            { ProjectBase = value; }

        }



        private static string GetProjectBaseDir()
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


            //Console.WriteLine("currentDirectory:" + DirectoryofExecution);
            //Console.WriteLine("projectDirectory:" + csProjectDir);
            //Console.WriteLine("Root:" + Root);
            //Console.WriteLine("Total Depth of dirs:" + dirs.Length);
            //foreach (string dir in dirs)
            //{
            //    Console.WriteLine(dir);

            return csProjectDir;
        }





    }
}
