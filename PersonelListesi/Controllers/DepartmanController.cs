using Microsoft.AspNetCore.Mvc;
using PersonelListesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var userdata = c.Depart.ToList();
            return View(userdata);
        }
        [HttpGet]
        public IActionResult NewDepartman()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDepartman(Depart data)
        {
            c.Depart.Add(data);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepartman(int id)
        {
            var depart = c.Depart.Find(id);
            var userdepart= c.Users.FirstOrDefault(x => x.departman == id);
            if (userdepart == null)
            {
                c.Depart.Remove(depart);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return Content("İlgili departman altında çalışan personel mevcuttur.");
        }
        public IActionResult GetDepartman(int id)
        {
            var depart = c.Depart.Find(id);
            return View("GetDepartman", depart);
        }
        public IActionResult UpdateDepartman(Depart depart)
        {
            var data = c.Depart.Find(depart.ID);
            data.Departman = depart.Departman;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
