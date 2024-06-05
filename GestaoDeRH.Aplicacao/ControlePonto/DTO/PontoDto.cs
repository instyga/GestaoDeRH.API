using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Dominio.Pessoas;

namespace GestaoDeRH.Aplicacao.ControlePonto.DTO
{
    public class PontoDto
    {
        public int ColaboradorId { get; set; }
        public DateTime DataHoraMarcacao { get; set; }

        public Ponto CriarEntidade(Colaborador colaborador)
        {
            return new Ponto
            {
                Colaborador = colaborador,
                DataMarcacao = DataHoraMarcacao,
            };
        }
    }
}
