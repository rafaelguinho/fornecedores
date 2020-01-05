using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Repositories
{
    public interface IEmpresaRepository
    {
        Empresa Salvar(Empresa empresa);

        IEnumerable<Empresa> Listar(string idUsuario);

        bool Existe(Empresa empresa, string idUsuario);

        (ICollection<FornecedorPessoaFisica> fornecedoresPF,
            ICollection<FornecedorPessoaJuridica> fornecedoresPJ) ListarFornecedoresEmpresa(string idUsuario, int idEmpresa);
    }
}
