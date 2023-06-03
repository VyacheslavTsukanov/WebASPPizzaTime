using System.Collections.Generic;
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
                    Id = 0, Name = "Mark", Email = "mark@example.com", PhotoPath = "avatar2.png", Department = Dept.PizzaMafia
                },
                new Commodity()
                {
                    Id = 1, Name = "Slava", Email = "slava@example.com", PhotoPath = "avatar2.png", Department = Dept.HelloPizza
                },
                new Commodity()
                {
                    Id = 2, Name = "Stiven", Email = "stiven@example.com", PhotoPath = "avatar2.png", Department = Dept.HelloPizza
                },
                 new Commodity()
                {
                    Id = 3, Name = "Shawn", Email = "shawn@example.com", PhotoPath = "avatar2.png", Department = Dept.YesPizza
                },
                new Commodity()
                {
                    Id = 4, Name = "Jenifer", Email = "jenifer@example.com", PhotoPath = "avatar3.png", Department = Dept.PizzaMafia
                },
                 new Commodity()
                {
                    Id = 5, Name = "Sten", Email = "sten@example.com", Department = Dept.HelloPizza
                }     
            };
        }

        public IEnumerable<Commodity> GetAllCommodity()
        {
            return _commodityList;
        }

        //public IEnumerable<Commodity> GetAllCommodityes()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
