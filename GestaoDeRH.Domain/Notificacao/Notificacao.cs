#nullable disable

using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Dominio.Notificacao
{
    public class Notificacao : Entidade
    {
        public virtual Colaborador Destinatario { get; set; }
        public string Mensagem { get; set; }

        //TODO Desafio: tracker data e hora da notificacao e evento de origem.
    }
}
