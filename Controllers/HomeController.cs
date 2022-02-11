using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MystaffTool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Globalization;
using MystaffTool.Models;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace MystaffTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            var Stats = new RestClient();
            JObject statsObject = new JObject();

            statsObject.Add("authentication_id", Session.MySessionId);

            RestRequest Request = new RestRequest(AppConstant.URL_POINT_STATS, Method.POST);
            Request.AddParameter("application/json", statsObject, ParameterType.RequestBody);
            IRestResponse Response = Stats.Execute(Request);

            var content = Response.Content;
            List<StatusData> MaData = JsonConvert.DeserializeObject<List<StatusData>>(content);
            ViewData["completed"] = MaData[0].data[0].completed;
            ViewData["progress"] = MaData[0].data[0].progress;
            ViewData["total"] = MaData[0].data[0].total;
            return View();
        }

        [HttpPost]
        public IActionResult GetStats( )
        {
            try

            {
                var Stats = new RestClient();
                JObject statsObject = new JObject();

                statsObject.Add("authentication_id", Session.MySessionId );

                RestRequest Request = new RestRequest(AppConstant.URL_POINT_STATS, Method.POST);
                Request.AddParameter("application/json", statsObject, ParameterType.RequestBody);
                IRestResponse Response = Stats.Execute(Request);

                var content = Response.Content;
                List<StatusData> MaData = JsonConvert.DeserializeObject<List<StatusData>>(content);
                ViewData["completed"] = MaData[0].data[0].completed;
                ViewData["progress"] = MaData[0].data[0].progress;
                ViewData["total"] = MaData[0].data[0].total;


            }
            catch(Exception e)
            {

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
