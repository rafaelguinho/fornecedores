using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace mvc.Models.Pessoas
{
    public class PessoaJuridica: Pessoa
    {
        public string CNPJ { get; set; }
    }
}