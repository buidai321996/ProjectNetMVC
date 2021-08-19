using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desceription { get; set; }
        public int Quantity { get; set; }
        // Foreign key for Catagory
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }

        public ICollection<Order> Orders { get; set; }



    }
}
