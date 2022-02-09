using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Product
    {
        public int IDProduct { get; set; }

        [Required(ErrorMessage = "Naziv proizvoda je obavezan")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Broj proizvoda je obavezan")]
        [StringLength(25, ErrorMessage = "Maksimalan broj znakova je 25")]
        public string ProductNumber { get; set; }

        [StringLength(15, ErrorMessage = "Maksimalan broj znakova je 15")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Obavezno je odabrati minimalnu količinu proizvoda na skladištu")]
        [Range(1, 32767, ErrorMessage = "Količina mora biti između 1 i 32.767")]
        public int MinQuantityAtLager { get; set; }

        [Required(ErrorMessage = "Obavezno je postaviti cijenu proizvoda")]
        [Range(0, 1.7976931348623157E+308, ErrorMessage = "Cijena mora biti pozitivan broj")]
        public double PriceWithoutPDV { get; set; }

        [Required(ErrorMessage = "Odaberite potkategoriju")]
        public int SubcategoryID { get; set; }
    }
}