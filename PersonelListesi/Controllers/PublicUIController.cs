using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonelListesi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Drawing;
using LazZiya.ImageResize;

namespace PersonelListesi.Controllers
{
    public class PublicUIController : Controller
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
        public IActionResult NewUser(UserAdd data)
        {   
            User userdata = new User();
            if (data.image != null)
            {
                var extension = Path.GetExtension(data.image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                data.image.CopyTo(stream);
                userdata.image = imagename;
                c.SaveChanges();
                stream.Close();
                var img = Image.FromFile(location);
                var scaleImage = ImageResize.Scale(img, 250, 250);
                var path = "wwwroot\\imageresize\\" + imagename;
                scaleImage.Save(path);
            }
            if (data.image1 != null)
            {
                var extension = Path.GetExtension(data.image1.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                data.image1.CopyTo(stream);
                userdata.image1 = imagename;
                c.SaveChanges();
                stream.Close();
                var img = Image.FromFile(location);
                var scaleImage = ImageResize.Scale(img, 250, 250);
                var path = "wwwroot\\imageresize\\" + imagename;
                scaleImage.Save(path);
            }
            if (data.image2 != null)
            {
                var extension = Path.GetExtension(data.image2.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", imagename);
                var stream = new FileStream(location, FileMode.Create);
                data.image2.CopyTo(stream);
                userdata.image2 = imagename;
                c.SaveChanges();
                stream.Close();
                var img = Image.FromFile(location);
                var scaleImage = ImageResize.Scale(img, 250, 250);
                var path = "wwwroot\\imageresize\\" + imagename;
                scaleImage.Save(path);
            }
            userdata.name = data.name;
            userdata.surname = data.surname;
            userdata.telephone = data.telephone;
            userdata.departman = data.departman;
            userdata.birthday = data.birthday;
            userdata.adminInformation = data.adminInformation;
            c.Users.Add(userdata);
            c.SaveChanges();
            return RedirectToAction("Index","AdminUI");

        }
    }
}
