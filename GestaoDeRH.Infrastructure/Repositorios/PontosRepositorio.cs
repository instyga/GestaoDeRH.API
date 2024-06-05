using GestaoDeRH.Dominio.ControlePonto;
using GestaoDeRH.Infra.BancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeRH.Infra.Repositorios
{
    public class PontosRepositorio(GestaoDeRhDbContext dbContext) : RepositorioGenerico<Ponto>(dbContext), IPontoRepositorio
    {
        public List<Ponto> ListarMarcacoesDePonto(int colaboradorId, DateTime inicio, DateTime fim)
        {
            return [.. _dbContext.Pontos.Where(x => x.Colaborador != null && x.DataMarcacao >= inicio && x.DataMarcacao <= fim && x.Colaborador.Id == colaboradorId)];
        }

        public async Task<List<Ponto>> ListarTodasMarcacoesDePontoPorCPF(string cpfColaborador)
        {
            return await _dbContext.Pontos.Where(x => x.Colaborador != null && x.Colaborador.CPF == cpfColaborador).ToListAsync();
        }
    }
}
