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
        public CustomerController(ICustomerBL p_custBL)
        {
            _custBL = p_custBL;
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
