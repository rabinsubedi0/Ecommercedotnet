using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    public class Category
    {
        [Key]

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual List <TotalProduct> TotalProducts { get; set; }
    }
}
