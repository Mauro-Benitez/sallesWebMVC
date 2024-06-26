﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models
{
    public class Department
    {

        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Vendedor")]
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();


        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }



        public void AddSeller (Seller seller)
        { 
            Sellers.Add(seller); 
            
        }


        public double TotalSales (DateTime initial, DateTime final)
        {

            return Sellers.Sum(s => s.TotalSales(initial, final));
        }

    }
}
