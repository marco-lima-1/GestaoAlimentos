using GestaoAlimentos.Models;

namespace GestaoAlimentos.Repositories
{
    public interface IRefeicaoRepository
    {
        Task<IEnumerable<RefeicaoModel>> GetAll();
        Task<RefeicaoModel> BuscarRefPorId(int id);
        Task AdicionarRefeicao(RefeicaoModel refeicao);
        Task<RefeicaoModel> AtualizarRefeicao(RefeicaoModel refeicao, int id);
        Task ExcluirRefeicao(int id);
    }
}
