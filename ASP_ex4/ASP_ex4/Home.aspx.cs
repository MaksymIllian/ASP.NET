using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex4
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            ViewStateUserKey = "soskov";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                foreach (string File in Directory.GetFiles(Page.MapPath(".") + @"\image"))//, "*.png|*.jpg"))
                {
                    // показываем имя файла

                    DropDownListOfImages.Items.Add(File);
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           
            
            string pageurl = @"PictureHandler.ashx?url=" + Path.GetFileName(DropDownListOfImages.SelectedItem.Text+"&userKey="+ViewStateUserKey);
            Response.Write("<script>");
            Response.Write(String.Format("window.open('{0}','_blank')", @ResolveUrl(pageurl)));
            Response.Write("</script>");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('"+ pageurl +"','_newtab');", true);
        }
       
    }
}
