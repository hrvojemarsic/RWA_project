using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Subcategory
    {
        public int IDSubcategory { get; set; }

        [Required(ErrorMessage = "Naziv potkategorije je obavezan")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Odaberite kategoriju kojoj pripada ova potkategorija")]
        public int CategoryID { get; set; }
    }
}