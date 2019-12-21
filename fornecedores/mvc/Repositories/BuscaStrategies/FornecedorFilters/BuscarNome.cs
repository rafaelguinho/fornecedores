using System.Linq;
using mvc.Models;

namespace Repository.BuscaStrategies.FornecedorFilters
{
    public class BuscarNome : IFornecedoresBuscaStrategy
    {
        public (IQueryable<FornecedorPessoaFisica> queryPF, IQueryable<FornecedorPessoaJuridica> queryPJ) Apply(IQueryable<FornecedorPessoaFisica> queryPF, 
         IQueryable<FornecedorPessoaJuridica> queryPJ, 
         BuscarFornecedoresViewModel busca)
        {
            if (string.IsNullOrEmpty(busca.Nome)) return (queryPF, queryPJ);

            var nome = busca.Nome.ToLower();

            return (queryPF.Where(f=>f.Nome.ToLower().Contains(nome)),
            queryPJ.Where(f=>f.Nome.ToLower().Contains(nome)));
        }

    }
}