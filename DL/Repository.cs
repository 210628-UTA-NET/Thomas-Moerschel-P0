using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DLEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace StoreApp
{
    
    public class Repository : IRepository
    {
         DLEntities.FirstDatabaseContext _context = new DLEntities.FirstDatabaseContext();
        public Repository(DLEntities.FirstDatabaseContext p_context)
        {
            _context = p_context;
        }
        
        
        
        //Called within the BL from _rep, a repository field variable, takes in customer object
        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(new DLEntities.Customer{
                CustomerName = p_customer.Name,
                CustomerAddress = p_customer.Address,
                CustomerEmail = p_customer.Email
            });
            _context.SaveChanges();
            return p_customer;
        }

        public LineItems AddInventory(LineItems p_lineItems, int quantity)
        {
            var data = _context.LineItems.Where(x=>x.LineItemId == p_lineItems.Id ||x.LineItemIdName ==p_lineItems.Product).FirstOrDefault();
            _context.LineItems.Remove(data); 
            DLEntities.LineItem lineItem = new DLEntities.LineItem()
            {
                LineItemId = data.LineItemId,
                LineItemIdName = data.LineItemIdName,
                LineItemQuantity = data.LineItemQuantity + quantity,
                StoreId = data.StoreId,
                OrderId = data.OrderId,
                ProductId = data.ProductId
            };
             _context.LineItems.Add(lineItem);
             _context.SaveChanges();
             return p_lineItems;                         
        }

        public Orders AddOrder(StoreFront p_storeFront, Customer p_customer, Orders p_order)
        {
            _context.Orders.Add(new DLEntities.Order{
                CustomerId = p_customer.Id,
                StoreId = p_storeFront.Id,
                OrderPrice = (decimal?)p_order.Price,
                OrderLocation = p_storeFront.Address,
            });
            _context.SaveChanges();
            return p_order;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                cust =>
                    new Customer()
                    {
                        Id = cust.CustomerId,
                        Name = cust.CustomerName,
                        Address = cust.CustomerAddress,
                        Email = cust.CustomerEmail
                    }
            ).ToList();
        }

        public List<StoreFront> GetAllStoreFronts()
        {
            return _context.StoreFronts.Select(
                store =>
                    new StoreFront()
                    {
                        Id = store.StoreId,
                        Name = store.StoreName,
                        Address = store.StoreAddress,
                    }
            ).ToList();
        }

        public Customer GetCustomer(Customer p_customer)
        {
            List<Customer> customers = _context.Customers.Select(
                cust=>
                    new Customer
                    {
                        Id = cust.CustomerId,
                        Name = cust.CustomerName,
                        Address = cust.CustomerAddress,
                        Email = cust.CustomerEmail
                    }).ToList();
            foreach(Customer cust in customers)
            {
                if (p_customer.Name == cust.Name) {return cust;}
                else if (p_customer.Address == cust.Address) {return cust;}
                else if (p_customer.Email == cust.Email) {return cust;}  
            }
            p_customer.Name = "Invalid Entry";
            return p_customer;

        }

        public List<LineItems> GetInventory(StoreFront p_storeFront)
        {

            List<LineItems> totalInventory = _context.LineItems.Select(
                inv=>
                    new LineItems
                    {
                        storeId = (int)inv.StoreId,
                        Id = inv.LineItemId,
                        Product = inv.LineItemIdName,
                        Quantity = (int)inv.LineItemQuantity,

                    }).ToList();
            List<LineItems> storeInventory = new List<LineItems>();
            foreach (LineItems inv in totalInventory )
            {
                if (inv.storeId == p_storeFront.Id){storeInventory.Add(inv);}
            }
            return storeInventory;
        }

        public List<Orders> GetOrders(StoreFront p_storeFront)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=>
                    new Orders
                    {
                        StoreId = (int)Ord.StoreId,
                        CustomerId = (int)Ord.CustomerId,
                        Price = (double)Ord.OrderPrice,
                    }).ToList();
            List<Orders> storeOrders = new List<Orders>();
            foreach (Orders order in allOrders)
            {
                if (order.StoreId == p_storeFront.Id){storeOrders.Add(order);}
            }
            return storeOrders;
        }

        public List<Orders> GetOrders(Customer p_customer)
        {
            List<Orders> allOrders = _context.Orders.Select(
                Ord=>
                    new Orders
                    {
                        StoreId = (int)Ord.StoreId,
                        CustomerId = (int)Ord.CustomerId,
                        Price = (double)Ord.OrderPrice,
                    }).ToList();
            List<Orders> customerOrders = new List<Orders>();
            foreach(Orders order in allOrders)
            {
                if (order.CustomerId == p_customer.Id){customerOrders.Add(order);}
            }
            return customerOrders;
        }

        public List<Products> GetProducts(StoreFront p_storeFront)
        {
            List<Products> totalProducts = _context.Products.Select(
                pro=>
                    new Products
                    {
                        StoreId = (int)pro.StoreId,
                        ProductId = pro.ProductId,
                        Name = pro.ProductName,
                        Price = (double)pro.ProductPrice,
                        Category = pro.ProductCategory
                    }).ToList();
            List<Products> storeProducts = new List<Products>();
            foreach (Products pro in totalProducts)
            {
                if (pro.StoreId ==p_storeFront.Id){storeProducts.Add(pro);}
            }
            return storeProducts;
        }
    }
}
