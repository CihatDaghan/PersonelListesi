using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string departman { get; set; }
    }
}
