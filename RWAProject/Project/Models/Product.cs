using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Product
    {
        public int IDProduct { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public int MinQuantityAtLager { get; set; }
        public double PriceWithoutPDV { get; set; }
        public int SubcategoryID { get; set; }
    }
}