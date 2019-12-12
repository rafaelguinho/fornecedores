using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using mvc.Models.Pessoas;

namespace mvc.Models
{
    public  class FornecedorPessoaJuridica: PessoaJuridica
    {
        public FornecedorPessoaJuridica()
        {
            TipoPessoa = "Jurídica fornecedor";
        }

        public int IdEmpresa { get; set; }

        public Empresa Empresa { get; set; }
        

    }
}