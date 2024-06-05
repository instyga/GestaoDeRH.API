using GestaoDeRH.Aplicacao.ControlePonto.DTO;
using GestaoDeRH.Aplicacao.ControlePonto.Interfaces;
using GestaoDeRH.Dominio.ControlePonto;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeRH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontoController(IMarcacaoPonto marcarPonto, IPontoRepositorio repositorio) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Ponto(PontoDto ponto)
        {
            var resultado = await marcarPonto.Marcar(ponto);
            if (resultado.Sucesso)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpGet("colaborador/{cpfColaborador}")]
        public async Task<IActionResult> Listar([FromRoute] string cpfColaborador)
        {
            var pontos = await repositorio.ListarTodasMarcacoesDePontoPorCPF(cpfColaborador);

            if (pontos != null && pontos.Any())
                return Ok(pontos);
            else
                return NotFound();
        }
    }
}
