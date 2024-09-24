using GestaoAlimentos.Data;
using GestaoAlimentos.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestaoAlimentos.Repositories
{
    public class RefeicaoRepository : IRefeicaoRepository
    {
        private readonly AppDbContext _context;

        public RefeicaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RefeicaoModel> AdicionarRefeicao(RefeicaoModel refeicao)
        {
            if (refeicao == null)
            {
                throw new ArgumentNullException(nameof(refeicao), "A refeição não pode ser nula.");
            }

            await _context.Refeicoes.AddAsync(refeicao);
            await _context.SaveChangesAsync();
            return refeicao;
        }

        public async Task<RefeicaoModel> AdicionarRefeicaoParaUsuario(RefeicaoModel refeicao, int UsuarioId)
        {
            
            var usuarioExistente = await _context.Usuarios.Include(u => u.Refeicoes).FirstOrDefaultAsync(u => u.Id == UsuarioId);

            if (usuarioExistente != null)
            {
                usuarioExistente.Refeicoes.Add(refeicao);
                await _context.SaveChangesAsync();
            }

            return refeicao;
        }

        public async Task<RefeicaoModel> AtualizarRefeicao(RefeicaoModel refeicao, int id)
        {
            RefeicaoModel refeicaoPorId = await BuscarRefPorId(id);
            if (refeicaoPorId == null)
            {
                throw new Exception($"Refeição {id} não encontrada");
            }
            var refeicoes = await _context.Refeicoes.Where(refeicaoPorId => refeicaoPorId.Id == id).Include(r => r.Usuario).Select(x => new RefeicaoModel
            {
                Id = x.Id,
                Tipo = x.Tipo,
                Descricao = x.Descricao,
                Usuario = x.Usuario
            }).ToListAsync();

            refeicaoPorId.Tipo = refeicao.Tipo;
            refeicaoPorId.Descricao = refeicao.Descricao;
            refeicaoPorId.Usuario = refeicao.Usuario;
            _context.Entry(refeicaoPorId).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return refeicaoPorId;
        }

        public async Task<RefeicaoModel> BuscarRefPorId(int id)
        {

            var refeicoesPorId = await _context.Refeicoes.FirstOrDefaultAsync(x => x.Id == id);

            var refeicoes = await _context.Refeicoes.Where(refeicoesPorId => refeicoesPorId.Id == id).Include(r => r.Usuario).Select(x => new RefeicaoModel
            {
                Id = x.Id,
                Tipo = x.Tipo,
                Descricao = x.Descricao,
                Usuario = x.Usuario
            }).ToListAsync();

            return refeicoesPorId;

        }

        public async Task ExcluirRefeicao(int id)
        {
            RefeicaoModel refeicoesPorId = await _context.Refeicoes.FirstOrDefaultAsync(x => x.Id == id);
            if (refeicoesPorId == null)
            {
                throw new Exception($"Refeição {id} não encontrada");
            }


            _context.Refeicoes.Remove(refeicoesPorId);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RefeicaoModel>> GetAll()
        {
            var refeicoes = await _context.Refeicoes.Include(r => r.Usuario).Select(x => new RefeicaoModel
            {
                Id = x.Id,
                Tipo = x.Tipo,
                Descricao = x.Descricao,
                Usuario = x.Usuario
            }).ToListAsync();

            return refeicoes;


        }


    }
}
