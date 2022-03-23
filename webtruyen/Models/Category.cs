using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set;}
        public string CategoryName { get; set;}
        public string imgcate { get; set;}
        public string CategoryDesctiption { get; set;}
        public string imghot { get; set;}
        public string trangthai { get; set;}
        public string namphathanh { get; set;}
        public virtual ICollection<Story> GetStories { get; set;}
        public int? idtacgiaintheloai { get; set;}
        [ForeignKey("idtacgiaintheloai")]
        public virtual Author Author { get; set;}
        public virtual ICollection<Anhbia> Anhbias { get; set;}
    }
}