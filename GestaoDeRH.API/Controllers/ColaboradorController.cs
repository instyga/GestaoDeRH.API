using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Pessoas;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeRH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController(IRepositorio<Colaborador> repositorioColaborador) : ControllerBase
    {
        [HttpGet("")]
        public async Task<List<Colaborador>> ListarColaboradores() => await repositorioColaborador.Listar();

        [HttpPost("")]
        public async Task<IActionResult> CriarColaborador(Colaborador novoColaborador)
        {
            if (novoColaborador.Id > 0)
                return BadRequest("Novo colaborador não pode conter um ID.");

            await repositorioColaborador.Salvar(novoColaborador);
            return Ok(novoColaborador);
        }

        [HttpPut("")]
        public async Task<IActionResult> AtualizarOuCriarColaborador(Colaborador novoColaborador)
        {
            await repositorioColaborador.Salvar(novoColaborador);
            return Ok(novoColaborador);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeletarColaborador(Colaborador novoColaborador)
        {
            if (novoColaborador.Id <= 0)
                return BadRequest("Não pode deletar um colaborador sem ID.");

            await repositorioColaborador.Deletar(novoColaborador.Id);
            return NoContent();
        }
    }
}
