using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Final.Areas.Asp_Admin.Controllers
{
    [Area("Asp_Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Indexi()
        {
            return View();
        }
    }
}