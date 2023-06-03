using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebASPPizzaTimeLessons.Models;
using WebASPPizzaTimeLessons.Services;

namespace WebASPPizzaTime.Pages.Commodityes
{
    public class CommodityesModel : PageModel
    {
        private readonly ICommodityRepository _db;
        public CommodityesModel(ICommodityRepository db)
        {
            _db = db;
        }

        public IEnumerable<Commodity> Commodityes { get; set; }

        public void OnGet()
        {
            Commodityes = _db.GetAllCommodity();
        }
    }
}
