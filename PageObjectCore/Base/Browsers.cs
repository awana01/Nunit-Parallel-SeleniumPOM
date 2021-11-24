using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PageObjectCore.Base
{

    public class ProjectConfig
    {

        public static BrowsersRoot GetProjectConfig()
        {
            BrowsersRoot Browsers = null;

            string project_config = @"E:\GiT-Works\LocalRepo\PageObjectCore\PageObjectCore\Resources\browsers.json";
            
            using (StreamReader r = new StreamReader(project_config))
            {
                string json = r.ReadToEnd();
                //Get data into dictonory
                //var table = JsonConvert.DeserializeObject<dynamic>(json);

                Browsers = JsonConvert.DeserializeObject<BrowsersRoot>(json);

                
                Console.WriteLine(Browsers.browsers.name1);
                Console.WriteLine(Browsers.browsers_options.chrome_options1.Count);


                //foreach (var item in values[0])
                //{
                //    Console.WriteLine("key: {0} value:{1} ", item.Key, item.Value);
                //    if (item.Value == "true")
                //    {
                //        data.Add(item.Key, item.Value);
                //    }
                //}
            }
            return Browsers;
        }

    }






   
    public class Browsers
    {
        public string name1 { get; set; }
        public string browsers_options { get; set; }
    }

    public class BrowsersOptions
    {
        public List<string> chrome_options1 { get; set; }
        public List<string> chrome_options2 { get; set; }
        public List<object> firefox_options1 { get; set; }
    }

    public class BrowsersRoot
    {
        public Browsers browsers { get; set; }
        public BrowsersOptions browsers_options { get; set; }
    }

}
