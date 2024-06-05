using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Dominio.FolhaDePagamento;
using GestaoDeRH.Dominio.Notificacao;
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Dominio.Recrutamento;
using GestaoDeRH.Infra.BancoDeDados.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GestaoDeRH.Infra.BancoDeDados
{
    public class GestaoDeRhDbContext(DbContextOptions<GestaoDeRhDbContext> options) : DbContext(options)
    {
        public DbSet<Ponto> Pontos { get; set; }
        public DbSet<Holerite> Holerites { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Vaga> Vagas  { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColaboradorConfiguration).Assembly);
            

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite().UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }


        public class GestaoDeRhDbContextFactory : IDesignTimeDbContextFactory<GestaoDeRhDbContext>
        {
            public GestaoDeRhDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<GestaoDeRhDbContext>();
                builder.UseSqlite($@"Data Source={Path.Combine("..", "LocalDatabase.db")}");
                return new GestaoDeRhDbContext(builder.Options);
            }
        }
    }
}
