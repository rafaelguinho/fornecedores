using System.Linq;
using mvc.Models;

namespace Repository.BuscaStrategies
{
    public interface IFornecedoresBuscaStrategy
    {
         (IQueryable<FornecedorPessoaFisica> queryPF, IQueryable<FornecedorPessoaJuridica> queryPJ) Apply(IQueryable<FornecedorPessoaFisica> queryPF, 
         IQueryable<FornecedorPessoaJuridica> queryPJ, 
         BuscarFornecedoresViewModel busca);

    }
}