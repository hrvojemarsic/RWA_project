﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class BuyerDB
    {
        public int IDBuyer { get; set; }

        [Required(ErrorMessage = "Ime je obavezno!")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail je obavezno!")]
        [StringLength(50, ErrorMessage = "Maksimalan broj znakova je 50")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unesite ispravnu e-mail adresu!")]
        public string Email { get; set; }
        public string Tel { get; set; }

        [Display(Name = "Grad")]
        [Required(ErrorMessage = "Niste odabrali grad")]
        public int CityID { get; set; }
    }
}