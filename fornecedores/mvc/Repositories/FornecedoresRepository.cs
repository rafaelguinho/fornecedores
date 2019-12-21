using System.Collections.Generic;
using System.Linq;
using mvc.Models;
using mvc.Context;
using Microsoft.EntityFrameworkCore;
using Repository.BuscaStrategies;

namespace Repository
{
    public class FornecedoresRepository : IFornecedoresRepository
    {
        private readonly FornecedoresContext _context;
        private readonly IEnumerable<IFornecedoresBuscaStrategy> _strategies;

        public FornecedoresRepository(FornecedoresContext context,
        IEnumerable<IFornecedoresBuscaStrategy> strategies)
        {
            _context = context;
            _strategies = strategies;
        }

        public (IQueryable<FornecedorPessoaFisica> fornecedoresPF, IQueryable<FornecedorPessoaJuridica> fornecedoresPJ) Buscar(BuscarFornecedoresViewModel busca = null)
        {
            var queryPF = _context.FornecedoresPessoaFisica.Include(f=>f.Empresa).AsNoTracking();
            var queryPJ = _context.FornecedoresPessoaJuridica.Include(f=>f.Empresa).AsNoTracking();

            if(busca == null) return (queryPF, queryPJ);

            foreach (var strategy in _strategies)
            {
                var queries = strategy.Apply(queryPF, queryPJ, busca);

                queryPF = queries.queryPF;
                queryPJ = queries.queryPJ;
            }

            return (queryPF, queryPJ);

        }
    }
}