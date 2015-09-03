using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI.WebControls;

namespace ASP_ex5
{
    
    [Serializable]
    public class ResourceObj
    {
        private static string path = null;
        public string key {get;set;}
        public string value { get; set; }
        public string comment { get; set; }
        static List<ResourceObj> l;
        public ResourceObj()
        {
            this.key = null;
            this.value = null;
            this.comment = null;
        }
        public ResourceObj(Random rand)
        {
            this.key = rand.NextDouble().ToString();
            this.value = rand.NextDouble().ToString();
            this.comment = rand.NextDouble().ToString();
        }
        public ResourceObj(string key, string value, string comment)
        {
            this.key = key;
            this.value = value;
            this.comment = comment;
        }
        public static void InsertEmployee(ResourceObj emp)
        {
            l.Add(emp);
            ResourceWriter rsxw = new ResourceWriter(path);
            for (int i = 0; i < l.Count; i++)
            {
                rsxw.AddResource("obj" + i.ToString(), l[i]);
            }
            rsxw.Close();
        }
        public static void InsertEmployee(string key, string value, string comment)
        {
            bool temp = false;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].key == key)
                {
                    temp = true;
                }               
            }
            if(temp ==false)
                l.Add(new ResourceObj(key, value, comment));
            ResourceWriter rsxw = new ResourceWriter(path);

            for (int i = 0; i < l.Count; i++)
            {
                    rsxw.AddResource("obj" + i.ToString(), l[i]);
            }
            rsxw.Close();
        }
        public static void UpdateEmployee(ASP_ex5.ResourceObj emp)
        {
            ResourceWriter rsxw = new ResourceWriter(path);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].key == emp.key)
                {
                    l[i].comment = emp.comment;
                    l[i].key = emp.key;
                    l[i].value = emp.value;

                }
                rsxw.AddResource("obj" + i.ToString(), l[i]);
            }
            rsxw.Close();
        }

        public static void UpdateEmployee(string key, string value, string comment)
        {
            ResourceWriter rsxw = new ResourceWriter(path);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].key == key)
                {
                    l[i].comment = comment;
                    l[i].key = key;
                    l[i].value = value;

                }
                rsxw.AddResource("obj" + i.ToString(), l[i]);
            }
            rsxw.Close();
        }

        public static void DeleteEmployee(ASP_ex5.ResourceObj emp)
        {
            ResourceWriter rsxw = new ResourceWriter(path);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].key != emp.key)
                {
                    rsxw.AddResource("obj" + i.ToString(), l[i]);
                }
            }
            rsxw.Close();

        }
        public static void DeleteEmployee(string key, string value, string comment)
        {
            ResourceWriter rsxw = new ResourceWriter(path);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].key != key)
                {
                    rsxw.AddResource("obj" + i.ToString(), l[i]);
                }
            }
            rsxw.Close();
        }

        //public ResourceObj GetEmployee(int employeeID)
        //{ 
        //    ResourceObj l = new Resourc;
            
        //    /* ... */
        
        //    return l;
        //}

        public List<ResourceObj> GetEmployees(string f)
        {
            l = new List<ResourceObj>();
            path = f;
            if (path != null)
            {
                using (ResourceReader resourceReader = new ResourceReader(path))
                {
                    foreach (DictionaryEntry entry in resourceReader)
                    {

                        l.Add((ResourceObj)entry.Value);
                    }
                }
            }
            return l;

        }

        public int CountEmployees()
        { int count=0;/* ... */ return count; }
    }
}