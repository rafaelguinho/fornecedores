using System;
using System.Collections.Generic;
using System.Diagnostics;
using mvc.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using mvc.Models.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
