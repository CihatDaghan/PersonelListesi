using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelListesi.Models
{
    public class Depart
    {
        [Key]
        public int ID { get; set; }
        public string Departman { get; set; }
    }
}
