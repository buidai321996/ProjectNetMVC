using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCiber.Models;
using ProjectCiber.Models.ViewModels;
using ProjectCiber.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using static ProjectCiber.Helper.Helpers;

namespace ProjectCiber.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            this._orderService = orderService;
        }
        [HttpGet, ActionName("Index")]
        public async Task<IActionResult> IndexAsync(string search, int ? page = 1, int  pageSize = 5)
        {

            return View(await GetListOrder(search, page, pageSize));
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var product = await _orderService.GetProductAsync();
            ViewData["listDataProducts"] = product;
            var customers = await _orderService.GetCustomerAsync();
            ViewData["listDataCustomers"] = customers;
            if (id == 0)
            {
                return View(new Order());
            }
            else
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.SaveOrderAsync(order, id);
                return Json(new { isValid = true, html = Helper.Helpers.RenderViewToString(this, "ViewAll", await GetListOrder(null, 1,5))});
            }
            else
            {
                //return Json(new { isValid = true, html = Helper.Helpers.RenderViewToString(this, "ViewAll", _orderService.GetOrderAsync(null)) });
                return Json(new { isValid = false, html = Helper.Helpers.RenderViewToString(this, "AddOrEdit", order) });
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (ModelState.IsValid)
            {
                await _orderService.DeleteOrderAsync(order);
                return Json(new { isValid = true, html = Helper.Helpers.RenderViewToString(this, "ViewAll", await GetListOrder(null, 1,5)) });
            }
            return Json(new { isValid = true, html = Helper.Helpers.RenderViewToString(this, "ViewAll", await GetListOrder(null, 1,5)) });
        }


        public async Task<IEnumerable<OrderViewModel>> GetListOrder(string search, int ? page, int ? pageSize)
        {
            IEnumerable<OrderViewModel> listOrder;
            ViewData["GetOrderdetail"] = search;
            if (!String.IsNullOrEmpty(search))
            {
                listOrder = await _orderService.GetOrderAsync(search, page, pageSize);
                listOrder.ToList()[0].Page = (int)page;
            }
            else
            {
                listOrder = await _orderService.GetOrderAsync(null, page, pageSize);
                listOrder.ToList()[0].Page = (int)page;
            }
            ViewData["CountList"] = listOrder.ToList()[0].CountList;
            ViewData["PageSize"] = pageSize;
            return listOrder;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
