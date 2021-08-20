using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public string OrderName { get; set; }

        public int Amount { get; set; }
   

        public DateTime OrderDate { get; set; }


        public Customer Customer { get; set; }

        public Product Product { get; set; }

        public Order()
        {
            this.OrderDate = DateTime.Now;
        }


    }
}
