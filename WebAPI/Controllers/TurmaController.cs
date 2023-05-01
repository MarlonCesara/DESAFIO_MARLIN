using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {

        private readonly IAplicacaoTurma _IAplicacaoTurma;

        public TurmaController(IAplicacaoTurma IAplicacaoTurma)
        {
            _IAplicacaoTurma = IAplicacaoTurma;
        }


        [Produces("application/json")]
        [HttpPost("/api/AdicionarTurma")]
        public async Task<List<Notifica>> AdicionaTurma(TurmaModel turma)
        {
            var turmaNova = new Turma();
            turmaNova.Numero = turma.Numero;
            turmaNova.AnoLetivo = turma.AnoLetivo;
            await _IAplicacaoTurma.Adicionar(turmaNova);

            return turmaNova.Notificacoes;

        }


        [Produces("application/json")]
        [HttpPost("/api/AtualizarTurma")]
        public async Task<List<Notifica>> AtualizaTurma(TurmaModel turma)
        {
            var turmaNova = await _IAplicacaoTurma.BuscarPorId(turma.IdTurma);
            turmaNova.Numero = turma.Numero;
            turmaNova.AnoLetivo = turma.AnoLetivo;
            await _IAplicacaoTurma.Atualizar(turmaNova);

            return turmaNova.Notificacoes;

        }


        [Produces("application/json")]
        [HttpPost("/api/ExcluirTurma")]
        public async Task<IActionResult> ExcluirTurma(TurmaModel turma)
        {
            var turmaNova = await _IAplicacaoTurma.BuscarPorId(turma.IdTurma);

            var resultado = await 
                _IAplicacaoTurma.ExcluirValidarTurma(turmaNova);

            if (resultado)
                return Ok("Turma excluida com sucesso!");
            else
                return Ok(turmaNova.Notificacoes);
        }


        [Produces("application/json")]
        [HttpPost("/api/BuscarTurmaPorId")]
        public async Task<Turma> BuscarPorId(TurmaModel turma)
        {
            var turmaNova = await _IAplicacaoTurma.BuscarPorId(turma.IdTurma);

            return turmaNova;

        }

    }
}
