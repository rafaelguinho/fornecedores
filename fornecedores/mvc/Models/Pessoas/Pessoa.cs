using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace mvc.Models.Pessoas
{
    public abstract class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Telefone> Telefones { get; set; }

        public string TipoPessoa { get; set; }

        public string IdUsuario { get; set; }
    }
}