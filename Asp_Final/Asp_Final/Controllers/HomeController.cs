using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp_Final.Models;
using Asp_Final.Db;
using Microsoft.AspNetCore.Identity;
using Asp_Final.ViewModels;

namespace Asp_Final.Controllers
{

    public class HomeController : Controller
    {

        private readonly Final_Db _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(Final_Db context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public  IActionResult Index()
        {
          
            
            return View(_context.Automobiles);
        }

        public IActionResult News()
        {
            return View(_context.News);
        }
        public async Task<IActionResult> CarDetails(int? id)
        {
            CarDetailsVM carDetails = new CarDetailsVM()
            {
                automobile =  await _context.Automobiles.FindAsync(id),
                 carImages = _context.CarImages
            };
            return View(carDetails);
        }
        public async Task<IActionResult> AdvertisementDetails(int? id)
        {
            Automobile selectedAuto = await _context.Automobiles.FindAsync(id);

            if (selectedAuto == null)
            {
                return NotFound();
            }
            CarDetailsVM carDetails = new CarDetailsVM()
            {
                automobile = selectedAuto,
                carImages = _context.CarImages
            };
            return View(carDetails);
        }






    }
}
