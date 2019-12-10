using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Telefone
    {
        public int Id { get; set; }

        public string DDD { get; set; }

        public string Numero { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}