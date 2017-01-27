using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.UI.Composition.Effects;

namespace TaskList.src
{
    class Dashboard
    {
        public static List<Dashboard> Dashboards = new List<Dashboard>();
        private string _name;
        private string _desc;
        private string _created;
        private int _id;
        private int _count;
        private List<Task> Tasks { get; set; }

        public void AddTask(Task t)
        {
            t.Id = _count++;
            Tasks.Add(t);            
        }

        public void RemoveTask(Task t)
        {
            Tasks.Remove(t);
        }

        public List<Task> FirstHalfTask()
        {
            List<Task> list = new List<Task>();

            for (int i = 0; i < Tasks.Count / 2; i++)
            {
                list.Add(Tasks[i]);
            }
            return list;
        }

        public List<Task> SecondHalfTask()
        {
            List<Task> list = new List<Task>();

            for (int i = Tasks.Count / 2; i < Tasks.Count; i++)
            {
                list.Add(Tasks[i]);
            }
            return list;
        }

        public Dashboard(int id, string name, string desc, string created)
        {
            _name = name;
            _desc = desc;
            _created = created;
            _id = id;
            _count = 0;
            Tasks = new List<Task>();
        }

        public Dashboard()
        {
            _count = 0;
            _id = 0;
            _name = "default";
            _desc = "default";
            _created = DateTime.Now.ToString();
            Tasks = new List<Task>();
        }

        public int Id { get { return _id; } set { _id = value; } }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public string Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public override string ToString()
        {
            return this.Name + " : " + this.Description + ". Created : " + this.Created;
        }

        public static List<Dashboard> GetDashboards()
        {
            return Dashboards;
        }

        public static int GetMax()
        {
            int id = 0;

            foreach (var v in Dashboards)
            {
                if (v.Id > id)
                    id = v.Id;
            }
            return id;
        }

        public static void AddDashboard(Dashboard param)
        {
            param.Id = Dashboard.GetMax() + 1;
            Dashboards.Add(param);
        }

        public static void RemoveDashboard(Dashboard param)
        {
            Dashboards.Remove(param);
        }

        public static Dashboard GetDashboardByName(string name)
        {
            return (from t in Dashboards where t.Name == name select (t)).FirstOrDefault();
        }

        public static Dashboard GetDashboardById(int name)
        {
            return (from t in Dashboards where t.Id == name select (t)).FirstOrDefault();
        }

        public static List<Dashboard> GetFirstHalf()
        {
            List<Dashboard> list = new List<Dashboard>();

            for (int i = 0; i < Dashboards.Count / 2; i++)
            {
                list.Add(Dashboards[i]);
            }
            return list;
        }

        public static List<Dashboard> GetSecondHalf()
        {
            List<Dashboard> list = new List<Dashboard>();

            for (int i = Dashboards.Count / 2; i < Dashboards.Count; i++)
            {
                list.Add(Dashboards[i]);
            }
            return list;
        }
    }
}
