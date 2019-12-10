using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace mvc.Models
{
    public class Empresa
    {
        public Empresa()
        {

        }

        public Empresa(string cNPJ, string uf, string nomeFantasia)
        {
            CNPJ = cNPJ;
            UF = uf;
            NomeFantasia = nomeFantasia;
        }


        [Required(ErrorMessage = "Campo obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeFantasia { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }

        public void LimparCNPJ()
        {
            CNPJ = CNPJ.Replace(",", "").Replace("-", "").Replace(".", "").Replace("/", "");
        }
    }
}