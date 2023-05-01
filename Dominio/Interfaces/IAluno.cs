using Dominio.Interfaces.Genericos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IAluno : IGenericos<Aluno>
    {
        Task<bool> ExisteAluno(string CPF);

        Task<int> RetornarIdAluno(string CPF);

    }
}
