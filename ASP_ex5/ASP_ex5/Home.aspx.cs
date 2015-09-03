using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using System.Collections;
using System.Data;
using System.Web.Configuration;
using System.IO;
namespace ASP_ex5
{
    public partial class Home : System.Web.UI.Page
    {
        
        void GenerationData(int countOfObj)
        {
            Random rand = new Random();
            ResourceWriter rsxw = new ResourceWriter(Server.MapPath("~/Resources/") + "res.resx");
            for (int i = 0; i < countOfObj; i++)
            {

                rsxw.AddResource("obj" + i.ToString(), new ResourceObj(rand));
            }
            rsxw.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //GenerationData(35);
            if (IsPostBack == false)
            {
                string path = WebConfigurationManager.AppSettings["Path"];
                foreach (string File in Directory.GetFiles(Server.MapPath(path)))//, "*.png|*.jpg"))
                {

                    DropDownListWithRESX.Items.Add(File);
                    
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (ObjectDataSource1.InsertParameters["key"] != null)
                ObjectDataSource1.InsertParameters["key"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("TextBoxInsertedKey")).Text;
            if (ObjectDataSource1.InsertParameters["value"] != null)
                ObjectDataSource1.InsertParameters["value"].DefaultValue =
                    ((TextBox)GridView1.FooterRow.FindControl("TextBoxInsertedValue")).Text;
            if (ObjectDataSource1.InsertParameters["comment"] != null)
                ObjectDataSource1.InsertParameters["comment"].DefaultValue =
                    ((TextBox)GridView1.FooterRow.FindControl("TextBoxInsertedComment")).Text;
            if (ObjectDataSource1.InsertParameters["key"].DefaultValue != "") //|| ObjectDataSource1.InsertParameters["key"] != "")
            {
                
                ObjectDataSource1.Insert();
            }
            
        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
           ObjectDataSource1.ConflictDetection = ConflictOptions.CompareAllValues;
           //ObjectDataSource1.DataObjectTypeName = "ASP_ex5.ResourceObj";
        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ObjectDataSource1.ConflictDetection = ConflictOptions.OverwriteChanges;
            //ObjectDataSource1.DataObjectTypeName = null;
        }

        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ObjectDataSource1.ConflictDetection = ConflictOptions.CompareAllValues;
            //ObjectDataSource1.DataObjectTypeName = null;
        }
    }
}