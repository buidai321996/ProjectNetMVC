﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> IndexAsync(string search)
        {
            List<OrderViewModel> listOrder;
            ViewData["GetOrderdetail"] = search;
            if (!String.IsNullOrEmpty(search))
            {
                listOrder = await _orderService.GetOrderAsync(search);
            }
            else
            {
                listOrder = await _orderService.GetOrderAsync(null);
            }
           
            return View(listOrder);
        }
        public IActionResult CreateOrderModal()
        {
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}