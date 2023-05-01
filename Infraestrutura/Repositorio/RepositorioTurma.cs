using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioTurma : RepositorioGenerico<Turma>, ITurma
    {

        private readonly DbContextOptions<Contexto> _optionsbuilder;

        public RepositorioTurma()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task<List<Turma>> ListarTurmas(Expression<Func<Turma, bool>> exTurma)
        {
            using (var banco = new Contexto(_optionsbuilder))
            {
                return await banco.Turma.Where(exTurma).AsNoTracking().ToListAsync();
            }
        }

        public async Task<bool> ExisteTurma(int numero)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.Turma.
                          Where(u => u.Numero.Equals(numero))
                          .AsNoTracking()
                          .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> RetornarIdTurma(int numero)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    var turma = await data.Turma.
                          Where(u => u.Numero.Equals(numero))
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

                    return turma.Id;

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
