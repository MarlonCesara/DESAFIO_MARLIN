using Aplicacao.Interfaces.Genericos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAluno : IGenericaAplicacao<Aluno>
    {
        Task<bool> AdicionarValidarAluno(Aluno aluno, int numeroTurma);
        Task<int> RetornarIdAluno(string CPF);
        Task<bool> ExcluirValidarAluno(Aluno aluno);
 
    }
}
