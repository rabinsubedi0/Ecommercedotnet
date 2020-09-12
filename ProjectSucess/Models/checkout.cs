using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    public class checkout
    {
        [Key]
        public int checkoutId { get; set; }
        
        public int Quantity { get; set; }

        public int Total { get; set;  }

        public int ProductId { get; set; }

        [NotMapped]
        public int DisplayImage { get; set; }

    }

}
