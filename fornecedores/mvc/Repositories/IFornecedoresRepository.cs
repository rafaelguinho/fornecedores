using System.Linq;
using mvc.Models;

namespace Repository
{
    public interface IFornecedoresRepository
    {
        (IQueryable<FornecedorPessoaFisica> fornecedoresPF, IQueryable<FornecedorPessoaJuridica>fornecedoresPJ) Buscar(BuscarFornecedoresViewModel busca = null);
    }
}