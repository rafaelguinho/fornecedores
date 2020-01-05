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
            return Converter(fornecedoresPF.ToList(), fornecedoresPJ.ToList());
        }

        public static List<FornecedorViewModel> ConverterFornecedoresParaViewModel(ICollection<FornecedorPessoaFisica> fornecedoresPF,
                ICollection<FornecedorPessoaJuridica> fornecedoresPJ)
        {
            return Converter(fornecedoresPF, fornecedoresPJ);
        }

        private static List<FornecedorViewModel> Converter(ICollection<FornecedorPessoaFisica> fornecedoresPF, ICollection<FornecedorPessoaJuridica> fornecedoresPJ)
        {
            var viewModels = new List<FornecedorViewModel>();
            viewModels.AddRange(fornecedoresPF.Select(f => new FornecedorViewModel(f, f.Empresa.Nome)));
            viewModels.AddRange(fornecedoresPJ.Select(f => new FornecedorViewModel(f, f.Empresa.Nome)));

            return viewModels;
        }
    }
}