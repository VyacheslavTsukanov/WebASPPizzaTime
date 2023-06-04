using System.Collections.Generic;
using WebASPPizzaTimeLessons.Models;

namespace WebASPPizzaTimeLessons.Services
{
    public interface ICommodityRepository
    {
        //IEnumerable<Commodity> Search(string searchTerm);

        IEnumerable<Commodity> GetAllCommodity();
        Commodity GetCommodity(int id);
        Commodity Update(Commodity updateCommodity);
        Commodity Add(Commodity newCommodity);
        //Commodity Delete(int id);
        //IEnumerable<DeptHeadCount> CommodityCountByDept(Dept? dept);
    }
}
