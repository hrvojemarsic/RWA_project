using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class BillDetail
    {
        public int ID { get; set; }
        public string Product { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public int BillID { get; set; }
    }
}