using System.Linq;
using mvc.Models;

namespace Repository.BuscaStrategies.FornecedorFilters
{
    public class BuscarData : IFornecedoresBuscaStrategy
    {
        public (IQueryable<FornecedorPessoaFisica> queryPF, IQueryable<FornecedorPessoaJuridica> queryPJ) Apply(IQueryable<FornecedorPessoaFisica> queryPF, 
         IQueryable<FornecedorPessoaJuridica> queryPJ, 
         BuscarFornecedoresViewModel busca)
        {
            if (!busca.DataCadastro.HasValue) return (queryPF, queryPJ);

            var data = busca.DataCadastro.Value.Date;

            return (queryPF.Where(f=>f.DataCadastro.Date == data),
            queryPJ.Where(f=>f.DataCadastro.Date == data));
        }

    }
}