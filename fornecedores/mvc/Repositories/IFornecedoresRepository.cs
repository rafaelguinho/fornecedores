using System.Linq;
using mvc.Models;

namespace Repository
{
    public interface IFornecedoresRepository
    {
        (IQueryable<FornecedorPessoaFisica> fornecedoresPF, IQueryable<FornecedorPessoaJuridica>fornecedoresPJ) 
            Buscar(string idUsuario, BuscarFornecedoresViewModel busca = null);

        FornecedorPessoaFisica Salvar(FornecedorPessoaFisica pf);
        FornecedorPessoaJuridica Salvar(FornecedorPessoaJuridica pj);
    }
}