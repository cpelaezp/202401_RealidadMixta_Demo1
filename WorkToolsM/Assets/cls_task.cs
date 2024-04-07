using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class cls_Task
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }

    }

    public class Listcls_Message
    {
        public List<cls_Message> Tasks;
    }

    public class cls_Message
    {
        public int id { get; set; }
        public string from { get; set; }
        public int type { get; set; }
        public DateTime dateSend { get; set; }
        public DateTime dateRead { get; set; }
        public string message { get; set; }
        public string status { get; set; }

    }

    public class cls_Mail
    {
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime dateSend { get; set; }
        public DateTime dateRead { get; set; }
        public string message { get; set; }
        public string status { get; set; }

    }
}
