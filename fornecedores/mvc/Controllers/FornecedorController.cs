using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Context;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using mvc.Extensions;

namespace mvc.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedoresContext _context;

        public FornecedorController(FornecedoresContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Novo()
        {
            PreencherEmpresas();
            return View();
        }

        [HttpPost]
        public IActionResult Novo(FornecedorViewModel viewModel)
        {
            PreencherEmpresas();

            viewModel.CNPJ = viewModel.CNPJ?.LimparCNPJ();

            if (!ModelState.IsValid) return View(viewModel);

            if (_context.Empresas.Any(e => e.CNPJ == viewModel.CNPJ) 
            || _context.FornecedoresPessoaJuridica.Any(e => e.CNPJ == viewModel.CNPJ))
            {
                ModelState.AddModelError("CNPJ", $"Empresa com o CNPJ {viewModel.CNPJ} já cadastrada");
                return View(viewModel);
            }

            if(viewModel.TipoPessoa == "PJ")
            {
                var pj = viewModel.ConverterPessoaJuridica();
                _context.FornecedoresPessoaJuridica.Add(pj);
            }
            else if(viewModel.TipoPessoa == "PF")
            {
                var pf = viewModel.ConverterPessoaFisica();
                _context.FornecedoresPessoaFisica.Add(pf);
            }

            _context.SaveChanges();

            return View(viewModel);
        }

        private void PreencherEmpresas()
        {
            var empresas = _context.Empresas.ToList();

            ViewBag.Empresas = empresas.Select(e => new SelectListItem { Text = e.Nome, Value = Convert.ToString(e.Id) });
        }
    }


}