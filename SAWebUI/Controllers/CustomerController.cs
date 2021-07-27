using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAWebUI.Models;
using StoreAppBL;
using StoreAppModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAWebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;
        private IInventoryBL _invBL;
        private IOrderBL _ordBL;
        public CustomerController(ICustomerBL p_custBL, IStoreFrontBL p_storeBL, IInventoryBL p_invBL, IOrderBL p_ordBL)
        {
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _invBL = p_invBL;
            _ordBL = p_ordBL;
        }
        public IActionResult Index()
        {
            return View(
                _custBL.GetAllCustomers()
                .Select(cust => new CustomerVM(cust))
                .ToList()
            );
        }
        public IActionResult Add()
        {
            Console.WriteLine("success Cust Add");
            return View();
        }
        public IActionResult StoreFrontMenu()
        {
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store))
                .ToList());
        }
        public IActionResult StoreInventory(int p_storeID)
        {
            Console.WriteLine(p_storeID + " This is the store ID of inventory access");
            return View(
                _invBL.GetInventory(p_storeID)
                .Select(inv => new LineItemsVM(inv))
                .ToList()
            );
        }
        public IActionResult ViewCustomerOrderHistory(int p_customerID)
        {
            Customer customerOrders = new Customer();
            customerOrders.Id = p_customerID;
            return View(
                _ordBL.GetOrders(customerOrders)
                .Select(ord => new OrdersVM(ord))
                .ToList()
            );

        }
        public IActionResult ViewStoreOrderHistory(int p_storeID, string sortOrder)
        {
            ViewBag.storeID = p_storeID;
            var orders = _ordBL.GetOrders(p_storeID)
                        .Select (ord =>new OrdersVM(ord))
                        .ToList();
                Console.WriteLine("Retrieved sort order: " + sortOrder + "Store ID: " + p_storeID);
            switch (sortOrder)
                {
                    case "orders_Desc":
                        orders = orders.OrderByDescending(ord=>ord.Price)
                                .ToList();
                        break;
                    case "orders_Asc":
                        orders = orders.OrderBy(ord=>ord.Price)
                                .ToList();
                        break;
                    default:
                        break;
                }
                return View(orders);
        }
        [HttpPost]
        public IActionResult Index(string custName)
        {
            var match = _custBL.GetAllCustomers()
                        .Select(cust => new CustomerVM(cust))
                        .ToList();
            List<CustomerVM> searchCustomer = new List<CustomerVM>();
            foreach (CustomerVM cust in match)
            {
                if (custName == null){
                    searchCustomer = match;
                }
                else if (cust.Name.ToUpper().Contains(custName.ToUpper()))
                {
                    searchCustomer.Add(cust);
                }
                
            }
            return View(searchCustomer);
        }
        [HttpPost]
        public IActionResult StoreInventory(LineItemsVM item)
        {
               int storeID = item.storeID;
               _invBL.AddInventory(new LineItems
                {
                    ProductsId = item.ProductsId,
                    Product = item.Product,
                    Id = item.Id,
                    storeId = item.storeID,
                }, item.Quantity);
           
            return RedirectToAction("StoreInventory", "Customer", new{p_storeID = storeID});
        }
        [HttpPost]
        public IActionResult Add(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _custBL.AddCustomer(new Customer
                        {
                        Name = custVM.Name,
                        PhoneNumber = custVM.PhoneNumber,
                        Email = custVM.Email,
                        Address = custVM.Address,
                        Password = custVM.Password,
                        }
                    );
                    Console.WriteLine("Successful Add");
                    return RedirectToAction(nameof(Index)); //Go back to the index html of the customer controller
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }
    }
}
