using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex4
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    Guid UniqueID = Guid.NewGuid();
                    string fname = Path.GetFileName(FileUpload1.FileName);
                    //ID = fname + UniqueID;
                    FileUpload1.SaveAs(Server.MapPath("~/image/") + UniqueID);
                    Label1.Text = "Загрузка успешна";
                }
                catch (Exception ex)
                {
                    Label1.Text = "Ошибка загрузки";
                }
            }
        }
    }
}