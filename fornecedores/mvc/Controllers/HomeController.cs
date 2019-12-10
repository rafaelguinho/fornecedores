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
        private readonly FornecedoresContext _context;

        public HomeController(FornecedoresContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
             var fs = _context.Empresas.Include(s => s.FornecedoresPessoaFisica).ToList();

            return View(fs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
