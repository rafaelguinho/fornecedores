using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Services.Results
{
    public class MensagemErro
    {
        public MensagemErro(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
    }
}
