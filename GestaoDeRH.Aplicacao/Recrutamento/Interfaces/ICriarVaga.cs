using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;

namespace GestaoDeRH.Aplicacao.Recrutamento.Interfaces
{
    public interface ICriarVaga
    {
        Task<ResultadoOperacao<VagaDto>> Criar(VagaDto vaga);
    }
}