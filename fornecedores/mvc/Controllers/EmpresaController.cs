using Microsoft.AspNetCore.Mvc;
using mvc.Context;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly FornecedoresContext _context;

        public EmpresaController(FornecedoresContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Empresas.ToList());
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Empresa empresa)
        {
            if(!ModelState.IsValid) return View(empresa);

            if(_context.Empresas.Any(e=> e.CNPJ == empresa.CNPJ))
            {
                ModelState.AddModelError("Model", $"Empresa com o CNPJ {empresa.CNPJ} já cadastrada");
                return View(empresa);
            }

            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            return View(empresa);
        }
    }
}