using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webtruyen.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Không được nhập chữ")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Mail")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Password { get; set; }
    }
}
