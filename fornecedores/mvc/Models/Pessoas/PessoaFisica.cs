using System;

namespace mvc.Models.Pessoas
{
    public class PessoaFisica: Pessoa
    {
        public DateTime DataNascimento { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }
    }
}