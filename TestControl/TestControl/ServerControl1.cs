using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;
using System.Reflection;
using System.Drawing.Design;
using System.Security.Permissions;
using System.Drawing;


namespace TestControl
{
    public class TestObject
    {
        string question;
        public List<RadioButton> listOfAnswers;
        public Label labelOfQuestion;
        public int answerIsDone;
        public TestObject(string question,
            List<string> listOfAnswers, int index, int size)
        {
            this.question = question;
            this.listOfAnswers = new List<RadioButton>();
            for (int i = 0; i < listOfAnswers.Count; i++)
            {
                this.listOfAnswers.Add(new RadioButton() { GroupName = "answers" + index.ToString(), AutoPostBack = true });
            }
            for (int i = 0; i < listOfAnswers.Count; i++)
            {
                this.listOfAnswers[i].Text = listOfAnswers[i];
                this.listOfAnswers[i].CheckedChanged += c;
                this.listOfAnswers[i].Font.Size = size;
                this.listOfAnswers[i].ForeColor = Color.Black;
            }
            this.labelOfQuestion = new Label();
            this.labelOfQuestion.Text = question;
            this.labelOfQuestion.Font.Size = size;

        }

        private void c(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listOfAnswers)
            {
                if (rb.Checked == true)
                    rb.ForeColor = Color.Coral;
                else
                    rb.ForeColor = Color.Black;
            }

        }
    }

    //[
    //AspNetHostingPermission(SecurityAction.Demand,
    //    Level = AspNetHostingPermissionLevel.Minimal),
    //AspNetHostingPermission(SecurityAction.InheritanceDemand,
    //    Level = AspNetHostingPermissionLevel.Minimal),

    //ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>"),
    //DefaultProperty("listOfQuestions")

    //]
    public class ServerControl1 : CompositeControl
    {
        
        //[
        //Category("Behavior"),
        //Description("The contacts collection"),
        //DesignerSerializationVisibility(
        //    DesignerSerializationVisibility.Content),
        //Editor(typeof(ContactCollectionEditor), typeof(UITypeEditor)),
        //PersistenceMode(PersistenceMode.InnerDefaultProperty)
        //]
        bool renderResult = false;
        private List<string> questions = new List<string>();
        public List<string> listOfQuestions
        {
            get { return questions != null ? questions : new List<string>(); }
            set { questions = value; }
        }
        public TestObject testOb;
        Label l, end, information;
        public List<TestObject> listOfTestObject= new List<TestObject>();
        private List<List<string>> answers = new List<List<string>>();
        public Button endButton = new Button() { ID = "idButton", Text = "End Test" };
        public List<List<string>> listOfAnswers
        {
            get { return answers != null ? answers : new List<List<string>>(); }
            set { answers=value; }
        }
        private List<string> trueAnswers = new List<string>();
        public List<string> listOfTrueAnswers
        {
            get { return trueAnswers != null ? trueAnswers : new List<string>(); }
            set { trueAnswers = value; }
        }
        private List<string> listOfUserAnswers = new List<string>();
        public int size
        {
            get;
            set;
        }
        protected override void CreateChildControls()
        {

        }
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            Page.RegisterRequiresControlState(this);
            //Controls.Clear();
            
            base.CreateChildControls();
            endButton.Click += end_Click;
            Controls.Add(endButton);

            for (int i = 0; i < listOfQuestions.Count; i++)
            {
                l = new Label();
                this.l.ID = "LabelQ" + i.ToString();
                this.l.Text = questions[i];

                testOb = new TestObject(questions[i], answers[i], i, size);
                listOfTestObject.Add(testOb);

            }
            //this.endButton.Click +=end_Click;
            end = new Label();
            this.ChildControlsCreated = true;
            for (int i = 0; i < listOfTestObject.Count; i++)
            {
                for (int j = 0; j < listOfTestObject[i].listOfAnswers.Count; j++)
                {
                    Controls.Add(listOfTestObject[i].listOfAnswers[j]);
                   
                }
            }
            information = new Label();
            information.ID = "infID";

            //base.Render();
        }
        protected void end_Click(object sender, EventArgs e)
        {
            int countOfTrueAnswers = 0, countNonChacked = 0;
            for (int i = 0; i < listOfTestObject.Count; i++)
            {
                countNonChacked = 0;
                for (int j = 0; j < listOfTestObject[i].listOfAnswers.Count; j++)
                {
                    if (listOfTestObject[i].listOfAnswers[j].Checked == true &&
                        listOfTestObject[i].listOfAnswers[j].Text == listOfTrueAnswers[i])
                    {
                        countOfTrueAnswers++;
                        listOfUserAnswers.Add(listOfTestObject[i].labelOfQuestion.Text + "\n"
                            + listOfTestObject[i].listOfAnswers[j].Text + " - Правильно.");
                    }
                    else if (listOfTestObject[i].listOfAnswers[j].Checked == true
                        && listOfTestObject[i].listOfAnswers[j].Text != listOfTrueAnswers[i])
                    {
                        listOfUserAnswers.Add(listOfTestObject[i].labelOfQuestion.Text + " "
                            + listOfTestObject[i].listOfAnswers[j].Text + " - Не правильно.");

                    }
                    else if (listOfTestObject[i].listOfAnswers[j].Checked != true)
                    {
                        countNonChacked++;
                    }
                    if (countNonChacked == listOfTestObject[i].listOfAnswers.Count)
                    {
                        listOfUserAnswers.Add(listOfTestObject[i].labelOfQuestion.Text + "\n"
                            + " - Нет ответа.");
                    }
                }
            }
            end.Text = "Количество правильных ответов: " + countOfTrueAnswers.ToString();
            renderResult = true;
            
        }

        protected override void Render(HtmlTextWriter writer)
        {
            int countDoneAnswers = 0;
            if (renderResult != true)
            {
                for (int i = 0; i < listOfTestObject.Count; i++)
                {
                    listOfTestObject[i].labelOfQuestion.RenderControl(writer);

                    new LiteralControl("<br />").RenderControl(writer);
                    for (int j = 0; j < listOfTestObject[i].listOfAnswers.Count; j++)
                    {
                        listOfTestObject[i].listOfAnswers[j].RenderControl(writer);
                        new LiteralControl("<br />").RenderControl(writer);
                        if (listOfTestObject[i].listOfAnswers[j].Checked == true)
                            countDoneAnswers++;
                    }
                    new LiteralControl("<br />").RenderControl(writer);
                    new LiteralControl("<br />").RenderControl(writer);
                }
                information.Text = "Всего вопросов: " + listOfQuestions.Count + " Из них отвечено: " + countDoneAnswers;
                Controls.Add(information);
                new LiteralControl("<br />").RenderControl(writer);
                information.RenderControl(writer);
                new LiteralControl("<br />").RenderControl(writer);
                endButton.RenderControl(writer);

            }
            else
            {
                end.RenderControl(writer);
                for (int i = 0; i < listOfUserAnswers.Count; i++)
                {
                    new LiteralControl("<br />").RenderControl(writer);
                    l.Text = listOfUserAnswers[i];
                    l.RenderControl(writer);
                }
            }
        }
        
        
    }

    //public class ContactCollectionEditor : CollectionEditor
    //{
    //    public ContactCollectionEditor(Type type)
    //        : base(type)
    //    {
    //    }

    //    protected override bool CanSelectMultipleInstances()
    //    {
    //        return false;
    //    }

    //    protected override Type CreateCollectionItemType()
    //    {
    //        return typeof(string);
    //    }
    //}

}
