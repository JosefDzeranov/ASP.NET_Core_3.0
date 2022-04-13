﻿using System;
using System.Collections.Generic;
using OnlineDesignBureauWebApp.Models;


namespace OnlineShopWebApp.Models
{
    public class Person
    {
        public int Id { get; }
        public string FistName { get;}
        public string Surname { get;}
        public int Age { get;}
        public string Email { get;}
        public List<Product> ComparisonList { get; set; }
        public List<Product> BasketList { get; set; }
        public List<Product> OrdersList { get; set; }

        private string password;
        public Person(int id, string fistName, string surname, int age, string email, string password_input)
        {
            Id = id;
            FistName = fistName;
            Surname = surname;
            Age = age;
            Email = email;
            password = password_input;
            ComparisonList = new List<Product>();
            BasketList = new List<Product>();
            OrdersList = new List<Product>();
        }

        public override string ToString()
        {
            return $"Id: {Id};\nИмя: {FistName};\nФамилия: {Surname};\nВозраст: {Age};\nEmail: {Email};";
        }

    }
}
