using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebASPPizzaTimeLessons.Models;
using WebASPPizzaTimeLessons.Services;

namespace WebASPPizzaTime.Pages.Commodityes
{
    public class EditModel : PageModel
    {
        private readonly ICommodityRepository _commodityRepository;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
           // _webHostEnvironment = webHostEnvironment;
        }

        public Commodity Commodity { get; set; }

        public IActionResult OnGet(int id)
        {
            Commodity = _commodityRepository.GetCommodity(id);

            if (Commodity == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
