using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoAlunoTurma : Interfaces.IAlunoTurma
    {
        IAlunoTurma _IAlunoTurma;
        IServicoAlunoTurma _IServicoAlunoTurma;

        public AplicacaoAlunoTurma(IAlunoTurma IAlunoTurma, IServicoAlunoTurma IServicoAlunoTurma)
        {
            _IAlunoTurma = IAlunoTurma;
            _IServicoAlunoTurma = IServicoAlunoTurma;
        }

        public async Task<bool> AdicionarValidarAlunoTurma(AlunoTurma alunoTurma)
        {
            return await _IServicoAlunoTurma.AdicionarValidarAlunoTurma(alunoTurma);
        }

        public async Task<bool> ExisteAlunoTurma(AlunoTurma alunoTurma)
        {
            return await _IAlunoTurma.ExisteAlunoTurma(alunoTurma);
        }

        public async Task<List<AlunoTurma>> ListarPorId(int alunoId)
        {
            return await _IAlunoTurma.ListarPorTurma(alunoId);
        }

        public async Task Adicionar(AlunoTurma Objeto)
        {
            await _IAlunoTurma.Adicionar(Objeto);
        }

        public async Task Atualizar(AlunoTurma Objeto)
        {
            await _IAlunoTurma.Atualizar(Objeto);
        }

        public async Task<AlunoTurma> BuscarPorId(int Id)
        {
            return await _IAlunoTurma.BuscarPorId(Id);
        }

        public async Task Excluir(AlunoTurma Objeto)
        {
            await _IAlunoTurma.Excluir(Objeto);
        }

        public async Task<List<AlunoTurma>> Listar()
        {
            return await _IAlunoTurma.Listar();
        }
    }
}
