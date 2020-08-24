using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _154AmnaAlwzrah.App_Code
{
    public class NewCustomer
    {
        //properties mapped to the the web form
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int CountryID { get; set; }
        public Boolean Active { get; set; }

    }
}