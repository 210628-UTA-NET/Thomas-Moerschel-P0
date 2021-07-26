//   To Do:
// [IMPORTANT]
//1. Manager Portal (mimic customer login -- nest in bottom corner)
//2. Customer Management 
//   2a. Search Customer (search bar at top- bootstrap)
//   2b. View Customer History (button that views order history)
//3. Storefront Management
//   3a. View Inventory Items
//   3b. Add Inventory Item (product conflicts)
//   3c. View StoreFronts (3c and 3d should be done first)
//   3d. Add StoreFront
//   3e. View Store Order History (Same as Customer)
//4. Logging 
//5. Unit Testing (May take a while, follow Stephen's tutorial from Friday) --20 of them-- DB methods tested Data shoudl persist
//6. Exception Handling 
//7. Input Validation
//8. DEPLOY THE WEBSITE (STEPHEN WENT OVER THIS FRIDAY)
//9. DB structure should be 3NF
//10. XML Documentation

//MONDAY
// Manager Portal, Customer Management, StoreFront Management and Making an Order are done
//Deploy Website 
//CICD PIPELINE ESTABLISHED USING AZURE PIPELINES
// if you finish, get started on Unit Testing from stephens video
//TUESDAY
// FINISH UNIT TESTING
// FINISH LOGGING
// XML DOCUMENTATION
// DB STRUCTURE 3NF
// INPUT VALIDATION AND EXCEPTION HANDLING



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAWebUI.Models;
using StoreAppBL;
using StoreAppModels;

namespace SAWebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerBL _custBL;
        private IStoreFrontBL _storeBL;
        private IInventoryBL _invBL;
        private IProductsBL _proBL;
        private IOrderBL _ordBL;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICustomerBL p_custBL, IStoreFrontBL p_storeBL, IInventoryBL p_invBL, IProductsBL p_proBL, IOrderBL p_ordBL)
        {
            _logger = logger;
            _custBL = p_custBL;
            _storeBL = p_storeBL;
            _invBL = p_invBL;
            _proBL = p_proBL;
            _ordBL = p_ordBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MakeAnOrder(List<LineItemsVM> p_items, int customerID)
        {
                //get order from customerID and price, remove items
                //add price as a dependency in repo
                //get LineItems with the same orderID// set that up in repo
                //in html, display Order Price at bottom, list of items, and "confirm purchase button", then take that to a IActionResult OrderConfirmationScreen
                // if they cancel the order remove the order from the database (easy)
            return View();
        }
        public IActionResult Add()
        {
            Console.WriteLine("Success");
            return View();
        }
        public IActionResult StoreFrontMenu(int customerID)
        {
            TempData["custID"] = customerID;
            return View(
                _storeBL.GetAllStoreFronts()
                .Select(store => new StoreFrontVM(store))
                .ToList()
            );
        }
        public IActionResult StoreInventory(int p_id, int p_customerID)
        {
            ViewBag.custID = p_customerID;
            return View(
                _invBL.GetInventory(p_id)
                .Select(inv => new LineItemsVM(inv))
                .ToList()
            );
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
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerVM custVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var test = _custBL.GetCustomer(new Customer
                            {
                            Name = custVM.Name,
                            Address = custVM.Address,
                            PhoneNumber = custVM.PhoneNumber,
                            Email = custVM.Email,
                            Password = custVM.Password,
                            }
                        );
                    Console.WriteLine(test.Name);
                    if (test.Name == "Invalid Entry")
                    {
                        Console.WriteLine("Customer Not Found");
                        return RedirectToAction(nameof(Index));
                    }
                    else{return RedirectToAction("StoreFrontMenu", "Home", new {customerID = test.Id});}
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult StoreInventory(List<LineItemsVM> p_list, int p_customerID)
        {
            //add order here 
            List<Products> products  = _proBL.GetProducts(p_list[0].storeID);
            Orders order = new Orders();
            string _customerID = TempData["custID"].ToString();
            p_customerID = Int32.Parse(_customerID);
            Console.WriteLine("Inventory customer ID: " + p_customerID + "length of list " + p_list.Count);
            //works for 1 product, validate and subtract from inventory using addinventory(-quantiy ) 
            foreach (LineItemsVM item in p_list)
            {
                string Quantity = item.Quantity.ToString();
                Quantity = "-" + Quantity;
                _invBL.AddInventory(new LineItems
                {
                    Product = item.Product,
                    Id = item.Id,
                    storeId = item.storeID
                }, Int32.Parse(Quantity));
                //ADD PRODUCTID IN REPO TO GRAB -- LINK IT IN DB
                foreach (Products prod in products)
                {
                    if (prod.Id == item.ProductsId)
                    {
                        order.Price += (prod.Price * item.Quantity);
                        //make definition for store ID make sure it reflects in database
                        order.storeId= item.storeID;
                        order.CustomerId = p_customerID;
                    }
                }
                
            }
            //make sure order reflects in database 
            _ordBL.AddOrder(p_list[0].storeID, p_customerID, order);
            return RedirectToAction("MakeAnOrder", "Home", new {p_items = p_list, customerID = p_customerID});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
