﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Customer
    {
        private string _firstName;

        public Customer()
        {
            Orders = new List<Order>();
        }
        [Key]
        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
          
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public List<Order> Orders { get; set; }
    }
}
