using ProjectCiber.Models;
using ProjectCiber.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Services
{
    public interface IOrderService
    {
        public Task<List<OrderViewModel>> GetOrderAsync(string contrain);
    }
}
