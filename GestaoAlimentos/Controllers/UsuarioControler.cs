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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("Listar todos")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetAll()
        {
            var users = await _usuarioRepository.GetAll();
            return users.ToList();
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            var user = await _usuarioRepository.BuscarUsuarioPorId(id);
            return user.ToList();
        }


        [HttpPost("Adicionar usuario")]
        public async Task<ActionResult<UsuarioModel>> AdicionarUsuario(UsuarioModel usuario)
        {
            await _usuarioRepository.AdicionarUsuario(usuario);
            return Ok("Usuario adcionado com sucesso");
        }
        [HttpPut("Atualizar usuario")]
        public async Task<ActionResult<UsuarioModel>> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            await _usuarioRepository.AtualizarUsuario(usuario, id);
            return Ok(usuario);
        }

        [HttpDelete("Deletar usuario")]
        public async Task<ActionResult> ExcluirUsuario(int id)
        {
            await _usuarioRepository.ExcluirUsuario(id);
            return Ok();
        }

    }

}

