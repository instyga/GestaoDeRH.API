using GestaoDeRH.Dominio.Base;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Dominio.ControlePonto
{
    public class Ponto : Entidade
    {
        public virtual Colaborador? Colaborador { get; set; }
        public DateTime DataMarcacao { get; set; }

        //Desafio, bug no calculo de horas extras do Holerite. Validar domingo

        public static double CalculaHorasTrabalhadas(List<Ponto> marcacoes)
        {
            marcacoes = [.. marcacoes.OrderBy(p => p.DataMarcacao)];

            double totalHoras = 0;
            DateTime? entrada = null;
            //BUG: Calcular apenas marcações diárias.
            for (int i = 0; i < marcacoes.Count; i++)
            {
                if (entrada == null)
                {
                    entrada = marcacoes[i].DataMarcacao;
                }
                else
                {
                    totalHoras += (marcacoes[i].DataMarcacao - entrada.Value).TotalHours;
                    entrada = null;
                }
            }

            return totalHoras;
        }
    }
}
 