using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.ControlePonto.DTO;

namespace GestaoDeRH.Aplicacao.ControlePonto.Interfaces
{
    public interface IMarcacaoPonto
    {
        Task<ResultadoOperacao<PontoDto>> Marcar(PontoDto marcacaoPonto);
    }
}