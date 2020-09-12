using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    public class Manager
    { 
    [Key]
    public int id { get; set; }

    public string userName { get; set; }
    public string userPassword { get; set; }
}
}
