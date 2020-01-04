using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvc.Context;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using mvc.Validacao;
using Repository;
using static mvc.Helpers.FornecedorHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using mvc.Areas.Identity;

namespace mvc.Controllers
{
    [Authorize]
    public class FornecedorController : Controller
    {
        private readonly IFornecedoresRepository _repository;
        private readonly FornecedoresContext _context;
        private readonly UserManager<AppIdentityUser> _userManager;

        public FornecedorController(IFornecedoresRepository repository, 
            FornecedoresContext context, 
            UserManager<AppIdentityUser> userManager)
        {
            _repository = repository;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var idUsuario = _userManager.GetUserId(HttpContext.User);
            var fornecedores = _repository.Buscar(idUsuario);

           var viewModels = ConverterFornecedoresParaViewModel(fornecedores.fornecedoresPF,
            fornecedores.fornecedoresPJ);

            var busca = new BuscarFornecedoresViewModel
            {
                Fornecedores = viewModels
            };

            return View(busca);
        }

        public IActionResult Buscar([FromQuery] BuscarFornecedoresViewModel buscaViewModel)
        {
            var idUsuario = _userManager.GetUserId(HttpContext.User);
            var fornecedores = _repository.Buscar(idUsuario, buscaViewModel);

            var fornecedorViewModels = ConverterFornecedoresParaViewModel(fornecedores.fornecedoresPF,
            fornecedores.fornecedoresPJ);

            buscaViewModel.Fornecedores = fornecedorViewModels;

            
            return View("Index", buscaViewModel);
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

            viewModel.CNPJ = viewModel.CNPJ?.LimparCNPJCPF();
            viewModel.CPF = viewModel.CPF?.LimparCNPJCPF();

            var ufEmpresa = ObterUfEmpresa(viewModel.IdEmpresa);

            Valida(viewModel, ufEmpresa);

            if (!ModelState.IsValid) return View(viewModel);

            if (_context.FornecedoresPessoaJuridica.Any(e => e.CNPJ == viewModel.CNPJ
               && e.IdEmpresa == viewModel.IdEmpresa.Value))
            {
                ModelState.AddModelError("CNPJ", $@"Fornecedor com o 
                                        CNPJ {viewModel.CNPJ} já cadastrada para empresa {viewModel.IdEmpresa.Value}");
                return View(viewModel);
            }

            var idUsuario = _userManager.GetUserId(HttpContext.User);
            
            if (viewModel.TipoPessoa == "PJ")
            {
                var pj = viewModel.ConverterPessoaJuridica();
                pj.IdUsuario = idUsuario;
                _repository.Salvar(pj);
            }
            else if (viewModel.TipoPessoa == "PF")
            {
                var pf = viewModel.ConverterPessoaFisica();
                pf.IdUsuario = idUsuario;
                _repository.Salvar(pf);
            }

            return RedirectToAction("Index");
        }

        private void PreencherEmpresas()
        {
            var empresas = _context.Empresas.ToList();

            ViewBag.Empresas = empresas.Select(e => new SelectListItem { Text = e.Nome, Value = Convert.ToString(e.Id) });
        }

        private string ObterUfEmpresa(int? idEmpresa)
        {
            if (!idEmpresa.HasValue) return string.Empty;

            var empresa = _context.Empresas.Where(e => e.Id == idEmpresa.Value).FirstOrDefault();

            if (empresa == null) return string.Empty;

            return empresa.UF;
        }

        private void Valida(FornecedorViewModel viewModel, string ufEmpresa)
        {
            if (!viewModel.IdEmpresa.HasValue)
                ModelState.AddModelError("IdEmpresa", $"É necessário informar uma empresa cadastrada");

            if (viewModel.TipoPessoa == "PF")
                EhPFValido(viewModel, ufEmpresa);
            else if (viewModel.TipoPessoa == "PJ")
                EhPJValido(viewModel);
        }

        private void EhPJValido(FornecedorViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.CNPJ))
                ModelState.AddModelError("CNPJ", $"Campo obrigatório para pessoa jurídica");

            if ((!string.IsNullOrEmpty(viewModel.CNPJ)) && !ValidaCNPJ.EhCnpjValido(viewModel.CNPJ))
                ModelState.AddModelError("CNPJ", $"CNPJ inválido");
        }

        private void EhPFValido(FornecedorViewModel viewModel, string ufEmpresa)
        {
            if (string.IsNullOrEmpty(viewModel.RG))
                ModelState.AddModelError("RG", $"Campo obrigatório para pessoa física");


            if (string.IsNullOrEmpty(viewModel.CPF))
                ModelState.AddModelError("CPF", $"Campo obrigatório para pessoa física");


            if (!viewModel.DataNascimento.HasValue)
                ModelState.AddModelError("DataNascimento", $"Campo obrigatório para pessoa física");


            if ((!string.IsNullOrEmpty(viewModel.CPF)) && !ValidaCPF.EhCpfValido(viewModel.CPF))
                ModelState.AddModelError("CPF", $"CPF inválido");

            ValidaMenorDeIdadeParana(viewModel.DataNascimento, ufEmpresa);
        }

        private void ValidaMenorDeIdadeParana(DateTime? dataNascimento, string ufEmpresa)
        {
            if ((!dataNascimento.HasValue) || ufEmpresa != "PR") return;

            var idade = CalculaIdade(dataNascimento.Value);

            if (idade < 18)
                ModelState.AddModelError("DataNascimento", $"Para empresas do Paraná o fornecedor não pode ser menor de idade");
        }

        private int CalculaIdade(DateTime dataNascimento)
        {
            int anos = DateTime.Now.Year - dataNascimento.Year;

            if ((dataNascimento.Month > DateTime.Now.Month) || (dataNascimento.Month == DateTime.Now.Month && dataNascimento.Day > DateTime.Now.Day))
                anos--;

            return anos;
        }
    }


}