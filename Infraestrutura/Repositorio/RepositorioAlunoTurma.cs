using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioAlunoTurma : RepositorioGenerico<AlunoTurma>, IAlunoTurma
    {

        private readonly DbContextOptions<Contexto> _optionsbuilder;

        public RepositorioAlunoTurma()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }


        public async Task<bool> ExisteAlunoTurma(AlunoTurma alunoTurma)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.AlunoTurma.
                          Where(u => u.TurmaId.Equals(alunoTurma.TurmaId) && u.AlunoId.Equals(alunoTurma.AlunoId))
                          .AsNoTracking()
                          .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<AlunoTurma>> ListarPorTurma(int turmaId)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.AlunoTurma
                        .Where(at => at.TurmaId == turmaId)
                        .AsNoTracking()
                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                return new List<AlunoTurma>();
            }
        }

        public async Task<List<AlunoTurma>> ListarPorAluno(int alunoId)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.AlunoTurma
                        .Where(at => at.AlunoId == alunoId)
                        .AsNoTracking()
                        .ToListAsync();
                }
            }
            catch (Exception)
            {
                return new List<AlunoTurma>();
            }

        }

    }
}
