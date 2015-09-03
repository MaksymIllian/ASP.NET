using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex2
{
    public partial class Default : System.Web.UI.Page
    {
        string[] refer = new string[3];
        Methods M = new Methods();

        protected void Page_Load(object sender, EventArgs e)
        {
            M.AddReferences(refer);
            if (!this.IsPostBack)
            {
                Application.Lock();

                int counter = 0;
                if (Application["PageLoad1"] != null)
                {
                    counter = (int)Application["PageLoad1"];
                }
                Application["PageLoad1"] = counter + 1;
                Application.UnLock();
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