using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using webapp.Utils;

namespace webapp.Controllers
{
    public class MenuController : Controller
    {

        private MysqlDataContext context;
        private readonly AppConfigurationServices config;
        public MenuController(MysqlDataContext context, AppConfigurationServices config)
        {
            this.context = context;
            this.config = config;
        }
        public IActionResult Index()
        {
            //List<SP_T_BASE_MENU> lst = context.Menu.ToList();
            //ViewBag["menu"] = lst;
            return View();
        }
    }
}