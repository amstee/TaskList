using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.src
{
    class Task
    {
        private string _name;
        private string _desc;
        private string _created;

        private ObservableCollection<Dashboard> Dashboard { get; set; }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        private string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        private string Created
        {
            get { return _created; }
            set { _created = value; }
        }
    }
}
