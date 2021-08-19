using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Models.ViewModels
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }

        public string ProductName { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string CatagoryName { get; set; }

        public int Amount { get; set; }


    }
}
