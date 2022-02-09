using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Country
    {
        public int IDCountry { get; set; }

        [Required(ErrorMessage = "Ime države je obavezno!")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50!")]
        public string Name { get; set; }
    }
}