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

    public class AlunoController : ControllerBase
    {

        private readonly IAluno _IAplicacaoAluno;

        public AlunoController(IAluno IAplicacaoAluno)
        {
            _IAplicacaoAluno = IAplicacaoAluno;
        }


        [Produces("application/json")]
        [HttpPost("/api/AdicionarAluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] AlunoModel alunoModel)
        {
            var aluno = new Aluno
            {
                Email = alunoModel.Email,
                CPF = alunoModel.CPF,
                Nome = alunoModel.Nome
            };

            var resultado = await
                _IAplicacaoAluno.AdicionarValidarAluno(aluno, alunoModel.NumeroTurma);

            if (resultado)
                return Ok("Aluno Adicionado com Sucesso");
            else
                return Ok(aluno.Notificacoes);
        }


     
        [Produces("application/json")]
        [HttpPost("/api/AtualizarAluno")]
        public async Task<List<Notifica>> AtualizarAluno(AlunoModel aluno)
        {
            var alunoNovo = await _IAplicacaoAluno.BuscarPorId(aluno.IdAluno);
            alunoNovo.Nome = aluno.Nome;
            alunoNovo.Email = aluno.Email;
            alunoNovo.CPF = aluno.CPF;

            await _IAplicacaoAluno.Atualizar(alunoNovo);

            return alunoNovo.Notificacoes;
        }


        [Produces("application/json")]
        [HttpPost("/api/ExcluirAluno")]
        public async Task<IActionResult> ExcluirAluno(AlunoModel aluno)
        {
            var alunoNovo = await _IAplicacaoAluno.BuscarPorId(aluno.IdAluno);

            var resultado = await 
                _IAplicacaoAluno.ExcluirValidarAluno(alunoNovo);

            if (resultado)
                return Ok("Aluno excluido com Sucesso!");
            else
                return Ok(alunoNovo.Notificacoes);
        }

       
        [Produces("application/json")]
        [HttpPost("/api/BuscarAlunoPorId")]
        public async Task<Aluno> BuscarPorId(AlunoModel aluno)
        {
            var alunoNovo = await _IAplicacaoAluno.BuscarPorId(aluno.IdAluno);

            return alunoNovo;
        }

    }
}
