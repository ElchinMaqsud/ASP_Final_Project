using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Asp_Final.Db;
using Asp_Final.Models;
using Asp_Final.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly Final_Db _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _env;
        public AccountController(Final_Db context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {


            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }

            ApplicationUser user = await _userManager.FindByNameAsync(loginvm.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "sdsdsd");
                return View(loginvm);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "sdsdsd");
                return View(loginvm);
            }


            return RedirectToAction("Index", "Home");
        }

        [ActionName("Register")]
        public IActionResult RegisterGet()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> RegisterPost(RegisterVM CreatingUser)
        {
            CreatingUser.RegisterDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please enter valid properties");
                return View(CreatingUser);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Firstname = CreatingUser.FirstName,
                Lastname = CreatingUser.LastName,
                RegisterDate = CreatingUser.RegisterDate,
                Email = CreatingUser.Email,
                UserName = CreatingUser.UserName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, CreatingUser.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Your password or username is not valid");
                return View(CreatingUser);
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Redirection()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("PostElan", "Account");
            }

            return RedirectToAction("Register", "Account");
        }
        public IActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        
         public async Task<IActionResult> UserProfile()
        {
            ApplicationUser user= await _userManager.FindByNameAsync(User.Identity.Name);

            return View(_context.Automobiles.Where(x => x.ApplicationUserId == user.Id));
        }

        [HttpGet]
        [ActionName("PostElan")]
        public IActionResult PostElanGet()
        {
            ViewBag.Cities = _context.Cities;
            ViewBag.Marks = _context.Marks;
            
            ViewBag.Fuels = _context.Fuels;
            ViewBag.Bans = _context.Bans;
            ViewBag.Colors = _context.Colors;
            ViewBag.SpeedBoxes = _context.SpeedBoxes;

            return View();
        }



        [ActionName("PostElan")]
        [HttpPost]
        public async Task<IActionResult> Advertisement(Automobile automobile)
        {

            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            automobile.ApplicationUserId = user.Id;

            ViewBag.Cities = _context.Cities;
            ViewBag.Marks = _context.Marks;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.Bans = _context.Bans;
            ViewBag.Colors = _context.Colors;
            ViewBag.SpeedBoxes = _context.SpeedBoxes;

            if (!ModelState.IsValid)
            {
                ViewBag.Cities = _context.Cities;
                ViewBag.Marks = _context.Marks;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.Bans = _context.Bans;
                ViewBag.Colors = _context.Colors;
                ModelState.AddModelError("", "Please input valid properties");
                return View(automobile);
            }

            if (automobile.Photo == null)
            {
                ViewBag.Cities = _context.Cities;
                ViewBag.Marks = _context.Marks;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.Bans = _context.Bans;
                ViewBag.Colors = _context.Colors;
                ModelState.AddModelError("Image", "Please input Image");
                return View(automobile);
            }

            foreach (var item in automobile.AllCarImages)
            {
                if (item == null)
                {
                    ViewBag.Cities = _context.Cities;
                    ViewBag.Marks = _context.Marks;
                    ViewBag.Fuels = _context.Fuels;
                    ViewBag.Bans = _context.Bans;
                    ViewBag.Colors = _context.Colors;
                    ModelState.AddModelError("Image", "Please input Image");
                    return View(automobile);
                }
            }

            Automobile ad = new Automobile()
            {
                Name = automobile.Name,
                Price = automobile.Price,
                GraduationYear = automobile.GraduationYear,
                EnginePower = automobile.EnginePower,
                EngineVolume = automobile.EngineVolume,
                ColorId = automobile.ColorId,
                FuelId = automobile.FuelId,
                ModelId = automobile.ModelId,
                BanId = automobile.BanId,
                SpeedBoxId = automobile.SpeedBoxId,
                ApplicationUserId = automobile.ApplicationUserId,
                IsNew = automobile.IsNew,
                Mileage = automobile.Mileage,
                CityId = automobile.CityId
            };

            if (automobile.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + automobile.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                ad.PhotoUrl = fileName;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await automobile.Photo.CopyToAsync(fileStream);
                }
            }

            await _context.Automobiles.AddAsync(ad);

            foreach (var p in automobile.AllCarImages)
            {
                if (p.ContentType.Contains("image/"))
                {
                    string folderPathAll = Path.Combine(_env.WebRootPath, "img");
                    string fileNameAll = Guid.NewGuid().ToString() + "_" + p.FileName;
                    string filePathALL = Path.Combine(folderPathAll, fileNameAll);

                    using (FileStream fileStreama = new FileStream(filePathALL, FileMode.Create))
                    {
                        await p.CopyToAsync(fileStreama);
                    }
                    CarImages img = new CarImages()
                    {
                        AutomobileId = ad.Id,
                        CarPhotoUrl = fileNameAll
                    };
                    _context.CarImages.Add(img);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DeleteAdvertisement(int? id)
        {
            if (id == null) return NotFound();
             CarDetailsVM model = new CarDetailsVM()
            {
                automobile=_context.Automobiles.Find(id),
                carImages=_context.CarImages
            };

            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost,ActionName("DeleteAdvertisement"),ValidateAntiForgeryToken]
        public async  Task<IActionResult> DeleteAdvertisementPost(int? id)
        {
            if (id == null) return NotFound();

            Automobile avto = _context.Automobiles.Find(id);
 
            if (avto == null) return NotFound();


            string currentFilePath = Path.Combine(_env.WebRootPath, "img", avto.PhotoUrl);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }
            _context.Automobiles.Remove(avto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }

        [HttpGet,ActionName("UpdateAdvertisement")]
        public IActionResult UpdateAdvertisementGet(int? id)
        {
            if (id == null) return NotFound();

            ViewBag.Cities = _context.Cities;
            ViewBag.Marks = _context.Marks;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.Bans = _context.Bans;
            ViewBag.Colors = _context.Colors;
            ViewBag.SpeedBoxes = _context.SpeedBoxes;

            CarDetailsVM model = new CarDetailsVM()
            {
                automobile = _context.Automobiles.Find(id),
                carImages = _context.CarImages.Where(x => x.AutomobileId == id)
            };

            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("UpdateAdvertisement")]
        public async Task<IActionResult> UpdateAdvertisementPost(Automobile automobile , int? id)
        {
            #region ViewBags
            ViewBag.Cities = _context.Cities;
            ViewBag.Marks = _context.Marks;
            ViewBag.Fuels = _context.Fuels;
            ViewBag.Bans = _context.Bans;
            ViewBag.Colors = _context.Colors;
            ViewBag.SpeedBoxes = _context.SpeedBoxes;
            #endregion

            CarDetailsVM model = new CarDetailsVM()
            {
                automobile = _context.Automobiles.Find(id),
                carImages = _context.CarImages.Where(x => x.AutomobileId == id)
            };

            if (!ModelState.IsValid)
            {
                #region ViewBags
                ViewBag.Cities = _context.Cities;
                ViewBag.Marks = _context.Marks;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.Bans = _context.Bans;
                ViewBag.Colors = _context.Colors;
                ViewBag.SpeedBoxes = _context.SpeedBoxes;
                #endregion

                ModelState.AddModelError("", "Xahiw olunur duzgun deyerler daxil edesiniz");
                return View(model);
            }

            Automobile automobileFromDb = _context.Automobiles.Find(id);
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            automobile.ApplicationUserId = user.Id;

            if (user == null || automobileFromDb.ApplicationUserId != user.Id)
            {
                #region ViewBags
                ViewBag.Cities = _context.Cities;
                ViewBag.Marks = _context.Marks;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.Bans = _context.Bans;
                ViewBag.Colors = _context.Colors;
                ViewBag.SpeedBoxes = _context.SpeedBoxes;
                #endregion

                ModelState.AddModelError("", "Siz active istifadeci deyilsiniz");
                return View(model);
            }

            if (id == null) return NotFound();

            if (automobileFromDb == null) return NotFound();

            if (automobile.Photo == null)
            {
                #region ViewBags
                ViewBag.Cities = _context.Cities;
                ViewBag.Marks = _context.Marks;
                ViewBag.Fuels = _context.Fuels;
                ViewBag.Bans = _context.Bans;
                ViewBag.Colors = _context.Colors;
                ViewBag.SpeedBoxes = _context.SpeedBoxes;
                #endregion
                ModelState.AddModelError("Image", "Please input Image");
                return View(automobile);
            }

            foreach (var item in automobile.AllCarImages)
            {
                if (item == null)
                {
                    #region ViewBags
                    ViewBag.Cities = _context.Cities;
                    ViewBag.Marks = _context.Marks;
                    ViewBag.Fuels = _context.Fuels;
                    ViewBag.Bans = _context.Bans;
                    ViewBag.Colors = _context.Colors;
                    ViewBag.SpeedBoxes = _context.SpeedBoxes;
                    #endregion
                    ModelState.AddModelError("Image", "Please input Image");
                    return View(automobile);
                }
            }

            if (automobile.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + automobile.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                automobileFromDb.PhotoUrl = fileName;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await automobile.Photo.CopyToAsync(fileStream);
                }

                string currentFilePath = Path.Combine(_env.WebRootPath, "image", automobileFromDb.PhotoUrl);
                if (System.IO.File.Exists(currentFilePath))
                {
                    System.IO.File.Delete(currentFilePath);
                }
            }

            foreach (var p in automobile.AllCarImages)
            {
                if (p.ContentType.Contains("image/"))
                {
                    string folderPathAll = Path.Combine(_env.WebRootPath, "img");
                    string fileNameAll = Guid.NewGuid().ToString() + "_" + p.FileName;
                    string filePathALL = Path.Combine(folderPathAll, fileNameAll);

                    using (FileStream fileStreama = new FileStream(filePathALL, FileMode.Create))
                    {
                        await p.CopyToAsync(fileStreama);
                    }

                    CarImages img = new CarImages()
                    {
                        AutomobileId = automobileFromDb.Id,
                        CarPhotoUrl = fileNameAll
                    };
                    _context.CarImages.Add(img);
                }
            }

            automobileFromDb.ApplicationUserId = user.Id;
            automobileFromDb.Name = automobile.Name;
            automobileFromDb.Price = automobile.Price;
            automobileFromDb.GraduationYear = automobile.GraduationYear;
            automobileFromDb.EnginePower = automobile.EnginePower;
            automobileFromDb.EngineVolume = automobile.EngineVolume;
            automobileFromDb.Mileage = automobile.Mileage;
            automobileFromDb.BanId = automobile.BanId;
            automobileFromDb.CityId = automobile.CityId;
            automobileFromDb.ColorId = automobile.ColorId;
            automobileFromDb.FuelId = automobile.FuelId;
            automobileFromDb.ModelId = automobile.ModelId;
            automobileFromDb.SpeedBoxId = automobile.SpeedBoxId;
            _context.SaveChanges();
            return RedirectToAction("UserProfile","Account");
        }



    }
}

 