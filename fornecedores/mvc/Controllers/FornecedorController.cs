using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Context;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using mvc.Extensions;
using Microsoft.EntityFrameworkCore;

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
            List<FornecedorViewModel> viewModels = new List<FornecedorViewModel>();

            var fornecedoresPF = _context.FornecedoresPessoaFisica.Include(s => s.Empresa).ToList();
            var fornecedoresPJ = _context.FornecedoresPessoaJuridica.Include(s => s.Empresa).ToList();

            if(fornecedoresPF.Count > 0){
                viewModels.AddRange((fornecedoresPF.Select(f=> new FornecedorViewModel(f, f.Empresa.Nome))));
            }

            if(fornecedoresPJ.Count > 0){
                viewModels.AddRange((fornecedoresPJ.Select(f=> new FornecedorViewModel(f, f.Empresa.Nome))));
            }

            return View(viewModels);
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

            if ( _context.FornecedoresPessoaJuridica.Any(e => e.CNPJ == viewModel.CNPJ 
                && e.IdEmpresa == viewModel.IdEmpresa.Value))
            {
                ModelState.AddModelError("CNPJ", $@"Fornecedor com o 
                                        CNPJ {viewModel.CNPJ} já cadastrada para empresa {viewModel.IdEmpresa.Value}");
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