using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Bill
    {
        public int IDBill { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string BillNumber { get; set; }
        public int BuyerID { get; set; }
        public int CommercialistID { get; set; }
        public int CreditCardID { get; set; }
        public string Comment { get; set; }
    }
}