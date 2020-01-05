
using System.Collections.Generic;
using System.Linq;

namespace mvc.Services.Results
{
    public class ServiceResult
    {
        public bool Sucesso { get; private set; } = true;

        public IEnumerable<MensagemErro> Erros { get; private set; } = new List<MensagemErro>();

        public void AdicionarErro(string codigo, string mensagem)
        {
            Sucesso = false;

            var _erros = Erros.ToList();
                _erros.Add(new MensagemErro(codigo, mensagem));

            Erros = _erros;
        }
    }
}
