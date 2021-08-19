using ProjectCiber.Models;
using ProjectCiber.Models.ViewModels;
using ProjectCiber.Responsitorys;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderResponsitory _orderResponsitory;
        public OrderService(IOrderResponsitory orderResponsitory)
        {
            this._orderResponsitory = orderResponsitory;
        }

        public Task<List<OrderViewModel>> GetOrderAsync(string contrain)
        {
            return _orderResponsitory.GetOrderAsync(contrain);
        }
    }
}
