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
        public Task<IEnumerable<OrderViewModel>> GetOrderAsync(string contrain, int? page, int? pageSize, string stringSort);
        public Task<List<Customer>> GetCustomerAsync();
        public Task<List<Product>> GetProductAsync();

        public Task<int> SaveOrderAsync(Order order, int id);

        public Task<Order> GetOrderByIdAsync(int id);
        public Task<int> DeleteOrderAsync(Order order);
    }
}
