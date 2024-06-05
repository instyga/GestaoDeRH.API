using GestaoDeRH.Dominio.FolhaDePagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class HoleriteConfiguration : IEntityTypeConfiguration<Holerite>
    {
        public void Configure(EntityTypeBuilder<Holerite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalDosDescontos);
            builder.Property(x => x.TotalDosVencimentos);
            
            builder.HasOne(x => x.Colaborador);
            builder.HasMany(x => x.Lancamentos);
        }
    }
}
