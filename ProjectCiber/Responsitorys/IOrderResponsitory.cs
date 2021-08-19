using ProjectCiber.Models;
using ProjectCiber.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Responsitorys
{
    public interface IOrderResponsitory
    {
        public  Task<List<OrderViewModel>> GetOrderAsync(string contrain);
    }
}
