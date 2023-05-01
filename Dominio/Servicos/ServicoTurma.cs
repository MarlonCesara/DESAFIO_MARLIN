using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoTurma : IServicoTurma
    {

        private readonly ITurma _ITurma;
        private readonly IAlunoTurma _IAlunoTurma;

        public ServicoTurma(ITurma ITurma, IAlunoTurma IAlunoTurma)
        {
            _ITurma = ITurma;
            _IAlunoTurma = IAlunoTurma;
        }

        public async Task<bool> ExcluirValidarTurma(Turma turma)
        {

            if(turma == null)
            {
                turma.AdicionarNotificacao("Turma não encontrada!");
                return false;
            }

            var matriculas = await _IAlunoTurma.ListarPorTurma(turma.Id);
            int quantidadeMatriculas = matriculas.Count;

            if (quantidadeMatriculas > 0)
            {
                turma.AdicionarNotificacao("Para excluir esta turma, exclua primeiramente as matrículas associadas a ela");
                return false;
            }

            await _ITurma.Excluir(turma);
            return true;
        }
    }
}
