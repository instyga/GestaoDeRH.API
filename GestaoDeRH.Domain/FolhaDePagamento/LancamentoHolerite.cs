#nullable disable

using GestaoDeRH.Dominio.Base;

namespace GestaoDeRH.Dominio.FolhaDePagamento
{
    public class LancamentoHolerite : Entidade
    {
        public TipoLancamento Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor {get;set;}
        public string Referencia { get; set; }
    }
}
