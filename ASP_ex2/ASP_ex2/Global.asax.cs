using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;

namespace ASP_ex2
{
    public class Global : System.Web.HttpApplication
    {
        
        public void Add(string name)
        {
            Debug.WriteLine(name);

            //Значит зашёл новый посетитель (увеличиваем на 1)!

            Application.Lock();
            int count = 0;
            if (Application[name] != null)
                count = (int)Application[name];
            count++;
            Application[name] = count;
            // Снять монопольный доступ. 

            Application.UnLock();
        }
        protected void Function()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerEvent);
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Function();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                // Not a postback 
                Add("Session_Start");
            }
            else if (Request.HttpMethod == "POST")
            {
                Debug.WriteLine("Session_Start");
                //Значит зашёл новый посетитель (увеличиваем на 1)!
                Add("Session_Start");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                // Not a postback 
          //      Add("BeginRequest");
            }
            else if (Request.HttpMethod == "POST")
            {
                Add("BeginRequest");
                Add("BeginRequestPerDay");
            
            }
 
        }
        protected void TimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 0)
            {
                Application["BeginRequestPerDay"] = 0;
                Application["Session_Start"] = 0;
            }
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
           //     Add("AuthenticateRequest");
            }
            else if (Request.HttpMethod == "POST")
            {
                Add("AuthenticateRequest");
            }
 
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}