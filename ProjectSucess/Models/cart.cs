using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    public class cart
    {

        public TotalProduct totalProduct { get; set; }
        [Key]
        public int productid { get; set; }
        public string productname { get; set; }

        public float price { get; set; }
        public int qty { get; set; }
        public float bill { get; set; }

    }
}
