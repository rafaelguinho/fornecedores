using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using mvc.Models.Pessoas;
using System;
using System.Linq;

namespace mvc.Models
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            
        }
        public FornecedorViewModel(FornecedorPessoaJuridica pj, string nomeEmpresa)
        {
            CNPJ = pj.CNPJ;
            Nome = pj.Nome;
            NomeEmpresa = nomeEmpresa;
            DataCadastro = pj.DataCadastro;
        }

        public FornecedorViewModel(FornecedorPessoaFisica pf, string nomeEmpresa)
        {
            RG = pf.RG;
            DataNascimento = pf.DataNascimento;
            Nome = pf.Nome;
            NomeEmpresa = nomeEmpresa;
            DataCadastro = pf.DataCadastro;
        }

        [Display(Name = "Empresa")]
        public string NomeEmpresa { get; set; }

        public string Nome { get; set; }

        public string TipoPessoa { get; set; }

        [Display(Name = "Empresa")]
        public int? IdEmpresa { get; set; }

        [Display(Name = "Data nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Data cadastro")]
        public DateTime DataCadastro { get; set; }

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
                IdEmpresa = IdEmpresa.Value,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { Numero = t.Numero }).ToList()
            };
        }

        public FornecedorPessoaFisica ConverterPessoaFisica()
        {
            return new FornecedorPessoaFisica
            {
                RG = RG,
                DataNascimento = DataNascimento.Value,
                IdEmpresa = IdEmpresa.Value,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { Numero = t.Numero }).ToList()
            };
        }

    }

    public class TelefoneViewModel{

        [Display(Name = "Número")]
        public string Numero { get; set; }
    }
}