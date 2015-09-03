using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex3
{
    public partial class Default : System.Web.UI.Page
    {    
        Label lName, lFName, lLastName, lDate, lEMail, lCountry, lSity;
        TextBox name, fName, lastName, mailBox, dateBox;
        Calendar calendar;
        DataSet dSet;
        DropDownList dDL;
        DropDownList dDLSity;
        ValidationSummary sumVal;
        protected void LoadControls()
        {
            //__________Nick Name______________

            lName = new Label();
            lName.Text = "Nick Name:    ";
            lName.ID = "Nick Name";
            form1.Controls.Add(lName);
            name = new TextBox();
            name.ID = "idName";
            form1.Controls.Add(name);
            NotNullValidation(name,lName);
            form1.Controls.Add(new LiteralControl("<br />"));
            //_________First Name____________

            lFName = new Label();
            lFName.Text = "First Name:  ";
            lFName.ID = "First Name";
            form1.Controls.Add(lFName);
            fName = new TextBox();
            fName.ID = "idFirName";
            form1.Controls.Add(fName);
            NotNullValidation(fName,lFName);
            EqualValidation(fName, name, lName);


            form1.Controls.Add(new LiteralControl("<br />"));
            //_________Last Name____________

            lLastName = new Label();
            lLastName.Text = "Last Name:  ";
            lLastName.ID = "Last Name";
            form1.Controls.Add(lLastName);
            lastName = new TextBox();
            lastName.ID = "idLastName";
            form1.Controls.Add(lastName);
            NotNullValidation(lastName, lLastName);
            EqualValidation(lastName, fName, lFName);
            form1.Controls.Add(new LiteralControl("<br />"));
            //_________Calendar____________
            lDate = new Label();
            lDate.Text = "Date of Birth:  ";
            lDate.ID = "Date of Birth";
            form1.Controls.Add(lDate);
            dateBox = new TextBox();
            dateBox.ID = "idDateBox";
            form1.Controls.Add(dateBox);
            calendar = new Calendar();
            calendar.ID = "idCal";
            form1.Controls.Add(calendar);
            calendar.SelectionChanged += new EventHandler(CalendarClick);
            NotNullValidation(dateBox, lDate);
            RangeValidation(dateBox);
            form1.Controls.Add(new LiteralControl("<br />"));
            //_________E-mail____________

            lEMail = new Label();
            lEMail.Text = "E-mail:  ";
            lEMail.ID = "E-mail";
            form1.Controls.Add(lEMail);
            mailBox = new TextBox();
            mailBox.ID = "idE-mailBox";
            mailBox.ValidationGroup = "Group1";
            form1.Controls.Add(mailBox);
            NotNullValidation(mailBox, lEMail);
            RegularExpression(mailBox);
            form1.Controls.Add(new LiteralControl("<br />"));
            //_________Country____________

            lCountry = new Label();
            lCountry.Text = "Country:  ";
            form1.Controls.Add(lCountry);
            dDL = new DropDownList();
            dDL.AutoPostBack = true;
            string dbConn = ConfigurationManager.ConnectionStrings["DataCountry"].ToString();
            SqlConnection connection1 = new SqlConnection(dbConn);
            connection1.Open();
            string commandText = "SELECT [Country] FROM [Table]";
            dSet = new DataSet();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();// Назначаем новый адаптер
            sqlDataAdapter1.SelectCommand = new SqlCommand(commandText, connection1);// Указываем объекту DataAdapter, какие данные он должен получить и откуда
            sqlDataAdapter1.Fill(dSet, "Table");// Теперь заполняем находящийся в памяти объект DataSet данными
            for (int i = 0; i < dSet.Tables["Table"].Rows.Count; i++)
            {
                dDL.Items.Add(dSet.Tables["Table"].Rows[i].ItemArray[0].ToString());
            }
            dDL.SelectedIndexChanged += new EventHandler(SelectedCountry);
            form1.Controls.Add(dDL);
            form1.Controls.Add(new LiteralControl("<br />"));
            //_________Sity____________

            lSity = new Label();
            lSity.Text = "Sity:  ";
            form1.Controls.Add(lSity);
            dDLSity = new DropDownList();
            commandText = "SELECT * FROM [TableS]";
            dSet = new DataSet();
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();// Назначаем новый адаптер
            sqlDataAdapter2.SelectCommand = new SqlCommand(commandText, connection1);// Указываем объекту DataAdapter, какие данные он должен получить и откуда
            sqlDataAdapter2.Fill(dSet, "TableS");// Теперь заполняем находящийся в памяти объект DataSet данными
            for (int i = 0; i < dSet.Tables["TableS"].Rows.Count; i++)
            {
                if ((dDL.SelectedIndex + 1).ToString() == dSet.Tables["TableS"].Rows[i].ItemArray[2].ToString())
                    dDLSity.Items.Add(dSet.Tables["TableS"].Rows[i].ItemArray[1].ToString());
            }
            form1.Controls.Add(dDLSity);
            connection1.Close();
            form1.Controls.Add(new LiteralControl("<br />"));
            //___________Buttons______________

            Button btSubmit = new Button();
            btSubmit.ID = "Button";
            btSubmit.Text = "Submit";
            btSubmit.Click += new EventHandler(Button_Click_Submit);
            form1.Controls.Add(btSubmit);
            Button btReset = new Button();
            btReset.ID = "rButton";
            btReset.Text = "Reset";
            btReset.Click += new EventHandler(Button_Click_Reset);
            form1.Controls.Add(btReset);

            sumVal = new ValidationSummary();
            sumVal.ID = "IdSumVal";
            sumVal.ForeColor = Color.Red;
            form1.Controls.Add(sumVal);
            form1.Controls.Add(new LiteralControl("<br />"));
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            
            
        }
        protected void SelectedCountry(object sender, EventArgs e)
        {
            dDLSity.Items.Clear();
            for (int i = 0; i < dSet.Tables["TableS"].Rows.Count; i++)
            {
                if ((dDL.SelectedIndex + 1).ToString() == dSet.Tables["TableS"].Rows[i].ItemArray[2].ToString())
                    dDLSity.Items.Add(dSet.Tables["TableS"].Rows[i].ItemArray[1].ToString());
            }
        }
        protected void CalendarClick(object sender, EventArgs e)
        {
            dateBox.Text =calendar.SelectedDate.ToShortDateString();
        }
        protected void Button_Click_Submit(object sender, EventArgs e)
        {
            
        }
        void NotNullValidation(TextBox tb, Label l)
        {
            RequiredFieldValidator rFV = new RequiredFieldValidator();
            rFV.ControlToValidate = tb.ID;
            rFV.ErrorMessage = l.ID + " Must be not null!";
            rFV.ForeColor = Color.Red;
            form1.Controls.Add(rFV);

        }
        void RangeValidation(TextBox tb)
        {
            RangeValidator rV = new RangeValidator();
            rV.MaximumValue = DateTime.Today.ToShortDateString();
            rV.MinimumValue = "12/1/1960";
            rV.ErrorMessage = "Must be between 12/1/1960 and now!";
            rV.ControlToValidate = tb.ID;
            rV.ForeColor = Color.Red;
            form1.Controls.Add(rV);
        }
        void RegularExpression(TextBox tb)
        {
            RegularExpressionValidator rEV = new RegularExpressionValidator();
            rEV.ControlToValidate = tb.ID;
            rEV.ValidationExpression = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            rEV.ErrorMessage = "E-Mail provided is invalid!";
            rEV.Text = "E-Mail provided is invalid!";
            rEV.ForeColor = Color.Red;
            form1.Controls.Add(rEV);
        }
        void EqualValidation(TextBox controlToValidate, TextBox valueToCompare, Label l)
        {
            CompareValidator cv = new CompareValidator();
            cv.Type = ValidationDataType.String;
            cv.ControlToValidate = controlToValidate.ID;
            cv.Operator = ValidationCompareOperator.Equal;
            cv.ValueToCompare = valueToCompare.Text;
            cv.ErrorMessage = "Shoul be not equal to " + l.ID + "!";
            cv.Text = "Shoul be not equal to " + l.ID + "!";
            cv.ForeColor = Color.Red;
            form1.Controls.Add(cv);
        }
        protected void Button_Click_Reset(object sender, EventArgs e)
        {
            name.Text = lastName.Text = mailBox.Text = fName.Text = dateBox.Text = null;
            
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadControls();
        }
    }
}