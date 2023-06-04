using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using WebASPPizzaTimeLessons.Models;
using WebASPPizzaTimeLessons.Services;

namespace WebASPPizzaTime.Pages.Commodityes
{
    public class EditModel : PageModel
    {
        private readonly ICommodityRepository _commodityRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(ICommodityRepository commodityRepository, IWebHostEnvironment webHostEnvironment)
        {
            _commodityRepository = commodityRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public Commodity Commodity { get; set; }


        [BindProperty]
        public IFormFile Photo { get; set; }


        [BindProperty]
        public bool Notify { get; set; }
        public string Massage { get; set; }


        public IActionResult OnGet(int id)
        {
            Commodity = _commodityRepository.GetCommodity(id);

            if (Commodity == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost(Commodity commodity)
        {
            if(Photo != null)
            {
                if(commodity.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", commodity.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                commodity.PhotoPath = ProcessUploadedFile();
            }

            Commodity = _commodityRepository.Update(commodity);

            TempData["SeccessMessage"] = $"Update {Commodity.Name} successful";

            return RedirectToPage("Commodityes");
        }

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Massage = "Thank you for turning on the notification";
            }
            else
            {
                Massage = "Your have turned off email notifications";
            }

            Commodity = _commodityRepository.GetCommodity(id);
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                };
            }
            return uniqueFileName;
        }
    }
}
