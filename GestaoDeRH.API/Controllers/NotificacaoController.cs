using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Notificacao;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeRH.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificacaoController(IRepositorio<Notificacao> repositorio) : ControllerBase
    {
        [HttpGet("")]
        public async Task<List<Notificacao>> ListarNotificacoes() => await repositorio.Listar();

    }
}
