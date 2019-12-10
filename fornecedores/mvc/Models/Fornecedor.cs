using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace mvc.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        public string CNPJEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataNascimento { get; set; }

        public string RG { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
    }
}