using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string OrderName { get; set; }
        public string CustomerName { get; set; }

        public string ProductName { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int CatagoryId { get; set; }
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }

        public string CatagoryName { get; set; }

        public int Amount { get; set; }

        public OrderViewModel()
        {
            this.OrderDate = DateTime.Now;
            this.Amount = 0;
        }


    }
}
