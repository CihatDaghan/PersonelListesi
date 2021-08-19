using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Models
{
    public class UserAdd
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public IFormFile image { get; set; }
        public IFormFile image1 { get; set; }
        public IFormFile image2 { get; set; }
        public int departman { get; set; }
        public string birthday { get; set; }
        public string adminInformation{ get; set; }
    }
}
