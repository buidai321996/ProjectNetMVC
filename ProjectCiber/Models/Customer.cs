﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models
{
    public class Customer
    {
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
