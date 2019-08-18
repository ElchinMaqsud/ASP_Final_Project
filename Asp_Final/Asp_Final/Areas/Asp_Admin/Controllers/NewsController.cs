using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Asp_Final.Db;
using Asp_Final.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Final.Areas.Asp_Admin.Controllers
{
    [Area("Asp_Admin")]
   
    public class NewsController : Controller
    {
      
        private readonly Final_Db _context;
        private readonly IHostingEnvironment _env;
        public NewsController(Final_Db context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult IndexNews()
        {
            return View(_context.News);
        }
        public async Task<IActionResult> NewsDetails(int? id)
        {
           
                if (id == null) return NotFound();

                News selectedNews = await _context.News.FindAsync(id);

                if (selectedNews == null) return NotFound();

                return View(selectedNews);
            }
        [HttpGet]
        [ActionName("CreateNews")]
        public IActionResult CreateNewsGet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateNews")]
        public async Task<IActionResult> CreatePost(News news)
        {
            if (!ModelState.IsValid)
            {
                return View(news);
            }

            if (news.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please upload photo");
                return View(news);
            }

            if (news.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + news.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await news.Photo.CopyToAsync(fileStream);
                }

                News news1 = new News()
                {
                     PhotoUrl= fileName,
                    Title = news.Title,
                    Info = news.Info
                };

                _context.News.Add(news1);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(IndexNews));
        }

        [HttpGet]
        [ActionName("Edit")]
        public IActionResult EditNewsGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News selectedNews = _context.News.Find(id);

            if (selectedNews == null)
            {
                return NotFound();
            }

            return View(selectedNews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditNewsPost(int? id, News news)
        {
            if (id == null)
            {
                return NotFound();
            }

            News newsFromDb = _context.News.Find(id);

            if (newsFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(news);
            }

            if (news.Photo == null)
            {
                ModelState.AddModelError("Photo", "Please, upload photo");
                return View(news);
            }

            string currentFilePath = Path.Combine(_env.WebRootPath, "img", newsFromDb.PhotoUrl);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }

            if (news.Photo.ContentType.Contains("image/"))
            {
                string folderPath = Path.Combine(_env.WebRootPath, "img");
                string fileName = Guid.NewGuid().ToString() + "_" + news.Photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                //string result = filePath.Replace(@"\", @"/");
                //await mainSlider.Photo.CopyToAsync(new FileStream(filePath, FileMode.Create));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await news.Photo.CopyToAsync(fileStream);
                }

                newsFromDb.PhotoUrl = fileName;
                newsFromDb.Title = news.Title;
                newsFromDb.Info = news.Info;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(IndexNews));
        }
        [HttpGet]
        [ActionName("NewsDelete")]
        public IActionResult NewsDeleteGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News newsFromDb = _context.News.Find(id);

            if (newsFromDb == null)
            {
                return NotFound();
            }

            return View(newsFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("NewsDelete")]
        public async Task<IActionResult> NewsDeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News selectedNewsFromDb = _context.News.Find(id);

            if (selectedNewsFromDb == null)
            {
                return NotFound();
            }

            string currentFilePath = Path.Combine(_env.WebRootPath, "img", selectedNewsFromDb.PhotoUrl);
            if (System.IO.File.Exists(currentFilePath))
            {
                System.IO.File.Delete(currentFilePath);
            }

            _context.News.Remove(selectedNewsFromDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(IndexNews));
        }


    }
}
