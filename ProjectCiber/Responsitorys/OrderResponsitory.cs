using Microsoft.EntityFrameworkCore;
using ProjectCiber.Models;
using ProjectCiber.Models.Contexts;
using ProjectCiber.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCiber.Responsitorys
{
    public class OrderResponsitory: IOrderResponsitory
    {
        public readonly OrderContext _orderContext;

        public OrderResponsitory(OrderContext orderContext)
        {
            this._orderContext = orderContext;
        }

        public Task<List<OrderViewModel>> GetOrderAsync(string contrain)
        {
            var resultDinamic = _orderContext.Orders
                .Join(
                _orderContext.Products,
                order => order.ProductId,
                product => product.Id,
                 (order, product) => new { Order = order, Product = product }
                ).Join(
                 _orderContext.Contacts,
                 cs => cs.Order.CustomerId,
                 contact => contact.Id,
                 (cs, contact) => new { Product = cs.Product, Contact = contact, Order = cs.Order }
                ).Join(
                 _orderContext.Catagorys,
                 product => product.Product.Id,
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
            if (contrain != null)
            {
                return resultDinamic.Where(order => order.CustomerName.Equals(contrain)).ToListAsync();
            }
            else
            {
                return resultDinamic.ToListAsync();
            }
        }
    }
}
