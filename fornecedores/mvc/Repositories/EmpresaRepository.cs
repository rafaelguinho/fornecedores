using Microsoft.EntityFrameworkCore;
using mvc.Context;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly FornecedoresContext _context;

        public EmpresaRepository(FornecedoresContext context)
        {
            _context = context;
        }

        public bool Existe(Empresa empresa, string idUsuario)
        {
            return _context.Empresas.Any(e => e.CNPJ == empresa.CNPJ && e.IdUsuario == idUsuario);
        }

        public IEnumerable<Empresa> Listar(string idUsuario)
        {
            return _context.Empresas.Where(e => e.IdUsuario == idUsuario);
        }

        public (ICollection<FornecedorPessoaFisica> fornecedoresPF, ICollection<FornecedorPessoaJuridica> fornecedoresPJ) 
            ListarFornecedoresEmpresa(string idUsuario, int idEmpresa)
        {
            var empresa = _context.Empresas.Include(s => s.FornecedoresPessoaFisica)
                            .Include(s => s.FornecedoresPessoaJuridica)
                        .SingleOrDefault(e => e.Id == idEmpresa && e.IdUsuario == idUsuario);

            return (empresa.FornecedoresPessoaFisica, empresa.FornecedoresPessoaJuridica);
        }

        public Empresa Salvar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();

            return empresa;
        }
    }
}
