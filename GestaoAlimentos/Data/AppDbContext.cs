using GestaoAlimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAlimentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RefeicaoModel> Refeicoes { get; set; }
    }
}
