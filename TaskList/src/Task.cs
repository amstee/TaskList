using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.src
{
    class ContextTask
    {
        public Task Task { get; set; }
        public Dashboard Context { get; set; }

        public ContextTask(Dashboard d, Task t)
        {
            Task = t;
            Context = d;
        }
    }

    class Task
    {
        private int _id;
        private string _name;
        private string _desc;
        private string _created;
        private string _deadline;
        private string _status;

        public Task(int id, string name, string status, string desc, string created, string deadline)
        {
            _id = id;
            _created = created;
            _desc = desc;
            _deadline = deadline;
            _name = name;
            _status = status;
        }

        public Task()
        {
            _id = 0;
            _name = "task";
            _desc = "description";
            _created = DateTime.Now.ToString();
            _deadline = DateTime.Now.AddHours(2).ToString();
            _status = "TODO";
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
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
    }
}
