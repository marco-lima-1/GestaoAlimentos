using GestaoAlimentos.Data;
using GestaoAlimentos.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GestaoAlimentos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            await _appDbContext.Usuarios.AddAsync(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel user = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("user nao encontrado.");
            }
            user.Nome = usuario.Nome;
            user.Refeicoes = usuario.Refeicoes;
            user.Dieta = usuario.Dieta;
            await _appDbContext.SaveChangesAsync();
            _appDbContext.Entry(usuario).State = EntityState.Modified;

            return user;
        }

        public async Task<IEnumerable<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            var usuarioPorId = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            var usuario = await _appDbContext.Usuarios.Where(usuarioPorId => usuarioPorId.Id == id).Include(r => r.Refeicoes).Select(x => new UsuarioModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Dieta = x.Dieta,
                
            }).ToListAsync();

            return usuario;
        }

        public async Task ExcluirUsuario(int id)
        {
            UsuarioModel user = await _appDbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("user nao encontrado.");
            }

            _appDbContext.Usuarios.Remove(user);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            List<UsuarioModel> users = await _appDbContext.Usuarios.Include(u => u.Refeicoes).ToListAsync();


            return users;
        }

    }
}
