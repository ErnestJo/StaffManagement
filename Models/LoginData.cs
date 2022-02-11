using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MystaffTool.Models
{
    public class LoginData
    {
        public string code { get; set; }
        public string message { get; set; }
        public data[] data { get; set; }
    }
    public class data
    {
        public long auth_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public long staff_number { get; set; }
        public string email { get; set; }       
        public string gender_name { get; set; }
        public long staff_id { get; set; }
        public long is_deleted { get; set; }
    }
}
