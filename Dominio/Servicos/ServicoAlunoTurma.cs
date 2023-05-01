using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoAlunoTurma : IServicoAlunoTurma
    {
        private readonly IAluno _IAluno;
        private readonly ITurma _ITurma;
        private readonly IAlunoTurma _IAlunoTurma;


        public ServicoAlunoTurma(ITurma ITurma, IAluno IAluno, IAlunoTurma IAlunoTurma)
        {
            _ITurma = ITurma;
            _IAluno = IAluno;
            _IAlunoTurma = IAlunoTurma;
        }

        public async Task<bool> AdicionarValidarAlunoTurma(AlunoTurma alunoTurma)
        {

            var Turma = await _ITurma.BuscarPorId(alunoTurma.TurmaId);

            if(Turma == null)
            {
                alunoTurma.AdicionarNotificacao("Turma não encontrada!");
                return false;
            }

            var matriculas = await _IAlunoTurma.ListarPorTurma(alunoTurma.TurmaId);
            int quantidadeMatriculas = matriculas.Count;

            if (quantidadeMatriculas >= 5)
            {
                alunoTurma.AdicionarNotificacao("A turma excedeu a quantidade máxima de matrículas");
                return false;
            }

            var existeMatricula = await _IAlunoTurma.ExisteAlunoTurma(alunoTurma);

            if (existeMatricula)
            {
                alunoTurma.AdicionarNotificacao("Este aluno já está matriculado nesta turma");
                return false;
            }

            var Aluno = await _IAluno.BuscarPorId(alunoTurma.AlunoId);

            if (Aluno == null)
            {
                alunoTurma.AdicionarNotificacao("Este aluno não existe");
                return false;
            }

            await _IAlunoTurma.Adicionar(alunoTurma);

            return true;  
        }
    }
}
