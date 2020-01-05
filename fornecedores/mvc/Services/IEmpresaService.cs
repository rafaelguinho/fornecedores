using mvc.Models;
using mvc.Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Services
{
    public interface IEmpresaService
    {
        ServiceResult Salvar(Empresa empresa);

        IEnumerable<Empresa> Listar();

        (ICollection<FornecedorPessoaFisica> fornecedoresPF,
            ICollection<FornecedorPessoaJuridica> fornecedoresPJ) ListarFornecedoresEmpresa(int idEmpresa);
    }
}
