using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Bill
    {
        public int IDBill { get; set; }

        [Required(ErrorMessage = "Datum izdavanja je obavezno polje!")]
        [DataType(DataType.DateTime, ErrorMessage = "Format datuma nije ispravan!")]
        public DateTime DateOfIssue { get; set; }

        [Required(ErrorMessage = "Broj računa je obavezno polje!")]
        [StringLength(25, ErrorMessage = "Maksimalan broj znakova je 25!")]
        public string BillNumber { get; set; }

        public int BuyerID { get; set; }
        public int CommercialistID { get; set; }
        public int CreditCardID { get; set; }

        [StringLength(128, ErrorMessage = "Maksimalan broj znakova je 128!")]
        public string Comment { get; set; }
    }
}