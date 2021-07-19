using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreAppModels;

namespace StoreAppDL
{
    public class Repository : IRepository
    {
        private StoreAppDBContext _context;
        public Repository(StoreAppDBContext p_context)
        {
            _context = p_context;
        }
        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(p_customer);
            _context.SaveChanges();
            return p_customer;
        }

        public LineItems AddInventory(LineItems p_lineItems, int quantity)
        {
            var lineItem = _context.LineItems.Select(item => item).ToList();
            foreach (LineItems item in lineItem)
            {
                if (item == p_lineItems)
                {
                    p_lineItems.Quantity = quantity;
                    _context.LineItems.Remove(item);
                    _context.Add(p_lineItems);
                }
            }
             _context.SaveChanges();
             return p_lineItems;                         
        }

        public Orders AddOrder(StoreAppModels.StoreFront p_storeFront, StoreAppModels.Customer p_customer, Orders p_order)
        {
            //may need more specification
            _context.Orders.Add(p_order);
            _context.SaveChanges();
            return p_order;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(cust => cust).ToList();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(store => store).ToList();
        }

        public StoreAppModels.Customer GetCustomer(StoreAppModels.Customer p_customer)
        {
            List<StoreAppModels.Customer> customers = _context.Customers.Select(cust=> cust).ToList();
            foreach(StoreAppModels.Customer cust in customers)
            {
                if (p_customer.Name == cust.Name) {return cust;}
                else if (p_customer.Address == cust.Address) {return cust;}
                else if (p_customer.Email == cust.Email) {return cust;} 
                else if (p_customer.PhoneNumber == cust.PhoneNumber){return cust;} 
            }
            p_customer.Name = "Invalid Entry";
            return p_customer;

        }

        public List<LineItems> GetInventory(StoreAppModels.StoreFront p_storeFront)
        {
            List<LineItems> totalInventory = _context.LineItems.Select(
                inv=> inv).ToList();
            List<LineItems> storeInventory = new List<LineItems>();
            foreach (LineItems inv in totalInventory )
            {
                if (inv.storeId == p_storeFront.Id){storeInventory.Add(inv);}
            }
            return storeInventory;
        }

        public List<Orders> GetOrders(StoreAppModels.StoreFront p_storeFront)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=> Ord).ToList();
            List<Orders> storeOrders = new List<Orders>();
            foreach (Orders order in allOrders)
            {
                if (order.StoreId == p_storeFront.Id){storeOrders.Add(order);}
            }
            return storeOrders;
        }

        public List<Orders> GetOrders(StoreAppModels.Customer p_customer)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=> Ord).ToList();
            List<Orders> customerOrders = new List<Orders>();
            foreach(Orders order in allOrders)
            {
                if (order.CustomerId == p_customer.Id){customerOrders.Add(order);}
            }
            return customerOrders;
        }

        public List<Products> GetProducts(StoreAppModels.StoreFront p_storeFront)
        {
            List<Products> totalProducts = _context.Products.Select(
                pro=>pro).ToList();
            List<Products> storeProducts = new List<Products>();
            foreach (Products pro in totalProducts)
            {
                if (pro.StoreId ==p_storeFront.Id){storeProducts.Add(pro);}
            }
            return storeProducts;
        }
    }
}
