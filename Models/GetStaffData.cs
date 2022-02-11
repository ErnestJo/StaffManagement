using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MystaffTool.Models
{
    public class GetStaffData
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<DataRes> data { get; set; }
    }

    public class DataRes
    {
        public long staff_id;
        public string first_name;
        public string last_name;
        public string middle_name;
        public long staff_number;
        public string gender;
        public string email;
        public string rank;
        public string status_name;

    }
 }
