using GestaoDeRH.Dominio.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);
            builder.Property(x => x.Sobrenome);
            builder.Property(x => x.DataDeNascimento);
            builder.Property(x => x.CPF);
            builder.Property(x => x.RG);
            builder.Property(x => x.DataInicioContratoDeTrabalho);
            builder.Property(x => x.DataFimContratoDeTrabalho);
            builder.Property(x => x.Salario);
            builder.Property(x => x.Cargo);
        }
    }
}
