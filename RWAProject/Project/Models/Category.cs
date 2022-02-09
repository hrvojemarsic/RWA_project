using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Category
    {
        public int IDCategory { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        [StringLength(50, ErrorMessage = "Maksimalna duljina naziva je 50 znakova!")]
        public string Name { get; set; }
    }
}