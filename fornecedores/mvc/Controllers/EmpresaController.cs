using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Context;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using mvc.Validacao;

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

        public IActionResult VerFornecedores(int id)
        {
            var empresa = _context.Empresas.Include(s => s.FornecedoresPessoaFisica)
            .Include(s => s.FornecedoresPessoaJuridica)
            .First(e=> e.Id == id);

            List<FornecedorViewModel> viewModels = new List<FornecedorViewModel>();

            var fornecedoresPF = empresa.FornecedoresPessoaFisica.Select(f=> new FornecedorViewModel(f, empresa.Nome)).ToList();
            var fornecedoresPJ = empresa.FornecedoresPessoaJuridica.Select(f=> new FornecedorViewModel(f, empresa.Nome)).ToList();

            viewModels.AddRange(fornecedoresPF);
            viewModels.AddRange(fornecedoresPJ);

            return View(viewModels);
        }
        public IActionResult Novo()
        {
            PreencherUfs();
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Empresa empresa)
        {
            PreencherUfs();

             empresa.CNPJ = empresa.CNPJ?.LimparCNPJCPF();

            if (!ValidaCNPJ.EhCnpjValido(empresa.CNPJ))
                ModelState.AddModelError("CNPJ", $"CNPJ inválido");

            if (!ModelState.IsValid) return View(empresa);

            if (_context.Empresas.Any(e => e.CNPJ == empresa.CNPJ))
            {
                ModelState.AddModelError("CNPJ", $"Empresa com o CNPJ {empresa.CNPJ} já cadastrada");
                return View(empresa);
            }

            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public void PreencherUfs()
        {
            ViewBag.UFS = new List<SelectListItem>{
             new SelectListItem {Text = "AC", Value = "AC"},
             new SelectListItem {Text = "AL", Value = "AL"},
            new SelectListItem {Text = "AP", Value = "AP"},
            new SelectListItem {Text = "AM", Value = "AM"},
            new SelectListItem {Text = "BA", Value = "BA"},
            new SelectListItem {Text = "CE", Value = "CE"},
            new SelectListItem {Text = "DF", Value = "DF"},
            new SelectListItem {Text = "ES", Value = "ES"},
            new SelectListItem {Text = "GO", Value = "GO"},
            new SelectListItem {Text = "MA", Value = "MA"},
            new SelectListItem {Text = "MT", Value = "MT"},
            new SelectListItem {Text = "MS", Value = "MS"},
            new SelectListItem {Text = "MG", Value = "MG"},
            new SelectListItem {Text = "PA", Value = "PA"},
            new SelectListItem {Text = "PB", Value = "PB"},
            new SelectListItem {Text = "PR", Value = "PR"},
            new SelectListItem {Text = "PE", Value = "PE"},
            new SelectListItem {Text = "PI", Value = "PI"},
            new SelectListItem {Text = "RJ", Value = "RJ"},
            new SelectListItem {Text = "RN", Value = "RN"},
            new SelectListItem {Text = "RS", Value = "RS"},
            new SelectListItem {Text = "RO", Value = "RO"},
            new SelectListItem {Text = "RR", Value = "RR"},
            new SelectListItem {Text = "SC", Value = "SC"},
            new SelectListItem {Text = "SP", Value = "SP"},
            new SelectListItem {Text = "SE", Value = "SE"},
            new SelectListItem {Text = "TO", Value = "TO"}};
        }
    }
}