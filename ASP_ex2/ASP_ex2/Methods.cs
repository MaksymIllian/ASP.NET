using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ASP_ex2
{
    public class Methods : System.Web.UI.Page
    {
        public Methods()
        { }

        public void AddReferences(string[] s)
        {
            string path = WebConfigurationManager.AppSettings["File"];
            StreamReader fs = new StreamReader(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, path));
            for (int i = 0; i < 3; i++)
            {
                s[i] = fs.ReadLine();
            }
        }

        //public void Add(string name)
        //{
        //    Debug.WriteLine(name);

        //    //Значит зашёл новый посетитель (увеличиваем на 1)!

        //    Application.Lock();
        //    int count = 0;
        //    if (Application[name] != null)
        //        count = (int)Application[name];
        //    count++;
        //    Application[name] = count;
        //    // Снять монопольный доступ. 

        //    Application.UnLock();
        //}
    }
}
