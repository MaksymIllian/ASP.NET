using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex2
{
    public partial class Page2 : System.Web.UI.Page
    {
        string[] refer = new string[3];
        Methods M = new Methods();
        protected void AddText(string name, string label)
        {
            int temp;
            try
            {
                temp = (int)Application[name];
            }
            catch (System.NullReferenceException exp)
            {
                temp = 0;
            }
            TextBox1.Text += label;
            TextBox1.Text += temp.ToString() + Environment.NewLine;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            M.AddReferences(refer);
            if (!this.IsPostBack)
            {
                Application.Lock();
                int counter = 0;
                if (Application["PageLoad2"] != null)
                {
                    counter = (int)Application["PageLoad2"];
                }
                Application["PageLoad2"] = counter + 1;
                Application.UnLock();

                TextBox1.Text = null;
                AddText("Session_Start", "Количество посетителей (за день): ");
                AddText("BeginRequest", "Количество запросов к web-приложению (за все время): ");
                AddText("BeginRequestPerDay", "Количество запросов к web-приложению (за день): ");
                AddText("AuthenticateRequest", "Количество уникальных посетителей (за все время): ");
                AddText("PageLoad1", "Количество запросов к 1 странице: ");
                AddText("PageLoad2", "Количество запросов к 2 странице: ");
                AddText("PageLoad3", "Количество запросов к 3 странице: ");
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(refer[0]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(refer[1]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(refer[2]);
        }
    }
}