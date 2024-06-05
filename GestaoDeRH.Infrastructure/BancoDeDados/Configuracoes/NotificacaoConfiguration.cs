using GestaoDeRH.Dominio.Notificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class NotificacaoConfiguration : IEntityTypeConfiguration<Notificacao>
    {
        public void Configure(EntityTypeBuilder<Notificacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Mensagem);
            builder.HasOne(x => x.Destinatario);
        }
    }
}
