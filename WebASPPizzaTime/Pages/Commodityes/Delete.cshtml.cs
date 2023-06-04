using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebASPPizzaTimeLessons.Models;
using WebASPPizzaTimeLessons.Services;

namespace WebASPPizzaTime.Pages.Commodityes
{
    public class DeleteModel : PageModel
    {
        private readonly ICommodityRepository _commodityRepository;

        public DeleteModel(ICommodityRepository commodityRepository)
        {
            _commodityRepository = commodityRepository;
        }

        [BindProperty]
        public Commodity Commodity { get; set; }
        public IActionResult OnGet(int id)
        {
            Commodity = _commodityRepository.GetCommodity(id);

            if (Commodity == null)
                return RedirectToPage("/NotFaund");

            return Page();
        }

        public IActionResult OnPost()
        {
            Commodity deletedCommodity = _commodityRepository.Delete(Commodity.Id);

            if (deletedCommodity == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Commodityes");
        }
    }
}
