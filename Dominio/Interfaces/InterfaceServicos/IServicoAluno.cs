using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoAluno
    {
        Task<bool> AdicionarValidarAluno(Aluno aluno, int numeroTurma);
        Task<bool> ExcluirValidarAluno(Aluno aluno);
    }
}
