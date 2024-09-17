using GestaoAlimentos.Data;
using GestaoAlimentos.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAlimentos.Repositories
{
    public class RefeicaoRepository : IRefeicaoRepository
    {
        private readonly AppDbContext _context;

        public RefeicaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarRefeicao(RefeicaoModel refeicao)
        {
            if (refeicao == null)
            {
                throw new ArgumentNullException(nameof(refeicao), "A refeição não pode ser nula.");
            }

            await _context.Refeicoes.AddAsync(refeicao);
            await _context.SaveChangesAsync();
        }

       

        public async Task<RefeicaoModel> AtualizarRefeicao(RefeicaoModel refeicao, int id)
        {
            RefeicaoModel refeicaoPorId = await BuscarRefPorId(id);
            if (refeicaoPorId == null)
            {
                throw new Exception($"Refeição {id} não encontrada");
            }

            refeicaoPorId.Tipo = refeicao.Tipo;
            refeicaoPorId.Descricao = refeicao.Descricao;
            _context.Entry(refeicaoPorId).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return refeicaoPorId;
        }

        public async Task<RefeicaoModel> BuscarRefPorId(int id)
        {
           
            return await _context.Refeicoes.FirstOrDefaultAsync(x => x.Id == id);
            
            
        }

        public async Task ExcluirRefeicao(int id)
        {
            RefeicaoModel refeicao = await _context.Refeicoes.FirstOrDefaultAsync(x => x.Id == id);
            if (refeicao == null)
            {
                throw new Exception($"Refeição {id} não encontrada");
            }
            _context.Refeicoes.Remove(refeicao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RefeicaoModel>> GetAll()
        {
            return await _context.Refeicoes.ToListAsync();

        }

       
    }
}
