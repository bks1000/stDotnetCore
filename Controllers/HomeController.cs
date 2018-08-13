using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Utils;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private MysqlDataContext context;
        private readonly AppConfigurationServices config;
        public HomeController(MysqlDataContext context, AppConfigurationServices config)
        {
            this.context = context;
            this.config = config;
        }

        public IActionResult Index()
        {
            //MysqlDataContext context = new MysqlDataContext();
            List<User> lst = context.User.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = config.AppConfigurations.FileUpPath;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
