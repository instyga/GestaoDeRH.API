using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Notificacoes;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;
using GestaoDeRH.Aplicacao.Recrutamento.Interfaces;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Recrutamento;

namespace GestaoDeRH.Aplicacao.Recrutamento
{
    public class NovoCandidato(IRepositorio<Candidato> candidatosRepositorio, IRepositorio<Vaga> vagasRepositorio, INotificarColaborador notificarColaborador) : INovoCandidato
    {
        public async Task<ResultadoOperacao<NovoCandidatoDto>> RegistrarCandidatura(NovoCandidatoDto novoCandidato)
        {
            var resultado = new ResultadoOperacao<NovoCandidatoDto>();
            var vaga = await vagasRepositorio.Obter(novoCandidato.VagaId);

            if (vaga == null)
            {
                resultado.Erros.Add($"Vaga com id: {novoCandidato.VagaId} não existe");
            }
            else
            {
                var entidade = novoCandidato.CriarEntidade(vaga);
                if (entidade.EstaValida(out List<string> errors))
                {
                    await notificarColaborador.Notificar(vaga.AbertaPor, $"Há uma nova candidatura para vaga: {vaga.Nome}");
                    await candidatosRepositorio.Salvar(entidade);
                }
                else
                {
                    resultado.AdicionarErros(errors);
                }
            }

            return resultado;
        }
    }
}
