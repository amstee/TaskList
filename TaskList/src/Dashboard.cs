using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.src
{
    class Dashboard
    {
        private string _name;
        private string _desc;
        private string _created;
        private int _id;
        private ObservableCollection<Task> Tasks { get; set; }

        public Dashboard(int id, string name, string desc, string created)
        {
            _name = name;
            _desc = desc;
            _created = created;
            _id = id;
        }

        public Dashboard()
        {
            _id = 0;
            _name = "default";
            _desc = "default";
            _created = "default";
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

        public static List<Dashboard> GetListDashboards()
        {
            var dashboards = new List<Dashboard>();

            dashboards.Add(new Dashboard(2, "First dashboard", "This is my first dashboard", "25/01/2017"));
            dashboards.Add(new Dashboard(1, "Second dashboard", "This is my second dashboard", "25/01/2017"));
            return (dashboards);
        }

        public static ObservableCollection<Dashboard> GetDashboards()
        {
            var dashboards = new ObservableCollection<Dashboard>();

            dashboards.Add(new Dashboard(2, "First dashboard", "This is my first dashboard", "25/01/2017"));
            dashboards.Add(new Dashboard(1, "Second dashboard", "This is my second dashboard", "25/01/2017"));
            return (dashboards);
        }
    }
}
