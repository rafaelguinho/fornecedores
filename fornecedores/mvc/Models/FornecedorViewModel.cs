using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using mvc.Models.Pessoas;
using System;
using System.Linq;

namespace mvc.Models
{
    public class FornecedorViewModel
    {
        public string Nome { get; set; }

        public string TipoPessoa { get; set; }

        public int IdEmpresa { get; set; }

        [Display(Name = "Data nascimento")]
        public DateTime? DataNascimento { get; set; }

        public string RG { get; set; }

        public string CNPJ { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; } = new List<TelefoneViewModel>();

        public bool EhValido()
        {
            return true;
        }

        public FornecedorPessoaJuridica ConverterPessoaJuridica()
        {
            return new FornecedorPessoaJuridica
            {
                CNPJ = CNPJ,
                IdEmpresa = IdEmpresa,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { DDD = t.DDD, Numero = t.Numero }).ToList()
            };
        }

        public FornecedorPessoaFisica ConverterPessoaFisica()
        {
            return new FornecedorPessoaFisica
            {
                RG = RG,
                DataNascimento = DataNascimento.Value,
                IdEmpresa = IdEmpresa,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { DDD = t.DDD, Numero = t.Numero }).ToList()
            };
        }


    }

    public class TelefoneViewModel{
        public string DDD { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }
    }
}