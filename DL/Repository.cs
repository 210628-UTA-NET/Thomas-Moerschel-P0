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
             _context.LineItems.Remove(data);
             _context.LineItems.Add(lineItem);
             _context.SaveChanges();
             return p_lineItems;                         
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
    }
}
