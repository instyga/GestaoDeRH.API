using GestaoDeRH.Dominio.Recrutamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class VagaConfiguration : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);
            builder.Property(x => x.FaixaSalarialMin);
            builder.Property(x => x.FaixaSalarialMax);
            builder.Property(x => x.Aberta);

            builder.HasOne(x => x.AbertaPor);
        }
    }
}
