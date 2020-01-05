using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using mvc.Areas.Identity;
using mvc.Extensions;
using mvc.Models;
using mvc.Repositories;
using mvc.Services.Results;
using mvc.Validacao;
using System.Collections.Generic;

namespace mvc.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly UserManager<AppIdentityUser> _userManager;

        public EmpresaService(IHttpContextAccessor httpContextAccessor, 
            IEmpresaRepository empresaRepository, UserManager<AppIdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _empresaRepository = empresaRepository;
            _userManager = userManager;
        }

        public IEnumerable<Empresa> Listar()
        {
            var idUsuario = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return _empresaRepository.Listar(idUsuario);
        }

        public (ICollection<FornecedorPessoaFisica> fornecedoresPF,
            ICollection<FornecedorPessoaJuridica> fornecedoresPJ) 
            ListarFornecedoresEmpresa(int idEmpresa)
        {
            var idUsuario = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            return _empresaRepository.ListarFornecedoresEmpresa(idUsuario, idEmpresa);
        }

        public ServiceResult Salvar(Empresa empresa)
        {
            var resultado = new ServiceResult();

            empresa.CNPJ = empresa.CNPJ?.LimparCNPJCPF();

            if (!ValidaCNPJ.EhCnpjValido(empresa.CNPJ))
                resultado.AdicionarErro("CNPJ", $"CNPJ inválido");

            var idUsuario = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);

            if(_empresaRepository.Existe(empresa, idUsuario))
                resultado.AdicionarErro("CNPJ", $"Empresa com o CNPJ {empresa.CNPJ} já cadastrada");

            empresa.IdUsuario = idUsuario;

            if(resultado.Sucesso)
                _empresaRepository.Salvar(empresa);


            return resultado;
        }
    }
}
