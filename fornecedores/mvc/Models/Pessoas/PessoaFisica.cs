using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace mvc.Models.Pessoas
{
    public class PessoaFisica: Pessoa
    {
        public DateTime DataNascimento { get; set; }

        public string RG { get; set; }
    }
}