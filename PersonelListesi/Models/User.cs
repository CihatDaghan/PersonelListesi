using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public string image { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public int departman { get; set; }
        public string birthday { get; set; }
        public string adminInformation{ get; set; }
    }
}
