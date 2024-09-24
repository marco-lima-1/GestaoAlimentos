using GestaoAlimentos.Models;

namespace GestaoAlimentos.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> GetAll();
        Task<IEnumerable<UsuarioModel>> BuscarUsuarioPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
        Task ExcluirUsuario(int id);
    }
}
