using GestaoDeRH.Dominio.Recrutamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);
            builder.Property(x => x.Sobrenome);
            builder.Property(x => x.DataDeNascimento);
            builder.Property(x => x.CPF);
            builder.Property(x => x.RG);
            builder.Property(x => x.SalarioPretendido);
            builder.Property(x => x.Aprovado);

            //Challenge: Mapear todos os candidatos em uma lista na entidade de vaga.
            builder.HasOne(x => x.VagaAplicada);
        }
    }
}
