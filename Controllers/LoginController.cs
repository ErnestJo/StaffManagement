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
    public class LoginController : Controller
    {

        public const string SessionName = "_Name";
        public const string SessionId = "0";
        public const string SessionStaffId = "0";
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewData["resCode"] = "";
            ViewData["resMsg"] = "";
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login([Bind] Loginuser user)
        {
            ViewData["errorCode"] = "";
            ViewData["errorMessage"] = "";
            try
            {
                if (user.username == "" || user.username == null)
                {
                    ViewData["errorMessage"] = "Please enter username";
                    ViewData["errorCode"] = "lmserror";
                }

                if (user.password == "" || user.password == null)
                {
                    ViewData["errorMessage"] = "Please enter Password";
                    ViewData["errorCode"] = "lmserror";
                }
                var Client = new RestClient();

                JObject staffObject = new JObject();

                staffObject.Add("password", user.password);
                staffObject.Add("username", user.username);

                RestRequest Request = new RestRequest(AppConstant.URL_AUTH, Method.POST);
                Request.AddParameter("application/json", staffObject, ParameterType.RequestBody);
                         
                IRestResponse Response = Client.Execute(Request);
                //LoginData LoginSession = null;
                if (Response.Content != "")
                {
                    string rawResponse = Response.Content;
                    List <LoginData> LoginSession = JsonConvert.DeserializeObject<List<LoginData>>(rawResponse);
                    string returnedAuthId = LoginSession[0].data[0].auth_id.ToString();
                    string returnedUserName = LoginSession[0].data[0].first_name + " " + LoginSession[0].data[0].middle_name + " " + LoginSession[0].data[0].last_name;
                    string returnedStaffId = LoginSession[0].data[0].staff_id.ToString();

                    HttpContext.Session.SetString(SessionName, returnedUserName);
                    HttpContext.Session.SetString(SessionStaffId, returnedStaffId);
                    HttpContext.Session.SetString(SessionId, returnedAuthId);

                    Session.MySessionName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(returnedUserName.ToLower());
                    Session.MySessionId = returnedAuthId;
                    Session.MySessionStaffId = returnedStaffId;

                    return RedirectToAction("Index", "Home");
                }
                            
                else
                
                    {
                        ViewData["errorMessage"] = "fala wewe ";
                        ViewData["errorCode"] = "SystemError";
                    }
                
            }
            catch (Exception ex)
            {
                ViewData["errorMessage"] = "Sorry Techical Error Occured";
                ViewData["errorCode"] = "SystemError";
            }
            return View();
        }
    }
}
