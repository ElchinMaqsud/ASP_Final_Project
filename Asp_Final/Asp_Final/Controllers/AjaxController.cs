using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp_Final.Db;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Final.Controllers
{
    public class AjaxController : Controller
    {
        private readonly Final_Db _context;

        public AjaxController(Final_Db context)
        {
            _context = context;
        }

        public IActionResult Index(int? id) 
        {
            return PartialView("Index",_context.Models.Where(x=>x.MarkId == id));
        }

        public async  void DeleteSingleImage(int? ImageId)
        {
            var deleting = _context.CarImages.Find(ImageId);
           _context.CarImages.Remove(deleting);
            await _context.SaveChangesAsync();
        }
    }
}