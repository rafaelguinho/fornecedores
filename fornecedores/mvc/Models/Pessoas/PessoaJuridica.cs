using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace mvc.Models.Pessoas
{
    public class PessoaJuridica: Pessoa
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CNPJ { get; set; }
    }
}