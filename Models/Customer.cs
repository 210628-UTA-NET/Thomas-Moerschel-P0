﻿using System;
using System.Collections.Generic;

namespace StoreAppModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Address {get; set; } 
        public string Email {get; set; }
        public string PhoneNumber { get; set; }
        public string Password {get; set; }
        public List <Orders> Orders { get; set; }

        
        //overrides default string function allowing you to output object parameters:: otherwise you receive "namespace.class"

        public override string ToString()
        {
            return $"Customer ID: {Id}\nName: {Name}\nPhone Number: {PhoneNumber}\nAddress: {Address}\nEmail: {Email}";
        }

    }
  
}
