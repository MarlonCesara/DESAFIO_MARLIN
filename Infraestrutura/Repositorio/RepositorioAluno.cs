using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioAluno : RepositorioGenerico<Aluno>, IAluno
    {

        private readonly DbContextOptions<Contexto> _optionsbuilder;

        public RepositorioAluno()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> ExisteAluno(string CPF)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.Aluno.
                          Where(u => u.CPF.Equals(CPF))
                          .AsNoTracking()
                          .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> RetornarIdAluno(string CPF)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    var aluno = await data.Aluno.
                          Where(u => u.CPF.Equals(CPF))
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

                    return aluno.Id;

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
