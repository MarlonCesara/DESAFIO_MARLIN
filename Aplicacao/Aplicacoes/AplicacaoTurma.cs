using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoTurma : IAplicacaoTurma
    {

        ITurma _ITurma;
        IServicoTurma _IServicoTurma;

        public AplicacaoTurma(ITurma ITurma, IServicoTurma IServicoTurma)
        {
            _ITurma = ITurma;
            _IServicoTurma = IServicoTurma;
        }


        public async Task Adicionar(Turma Objeto)
        {
            await _ITurma.Adicionar(Objeto);
        }

        public async Task Atualizar(Turma Objeto)
        {
            await _ITurma.Atualizar(Objeto);
        }

        public async Task<Turma> BuscarPorId(int Id)
        {
            return await _ITurma.BuscarPorId(Id);
        }

        public async Task<int> RetornarIdAluno(int numero)
        {
            return await _ITurma.RetornarIdTurma(numero);
        }


        public async Task Excluir(Turma Objeto)
        {
            await _ITurma.Excluir(Objeto);
        }

        public async Task<bool> ExcluirValidarTurma(Turma turma)
        {
            return await _IServicoTurma.ExcluirValidarTurma(turma);
        }

        public async Task<List<Turma>> Listar()
        {
            return await _ITurma.Listar();
        }

        public async Task<bool> ExisteTurma(int numero)
        {
            return await _ITurma.ExisteTurma(numero);
        }

    }
}
