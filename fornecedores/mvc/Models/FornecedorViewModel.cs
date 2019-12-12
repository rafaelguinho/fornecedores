using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using mvc.Models.Pessoas;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace mvc.Models
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {

        }
        public FornecedorViewModel(FornecedorPessoaJuridica pj, string nomeEmpresa)
        {
            CPFCNPJ = pj.CNPJ;
            Nome = pj.Nome;
            NomeEmpresa = nomeEmpresa;
            DataCadastro = pj.DataCadastro;
            TelefonesView = UnirTelefones(pj.Telefones);
        }

        public FornecedorViewModel(FornecedorPessoaFisica pf, string nomeEmpresa)
        {
            RG = pf.RG;
            CPFCNPJ = pf.CPF;
            DataNascimento = pf.DataNascimento;
            Nome = pf.Nome;
            NomeEmpresa = nomeEmpresa;
            DataCadastro = pf.DataCadastro;
            TelefonesView = UnirTelefones(pf.Telefones);
        }

        private string UnirTelefones(ICollection<Telefone> telefones)
        {
            if (telefones == null) return string.Empty;

            return string.Join(",", telefones.Select(t => t.Numero).ToArray());
        }

        [Display(Name = "Empresa")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
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

        public string CPF { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string CPFCNPJ { get; set; }

        public string TelefonesView { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; } = new List<TelefoneViewModel>();

        public FornecedorPessoaJuridica ConverterPessoaJuridica()
        {
            return new FornecedorPessoaJuridica
            {
                CNPJ = CNPJ,
                IdEmpresa = IdEmpresa.Value,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { Numero = t.Numero }).Where(t => !string.IsNullOrEmpty(t.Numero)).ToList()
            };
        }

        public FornecedorPessoaFisica ConverterPessoaFisica()
        {
            return new FornecedorPessoaFisica
            {
                RG = RG,
                CPF = CPF,
                DataNascimento = DataNascimento.Value,
                IdEmpresa = IdEmpresa.Value,
                Nome = Nome,
                Telefones = Telefones.Select(t => new Telefone { Numero = t.Numero }).Where(t => !string.IsNullOrEmpty(t.Numero)).ToList()
            };
        }

    }

    public class TelefoneViewModel
    {

        [Display(Name = "Número")]
        public string Numero { get; set; }
    }
}