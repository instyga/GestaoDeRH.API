#nullable disable

namespace GestaoDeRH.Aplicacao.Recrutamento.DTO
{
    public class CandidatoAprovadoDto
    {
        public int CandidatoId { get; set; }
        public decimal SalarioNegociado { get; internal set; }
        public DateTime DataInicioDeTrabalho { get; internal set; }
    }
}
