using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Notificacoes;
using GestaoDeRH.Aplicacao.Recrutamento.DTO;
using GestaoDeRH.Aplicacao.Recrutamento.Interfaces;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Pessoas;
using GestaoDeRH.Dominio.Recrutamento;

namespace GestaoDeRH.Aplicacao.Recrutamento
{
    public class AprovarCandidato(IRepositorio<Candidato> candidatosRepositorio, IRepositorio<Vaga> vagasRepositorio, IRepositorio<Colaborador> colaboradorRepositorio, INotificarColaborador notificarColaborador) : IAprovarCandidato
    {
        public async Task<ResultadoOperacao<CandidatoAprovadoDto>> Aprovar(CandidatoAprovadoDto candidatoAprovadoDto)
        {
            var resultado = new ResultadoOperacao<CandidatoAprovadoDto>();

            Candidato candidatoAprovado = await candidatosRepositorio.Obter(candidatoAprovadoDto.CandidatoId);

            if (candidatoAprovado == null)
                resultado.Erros.Add($"Não existe candidato com id {candidatoAprovadoDto.CandidatoId}");
            else
            {

                candidatoAprovado.AprovarCandidatura();
                candidatoAprovado.VagaAplicada.FecharVaga();

                var novoColaborador = candidatoAprovado.CriarColaborador(candidatoAprovadoDto.DataInicioDeTrabalho, candidatoAprovadoDto.SalarioNegociado);

                await candidatosRepositorio.Salvar(candidatoAprovado);
                await vagasRepositorio.Salvar(candidatoAprovado.VagaAplicada);
                await colaboradorRepositorio.Salvar(novoColaborador);

                await notificarColaborador.Notificar(candidatoAprovado.VagaAplicada.AbertaPor, $"Sua vaga {candidatoAprovado.VagaAplicada.Nome} foi fechada. O candidato {candidatoAprovado.Nome} {candidatoAprovado.Sobrenome} foi aprovado.");

            }

            return resultado;
        }
    }
}
