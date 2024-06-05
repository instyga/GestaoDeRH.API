using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;

namespace GestaoDeRH.Aplicacao.Recrutamento.Interfaces
{
    public interface IAprovarCandidato
    {
        Task<ResultadoOperacao<CandidatoAprovadoDto>> Aprovar(CandidatoAprovadoDto candidatoAprovadoDto);
    }
}