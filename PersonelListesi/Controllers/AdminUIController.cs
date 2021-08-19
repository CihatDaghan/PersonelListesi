using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonelListesi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PersonelListesi.Controllers
{
    public class AdminUIController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var userdata = c.Users.ToList();

            List<Depart> datas = (from x in c.Depart.ToList()
                                          select new Depart{}).ToList();
            ViewBag.datas = datas.ToList();
            return View(userdata);
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            List<SelectListItem> datas = (from x in c.Depart.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Departman,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.data = datas;
            List<SelectListItem> data = (from x in c.Users.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.name,
                                              Value = x.name.ToString()
                                          }).ToList();
            ViewBag.datas = data;

            return View();
        }
        [HttpPost]
        public IActionResult NewUser(User data)
        {
            
            c.Users.Add(data);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult DeleteUser(int id)
        {
            var user = c.Users.Find(id);
            var data = c.AdminUsers.FirstOrDefault(x => x.username == Request.Cookies["name"]);
            if (Convert.ToInt16(data.departman) == 1)
            {
                c.Users.Remove(user);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Yönetici yetkisine sahip değilsiniz.");
        }
        public IActionResult GetUser(int id)
        {
            List<SelectListItem> datas = (from x in c.Depart.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.Departman,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.data = datas;
            List<SelectListItem> data = (from x in c.Users.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.name,
                                             Value = x.name.ToString()
                                         }).ToList();
            ViewBag.datas = data;
            var user = c.Users.Find(id);
            return View("GetUser", user);
        }
        public IActionResult UpdateUser(User user)
        {
            var data = c.Users.Find(user.ID);
            data.name = user.name;
            data.surname = user.surname;
            data.telephone = user.telephone;
            data.departman = user.departman;
            data.birthday = user.birthday;
            data.adminInformation = user.adminInformation;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
