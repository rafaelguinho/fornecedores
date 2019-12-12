using System;
using System.Collections.Generic;
using mvc.Models;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class BuscarFornecedoresViewModel
    {
        public string Nome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }


        [Display(Name = "Data cadastro")]
        public DateTime? DataCadastro { get; set; }

        public List<FornecedorViewModel> Fornecedores { get; set; } = new List<FornecedorViewModel>();
    }
}