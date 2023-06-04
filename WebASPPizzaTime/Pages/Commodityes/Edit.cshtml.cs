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

        [BindProperty]
        public Commodity Commodity { get; set; }


        [BindProperty]
        public IFormFile Photo { get; set; }


        [BindProperty]
        public bool Notify { get; set; }
        public string Massage { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                Commodity = _commodityRepository.GetCommodity(id.Value);
            else
                Commodity = new Commodity();

            if (Commodity == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Commodity.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Commodity.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Commodity.PhotoPath = ProcessUploadedFile();
                }


                if(Commodity.Id > 0)
                {
                    Commodity = _commodityRepository.Update(Commodity);
                    TempData["SeccessMessage"] = $"Update {Commodity.Name} successful";
                }
                else
                {
                    Commodity = _commodityRepository.Add(Commodity);
                    TempData["SeccessMessage"] = $"Adding {Commodity.Name} successful!";
                }

                return RedirectToPage("Commodityes");
            }
            else
            {
                return Page();
            }
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
