using GestaoDeRH.Aplicacao.Recrutamento.DTO;
using GestaoDeRH.Aplicacao.Recrutamento.Interfaces;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Recrutamento;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeRH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecrutamentoController(
        IRepositorio<Vaga> vagasRepositorio,
        ICriarVaga criarVaga,
        INovoCandidato novoCandidato,
        IAprovarCandidato aprovarCandidato) : ControllerBase
    {
        [HttpGet("vaga")]
        public async Task<IEnumerable<Vaga>> ListarVagas()
        {
            return await vagasRepositorio.Listar();
        }

        [HttpPost("vaga")]
        public async Task<IActionResult> NovaVaga(VagaDto novaVaga)
        {
            var resultado = await criarVaga.Criar(novaVaga);

            if (resultado.Sucesso)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpPost("vagas/candidato")]
        public async Task<IActionResult> NovoCandidato(NovoCandidatoDto novoCandidatoDto)
        {
            var resultado = await novoCandidato.RegistrarCandidatura(novoCandidatoDto);

            if (resultado.Sucesso)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpPost("vagas/candidato/aprovado")]
        public async Task<IActionResult> AprovarCandidato(CandidatoAprovadoDto candidatoAprovadoDto)
        {
            var resultado = await aprovarCandidato.Aprovar(candidatoAprovadoDto);

            if (resultado.Sucesso)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        //Desafio criar API de alteração de vagas

        //Criar desafio de desativar sem deletar.

        //Criar relatório de todos os candidatos da vaga que estão dentro da faixa salarial.

        //Criar cadastro de bons candidatos, ou seja, candidatos que não foram aprovados mas que a empresa quer matner como banco de talento.
    }
}
