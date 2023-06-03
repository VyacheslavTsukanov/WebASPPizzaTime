using System.Collections.Generic;
using WebASPPizzaTimeLessons.Models;

namespace WebASPPizzaTimeLessons.Services
{
    public interface ICommodityRepository
    {
        //IEnumerable<Commodity> Search(string searchTerm);

        IEnumerable<Commodity> GetAllCommodity();
        Commodity GetCommodity(int id);
        //Commodity Update(Commodity updateEmployee);
        //Commodity Add(Commodity newEmployee);
        //Commodity Delete(int id);
        //IEnumerable<DeptHeadCount> CommodityCountByDept(Dept? dept);
    }
}
