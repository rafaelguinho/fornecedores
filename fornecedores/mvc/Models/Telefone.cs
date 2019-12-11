using System.ComponentModel.DataAnnotations;
using mvc.Models.Pessoas;

namespace mvc.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}