using GestaoAlimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoAlimentos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RefeicaoModel> Refeicoes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasMany(u => u.Refeicoes)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);
        }
    }
}
