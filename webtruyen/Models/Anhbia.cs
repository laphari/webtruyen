using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class Anhbia
    {
        [Key]
        public int Idanhbia { get; set;}
        public string Nameanhbia { get; set;}
        public string Namest { get; set;}
        public string motaveanhbia { get; set;}
        public DateTime ngaytao { get; set;}
        public string Imgbia { get; set;}
        public string theloaibia { get; set;}
        public int? IDtheloaibia { get; set;}
        [ForeignKey("IDtheloaibia")]
        public virtual Category Category { get; set;}
        public int? IDtensach { get; set;}
        [ForeignKey("IDtensach ")]
        public virtual Story Story { get; set;}
    }
}