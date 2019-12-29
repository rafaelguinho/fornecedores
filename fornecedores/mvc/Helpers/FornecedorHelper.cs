using mvc.Models;
using System.Linq;
using System.Collections.Generic;

namespace mvc.Helpers
{
    public static class FornecedorHelper
    {
        public static List<FornecedorViewModel> ConverterFornecedoresParaViewModel(IQueryable<FornecedorPessoaFisica> fornecedoresPF,
                IQueryable<FornecedorPessoaJuridica> fornecedoresPJ)
        {
            var viewModels = new List<FornecedorViewModel>();
            viewModels.AddRange(fornecedoresPF.ToList().Select(f => new FornecedorViewModel(f, f.Empresa.Nome)));
            viewModels.AddRange(fornecedoresPJ.ToList().Select(f => new FornecedorViewModel(f, f.Empresa.Nome)));

            return viewModels;
        }
    }
}