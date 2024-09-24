using GestaoAlimentos.Models;

namespace GestaoAlimentos.Repositories
{
    public interface IRefeicaoRepository
    {
        Task<IEnumerable<RefeicaoModel>> GetAll();
        Task<RefeicaoModel> BuscarRefPorId(int id);
        Task<RefeicaoModel> AdicionarRefeicao(RefeicaoModel refeicao);
        Task<RefeicaoModel> AdicionarRefeicaoParaUsuario(RefeicaoModel refeicao, int UsuarioId);
        Task<RefeicaoModel> AtualizarRefeicao(RefeicaoModel refeicao, int id);
        Task ExcluirRefeicao(int id);
    }
}
