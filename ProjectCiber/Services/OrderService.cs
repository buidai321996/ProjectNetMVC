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

        public Task<List<Customer>> GetCustomerAsync()
        {
            return _orderResponsitory.GetCustomerAsync();
        }

        public Task<IEnumerable<OrderViewModel>> GetOrderAsync(string contrain, int? page, int? pageSize)
        {
            return _orderResponsitory.GetOrderAsync(contrain, page, pageSize);
        }

        public Task<List<Product>> GetProductAsync()
        {
            return _orderResponsitory.GetProductAsync();
        }

        public Task<int> SaveOrderAsync(Order order, int id)
        {
            return _orderResponsitory.SaveOrderAsync(order,  id);
        }
        public Task<Order> GetOrderByIdAsync(int id)
        {
            return _orderResponsitory.GetOrderByIdAsync(id);
        }
        public async Task<int> DeleteOrderAsync(Order order)
        {
            return await _orderResponsitory.DeleteOrderAsync(order);
        }
    }
    
}
