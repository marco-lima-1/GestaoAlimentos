using Azure.Core;
using GestaoAlimentos.Data;
using GestaoAlimentos.Models;
using GestaoAlimentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoAlimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefeicoesController : ControllerBase
    {
        private readonly IRefeicaoRepository _refeicaoRepository;

        public RefeicoesController(IRefeicaoRepository refeicaoRepository)
        {
            _refeicaoRepository = refeicaoRepository;
        }

        [HttpPost("Adicionar Refeicao Para Usuario")]
        public async Task<ActionResult> AdicionarRefeicaoParaUsuario(RefeicaoModel refeicao, int UsuarioId)
        {
            try
            {
                var novaRefeicao = await _refeicaoRepository.AdicionarRefeicaoParaUsuario(refeicao, UsuarioId);

                if (novaRefeicao != null)
                {
                    return Ok(new { message = "Refeição adicionada com sucesso!", refeicao = novaRefeicao });
                }
                else
                {
                    return NotFound(new { message = "Usuário não encontrado!" });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "Ocorreu um erro ao adicionar a refeição.", error = ex.Message });
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RefeicaoModel>>> GetAll()
        {
            var refeicoes = await _refeicaoRepository.GetAll();
            return refeicoes.ToList();
        }
        [HttpGet("{id}")]
        public async Task<RefeicaoModel> BuscarRefPorId(int id)
        {
            var refeicao = await _refeicaoRepository.BuscarRefPorId(id);
            if (refeicao == null)
            {
                throw new Exception($"Refeição {id} não encontrada");
            }
            return refeicao;

        }
        [HttpPost]
        public async Task<RefeicaoModel> AdicionarRefeicao(RefeicaoModel refeicao)
        {
             
            await _refeicaoRepository.AdicionarRefeicao(refeicao);
            return refeicao;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarRefeicao(RefeicaoModel refeicao, int id)
        {
            await _refeicaoRepository.AtualizarRefeicao(refeicao, id);
            return Ok(refeicao);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirRefeicao(int id)
        {
            await _refeicaoRepository.ExcluirRefeicao(id);
            return Ok();
        }

    }
}
