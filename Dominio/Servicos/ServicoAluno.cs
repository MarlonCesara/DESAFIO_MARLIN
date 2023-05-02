using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoAluno : IServicoAluno
    {

        private readonly IAluno _IAluno;
        private readonly ITurma _ITurma;
        private readonly IAlunoTurma _IAlunoTurma;

        public ServicoAluno(IAluno IAluno, ITurma ITurma, IAlunoTurma IAlunoTurma)
        {
            _IAluno = IAluno;
            _ITurma = ITurma;
            _IAlunoTurma = IAlunoTurma;
        }

        public async Task<bool> AdicionarValidarAluno(Aluno aluno, int numeroTurma)
        {
            var validarNome = aluno.ValidarPropriedadeString(aluno.Nome, "Nome");
            var validarCPF = aluno.ValidarCPF(aluno.CPF, "CPF");
            var validarEmail = aluno.ValidarEmail(aluno.Email, "Email");

            if (!validarCPF || !validarNome || !validarEmail)
            {
                return false;
            }

            var existeAluno = await _IAluno.ExisteAluno(aluno.CPF);

            if(existeAluno)
            {
                aluno.AdicionarNotificacao("Aluno já cadastrado!");
                return false;
            }

            var existeTurma = await _ITurma.ExisteTurma(numeroTurma);

            if (!existeTurma)
            {
                aluno.AdicionarNotificacao("Turma não encontrada! Verique se a turma foi criada antes de fazer o cadastro!");
                return false;
            }

            //Verifica quantidade de matriculas
            var IdTurma = await _ITurma.RetornarIdTurma(numeroTurma);

            var matriculas = await _IAlunoTurma.ListarPorTurma(IdTurma);
            int quantidadeMatriculas = matriculas.Count;

            if (quantidadeMatriculas >= 5)
            {
                aluno.AdicionarNotificacao("A turma excedeu a quantidade máxima de matrículas!");
                return false;
            }

            await _IAluno.Adicionar(aluno);

            //Criar matricula obrigatória para novo aluno
            var IdAluno = await _IAluno.RetornarIdAluno(aluno.CPF);

            var novaMatricula = new AlunoTurma
            {
                AlunoId = IdAluno,
                TurmaId = IdTurma,
            };

          
            await _IAlunoTurma.Adicionar(novaMatricula);

            return true;  
        }

        public async Task<bool> ExcluirValidarAluno(Aluno aluno)
        {

            if (aluno == null)
            {
             aluno.AdicionarNotificacao("Aluno não encontrado!");
             return false;
            }

            var matricula = await _IAlunoTurma.ListarPorAluno(aluno.Id);

            if (matricula != null)
            {
                aluno.AdicionarNotificacao("Exclua a matrícula antes de excluir o aluno!");
            }

            await _IAluno.Excluir(aluno);
            return true;
        }
    }
}
