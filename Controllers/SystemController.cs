using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapp.Models;

namespace webapp.Controllers
{
    public class SystemController : Controller
    {
        private MysqlDataContext context;
        public SystemController(MysqlDataContext context)
        {
            this.context = context;
        }
        public IActionResult UserManage()
        {
            List<User> lst = context.User.ToList();
            //ViewBag.users = Json(lst).Value.ToString();
            ViewBag.users = JsonConvert.SerializeObject(lst);
            ViewData["user"] = ViewBag.users;
            ViewBag.user1 = lst;
            return View(lst);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public StatusCodeResult SaveUser([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.ID))
            {
                user.ID = Guid.NewGuid().ToString();
                context.User.Add(user);
            }
            else
            {
                context.User.Update(user);
            }
            
            context.SaveChanges();
            return Ok();
        }

        /*[HttpGet] //它序列化返回的是小写的key 
        public JsonResult GetUser()
        {
            List<User> lst = context.User.ToList();
            return new JsonResult(lst);
        }*/

        [HttpGet]
        public string GetUser()
        {
            List<User> lst = context.User.ToList();
            return JsonConvert.SerializeObject(lst);//返回的和属性名称相同的大小写key
        }
    }
}