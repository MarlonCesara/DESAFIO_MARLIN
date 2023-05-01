using Aplicacao.Interfaces.Genericos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public  interface IAplicacaoTurma : IGenericaAplicacao<Turma>
    {
        Task<bool> ExisteTurma(int numero);
        Task<int> RetornarIdAluno(int numero);
        Task<bool> ExcluirValidarTurma(Turma turma);
    }
}
