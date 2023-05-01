using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoTurma
    {
        Task<bool> ExcluirValidarTurma(Turma turma);

    }
}
