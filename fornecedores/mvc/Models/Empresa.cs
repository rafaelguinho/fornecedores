using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using mvc.Models.Pessoas;

namespace mvc.Models
{
    public class Empresa :PessoaJuridica
    {
        public Empresa()
        {
            base.TipoPessoa = "Jurídica empresa";
        }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF { get; set; }


        public ICollection<FornecedorPessoaFisica> FornecedoresPessoaFisica { get; set; }


        public ICollection<FornecedorPessoaJuridica> FornecedoresPessoaJuridica { get; set; }

        
    }
}