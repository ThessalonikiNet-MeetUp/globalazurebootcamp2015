using MySQLTestApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MySQLTestApp.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.GetAsync("http://192.168.23.6:9000/agent/status").Result;
                JsonSerializer ser = new JsonSerializer();
                StringReader sr = new StringReader(response.Content.ReadAsStringAsync().Result);

                Status status = (Status)ser.Deserialize(sr, typeof(Status));
                return View(status);
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}