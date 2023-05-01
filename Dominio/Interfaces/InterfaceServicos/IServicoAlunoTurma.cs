using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{

    public interface IServicoAlunoTurma
    {
        Task<bool> AdicionarValidarAlunoTurma(AlunoTurma alunoTurma);
    }
}
