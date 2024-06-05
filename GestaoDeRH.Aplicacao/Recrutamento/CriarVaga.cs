using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Notificacoes;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;
using GestaoDeRH.Aplicacao.Recrutamento.Interfaces;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Dominio.Recrutamento;

namespace GestaoDeRH.Aplicacao.Recrutamento
{
    public class CriarVaga(IRepositorio<Vaga> vagasRepositorio, IRepositorio<Colaborador> colaboradorRepositorio, INotificarColaborador notificarColaborador) : ICriarVaga
    {
        public async Task<ResultadoOperacao<VagaDto>> Criar(VagaDto vaga)
        {
            var resultado = new ResultadoOperacao<VagaDto>();
            var criadorDaVaga = await colaboradorRepositorio.Obter(vaga.ColaboradorId);

            if (criadorDaVaga == null)
            {
                resultado.Erros.Add($"Colaborador criador da vaga com id: {vaga.ColaboradorId} não existe");
            }
            else
            {
                var entidade = vaga.CriarEntidade(criadorDaVaga);
                if (entidade.EstaValida(out List<string> erros))
                {
                    await notificarColaborador.Notificar(criadorDaVaga, $"Vaga {vaga.Nome} criada com sucesso.");
                    await vagasRepositorio.Salvar(entidade);
                }
                else
                {
                    resultado.AdicionarErros(erros);
                }
            }

            return resultado;
        }
    }
}
