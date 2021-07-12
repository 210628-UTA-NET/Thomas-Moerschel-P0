using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp
{
    public class MakeAnOrder : IMenu
    {
        private IInventory _InventoryBL;
        private IProductsBL _ProductsBL;
        public MakeAnOrder(){}
        public MakeAnOrder(IInventory p_InventoryBL, IProductsBL p_IProductsBL)
        {
            _InventoryBL = p_InventoryBL;
            _ProductsBL = p_IProductsBL;
        }
        public static Customer shoppingCustomer = new Customer();
        public static StoreFront shoppingStoreFront = new StoreFront();
        public static List<LineItems> cart = new List<LineItems>();
        public void storeLocation(StoreFront p_storeFront)
        {
            shoppingStoreFront = p_storeFront;
        }
        public void customerInformation(Customer p_customer)
        {
            shoppingCustomer = p_customer;
        }
        
        public void Menu()
        {
            Console.WriteLine("Welcome " + shoppingCustomer.Name + " to " + shoppingStoreFront.Name);
            Console.WriteLine(shoppingStoreFront.Name + " Summer Catalog:");
            Console.WriteLine("-------------------");
            List<LineItems> lineItems = _InventoryBL.GetInventory(shoppingStoreFront);
            List<Products> products = _ProductsBL.GetProducts(shoppingStoreFront);
            foreach(Products prod in products)
            {
                 if (prod.StoreId == shoppingStoreFront.Id)
                {
                    Console.WriteLine(prod);
                    foreach(LineItems item in lineItems)
                    {
                        if (item.Product == prod.Name)
                        {
                            Console.WriteLine ("Quantity: " + item.Quantity);
                            Console.WriteLine("-------------------");
                        }
                    }
                }
            }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(shoppingStoreFront);
            List<Products> products = _ProductsBL.GetProducts(shoppingStoreFront);
            Console.WriteLine("Which Item would you like to purchase?\n(Choose by Product ID or Product Name)");
            double price = 0.00;
            string userInput = Console.ReadLine();
            string invQuantity;
            foreach(LineItems item in lineItems)
            {
                if (userInput == item.Id.ToString() || item.Product.ToLower() == userInput.ToLower())
                {
                    Console.WriteLine("How many would you like to add to your cart?");
                    string quantity = Console.ReadLine();
                    invQuantity = "-" + quantity;
                    item.Quantity = Int16.Parse(quantity);
                    _InventoryBL.AddInventory(item, Int16.Parse(invQuantity));
                    if (cart.Count > 0)
                    {
                        foreach (LineItems product in cart.ToList())
                        {
                            if (product.Id.ToString() == userInput || product.Product.ToLower() == userInput.ToLower())
                            {
                                product.Quantity += Int16.Parse(quantity);
                            }
                            else
                            {
                                cart.Add(item);
                            }
                        }
                    }
                    else
                    {
                        cart.Add(item);   
                    }
                }
                
            }
            Console.Clear();
            Console.WriteLine("Would you like to make another purchase?");
            Console.WriteLine("[2] Make another Purchase\n[1] Continue to Checkout\n[0] Cancel Order");
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    foreach (LineItems item in cart)
                    {
                        _InventoryBL.AddInventory(item, item.Quantity);
                    }
                    cart.Clear();
                    return MenuType.MainMenu;
                case "1":
                    CustomerCheckout checkout = new CustomerCheckout();
                    foreach (LineItems item in cart)
                    {
                        foreach (Products product in products)
                        {
                            if (item.Id == product.ProductId)
                            {
                                price += (product.Price * item.Quantity);
                            }
                        }
                    }
                    checkout.checkoutInformation(shoppingStoreFront, shoppingCustomer, cart, price);
                    return MenuType.CustomerCheckout;
                case "2":
                    return MenuType.MakeAnOrder;

            }



           
            return MenuType.MakeAnOrder;
        }
    }
}