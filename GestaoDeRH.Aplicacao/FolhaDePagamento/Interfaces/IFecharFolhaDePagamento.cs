using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.FolhaDePagamento.DTO;
using GestaoDeRH.Dominio.FolhaDePagamento;

namespace GestaoDeRH.Aplicacao.FolhaDePagamento.Interfaces
{
    public interface IFecharFolhaDePagamento
    {
        Task<ResultadoOperacao<Holerite>> Fechar(FecharFolhaDePagamentoDto dto);
    }
}