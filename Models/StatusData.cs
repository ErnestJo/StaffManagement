using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MystaffTool.Models
{
    public class StatusData
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<DataResponse> data { get; set; }

    }
    public class DataResponse
    {
      
        public long completed { get; set; }
        public long progress { get; set; }
        public long total { get; set; }

    }

    


}
