using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Models;
using System.Collections.Generic;
using static mvc.Helpers.FornecedorHelper;
using Microsoft.AspNetCore.Authorization;
using mvc.Services;

namespace mvc.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        public IActionResult Index()
        {
            return View(_empresaService.Listar());
        }

        public IActionResult VerFornecedores(int id)
        {
            var fornecedores = _empresaService.ListarFornecedoresEmpresa(id);

            var viewModels = ConverterFornecedoresParaViewModel(fornecedores.fornecedoresPF,
           fornecedores.fornecedoresPJ);

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
            var resultado = _empresaService.Salvar(empresa);

            if (!resultado.Sucesso)
            {
                foreach(var erro in resultado.Erros)
                {
                    ModelState.AddModelError(erro.Codigo, erro.Descricao);
                }

                PreencherUfs();

                return View(empresa);
            }

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