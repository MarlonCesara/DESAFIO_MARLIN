using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoAluno : Interfaces.IAluno
    {
        IAluno _IAluno;
        IServicoAluno _IServicoAluno;

        public AplicacaoAluno(IAluno IAluno, IServicoAluno IServicoAluno)
        {
            _IAluno = IAluno;
            _IServicoAluno = IServicoAluno;
        }

        public async Task<bool> AdicionarValidarAluno(Aluno aluno, int numeroTurma)
        {
            return await _IServicoAluno.AdicionarValidarAluno(aluno, numeroTurma);
        }

        public async Task<bool> ExisteAluno(string email)
        {
            return await _IAluno.ExisteAluno(email);
        }

        public async Task<int> RetornarIdAluno(string CPF)
        {
            return await _IAluno.RetornarIdAluno(CPF);
        }

        public async Task Adicionar(Aluno Objeto)
        {
            await _IAluno.Adicionar(Objeto);
        }

        public async Task Atualizar(Aluno Objeto)
        {
            await _IAluno.Atualizar(Objeto);
        }

        public async Task<Aluno> BuscarPorId(int Id)
        {
            return await _IAluno.BuscarPorId(Id);
        }

        public async Task<bool> ExcluirValidarAluno(Aluno aluno)
        {
            return await _IServicoAluno.ExcluirValidarAluno(aluno);
        }

        public async Task Excluir(Aluno Objeto)
        {
            await _IAluno.Excluir(Objeto);
        }

        public async Task<List<Aluno>> Listar()
        {
            return await _IAluno.Listar();
        }

    }
}
