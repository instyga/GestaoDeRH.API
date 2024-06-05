using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;

namespace GestaoDeRH.Aplicacao.Recrutamento.Interfaces
{
    public interface INovoCandidato
    {
        Task<ResultadoOperacao<NovoCandidatoDto>> RegistrarCandidatura(NovoCandidatoDto novoCandidato);
    }
}