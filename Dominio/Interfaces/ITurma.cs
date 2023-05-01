using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface ITurma : IGenericos<Turma>
    {
        Task<List<Turma>> ListarTurmas(Expression<Func<Turma, bool>> exTurma);

        Task<bool> ExisteTurma(int numero);

        Task<int> RetornarIdTurma(int numero);
    }
}
