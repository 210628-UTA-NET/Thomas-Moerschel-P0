using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAWebUI.Models;
using StoreAppBL;
using StoreAppModels;

namespace SAWebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderBL _orderBL;
        private StoreFront storeFront;
        public OrderController(IOrderBL p_orderBL)
        {
            _orderBL = p_orderBL;
        }
        public OrderController(StoreFront p_storeFront)
        {
            storeFront = p_storeFront;
        }
        public IActionResult Index()
        {
            return View(
                _orderBL.GetOrders(storeFront)
                .Select(ord => new OrdersVM(ord))
                .ToList()
            );
        }
    }
}