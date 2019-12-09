using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Empresa
    {
        public Empresa()
        {

        }

        public Empresa(string uf, string nomeFantasia, string cNPJ)
        {
            UF = uf;
            NomeFantasia = nomeFantasia;
            CNPJ = cNPJ;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string CNPJ { get; set; }
    }
}