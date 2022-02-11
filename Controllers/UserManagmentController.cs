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
    public class UserManagmentController : Controller
    {
        public IActionResult Index()
        {
            var Users = new RestClient();
            JObject usersObject = new JObject();

            usersObject.Add("authentication_id", Session.MySessionId);

            RestRequest Request = new RestRequest(AppConstant.URL_GET_STAFFS, Method.POST);
            Request.AddParameter("application/json", usersObject, ParameterType.RequestBody);
            IRestResponse Response = Users.Execute(Request);

            var content = Response.Content;
            List<GetStaffData> userData = JsonConvert.DeserializeObject<List<GetStaffData>>(content);


            return View(userData[0].data);
        }
    }
}
