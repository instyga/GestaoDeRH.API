#nullable disable

using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Dominio.FolhaDePagamento
{
    public class Holerite : Entidade
    {
        public virtual Colaborador Colaborador { get; set; }
        public virtual List<LancamentoHolerite> Lancamentos { get; set; }
        public decimal TotalDosVencimentos { get; set; }
        public decimal TotalDosDescontos { get; set; }

        public decimal ValorLiquidoAReceber { get
            {
                return TotalDosVencimentos - TotalDosDescontos;
            } 
        }


    }

    public enum TipoLancamento
    {
        PROVENTO,
        DESCONTO
    }
}
