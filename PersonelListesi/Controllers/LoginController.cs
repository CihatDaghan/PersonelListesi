using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonelListesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonelListesi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(AdminUser user)
        {
            var data = c.AdminUsers.FirstOrDefault(x => x.username == user.username && x.password == user.password);
            if (data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.username)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Append("name", user.username, options);
                return RedirectToAction("Index", "AdminUI");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            var data = c.AdminUsers.FirstOrDefault(x => x.username == Request.Cookies["name"]);
            ViewBag.username = data.username;
            ViewBag.password = data.password;
            ViewBag.ıd = data.Id;
            return View();
        }


        [HttpPost]
        public IActionResult ResetPassword(AdminUser adminuser)
        {
            if (adminuser.username != null)
            {
                var data = c.AdminUsers.FirstOrDefault(x => x.username == Request.Cookies["name"]);
                data.username = adminuser.username;
                data.password = adminuser.password;
                c.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
    }
}
