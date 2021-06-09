using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Buyer
    {
        public int IDBuyer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}