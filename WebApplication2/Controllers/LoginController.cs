using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if("admin".Equals(name)&& "123".Equals(password))
            {
                //HttpContext.Session.SetString(name, "asd");

                //Session["Kullanıcı"] = User();
                //Session["user"] = new User() { Login = name, Name = "Jennifer" };
                //return RedirectToAction("Index", "Home");

            }
            return View();
        }
    }
}