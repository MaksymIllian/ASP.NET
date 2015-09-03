using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_ex6
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                List<string> ans = new List<string>();
                ans.Add("такого");
                ans.Add("сякого");
                ans.Add("Хуйого");
                ServerControl11.size = 12;
                ServerControl11.listOfQuestions.Add("Какого?");
                ServerControl11.listOfAnswers.Add(ans);
                ServerControl11.listOfTrueAnswers.Add("Хуйого");
                ServerControl11.listOfQuestions.Add("Зачем?");
                ans = new List<string>();
                ans.Add("Надо");
                //ans.Add("Не надо");
                ans.Add("Хуйадо");
                ServerControl11.listOfTrueAnswers.Add("Хуйадо");
                ServerControl11.listOfAnswers.Add(ans);
                ServerControl11.listOfQuestions.Add("Как вам тест?");
                ans = new List<string>();
                ans.Add("норм");
                ans.Add("я банан");
                ans.Add("я охуевая с вас");
                ServerControl11.listOfTrueAnswers.Add("я банан");
                ServerControl11.listOfAnswers.Add(ans);
 
 
            
        }
    }
}