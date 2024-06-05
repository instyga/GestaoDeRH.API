using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Aplicacao.Notificacoes
{
    public interface INotificarColaborador
    {
        Task Notificar(Colaborador colaborador, string mensagem);
    }
}