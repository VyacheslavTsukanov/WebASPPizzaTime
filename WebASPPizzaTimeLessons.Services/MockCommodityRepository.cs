﻿using System.Collections.Generic;
using WebASPPizzaTimeLessons.Models;

namespace WebASPPizzaTimeLessons.Services
{
    public class MockCommodityRepository : ICommodityRepository
    {
        private List<Commodity> _commodityList;

        public MockCommodityRepository()
        {
            _commodityList = new List<Commodity>
            {
                new Commodity()
                {
                    Id = 0, Name = "Гавайская", Email = "mark@example.com", PhotoPath = "avatar2.png", Department = Dept.PizzaMafia
                },
                new Commodity()
                {
                    Id = 1, Name = "Маргарита", Email = "slava@example.com", PhotoPath = "avatar3.png", Department = Dept.HelloPizza
                },
                new Commodity()
                {
                    Id = 2, Name = "Гавайская", Email = "stiven@example.com", PhotoPath = "avatar3.png", Department = Dept.HelloPizza
                },
                 new Commodity()
                {
                    Id = 3, Name = "Сицилийская", Email = "shawn@example.com", PhotoPath = "avatar2.png", Department = Dept.YesPizza
                },
                new Commodity()
                {
                    Id = 4, Name = "Гавайская", Email = "jenifer@example.com", PhotoPath = "avatar4.png", Department = Dept.PizzaMafia
                },
                 new Commodity()
                {
                    Id = 5, Name = "Гавайская", Email = "sten@example.com", Department = Dept.HelloPizza
                }     
            };
        }

        public IEnumerable<Commodity> GetAllCommodity()
        {
            return _commodityList;
        }
    }
}
