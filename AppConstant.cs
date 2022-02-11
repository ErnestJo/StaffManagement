
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MystaffTool
{
    public class AppConstant
    {
        public static string GetSettingsVal( string tag_name)
        {
            var value = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MySettings")[tag_name];
            return value;
        }

        private static string _ip_address = GetSettingsVal("IpAddress");
        private static string _port_no = GetSettingsVal("IpPort");

        private static string BASE_URL = "http://" + _ip_address + ":" + _port_no + "/";

        // API For athentication
        public static string URL_AUTH = BASE_URL + "api/login";


        //API for point  
        public static String URL_POINT_STATS = BASE_URL + "api/get_project_dashboard_stats";



        // API for shared
        public static String URL_GET_STAFFS = BASE_URL + "api/get_staffs";
    }
}
