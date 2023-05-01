using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IAlunoTurma : IGenericos<AlunoTurma>
    {
        Task<bool> ExisteAlunoTurma(AlunoTurma alunoTurma);

        Task<List<AlunoTurma>> ListarPorTurma(int turmaid);

        Task<List<AlunoTurma>> ListarPorAluno(int alunoId);

    }
}
