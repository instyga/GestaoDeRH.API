using GestaoDeRH.Dominio.FolhaDePagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class LancamentoHoleriteConfiguration : IEntityTypeConfiguration<LancamentoHolerite>
    {
        public void Configure(EntityTypeBuilder<LancamentoHolerite> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao);
            builder.Property(x => x.Valor);
            builder.Property(x => x.Referencia);
        }
    }
}
