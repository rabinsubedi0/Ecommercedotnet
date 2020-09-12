﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSucess.Models
{
    public class Admin_Login
    {
        [Key]
        public int id { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        [NotMapped]
        public bool Admin { get; set; }
    }
}
