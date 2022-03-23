using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set;}
        public string AuthorName { get; set;}
        public string AuthorAvatar { get; set;}
        public DateTime AuthorDateOfBirth { get; set;}
        public string AuthorDescription { get; set;}
        public virtual ICollection<Story> Liststory { get; set; }
        public virtual ICollection<Category> GetCategories { get; set;}
    }
}