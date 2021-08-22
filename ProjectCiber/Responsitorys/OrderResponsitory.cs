using Microsoft.EntityFrameworkCore;
using ProjectCiber.Models;
using ProjectCiber.Models.Contexts;
using ProjectCiber.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;

namespace ProjectCiber.Responsitorys
{
    public class OrderResponsitory: IOrderResponsitory
    {
        public readonly OrderContext _orderContext;

        public OrderResponsitory(OrderContext orderContext)
        {
            this._orderContext = orderContext;
        }

        public Task<int> AddOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await _orderContext.Contacts.ToListAsync();
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrderAsync(string contrain, int ? page, int ? pageSize, string stringSort)
        {
            var resultDinamic = _orderContext.Orders
                .Join(
                _orderContext.Products,
                order => order.ProductId,
                product => product.Id,
                 (order, product) => new { Order = order, Product = product}
                ).Join(
                 _orderContext.Contacts,
                 cs => cs.Order.CustomerId,
                 contact => contact.Id,
                 (cs, contact) => new { Product = cs.Product, Contact = contact, Order = cs.Order }
                ).Join(
                 _orderContext.Catagorys,
                 product => product.Product.CatagoryId,
                 catagory => catagory.Id,
                  (product, catagory) => new
                  {
                      Product = product.Product,
                      Order = product.Order,
                      CatagoryName = catagory.Name,
                      CustomerName = product.Contact.Name
                  }
                    ).
                    Select(c => new OrderViewModel
                    {
                        ProductName = c.Product.Name,
                        OrderDate = c.Order.OrderDate,
                        Id = c.Order.Id,
                        Amount = c.Order.Amount,
                        CatagoryName = c.CatagoryName,
                        CustomerName = c.CustomerName
                    });
            if (stringSort.Equals("DESC"))
            {
                resultDinamic = resultDinamic.OrderByDescending(x => x.ProductName);
            }
            else
            {
                resultDinamic = resultDinamic.OrderBy(x => x.ProductName);
            }
            if (contrain != null)
            {
                var dataAll = resultDinamic.ToList().Count;
                var data = resultDinamic.Where(order => order.CustomerName.Equals(contrain.Trim())).ToPagedList(page ?? 1, (int)pageSize);
                if (data.Count != 0)
                {
                    data.ToList()[0].CountList = dataAll;
                }
                return data;
            }
            else
            {
                var dataAll = resultDinamic.ToList().Count;
                var data = resultDinamic.ToPagedList(page ?? 1, (int)pageSize);
                if(data.Count != 0) {
                    data.ToList()[0].CountList = dataAll;
                }
                return  data;
            }
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _orderContext.Products.ToListAsync();
        }

        public async Task<int> SaveOrderAsync(Order order, int id)
        {
            if (id == 0)
            {
                _orderContext.Add(order);
                return await _orderContext.SaveChangesAsync();
            }
            else
            {
                _orderContext.Update(order);
                return await _orderContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderContext.Orders.FindAsync(id);
        }

        public async Task<int> DeleteOrderAsync(Order order)
        {
             _orderContext.Orders.Remove(order);
            return await _orderContext.SaveChangesAsync();
        }

    }
}
