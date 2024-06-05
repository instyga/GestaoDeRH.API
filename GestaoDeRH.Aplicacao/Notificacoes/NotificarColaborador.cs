using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Notificacao;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Aplicacao.Notificacoes
{
    public class NotificarColaborador(IRepositorio<Notificacao> repositorioNotificacao) : INotificarColaborador
    {
        public async Task Notificar(Colaborador colaborador, string mensagem)
        {
            var novaNotificacao = new Notificacao
            {
                Destinatario = colaborador,
                Mensagem = mensagem
            };

            await repositorioNotificacao.Salvar(novaNotificacao);
        }
    }
}
