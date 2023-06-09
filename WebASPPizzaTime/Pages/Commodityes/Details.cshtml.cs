using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebASPPizzaTimeLessons.Models;
using WebASPPizzaTimeLessons.Services;

namespace WebASPPizzaTime.Pages.Commodityes
{
    public class DetailsModel : PageModel
    {
        private readonly ICommodityRepository _commodityRepository;
        // private readonly IWebHostEnvironment _webHostEnvironment;


        public DetailsModel(ICommodityRepository commodityRepository) // IWebHostEnvironment webHostEnvironment
        {
            _commodityRepository = commodityRepository;
           // _webHostEnvironment = webHostEnvironment;
        }

        public Commodity Commodity { get; private set; }

        public IActionResult OnGet(int id)
        {
            Commodity = _commodityRepository.GetCommodity(id);

            if (Commodity == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
