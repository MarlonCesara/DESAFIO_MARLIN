using Entidades.Entidades;
using Entidades.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using Aplicacao.Interfaces;




namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurma _IAplicacaoAlunoTurma;

        public AlunoTurmaController(IAlunoTurma IAplicacaoAlunoTurma)
        {
            _IAplicacaoAlunoTurma = IAplicacaoAlunoTurma;
        }


        [Produces("application/json")]
        [HttpPost("/api/AtualizarMatricula")]
        public async Task<List<Notifica>> AtualizarAlunoTurma(AlunoTurmaModel alunoTurma)
        {
            var alunoTurmaNovo = new AlunoTurma
            {
            Id = alunoTurma.IdAlunoTurma,
            AlunoId = alunoTurma.IdAluno,
            TurmaId = alunoTurma.IdTurma,
            };

            await _IAplicacaoAlunoTurma.Atualizar(alunoTurmaNovo);

            return alunoTurmaNovo.Notificacoes;
        }


        [Produces("application/json")]
        [HttpPost("/api/ExcluirMatricula")]
        public async Task<List<Notifica>> ExcluirAlunoTurma(AlunoTurmaModel alunoTurma)
        {
            var alunoTurmaNovo = await _IAplicacaoAlunoTurma.BuscarPorId(alunoTurma.IdAlunoTurma);

            await _IAplicacaoAlunoTurma.Excluir(alunoTurmaNovo);

            return alunoTurmaNovo.Notificacoes;

        }


        [Produces("application/json")]
        [HttpPost("/api/BuscarMatriculaPorId")]
        public async Task<AlunoTurma> BuscarPorId(AlunoTurmaModel alunoTurma)
        {
            var alunoTurmaNovo = await _IAplicacaoAlunoTurma.BuscarPorId(alunoTurma.IdAlunoTurma);

            return alunoTurmaNovo;

        }


        [Produces("application/json")]
        [HttpPost("/api/MatricularAluno")]
        public async Task<IActionResult> MatricularAluno([FromBody] AlunoTurmaModel alunoTurmaModel)
        {
            var alunoTurma = new AlunoTurma
            {
                AlunoId = alunoTurmaModel.IdAluno,
                TurmaId = alunoTurmaModel.IdTurma,
            };

            var resultado = await
                _IAplicacaoAlunoTurma.AdicionarValidarAlunoTurma(alunoTurma);

            if (resultado)
                return Ok("Matricula efetuada com Sucesso");
            else
                return Ok(alunoTurma.Notificacoes);
        }
    }
}
