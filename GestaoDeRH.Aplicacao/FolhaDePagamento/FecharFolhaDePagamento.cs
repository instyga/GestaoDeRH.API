using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.FolhaDePagamento;
using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Aplicacao.FolhaDePagamento.DTO;
using GestaoDeRH.Aplicacao.FolhaDePagamento.Interfaces;


namespace GestaoDeRH.Aplicacao.FolhaDePagamento
{

    public class FecharFolhaDePagamento(IRepositorio<Holerite> holeriteRepositorio, IPontoRepositorio pontoRepositorio, IRepositorio<Colaborador> colaboradorRepositorio) : IFecharFolhaDePagamento
    {
        /// <summary>
        /// Um funcionário tem um contrato para 176 horas mensais.
        /// </summary>
        public const int BASE_DE_HORAS_MENSAL = 176;

        public async Task<ResultadoOperacao<Holerite>> Fechar(FecharFolhaDePagamentoDto dto)
        {
            var resultado = new ResultadoOperacao<Holerite>();
            var colaborador = await colaboradorRepositorio.Obter(dto.ColaboradorId);

            if (colaborador == null)
                resultado.Erros.Add($"Não existe colaborador com id {dto.ColaboradorId}");
            else
            {
                var salarioEmHoras = colaborador.SalarioEmHoras(BASE_DE_HORAS_MENSAL);
                var marcacoes = pontoRepositorio.ListarMarcacoesDePonto(dto.ColaboradorId, dto.DataInicio, dto.DataFim);

                double totalHoras = Ponto.CalculaHorasTrabalhadas(marcacoes);
                //Challenge considerar adicional noturno e domingos em dobro.
                var totalSalario = salarioEmHoras * Convert.ToDecimal(totalHoras);
                //Challenge calculo de IR e INSS.
                Holerite holerite = new()
                {
                    Colaborador = colaborador
                };
                holerite.Lancamentos.Add(new LancamentoHolerite
                {
                    Descricao = "Proventos",
                    Referencia = totalHoras.ToString(),
                    Tipo = TipoLancamento.PROVENTO,
                    Valor = totalSalario
                });

                holerite.TotalDosVencimentos = totalSalario;

                await holeriteRepositorio.Salvar(holerite);
                resultado.Dados = holerite;
            }

            return resultado;
        }

    }
}
