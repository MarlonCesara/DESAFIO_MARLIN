using Aplicacao.Interfaces.Genericos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAlunoTurma : IGenericaAplicacao<AlunoTurma>
    {
        Task<bool> AdicionarValidarAlunoTurma(AlunoTurma aluno);
    }
}
