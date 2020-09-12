using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    using System;
    using System.Collections.Generic;
    public partial class TotalProduct
    {
    
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public int Stock { get; set; }

        public DateTime Manufacture { get; set; }

        public DateTime Expire { get; set; }

        public string ImageName { get; set; }

        public string ProductDescription { get; set; }

        public int RiceId { get; set; }

        public int qty { get; set; }
        public int bill { get; set; }


        [NotMapped]
        public string CategoryName { get; set; }

        [NotMapped]
        public IFormFile ProductImage { get; set; }

        [NotMapped]
        public IFormFile Display { get; set; }

        public int CategoryId { get; set; }

        public virtual  Category  Category { get; set; }
    

}
}
