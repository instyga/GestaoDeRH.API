using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Aplicacao.ControlePonto.DTO;
using GestaoDeRH.Aplicacao.ControlePonto.Interfaces;

namespace GestaoDeRH.Aplicacao.ControlePonto
{
    public class MarcacaoPonto(IRepositorio<Ponto> pontoRepositorio, IRepositorio<Colaborador> colaboradorRepositorio) : IMarcacaoPonto
    {
        public async Task<ResultadoOperacao<PontoDto>> Marcar(PontoDto marcacaoPonto)
        {
            var resultado = new ResultadoOperacao<PontoDto>();
            var colaborador = await colaboradorRepositorio.Obter(marcacaoPonto.ColaboradorId);

            if (colaborador == null)
                resultado.Erros.Add($"Não existe colaborador com id {marcacaoPonto.ColaboradorId}");
            else
            {
                var entidade = marcacaoPonto.CriarEntidade(colaborador);
                await pontoRepositorio.Salvar(entidade);
            }

            return resultado;
        }

    }
}
