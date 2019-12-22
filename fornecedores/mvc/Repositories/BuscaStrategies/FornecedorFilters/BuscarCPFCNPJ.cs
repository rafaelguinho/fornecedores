using System.Linq;
using mvc.Models;
using static mvc.Extensions.StringExtensions;

namespace Repository.BuscaStrategies.FornecedorFilters
{
    public class BuscarCPFCNPJ : IFornecedoresBuscaStrategy
    {
        public (IQueryable<FornecedorPessoaFisica> queryPF, IQueryable<FornecedorPessoaJuridica> queryPJ) Apply(IQueryable<FornecedorPessoaFisica> queryPF, 
         IQueryable<FornecedorPessoaJuridica> queryPJ, 
         BuscarFornecedoresViewModel busca)
        {
            if (string.IsNullOrEmpty(busca.CPFCNPJ)) return (queryPF, queryPJ);

            var CPFCNPJ = busca.CPFCNPJ.LimparCNPJCPF();

            return (queryPF.Where(f=>f.CPF == CPFCNPJ),
            queryPJ.Where(f=>f.CNPJ == CPFCNPJ));
        }

    }
}